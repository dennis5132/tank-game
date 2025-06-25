using UnityEngine;
using UnityEngine.SceneManagement;

public class tankDamage : MonoBehaviour
{
    public TankMovement tank;
    public tankDestruction Destruction;
    public tankManager tankManager;
    private float endTimer;
    
    private bool exploding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (exploding)
        {
            endTimer++;
            //Debug.Log(endTimer);
        }
        if (endTimer > tankManager.endTime)
        {
            Debug.Log("endscreen");
            if (tank.redTank) // checkt welke tank het is en laadt het juiste overwinningsscherm
            {
                SceneManager.LoadScene("redWinScreen");
            }
            else
            {
                SceneManager.LoadScene("blueWinScreen");
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("projectile")) // checkt of de tank geraakt word
        {
            tank.health--;
            if (tank.health < 1)
            {
                exploding = true;
                Destruction.doExplosion(); // activeert explosie script
                tankManager.fadeOut();

            }
        }
    }
}
