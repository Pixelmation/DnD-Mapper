using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshProperties : MonoBehaviour {

    Renderer rend;

    // Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        rend.material.shader = Shader.Find("_color");
        rend.material.SetColor("_color", Color.red);
    }
}
