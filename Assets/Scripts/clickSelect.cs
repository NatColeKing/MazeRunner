using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class clickSelect : MonoBehaviour {
		public Material on;
		public Material off;
		public String sceneName;
		void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
				this.gameObject.GetComponent<MeshRenderer>().material = on;
				if (Input.GetMouseButtonDown(0))
				{
					if(sceneName == "quit")
					{
						Debug.Log("Quit application");
						Application.Quit();
					}
					SceneManager.LoadScene(sceneName);
				}
    }
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
				this.gameObject.GetComponent<MeshRenderer>().material = off;
    }
}
