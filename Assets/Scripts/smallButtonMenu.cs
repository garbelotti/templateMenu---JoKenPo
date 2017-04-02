using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class smallButtonMenu : MonoBehaviour {

	public Button me;
	public Animator anima;
	public bool opened;
	// Use this for initialization
	void Start () {
		opened=false;
		me.onClick.AddListener(clicked);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void clicked(){
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
		anima.SetTrigger("open");
	}

	public void close(){
		anima.SetTrigger("close");
	}
}
