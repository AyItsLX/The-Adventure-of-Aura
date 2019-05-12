using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdleRegeneration : MonoBehaviour {

    public PlayerController playerController;
    public Slider staminaBar, manaBar;
    public Text ManaBar, StaminaBar;
    public float StaRegen = 2, ManaRegen = 1;
    public Text MRUI, STAUI;
    public float RegenTimer = 2f;

    void Update () {
        if (playerController == null)
        {
            playerController = GetComponent<PlayerController>();
        }
        UpdateTexts();

        RegenTimer -= Time.deltaTime;
        if (RegenTimer < 0)
        {
            if (playerController.Stamina < 100)
            {
                playerController.Stamina += StaRegen;
            }
            if (playerController.Mana < 100)
            {
                playerController.Mana += ManaRegen;
            }
            RegenTimer = 0.25f;
        }
    }

    #region UpdateTextFunction
    void UpdateTexts()
    {
        MRUI.text = "Mana Regen : " + ManaRegen;
        STAUI.text = "Stamina Regen : " + StaRegen;

        ManaBar.text = "Mana : " + playerController.Mana;
        StaminaBar.text = "Stamina : " + playerController.Stamina;

        staminaBar.value = Mathf.Lerp(staminaBar.value, playerController.Stamina, Time.deltaTime * 5f);
        manaBar.value = Mathf.Lerp(manaBar.value, playerController.Mana, Time.deltaTime * 5f);
    }
    #endregion
}
