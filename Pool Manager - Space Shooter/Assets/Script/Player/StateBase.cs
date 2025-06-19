using JetBrains.Annotations;
using UnityEngine;

public class StateBase
{
    public virtual void OnStateEnter(object o = null)
    {
        Debug.Log("OnStateEnter");
    }
    public virtual void OnStateStay()
    {
        Debug.Log("OnStateStay");
    }
    public virtual void OnStateExit()
    {
        Debug.Log("OnStateExit");
    }

}

public class StateRunning : StateBase
{
    public Player player;
    public override void OnStateEnter(object o = null)
    {
        // informa que o objeto "o" � um player, � como uma variavel do tipo "Player" que est� sendo
        // nomeada com "player" e o valor dela � o "o" que � o objeto nosso, mas est� como "=Player()o;"
        // pois n�o tem como dar o valor de um objeto para a variavel diretamente, ent�o "Player player = o;"
        // causaria erro, por isso o (Player)o; se faz necess�rio, pq sinaliza que o "o" � um tipo player
        player = (Player)o;
        player.canMove = true;
        player.ChangeColor(Color.blue);

        base.OnStateEnter(o);
    }

    public override void OnStateExit()
    {
        player.canMove = false;
        player.ChangeColor(Color.magenta);
        base.OnStateExit();
    }
}
