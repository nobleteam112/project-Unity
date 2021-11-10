using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    public float speed, jumpforce, back, atk;                 //declaracion de todas la variables que se estan utilizando.
    private float Horizontal, Vertical;
    private bool grounded, air;
    private Rigidbody2D Rigidbody2D;

    void Start()                                              //las acciones realizadas en este apartado solo se realizaran 1 vez cada que se ejecute el script
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();              //aigna a la variable rigidbody2d al componente del mismo nombre
    }

    void Update()                                             // las acciones realizadas aqui se ectualizan cada frames
    {
    Horizontal = Input.GetAxisRaw("Horizontal");
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

    //Debug.DrawRay(transform.position, Vector3.down * 1.6f, Color.red);

            if (Physics2D.Raycast(transform.position, Vector3.down, 1.6f))
                {
                    grounded = true;
                     air = false;
                 }

            else { 
                    grounded = false;
                     air = true;
                 }


            if (Input.GetKeyDown(KeyCode.W) && grounded)
                {
                    Jump();
                }


            if (Input.GetKeyDown(KeyCode.S) && air)
                 {
                    Atack();
                 }


    }

        private void Jump()
        {

         Rigidbody2D.AddForce(Vector2.up * jumpforce);
        
         }

        private void Atack()
         {

         Rigidbody2D.AddForce(Vector3.down * atk);
        }

        private void FixedUpdate()
         {
          Rigidbody2D.velocity = new Vector2(Horizontal * speed, Rigidbody2D.velocity.y);
        }
}