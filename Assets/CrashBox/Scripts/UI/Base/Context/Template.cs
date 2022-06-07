using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Template : MonoBehaviour
{
    public abstract Type DataContextType { get; }
    public abstract void SetDataContext(object dataContext);
}