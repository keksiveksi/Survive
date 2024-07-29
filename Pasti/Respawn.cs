using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    private past Past;
    void Start()
    {
        Past = GetComponent<past>();

    }

    public void TrapRespawn()
    {
        Past.RestartPozice();
    }
}
