using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class DisplayHighScore : MonoBehaviour
    {
        private DatabaseAccess databaseAccess;


        public Text highScoreOutPut;

        void Start()
        {
            databaseAccess = GameObject.FindGameObjectWithTag("DatabaseAccess").GetComponent<DatabaseAccess>();
            Invoke("DisplayHighScoreInTextMesh", 2f);
        }

        private async void DisplayHighScoreInTextMesh()
        {
            var task = databaseAccess.GetScoresFromDataBase();
            var result = await task;
            var output = "";
            foreach (var score in result)
            {
                output += score.UserName + " Набрано очков: " + score.Score + "\n";
            }
            highScoreOutPut.text = output;
        }
    }
}
