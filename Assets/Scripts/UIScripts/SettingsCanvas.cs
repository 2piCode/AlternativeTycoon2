using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class SettingsCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject settingsCanvas;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button quitButton;


        private void Awake()
        {
            settingsCanvas.SetActive(false);
            
            settingsButton.onClick.AddListener(() => settingsCanvas.SetActive(true));

            resumeButton.onClick.AddListener(() => settingsCanvas.SetActive(false));
            quitButton.onClick.AddListener(() => Application.Quit());
        }
    }
}


