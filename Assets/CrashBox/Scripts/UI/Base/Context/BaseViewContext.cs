using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseViewContext : MonoBehaviour
{
    public abstract Type DataContextType { get; }
    public abstract void SetDataContext(object dataContext);
}