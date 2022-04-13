using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Vector3 objPos;


    // Start is called before the first frame update
    void Start()
    {
        objPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            FindObjectOfType<HealthManager>().setRespawnPoint(objPos);
        }
    }
}
