using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SnapScrollComputerMenu : MonoBehaviour, IEndDragHandler, IDragHandler
{
    [Range(1, 500)]
    [SerializeField] private int panelOffset;
    [Range(0f, 20f)]
    [SerializeField] private float snapSpeed;
    [SerializeField] private List<GameObject> apps = new List<GameObject>();
    [SerializeField] private RectTransform contentRectangle;
    [SerializeField] private ScrollRect scrollRectangle;

    private bool isDragged;
    private GameObject closestButton;
    private Vector2 contentVector = new Vector2(0, 0);

    void Awake()
    {
        for (int i = 1; i < apps.Count; i++)
        {
            apps[i].transform.localPosition = new Vector2(
                apps[i - 1].transform.localPosition.x + apps[0].GetComponent<RectTransform>().sizeDelta.x + panelOffset,
                apps[i].transform.localPosition.y
                );
        }
        closestButton = apps[0];
    }

    private void FixedUpdate()
    {
        scrollRectangle.inertia = (
            (-contentRectangle.anchoredPosition.x >= apps[0].transform.localPosition.x - 10) &&
            (-contentRectangle.anchoredPosition.x <= apps[apps.Count - 1].transform.localPosition.x + 10));
        if (Mathf.Abs(scrollRectangle.velocity.x) >= 400)
        {
            setClosestButton();
        }
        if (!isDragged && Mathf.Abs(scrollRectangle.velocity.x) < 400)
        {
            scrollRectangle.inertia = (Mathf.Abs(scrollRectangle.velocity.x) < 100);
            getToClosestButton();
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        isDragged = false;
        setClosestButton();
    }

    public void OnDrag(PointerEventData data)
    {
        isDragged = true;
    }

    private void setClosestButton()
    {
        double distance;
        double closestButtonDistance = double.MaxValue;;

        for (int i = 0; i < apps.Count; i++) 
        {
            distance = Mathf.Abs(contentRectangle.anchoredPosition.x + apps[i].transform.localPosition.x);
            if (distance < closestButtonDistance)
            {
                closestButtonDistance = distance;
                closestButton = apps[i];
            }
        }
    }

    private void getToClosestButton()
    {
        contentVector.x = Mathf.SmoothStep(
            contentRectangle.anchoredPosition.x, 
            -closestButton.transform.localPosition.x, 
            snapSpeed * Time.fixedDeltaTime);
        contentRectangle.anchoredPosition = contentVector;
    }
}
