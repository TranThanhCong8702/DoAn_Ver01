using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public GameObject leftLeg;
    public GameObject rightLeg;
    Rigidbody2D leftLegRB;
    Rigidbody2D rightLegRB;

    [SerializeField] Rigidbody2D leftLegRBlow;
    [SerializeField] Rigidbody2D rightLegRBlow;
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

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                anim.Play("WalkLeft");
                StartCoroutine(MoveLeft(legWait));
                Hip.velocity = new Vector2(Hip.velocity.x, 0);
            }
            else
            {
                anim.Play("WalkRight");
                StartCoroutine(MoveRight(legWait));
                Hip.velocity = new Vector2(Hip.velocity.x, 0);
            }

        }
        else
        {
            anim.Play("idle");
            if(Mathf.Abs(Hip.velocity.x) < 3f)
            {
                leftLegRB.velocity = new Vector2(0, Hip.velocity.y);
                rightLegRB.velocity = new Vector2(0, Hip.velocity.y);
                Hip.velocity = new Vector2(0, Hip.velocity.y);
            }
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    leftLegRB.AddForce(Vector2.up * (jumpHeight * 1000));
        //    rightLegRB.AddForce(Vector2.up * (jumpHeight * 1000));
        //}

    }


    IEnumerator MoveRight(float seconds)
    {
        if((leftLegRBlow.IsTouchingLayers(LayerMask.GetMask("Ground")) || rightLegRBlow.IsTouchingLayers(LayerMask.GetMask("Ground"))))
        {
            leftLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
            rightLegRB.AddForce(Vector2.left * (speed * 1000) / 2 * Time.deltaTime);
            yield return new WaitForSeconds(seconds);
            rightLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
            leftLegRB.AddForce(Vector2.left * (speed * 1000) / 2 * Time.deltaTime);
        }
    }

    IEnumerator MoveLeft(float seconds)
    {
        if ((leftLegRBlow.IsTouchingLayers(LayerMask.GetMask("Ground")) || rightLegRBlow.IsTouchingLayers(LayerMask.GetMask("Ground"))))
        {
            rightLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
            leftLegRB.AddForce(Vector2.right * (speed * 1000) / 2 * Time.deltaTime);
            yield return new WaitForSeconds(seconds);
            leftLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
            rightLegRB.AddForce(Vector2.right * (speed * 1000) / 2 * Time.deltaTime);
        }
    }
}
