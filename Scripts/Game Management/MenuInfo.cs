using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MenuInfo", menuName = "ScriptableObjects/MenuInfo", order = 0)]
public class MenuInfo : ScriptableObject
{
    public int maxLevel;
    public bool[] completed = {};
}
