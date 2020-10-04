using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //find & search

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<State> _gameStates = new List<State>();
    private IState _currentState;

    private void Start()
    {
        SetState(StateType.PreGameState);
    }


    #region STATE MACHINE

    public void SetState(StateType stateType)
    {
        IState nextState = _gameStates.FirstOrDefault(x => x.stateType == stateType).stateScript as IState;
        if (_currentState == nextState) return;
        if(_currentState != null)
        {
            _currentState.Exit();
        }
        
        _currentState = nextState;
        nextState.Enter();
    } 

    #endregion
}

[System.Serializable]
public class State
{
    public StateType stateType;

    public MonoBehaviour stateScript;
}

public enum StateType
{
    PreGameState,
    GameState,
    PauseGameState
}