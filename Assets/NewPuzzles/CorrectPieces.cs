using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPieces : PieceTypes
{
    public PieceType[] correctPieces;
    public PieceType[] placedPieces;
    [SerializeField] PiecePlacement[] piecePlacements;
    public CharacterMovement character;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < piecePlacements.Length; i++)
        {
            placedPieces[i] = piecePlacements[i].GetThisPieceType();
        }
    }

    public void CheckIfCorrect()
    {

        StartCoroutine(Movement());
        //  if(correctPieces[i] != placedPieces[i])
        // {
        //   Debug.Log("Incorrect!");
        // return;
        // }
        //}
        //Debug.Log("Correct!");
    }
IEnumerator Movement()
{
    for (int i = 0; i < correctPieces.Length; i++)
    {
            if (placedPieces[i] == PieceType.MoveForward)
            {
                character.MoveRight();
                yield return new WaitForSeconds(0.5f);
            }
            else if (placedPieces[i] == PieceType.MoveBackward)
            {
                character.MoveLeft();
                yield return new WaitForSeconds(0.5f);
            }
            else if (placedPieces[i] == PieceType.JumpForward)
            {
                character.JumpForward();
                yield return new WaitForSeconds(1.5f);
            }
            else if (placedPieces[i] == PieceType.JumpBackward)
            {
                character.JumpBack();
                yield return new WaitForSeconds(1.5f);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
