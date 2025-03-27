using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    public float timeToReset = 5f;
    public Vector3 dir;
    public string tagToLook = "Enemy";

    public Action OnHitTarget;

    public void StartProjectile()
    {
        //Destroy(gameObject, timeToDestroy);
        Invoke(nameof(FinishUsage), timeToReset);//nameOf transforma em String
                                                 // Invoke chame uma funcao depois de um tempo
    }

    private void FinishUsage()
    {
        gameObject.SetActive(false);
        OnHitTarget = null; // Limpar o CallBack
    }


    void Update()
    {
        transform.Translate(dir * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToLook)
        {
            Destroy(collision.transform.gameObject);
            OnHitTarget?.Invoke(); //A ? e confirmando se for valido, ai se for valido ele executa se nao for nao da erro
            FinishUsage();
        }
    }
}
