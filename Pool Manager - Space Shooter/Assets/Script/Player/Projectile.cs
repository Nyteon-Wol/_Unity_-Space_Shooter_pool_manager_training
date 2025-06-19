using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Projectile : MonoBehaviour
{
    // Tempo de vida/dura��o do proj�til
    public float timeToReset = 2f;

    // variavel dada para realizar a movimenta��o do proj�til
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
        // Deixa o objeto setado para "false" ap�s o uso, ou seja, desativa o objeto
        gameObject.SetActive(false);
        OnHitTarget = null;
    }

    // Ao colidir o c�digo faz a verifica��o de se � a tag armazenada na variavel
    // "tagToLook", se for ele destroi o game Object que foi acertado com
    // "Destroy(collision.gameObject);", depois disso verifica se "OnHitTarget" � v�lido
    // caso seja valido o "Invoke" chama o "FinishUsage" para desativar o gameobject
    // e fazer ele voltar ao pool, � chamado o "invoke" inv�s de diretamente o "FinishUsage"
    // para que possa ser chamado tamb�m o "timeToReset" e controlar o tempo para
    // desativa��o do proj�til, ent�o sim chamamos diretamente o "FinishUsage",
    // onde tamb�m torna o "OnHitTarget" como nulo para voltarmos a utilizar ele do 
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
