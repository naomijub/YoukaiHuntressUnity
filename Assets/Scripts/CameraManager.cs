using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public Transform target;
    public float smoothing = 1.0f;

    Vector3 offset;

	// Use this for initialization
	void Start () {
        
        offset = transform.position - target.position + new Vector3(-5f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetCamPos;
        if (target.position.x < -10.0f)
        {
            targetCamPos = new Vector3(-9.7f, -3.5f, -10.0f) + offset;
        }
        else {
            targetCamPos = target.position + offset;
        }
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
