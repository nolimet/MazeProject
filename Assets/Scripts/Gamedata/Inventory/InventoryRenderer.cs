using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace gameData.InventorySystem
{
    public class InventoryRenderer : MonoBehaviour
    {
        Inventory invA;
        Inventory invB;
        bool Bused;

        [SerializeField]
        RectTransform PlayerInvListParent;
        [SerializeField]
        RectTransform OtherInvListParent;
        [SerializeField]
        ItemRenderPartGeneric GenericItem;
        [SerializeField]
        ItemRenderPartArmor GenericArmor;
        [SerializeField]
        ItemRenderPartWeapon GenericWeapon;
        [SerializeField]
        ItemRenderPartKey GenericKey;

        

        void Start()
        {
            managers.EventManager.openInventory += EventManager__openInventory;
        }

        void EventManager__openInventory(Inventory Player, Inventory Other = null)
        {
            invA = Player;
            invB = Other;
            if (Other = null)
                Bused = false;
        }

        void renderItems(Inventory toRender, RectTransform parent)
        {
            foreach (Inventory.item i in toRender.contents)
            {
                switch (i.type)
                {
                    case Inventory.itemType.misc:

                        break;
                    case Inventory.itemType.armor:
                        break;
                    case Inventory.itemType.weapon:
                        break;
                    case Inventory.itemType.key:
                        break;
                    default:
                        Debug.LogWarning("UnknowItem Type named: " + i.type + " Item name is " + i.name);
                        break;

                }
            }
        }
        #region ObjectParentClasses;
        public class ItemRenderPartGeneric
        {
            GameObject MainObject;
            RectTransform objectRectTransform;
            UnityEngine.UI.Text itemName;
            UnityEngine.UI.Text Discription;
            UnityEngine.UI.Text Weight;
            UnityEngine.UI.Image Icon;

            public ItemRenderPartGeneric()
            {
                
            }
        }

        public class ItemRenderPartKey : ItemRenderPartGeneric
        {
            UnityEngine.UI.Text WillOpen;
        }

        public class ItemRenderPartArmor : ItemRenderPartGeneric
        {
            UnityEngine.UI.Text Stats;
            UnityEngine.UI.Text Type;
        }

        public class ItemRenderPartWeapon : ItemRenderPartGeneric
        {
            UnityEngine.UI.Text Damage;
            UnityEngine.UI.Text Enchants;
        }
        #endregion
    }
}
