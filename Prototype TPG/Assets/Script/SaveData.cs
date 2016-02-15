using UnityEngine;
using System.Collections;

public class SaveData : MonoBehaviour {

//	public enum SaveType{
//		tfloat
//		,tint
//		,tstring
//		,tbool,
//
//
//	}
	//SaveType type;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	public static void Save(string Slot,int value)
	{
		PlayerPrefs.SetInt (Slot, value);
		//Debug.Log ("SaveComplete" + Slot + "int"+value);
		
	}
	public static int Load(string Slot,int valueload,bool Log){
		if (PlayerPrefs.HasKey (Slot)) {
			if(Log)
			//Debug.Log ("LoadComplete" + Slot + "int"+valueload);
			return PlayerPrefs.GetInt (Slot);
		} else
			if(Log)
			//Debug.Log ("LoadFail" + Slot + "int"+valueload);
			return -9999;
	}
	public static void Save(string Slot,float value)
	{
		PlayerPrefs.SetFloat (Slot, value);
		//Debug.Log ("SaveComplete" + Slot + "float"+value);
			
	}
	public static float Load(string Slot,float valueload,bool Log){
		if (PlayerPrefs.HasKey (Slot)) {
			if(Log)
			//Debug.Log ("LoadComplete" + Slot + "Float"+valueload);
			return PlayerPrefs.GetFloat (Slot);
		} else {
			if(Log)
			//Debug.Log ("LoadFail" + Slot + "float"+valueload);
			return -9999;
		}
	}
	public static void Save(string Slot,string value)
	{
		PlayerPrefs.SetString (Slot, value);
		//Debug.Log ("SaveComplete" + Slot + "string"+value);
			
	}
	public static string Load(string Slot,string valueload,bool Log){
		if (PlayerPrefs.HasKey (Slot)) {
			if(Log)
			//Debug.Log ("LoadComplete" + Slot + "String"+valueload);
			return PlayerPrefs.GetString (Slot);
		} else {
			if(Log)
			//Debug.Log ("LoadFail" + Slot + "string"+valueload);
			return "";

		}
	}
	public static void Save(string Slot,bool value)
	{
		int boolean = 0;
		if (value) {
			boolean = 1;
		} else {
			boolean	= 0;
		}
		PlayerPrefs.SetInt (Slot, boolean);
		//Debug.Log ("SaveComplete" + Slot + "bool"+value);
			
	}
	public static bool Load(string Slot,bool valueload,bool Log){
		if (PlayerPrefs.HasKey (Slot)) {
			if(Log)
			//Debug.Log ("LoadComplete" + Slot + "bool"+valueload);
			if (PlayerPrefs.GetInt (Slot) == 1) {

				return true;
			} else {
				return false;
			}
				
		} else {
			if(Log)
			//Debug.Log ("LoadFail" + Slot + "bool"+valueload);
			return false;
		
		}
	}
	public static void Save(string Slot,char value)
	{
		string chars = value.ToString();

		PlayerPrefs.SetString (Slot, chars);
		//Debug.Log ("SaveComplete" + Slot + "Char"+value);
			
	}
	public static char Load(string Slot,char valueload,bool Log){
		if (PlayerPrefs.HasKey (Slot)) {
			if(Log)
			//Debug.Log ("LoadComplete" + Slot + "Char"+valueload);
			return	char.Parse (PlayerPrefs.GetString (Slot));

			
		} else {
			if(Log)
			//Debug.Log ("LoadFail" + Slot + "char"+valueload);
			return ' ';
		}
	}


}
