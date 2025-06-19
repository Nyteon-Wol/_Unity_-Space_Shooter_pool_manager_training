using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    // Para caso for utilizar a alteração de um objeto para visivel ou não visivel
    //public GameObject fire;
    //private void Awake()
    //{
    //    fire.SetActive(false);
    //}

    // Utilizar Collision pra coisas como cenários e objetos do cenário, lembrando de evitar se não quiser aplicar
    // força neles, por exemplo a Rebellion(Espada) do Dante no Devil May cry 3 e 4, se ela usasse Collision, ela atrapalharia
    // fazer qualquer combo, pois os monstros seriam lançados pela fisica resultada da colisão a cada golpe dela,
    // Já em uma porta enquanto está em combate o Dante é barrado por uma "Sin Door Hand" que lança ele pra longe 
    // da porta e causa desse, nesse caso a "Sin door hand" pode ter collision pois bloqueia o Dante de prosseguir e lança ele 
    // pra longe
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(" Collision Enter");
        Destroy(gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(" Collision Stay");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision Exit");
    }

    // Podemos usar trigger pra criar uma área invisível como quando o player chegar num local X vai ser ativado uma cutscene,
    // ou quando o Sonic encosta em algum espinho ele é morto instântaneamente, simplesmente criando uma área nos espinhos
    // que dê dano o suficiente pra ele ser morto, ou usando em equipamentos corpo a corpo como uma espada, onde o trigger
    // calcula o dano e faz alguma animação em contato com aquele inimigo pra simular uma pancada, assim a fisica não lança
    // o inimigo pra longe e atrapalha o combo do player por conta de colisão, ativar o trigger em collision no inspetor 
    // pra que ele responda
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        // fire.SetActive(true);

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger Stay");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit");
        // fire.SetActive(false);
    }

}
