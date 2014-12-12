using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class RedialSpellMenu : MonoBehaviour {

    [SerializeField]
    GameObject TemplateObject;
    [SerializeField]
    SpellList[] Spells;
    [SerializeField]
    List<Menu> menus;
    RectTransform rectTrans;
    [SerializeField]
    RectTransform canvas;

    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        GameObject g;
        GameObject p;

        int l;
        foreach (SpellList spell in Spells)
        {
            p = new GameObject(spell.name);
            ButtonObj b;
            p.AddComponent<RectTransform>().parent=canvas;
            l = spell.Spells.Length;
            for (int i = 0; i < l; i++)
            {
                g = (GameObject)Instantiate(TemplateObject);
                b = new ButtonObj(g, g.GetComponentInChildren<Text>(), g.GetComponent<Button>(), i, spell.Spells[i]);
            }
        }
    }

    void makeNewButton()
    {
    }

    [System.Serializable]
    class ButtonObj
    {
        public GameObject self;
        RectTransform RectTrans;
        public Button button;
        public Text visual;
        public int spellNumb;

        public ButtonObj(GameObject _self, Text _visual,Button _button ,int _spellNumb, string SpellName)
        {
            self = _self;
            visual = _visual;
            button = _button;
            spellNumb = _spellNumb;

            RectTrans = self.GetComponent<RectTransform>();

            visual.text = SpellName;
            
        }
    }

    [System.Serializable]
    public class SpellList
    {
        public string name;
        public string[] Spells;
    }

    [System.Serializable]
    public class Menu
    {
        public RectTransform menu;
        public GameObject menuGameObject;

        public Menu(RectTransform menu, GameObject menuGameObject)
        {
            this.menu = menu;
            this.menuGameObject = menuGameObject;
        }
    }
}
