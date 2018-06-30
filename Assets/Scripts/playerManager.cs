using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerManager : MonoBehaviour {
	public GameObject lightsOut;
	public ParticleSystem fire_ps;
	public Light lightSource;
	public Light flashLight;
	public int levelTime;
	private int alpha;

	// Use this for initialization
	void Start ()
	{
		lightSource.GetComponent<Light>();
		lightsOut.SetActive(false);
	}

	// Update is called once per frame
	void Update()
  {
    var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
    var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
    fire_ps.transform.Rotate(0, x, 0);
    fire_ps.transform.Translate(0, 0, z);

		lightSource.intensity -= 0.0018f;
		flashLight.intensity -= 0.0005f;

		if(Time.timeSinceLevelLoad > levelTime - 2)
		{
			fire_ps.Stop();
			if(Time.timeSinceLevelLoad > levelTime)
				lightsOut.SetActive(true);
			if(Time.timeSinceLevelLoad > levelTime + 3)
				SceneManager.LoadScene("loseScreen");
		}
  }

	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.name == "win_collider")
		{
			SceneManager.LoadScene("winScreen");
		}
	}
}
