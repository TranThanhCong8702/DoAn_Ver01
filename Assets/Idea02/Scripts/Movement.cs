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
    // Start is called before the first frame update
    void Start()
    {
        leftLegRB = leftLeg.GetComponent<Rigidbody2D>();
        rightLegRB = rightLeg.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            if(Input.GetAxis("Horizontal") > 0)
            {
                anim.Play("WalkRight");
                //StartCoroutine(MoveRight(legWait));
                MoveRight();
            }
            else
            {
                anim.Play("WalkLeft");
                //StartCoroutine(MoveLeft(legWait));
                MoveLeft();

            }
            
        }
        else
        {
            anim.Play("idle");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //leftLegRB.AddForce(Vector2.up * (jumpHeight*1000));
            //rightLegRB.AddForce(Vector2.up * (jumpHeight * 1000));
            if(leftLegRB.IsTouchingLayers(LayerMask.GetMask("Ground")) || rightLegRB.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                Hip.AddForce(new Vector2(0, 1f) * (jumpHeight * 1000));
            }

        }
       
    }

    void MoveRight()
    {
        //Hip.AddForce(new Vector2(1, 0f) * (speed * 1000) * Time.deltaTime);
        Hip.velocity = new Vector2(1 * (speed * 1000) * Time.deltaTime, 0);
    }
    void MoveLeft()
    {
        //Hip.AddForce(new Vector2(-1, 0f) * (speed * 1000) * Time.deltaTime);
        Hip.velocity = new Vector2(-1 * (speed * 1000) * Time.deltaTime, 0);
    }
    //IEnumerator MoveRight(float seconds)
    //{
    //    leftLegRB.AddForce(new Vector2(1, 1f) * (speed * 1000) * Time.deltaTime);
    //    yield return new WaitForSeconds(seconds);
    //    rightLegRB.AddForce(new Vector2(1, 1f) * (speed * 1000) * Time.deltaTime);
    //}

    //IEnumerator MoveLeft(float seconds)
    //{
    //    rightLegRB.AddForce(new Vector2(-1, 1f) * (speed * 1000) * Time.deltaTime);
    //    yield return new WaitForSeconds(seconds);
    //    leftLegRB.AddForce(new Vector2(-1, 1f) * (speed * 1000) * Time.deltaTime);
    //}
}
