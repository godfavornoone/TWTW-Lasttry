using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SPBarScript : MonoBehaviour {

    Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void updateplayerSP(float update)
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
}
