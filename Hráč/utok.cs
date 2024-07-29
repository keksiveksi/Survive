using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class utok : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private Pohyb pohyb;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        pohyb = GetComponent<Pohyb>();
    }

    private void Update()
    {
        //kontrola jestli m��e �to�it kdy� je zm��knut� lev� tl��tko na mi�i
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && pohyb.canAttack() || Input.GetKeyDown(KeyCode.C) && cooldownTimer > attackCooldown && pohyb.canAttack())
        {
            attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void attack()
    {
        //spu�t�n� animace �toku
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        //nastavov�n� m�sta odkud se budou firebally st��let
        fireballs[findFireball()].transform.position = firePoint.position;
        fireballs[findFireball()].GetComponent<projektil>().setDirection(Mathf.Sign(transform.localScale.x));
    }
     
    private int findFireball()
    {
        //zaji�t�n� v�ce fireball� z�rove� na obrazovce
        for (int i = 0; i < fireballs.Length; i++)
        {
            if(!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
