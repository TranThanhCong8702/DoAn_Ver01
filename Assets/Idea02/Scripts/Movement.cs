using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public GameObject leftLeg;
    public GameObject rightLeg;
    Rigidbody2D leftLegRB;
    Rigidbody2D rightLegRB;
    [SerializeField] Rigidbody2D Hip;

    Animator anim;
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float legWait = .5f;
    float Horizontal = 0;
    // Start is called before the first frame update
    void Start()
    {
        leftLegRB = leftLeg.GetComponent<Rigidbody2D>();
        rightLegRB = rightLeg.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(Horizontal != 0)
        {
            if(Horizontal > 0)
            {
                anim.Play("WalkRight");
                MoveRight();
            }
            else
            {
                anim.Play("WalkLeft");
                MoveLeft();

            }
            
        }
        //else
        //{
        //    anim.Play("idle");
        //}
        if (Hip.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Hip.AddForce(new Vector2(0, Input.GetAxis("Vertical")) * (jumpHeight * 1000));
        }
       
    }

    void MoveRight()
    {
        //Hip.AddForce(new Vector2(1, 0f) * (speed * 1000) * Time.deltaTime);
        Hip.velocity = new Vector2(1 * (speed), 0);
    }
    void MoveLeft()
    {
        //Hip.AddForce(new Vector2(-1, 0f) * (speed * 1000) * Time.deltaTime);
        Hip.velocity = new Vector2(-1 * (speed), 0);
    }
}
