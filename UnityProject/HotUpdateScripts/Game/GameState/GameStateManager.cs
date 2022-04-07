using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MetaFramework.Singleton;
using MetaFramework.Fsm;


public enum GameStateType
{
    Init,
    Home,
    Play,
}

public class GameStateManager : SingletonTemplate<GameStateManager>
{
    private FsmLite<GameStateType> fsm;

    public void Init()
    {
        fsm = new FsmLite<GameStateType>(GameStateType.Init);
        fsm.RegistState(GameStateType.Init, GameStateInit.Enter, GameStateInit.Exit);
        fsm.RegistState(GameStateType.Home, GameStateHome.Enter, GameStateHome.Exit);
        fsm.RegistState(GameStateType.Play, GameStatePlay.Enter, GameStatePlay.Exit);

        fsm.Start();
    }

    public void SetState(GameStateType state)
    {
        fsm.SetState(state);
    }
}
