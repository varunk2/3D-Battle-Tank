using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "Scrpitable Objects/New Tank")]
public class TankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public Color tankColor;
    public float speed;
    public float turnSpeed;
    public float health;
    public float damage;
    public float mass;
}


[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "Scrpitable Objects/TanksList")]
public class TankScriptableObjectList : ScriptableObject {
    public TankScriptableObject[] tanks;
}