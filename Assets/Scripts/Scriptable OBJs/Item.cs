using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New ")]
public class Item : ScriptableObject
{
    public Sprite Artwork;

    public int ItemCost;

    public int AddedDamage;

    public int AddedHealth;

    public int AddedAttackSpeed;

    public float AddedMovementSpeed;

    public int AddedLifeStealPercentage;

    public float AddedCoolDown;

    public string Description;
}
