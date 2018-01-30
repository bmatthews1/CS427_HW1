using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTexture : MonoBehaviour {
	float expected = 1.0f;

	void Start() {
		MeshFilter mf = GetComponent<MeshFilter>();
		if (mf != null) {
			Bounds bounds = mf.mesh.bounds;

			Vector3 size = Vector3.Scale(bounds.size, transform.localScale);
			Vector3 adj = new Vector3(expected/ size.x, expected/ size.y/ size.z);
			print(adj);


			GetComponent<Renderer>().material.mainTextureScale = adj;
			print("resized");
			print(GetComponent<Renderer>().material.mainTextureScale);
		}
	}

	void Update(){

	}
}
