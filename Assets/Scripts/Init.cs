using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {

    TextMesh textM;
    public string initText;

    bool loopStarted = false;
	void Start () 
    {
        textM = GetComponent<TextMesh>();
        textM.text = "";
        StartCoroutine(init());
	}
	
	IEnumerator init()
    {
        textM.text = "";
        foreach(char c in initText)
        {
            textM.text += c;
            print(c);
            yield return new WaitForSeconds(0.05f);
        }

        StartCoroutine(loop());
    }

    IEnumerator loop()
    {
        bool cycle = false;
        loopStarted = true;

        string TempS = initText;
        while (loopStarted)
        {
        if (cycle)
            textM.text += "_";
        else
            textM.text = TempS;

        cycle = !cycle;
        yield return new WaitForSeconds(0.5f);
        }
    }


    void Update()
    {
        if (loopStarted && Input.GetKeyDown(KeyCode.Return))
        {
            loopStarted = false;
            StartCoroutine(init());
        }
    }

    void OnGUI()
    {
       initText = GUI.TextField(new Rect(0, 0, 200, 20), initText);
    }
}
