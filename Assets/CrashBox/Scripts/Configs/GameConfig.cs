using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Crash Box/Game Config")]
public class GameConfig : ScriptableObject
{
    [System.Serializable]
    public class LevelConfigData
    {
        public string Name;
        public GameObject LevelTemplate;
    }

    public LevelConfigData[] Levels;
}
