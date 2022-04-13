using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == ("Enemy"))
        {
            Debug.Log("Hit");
            FindObjectOfType<HealthManager>().HurtPlayer(1);
        }
    }
}
