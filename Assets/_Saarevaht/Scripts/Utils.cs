using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Utils
{
    public static void IsType<T>(object obj) where T : class
    {
        if (!(obj is T))
        {
            throw new ArgumentException("Not a Correct Type");
        }
    }
    public static bool Contains(this string source, string toCheck, StringComparison comp)
    {
        return source?.IndexOf(toCheck, comp) >= 0;
    }
}
