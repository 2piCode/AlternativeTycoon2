using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IComputerApp : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private protected GameObject computerScreenImage;
    [SerializeField] private protected GameObject appScreenImage;
    [SerializeField] private protected Button appButton;
    [SerializeField] private protected Button closeButton;
    

    protected virtual void Awake()
    {
        appButton.onClick.AddListener(() => 
        {
            appScreenImage.SetActive(true);
            computerScreenImage.SetActive(false);
        });
        appScreenImage.SetActive(false);
        closeButton.onClick.AddListener(() => 
        {
            appScreenImage.SetActive(false);
            computerScreenImage.SetActive(true);
        });
    }
}
