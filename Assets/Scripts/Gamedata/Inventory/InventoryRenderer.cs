﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace gameData.InventorySystem
{
    public class InventoryRenderer : MonoBehaviour
    {
        const int padding = 10;

		[SerializeField]
        Inventory invA =null ,invB = null; // testing Invs
        //bool Bused;
        [SerializeField]
        RectTransform PlayerInvListParent, OtherInvListParent;

        [SerializeField]
        ScrollRect PlayerInvScrollRect, OtherInvScrollRect;

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
            GenericArmor.MainObject.SetActive(false);
            GenericItem.MainObject.SetActive(false);
            GenericKey.MainObject.SetActive(false);
            GenericWeapon.MainObject.SetActive(false);

            Inventory.equip e = new Inventory.equip("testingItem");
            invA.contents.Add(e);
        }

        void EventManager__openInventory(Inventory Player, Inventory Other = null)
        {
			renderItems(Player,PlayerInvListParent);
            if (Other == null)
				renderItems(Other,OtherInvListParent);
            managers.EventManager.OnInventoryDoneLoading();
        }

		public void openFake(bool both = false)
		{
			renderItems(invA,PlayerInvListParent);
			if (both)
				renderItems(invB,OtherInvListParent);

            managers.EventManager.OnInventoryDoneLoading();
		}

        #region invHandler
        void renderItems(Inventory toRender, RectTransform parent)
        {
            int l = parent.childCount;
            for (int i = 0; i < l; i++)
            {
                if (parent.GetChild(i) != parent.gameObject)
                    Destroy(parent.GetChild(i).gameObject, 0.1f);
            }
            parent.sizeDelta = new Vector2(parent.sizeDelta.x, 800);
            float heightIndex = parent.sizeDelta.y / 2f;
            foreach (Inventory.item i in toRender.contents)
            {
                switch (i.type)
                {
                    case Inventory.itemType.misc:
                        ItemRenderPartGeneric gri = new ItemRenderPartGeneric();
                        gri.MainObject = (GameObject)Instantiate(GenericItem.MainObject);
                        gri.init(GenericItem);
                        itemSetGeneric(i, gri, parent);
                        heightIndex = gri.setPos(heightIndex);
                        break;
                    case Inventory.itemType.armor:
                        ItemRenderPartArmor ari = new ItemRenderPartArmor();
                        ari.MainObject = (GameObject)Instantiate(GenericArmor.MainObject);
                        ari.init(GenericArmor);
                        itemSetGeneric(i, ari, parent);
                        itemSetArmor((Inventory.equip)i, ari);
                        heightIndex = ari.setPos(heightIndex);
                        break;
                    case Inventory.itemType.weapon:
                        ItemRenderPartWeapon wri = new ItemRenderPartWeapon();
                        wri.MainObject = (GameObject)Instantiate(GenericWeapon.MainObject);
                        wri.init(GenericWeapon);
                        itemSetGeneric(i, wri, parent);
                        itemSetWeapon((Inventory.weapon)i, wri);
                        heightIndex = wri.setPos(heightIndex);
                        break;
                    case Inventory.itemType.key:
                        ItemRenderPartKey kri = new ItemRenderPartKey();
                        kri.MainObject = (GameObject)Instantiate(GenericKey.MainObject);
                        kri.init(GenericKey);
                        itemSetGeneric(i, kri, parent);
                        heightIndex = kri.setPos(heightIndex);
                        break;
                    default:
                        Debug.LogWarning("UnknownItem Type named: " + i.type + " Item name is " + i.name);
                        break;
                }
            }

            parent.sizeDelta = new Vector2(parent.sizeDelta.x, (155 * parent.childCount));

            parent.parent.parent.gameObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
            parent.parent.parent.gameObject.GetComponent<ScrollRect>().verticalScrollbar.value = 1f;
            //parent.GetComponent<VerticalLayoutGroup>().SetLayoutVertical();
        }

        void itemSetGeneric( Inventory.item i, ItemRenderPartGeneric irg, RectTransform parent)
        {
			//Debug.Log (i.name + ", " + i.Discription + ", " + i.type.ToString());
            irg.MainObject.SetActive(true);
            irg.itemName.text = i.name;
			irg.Discription.text = i.Discription;
            irg.Icon.sprite = i.icon;
            irg.Weight.text = "Weight: " + i.weight.ToString()+"KG";
			irg.MainObject.name = i.name;
			irg.objectRectTransform.SetParent(parent);

        }

        void itemSetArmor(Inventory.equip i, ItemRenderPartArmor ari)
        {
            ari.ArmorLocation.text = "Armor Location: " + i.part.ToString();
            ari.ArmorRating.text = "Armor: " + i.armor.ToString();
            ari.Type.text = "Armor Type: " + i.type.ToString();
        }

        void itemSetWeapon(Inventory.weapon i, ItemRenderPartWeapon wri)
        {
            wri.Damage.text = "Damage: " + i.dmg.ToString();
            wri.Enchants.text = "Enchants: " + i.enchant.ToString();
        }

        void itemSetKey(Inventory.key i, ItemRenderPartKey kri)
        {
            
        }
        #endregion
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

            public virtual void init( ItemRenderPartGeneric parentObject)
            {
                objectRectTransform = MainObject.GetComponent<RectTransform>();
                UnityEngine.UI.Text[] textList = MainObject.GetComponentsInChildren<UnityEngine.UI.Text>();
                foreach (UnityEngine.UI.Text t in textList)
                {
                    compairObjectText(t, parentObject);
                }
                UnityEngine.UI.Image[] imageList = MainObject.GetComponentsInChildren<UnityEngine.UI.Image>();
                foreach (UnityEngine.UI.Image t in imageList)
                {
                    if (t.name == parentObject.Icon.name)
                        Icon = t;
                }

            }

			public float setPos(float heightIndex){
				//objectRectTransform.localPosition = new Vector3(0,heightIndex,0);
                objectRectTransform.localScale = new Vector3(1, 1, 1);
                CustomDebug.Log(heightIndex + ", " + objectRectTransform.sizeDelta.ToString(), CustomDebug.Level.Trace);
				heightIndex -= objectRectTransform.sizeDelta.y + padding;
                
				return heightIndex;
			}

            protected virtual void compairObjectText(UnityEngine.UI.Text t, ItemRenderPartGeneric parentObject)
            {
                switch (t.name)
                {
                    case "Name":
                        itemName = t;
                        break;
                    case "Discription":
                        Discription = t;
                        break;
                    case "Weight":
                        Weight = t;
                        CustomDebug.Log(t.name + " Object Type: Weight", CustomDebug.Level.Debug, CustomDebug.Profile.Jesse);
                        break;
                }
            }
        }

        [System.Serializable]
        public class ItemRenderPartKey : ItemRenderPartGeneric
        {
            //public UnityEngine.UI.Text WillOpen;
            //needs exstra function for what it will open
            protected override void compairObjectText(UnityEngine.UI.Text t, ItemRenderPartGeneric parentObject)
            {
                base.compairObjectText(t, parentObject);
            }
        }

        [System.Serializable]
        public class ItemRenderPartArmor : ItemRenderPartGeneric
        {
            public UnityEngine.UI.Text ArmorRating;
            public UnityEngine.UI.Text Type;
            public UnityEngine.UI.Text ArmorLocation;
            //stats will be put in the discription

            protected override void compairObjectText(Text t, ItemRenderPartGeneric parentObject)
            {
                base.compairObjectText(t, (ItemRenderPartGeneric)parentObject);

                switch (t.name)
                {
                    case "ArmorLocation":
                        ArmorLocation = t;
                        CustomDebug.Log(t.name + " Object Type: ArmorLocation", CustomDebug.Level.Debug, CustomDebug.Profile.Jesse);
                        break;
                    case "ArmorType":
                        Type = t;
                        CustomDebug.Log(t.name + " Object Type: ArmorType", CustomDebug.Level.Debug, CustomDebug.Profile.Jesse);
                        break;
                    case "ArmorRate":
                        ArmorRating = t;
                        break;
                }
            }
        }

        [System.Serializable]
        public class ItemRenderPartWeapon : ItemRenderPartGeneric
        {
            public UnityEngine.UI.Text Damage;
            public UnityEngine.UI.Text Enchants;

            protected override void compairObjectText(Text t, ItemRenderPartGeneric parentObject)
            {
                base.compairObjectText(t, (ItemRenderPartGeneric)parentObject);
                switch (t.name)
                {
                    case "Damage":
                        Damage = t;
                        break;
                    case "Enchants":
                        Enchants = t;
                        break;
                }
            }
        }
        #endregion
    }
}
