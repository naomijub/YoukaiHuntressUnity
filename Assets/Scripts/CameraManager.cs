using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public Transform target;
    public float smoothing = 1.0f;

    Vector3 offset;

	// Use this for initialization
	void Start () {
        
        offset = transform.position - target.position + new Vector3(-5.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
