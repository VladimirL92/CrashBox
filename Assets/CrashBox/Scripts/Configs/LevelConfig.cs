using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Crash Box/Level Config")]
public class LevelConfig : ScriptableObject
{
    public string Name;
    public Sprite Preview;
    public GameObject Template;

    [Header("Arsenal")]
    public int BombA; 
    public int BombB; 
    public int BombC;
}
