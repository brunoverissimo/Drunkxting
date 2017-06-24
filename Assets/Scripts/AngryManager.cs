using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AngryManager : MonoBehaviour {

    public Transform angryBar;
    private Color32 currentColor;
    private float totalAngry;
    private float currentAngry;
    byte red = 72;
    byte green = 148;
    byte blue = 74;
    byte alpha = 255;
    int timer = 0;
    public int colorChangeRate = 3;
    [SerializeField] private float initialAngry;


    private void Start()
    {
       
        currentAngry = initialAngry;
        totalAngry = currentAngry;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentAngry >= 0)
        {
            currentAngry -= 10 * Time.deltaTime;
            if(timer% colorChangeRate == 0)
            {

                if (red < 255)
                {
                    red++;
                }
                if (green > 0)
                {
                    green--;
                }
                if (blue > 0)
                {
                    blue--;
                }
            }
            timer++;

        }
        angryBar.GetComponent<Image>().fillAmount = currentAngry / 100;
        angryBar.GetComponent<Image>().color = new Color32(red, green, blue, alpha);
    }

    public void addAngriness(float angryAmount)
    {
        currentAngry -= angryAmount;
    }
    public void removeAngriness(float angryAmount)
    {
        currentAngry += angryAmount;
    }
    public void resetAngriness()
    {
        currentAngry = totalAngry;
    }
}
