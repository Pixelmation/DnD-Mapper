using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteShape : MonoBehaviour
{
    public bool searching = false;
    int layerMask = 1 << 8;

    // Start is called before the first frame update
    void Start()
    {
        searching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);
            //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (hit)
            {
                if (hit.collider.gameObject.name == "meshTemp(Clone)")
                {
                    Destroy(hit.collider.gameObject);                
                }
            }            
                    searching = false;
        }
    }

    public void DeleteObject()
    {
        searching = true;

        StartCoroutine("DeleteCheck");
    }

    IEnumerator DeleteCheck()
    {
        while (searching)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);
                //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (hit)
                {
                    if (hit.collider.gameObject.name == "meshTemp(Clone)")
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
                searching = false;
            }
            yield return null;
        }
    }
}
