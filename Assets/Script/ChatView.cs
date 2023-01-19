using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ChatView : MonoBehaviour
{
    [SerializeField]
    private string chattext;
    public static ChatView instance;
    public Text inputtext;
    public void AddLog(string name, string message, DateTime time)
    {

        chattext = inputtext.text;
        this.gameObject.GetComponent<Text>().text = chattext;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {

            chattext = inputtext.text;
            this.gameObject.GetComponent<Text>().text = chattext;

        }
    }
}
