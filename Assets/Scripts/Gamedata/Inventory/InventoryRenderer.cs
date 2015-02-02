using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace gameData.InventorySystem
{
    public class InventoryRenderer : MonoBehaviour
    {
		[SerializeField]
        Inventory invA,invB; // testing Invs
        //bool Bused;

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
			renderItems(Player,PlayerInvListParent);
            if (Other == null)
				renderItems(Other,OtherInvListParent);
        }

		public void openFake(bool both = false)
		{
			renderItems(invA,PlayerInvListParent);
			if (both)
				renderItems(invB,OtherInvListParent);
		}

        void renderItems(Inventory toRender, RectTransform parent)
        {
			Transform[] transforms = parent.GetComponentsInChildren<Transform>();
			foreach(Transform t in transforms)
			{
				if(t!=parent.transform)
					DestroyImmediate(t.gameObject);
			}

			float heightIndex = 0;
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
						heightIndex = ari.setPos(heightIndex);
                        break;
                    case Inventory.itemType.weapon:
						ItemRenderPartWeapon wri = new ItemRenderPartWeapon();
						wri.MainObject = (GameObject)Instantiate(GenericArmor.MainObject);
						wri.init(GenericWeapon);
						itemSetGeneric(i, wri, parent);
						heightIndex = wri.setPos(heightIndex);
                        break;
                    case Inventory.itemType.key:
                        break;
                    default:
                        Debug.LogWarning("UnknownItem Type named: " + i.type + " Item name is " + i.name);
                        break;
                }
            }
        }

        void itemSetGeneric( Inventory.item i, ItemRenderPartGeneric irg, RectTransform parent)
        {
			Debug.Log (i.name + ", " + i.Discription + ", " + i.type.ToString());
            irg.itemName.text = i.name;
			irg.Discription.text = i.Discription;
            irg.Icon.sprite = i.icon;
            irg.Weight.text = "Weight: " + i.weight.ToString()+"KG";
			irg.MainObject.name = i.name;
			irg.objectRectTransform.SetParent(parent);

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

			public float setPos(float heightIndex){
				objectRectTransform.localPosition = new Vector3(0,heightIndex,0);
				heightIndex += objectRectTransform.sizeDelta.y;
				return heightIndex;
			}

            private void compairObjectText(UnityEngine.UI.Text t, ItemRenderPartGeneric parentObject)
            {
                if (t.name == parentObject.itemName.name)
                    itemName = t;
                else if (t.name == parentObject.Discription.name)
                    Discription = t;
                else if (parentObject.Weight.name == parentObject.Weight.name)
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
				else if (t.name == parentObject.Discription.name)
					Discription = t;
				else if (parentObject.Weight.name == parentObject.Weight.name)
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
				else if (t.name == parentObject.Discription.name)
					Discription = t;
				else if (parentObject.Weight.name == parentObject.Weight.name)
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
