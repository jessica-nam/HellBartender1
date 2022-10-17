using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SidePanel : MonoBehaviour
{

    public TextMeshProUGUI nameDisplay;
    void Start()
    {
        DisplayName();
    }
    // Start is called before the first frame update
    public void DisplayName(){
        Debug.Log(DialogueManager.instance.characterName);
        nameDisplay.text = DialogueManager.instance.characterName;
    }
}
