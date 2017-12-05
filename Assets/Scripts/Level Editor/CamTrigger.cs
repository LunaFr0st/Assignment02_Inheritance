using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public int idValue = -1;
    CameraMover camMove;
    void Start()
    {
        camMove = GameObject.Find("LevelGenerator").GetComponent<CameraMover>();
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            idValue++;
            camMove.CameraMove(idValue);
        }
    }
}
