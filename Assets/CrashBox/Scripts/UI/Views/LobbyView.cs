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
        var levelCards = _gameConfig.Levels.Select(levelCard => new LevelCard 
        { 
            Name = levelCard.Name, 
            Preview = levelCard.Preview,
            Template = levelCard.Template
        });

        _levelList.Rebuild(levelCards);
    }
}