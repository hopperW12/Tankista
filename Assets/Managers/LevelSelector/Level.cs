using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level",menuName = "Levels/Level")]
public class Level : ScriptableObject
{

    public new string name;
    public GameObject levelPrefab;

}
