using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankDestruction : MonoBehaviour
{
    public tankManager tankManager;
    //[SerializeField] private float effectDisplayTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void doExplosion()
    {
        handleEffects();
        handleDestruction();
    }
    private void handleEffects()
    {
        if (tankManager.explosion != null)
        {
            GameObject effect = Instantiate(tankManager.explosion, transform.position, Quaternion.identity);
        }
    }
    private void handleDestruction()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, tankManager.radius);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.AddExplosionForce(tankManager.force, transform.position, tankManager.radius);
            }
        }
    }
}
