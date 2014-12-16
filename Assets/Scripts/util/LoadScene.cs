using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

    public void loadLevel(string lvl)
    {
        Application.LoadLevel(lvl);
    }

    public void loadScene(int lvl)
    {
        Application.LoadLevel(lvl);
    }
}
