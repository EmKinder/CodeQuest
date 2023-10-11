using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceArray : PieceTypes
{
    [SerializeField] PieceType[] correctPieces;
    [SerializeField] PiecePlacement[] piecePlacements;
    [SerializeField] PieceType[] placedPieces;
    [SerializeField] bool checkIfRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < piecePlacements.Length; i++)
        {
            placedPieces[i] = piecePlacements[i].GetThisPieceType();
        }
        if (checkIfRight)
        {
            CheckArray();
            checkIfRight = false;
        }
    }

    bool CheckArray()
    {
        for(int i = 0; i < piecePlacements.Length; i++)
        {
            if(placedPieces[i] != correctPieces[i])
            {
                Debug.Log("Not correct!");
                return false;
            }
        }
        Debug.Log("Correct!");
        return true;
    }
    
}
