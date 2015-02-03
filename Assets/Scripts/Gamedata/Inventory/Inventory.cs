using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace gameData.InventorySystem
{
	[System.Serializable]
    public class Inventory
    {
        public List<item> contents;
        public InvType ContainerType;

        #region enums
        public enum itemType
        {
            misc,
            key,
            armor,
            weapon
        }

        public enum ArmorType
        {
            Heavy,
            medium,
            light,
            none
        }

        public enum ArmorPart
        {
            Bracelet,
            ChestPlate,
            Helmet,
            Pants,
            Gloves,
            Boots,
            ShoulderPads,
            Cape,
            Shirt,
            Belt,
            Ring,
            Amulet
        }

        public enum InvType
        {
            Monster,
            Player,
            Container
        }
        #endregion

		#region Item MainClasses
        [System.Serializable]
        public class item
        {
			public string name = "";
            public itemType type = itemType.misc;
            public float weight = 0;
            public string Discription = "";
            public Sprite icon = new Sprite();
            public item (string _name = "", itemType _type = itemType.misc, float _weight = 0, string _discription = "")
            {
                name = _name;
                type = _type;
                weight = _weight;
                Discription = _discription;
            }
        }

        [System.Serializable]
        public class weapon : item
        {
            public int dmg = 0;
            public gameData.Stats.DMGTypes[] enchant = new Stats.DMGTypes[1];
        }

        [System.Serializable]
        public class equip : item
        {
            public int armor = 0;
            public gameData.Stats.DMGTypes armorType = Stats.DMGTypes.Arcane;
            public ArmorPart part = ArmorPart.Ring;
            public armorStat stats = new armorStat();

            public equip(string _name = "", itemType _type = itemType.armor, float _weight = 0, string _discription = "", int _armor= 0, gameData.Stats.DMGTypes _armortype = Stats.DMGTypes.Arcane, ArmorPart _part = ArmorPart.Amulet) : base (_name, _type, _weight, _discription)
            {
                armor = _armor;
                armorType = _armortype;
                part = _part;
            }
        }

        public class key : item
        {
            public GameObject willUnlock;
        }
        [System.Serializable]
        public class armorStat
        {
            public int Str, Int, Agl, Sta;
        }
		#endregion
    }
}