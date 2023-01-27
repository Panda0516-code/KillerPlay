using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SelectCharacter
{
    public class SceneTransition : MonoBehaviour
    {
        private CharacterPick myGameManagerData;

        private void Start()
        {
            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
        }

        public void GoToOtherScene(string stage)
        {
            //�@���̃V�[���f�[�^��MyGameManager�ɕۑ�
            myGameManagerData.SetNextSceneName(stage);
            //�@�L�����N�^�[�I���V�[����
            SceneManager.LoadScene("CharacterSelect");
        }
 
        public void GameStart()
        {
            //�@MyGameManagerData�ɕۑ�����Ă��鎟�̃V�[���Ɉړ�����
            SceneManager.LoadScene(myGameManagerData.GetNextSceneName());
        }
    }
}