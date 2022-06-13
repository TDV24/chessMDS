using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFunctionality : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public GameObject otherGameObject;
    private string textDescription;
    private ModificatorDeScene modificatorDeScene;

    // Start is called before the first frame update

    void Awake()
    {
        modificatorDeScene = GetComponent<ModificatorDeScene>();

    }

    void Start()
    {
        GetComponent<Text>().color = new Color(255, 255, 255);
        otherGameObject = GameObject.Find("DropdownTheme");
        
    }

    void OnMouseOver()
    {
        GetComponent<Text>().color = Color.red;
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        GetComponent<Text>().color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        textDescription = GetComponent<Text>().text;
        Debug.Log(textDescription); //This is never logging
        GetComponent<Text>().color = Color.gray;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Text>().color = new Color(255, 255, 255);
        Debug.Log("Mouse exit");
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        

        textDescription = GetComponent<Text>().text;
        switch(textDescription)
        {
            case "Play":

                Debug.Log("Play the game!");
                modificatorDeScene.LoadScene("Game");

                break;

            case "Options":

                Debug.Log("See the options of the game!");
                modificatorDeScene.LoadScene("Options");
                break;


            case "Back":
                if (otherGameObject == null)
                {
                    Debug.Log("MORT");
                }

                else
                {
                    int value = otherGameObject.GetComponent<Dropdown>().value + 1;
                    Debug.Log("O sa salvez valoarea:" + value);

                    PlayerPrefs.SetInt("tema", value);
                    modificatorDeScene.LoadScene("Menu");
                }
                
                break;

            case "Quit":
                Application.Quit();

                break;
        }
    }
}
