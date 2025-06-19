using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject prefab;

    // Lista do que ser� instanciado no pool
    public List<GameObject> pooledObjects;

    // Insere a quantidade de objetos para o pool
    public int amount = 20;

    private void Awake()
    {
        // Inicia o pool assim que o script for carregado
        StartPool();
    }

    // inicializa o pool, esse m�todo funciona assim:
    // 1 -  faz com a que variavel "pooledObjects" seja uma lista do tipo "GameObject"
    // 2 - o "for" vai passar a quantidade de vezes que foi definida na variavel "amount"
    // 3 - dentro do "for" vai instanciar o prefab que foi definido no inspector e o transform do objeto
    // 4 - o objeto instanciado vai ser desativado com o "SetActive(false)"
    // 5 - o objeto ap�s ser desativado, vai ser adicionado na lista "pooledObjects" e ent�o adicionado
    // ao pool
    // 6 - "pooledObjects.Add(obj);" faz com que seja Adicionado o objeto que est� passando dentro do for para dentro
    // d� variavel "pooledObjects", e o (obj) joga esse objeto adicionado para dentro da variavel obj que foi criada
    // dentro do "for"
    private void StartPool()
    {
        pooledObjects = new List<GameObject>();
        for(int i = 0; i < amount; i++)
        {
            var obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amount; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        // retorna nulo se n�o tiver objetos ativos
        return null;
    }

}
