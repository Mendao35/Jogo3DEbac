using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> pooledObjects;
    public int amount = 20;

    private void Awake()
    {
        StartPool();
    }

    private void StartPool()
    {
        pooledObjects = new List<GameObject>(); // Lista precisa ser inicializada
        for(int i = 0; i < amount; i++)
        {
            var obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pooledObjects.Add(obj); // Adiciono o Prefab criado na lista
        }
    }

    public GameObject GetPooledObject() //Esse funcao precisa retornar algo, por isso as verificacoes com Return,
                                        //a funcao serve para pegar o proximo objeto disponivel
    {
        for (int i = 0; i < amount; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)//verifica se o objeto nao estar ativo na lista criada
            {
                return pooledObjects[i]; //Retorna esse objeto porque vamos usar
            }
        }

        return null;
    }

    
}
