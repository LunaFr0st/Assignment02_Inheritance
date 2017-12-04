using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAim : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        
        Vector3 currentPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = Input.mousePosition;
        Vector3 direction = (mousePos - currentPos).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

}
