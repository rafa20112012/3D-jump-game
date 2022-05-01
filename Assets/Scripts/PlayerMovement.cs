using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerMovement : MonoBehaviour
    {
        Rigidbody rb;
        [SerializeField] float movementSpeed = 6f;
        [SerializeField] float jumpForce = 5f;

        [SerializeField] Transform groundCheck;
        [SerializeField] LayerMask ground;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            float horizontalImput = Input.GetAxis("Horizontal");
            float verticalImput = Input.GetAxis("Vertical");

            rb.velocity = new Vector3(horizontalImput * movementSpeed, rb.velocity.y, verticalImput * movementSpeed);

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                Jump();
             
            }

        
        }
         void Jump()
         {
              rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
         }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy Head"))
            {
                 Destroy(collision.transform.parent.gameObject);
                 Jump();
            }
        }

         bool IsGrounded()
        {
           return Physics.CheckSphere(groundCheck.position, .1f, ground);

        }
    }

