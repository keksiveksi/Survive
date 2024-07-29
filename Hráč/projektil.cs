using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projektil : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float lifeTime;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) return;
        //pohyb fireballu
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        //když fireball vyletí z mapy tak aby se za 5 vteøin deaktivoval
        lifeTime += Time.deltaTime;
        if(lifeTime > 5)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //když fireball nìco trefí tak se ukáže animece exploze
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");
    }
    
    public void setDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;
        //nastavování otoèení fireballu tak aby vždy smìøoval na jakou stranu letí
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void deactivate()
    {
        //deaktivace fireballu
        gameObject.SetActive(false);
    }
}
