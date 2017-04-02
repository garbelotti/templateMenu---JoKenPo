using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
[Serializable]
public class playerData {
public int totalMoedas, totalOvo;
public float tempoTotal;
public double ultimoPresente;
public bool muteAudio;
public decimal gold,baseDMG,bonusDMG,goldM,bonusDMG2;
public int monsterLvl,monsterSubLvl;
public ArrayList jogadas;


public string salvaDados(){
		BinaryFormatter bf = new BinaryFormatter();
        MemoryStream str = new MemoryStream();
        bf.Serialize(str, this);
        string dadosT = Convert.ToBase64String(str.ToArray());	
		return dadosT;
		
}

public static playerData restauraDados(string S){
	
	byte[] bytes = Convert.FromBase64String(S);
                MemoryStream str = new MemoryStream(bytes);
                BinaryFormatter bf = new BinaryFormatter();
                playerData dadosTemp = bf.Deserialize(str) as playerData;
				return dadosTemp;
}

}
