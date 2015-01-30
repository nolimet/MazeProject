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
        [SerializeField]
        Color textcolour;
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
                        ItemRenderPartGeneric gri = new ItemRenderPartGeneric();
                        gri.MainObject = (GameObject)Instantiate(GenericItem.MainObject);
                        gri.init(GenericItem);
                        itemSetGeneric(i, gri);
                        break;
                    case Inventory.itemType.armor:
                        ItemRenderPartArmor ari = new ItemRenderPartArmor();
                        ari.MainObject = (GameObject)Instantiate(GenericArmor.MainObject);
                        ari.init(GenericArmor);
                        itemSetGeneric(i, ari);
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

        void itemSetGeneric( Inventory.item i, ItemRenderPartGeneric irg)
        {
            irg.itemName.text = i.name;
            irg.Discription.text = i.Discription;
            irg.Icon.sprite = i.icon;
            irg.Weight.text = "Weight: " + i.weight.ToString()+"KG";
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

            public void init( ItemRenderPartGeneric parentObject)
            {
                objectRectTransform = MainObject.GetComponent<RectTransform>();
                UnityEngine.UI.Text[] textList = MainObject.GetComponentsInChildren<UnityEngine.UI.Text>();
                foreach (UnityEngine.UI.Text t in textList)
                {
                    compairObjectText(t, parentObject);
                }

                Icon = MainObject.GetComponentInChildren<UnityEngine.UI.Image>();
            }

            private void compairObjectText(UnityEngine.UI.Text t, ItemRenderPartGeneric parentObject)
            {
                if (t.name == parentObject.itemName.name)
                    itemName = t;
                else if (t.name == parentObject.itemName.name)
                    Discription = t;
                else if (parentObject.Weight.name == parentObject.itemName.name)
                    Weight = t;
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
            private void compairObjectText(UnityEngine.UI.Text t, ItemRenderPartArmor parentObject)
            {
                //base.compairObjectText(t, (ItemRenderPartGeneric)parentObject);
                if (t.name == parentObject.itemName.name)
                    itemName = t;
                else if (t.name == parentObject.itemName.name)
                    Discription = t;
                else if (parentObject.Weight.name == parentObject.itemName.name)
                    Weight = t;
                else if (t.name == parentObject.ArmorLocation.name)
                    ArmorLocation = t;
                else if (t.name == parentObject.Type.name)
                    Type = t;
                else if (t.name == parentObject.ArmorRating.name)
                    ArmorRating = t;
            }

        }

        [System.Serializable]
        public class ItemRenderPartWeapon : ItemRenderPartGeneric
        {
            public UnityEngine.UI.Text Damage;
            public UnityEngine.UI.Text Enchants;

            private void compairObjectText(UnityEngine.UI.Text t, ItemRenderPartWeapon parentObject)
            {
                //base.compairObjectText(t, (ItemRenderPartGeneric)parentObject);
                if (t.name == parentObject.itemName.name)
                    itemName = t;
                else if (t.name == parentObject.itemName.name)
                    Discription = t;
                else if (parentObject.Weight.name == parentObject.itemName.name)
                    Weight = t;
                else if (t.name == parentObject.Damage.name)
                    Damage = t;
                else if (t.name == parentObject.Enchants.name)
                    Enchants = t;
            }
        }
        #endregion
    }
}
