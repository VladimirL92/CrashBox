using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private GameObject LevelTemplate;

    private GameObject _level;

    private void Start()
    {
        Reload();
    }

    public void Reload()
    {
        if (_level)
        {
            Destroy(_level);
        }

        _level = Instantiate(LevelTemplate);
    }

    public void Explode()
    {
        var bombs = FindObjectsOfType<Bomb>();
        
        foreach(var bomb in bombs)
        {
            bomb.Explode();
        }
    }
}
