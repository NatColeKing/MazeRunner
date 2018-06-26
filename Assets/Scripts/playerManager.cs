using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour {
	public Light lightSource;
	public ParticleSystem fire;
	private int alpha;
	// Use this for initialization
	void Start () {
		lightSource.GetComponent<Light>();
	}

	// Update is called once per frame
	void Update()
    {
        var z = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        fire.transform.Rotate(0, 0, z);
        fire.transform.Translate(0, -y, 0);

				lightSource.intensity -= 0.002f;

				alpha --;
				fire.main.startColor = new Color(255, 185, 0, alpha);
    }
}
