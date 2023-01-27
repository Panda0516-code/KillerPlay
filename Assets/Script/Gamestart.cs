using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;
using SoftGear.Strix.Unity.Runtime;

namespace SelectCharacter
{
    public class Gamestart : StrixBehaviour
    {
    
        [SerializeField]
        private CharacterPick myGameManagerData = null;

        // バーチャルカメラ
        [SerializeField] private CinemachineFreeLook _FreelookCamera;

        // 追従対象リスト
        [SerializeField] private GameObject _targetList;
        // 追従対象情報
        // 追従対象
        private Transform follow;
        // 照準を合わせる対象
        private Transform lookAt;
        
        // 選択中のターゲットのインデックス
        private int _currentTarget = 0;


        void Start()
        {
            if (!isLocal)
            { return; }
            Instantiate(myGameManagerData.GetCharacter(), Vector3.zero, Quaternion.identity);
            _targetList = GameObject.FindWithTag("Player");
            if(_targetList != isLocal)
            {
                return;
            }
            follow = _targetList.transform;
            lookAt = _targetList.transform;
            // 追従対象情報が設定されていなければ、何もしない
            if (_targetList == null)
                return;

                // 追従対象を更新
                _FreelookCamera.Follow = follow;
                _FreelookCamera.LookAt = lookAt;
            
        }
       
    }
    
}

