using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour {

    Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void updateplayerHP(float update)
    {
        if (update >= 0.02)
        {
            if(update<=0.35)
            {
                image.color = Color.red;
            }
            else if(update<=0.5)
            {
                image.color = Color.yellow;
            }
            else
            {
                image.color = Color.green;
            }
            image.fillAmount = update;
        }
        else if (update > 0)
        {
            image.color = Color.red;
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
