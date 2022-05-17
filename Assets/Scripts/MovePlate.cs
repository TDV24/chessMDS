using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject controller;

    GameObject reference = null; // cand apesi pe o piesa de sah, se genereaza movePlate ul, dar tre sa ai o referinta catre obiectul pe care ai apasat

    // pozitii pe tabla, nu world pos
    int matrixX;
    int matrixY;

    public bool attack = false;

    public void Start()
    {
        if(attack)
        {
            // schimbi in rosu
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        if(attack)
        {
            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);
            //stabilim daca piesa luata este regele(testam functia de win)
            if (cp.name == "whiteKing")
                controller.GetComponent<Game>().Winner("Black");
            if (cp.name == "blackKing")
                controller.GetComponent<Game>().Winner("White");
            Destroy(cp);
        }

        controller.GetComponent<Game>().SetPositionEmpty(
            reference.GetComponent<Chessman>().GetXBoard(),
            reference.GetComponent<Chessman>().GetXBoard()); // pozitia trebuie sa fie goala dupa ce mutam piesa de sah

        reference.GetComponent<Chessman>().SetXBoard(matrixX);
        reference.GetComponent<Chessman>().SetYBoard(matrixY);
        reference.GetComponent<Chessman>().SetCoords();

        controller.GetComponent<Game>().SetPosition(reference);
        controller.GetComponent<Game>().NextTurn(); //schimb randul
        reference.GetComponent<Chessman>().DestroyMovePlates(); // revin
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }
}
