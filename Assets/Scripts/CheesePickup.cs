using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheesePickup : MonoBehaviour
{
    public int value;
    public ParticleSystem pickupEffect;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddCheese(value);
            pickupEffect.transform.position = transform.position;
            pickupEffect.Play();
            Destroy(gameObject);
            //GameObject particle = Instantiate(pickupEffect, transform.position, transform.rotation);

        }
    }
}
