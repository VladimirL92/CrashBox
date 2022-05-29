using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainView: MonoBehaviour
{
    [SerializeField]
    private Test _test;

    public void OnClickReset()
    {
        _test.ReloadLevel();
    }

    public void OnClickExplode()
    {
        _test.Explode();
    }
}
