using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteShape : MonoBehaviour
{
    public bool searching;
    Ray ray;
    int layerMask = 1 << 8;

    // Start is called before the first frame update
    void Start()
    {
        searching = false;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (searching && Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, Input.mousePosition);
            //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (hit)
            {
                //if (hit.collider.gameObject.name == "Mesh Temp (clone)")
                //{
                    print(hit.collider.gameObject.name);

                    searching = false;
                
                //}
            }            
        }
    }

    ///checks if the button is pressed
    void OnMouseDown()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", new Color32(255, 0, 0, 255));
    }

    private void OnMouseUp()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", new Color32(0, 240, 255, 255));
        searching = true;
    }

    //GameObject GetClickedGameObject()
    //{
    //
    //}
}
