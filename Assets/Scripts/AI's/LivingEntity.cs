using UnityEngine;
using System.Collections;

public class LivingEntity : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected float startingHealth;//how much health at the start
    protected float health;//how much health
    protected bool dead;//to be or not to be :)

    public event System.Action OnDeath;

    protected virtual void Start()
    {
        health = startingHealth;//sets health  
    }

    public void TakeDamg(float damage)
    {
        health -= damage;
        if (health <= 0 && !dead)
        {
            Invoke("death",0);

            //print("killed by mayro minion");
        }
    }
    
    public void knockBack(Transform centerSmash)
    {
        
    }

    virtual protected void death()//when would this be used >_>
    {
        dead = true;
        if (OnDeath != null)
            OnDeath();
        GameObject.Destroy(gameObject);
    }

   
}