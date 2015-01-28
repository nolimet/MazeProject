using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace gameData.InventorySystem
{
    public class Inventory : MonoBehaviour
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

        [System.Serializable]
        public class item
        {
            public itemType type = itemType.misc;
            public string name = "";
            public float weight = 0;
            public string Discription = "";
            public Sprite icon;
        }

        [System.Serializable]
        public class weapon : item
        {
            public int dmg;
            public gameData.Stats.DMGTypes[] enchant;
        }

        [System.Serializable]
        public class equip : item
        {
            public int armor;
            public gameData.Stats.DMGTypes armorType;
            public ArmorPart part;
            public armorStat stats;
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
    }
}