using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartup : MonoBehaviour
{
    [SerializeField]
    private GameObject debugLevelTemplate;

    private void Start()
    {
        var game = FindObjectOfType<Game>();

        var startupInfo = FindObjectOfType<StartupInfo>();
        if (startupInfo)
        {
            game.LoadLevel(startupInfo.LevelTemplate);
            Destroy(startupInfo.gameObject);
        }
        else if (debugLevelTemplate)
        {
            game.LoadLevel(debugLevelTemplate);
        }
    }
}
