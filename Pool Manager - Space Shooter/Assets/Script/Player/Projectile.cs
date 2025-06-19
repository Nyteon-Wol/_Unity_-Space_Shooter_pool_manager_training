using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Projectile : MonoBehaviour
{
    // Tempo de vida/duração do projétil
    public float timeToReset = 2f;

    // variavel dada para realizar a movimentação do projétil
    public Vector3 right;

    public string tagToLook = "Enemy";

    public Action OnHitTarget;

    void Update()
    {
        transform.Translate(right * Time.deltaTime);        
    }
    public void StartProjectile()
    {
        Invoke("FinishUsage", timeToReset);        
    }
    private void FinishUsage()
    {
        // Deixa o objeto setado para "false" após o uso, ou seja, desativa o objeto
        gameObject.SetActive(false);
        OnHitTarget = null;
    }

    // Ao colidir o código faz a verificação de se é a tag armazenada na variavel
    // "tagToLook", se for ele destroi o game Object que foi acertado com
    // "Destroy(collision.gameObject);", depois disso verifica se "OnHitTarget" é válido
    // caso seja valido o "Invoke" chama o "FinishUsage" para desativar o gameobject
    // e fazer ele voltar ao pool, é chamado o "invoke" invés de diretamente o "FinishUsage"
    // para que possa ser chamado também o "timeToReset" e controlar o tempo para
    // desativação do projétil, então sim chamamos diretamente o "FinishUsage",
    // onde também torna o "OnHitTarget" como nulo para voltarmos a utilizar ele do 
    // principio
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagToLook)
        {
            Destroy(collision.gameObject);
            OnHitTarget?.Invoke();
            FinishUsage();
        }
    }
}
