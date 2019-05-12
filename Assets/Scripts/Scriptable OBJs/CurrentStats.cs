using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentStats : MonoBehaviour {

    public Stats DesiredStats;
    public float Damage;
    public float Health;
    public float MaxHealth;
    public float AttackSpeed;
    public float MovementSpeed;
    public Slider HealthBar;
    public float HealthBarValue;
    public int LifeStealPercentage;
    public float Range;
    public float CoolDown;

	void Start ()
    {
        Damage = DesiredStats.BaseDamage;
        MaxHealth = DesiredStats.BaseHealth;
        Health = MaxHealth;
        AttackSpeed = DesiredStats.BaseAttackSpeed;
        MovementSpeed = DesiredStats.MovementSpeed;
        LifeStealPercentage = DesiredStats.LifeStealPercentage;
        Range = DesiredStats.Range;
        CoolDown = DesiredStats.CoolDown;
	}

	void Update ()
    {
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        UpdateHealthBar();
        CheckForDeath();
    }

    void CheckForDeath()
    {
        if (Health <= 0)
        {
            Health = 0;
            //Destroy(gameObject);
        }
    }

    void UpdateHealthBar()
    {
        HealthBarValue = Health; // / MaxHealth
        if (HealthBar == null)
        {
            return;
        }
        //HealthBar.value = HealthBarValue;

        HealthBar.value = Mathf.Lerp(HealthBar.value, HealthBarValue, Time.deltaTime * 5f);
    }
}
