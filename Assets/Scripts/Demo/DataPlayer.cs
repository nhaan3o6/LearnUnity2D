using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DataPlayer
{
    public string Name;
    public int Level;
    public int Gold;
}
[Serializable]
public class ListPlayer
{
    public DataPlayer[] playerData;
}
