using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {


    public float speed;
    public float maxDistance;
    private float maxDist = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        maxDist += 1 * Time.deltaTime;

        if (maxDist >= maxDistance)
            Destroy(this.gameObject);
	}

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
