using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSelect : MonoBehaviour, IDropHandler
{
    [SerializeField] private Image water;
    public bool CountDownDone;
    public int countdownTime = 3;

    public void OnDrop(PointerEventData pointerEventData)
    {
        Debug.Log("OnDrop");
        if(pointerEventData.pointerDrag != null){
            pointerEventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            //Debug.Log("rotate to pour");
            
            //Vector3 temp = pointerEventData.pointerDrag.GetComponent<RectTransform>().transform.rotation.eulerAngles;
            //temp.z = 70.0f;
            //Debug.Log(temp);
            //pointerEventData.pointerDrag.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(temp);
            StartCoroutine(PouringDrink());
            countdownTime = 3;

            

            if(CountDownDone){
                //Vector3 temp1 = pointerEventData.pointerDrag.GetComponent<RectTransform>().transform.rotation.eulerAngles;
                //temp1.z = 0f;
                //pointerEventData.pointerDrag.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(temp1);
                //Debug.Log(temp1);
                StartCoroutine(PouringDrink());
                countdownTime = 3;
            }

        }
    }

    private IEnumerator PouringDrink()
    {

        while (countdownTime > 0)
        {
            water.enabled = true;
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }


        water.enabled = false;
        yield return new WaitForSeconds(1f);

        if (countdownTime == 0)
        {
            CountDownDone = true;
        }else if(countdownTime == 3){
            CountDownDone = false;
        }
    }
}
