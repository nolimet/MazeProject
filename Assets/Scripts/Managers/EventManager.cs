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
                print("Paused game");

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
                print(SpellSelf.ToString() + " casted");
            CastSpell(SpellSelf);

        }

        private static bool _enabledLoging = false;
        protected static bool EventManagerExists;
        public bool enableLoging = false;
        void Start()
        {
            _enabledLoging = enableLoging;
            if (EventManagerExists)
                Debug.LogError("there are two EventManagers");
            else
                EventManagerExists = true;
        }
    }
}