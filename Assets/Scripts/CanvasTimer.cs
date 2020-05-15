using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTimer : MonoBehaviour
{
    [SerializeField]
    private float waitTime;

    private void OnEnable()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
        Debug.Log("Canvas should vanish");
    }
}
