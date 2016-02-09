using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EXPBarScript : MonoBehaviour {

    Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void updateplayerEXP(float update)
    {
        if (update >= 0.95)
        {
            image.fillAmount = 0.95f;
        }
        else 
        {
            image.fillAmount = update;
        }
    }
}
