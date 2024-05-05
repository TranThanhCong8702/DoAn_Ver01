using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    [SerializeField] float HP = 50f;
    [SerializeField] Image HPbar;
    [SerializeField] List<Transform> target;
    [SerializeField] float attackRange = 10f;
    [SerializeField] int iAddAMount = 1;
    [SerializeField] GameObject player;
    [SerializeField] Collider2D col;

    [SerializeField] Vector3 DefaultPos;
    [SerializeField] Animator anim;
    public float speed = 5f;
    public float rotateSpeed = 200f;
    private Rigidbody2D rb;
    int i = 0;
    public bool IsAlive;
    [SerializeField] float attackDistance = 2f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HPbar.fillAmount = HP/50;
    }

    private void OnDisable()
    {
        IsAlive = true;
        col.enabled = true;
        transform.position = DefaultPos;
        HP = 50f;
        i = 0;
        iAddAMount = 1;
    }

    private void OnEnable()
    {
        anim.Play("Idle");
        HPbar.fillAmount = HP / 50;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bomb"))
        {
            StartCoroutine(Bombed(collision));
        }
    }

    IEnumerator Bombed(Collider2D collision)
    {
        yield return new WaitUntil(() => collision.CompareTag("Missile"));
        var t = collision.GetComponent<Weapons>();
        if(HP > 0)
        {
            HP -= t.Damage * 5;
            HPbar.fillAmount = HP / 50;
            if (HP <= 0)
            {
                IsAlive = false;
                anim.Play("Death");
                col.enabled = false;
                GameManager.instance.StoryWin();
                Pref_Data.Gold += 50;
                UIController.instance.storuUI.gold.text = Pref_Data.Gold.ToString();
                ObjectPool.instance.ReturnAllPool();
            }
        }
        collision.enabled = false;
    }

    void FixedUpdate()
    {
        if (!IsAlive) { return; }
        player = GameManager.instance.playersCurr[0];
        if (player && Vector2.Distance(rb.position, (Vector2)player.GetComponent<Movement2>().Hip.position) < attackRange)
        {
            if (Vector2.Distance(rb.position, (Vector2)player.GetComponent<Movement2>().Hip.position) < attackDistance)
            {
                anim.Play("Attack");
            }
            Vector2 direction = (Vector2)player.GetComponent<Movement2>().Hip.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
        else
        {
            Vector2 direction = (Vector2)target[i].position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;

            if (Vector2.Distance((Vector2)rb.position, (Vector2)target[i].position) < 0.3f)
            {
                i += iAddAMount;
                if (i >= target.Count - 1)
                {
                    iAddAMount = -iAddAMount;
                }
                else if (i <= 0 && iAddAMount < 0)
                {
                    iAddAMount = -iAddAMount;
                }
            }
        }
    }
}
