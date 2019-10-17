using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewportManager : MonoBehaviour
{
    public GameObject picViewport;
    Collider2D viewCollider;

    // Start is called before the first frame update
    void Start()
    {
        viewCollider = picViewport.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (viewCollider.bounds.Contains(Input.mousePosition) && Input.mouseScrollDelta.y != 0)
        {
            print("working");
        }
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
