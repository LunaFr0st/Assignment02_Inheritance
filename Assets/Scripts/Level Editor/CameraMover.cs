using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public GameObject[] camPos;
    public float step;
    void Update()
    {
        if (camPos.Length == 0)
        {
            camPos = GameObject.FindGameObjectsWithTag("CamTrigger");
        }    
    }
    public void CameraMove(int camID)
    {
        step = 50 * Time.deltaTime;
        Vector3 pos = Camera.main.transform.position;
        pos = Vector3.MoveTowards(pos, camPos[camID].transform.position, step);
    }

}
