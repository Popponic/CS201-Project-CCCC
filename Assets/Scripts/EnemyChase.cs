using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5;
    private Rigidbody rb;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPosition);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    //void moveCharacter(Vector3 direction)
    //{
    //    rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
    //}
}
