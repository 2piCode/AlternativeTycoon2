using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ComputerCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject computerCanvas;
        [SerializeField] private Button closeButton;
        [SerializeField] private Button modRaiting;
        [SerializeField] private Button modCreatorButton;
        [SerializeField] private Button bankButton;
        [SerializeField] private Button newsButton;
        [SerializeField] private Button shopButton;
        [SerializeField] private List<GameObject> programs = new List<GameObject>();
        private void Awake()
        {
            closeButton.onClick.AddListener(() => computerCanvas.SetActive(false));
            modCreatorButton.onClick.AddListener(() =>
            {
                //0 - ModCreator
                programs[0].SetActive(true);
                computerCanvas.SetActive(false);
            });
        }
        
        private void Start()
        {
            computerCanvas.SetActive(false);
        }
        
        private void OnMouseDown() => computerCanvas.SetActive(true);
    }
}