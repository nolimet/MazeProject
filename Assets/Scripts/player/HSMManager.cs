using UnityEngine;
using System.Collections;
using gameData;

public class HSMManager : MonoBehaviour
{

    //Heatlh
    //Stamina
    //Mana

    const float staminaRegenrationRate = 4;
    const float manaRegenrationRate = 1;

    [SerializeField]
    Texture staminaTexture;
    [SerializeField]
    Texture healthTexture;
    [SerializeField]
    Texture manaTexture;

    void Update()
    {
        stamina();
        magic();
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, (HSM.Stamina / HSM.maxStamina * 120), 20), staminaTexture);
        GUI.TextArea(new Rect(0, 0, 120, 20), "stamina: " + Mathf.FloorToInt(HSM.Stamina) + "/" + HSM.maxStamina);
        GUI.DrawTexture(new Rect(0, 20, (HSM.Health / HSM.maxHealth * 120), 20), healthTexture);
        GUI.TextArea(new Rect(0, 20, 120, 20), "health: " + Mathf.FloorToInt(HSM.Health) + "/" + HSM.maxHealth);
        GUI.DrawTexture(new Rect(0, 40, (HSM.Mana / HSM.maxMana * 120), 20), manaTexture);
        GUI.TextArea(new Rect(0, 40, 120, 20), "mana: " + Mathf.FloorToInt(HSM.Mana) + "/" + HSM.maxMana);

    }

    void magic()
    {
        if (HSM.Mana < HSM.maxMana)
        {
            HSM.Mana += manaRegenrationRate * Time.deltaTime;
            if (HSM.Mana > HSM.maxMana)
                HSM.Mana = HSM.maxMana;
        }

            if (Input.GetKeyDown(KeyCode.C))
            {
                if (HSM.CastSpell(20))
                    print("casted a spell");
            }
    }

    void stamina()
    {
        if (!Input.GetButton(Axis.Sprint) && HSM.Stamina < HSM.maxStamina)
        {

            if (Input.GetAxis(Axis.Horizontal) == 0 && Input.GetAxis(Axis.Vertical) == 0)
            {
                HSM.Stamina += staminaRegenrationRate * Time.deltaTime;
            }
            else
            {
                HSM.Stamina += (staminaRegenrationRate / 2f) * Time.deltaTime;
            }
            if (HSM.Stamina > HSM.maxStamina)
                HSM.Stamina = HSM.maxStamina;
        }
        else if (Input.GetButton(Axis.Sprint))
            if (HSM.Stamina > 1 && Input.GetButton(Axis.Sprint))
            {
                if (Input.GetAxis(Axis.Horizontal) != 0 || Input.GetAxis(Axis.Vertical) != 0)
                    HSM.Stamina -= 5f * Time.deltaTime;
            }
    }
}
