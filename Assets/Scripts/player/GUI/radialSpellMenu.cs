using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class radialSpellMenu : MonoBehaviour
{

    [SerializeField]
    GameObject TemplateObject;
    [SerializeField]
    SpellList[] Magics;
    [SerializeField]
    List<Menu> menus;
    RectTransform rectTrans;
    [SerializeField]
    RectTransform canvas;
    [SerializeField]
    float radius = 200f, angleOffSet = 0f;

    public static radialSpellMenu instance;
    void Start()
    {
        instance = this;
        rectTrans = GetComponent<RectTransform>();

        GameObject g;
        GameObject p;
        ButtonObj b;
        RectTransform pt;
        Menu pm;


        int l;
        int k = Magics.Length;
        float angle;


        l = Magics.Length;
        angle = 360f / l;

        p = new GameObject("Magics");
        p.AddComponent<RectTransform>().SetParent(rectTrans);
        pt = p.GetComponent<RectTransform>();
        pm = new Menu(pt, p);
        menus.Add(pm);
        pt.localPosition = Vector3.zero;

        for (int i = 0; i < l; i++)
        {
            g = (GameObject)Instantiate(TemplateObject);
            g.SetActive(true);
            b = new ButtonObj(g, g.GetComponentInChildren<Text>(), g.GetComponent<Button>(), i, Magics[i].name, 0);
            b.RectTrans.SetParent(pt);
            b.RectTrans.localPosition = (Vector3)VectorExtension.angleToVector((angle * i) + angleOffSet).normalized * radius;
        }

        for (int j = 0; j < k; j++)
        {
            p = new GameObject(Magics[j].name);
            p.AddComponent<RectTransform>().SetParent(rectTrans);
            
            pt = p.GetComponent<RectTransform>();
            pm = new Menu(pt, p);
            menus.Add(pm);
            pt.localPosition = Vector3.zero;

            l = Magics[j].Spells.Length;
            angle = 360f / l;

            for (int i = 0; i < l; i++)
            {
                g = (GameObject)Instantiate(TemplateObject);
                g.SetActive(true);
                b = new ButtonObj(g, g.GetComponentInChildren<Text>(), g.GetComponent<Button>(), i, Magics[j].Spells[i], j + 1);
                b.RectTrans.SetParent(pt);
                b.RectTrans.localPosition = (Vector3)VectorExtension.angleToVector((angle * i) + angleOffSet).normalized * radius;
            }
        }
        l = menus.Count;
        for (int i = 1; i < l; i++)
        {
            menus[i].menuGameObject.SetActive(false);
        }
       
    }
    void Update()
    {
        if(managers.MenuManager.paused)
            OpenMenu(0);
        else
            OpenMenu(-1);
    }

    public void OpenMenu(int id)
    {
        for (int i = 0; i < menus.Count; i++)
        {
            menus[i].menuGameObject.SetActive(false);
        }
        if(id>-1)
            menus[id].menuGameObject.SetActive(true);
    }

    public void SelectSpell(int type, int id)
    {
        HSMManager.instance.changeSpell(type, id);
    }

    [System.Serializable]
    class ButtonObj
    {
        public GameObject self;
        public RectTransform RectTrans;
        public Button button;
        public Text visual;
        public int spellNumb;
        public int spellType;

        public ButtonObj(GameObject _self, Text _visual,Button _button ,int _spellNumb, string SpellName,int _spellType)
        {
            self = _self;
            visual = _visual;
            button = _button;
            spellNumb = _spellNumb;
            spellType = _spellType;
            RectTrans = self.GetComponent<RectTransform>();

            visual.text = SpellName;
            self.name = SpellName;

            AddEvents();
        }

        void AddEvents()
        {
            button.onClick.RemoveAllListeners();
            if (spellType == 0)
            {
                
                //Add your new event
                button.onClick.AddListener(delegate
                {
                    radialSpellMenu.instance.OpenMenu(spellNumb + 1);
                });
            }
            else
            {
                button.onClick.AddListener(delegate
                {
                    radialSpellMenu.instance.SelectSpell(spellType, spellNumb);
                });
            }
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
