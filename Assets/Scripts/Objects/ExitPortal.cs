using UnityEngine;
using System.Collections;
namespace Mechanismes
{
    public class ExitPortal : BasicUse
    {
        [SerializeField]
        private string LevelToOpen = "";

        protected override void UseObj()
        {
            Application.LoadLevel(LevelToOpen);    
        }
    }
}
