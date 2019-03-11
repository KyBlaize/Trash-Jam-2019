using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFruit : ScriptableObject
{
    public string Name = "New Fruit";
    public float BaseRipeRotRate = 1f;
    public float MaxRipenessValue = 1f;
    public float Value = 0;
    public bool IsRipe = false;

    public abstract void Ripen();
    public abstract void Rot();
}
