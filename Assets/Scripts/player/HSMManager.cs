using UnityEngine;
using System.Collections;

public class HSMManager : MonoBehaviour {

    //Heatlh
    //Stamina
    //Mana

	const float staminaRegenrationRate = 4;

    [SerializeField]
    Texture staminaTexture;
    [SerializeField]
    Texture healthTexture;
    [SerializeField]
    Texture manaTexture;

    void Update()
    {
        
            if (!Input.GetButton(Axis.Sprint) && gameData.HSM.Stamina < gameData.HSM.maxStamina)
            {

                if (Input.GetAxis(Axis.Horizontal) == 0 && Input.GetAxis(Axis.Vertical) == 0)
                {
                    gameData.HSM.Stamina += staminaRegenrationRate * Time.deltaTime;
                }
                else
                {
                    gameData.HSM.Stamina += (staminaRegenrationRate / 2f) * Time.deltaTime;
                }
                if (gameData.HSM.Stamina > gameData.HSM.maxStamina)
                    gameData.HSM.Stamina = gameData.HSM.maxStamina;
            }
        else if(Input.GetButton(Axis.Sprint))
            if (gameData.HSM.Stamina > 1 && Input.GetButton(Axis.Sprint))
            {
                if (Input.GetAxis(Axis.Horizontal) != 0 || Input.GetAxis(Axis.Vertical) != 0)
                    gameData.HSM.Stamina -= 5f * Time.deltaTime;
            }
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, (gameData.HSM.Stamina / gameData.HSM.maxStamina * 120), 20), staminaTexture);
        GUI.TextArea(new Rect(0,0,120,20),"stamina: " + Mathf.FloorToInt(gameData.HSM.Stamina) + "/" + gameData.HSM.maxStamina);
        GUI.DrawTexture(new Rect(0, 20, (gameData.HSM.Health / gameData.HSM.maxHealth * 120), 20), healthTexture);
        GUI.TextArea(new Rect(0, 20, 120, 20), "health: " + Mathf.FloorToInt(gameData.HSM.Health) + "/" + gameData.HSM.maxHealth);
        GUI.DrawTexture(new Rect(0, 40, (gameData.HSM.Mana / gameData.HSM.maxMana * 120), 20), manaTexture);
        GUI.TextArea(new Rect(0, 40, 120, 20), "mana: " + Mathf.FloorToInt(gameData.HSM.Mana) + "/" + gameData.HSM.maxMana);
        
    }
}
