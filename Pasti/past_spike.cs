using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class past_spike : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float damage;
    private PolygonCollider2D colider;
    private float odpocet;
    private bool prosel;

    void Start()
    {
        colider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = speed * Time.deltaTime;

        if (playerDown() || playerUP())
        {
            print("funguje");
            prosel = true;

        }
        else
            print("nefunguje");
        if (prosel)
        {
            odpocet += Time.deltaTime;
            if (odpocet < 2 && prosel)
            {
                transform.Translate(0, moveSpeed, 0);

                if (odpocet > 1.5)
                {
                    //gameObject.SetActive(false);
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private bool playerDown()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(colider.bounds.center, new Vector2(0.3f, 2), 0, Vector2.down, 1, playerLayer);


        return raycastHit.collider != null;
    }

    private bool playerUP()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(colider.bounds.center, new Vector2(0.3f, 2), 0, Vector2.up, 1, playerLayer);

        return raycastHit.collider != null;
    }
}
