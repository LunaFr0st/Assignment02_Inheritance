using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    float sW, sH;
    void Update()
    {
        sW = Screen.width / 16;
        sH = Screen.height / 9;
    }
    void OnGUI()
    {
        GUI.Box(new Rect(sW, sH, sW, sH), "");
    }
}
