using UnityEngine;
using System.Collections;

public class DisableOrEnableObject : MonoBehaviour {

	public GameObject menu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void whenButtonClicked()
	{
		if (menu.activeInHierarchy == true)
			menu.SetActive(false);
		else
			menu.SetActive(true);
	}
}
