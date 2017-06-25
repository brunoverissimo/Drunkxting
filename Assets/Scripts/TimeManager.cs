using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public Transform LoadingBar;
    public Game Game;

    [SerializeField] private float currentTime;
    [SerializeField] private float speed;
    private bool stopCorrotine;

    // Update is called once per frame
    void Update () {
	
	}

    /*
     * Processamento paralelo para contagem regressiva 
     */
    public IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0);

        float time = 0;

        while (LoadingBar.GetComponent<Image>().fillAmount > 0)
        {
            if (stopCorrotine)
            {
                break;
            }
            yield return new WaitForEndOfFrame();

            time += Time.deltaTime;

            LoadingBar.GetComponent<Image>().fillAmount = 1 - (time / Game.timeForResponse);

            
        }

        Game.PickRandomChoice();
    }

    
}
