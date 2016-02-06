using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour {

    public GameObject yoohoo;
    Player_Status a;
    public float currentFill;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        a = yoohoo.GetComponent<Player_Status>();
    }

    public void updateplayerHP(float update)
    {
        if (update >= 0.02)
        {
            image.fillAmount = update;
        }
        else if (update > 0)
        {
            image.fillAmount = .02f;
        }
        else
        {
            image.fillAmount = 0;
        }
    }



	// Update is called once per frame
	void Update () {

        

        
	
	}
}
