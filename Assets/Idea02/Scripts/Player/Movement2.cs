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
    public Rigidbody2D leftHandRB;
    public Rigidbody2D rightHandRB;
    public Rigidbody2D leftHandRBlow;
    public Rigidbody2D rightHandRBlow;
    [SerializeField] float handForce = 1000f;

    [Header("Hook")]
    [SerializeField] Hooks hook;

    //public Camera cam;
    public LineRenderer _line;

    public Rigidbody2D Hip;
    Animator anim;

    [SerializeField] float MaxSpeed;
    [SerializeField] float YMaxSpeed;

    [SerializeField] float deAccelRate;

    [SerializeField] float speed = 2f;
    [SerializeField] float legWait = .5f;

    [Header("Player's State")]
    [SerializeField] BulletSapwner bulletspawner;
    [SerializeField] Playermanager playermanager;
    [SerializeField] PlayerBomb_Hand bombhand;
    public bool hasBomb = true;

    [Header("Other State")]
    public bool IsCCed;
    public bool MouseIsUp = true;
    public bool isStandDown = false;
    public Vector2 moveVal;

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
        if (MouseIsUp)
        {
            MouseIsUp = false;
            hook.gameObject.SetActive(true);
            if(moveVal != Vector2.zero)
            {
                hook.rb.AddForce(/*hook.transform.parent.up*/moveVal.normalized * (hook.speed * 100), ForceMode2D.Force);
            }
            else
            {
                hook.rb.AddForce(hook.transform.parent.up * (hook.speed * 100), ForceMode2D.Force);
            }
        }
        else
        {
            hook.transform.position = leftHandRBlow.position;
            hook.DisableJoint();
            hook.gameObject.SetActive(false);
            _line.SetPosition(0, leftHandRBlow.position);
            _line.SetPosition(1, leftHandRBlow.position);
            MouseIsUp = true;
        }

    }


    void OnJump(InputValue val)
    {
        if (val.isPressed && hasBomb)
        {
            bombhand.Throw();
            hasBomb = false;
            playermanager.ManaBarVal = 0;
        }
    }
    void HandController()
    {
        float angle = -Mathf.Atan2(moveVal.x, moveVal.y) * Mathf.Rad2Deg;
        leftHandRBlow.MoveRotation(Mathf.LerpAngle(leftHandRBlow.rotation, angle, handForce * Time.deltaTime));
        rightHandRBlow.MoveRotation(Mathf.LerpAngle(leftHandRBlow.rotation, angle, handForce * Time.deltaTime));
        leftHandRB.MoveRotation(Mathf.LerpAngle(leftHandRBlow.rotation, angle, handForce * Time.deltaTime));
        rightHandRB.MoveRotation(Mathf.LerpAngle(leftHandRBlow.rotation, angle, handForce * Time.deltaTime));
    }

    void Update()
    {
        if (IsCCed) return;
        if (!MouseIsUp)
        {
            _line.SetPosition(0, leftHandRBlow.position);
            _line.SetPosition(1, hook.transform.position);
            if (Vector2.Distance(hook.transform.position, leftHandRBlow.position) > hook.length)
            {
                hook.transform.position = leftHandRBlow.position;
                hook.DisableJoint();
                hook.gameObject.SetActive(false);
                _line.SetPosition(0, leftHandRBlow.position);
                _line.SetPosition(1, leftHandRBlow.position);
            }
        }
    }
    void FixedUpdate()
    {
        if (IsCCed) return;
        if (moveVal != Vector2.zero)
        {
            HandController();
            if (moveVal.x != 0)
            {
                if (moveVal.x < 0)
                {
                    if (!isStandDown)
                    {
                        anim.Play("WalkLeft");
                    }
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
                    if (!isStandDown) 
                    {
                        anim.Play("WalkRight");
                    }
                    StartCoroutine(MoveRight(legWait));
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
                    isStandDown = true;
                    anim.Play("Down");
                }
                else
                {
                    if (YMaxSpeed < Hip.velocity.y)
                    {
                        Hip.velocity = new Vector2(Hip.velocity.x, MaxSpeed);
                    }
                    else
                    {
                        Hip.velocity = new Vector2(Hip.velocity.x, Hip.velocity.y);
                    }
                    isStandDown = false;
                }
            }
            if (moveVal.y == 0)
            {
                isStandDown = false;
                
            }
        }
        else
        {
            anim.Play("idle");
            isStandDown = false;
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
