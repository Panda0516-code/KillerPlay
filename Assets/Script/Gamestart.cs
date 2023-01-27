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

        // �o�[�`�����J����
        [SerializeField] private CinemachineFreeLook _FreelookCamera;

        // �Ǐ]�Ώۃ��X�g
        [SerializeField] private GameObject _targetList;
        // �Ǐ]�Ώۏ��
        // �Ǐ]�Ώ�
        private Transform follow;
        // �Ə������킹��Ώ�
        private Transform lookAt;
        
        // �I�𒆂̃^�[�Q�b�g�̃C���f�b�N�X
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
            // �Ǐ]�Ώۏ�񂪐ݒ肳��Ă��Ȃ���΁A�������Ȃ�
            if (_targetList == null)
                return;

                // �Ǐ]�Ώۂ��X�V
                _FreelookCamera.Follow = follow;
                _FreelookCamera.LookAt = lookAt;
            
        }
       
    }
    
}

