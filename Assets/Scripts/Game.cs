using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    // create a new attribute for the chess Piece object
    public GameObject chesspiece;

    // pozitii pentru fiecare piesa
    private GameObject[,] positions = new GameObject[8, 8]; //8 pe 8 din cauza ca tabla de sah e 8 pe 8

    private GameObject[] playerBlack = new GameObject[16]; // la inceput de joc ai 16 obiecte
    private GameObject[] playerWhite = new GameObject[16];


    private string currentPlayer = "white";

    private bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        playerWhite = new GameObject[]
        {
            Create("whiteRook", 0, 0),
            Create("whiteKnight", 1, 0),
            Create("whiteBishop", 2, 0),
            Create("whiteQueen", 3, 0),
            Create("whiteKing", 4, 0),
            Create("whiteBishop", 5, 0),
            Create("whiteKnight", 6, 0),
            Create("whiteRook", 7, 0),

            Create("whitePawn", 0, 1),
            Create("whitePawn", 1, 1),
            Create("whitePawn", 2, 1),
            Create("whitePawn", 3, 1),
            Create("whitePawn", 4, 1),
            Create("whitePawn", 5, 1),
            Create("whitePawn", 6, 1),
            Create("whitePawn", 7, 1),

        };

        playerBlack = new GameObject[]
        {
            Create("blackRook", 0, 7),
            Create("blackKnight", 1, 7),
            Create("blackBishop", 2, 7),
            Create("blackQueen", 3, 7),
            Create("blackKing", 4, 7),
            Create("blackBishop", 5, 7),
            Create("blackKnight", 6, 7),
            Create("blackRook", 7, 7),

            Create("blackPawn", 0, 6),
            Create("blackPawn", 1, 6),
            Create("blackPawn", 2, 6),
            Create("blackPawn", 3, 6),
            Create("blackPawn", 4, 6),
            Create("blackPawn", 5, 6),
            Create("blackPawn", 6, 6),
            Create("blackPawn", 7, 6),
        };


        // Seteaza toate pozitiile pieselor pe tabla de sah
        for(int i = 0; i < playerBlack.Length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }
    }

    public GameObject Create(string name, int x, int y)
    {
        // vrem sa avem o referinta catre gameObject
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);
        // apoi vrem sa accesam Chessman scriptul
        Chessman cm = obj.GetComponent<Chessman>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);

        cm.Activate();

        // i am setat pozitia si l-am activat deci il returnam
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        Chessman cm = obj.GetComponent<Chessman>();

        positions[cm.GetXBoard(), cm.GetYBoard()] = obj; // asa ne asiguram ca e umpluta corect tabla de sah

    }

    // FUNCTII PENTRU MUTARE DE PIESE

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null; // asa arat ca nu e nimic acolo
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        // vrem sa vedem daca pozitiile pe care le dam sunt pe tabla de sah

        if( x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1))
        {
            return false;
        }
        return true;
    }
    // Update is called once per frame

    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return gameOver; // verifica daca s-a realizat mat sau nu
    }

    public void NextTurn()
    {
        if (currentPlayer == "white") 
        {
            currentPlayer = "black";
        }
        else
        {
            currentPlayer = "white";
        }
        // schimbam randul jucatorilor
    }

    public void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            gameOver = false;
            SceneManager.LoadScene("Game");
        }
    }

    public void Winner(string playerWinner)
    {
        gameOver = true;
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().enabled = true;
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().text = playerWinner + " has won the match!";

        GameObject.FindGameObjectWithTag("RestartText").GetComponent<Text>().enabled = true;
    }
}
