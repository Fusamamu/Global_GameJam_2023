using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GlobalGameJam
{
    public class SceneLoader : MonoBehaviour
    {
        public static bool IsRestartCurrentLevel;
        
        public void StartLevel1()
        {
            LevelManager.CurrentLevel = 0;
            SceneManager.LoadScene("Level_1");
        }

        public void RestartLevel()
        {
            IsRestartCurrentLevel = true;
            SceneManager.LoadScene("Level_1");
        }
    }
}
