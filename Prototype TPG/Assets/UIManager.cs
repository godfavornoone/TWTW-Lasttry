using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public void switchScene(string sceneName){
		Application.LoadLevel(sceneName);
	}

	public void Quit(){
		Application.Quit ();
	}
}
