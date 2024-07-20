using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CheckpointSystem", menuName = "ScriptableObjects/CheckpointSystem", order = 0)]
public class CheckpointSystem : ScriptableObject
{
    public int level = 0;
    public Vector3 spawnPoint;
}
