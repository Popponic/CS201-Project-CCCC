using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    //public Rigidbody theRB;
    public float jumpForce;
    public float slideFriction = 0.3f;
    private bool isGrounded;
    public CharacterController controller;
    public GameObject enemy;

    private Vector3 moveDirection;
    private Vector3 hitNormal;
    public float gravityScale;
    private bool isJumping;

    public Animator anim;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    // Start is called before the first frame update
    void Start()
    {
        //theRB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        enemy = GetComponent<GameObject>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //    theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        //    if(Input.GetButtonDown("Jump"))
        //    {
        //        theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
        //    }

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        if (knockBackCounter < 0)
        {
            if (!isGrounded)
            {
                moveDirection.x += (1f - hitNormal.y) * hitNormal.x * (moveSpeed - slideFriction);
                moveDirection.z += (1f - hitNormal.y) * hitNormal.z * (moveSpeed - slideFriction);
            }
            float yStore = moveDirection.y;
            moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = yStore;
            isGrounded = Vector3.Angle(Vector3.up, hitNormal) <= controller.slopeLimit;

            if (controller.isGrounded)
            {
                
                //anim.SetBool("isGrounded", controller.isGrounded);
                //anim.SetBool("isJumping", false);
                isJumping = false;
                //anim.SetBool("isFalling", false);
                if (Input.GetButtonDown("Jump"))
                {
                    //moveDirection.y = jumpForce;
                    ////anim.SetBool("isJumping", true);
                    //isJumping = true;
                    Jump();
                }
            }
            else
            {
                moveDirection.y += (Physics.gravity.y * gravityScale * Time.deltaTime);
                if ((isJumping && moveDirection.y < 0))
                {
                    //anim.SetBool("isFalling", true);
                    print("true");
                }
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }
        controller.Move(moveDirection * Time.deltaTime);
        

        //anim.SetBool("isGrounded", controller.isGrounded);
        //anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

    }

    void Jump()
    {
        moveDirection.y = jumpForce;
        //anim.SetBool("isJumping", true);
        isJumping = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == ("EnemyHead"))
        {
            Destroy(hit.transform.parent.gameObject);
            Jump();
        }
        else
        {
            hitNormal = hit.normal;
        }
    }

    public void Knockback(Vector3 direction)
    {
        //anim.SetBool("isKnockedBack", true);
        knockBackCounter = knockBackTime;

        direction = new Vector3(1f, 1f, 1f);

        moveDirection = direction * knockBackForce;
        //anim.SetBool("isKnockedBack", false);

    }

    public void Bounce()
    {
        moveDirection = new Vector3(0, 10, 0);
    }

}

