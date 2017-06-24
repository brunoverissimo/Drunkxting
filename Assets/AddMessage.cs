using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMessage : MonoBehaviour {


    public GameObject content;


    private Font font;

	// Use this for initialization
	void Start () {

        font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

    }
	
	// Update is called once per frame
	void Update () {
		
	}



    public void Message()
    {

        GameObject message = new GameObject("Text");

        message.transform.parent = content.transform;

        Text text = message.AddComponent<Text>();

        text.text = System.DateTime.Now.ToString();

        text.font = font;

        //string[] str = text.font.fontNames;


    }


}
