using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMessage : MonoBehaviour
{

    public GameObject scrollView;
    public GameObject content;
    public GameObject MessageFrame;


    private float contentHeight;

    // Use this for initialization
    void Start()
    {

        //font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        //contentHeight = scrollView.GetComponent<RectTransform>().rect.height;


    }

    // Update is called once per frame
    void Update()
    {

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




    public void Sender(string text)
    {

        GameObject frame;

        Message(out frame);


        Text message = frame.GetComponentInChildren<Text>();

        message.text = text;


    }


    public void Receiver()
    {

        GameObject frame;

        Message(out frame);

        Text message = frame.GetComponentInChildren<Text>();

        message.text = System.DateTime.Now.ToString();

    }


}
