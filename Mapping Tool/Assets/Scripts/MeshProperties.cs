using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshProperties : MonoBehaviour {

    //Instantiations for mesh creation
    public GameObject thisMesh;
    public PolygonCollider2D newCollider;
    Vector2[] vertices2D;
    Vector3[] meshPoints;
    bool deletable;

    //Instantiations for User Input
    string newName = "New Area";

    // Use this for initialization
    void Start () {
        newCollider = GetComponent<PolygonCollider2D>();
        meshPoints = thisMesh.GetComponent<MeshFilter>().mesh.vertices;
        vertices2D = new Vector2[meshPoints.Length];
        for (int i = 0; i < meshPoints.Length; i++)
        {
            vertices2D[i] = new Vector2(meshPoints[i].x, meshPoints[i].y);
        }
        newCollider.points = vertices2D;
        deletable = true;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.SetColor("_Color", new Color32(255, 0, 0, 50));
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", new Color32(78, 161, 72, 50));
    }

    void OnMouseDown()
    {

    }

    void DeleteThis()
    {
        Destroy(thisMesh);
    }

}
