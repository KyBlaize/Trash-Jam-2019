using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Fruit")]
public class Fruit : BaseFruit
{
    public float RotModifier = 0f;

    public override void Ripen()
    {
        Value += BaseRipeRotRate * Time.deltaTime;
    }

    public override void Rot()
    {
        Value -= (BaseRipeRotRate * RotModifier) * Time.deltaTime;
    }
}
