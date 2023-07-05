using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MenuActions : MonoBehaviour
    {
        public void OnGameStart()
        {
            SceneManager.LoadScene("GameScene");    
        }

        public void OnHome()
        {
            GameStats.Instance = null;
            SceneManager.LoadScene("PlayerSelectScene");
        }
    }
}
