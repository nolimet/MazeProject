using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MainMenuManager : MonoBehaviour {

    public List<RectTransform> menus;
    public Camera mainCam;
    void Start()
    {
        mainCam.transform.LookAt(menus[0].transform);
    }

    IEnumerator rotateToTarget(Quaternion newRot, Quaternion originalRot)
    {

       
        float startTime = Time.time;
        for (int i = 0; i < 300; i++) 
        //while (originalRot != newRot)
        {
            mainCam.transform.rotation = Quaternion.Slerp(originalRot,newRot,(Time.time-startTime)/2f);
            yield return new WaitForEndOfFrame();
        }
        mainCam.transform.rotation = newRot;
        Debug.Log("rotComplete");
    }

    public void openMenu(int id)
    {
        Quaternion oldRot = mainCam.transform.rotation;

        mainCam.transform.LookAt(menus[id].transform);

        Quaternion newRot = mainCam.transform.rotation;

        mainCam.transform.rotation = oldRot;

        StartCoroutine(rotateToTarget(newRot, oldRot));
    }
}
