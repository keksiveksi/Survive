using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pohyb : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private Rigidbody2D postava;
    private EdgeCollider2D boxCollider;
    private Animator anim;
    private float horizontalInput;

    private void Awake()
    {
        //získávání komponentù
        postava = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<EdgeCollider2D>();
    }
    void Update()
    {
        //základní pohyb
        horizontalInput = Input.GetAxisRaw("Horizontal");
        
        postava.velocity = new Vector2(horizontalInput * speed, postava.velocity.y);

        //otáèení modelu hráèe
        if (horizontalInput > 0.1f)
            transform.localScale = new Vector3(0.4f, 0.4f, 1);
        else if (horizontalInput < -0.1f)
            transform.localScale = new Vector3(-0.4f, 0.4f, 1) ;
        
        //pouštìní animací na zkok a na bìh
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        //kontrola jestli hráè stojí na zemi nebo jestli je ve vzduchu když zmáèkne space (pokud je na zemi metoda isGrounded vrátí True)
        if (Input.GetKey(KeyCode.Space) && isGrounded() || Input.GetKey(KeyCode.W) && isGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        //skok
        postava.velocity = new Vector2(postava.velocity.x, jumpPower);
        anim.SetTrigger("jump");
    }
    private bool isGrounded()
    {

        //raycast na zem aby se zjistilo jestli mùže skoèit

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        

        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        //nevim jestli budu potøebovat aby mohl útoèit i za letu tak sem to zakomentoval
        return horizontalInput == 0;// && isGrounded();
    }
}
