using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] AudioSource landing;

    public GameObject item;
    public Transform theDest;
    public float throwSpeed;
    float distance;
    
    void Update()
    {
        distance = Vector3.Distance(item.transform.position, theDest.transform.position);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Grab();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Drop();
        }
    }

    void Grab()
    {
        if(distance <= 2f)
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            item.transform.position = theDest.position;
            item.transform.parent = GameObject.Find("Destination").transform;
            item.transform.rotation = transform.parent.rotation;
        }
    }

    void Drop()
    {
        if(distance <= 1f) 
        { 
        item.transform.parent = null;
        GetComponent<Rigidbody>().AddForce(theDest.forward * throwSpeed);
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Ground")
        {
            landing.Play();
        }
    }
}
