using UnityEngine;
using System.Collections;

public class HSMManager : MonoBehaviour {

    //Heatlh
    //Stamina
    //Mana

	const float staminaRegenrationRate = 4;

    [SerializeField]
    Texture staminaTexture;

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
        GUI.DrawTexture(new Rect(0, 0, (gameData.HSM.Stamina / gameData.HSM.maxStamina * 100), 40), staminaTexture);
        GUI.TextArea(new Rect(0,0,120,40),"stamina: " + gameData.HSM.Stamina + "/" + gameData.HSM.maxStamina);
        
    }
}
