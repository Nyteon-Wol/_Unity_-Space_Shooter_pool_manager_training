using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Enemy_Ghost_Horizontal : MonoBehaviour
{
    public EnemyObject enemySettings;

    // Herança do scriptableObject
    public float speed;
    public string EnemyName;


    // salva o ponto inicial
    private Vector3 initialPosition;

    // metodo de movimento do DoTween
    public Ease ease = Ease.Linear;


    private void Start()
    {
        name = enemySettings.name;
        speed = enemySettings.speed;

        // salva a posição inicial do actor
        initialPosition = transform.position;


        Sequence patrol = DOTween.Sequence();

        // move do ponto A ao ponto B com uma velocidade X, ".append" faz esperar 
        // terminar o comando para a sequência
        patrol.Append(transform.DOMoveZ(5, speed).SetEase(ease));

        // volta para o initialPosition salvo
        patrol.Append(transform.DOMove(initialPosition, speed).SetEase(ease));

        // ".SetLoops(-1)" faz com que o trecho patrol rode em loops infinitamente
        patrol.SetLoops(-1);
    }

    private void Update()
    {
    }
}
