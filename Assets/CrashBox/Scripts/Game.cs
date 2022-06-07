using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private GameObject _levelTemplate;
    private GameObject _level;

    public void LoadLevel(GameObject levelTemplate)
    {
        _levelTemplate = levelTemplate;

        ReloadLevel();
    }

    public void ReloadLevel()
    {
        if (_level)
        {
            Destroy(_level);
        }

        if (_levelTemplate)
        {
            _level = Instantiate(_levelTemplate);
        }
    }

    public void Explode()
    {
        var bombs = FindObjectsOfType<Bomb>();
        
        foreach(var bomb in bombs)
        {
            bomb.Explode();
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Lobby");
    }
}
