using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PieceArray : PieceTypes
{
    [SerializeField] PieceType[] correctPieces;
    [SerializeField] PiecePlacement[] piecePlacements;
    [SerializeField] PieceType[] placedPieces;
    [SerializeField] bool checkIfRight;
    EventManager eventManager;
    bool puzzleFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!puzzleFinished)
        {
            for (int i = 0; i < piecePlacements.Length; i++)
            {
                placedPieces[i] = piecePlacements[i].GetThisPieceType();
            }
            if (checkIfRight)
            {
                CheckArray();
                checkIfRight = false;
            }
        }
    }

    public void CheckArray()
    {
        for(int i = 0; i < piecePlacements.Length; i++)
        {
            if(placedPieces[i] != correctPieces[i])
            {
                Debug.Log("Not correct!");
                return;
            }
        }
        Debug.Log("Correct!");
        puzzleFinished = true;
        eventManager.SetLastPuzzleSuccess(true);
        eventManager.EndPuzzle();
    }

    public void test()
    {

    }
    
}
