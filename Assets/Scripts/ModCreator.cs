using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game
{
    public class ModCreator : MonoBehaviour
    {
        [SerializeField] private GameObject modCreatorCanvas;
        [SerializeField] private InputField name;
        [SerializeField] private Button closeButton;
        [SerializeField] private Dropdown genreScrollbar;
        [SerializeField] private Dropdown countryScrollbar;
        [SerializeField] private Slider costSlider;
        private void Awake()
        {
            closeButton.onClick.AddListener(() => modCreatorCanvas.SetActive(false));
        }
        
        private void Start()
        {
            GameManager.singleton.onFinishDay += CreateMod;
            modCreatorCanvas.SetActive(false);
        }
        
        //private void OnMouseDown() => modCreatorCanvas.SetActive(true);

        public void CreateMod()
        {
            // string eventText = $"{ev.name}\n{ev.description}\n\n";
            // writeTextInNote(eventText);
            
        }
    }
  
}
