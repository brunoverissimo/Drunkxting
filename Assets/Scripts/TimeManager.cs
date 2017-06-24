using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public Transform LoadingBar;

    [SerializeField] private float currentTime;
    [SerializeField] private float speed;

	
	// Update is called once per frame
	void Update () {
	    if(currentTime < 100)
        {
            currentTime += speed * Time.deltaTime;
        }
        else
        {
            //use end of time function
        }

        LoadingBar.GetComponent<Image>().fillAmount = currentTime / 100;
	}
}
