using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    // Para caso for utilizar a altera��o de um objeto para visivel ou n�o visivel
    //public GameObject fire;
    //private void Awake()
    //{
    //    fire.SetActive(false);
    //}

    // Utilizar Collision pra coisas como cen�rios e objetos do cen�rio, lembrando de evitar se n�o quiser aplicar
    // for�a neles, por exemplo a Rebellion(Espada) do Dante no Devil May cry 3 e 4, se ela usasse Collision, ela atrapalharia
    // fazer qualquer combo, pois os monstros seriam lan�ados pela fisica resultada da colis�o a cada golpe dela,
    // J� em uma porta enquanto est� em combate o Dante � barrado por uma "Sin Door Hand" que lan�a ele pra longe 
    // da porta e causa desse, nesse caso a "Sin door hand" pode ter collision pois bloqueia o Dante de prosseguir e lan�a ele 
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

    // Podemos usar trigger pra criar uma �rea invis�vel como quando o player chegar num local X vai ser ativado uma cutscene,
    // ou quando o Sonic encosta em algum espinho ele � morto inst�ntaneamente, simplesmente criando uma �rea nos espinhos
    // que d� dano o suficiente pra ele ser morto, ou usando em equipamentos corpo a corpo como uma espada, onde o trigger
    // calcula o dano e faz alguma anima��o em contato com aquele inimigo pra simular uma pancada, assim a fisica n�o lan�a
    // o inimigo pra longe e atrapalha o combo do player por conta de colis�o, ativar o trigger em collision no inspetor 
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
