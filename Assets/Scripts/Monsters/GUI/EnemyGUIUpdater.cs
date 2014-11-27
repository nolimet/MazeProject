using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using util;
[RequireComponent(typeof(gameData.Stats))]
public class EnemyGUIUpdater : MonoBehaviour {

    [SerializeField]
    CanvasImg Hp = new CanvasImg();
    [SerializeField]
    Text text;
    gameData.Stats data;
	// Use this for initialization
	void Start () {
        Hp.SetOrignals();
        data = GetComponent<gameData.Stats>();
	}
	
	// Update is called once per frame
	void Update () {
        Hp.ResizeScale(data.health / data.maxHealth);
        text.text = "HP: " + data.health + "/" + data.maxHealth;
	}
}
