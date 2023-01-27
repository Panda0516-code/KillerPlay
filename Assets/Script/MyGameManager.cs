using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SelectCharacter {

    public class MyGameManager : MonoBehaviour
    {
        //�@���E�Ɉ������MyGameManager
        private static MyGameManager myGameManager;
        //�@�Q�[���S�̂ŊǗ�����f�[�^
        [SerializeField]
        private CharacterPick myGameManagerData = null;

        private void Awake()
        {
            //�@���E�Ɉ������MyGameManager�ɂ��鏈��
            if (myGameManager == null)
            {
                myGameManager = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        //�@MyGameManagerData��Ԃ�
        public CharacterPick GetMyGameManagerData()
        {
            return myGameManagerData;
        }
    }
}

