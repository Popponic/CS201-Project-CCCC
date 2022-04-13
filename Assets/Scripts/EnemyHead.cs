using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    public GameObject Enemy;
    public PlayerController player;
    public HealthManager hm;
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
        if(other.tag == "Enemy")
        {
            print("Hit2");
        } else
        {
            if (other.tag == "Enemy")
            {
                print("Hit");
                player.Bounce();
                Destroy(Enemy);
                Destroy(this);
            }
            
        }
        
    }
}
