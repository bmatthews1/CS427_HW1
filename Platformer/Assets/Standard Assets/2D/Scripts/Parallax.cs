using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public Transform target;
	public float scale = .5f;
	MeshRenderer rend;

    void Start () {
		rend = GetComponent<MeshRenderer>();
    }

	void Update () {
		Vector3 pos = target.position;
		pos.z = transform.position.z;
		transform.position = pos;
		//transform.localScale = pos;
		if (rend != null)
			rend.material.mainTextureOffset = pos*-scale;
    }
}