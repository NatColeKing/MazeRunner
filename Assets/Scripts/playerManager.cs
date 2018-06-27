using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerManager : MonoBehaviour {
	public Light lightSource;
	public GameObject lightsOut;
	public GameObject back;
	public ParticleSystem fire_ps;
	public int levelTime;
	private int alpha;
	// Use this for initialization
	void Start () {
		lightSource.GetComponent<Light>();
		lightsOut.SetActive(false);
		back.SetActive(true);
	}

	// Update is called once per frame
	void Update()
    {
        var z = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        fire_ps.transform.Rotate(0, z, 0);
        fire_ps.transform.Translate(0, 0, y);

				lightSource.intensity -= 0.002f;

				if(Time.timeSinceLevelLoad > levelTime - 2) {
					fire_ps.Stop();
					if(Time.timeSinceLevelLoad > levelTime)
					{
						lightsOut.SetActive(true);
						back.SetActive(false);
					}
					if(Time.timeSinceLevelLoad > levelTime + 3)
						SceneManager.LoadScene("loseScreen");
				}

				// alpha --;
				// fire.main.startColor = new Color(255, 185, 0, alpha);
    }
}
