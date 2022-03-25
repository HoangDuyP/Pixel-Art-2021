using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    RaycastHit Hit;
    Vector3 Position;
    Vector3 brushPosition;
    Touch brush;

    private void Update()
    {
        TouchBrush();
    }
    private void TouchBrush()
    {
        if(Input.touchCount > 0)
        {
            brush = Input.GetTouch(0);
            Position = brush.position;
            Position.z = Camera.main.nearClipPlane;
            brushPosition = Camera.main.ScreenToWorldPoint(Position);
            brushPosition.z = -2f;
            transform.position = brushPosition;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, 2f))
            {
                if (Hit.collider.gameObject.tag != "Result")
                {
                    if (Hit.collider.gameObject.tag == "ID")
                    {
                        Hit.collider.gameObject.SendMessage("Receive_Colour");
                    }
                }
            }
        }
    }
    
}
