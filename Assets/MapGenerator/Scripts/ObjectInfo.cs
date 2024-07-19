using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Info", menuName = "Map Generator/GameInfo", order = 1)]
public class ObjectInfo : ScriptableObject
{
    public Color color;
    public GameObject prefab;
}
