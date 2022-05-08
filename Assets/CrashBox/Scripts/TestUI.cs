using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour
{
    [SerializeField]
    private Test _test;

    public void OnClickReset()
    {
        _test.Reload();
    }

    public void OnClickExplode()
    {
        _test.Explode();
    }
}
