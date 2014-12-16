using UnityEngine;
using System.Collections;
using util;
namespace player
{
    public class GuiUpdater : MonoBehaviour
    {
        [SerializeField]
        CanvasImg manaBar = null, healthBar = null, staminaBar = null;
        // Use this for initialization
        void Start()
        {
            manaBar.SetOrignals();
            healthBar.SetOrignals();
            staminaBar.SetOrignals();

        }

        // Update is called once per frame
        void Update()
        {
            manaBar.ResizeScale(gameData.HSM.Mana / gameData.HSM.maxMana);
            healthBar.ResizeScale(gameData.HSM.Health / gameData.HSM.maxHealth);
            staminaBar.ResizeScale(gameData.HSM.Stamina / gameData.HSM.maxStamina);
        }
    }
}