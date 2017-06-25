﻿using Ink.Runtime;
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

    public Text textButton1;
    public Text textButton2;
    public Text textButton3;

    public GameObject buttonHolder;
    public GameObject scrollView;
    public GameObject content;

    private VerticalLayoutGroup contentVerticalGroup;

    public AngryManager angryMeter;

    [Header("Messages")]
    public GameObject MessageFrame;
    public GameObject MyMessageFrame;

    [Header("Sounds")]
    public AudioClip newMessageSfx;
    public AudioClip backgroundMusic;
    private AudioSource source;

    [Header("Answer Time")]
    public TimeManager timeManager;
    [Range(5, 20)]
    public short timeForResponse;

    private Coroutine counterRoutine;



    private List<GameObject> messagesList = new List<GameObject>();


    // Use this for initialization
    void Start () {

        contentVerticalGroup = content.GetComponent<VerticalLayoutGroup>();


        source = GetComponent<AudioSource>();
        story = new Story(inkJSONAsset.text);
        source.clip = backgroundMusic;
        source.Play();
        RefreshStory(TIME_COUNTDOWN.NO,true);

    }


    private void RefreshStory(TIME_COUNTDOWN TimeforAnswer, Boolean showFirstMessageAsOther = false)
    {
        buttonHolder.SetActive(false);
        buttonHolder.transform.GetChild(0).gameObject.SetActive(false);
        buttonHolder.transform.GetChild(1).gameObject.SetActive(false);
        buttonHolder.transform.GetChild(2).gameObject.SetActive(false);
        timeManager.gameObject.SetActive(false);

        if (TimeforAnswer == TIME_COUNTDOWN.YES)
        {
            timeManager.gameObject.SetActive(true);
        }

       

        if (!showFirstMessageAsOther)
        {
            string text = story.Continue().Trim();
            CreateContentView(text, true);
        }

        while (story.canContinue)
        {
            string text = story.Continue().Trim();
            CreateContentView(text,false);
        }

        if (story.currentChoices.Count > 0) {
            buttonHolder.GetComponent<RectTransform>().sizeDelta = new Vector2(300,100 * story.currentChoices.Count);
            buttonHolder.SetActive(true);
        }
        else
        {
            //END
            timeManager.gameObject.SetActive(false);

        }

        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            if(i == 0)
            {
                buttonHolder.transform.GetChild(0).gameObject.SetActive(true);
                textButton1.text = story.currentChoices[i].text;
            }
            else if( i == 1)
            {

                textButton2.text = story.currentChoices[i].text;
                buttonHolder.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                textButton3.text = story.currentChoices[i].text;
                buttonHolder.transform.GetChild(2).gameObject.SetActive(true);
            }
        }

        if (TimeforAnswer == TIME_COUNTDOWN.YES)
        {
            counterRoutine = StartCoroutine(timeManager.Countdown());
        }
    }

    //GameObject gFrame;
    //bool lateupdate;

    void CreateContentView(string text,Boolean isMyMessage)
    {

        GameObject frame;

        GetMessageFrame(out frame, isMyMessage);


        Text message = frame.GetComponentInChildren<Text>();

        message.text = text;



        messagesList.Add(frame);

        //ResizeMessageFrame(frame);
        //gFrame = frame;
        //lateupdate = true;

    }

    private void ResizeMessageFrame(GameObject frame)
    {


        RectTransform rect = frame.GetComponentInChildren<Text>().gameObject.GetComponent<RectTransform>();

        //foreach(RectTransform child in frame.transform)
        //{

        //    if (child.gameObject.tag == "Message")
        //    {


        //        RectTransform rect = child.GetComponent<RectTransform>();

        //    }

        //}

        //float height = frame.GetComponent<RectTransform>().rect.height;

        //Vector2 size = content.GetComponent<RectTransform>().sizeDelta;

        //size.y += height + contentVerticalGroup.spacing;

        //content.GetComponent<RectTransform>().sizeDelta = size;

        //scrollView.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;

    }


    private void OnPreRender()
    {

        float height = 0;

        if (messagesList.Count > 0)
        {

            while (messagesList.Count > 0)
            {

                GameObject frame = messagesList[0];

                //frame.transform.SetParent(content.transform);


                RectTransform rectF = frame.GetComponent<RectTransform>();
                RectTransform rect = frame.GetComponentInChildren<Text>().gameObject.GetComponent<RectTransform>();

                rectF.sizeDelta = new Vector2(rectF.sizeDelta.x, rect.sizeDelta.y + 15);


                height += (rectF.sizeDelta.y + contentVerticalGroup.spacing);

                messagesList.RemoveAt(0);

            }

            Vector2 size = content.GetComponent<RectTransform>().sizeDelta;

            size.y += height;

            content.GetComponent<RectTransform>().sizeDelta = size;

            scrollView.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;




            //RectTransform rectF = gFrame.GetComponent<RectTransform>();
            //RectTransform rect = gFrame.GetComponentInChildren<Text>().gameObject.GetComponent<RectTransform>();

            //rectF.sizeDelta =  new Vector2(rectF.sizeDelta.x,  rect.sizeDelta.y + 15);



            //Vector2 size = content.GetComponent<RectTransform>().sizeDelta;

            //size.y += rectF.sizeDelta.y + contentVerticalGroup.spacing;

            //content.GetComponent<RectTransform>().sizeDelta = size;

            //scrollView.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;



            // lateupdate = false;
        }


    }

    void GetMessageFrame(out GameObject frame, Boolean isMyMessage)
    {

        if (isMyMessage)
        {
            frame = Instantiate(MyMessageFrame, content.transform) as GameObject;
            //frame = Instantiate(MyMessageFrame) as GameObject;

        }
        else
        {
            frame = Instantiate(MessageFrame, content.transform) as GameObject;
            //frame = Instantiate(MessageFrame) as GameObject;
            source.PlayOneShot(newMessageSfx);
        }

        //float height = frame.GetComponent<RectTransform>().rect.height;

        //Vector2 size = content.GetComponent<RectTransform>().sizeDelta;

        //size.y += height + contentVerticalGroup.spacing;

        //content.GetComponent<RectTransform>().sizeDelta = size;

        //scrollView.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;


    }

    public void PickRandomChoice()
    {
        if (story.currentChoices.Count > 0)
        {
            PickAChoice(UnityEngine.Random.Range(0, story.currentChoices.Count));
        }
    }

    public void PickAChoice(int choice)
    {
        if (counterRoutine != null)
        {
            StopCoroutine(counterRoutine);
        }
        timeManager.ResetScale();
        angryMeter.addAngriness(10);
        story.ChooseChoiceIndex(choice);
        RefreshStory(TIME_COUNTDOWN.YES);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
