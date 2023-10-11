using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using UnityEngine.EventSystems;


public class PlaceablePiece : PieceTypes
{
    [SerializeField] public PieceType thisPieceType;
    [SerializeField] public SpriteRenderer thisBackground;
    [SerializeField] public TMP_Text thisText;
    [SerializeField] GameObject parent;
    int stringLength;
    bool isHolding = false;
    string pieceTypeString;
    int pieceStringLength;
    // Start is called before the first frame update
    void Start()
    {
        pieceTypeString = GetTextString(thisPieceType);
        pieceStringLength = new StringInfo(pieceTypeString).LengthInTextElements;
        Debug.Log(pieceTypeString + " + " + pieceStringLength);
        thisBackground.transform.localScale = new Vector2((float)pieceStringLength/2*0.7f, 0.7f);
        thisText.rectTransform.sizeDelta = new Vector2(40 + pieceStringLength * 40, 1);
        thisText.text = pieceTypeString;
    }

    // Update is called once per frame


    public string GetTextString(PieceType piece)
    {
        string thisString = null;
        switch (piece)
        {
            case PieceType.OpenCurlyBrace:
                thisString = "{";
                break;
            case PieceType.ClosedCurlyBrace:
                thisString = "}";
                break;
            case PieceType.BoolEqual:
                thisString = "==";
                break;
            case PieceType.If:
                thisString = "if";
                break;
            case PieceType.True:
                thisString = "true";
                break;
            case PieceType.False:
                thisString = "false";
                break;
            case PieceType.Semicolon:
                thisString = ";";
                break;
            case PieceType.LeftParenthesis:
                thisString = "(";
                break;
            case PieceType.RightParenthesis:
                thisString = ")";
                break;
            case PieceType.SpinBox:
                thisString = "spinBox";
                break;
            case PieceType.ClickOnBox:
                thisString = "clickOnBox";
                break;
        }
        return thisString;
    }


}
