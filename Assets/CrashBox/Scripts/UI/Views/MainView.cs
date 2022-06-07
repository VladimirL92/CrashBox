using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainView: MonoBehaviour
{
    private Game _game;

    private void Awake()
    {
        _game = FindObjectOfType<Game>();
    }

    public void OnClickReset()
    {
        _game.ReloadLevel();
    }

    public void OnClickExplode()
    {
        _game.Explode();
    }

    public void OnClickBack()
    {
        _game.Back();
    }
}
