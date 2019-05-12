using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonParticle : MonoBehaviour {

	void Update () {
        Destroy(gameObject, 2f);
	}
}
