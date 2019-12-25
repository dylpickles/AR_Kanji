using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class KanjiSelectionGUI : MonoBehaviour
{
    //public List<string> folderNames = new List<string>();
    private static string[] folderNames = Directory.GetDirectories("Assets/Resources/xmlFiles");

    private string[] tempSplit;

    private int numDispKanji = 0;

    private int idk = 0;

    public Dictionary<string, string> selectedButton = new Dictionary<string, string>();

    //public string folder;
    protected string folder;

    int i = 0;

    int times = 0;

    public Button TL;
    public Button TR;
    public Button BL;
    public Button BR;

    public Button RightArrow;

    public string choseButton;

    void Start()
    {
        //This is to have preset folder names ready in case one will be chosen from the main screen
        selectedButton["TL"] = "0f9ad";
        selectedButton["TR"] = "0f9af";
        selectedButton["BL"] = "0f9b1";
        selectedButton["BR"] = "0f9b2";
    }
    /**/


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ChosenButton()
    {
        choseButton = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("YOU CHOSE: " + choseButton);
        folder = selectedButton[choseButton];
        Debug.Log("This kanji is from folder: " + folder);
    }

    public void NewPageDisplay()
    {

        Debug.Log("Page Split");

        for (i = i; i < (folderNames.Length - 4); i++)
        {
            folder = folderNames[i];
            tempSplit = folder.Split("/"[0]);
            folder = tempSplit[3];

            if (numDispKanji != 4)
            {
                Debug.Log("At Folder: " + folder);

                //Record the folder name to reference the correct kanji
                if (numDispKanji == 0)
                {
                    selectedButton["TL"] = folder;
                    TL.GetComponent<CanvasRenderer>().SetTexture(Resources.Load("xmlFiles/" + folder + "/Original") as Texture2D);
                }
                else if (numDispKanji == 1)
                {
                    selectedButton["TR"] = folder;
                    TR.GetComponent<CanvasRenderer>().SetTexture(Resources.Load("xmlFiles/" + folder + "/Original") as Texture2D);
                }

                else if (numDispKanji == 2)
                {
                    selectedButton["BL"] = folder;
                    BL.GetComponent<CanvasRenderer>().SetTexture(Resources.Load("xmlFiles/" + folder + "/Original") as Texture2D);
                }
                else if (numDispKanji == 3)
                {
                    selectedButton["BR"] = folder;
                    BR.GetComponent<CanvasRenderer>().SetTexture(Resources.Load("xmlFiles/" + folder + "/Original") as Texture2D);
                }

                numDispKanji++;
            }
            else
            {
                break;
            }
        }
        numDispKanji = 0;
    }

    public void UseThisKanji()
    {
        Debug.Log("Key is: " + choseButton);
        Debug.Log("Key Value is: " + selectedButton[choseButton]);

        //Specify the folder being used, set it able to be referenced in another scene
        PlayerPrefs.SetString("FolderName" , folder);

        Debug.Log("The folder is now: " + folder);

        //set the displated maaterial to whatever's on the button
        SceneManager.LoadScene(1);
    }
}