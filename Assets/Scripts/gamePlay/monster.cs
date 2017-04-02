[System.Serializable]
public class monster  {
	public int level,sublevel;
	public bool boss,subBoss;
	public monster(int l,int s){
		boss=subBoss=false;
		if ((l%5==0) && (s%10==0)) {boss=true;}
		else if (s%10==0) subBoss=true;
		this.level=l;
		this.sublevel=s;
	}
}
