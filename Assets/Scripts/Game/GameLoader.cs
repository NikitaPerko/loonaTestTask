using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoonaTest.Game
{
    public class GameLoader : MonoBehaviour
    {
        private void Start()
        {
            new GameObject().AddComponent<GameController>().name="GameController";
            SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
            SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        }
    }
}