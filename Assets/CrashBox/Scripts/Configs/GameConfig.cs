using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Crash Box/Game Config")]
public class GameConfig : ScriptableObject
{
    public LevelConfig[] Levels;
}
