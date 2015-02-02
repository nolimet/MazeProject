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
            public Sprite icon;
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