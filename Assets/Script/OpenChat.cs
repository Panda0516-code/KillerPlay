using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class OpenChat : StrixBehaviour 
{
    //�`���b�g���̓p�[�c
    [SerializeField] private InputField inputField;

    //�`���b�g�����o���p�[�c
    [SerializeField] private ChatWindow chatWindow;
    //���O�p�[�c
    [SerializeField] private ChatView chatView;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            RpcToAll(nameof(CallSendChat), inputField.text, DateTime.Now);
        }
    }
    public void SendChat(string name, string message, DateTime time)
    {
        ChatView.instance.AddLog(name,message,time);
    }
    [StrixRpc]
    public void CallSendChat(string message,DateTime time, StrixRpcContext context)
    {
        SendChat(context.sender.GetName(), message, time);
        if (context.senderUid.Equals(strixReplicator.ownerUid))
        { 
        
        }
    }
}
