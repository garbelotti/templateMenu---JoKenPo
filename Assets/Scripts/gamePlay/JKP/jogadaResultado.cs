using System.Collections;
using System.Collections.Generic;
using System;
[Serializable]
public class jogadaResultado {
public btControl.jogadas jogada;
public bool venceu=false,empatou=false;

public string toString(){
    string s = jogada + " ";
    if (venceu) s+="venceu";
    else if (empatou) s+= "empatou";
    else s+="perdeu";
    return s;
}
}
