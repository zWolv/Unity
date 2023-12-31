using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    private float destroyTimer;
    private float flightTimer;
    [SerializeField] private LayerMask layerMask;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 0)
        {
            Destroy(gameObject);
        }

        if(gameObject.GetComponent<Rigidbody>().velocity == Vector3.zero) 
        {
            destroyTimer += Time.deltaTime;
            if(destroyTimer > 5)
            {
                //Destroy(gameObject);
            }
        }
        flightTimer += Time.deltaTime;
        if(flightTimer >= 15f)
        {
            //Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(layerMask == (layerMask | (1 << other.transform.gameObject.layer)))
        {
            other.transform.parent.parent.gameObject.GetComponent<GenericEnemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
