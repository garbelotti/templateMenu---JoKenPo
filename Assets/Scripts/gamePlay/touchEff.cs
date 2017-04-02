using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchEff : MonoBehaviour {
	public GameObject eff;
	public Camera c;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void makeEffect(Vector2 v){
		var t = Instantiate(eff,transform);
		//t.gameObject.transform.position=v;
		//Debug.Log(t.gameObject.transform.position);
		
		Vector3 screenPos = c.WorldToScreenPoint(v);
		Debug.Log(v);
		t.GetComponent<RectTransform>().anchoredPosition = v/100;
	}
}
