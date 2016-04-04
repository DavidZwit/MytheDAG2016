using UnityEngine;
using System.Collections;

public class CurveShot : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float firingAngle = 45.0f;
    [SerializeField]
    private float gravity = 9.8f;
    [SerializeField]
    private float delayTime = 1f;
    [SerializeField]
    private GameObject nozzle;
    [SerializeField]
    private Transform projectile;
    RandomShake screenShake;
    private GameObject handler;

    public bool _curveShootAnim = false;

    void Awake()
    {
        handler = GameObject.Find("Handeler");
        //With the invokeReapeat the catapult can shoot more then 1 projectile.
        InvokeRepeating("CoroutineProjectile", 1, 5);
        screenShake = GameObject.Find("Camera").GetComponent<RandomShake>();

    }

    void CoroutineProjectile()
    {
        //Starts the SimulateProjectile IEnumarator.
        StartCoroutine(SimulateProjectile());

    }

    IEnumerator SimulateProjectile()
    {
        projectile.position = new Vector3(projectile.position.x, projectile.position.y, projectile.position.z);

        // Short delay added before Projectile is thrown.
        yield return new WaitForSeconds(delayTime);


        PlayAudio(1);
        //Sets the Catapult Animation True
        _curveShootAnim = true;
        // Move projectile to the position of throwing object + add some offset if needed.
        projectile.position = nozzle.transform.position;

        // Calculate distance to target.
        float targetDistance = Vector3.Distance(projectile.position, target.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectileVelocity = targetDistance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity.
        float VelocityX = Mathf.Sqrt(projectileVelocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float VelocityY = Mathf.Sqrt(projectileVelocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = targetDistance / VelocityX;

        // Rotate projectile to face the target.
        projectile.rotation = Quaternion.LookRotation(target.position - projectile.position);

        float elapseTime = 0;

        while (elapseTime < flightDuration)
        {

            //The Projectile will keep flying until it has reached his target location.
            projectile.Translate(0, (VelocityY - (gravity * elapseTime)) * Time.deltaTime, VelocityX * Time.deltaTime);

            elapseTime += Time.deltaTime;

            yield return null;
        }

        projectile.position = new Vector3(projectile.position.x, 0, projectile.position.z);
        //screenShake.Shake(new Vector2(0.2f, 0.2f), 0.2f, 0.01f);

        //Sets the Catapult Animation false
        _curveShootAnim = false;

    }

    void PlayAudio(int audioID)
    {
        handler.GetComponent<SoundManager>().PlayAudioIfNotPlaying(audioID);
    }


}