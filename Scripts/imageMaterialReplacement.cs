using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageMaterialReplacement : KanjiSelectionGUI
{
    //public Material kanjiStroke;

    private int currentText = 0;

    private Touch finger;

    public GameObject empty;

    public ScriptableObject theFile;

    private string folderName;
    //public string buttonName

    void Start()
    {

        //Debug.Log(folderName);
        folderName = PlayerPrefs.GetString("FolderName");

        Debug.Log(folderName);

        Debug.Log("Folder that's being used: " + folderName);
        //folderName = "0f9a8";
       
        GetComponent<Renderer>().material.mainTexture = Resources.Load("xmlFiles/" + folderName + "/Original") as Texture2D;
    }

    // Update is called once per frame
    void Update()
    {
        //Change the folder name
        //folderName = "this should be defined by user input";

        //For computer keyboards
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("At Texture: " + currentText.ToString());
            GetComponent<Renderer>().material.mainTexture = Resources.Load("xmlFiles/" + folderName + "/" + currentText.ToString()) as Texture2D;
            currentText++;
        }

        /**/
        //For iOS tapping input

        /*
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("A Finger Pressed");
                //Debug.Log("At Texture: " + currentText.ToString());
                GetComponent<Renderer>().material.mainTexture = Resources.Load("xmlFiles/0599b/" + currentText.ToString()) as Texture2D;
                currentText++;
            }
        }

        /**/

    }
}
