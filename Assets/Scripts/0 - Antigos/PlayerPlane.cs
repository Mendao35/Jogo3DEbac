using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlane : MonoBehaviour
{
    public GameObject projectile;
    public Transform shootPoint;
    public Vector3 dir;

    public PoolManager poolManager;

    public int deathNumber = 0;

    public bool canMove = false; 

    void Update()
    {
        if (!canMove) return; //So vai executar o Uptade se canMove for verdadeiro

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(dir * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-dir * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        var obj = poolManager.GetPooledObject(); //usa o var obj para pegar a referencia do objeto
        obj.SetActive(true);
        obj.transform.SetParent(null); //Para nao ficar dentro do objeto Pai
        obj.transform.position = shootPoint.transform.position;
        obj.GetComponent<Projectile>().StartProjectile(); // acessando o script e pegando a funcao
        obj.GetComponent<Projectile>().OnHitTarget = CountDeaths;
    }

    private void CountDeaths()
    {
        deathNumber++;
        Debug.Log("Count Death"+deathNumber);
    }
}
