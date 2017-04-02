using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudManager : MonoBehaviour {

	// Use this for initialization
	public decimal gold;
	public Text txtGold;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addGold(decimal g){
		gold+=g;
		setHud();
	}

	

	public void setHud(){
		txtGold.text=gold.ToString("0");
	}
}
