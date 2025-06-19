using UnityEngine;

public class CreateItem : MonoBehaviour
{
    // tempo de coolDown pro disparo
    [SerializeField]
    public float disparoCooldown = 0.2f;

    private float cooldownAtual = 0;



    // objeto que ser� chamado para rodar na fila
    public GameObject prefab;
    
    // controle de dire��o dos eixos para o Rigidbody
    public Vector3 forceDirection;

    private void SpawnObject()
    {
        // "var obj" vai salvar a informa��o do "Instantiate", dentro do Instantiate
        // est� sendo sinalizado para ele conter as informa��o do objeto que ser�
        // spawnado (no caso "prefab"), e a localiza��o desse objeto ("transform")
        var obj = Instantiate(prefab, transform);

        // Chama o Rigidbody do prefab e aplica o "forceDiretion" que criamos para ele
        obj.GetComponent<Rigidbody>().AddForce(forceDirection);
    }

    private void Update()
    {
        // faz reduzir um tmer at� 0 caso seja maior que zero
        if (cooldownAtual > 0)
        {
            cooldownAtual -= Time.deltaTime;
        }
        // aciona enquanto a variavel "cooldownAtual" for igual ou menos que 0 e ao usar a tecla "E",
        // "Espa�o" ou "Mouse0(Bot�o esquerdo)"
        // importante, lembrar de usar o "||" fora da condi��o, se chamar ele dentro
        // de "(KeyCode.)" ele n�o ser� reconhecido, pq � necess�rio finalizar cada
        // senten�a de condi��o e n�o criar uma unica com v�rios conjuntos "ou"
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
