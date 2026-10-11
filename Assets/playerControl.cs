using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;

    public KeyCode Spacebar;

    public KeyCode L;
    public KeyCode R;
    
    public Transform groundCheck;
    public float groundCheckRadius ;
    public LayerMask whatIsGround ;
    private bool grounded;


private Animator anim;


   void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }



    void jump(){
        GetComponent<Rigidbody2D>().velocity= new Vector2(GetComponent<Rigidbody2D>().velocity.x , jumpHeight);
    }
    void Start()
    {
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        
         if (Input.GetKey(L))
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed , GetComponent<Rigidbody2D>().velocity.y);

        
        if (GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
  
    }


   if (Input.GetKey(R))
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed , GetComponent<Rigidbody2D>().velocity.y);

        
        if (GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
  

    }



    if (Input.GetKeyDown(Spacebar) && grounded)
        {
            jump();
        }

        anim.SetFloat("speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        
        anim.SetFloat("height", GetComponent<Rigidbody2D>().velocity.y);
        
        anim.SetBool("grounded", grounded);





    }
    

    
    
 

    

}