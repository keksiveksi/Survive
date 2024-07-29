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
        //kontrola jestli mùže útoèit když je zmáèknuté levé tlèítko na miši
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && pohyb.canAttack() || Input.GetKeyDown(KeyCode.C) && cooldownTimer > attackCooldown && pohyb.canAttack())
        {
            attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void attack()
    {
        //spuštìní animace útoku
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        //nastavování místa odkud se budou firebally støílet
        fireballs[findFireball()].transform.position = firePoint.position;
        fireballs[findFireball()].GetComponent<projektil>().setDirection(Mathf.Sign(transform.localScale.x));
    }
     
    private int findFireball()
    {
        //zajištìní více fireballù zároveò na obrazovce
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
