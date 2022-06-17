using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButtonAction : MonoBehaviour
{
    private Animator SettBar;
    private void Start()
    {
        SettBar = GetComponent<Animator>();
    }
    public void AnimatorToggle()
    {
        var visible = SettBar.GetBool("BarVisible");
        SettBar.SetBool("BarVisible", !visible);
    }
}
