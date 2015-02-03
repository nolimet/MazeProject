using UnityEngine;
using System.Collections;

namespace managers
{
    public class EventManager : MonoBehaviour
    {

        public delegate void PauseAction();
        public static event PauseAction Pause;
        public static void FirePause()
        {
            if (_enabledLoging)
                CustomDebug.Log("Paused game", CustomDebug.Level.Trace);

            if (Pause != null)
                Pause();
        }

        public delegate void SaveAction(string filePath);
        public static event SaveAction Save;
        public static void SaveGame(string filePath)
        {
            Save(filePath);
        }

        public delegate void LoadAction(string filePath);
        public static event LoadAction Load;
        public static void LoadGame(string filePath)
        {
            Load(filePath);
        }

        public delegate void CastSpellAction(MagicSpells.SelfSpells spellSelf);
        public static event CastSpellAction CastSpell;
        public static void CastedSpell(MagicSpells.SelfSpells SpellSelf)
        {
            if (_enabledLoging)
                CustomDebug.Log(SpellSelf.ToString() + " casted");
            CastSpell(SpellSelf);

        }

        public delegate void InventoryOpened(gameData.InventorySystem.Inventory Player, gameData.InventorySystem.Inventory other = null);
        public static event InventoryOpened openInventory;
        public static void CallOpendInventory(gameData.InventorySystem.Inventory Player, gameData.InventorySystem.Inventory other = null)
        {
            if(_enabledLoging)
                CustomDebug.Log("Opened an inventory of type " + Player.ContainerType + " and one of type " + other.ContainerType);
            openInventory(Player, other);
        }

        public delegate void InventoryDoneLoading();
        public static event InventoryDoneLoading _InventoryDoneloading;
        public static void OnInventoryDoneLoading()
        {
            if (_enabledLoging)
                CustomDebug.Log("Inventory done loading");
        }

        //In Mamanger var's. Have nothing todo with the eventmanager it self. Just for logging
        private static bool _enabledLoging = false;
        protected static bool EventManagerExists;
        public bool enableLoging = false;
        public CustomDebug.Level logLevel;

        //Init for manager;
        void Start()
        {
            _enabledLoging = enableLoging;
            if (EventManagerExists)
                Debug.LogError("there are two EventManagers");
            else
                EventManagerExists = true;

            CustomDebug.LogLevel = logLevel;
        }

        
    }

    
}

