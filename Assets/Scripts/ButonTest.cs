using UnityEngine;
using System.Collections;

public class ButonTest : MonoBehaviour {

    public enum coolLevel
    {
        boring,
        better,
        super,
        SUPAR
    }

    public void Test(Mdata test)
    {
        print("boobBeeb");
        print(test.boob);
    }

    [System.Serializable]
    public class Mdata
    {
        public string hello;
        public coolLevel boob;
    }
}
