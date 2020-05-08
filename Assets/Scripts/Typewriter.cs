using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour
{
    Text text;
    string storyText;

    private void Awake()
    {
        text = GetComponent<Text>();
        storyText = text.text;
        text.text = "";

        StartCoroutine(Begin());
    }

    IEnumerator Begin()
    {
        foreach (char c in storyText)
        {
            text.text += c;
            yield return new WaitForSeconds(0.01f);
        }
    }

}
