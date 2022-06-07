using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View<T> : Template
{
    public T DataContext { get; set; }
    public override Type DataContextType => typeof(T);

    public override void SetDataContext(object dataContext)
    {
        DataContext = (T)dataContext;
    }
}