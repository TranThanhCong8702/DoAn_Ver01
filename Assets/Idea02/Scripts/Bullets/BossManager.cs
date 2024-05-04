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

    [SerializeField] Vector3 DefaultPos;
    public float speed = 5f;
    public float rotateSpeed = 200f;
    private Rigidbody2D rb;
    int i = 0;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HPbar.fillAmount = HP/50;
    }

    private void OnDisable()
    {
        transform.position = DefaultPos;
        HP = 50f;
        i = 0;
        iAddAMount = 1;
    }

    private void OnEnable()
    {
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
        player = GameManager.instance.playersCurr[0];
        if (player && Vector2.Distance(rb.position, (Vector2)player.GetComponent<Movement2>().Hip.position) < attackRange)
        {
            Vector2 direction = (Vector2)player.GetComponent<Movement2>().Hip.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, -transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = -transform.up * speed;
        }
        else
        {
            Vector2 direction = (Vector2)target[i].position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, -transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = -transform.up * speed;

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
