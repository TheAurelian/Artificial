using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTimer : MonoBehaviour
{
    public GameObject introCanvas;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        introCanvas.gameObject.SetActive(false);
        Debug.Log("Canvas should vanish");
    }
}
