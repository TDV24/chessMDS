using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiecesTaken : MonoBehaviour
{
    int blackPawns = 0;
    int blackRooks = 0;
    int blackKnights = 0;
    int blackBishops = 0;
    int blackQueen = 0;
    int blackKing = 0; 
    int whitePawns = 0;
    int whiteRooks = 0;
    int whiteKnights = 0;
    int whiteBishops = 0;
    int whiteQueen = 0;
    int whiteKing = 0;
    public Text BlackPiecesTaken;
    public Text WhitePiecesTaken;
    // Start is called before the first frame update
    void Start()
    {
        blackPawns = 0;
        blackRooks = 0;
        blackKnights = 0;
        blackBishops = 0;
        blackQueen = 0;
        blackKing = 0;
        whitePawns = 0;
        whiteRooks = 0;
        whiteKnights = 0;
        whiteBishops = 0;
        whiteQueen = 0;
        whiteKing = 0;
    }

    // Update is called once per frame
    public void TextWritePiecesTaken(string PieceName)
    {
        if (PieceName == "blackPawn")
            blackPawns++;
        else if (PieceName == "blackRook")
            blackRooks++;
        else if (PieceName == "blackKnight")
            blackKnights++;
        else if (PieceName == "blackBishop")
            blackBishops++;
        else if (PieceName == "blackQueen")
            blackQueen++;
        else if (PieceName == "blackKing")
            blackKing++;
        else if (PieceName == "whitePawn")
            whitePawns++;
        else if (PieceName == "whiteRook")
            whiteRooks++;
        else if (PieceName == "whiteKnight")
            whiteKnights++;
        else if (PieceName == "whiteBishop")
            whiteBishops++;
        else if (PieceName == "whiteQueen")
            whiteQueen++;
        else if (PieceName == "whiteKing")
            whiteKing++;
        BlackPiecesTaken.text = "Black Pieces Taken\n\n" + "Pawns: " + blackPawns.ToString() + "\nRooks: " + blackRooks.ToString() + "\nKnights: " + blackKnights.ToString() + "\nBishops: " +
            blackBishops.ToString() + "\nQueen: " + blackQueen.ToString() + "\nKing: " + blackKing.ToString(); // afisam piesele luate de alb
        WhitePiecesTaken.text = "White Pieces Taken\n\n" + "Pawns: " + whitePawns.ToString() + "\nRooks: " + whiteRooks.ToString() + "\nKnights: " + whiteKnights.ToString() + "\nBishops: " +
            whiteBishops.ToString() + "\nQueen: " + whiteQueen.ToString() + "\nKing: " + whiteKing.ToString(); // afisam piesele luate de negru
    }
}
