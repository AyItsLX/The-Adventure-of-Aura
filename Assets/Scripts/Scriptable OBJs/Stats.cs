using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats", fileName = "New Stats")]
public class Stats : ScriptableObject
{
    public float BaseDamage;
    public int BaseHealth;
    public float BaseAttackSpeed;
    public float MovementSpeed;
    public int LifeStealPercentage;
    public float Range;
    public float CoolDown;
}
