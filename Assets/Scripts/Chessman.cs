using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Chessman : MonoBehaviour
{
    // need more references
    public GameObject controller;   // avem o ref catre controller pe care il atasam imd
    public GameObject movePlate;    // apesi pe patratul pe care vrei sa muti piesa de sah

    // setam pozitii
    private int xBoard = -1; // inca nu este pe tabla de sah
    private int yBoard = -1;

    // Variabile care sa faca tracking daca negru sau alb muta
    private string player;          // by default nu ii zicem nimic


    // sprite urile pentru fiecare element din joc

    public Sprite blackQueen, blackKnight, blackBishop, blackKing, blackRook, blackPawn;
    public Sprite whiteQueen, whiteKnight, whiteBishop, whiteKing, whiteRook, whitePawn;


    // cand piesa de sah este facuta, atunci se apeleaza Activate()
    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController"); // ca sa il gaseasca pe gameController

        // ia locatia instantiata si ajusteaza transformarea
        // cand cream obiectul ne da o locatie anume si noi vrem sa o transformam
        // adica modificam coordonatele X si Y 

        SetCoords();

        switch (this.name)
        {
            case "blackQueen": this.GetComponent<SpriteRenderer>().sprite = blackQueen; player = "black";  break;
            case "blackKnight": this.GetComponent<SpriteRenderer>().sprite = blackKnight; player = "black";  break;
            case "blackBishop": this.GetComponent<SpriteRenderer>().sprite = blackBishop; player = "black"; break;
            case "blackKing": this.GetComponent<SpriteRenderer>().sprite = blackKing; player = "black"; break;
            case "blackRook": this.GetComponent<SpriteRenderer>().sprite = blackRook; player = "black"; break;
            case "blackPawn": this.GetComponent<SpriteRenderer>().sprite = blackPawn; player = "black"; break;

            case "whiteQueen": this.GetComponent<SpriteRenderer>().sprite = whiteQueen; player = "white";  break;
            case "whiteKnight": this.GetComponent<SpriteRenderer>().sprite = whiteKnight; player = "white"; break;
            case "whiteBishop": this.GetComponent<SpriteRenderer>().sprite = whiteBishop; player = "white"; break;
            case "whiteKing": this.GetComponent<SpriteRenderer>().sprite = whiteKing; player = "white"; break;
            case "whiteRook": this.GetComponent<SpriteRenderer>().sprite = whiteRook; player = "white"; break;
            case "whitePawn": this.GetComponent<SpriteRenderer>().sprite = whitePawn; player = "white"; break;
        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        // ajustam bazat pe world positionul din unity si nu pe baza pozitiilor tablei de sah 

        x *= 0.64f;
        y *= 0.64f;

        x += -2.25f;
        y += -2.0f;

        // setam pozitia in unity si acum ajustam transformul

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    private void OnMouseUp()
    {
        if (!controller.GetComponent<Game>().IsGameOver() && controller.GetComponent<Game>().GetCurrentPlayer() == player)
        {
            DestroyMovePlates();

            InitiateMovePlates();
        }
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for(int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    public void InitiateMovePlates()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        Game sc = controller.GetComponent<Game>();

        var board = new char[10, 10]; // aici vreau sa tin codificarile la piese

        board = controller.GetComponent<Game>().getBoard();

        switch(this.name)
        {
            case "blackQueen":
            case "whiteQueen":
                LineMovePlate(1, 0, board); // creeaza o linie de movePlates pentru toate cazurile
                LineMovePlate(0, 1, board);
                LineMovePlate(1, 1, board);
                LineMovePlate(-1, 0, board);
                LineMovePlate(0, -1, board);
                LineMovePlate(-1, -1, board);
                LineMovePlate(-1, 1, board);
                LineMovePlate(1, -1, board);
                break;

            case "blackKnight":
            case "whiteKnight":
                LMovePlate(board);       // management la mersul in forma de L
                break;

            case "blackBishop":
            case "whiteBishop":
                LineMovePlate(1, 1, board);
                LineMovePlate(1, -1, board);
                LineMovePlate(-1, 1, board);
                LineMovePlate(-1, -1, board);
                break;

            case "blackKing":
            case "whiteKing":
                SurroundMovePlate(board);
                break;

            case "blackRook":
            case "whiteRook":
                LineMovePlate(1, 0, board);
                LineMovePlate(-1, 0, board);
                LineMovePlate(0, 1, board);
                LineMovePlate(0, -1, board);
                break;

            case "blackPawn":
                if(yBoard == 6)
                    PawnMovePlate(xBoard, yBoard - 2, 2, board);
                PawnMovePlate(xBoard, yBoard - 1, 0, board);
                break;

            case "whitePawn":
                if(yBoard == 1)
                    PawnMovePlate(xBoard, yBoard + 2, 1, board);
                PawnMovePlate(xBoard, yBoard + 1, 0, board);
                break;


        }
    }

    public int IsInCheck(char [,] board , int player)
    {
        // if player is white, I will check whether the white king is attacked by any black pieces and opposite
        // uppercase = white, lowercase = black
        int xKing = 0, yKing = 0;
        for(int i = 0; i <= 7; ++i)
        {
            for(int j = 0; j <= 7; ++j)
            {
                if(board[i, j] == 'K' && player == 0)
                {
                    xKing = i;
                    yKing = j;
                }
                if(board[i, j] == 'k' && player == 1)	
                {
                    xKing = i;
                    yKing = j;
                }
            }
        }
        
        // king check (invalid in normal chess though)
        
        for(int xDif = -1; xDif <= 1; ++xDif)
        {
            for(int yDif = -1; yDif <= 1; ++yDif)
            {
                int copyX = xKing + xDif;
                int copyY = yKing + yDif;
                if(copyX >= 0 && copyX <= 7 && copyY >= 0 && copyY <= 7)
                {
                    if(player == 0 && board[copyX, copyY] == 'k')
                        return 1;
                    if(player == 1 && board[copyX, copyY] == 'K')
                        return 1;
                }
            }
        }
        
        // pawn check
        
        if(player == 0) // white
        {
            if(xKing > 0 && yKing < 7 && board[xKing - 1, yKing + 1] == 'p')
                return 1;
            if(xKing < 7 && yKing < 7 && board[xKing + 1, yKing + 1] == 'p')
                return 1;
        }
        if(player == 1) // black
        {
            if(xKing > 0 && yKing > 0 && board[xKing - 1, yKing - 1] == 'P')
                return 1;
            if(xKing < 7 && yKing > 0 && board[xKing + 1, yKing - 1] == 'P')
                return 1;
        }
        
        // bishop check + queen diagonal check
        
        for(int xDif = -1; xDif <= 1; xDif += 2)
        {
            for(int yDif = -1; yDif <= 1; yDif += 2)
            {
                int copyX = xKing + xDif;
                int copyY = yKing + yDif;
                while(copyX >= 0 && copyX <= 7 && copyY >= 0 && copyY <= 7 && board[copyX, copyY] == '.')
                {
                    copyX += xDif;
                    copyY += yDif;
                }
                if(copyX >= 0 && copyX <= 7 && copyY >= 0 && copyY <= 7)
                {
                    if(player == 0)
                    {
                        if(board[copyX, copyY] == 'b' || board[copyX, copyY] == 'q')
                        {
                            return 1;
                        }
                    }
                    else
                    {
                        if(board[copyX, copyY] == 'B' || board[copyX, copyY] == 'Q')
                        {
                            return 1;
                        }
                    }
                }
            }
        }

        // rook check + queen line check
        
        for(int xDif = -1; xDif <= 1; xDif++)
        {
            for(int yDif = -1; yDif <= 1; yDif++)
            {
                if((xDif == 0 || yDif == 0) && xDif + yDif != 0)
                {
                    int copyX = xKing + xDif;
                    int copyY = yKing + yDif;
                    while(copyX >= 0 && copyX <= 7 && copyY >= 0 && copyY <= 7 && board[copyX, copyY] == '.')
                    {
                        copyX += xDif;
                        copyY += yDif;
                    }
                    if(copyX >= 0 && copyX <= 7 && copyY >= 0 && copyY <= 7)
                    {
                        if(player == 0)
                        {
                            if(board[copyX, copyY] == 'r' || board[copyX, copyY] == 'q')
                            {
                                return 1;
                            }
                        }
                        else
                        {
                            if(board[copyX, copyY] == 'R' || board[copyX, copyY] == 'Q')
                            {
                                return 1;
                            }
                        }
                    }
                }
            }
        }
        
        // knight check
        
        for(int xDif = -2; xDif <= 2; ++xDif)
        {
            for(int yDif = -2; yDif <= 2; ++yDif)
            {
                int sum = Math.Abs(xDif) + Math.Abs(yDif);
                if(sum == 3)
                {
                    int copyX = xKing + xDif;
                    int copyY = yKing + yDif;
                    if(copyX >= 0 && copyX <= 7 && copyY >= 0 && copyY <= 7)
                    {
                        if(player == 0 && board[copyX, copyY] == 'n')
                            return 1;
                        if(player == 1 && board[copyX, copyY] == 'N')
                            return 1;
                    }
                }
            }
        }
        
        return 0;
        
    }

    public void LineMovePlate(int xIncrement, int yIncrement, char [,] board)
    {

        Game sc = controller.GetComponent<Game>();

        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;

        while(sc.PositionOnBoard(x, y) && sc.GetPosition(x, y) == null)
        {
            var good = 1;
            var pcs = board[xBoard, yBoard];
            var turn = 1;
            board[xBoard, yBoard] = '.';
            board[x, y] = pcs;
            if(Char.IsUpper(pcs) == true)
                turn = 0;
            if(IsInCheck(board, turn) == 1)
                good = 0;
            board[x, y] = '.';
            board[xBoard, yBoard] = pcs;
            if(good == 1)
                MovePlateSpawn(x, y);
            x += xIncrement;
            y += yIncrement;

        }

        if (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<Chessman>().player != player)
        {
            // daca nu e egal inseamna ca putem sa atacam
            var good = 1;
            var pcs = board[xBoard, yBoard];
            var turn = 1;
            var oldpiece = board[x, y];
            board[xBoard, yBoard] = '.';
            board[x, y] = pcs;
            if(Char.IsUpper(pcs) == true)
                turn = 0;
            if(IsInCheck(board, turn) == 1)
                good = 0;
            board[x, y] = oldpiece;
            board[xBoard, yBoard] = pcs;
            if(good == 1)
                 MovePlateAttackSpawn(x, y);
        }
    }

    public void LMovePlate(char [,] board)
    {
        PointMovePlate(xBoard + 1, yBoard + 2, board); // pt ca forma de L are +1 si +2
        PointMovePlate(xBoard - 1, yBoard + 2, board);
        PointMovePlate(xBoard + 2, yBoard + 1, board);
        PointMovePlate(xBoard + 2, yBoard - 1, board);
        PointMovePlate(xBoard + 1, yBoard - 2, board);
        PointMovePlate(xBoard - 1, yBoard - 2, board);
        PointMovePlate(xBoard - 2, yBoard + 1, board);
        PointMovePlate(xBoard - 2, yBoard - 1, board);
    }

    public void SurroundMovePlate(char [,] board)
    {
        PointMovePlate(xBoard, yBoard + 1, board);
        PointMovePlate(xBoard, yBoard - 1, board);
        PointMovePlate(xBoard - 1, yBoard - 1, board);
        PointMovePlate(xBoard - 1, yBoard - 0, board);
        PointMovePlate(xBoard - 1, yBoard + 1, board);
        PointMovePlate(xBoard + 1, yBoard - 1, board);
        PointMovePlate(xBoard + 1, yBoard - 0, board);
        PointMovePlate(xBoard + 1, yBoard + 1, board);

    }

    public void PointMovePlate(int x, int y, char [,] board)
    {
        Game sc = controller.GetComponent<Game>();

        if(sc.PositionOnBoard(x, y))
        {

            if (sc.GetPosition(x, y) == null)
            {
                var good = 1;
                var pcs = board[xBoard, yBoard];
                var turn = 1;
                board[xBoard, yBoard] = '.';
                board[x, y] = pcs;
                if(Char.IsUpper(pcs) == true)
                    turn = 0;
                if(IsInCheck(board, turn) == 1)
                    good = 0;
                board[x, y] = '.';
                board[xBoard, yBoard] = pcs;
                if(good == 1)
                    MovePlateSpawn(x, y);
            }

            else if(sc.GetPosition(x, y).GetComponent<Chessman>().player != player)
            {
                var good = 1;
                var pcs = board[xBoard, yBoard];
                var turn = 1;
                var oldpiece = board[x, y];
                board[xBoard, yBoard] = '.';
                board[x, y] = pcs;
                if(Char.IsUpper(pcs) == true)
                    turn = 0;
                if(IsInCheck(board, turn) == 1)
                    good = 0;
                board[x, y] = oldpiece;
                board[xBoard, yBoard] = pcs;
                if(good == 1)
                    MovePlateAttackSpawn(x, y);
            }
        }
    }

    public void PawnMovePlate(int x, int y, int FirstMove, char [,] board)
    {
        Game sc = controller.GetComponent<Game>();
        if(sc.PositionOnBoard(x, y))
        {
            if(sc.GetPosition(x, y) == null )
            {
                var good = 1;
                var pcs = board[xBoard, yBoard];
                var turn = 1;
                board[xBoard, yBoard] = '.';
                board[x, y] = pcs;
                if(Char.IsUpper(pcs) == true)
                    turn = 0;
                if(IsInCheck(board, turn) == 1)
                    good = 0;
                board[x, y] = '.';
                board[xBoard, yBoard] = pcs;
                if(good == 1)
                    MovePlateSpawn(x, y);
            }

            if (sc.PositionOnBoard(x + 1, y) && 
                sc.GetPosition(x + 1, y) != null && 
                sc.GetPosition(x + 1, y).GetComponent<Chessman>().player != player && FirstMove == 0)
            {
                var good = 1;
                var pcs = board[xBoard, yBoard];
                var turn = 1;
                var oldpiece = board[x, y];
                board[xBoard, yBoard] = '.';
                board[x, y] = pcs;
                if(Char.IsUpper(pcs) == true)
                    turn = 0;
                if(IsInCheck(board, turn) == 1)
                    good = 0;
                board[x, y] = oldpiece;
                board[xBoard, yBoard] = pcs;
                if(good == 1)
                    MovePlateAttackSpawn(x + 1, y);
            }

            if (sc.PositionOnBoard(x - 1, y) &&
                sc.GetPosition(x - 1, y) != null &&
                sc.GetPosition(x - 1, y).GetComponent<Chessman>().player != player && FirstMove == 0)
            {
                var good = 1;
                var pcs = board[xBoard, yBoard];
                var turn = 1;
                var oldpiece = board[x, y];
                board[xBoard, yBoard] = '.';
                board[x, y] = pcs;
                if(Char.IsUpper(pcs) == true)
                    turn = 0;
                if(IsInCheck(board, turn) == 1)
                    good = 0;
                board[x, y] = oldpiece;
                board[xBoard, yBoard] = pcs;
                if(good == 1)
                    MovePlateAttackSpawn(x - 1, y);
            }
            if(FirstMove > 0)
            {
                    int dif = 1;
                    if(FirstMove == 2)
                        dif = -1;
                    // null pentru ca trebuie sa apesi pixel perfect
                    if(sc.GetPosition(x, y) == null && sc.GetPosition(x, y - dif) == null)
                    {
                        Debug.Log("itemul de pe pozitia"+ x + " " + (y - dif) + " este null");
                        Debug.Log(sc.GetPosition(x, y - dif));
                        if(sc.GetPosition(x, y - dif) == null)
                            Debug.Log("itemul de pe pozitia"+ x + " " + y + " este null");
                        var good = 1;
                        var pcs = board[xBoard, yBoard];
                        var turn = 1;
                        var oldpiece = board[x, y];
                        board[xBoard, yBoard] = '.';
                        board[x, y] = pcs;
                        if(Char.IsUpper(pcs) == true)
                            turn = 0;
                        if(IsInCheck(board, turn) == 1)
                            good = 0;
                        board[x, y] = oldpiece;
                        board[xBoard, yBoard] = pcs;
                        if(good == 1)
                            MovePlateSpawn(x, y);
                    }
            }
        }
    }

    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.64f;
        y *= 0.64f;

        x += -2.25f;
        y += -2.17f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.64f;
        y *= 0.64f;

        x += -2.25f;
        y += -2.17f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);


    }
}
