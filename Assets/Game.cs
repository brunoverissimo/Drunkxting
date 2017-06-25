using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game : MonoBehaviour {

    enum TIME_COUNTDOWN
    {
        YES,
        NO
    }


    [Header("Story")]
    [SerializeField]
    private TextAsset inkJSONAsset;
    private Story story;



    public GameObject scrollView;
    public GameObject content;
    public GameObject MessageFrame;


    [Header("Answer Time")]
    public Image radialBar;
    [Range(5, 20)]
    public short timeForResponse;

    private Coroutine counterRoutine;


    // Use this for initialization
    void Start () {

        story = new Story(inkJSONAsset.text);



        /**
         *  Demetrio disse para não contar tempo na primeira pergunta. 
         */
        RefreshStory(TIME_COUNTDOWN.YES);


    }

    private void RefreshStory(TIME_COUNTDOWN TimeforAnswer)
    {

        while (story.canContinue)
        {
            string text = story.Continue().Trim();
            CreateContentView(text);
        }


        if (TimeforAnswer == TIME_COUNTDOWN.YES)
        {
            counterRoutine = StartCoroutine(Countdown());
        }



    }

    void CreateContentView(string text)
    {

        GameObject frame;

        Message(out frame);

        Text message = frame.GetComponentInChildren<Text>();

        message.text = text;

    }



    void Message(out GameObject frame)
    {

        frame = Instantiate(MessageFrame, content.transform) as GameObject;

        float height = frame.GetComponent<RectTransform>().rect.height;

        Vector2 size = content.GetComponent<RectTransform>().sizeDelta;

        size.y += height;

        content.GetComponent<RectTransform>().sizeDelta = size;

        scrollView.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;

        //return frame;



    }



    /*
     * Processamento paralelo para contagem regressiva 
     */
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0);

        float time = 0;

        while (radialBar.fillAmount > 0)
        {
            yield return new WaitForEndOfFrame();

            time += Time.deltaTime;

            radialBar.fillAmount = 1 - (time / timeForResponse);

            Debug.Log(time);
        }

        PickRandomChoice();
    }


    void PickRandomChoice()
    {
        Debug.Log("Pick Random");
    }



    // Update is called once per frame
    void Update () {
		
	}
}
