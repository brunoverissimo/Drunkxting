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


    [Header("Panels")]
    public GameObject menuPanel;
    public GameObject gamePanel;


    [Header("Story")]
    [SerializeField]
    private TextAsset inkJSONAsset;
    [SerializeField]
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
    //public TimeManager timeManager;
    public Image timeManager;
    public Transform LoadingBar;
    [Range(5, 20)]
    public short timeForResponse;

    private Coroutine counterRoutine;

    public GameObject endButton;



    private List<GameObject> messagesList = new List<GameObject>();


    // Use this for initialization
    void Start () {

        contentVerticalGroup = content.GetComponent<VerticalLayoutGroup>();


        source = GetComponent<AudioSource>();
        

        source.clip = backgroundMusic;
        source.Play();

    }


    public void PlayStory()
    {
        if (content.transform.childCount > 0)
        {
            foreach (Transform t in content.transform)
            {
                Destroy(t.gameObject);
            }

            Vector2 size = content.GetComponent<RectTransform>().sizeDelta;

            size.y = 10;

            content.GetComponent<RectTransform>().sizeDelta = size;

        }

        story = new Story(inkJSONAsset.text);
        RefreshStory(TIME_COUNTDOWN.NO, true);
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


        string text;
        if (!showFirstMessageAsOther)
        {
            text = story.Continue().Trim();
            CreateContentView(text, true);
        }

        
        while (story.canContinue)
        {
            text = story.Continue().Trim();
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

            EndGame();

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

        if (TimeforAnswer == TIME_COUNTDOWN.YES && story.currentChoices.Count > 0)
        {
            counterRoutine = StartCoroutine(Countdown());
        }
    }

    void CreateContentView(string text,Boolean isMyMessage)
    {

        GameObject frame;

        GetMessageFrame(out frame, isMyMessage);


        Text message = frame.GetComponentInChildren<Text>();

        message.text = text;

        messagesList.Add(frame);

    }



    public IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0);

        float time = 0;

        while (LoadingBar.GetComponent<Image>().fillAmount > 0)
        {

            yield return new WaitForEndOfFrame();

            time += Time.deltaTime;

            LoadingBar.GetComponent<Image>().fillAmount = 1 - (time / timeForResponse);


        }

        PickRandomChoice();
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

                rectF.sizeDelta = new Vector2(rectF.sizeDelta.x, rect.sizeDelta.y + 10);


                height += (rectF.sizeDelta.y + contentVerticalGroup.spacing);

                messagesList.RemoveAt(0);

            }

            Vector2 size = content.GetComponent<RectTransform>().sizeDelta;

            size.y += height;

            content.GetComponent<RectTransform>().sizeDelta = size;

            scrollView.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;

        }


    }

    void GetMessageFrame(out GameObject frame, Boolean isMyMessage)
    {

        if (isMyMessage)
        {
            frame = Instantiate(MyMessageFrame, content.transform) as GameObject;

        }
        else
        {
            frame = Instantiate(MessageFrame, content.transform) as GameObject;
            source.PlayOneShot(newMessageSfx);
        }


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
        ResetScale();
        angryMeter.addAngriness(10);
        story.ChooseChoiceIndex(choice);
        RefreshStory(TIME_COUNTDOWN.YES);
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        endButton.SetActive(false);
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);

        PlayStory();

    }

    public void EndGame()
    {

        endButton.SetActive(true);

    }

    public void ReturnMainMenu()
    {

        menuPanel.SetActive(true);
        gamePanel.SetActive(false);

    }

    public void ResetScale()
    {
        LoadingBar.GetComponent<Image>().fillAmount = 1;
    }

}
