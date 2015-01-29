using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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

        List<ItemRenderPartGeneric> playerInv;
        List<ItemRenderPartGeneric> otherInv;
        

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
        [System.Serializable]
        public class ItemRenderPartGeneric
        {
            public GameObject MainObject;
            public RectTransform objectRectTransform;
            public UnityEngine.UI.Text itemName;
            public UnityEngine.UI.Text Discription;
            public UnityEngine.UI.Text Weight;
            public UnityEngine.UI.Image Icon;

            public ItemRenderPartGeneric()
            {
                
            }
        }

        [System.Serializable]
        public class ItemRenderPartKey : ItemRenderPartGeneric
        {
            //public UnityEngine.UI.Text WillOpen;
            //needs exstra function for what it will open
        }

        [System.Serializable]
        public class ItemRenderPartArmor : ItemRenderPartGeneric
        {
            public UnityEngine.UI.Text ArmorRating;
            public UnityEngine.UI.Text Type;
            public UnityEngine.UI.Text ArmorLocation;
            //stats will be put in the discription

        }

        [System.Serializable]
        public class ItemRenderPartWeapon : ItemRenderPartGeneric
        {
            public UnityEngine.UI.Text Damage;
            public UnityEngine.UI.Text Enchants;
        }
        #endregion
    }
}
