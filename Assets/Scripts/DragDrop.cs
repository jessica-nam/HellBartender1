using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public string item;

    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        item = pointerEventData.pointerEnter.transform.name;
        Debug.Log(item);
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += pointerEventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    
    //Detect current clicks on the GameObject (the one with the script attached)
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //Output the name of the GameObject that is being clicked
        Debug.Log(name + " Game Object Click in Progress");
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Debug.Log(name + "No longer being clicked");
    }
}