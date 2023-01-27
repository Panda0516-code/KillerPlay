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
            //　次のシーンデータをMyGameManagerに保存
            myGameManagerData.SetNextSceneName(stage);
            //　キャラクター選択シーンへ
            SceneManager.LoadScene("CharacterSelect");
        }
 
        public void GameStart()
        {
            //　MyGameManagerDataに保存されている次のシーンに移動する
            SceneManager.LoadScene(myGameManagerData.GetNextSceneName());
        }
    }
}