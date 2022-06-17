using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ComputerCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject computerCanvas;
        [SerializeField] private Button closeButton;

        private void Awake()
        {
            closeButton.onClick.AddListener(() => computerCanvas.SetActive(false));
            computerCanvas.SetActive(false);
        }

        private void OnMouseDown() => computerCanvas.SetActive(true);
    }
}
