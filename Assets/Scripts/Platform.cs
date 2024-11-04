using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject platformBlast;
    private void Start()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("falldown", 0.2f);
        }
    }

    void falldown()
    {
        Instantiate(platformBlast,transform.position, Quaternion.identity);
        GetComponent<Rigidbody>().isKinematic = false;
        if (gameObject != null)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
