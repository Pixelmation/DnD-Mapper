using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewShape : MonoBehaviour {

    //lists for verties and their 
    public List<Vector3> vertices;
    public List<GameObject> vertexVisuals;

    public GameObject vertexPoint;
    public Camera maincameraLad;

    bool enableVertexTracking = false;
    bool ignoreFirst = true;

    public GameObject meshTemplate;
    public Material meshMat;

    // Use this for initialization
    void Start () {
        List<Vector3> verticies = new List<Vector3>();
        List<GameObject> vertexVisuals = new List<GameObject>();
        maincameraLad = Camera.main;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0) && enableVertexTracking)
        {
            if (!ignoreFirst)
            {
                vertices.Add(Input.mousePosition);
                print("added vertex at: " + Input.mousePosition);
                GameObject circleLad = Instantiate(vertexPoint, maincameraLad.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, .5f)), Quaternion.Euler(0,0,0));
                vertexVisuals.Add(circleLad);

                if (vertices.Count >= 3)
                {
                    ValidPolygonCheck();
                }
            }
            else
            {
                ignoreFirst = false;
            }
        }

	}

    void OnMouseDown()
    {
        enableVertexTracking = true;
        ignoreFirst = true;
    }

    void ValidPolygonCheck()
    {
        float endDistance = GetDistanceBetweenVectors(vertices[0], vertices[vertices.Count - 1]);
        //print("distance between first and last vertex: " + endDistance);
        if (endDistance <= 20)
        {
            //print("vectors are close enough. closing polygon");
            for (int i = 0; i < vertices.Count - 1; i++)
            {
                vertices[i] = maincameraLad.ScreenToWorldPoint(new Vector3(vertices[i].x, vertices[i].y, -.05f));
                print("Vertex " + (i+1) + ": (" + vertices[i].x + ", " + vertices[i].y + ")");

            }

            CreateMesh(vertices);

            vertices.Clear();
            while(vertexVisuals.Count >= 1)
            { 
                GameObject deletedBoi = vertexVisuals[0];
                vertexVisuals.Remove(deletedBoi);
                Destroy(deletedBoi.gameObject);

            }

            enableVertexTracking = false;
        }
    }

    float GetDistanceBetweenVectors(Vector3 a, Vector3 b)
    {
        Vector2 c = b - a;
        return c.magnitude;
    }

    void CreateMesh(List<Vector3> source)
    {
        //made -1 because of faulty extra value — bandaid solution
        Vector2[] vertices2D = new Vector2[source.Count - 1];
        print("Test: " + source.Count);
        for (int i = 0; i < (source.Count); i++)
        {
            print("Added Vertex " + (i + 1) + ": (" + source[i].x + ", " + source[i].y + ")");
        }

        print("2D length: " + vertices2D.Length);
        for (int i = 0; i < (source.Count - 1); i++)
        {
            vertices2D[i] = new Vector2(source[i].x, source[i].y);
            print("Added Vertex " + (i + 1) + ": (" + vertices2D[i].x + ", " + vertices2D[i].y + ")");
            

        }

        //use triangulator to get indicies for creating triangles
        Triangulator tr = new Triangulator(vertices2D);
        int[] indicies = tr.Triangulate();

        //Create the Vector3 vertices
        Vector3[] vertices3D = new Vector3[vertices2D.Length];
        print("2D length: " + vertices2D.Length);
        for (int i = 0; i < vertices3D.Length; i++)
        {
            vertices3D[i] = new Vector3(vertices2D[i].x, vertices2D[i].y, -.05f);
            print("Added Vertex " + (i + 1) + ": (" + vertices2D[i].x + ", " + vertices2D[i].y + ")");
        }

        //create the mesh
        GameObject newMesh = Instantiate(meshTemplate);

        Mesh msh = new Mesh();
        msh.vertices = vertices3D;
        msh.triangles = indicies;
        msh.RecalculateNormals();
        msh.RecalculateBounds();

        //set up game object with mesh
        newMesh.AddComponent(typeof(MeshRenderer));
        MeshFilter filter = newMesh.AddComponent(typeof(MeshFilter)) as MeshFilter;
        filter.mesh = msh;

        newMesh.GetComponent<MeshRenderer>().material = meshMat;
    }

}
