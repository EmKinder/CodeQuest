using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceTypes: MonoBehaviour
{
    public enum PieceType
    {
        Null,
        OpenCurlyBrace,
        ClosedCurlyBrace,
        BoolEqual,
        If,
        ElseIf,
        True,
        False,
        Semicolon,
        LeftParenthesis,
        RightParenthesis,
        SpinBox,
        ClickOnBox,
        PressW, 
        PressA,
        PressS,
        PressD,
        MoveLeft, 
        MoveRight
    }

}
