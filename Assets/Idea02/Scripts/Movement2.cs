using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement2 : MonoBehaviour
{
    [Header("Leg")]
    [SerializeField] Rigidbody2D leftLegRB;
    [SerializeField] Rigidbody2D rightLegRB;

    [SerializeField] Rigidbody2D leftLegRBlow;
    [SerializeField] Rigidbody2D rightLegRBlow;

    [Header("Arm")]
    [SerializeField] Rigidbody2D leftHandRB;
    [SerializeField] Rigidbody2D rightHandRB;
    [SerializeField] Rigidbody2D leftHandRBlow;
    [SerializeField] Rigidbody2D rightHandRBlow;

    public Rigidbody2D Hip;
    Animator anim;

    [SerializeField] float MaxSpeed;
    [SerializeField] float MinSpeed;

    [SerializeField] float deAccelRate;

    [SerializeField] float speed = 2f;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float legWait = .5f;

    public bool IsFlying;
    public bool MouseIsUp = true;
    public bool IsOnGround = true;
    public float jumpDuration = 2f;
    Vector2 moveVal;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
        Debug.Log(moveVal);
    }

    void OnFire(InputValue val)
    {
        if (val.isPressed)
        {
            MouseIsUp = false;
            GameManager.instance.hook.gameObject.SetActive(true);
            var t = GameManager.instance.cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 distanceVector = t - GameManager.instance.hook.transform.position;

            float angle = -Mathf.Atan2(distanceVector.x, distanceVector.y) * Mathf.Rad2Deg;
            GameManager.instance.hook.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            GameManager.instance.hook.rb.AddForce((Vector3.Normalize((Vector2)t - (Vector2)GameManager.instance.hook.transform.position)) * (GameManager.instance.hook.speed * 100), ForceMode2D.Force);
            //IsFlying = true;
        }
    }
    void OnRelease(InputValue val)
    {
        MouseIsUp = true;
        GameManager.instance.hook.transform.position = Hip.position;
        GameManager.instance.hook.DisableJoint();
        GameManager.instance.hook.gameObject.SetActive(false);
        GameManager.instance._line.SetPosition(0, Hip.position);
        GameManager.instance._line.SetPosition(1, Hip.position);
    }

    void OnJump(InputValue val)
    {
        if (val.isPressed && jumpDuration >= 2)
        {
            Hip.velocity = new Vector2(Hip.velocity.x, 0);
            //Hip.velocity = new  Vector2(Hip.velocity.x,(jumpHeight));
            Hip.MovePosition(Hip.position + new Vector2(0, jumpHeight));
            jumpDuration = 0;
        }
    }

    void HandController()
    {
        float angle = -Mathf.Atan2(moveVal.x, moveVal.y) * Mathf.Rad2Deg;
        leftHandRBlow.MoveRotation(angle);
        rightHandRBlow.MoveRotation(angle);
        leftHandRB.MoveRotation(angle);
        rightHandRB.MoveRotation(angle);
    }

    void Update()
    {
        if (jumpDuration < 2)
        {
            jumpDuration += Time.deltaTime;
        }
        if (!MouseIsUp)
        {
            GameManager.instance._line.SetPosition(0, Hip.position);
            GameManager.instance._line.SetPosition(1, GameManager.instance.hook.transform.position);
            if (Vector2.Distance(GameManager.instance.hook.transform.position, Hip.position) > GameManager.instance.hook.length)
            {
                GameManager.instance.hook.transform.position = Hip.position;
                GameManager.instance.hook.DisableJoint();
                GameManager.instance.hook.gameObject.SetActive(false);
                GameManager.instance._line.SetPosition(0, Hip.position);
                GameManager.instance._line.SetPosition(1, Hip.position);
            }
        }
    }
    void FixedUpdate()
    {
        if(moveVal != Vector2.zero)
        {
            HandController();
            if (moveVal.x != 0)
            {
                if (moveVal.x < 0)
                {
                    //if (IsFlying) return;
                    anim.Play("WalkLeft");
                    StartCoroutine(MoveLeft(legWait));
                    if (Mathf.Abs(MaxSpeed) < Mathf.Abs(Hip.velocity.x))
                    {
                        Hip.velocity = new Vector2(-MaxSpeed, Hip.velocity.y);
                    }
                    else
                    {
                        Hip.velocity = new Vector2(Hip.velocity.x, Hip.velocity.y);
                    }
                }
                else
                {
                    //if (IsFlying) return;
                    anim.Play("WalkRight");
                    StartCoroutine(MoveRight(legWait));
                    //Hip.velocity = new Vector2(Hip.velocity.x, 0);
                    if (Mathf.Abs(MaxSpeed) < Mathf.Abs(Hip.velocity.x))
                    {
                        Hip.velocity = new Vector2(MaxSpeed, Hip.velocity.y);
                    }
                    else
                    {
                        Hip.velocity = new Vector2(Hip.velocity.x, Hip.velocity.y);
                    }
                }

            }
            if (moveVal.y != 0)
            {
                if (moveVal.y < 0)
                {
                    //if (IsFlying) return;
                    anim.Play("Down");
                    //if (Hip.velocity.y > 1f)
                    //{
                    //    Hip.AddForce(Vector2.down * jumpHeight * 100);
                    //}
                }
            }
        }
        else
        {
            anim.Play("idle");
        }
    }
    IEnumerator MoveRight(float seconds)
    {

        leftLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
        rightLegRB.AddForce(Vector2.left * (speed * 1000) / 2 * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        rightLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
        leftLegRB.AddForce(Vector2.left * (speed * 1000) / 2 * Time.deltaTime);

    }

    IEnumerator MoveLeft(float seconds)
    {

        rightLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
        leftLegRB.AddForce(Vector2.right * (speed * 1000) / 2 * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        leftLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
        rightLegRB.AddForce(Vector2.right * (speed * 1000) / 2 * Time.deltaTime);
    }
}
