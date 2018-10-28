using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    MeshCollider mc;

	// Use this for initialization
	void Start () {
        mc = GetComponent<MeshCollider>();
        mc.enabled = false;
        mc.enabled = true;

    }
	
	// Update is called once per frame
	void Update () {
        float screenWidthInUnit = GameManager.Instance.screenWidthInUnit;
        float cameraX = Camera.main.transform.position.x;
        float curCameraStartX = cameraX - screenWidthInUnit / 2;

        if(transform.position.x + 1 < curCameraStartX)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
