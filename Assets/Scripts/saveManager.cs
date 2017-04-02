using UnityEngine;
using System.Collections.Generic;
using System;
public class saveManager : MonoBehaviour {

	public void salva(string key, string dado){
		byte[] toBytes = GetBytes(dado);
		string tempcode = Convert.ToBase64String(toBytes);
		PlayerPrefs.SetString(key, tempcode);
		Debug.Log("saving...");
		PlayerPrefs.Save();
	}

	public void salva(string key, int dado){
		salva(key, dado.ToString());
	}

	public void salva(string key, float dado){
		salva(key, dado.ToString());
	}

	public void salva(string key, bool dado){
		salva(key, dado.ToString());
	}

	public string carrega(string key){
		string tempstr = PlayerPrefs.GetString(key);
		byte[] tempb=Convert.FromBase64String(tempstr);
		return GetString(tempb);
	}
	

	static byte[] GetBytes(string str)
{
     byte[] bytes = new byte[str.Length * sizeof(char)];
     System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
     return bytes;
}

static string GetString(byte[] bytes)
{
     char[] chars = new char[bytes.Length / sizeof(char)];
     System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
     return new string(chars);
}


}