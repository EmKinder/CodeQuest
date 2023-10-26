using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPieces : PieceTypes
{
    public PieceType[] correctPieces;
    public PieceType[] placedPieces;
    [SerializeField] PiecePlacement[] piecePlacements;
    public CharacterMovement character;
    Vector3 startPos;
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
        startPos = character.GetStartPos();
        StartCoroutine(Movement());


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
        IfGoBack();
    }

    void IfGoBack()
    {
        
        for (int i = 0; i < correctPieces.Length; i++)
        {
            if (correctPieces[i] != placedPieces[i])
            {
                Debug.Log("Incorrect!");
                character.transform.position = startPos;
                RemoveAllPieces();
                return;
            }
        }
        Debug.Log("Correct!");
        StartCoroutine(character.LevelOneFin());
        RemoveAllPieces();

    }

    public void RemoveAllPieces()
    {
        GameObject[] piecesInScene = GameObject.FindGameObjectsWithTag("Piece");
        foreach (GameObject go in piecesInScene)
            Destroy(go);
        for(int i = 0; i < placedPieces.Length; i++)
            placedPieces[i] = PieceType.Null;
    }
}
