using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class simplePanelUp : MonoBehaviour {

	// Use this for initialization
	public Button me,imageBack;
	public Animation anima;
	public bool opened;
	// Use this for initialization
	void Start () {
		opened=false;
		me.onClick.AddListener(clicked);
		imageBack.onClick.AddListener(clicked);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void clicked(){
		if (!anima.isPlaying)
		if (!opened) {
			opened=true;
			open();
		}else
		{
			
			opened=false;
			close();
		}

	}

	public void open(){
		
		anima.Play("simplePanelUp");
		
	}

	public void close(){
		
		anima.Play("simplePanelDown");
	}

}
