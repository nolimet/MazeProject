using UnityEngine;
using System.Collections;
namespace player
{
    public class GuiUpdator : MonoBehaviour
    {
        [SerializeField]
        CanvasImg manaBar, healthBar, staminaBar;
        // Use this for initialization
        void Start()
        {
            manaBar.orignalPos = new Vector3(manaBar.RectTransform.rect.x,manaBar.RectTransform.rect.y);
            manaBar.orignalSize = new Vector2(manaBar.RectTransform.rect.width, manaBar.RectTransform.rect.height);

            healthBar.orignalPos = new Vector3(healthBar.RectTransform.rect.x, healthBar.RectTransform.rect.y);
            healthBar.orignalSize = new Vector2(healthBar.RectTransform.rect.width, healthBar.RectTransform.rect.height);

            staminaBar.orignalPos = new Vector3(staminaBar.RectTransform.rect.x, staminaBar.RectTransform.rect.y);
            staminaBar.orignalSize = new Vector2(staminaBar.RectTransform.rect.width, staminaBar.RectTransform.rect.height);

        }

        // Update is called once per frame
        void Update()
        {
            manaBar.RectTransform.sizeDelta = new Vector2(manaBar.orignalSize.x * (gameData.HSM.Mana / gameData.HSM.maxMana),manaBar.orignalSize.y);
            healthBar.RectTransform.sizeDelta = new Vector2(healthBar.orignalSize.x * (gameData.HSM.Health / gameData.HSM.maxHealth), healthBar.orignalSize.y);
            staminaBar.RectTransform.sizeDelta = new Vector2(staminaBar.orignalSize.x * (gameData.HSM.Stamina / gameData.HSM.maxStamina), staminaBar.orignalSize.y);
        }
    }

    [System.Serializable]
    public class CanvasImg{
        public RectTransform RectTransform;
        public Vector2 orignalSize;
        public Vector3 orignalPos;

    }
}