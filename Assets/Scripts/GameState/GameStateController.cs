using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Scene = UnityEditor.SearchService.Scene;

public class GameStateController : MonoBehaviour
{
    private GameState _currentState;
    
    //why have exit gameplay AND enter gameOver if our machine is so simple? You don't need it, but its to prove a point.
    //The next step is a gameWin and a gameLose state. Theres a lot you would do regardless of win or lose, like disable playerControllers or turn off HUD.
    //you would do that stuff on exitGameplay.
    
    

    // public UnityEvent EnterStartState;//not needed because we are going to just reload our scene.
    public UnityEvent ExitStartState;
    //gameplay states
    public UnityEvent EnterGameplayState;
    public UnityEvent ExitGameplayState;
    //gameOverStates
    public UnityEvent EnterGameOverState;
    public UnityEvent ExitGameOverState;
    //restart state events
    public UnityEvent EnterRestartState;
    //exitRestart not needed bcause of ... its restarting
    
    //i feel i need to note there are many more elegant ways to do this...
    void Start()
    {
        _currentState = GameState.start;
    }

    public bool IsState(GameState state)
    {
        return state == _currentState;
    }
    public void ChangeState(GameState newState)
    {
        CallExitEvent(_currentState);
        _currentState = newState;
        CallEnterEvent(_currentState);
        Debug.Log("Changed to "+_currentState+" state.");
    }

    //Shorthand to make this UnityEvent easier to call
    public void GameOver()
    {
        ChangeState(GameState.gameOver);
    }
    
    private void CallEnterEvent(GameState state)
    {
        switch (state)
        {
            case GameState.playing:
                EnterGameplayState.Invoke();
                break;
            case GameState.gameOver:
                EnterGameOverState.Invoke();
                break;
            case GameState.restart:
                EnterRestartState.Invoke();
                break;
        }
    }

    private void CallExitEvent(GameState state)
    {
        switch (state)
        {
            case GameState.playing:
                ExitGameplayState.Invoke();
                break;
            case GameState.start:
                ExitStartState.Invoke();
                break;
            case GameState.gameOver:
                ExitGameOverState.Invoke();
                break;
        }
    }
}
