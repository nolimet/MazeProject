using UnityEngine;
using System.Collections;

public class ResetOnInvdoneloading : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        managers.EventManager._InventoryDoneloading += EventManager__InventoryDoneloading;
    }

    private void EventManager__InventoryDoneloading()
    {
        StartCoroutine(resetDelay());
    }

    IEnumerator resetDelay()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        GetComponent<UnityEngine.UI.Scrollbar>().value = 1;
    }

    void OnDestory()
    {
        managers.EventManager._InventoryDoneloading -= EventManager__InventoryDoneloading;
    }
}
