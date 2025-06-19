using UnityEngine;

public class Player : MonoBehaviour
{
    // tempo de coolDown pro disparo
    [SerializeField]
    public float disparoCooldown = 0.2f;
    private float cooldownAtual = 0;

    // controle de dire��o dos eixos para o Rigidbody
    public Vector3 forceDirection;

    // referencia do que ser� usado como referencia para o transform, no caso o ShootPoint que foi criado no inspetor
    public Transform ShootPoint;
    public GameObject Projectile;
    // serve para poder colocar o valor de dire��o no console
    public Vector3 right;

    public PoolManager poolManager;

    public bool canMove = false;

    public MeshRenderer meshRenderer;

    public int deathNumber = 0;

    public void ChangeColor(Color c)
    {
        meshRenderer.material.SetColor("_Color", c);
    }

    void Update()
    {
        // s� entra no bloco de c�digo abaixo quando a v�riavel � true
        if (!canMove) return;

        // O translate recoloca o player na posi��o mencionada dentro da variavel right que � um Vector3,
        // o deltaTime faz com que seja tudo atualizado por frame, sem o * Time.deltaTime, seria atualizado por cada
        // clique da a��o e n�o por cada quadro (IMPORTANTE, usar GetKey nesse caso inv�s de GetKeyDown, assim a
        // a��o � detectada por intera��o com a tecla e n�o necess�riamente o pressionar dela
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            transform.Translate(right * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.Translate(-right * Time.deltaTime);
        }

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
    private void SpawnObject()
    {

        // aqui enquanto estiver dando spawn nos gameObjects, ser� liberado o acesso
        // ao Projetile.cs
        var obj = poolManager.GetPooledObject();
        obj.SetActive(true);
        obj.GetComponent<Projectile>().StartProjectile();
        obj.GetComponent<Projectile>().OnHitTarget = CountDeaths;
        //obj.transform.SetParent(null);
        // "var obj" vai salvar a informa��o do "Instantiate", dentro do Instantiate
        // est� sendo sinalizado para ele conter as informa��o do objeto que ser�
        // spawnado (no caso "prefab"), e a localiza��o desse objeto ("transform")
        // var obj = Instantiate(Projectile);
        obj.transform.position = ShootPoint.transform.position;
    }

    // contador de abates
    private void CountDeaths()
    {
        deathNumber++;
        Debug.Log("Inimigos mortos " + deathNumber + "!");
    }
}
