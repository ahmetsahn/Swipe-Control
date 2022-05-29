using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5;
    private float horizontalInput;
    private int xRange = 4;
    private bool touching;
    Vector3 lastPos;

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

       if(Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);
            touching = true;

            if (touching)
            {
                lastPos = new Vector3((Camera.main.ScreenToViewportPoint(touch.position).x-0.5f) * 8, transform.position.y, transform.position.z);
               
                // Camera.main.ScreenToViewportPoint(touch.position) takes a value between 0 and 1
                // When the player is at 0, Camera.main.ScreenToViewportPoint(touch.position) is at 0.5
                // So 0.5 is subtracted
                // The player can move between -4 and 4 on the x-axis.Difference 8.So it is multiplied by 8.

                 transform.position = Vector3.Lerp(transform.position, lastPos, Time.deltaTime * 10);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                touching = false;
            }  
        }
    }
    }

