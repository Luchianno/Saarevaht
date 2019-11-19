using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Utils
{
    public static void IsType<T>(object obj) where T : class
    {
        if (!(obj is T))
        {
            throw new ArgumentException("Not a Correct Type");
        }
    }

}
