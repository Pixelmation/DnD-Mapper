using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewportManager : MonoBehaviour
{
    public GameObject picViewport;
    Collider2D viewCollider;
    float mouseWheelSpeed;
    float zoomMax;
    float zoomMin;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        mouseWheelSpeed = 100;
        viewCollider = picViewport.GetComponent<Collider2D>();
        zoomMin = viewCollider.bounds.size.x / 2;
        mousePos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (viewCollider.OverlapPoint(mousePos) && Input.mouseScrollDelta.y != 0)
        {            
            print("working");
            SetZoom(-Input.mouseScrollDelta.y, mouseWheelSpeed);
        }
    }

    void SetZoom(float delta, float zoomSpeed)
    {
        Vector3 rectScale = viewCollider.bounds.size;

        //	X
        rectScale.x -= delta * zoomSpeed;
        if (rectScale.x > zoomMax)
        {
            rectScale.x = zoomMax;
        }
        else if (rectScale.x < zoomMin)
        {
            rectScale.x = zoomMin;
        }

        //	Y
        //rectScale.y -= delta * zoomSpeed;
        //if (rectScale.y > zoomMax)
        //{
        //    rectScale.y = zoomMax;
        //}
        //else if (rectScale.y < zoomMin)
        //{
        //    rectScale.y = zoomMin;
        //}
    }

    private void OnMouseOver()
    {
        print("Mouse is Over");
    }

    /*
    bool MouseInViewport()
    {
        if (Input.mousePosition.x > picViewport.position.)
        {

            return true;
        }
        else
        {
            return false;
        }
    }
    */
}
