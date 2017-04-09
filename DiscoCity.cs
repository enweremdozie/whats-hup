using UnityEngine;
using System.Collections;

public class DiscoCity : MonoBehaviour {

	public Material blue;
	public Material red;
	public Material green;
	public Material yellow;
	public Material[] materials = new Material[24];
	public GameObject[] levelLeft = new GameObject[40];
	public GameObject[] levelRight = new GameObject[40];
	public GameObject[] levelTop = new GameObject[40];
	public GameObject[] levelBottom = new GameObject[40];
	public GameObject[] back = new GameObject[2];
	float duration = 5f;
	GameObject topR;
	GameObject topL;
	GameObject botR;
	GameObject botL;
	public Material blueDeath;
	public Material greenDeath;
	public Material redDeath;
	public Material yellowDeath;
	public bool QBdark;
	public bool collided;
	int num;
   // bool cond = true;
    GameObject[] other;
	GameObject[] leftSide;
	GameObject[] rightSide;
	public Material sky;
	int state;
	float frameRate;
	bool nightMare;
	public bool NMover;
	public int endCount = 0;

void ForGit(){

//I just want to see
}

	void Awake(){
		
		other = GameObject.FindGameObjectsWithTag("LevelWall");//walls at the top, bottom, front and back found with tag
		leftSide = GameObject.FindGameObjectsWithTag("WallLeft");//walls on the left found with tag
		rightSide = GameObject.FindGameObjectsWithTag("WallRight");//walls on the right found with tag
		frameRate = 1/Time.deltaTime;//frame rate
		topR = GameObject.FindGameObjectWithTag ("TR");
		botR = GameObject.FindGameObjectWithTag ("BR");
		topL = GameObject.FindGameObjectWithTag ("TL");
		botL = GameObject.FindGameObjectWithTag ("BL");


	}
		
	void Update(){


	}
	public void choose(bool collide){
		//collide = GameObject.Find ("manager").GetComponent<score> ().collide;
		if ((collide == true))// && (nightMare == false))
			dark ();
		else if ((collide == false)){// && (nightMare == false)) {
			topR.GetComponent<Renderer> ().sharedMaterial = red;
			topL.GetComponent<Renderer> ().sharedMaterial = green;
			botR.GetComponent<Renderer> ().sharedMaterial = blue;
			botL.GetComponent<Renderer> ().sharedMaterial = yellow;

			qbcol ();
			//Lights ();
			//Debug.Log(nightMare);
		}
	}

	public void dark(){
		topR.GetComponent<Renderer> ().sharedMaterial = redDeath;
		topL.GetComponent<Renderer> ().sharedMaterial = greenDeath;
		botR.GetComponent<Renderer> ().sharedMaterial = blueDeath;
		botL.GetComponent<Renderer> ().sharedMaterial = yellowDeath;

	}

	public void qbcol(){
		NMover = GameObject.Find("manager").GetComponent<Xob>().nmend;
		//Debug.Log (NMover);
		if (NMover == true) {
			topR.GetComponent<Renderer> ().sharedMaterial = red;
			topL.GetComponent<Renderer> ().sharedMaterial = green;
			botR.GetComponent<Renderer> ().sharedMaterial = blue;
			botL.GetComponent<Renderer> ().sharedMaterial = yellow;

		} 
		Lights ();
	}

	public void Lights(){
		
		nightMare = GameObject.Find("manager").GetComponent<Xob>().nightmare;

		RenderSettings.skybox = sky;//Sky box template
		//GameObject.Find("manager").GetComponent<QB_color>().QBtrans();
		//Debug.Log ("this is the frame rate " + frameRAte);


		//GameObject.Find ("manager").GetComponent<GameManager> ().QBdark;//for deciding if QB is dark
		//Debug.Log("here");
		num = Random.Range(0, 23);
		//collide = GameObject.Find("manager").GetComponent<score>().collided;
		//Debug.Log (collide);



		back[0].GetComponent<Renderer>().sharedMaterial = materials[num];//selecting front wall and changing its texture
		back[1].GetComponent<Renderer>().sharedMaterial = materials[num];//selecting back wall and changing its texture

		for(int i = 0; i < levelLeft.Length; i++)//for loop for changing texture of walls on the top, left, right and bottom
		{
			collided = GameObject.Find ("manager").GetComponent<score> ().collided;
 
			num = Random.Range(0, 23);
			levelLeft[i].GetComponent<Renderer>().sharedMaterial = materials[num];
			
			for(int j = 0; j < levelRight.Length; j++)
			{
				num = Random.Range(0, 23);
				levelRight[j].GetComponent<Renderer>().sharedMaterial = materials[num];
			}
			
			for(int k = 0; k < levelTop.Length; k++)
			{
				num = Random.Range(0, 23);
				levelTop[k].GetComponent<Renderer>().sharedMaterial = materials[num];
			}
			
			for(int l = 0; l < levelBottom.Length; l++)
			{
				num = Random.Range(0, 23);
				levelBottom[l].GetComponent<Renderer>().sharedMaterial = materials[num];
			}
			//print ("this is night mare " + nightMare);
			//if(QBdark == false && collided != false){


			//}
		}
		// StartCoroutine("waitSomeTime");
		endCount++;
	  }



	
	IEnumerator waitSomeTime() {//coroutine if still needed at some point
		
		yield return new WaitForSeconds(duration);

		Lights ();
	}//end of waitSomeTime()

}//end of DiscoCity






