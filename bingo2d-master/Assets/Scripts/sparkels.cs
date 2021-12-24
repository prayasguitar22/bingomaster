using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sparkels : MonoBehaviour
{
    public Button but;
    public Sprite mint;
    
    
    public void OnMouseUpAsButton()
    {
        but.image.sprite = mint;
    }

}
