using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RedialMenu : MonoBehaviour {

    [SerializeField]
    GameObject TemplateObject;

    void makeNewButton()
    {
        
    }

    [SerializeField]
    class ButtonObj
    {
        public GameObject self;
        public Button button;
        public Text visual;
        public int spellNumb;
        public ButtonObj(GameObject _self, Text _visual,Button _button ,int _spellNumb)
        {
            self = _self;
            visual = _visual;
            button = _button;
            spellNumb = _spellNumb;
        }
    }

    [SerializeField]
    public class SpellList
    {
        string name;
        string[] Spells;
    }
}
