using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LobbyView : MonoBehaviour
{
    [SerializeField]
    private GameConfig _gameConfig;

    [SerializeField]
    private ItemsControl _levelList;

    private void Awake()
    {
        var levelCards = _gameConfig.Levels.Select(x => new LevelCard { Name = x.Name });
        _levelList.Rebuild(levelCards);
    }
}