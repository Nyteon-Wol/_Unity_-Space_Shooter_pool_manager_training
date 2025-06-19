using UnityEngine;

public class CreateItem : MonoBehaviour
{
    // tempo de coolDown pro disparo
    [SerializeField]
    public float disparoCooldown = 0.2f;

    private float cooldownAtual = 0;



    // objeto que será chamado para rodar na fila
    public GameObject prefab;
    
    // controle de direção dos eixos para o Rigidbody
    public Vector3 forceDirection;

    private void SpawnObject()
    {
        // "var obj" vai salvar a informação do "Instantiate", dentro do Instantiate
        // está sendo sinalizado para ele conter as informação do objeto que será
        // spawnado (no caso "prefab"), e a localização desse objeto ("transform")
        var obj = Instantiate(prefab, transform);

        // Chama o Rigidbody do prefab e aplica o "forceDiretion" que criamos para ele
        obj.GetComponent<Rigidbody>().AddForce(forceDirection);
    }

    private void Update()
    {
        // faz reduzir um tmer até 0 caso seja maior que zero
        if (cooldownAtual > 0)
        {
            cooldownAtual -= Time.deltaTime;
        }
        // aciona enquanto a variavel "cooldownAtual" for igual ou menos que 0 e ao usar a tecla "E",
        // "Espaço" ou "Mouse0(Botão esquerdo)"
        // importante, lembrar de usar o "||" fora da condição, se chamar ele dentro
        // de "(KeyCode.)" ele não será reconhecido, pq é necessário finalizar cada
        // sentença de condição e não criar uma unica com vários conjuntos "ou"
        if (cooldownAtual <= 0 && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.Mouse0)))
        {
            // faz o valor usado para o timer do cooldown ser setado como o valor do cooldown para que a
            // habilidade possa ser usada novamente quando o timer chegar a zero
            SpawnObject();
            cooldownAtual = disparoCooldown;
        }
    }
}
