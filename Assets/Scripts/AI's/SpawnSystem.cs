using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnSystem : MonoBehaviour {

    //Scripts
    [SerializeField]
    private Wave[] waves;//ammount of waves
    [SerializeField]
    private EnemyKind[] enemies;//import enemy class

    private Guard enemy;//the enemy that gets spawned
    private EnemyKind currentEnemy;//has the difrend kinds of enemies
    private Wave currentWave;//has the info from current wave
    //Scripts

    //Floats
    [SerializeField]
    private float maxTimeBetweenWaves;//the max ammount of time you get between waves
    private float maxTimeCounter;//actual vallue that counts down to 0
    private float nextSpawnTime;//for checking if if it is time for the next enemy to spawn
    [SerializeField]
    public float wavesCounter;//for counting waves
    //Floats

    //Bool
    [SerializeField]
    private bool _112233;//volgorde soort ennemies, eerst een dan ander
    [SerializeField]
    private bool _123123;//volgorde soort ennemies, om de beurd
    [SerializeField]
    private bool _232113;////volgorde soort ennemies random
    public bool waveDone;//checks if wave is done
    //Bool

    //Int
    private int spawnpointDivider;
    private int currentWaveNum;//which number the current wave is
    private int enemiesToSpawn;//how much are yet to spawn, if 0 then no enemies wil be spawned for this wave
    private int enemiesAlive;//the ammount of enemies that are still alive(includes enemies yet to be spawned
    [HideInInspector]
    public int _percentHP;//percentage hp wat er bij komt
    public int _percentSpeed;//percentage movementspeed wat er bij komt
    public int _percentMoney;//percentage money(recources)
                             //Int

    //GameObject

    //GameObject

    //transforms
    [SerializeField]
    private Transform[] spawnpoints;
    //trandforms

    //AudioSource

    //AudioSource

    void Awake()
    {
        //wavesCounter = 0;
        spawnpointDivider = 0;
        NextWave();
    }

    void Update()
    {
        if(wavesCounter>= 1)
        {
            spawnCheck();
            WavesCheck();
        }
        
    }
    void WavesCheck()
    {
        if (waveDone)
        {
            
            
        }
    }
    void spawnCheck()
    {
        if (enemiesToSpawn > 0 && Time.time > nextSpawnTime)//checks if there are enemies left to spawn this wave and if it is time to spawn a enemy, if it executes it ajusts the amount of enemies that need to spawn, resets the timer and spawns a enemy
        {
            enemiesToSpawn--;
            nextSpawnTime = Time.time + currentWave.spawnTime;

            
            if (_112233)//functie die er voor zorgt dat als 112233 true is dat de eerste eerst worden gespawned dan de 2e en dan de 3e
            {
                if(currentWave.enemyCount1 != 0)
                {
                    currentEnemy = enemies[0];
                    enemy = currentEnemy.enemy;
                    currentWave.enemyCount1--;
                }
                else if (currentWave.enemyCount2 != 0)
                {
                    currentEnemy = enemies[1];
                    enemy = currentEnemy.enemy;
                    currentWave.enemyCount2--;
                }
                else if (currentWave.enemyCount3 != 0)
                {
                    currentEnemy = enemies[2];
                    enemy = currentEnemy.enemy;
                    currentWave.enemyCount3--;
                }
                else if (currentWave.enemyCount4 != 0)
                {
                    currentEnemy = enemies[3];
                    enemy = currentEnemy.enemy;
                    currentWave.enemyCount4--;
                }
                else if (currentWave.enemyCount5 != 0)
                {
                    currentEnemy = enemies[4];
                    enemy = currentEnemy.enemy;
                    currentWave.enemyCount5--;
                }
            }
            if(spawnpointDivider >= spawnpoints.Length)
            {
                spawnpointDivider = 0;
            }
            Guard spawnedEnemy = Instantiate(enemy, spawnpoints[spawnpointDivider].position, Quaternion.identity) as Guard;
            spawnpointDivider++;
            spawnedEnemy.OnDeath += OnEnemyDeath;//when ondeath is called, onenemydeath wil be called to
        }
        if (waveDone == true)
        {
            maxTimeCounter -= Time.deltaTime;

            if (maxTimeCounter <= 0)
            {
                NextWave();
                wavesCounter++;
                waveDone = false;
            }
        }
    }

    void OnEnemyDeath()//decreases the int enemies alive and checks if next wave can start
    {
        enemiesAlive--;
        if(enemiesAlive == 0)
        {
            waveDone = true;
            maxTimeCounter = maxTimeBetweenWaves;
        }
    }

    void NextWave()
    {
        currentWaveNum++;
        if (currentWaveNum - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNum - 1];
            currentWave.enemyCountTotal = currentWave.enemyCount1 + currentWave.enemyCount2 + currentWave.enemyCount3 + currentWave.enemyCount4 ;
            enemiesToSpawn = currentWave.enemyCountTotal;
            enemiesAlive = enemiesToSpawn;
            _percentHP = currentWave.addedPercentageHealth;
            _percentSpeed = currentWave.addedPercentageMovespeed;
            _percentMoney = currentWave.addedPercentageDeathMoney; 
            
        }
    }

    [System.Serializable]
    public class EnemyKind
    {
        public Guard enemy;
    }

    [System.Serializable]
    public class Wave//class for edditing the waves
    {
        public int enemyCount1;//how much nr 1 enemies
        //[HideInInspector]
        public int enemyCount2;//how much nr 2 enemies
        //[HideInInspector]
        public int enemyCount3;//how much nr 3 enemies
        //[HideInInspector]
        public int enemyCount4;//how much nr 4 enemies
        //[HideInInspector]
        public int enemyCount5;//how much nr 5 enemies
        public int enemyCountTotal;//how much enemies in the wave total
        public float spawnTime;//how much time inbetween enemy spawns
        public int addedPercentageHealth;//each ennemy has a static(not yet static this version) base health that wont be changed, to make each wave harder the health that the enemy starts with is baseHealth + (basehealth/100 * addedPercentageHealth). 
        public int addedPercentageMovespeed;//each ennemy has a static(not yet static this version) base movespeed that wont be changed, to make each wave harder the speed that the enemy starts with is baseHealth + (basespeed/100 * addedPercentageMovespeed).
        public int addedPercentageDeathMoney;//each ennemy has a static(not yet static this version) base gold reward for when de enemy gets killed .
        //why percentage? if i add +2 hp each round it makes later on the difrense between tanks and other units insignificant, round 1 tank 10hp speedster 3hp, round 15 tank 40hp speedster 33hp now we have a tanky speedster wich is op or a weak tank. percentage fixes that and same goes for th speed.
    }
}
