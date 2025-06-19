using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        IDLE,
        RUNNING,
        DEAD
    }

    public Dictionary<States, StateBase> dictionaryState;

    // variavel para guardar o estado atual da state machine
    private StateBase _currentState;
    public Player player;
    public float TimeToStartGame = 1f;

    private void Awake()
    {

        // Informa qual classe do Script C# informado em "newDictionary"(no caso "StateBase") é
        // o State, por exemplo, "States.Idle, new StateBase()" está dizendo
        // o estado "idle" pertence ao aquivo de Script C# "StateBase" e na classe "StateBase", já o
        // "States.RUNNING, new StateRunning" informa que dentro de "<StateBase>" e na classe
        // "StateRunning" está o que será lido para ele
        dictionaryState = new Dictionary<States, StateBase>();

        dictionaryState.Add(States.IDLE, new StateBase());
        dictionaryState.Add(States.RUNNING, new StateRunning());
        dictionaryState.Add(States.DEAD, new StateBase());

        // Sinaliza o estado que vai ser passado após resolver tudo nos "dictionaryState" acima
        SwitchState(States.IDLE);

        Invoke(nameof(StartGame), TimeToStartGame);
    }

    private void StartGame()
    {
        SwitchState(States.RUNNING);
    }

    private void SwitchState(States state)
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = dictionaryState[state];

        _currentState.OnStateEnter(player);
    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();
    }

}
