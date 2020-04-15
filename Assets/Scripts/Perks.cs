using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Perk", menuName = "Perk")]
public class Perks : ScriptableObject
{
    public int index;
    public new string name;
    public string description;

    public Sprite icon;

}
