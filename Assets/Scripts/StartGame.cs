using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game
{
    

    public class StartGame : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        private void Awake()
        {
            startButton.onClick.AddListener(() => SceneManager.LoadScene("Garage"));
            exitButton.onClick.AddListener(() => Application.Quit());
        }
    }
}

