    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCamMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position - new Vector3(Time.deltaTime * 1f, 0, 0);
	}
}
