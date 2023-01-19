using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatWindow : MonoBehaviour
{
    [SerializeField] private int seconds;
    private Text Chattext;
    private void Start()
    {
        Chattext = GetComponentInChildren<Text>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {

            StartCoroutine("ImageAndTextActive");

        }
    }
    IEnumerator ImageAndTextActive()
    {
        this.gameObject.GetComponent<Image>().enabled = true;
        Chattext.enabled = true;
        yield return new WaitForSeconds(seconds);
        this.gameObject.GetComponent<Image>().enabled = false;
        Chattext.enabled = false;

    }
}
