using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GlobalGameJam
{
    public class SceneLoader : MonoBehaviour
    {
        public void GoToGameplay()
        {
            SceneManager.LoadScene("Level_1");
        }
    }
}
