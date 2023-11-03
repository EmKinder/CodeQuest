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
    [SerializeField] private StarsCollected stars;
    bool level3FirstMoveCorrect = false;
    bool level3SecondMoveCorrect = false;
    Vector3 cameraStartPos;
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
        stars.SetLevelAttempts();
        StartCoroutine(Movement());


    }
    IEnumerator Movement()
    {
        for (int i = 0; i < correctPieces.Length; i++)
        {
            if (stars.GetStarsCollected() == 2)
            {
                //cameraStartPos = Camera.main.transform.position;
                if (i == 0 && placedPieces[i] == PieceType.MoveForward)
                    level3FirstMoveCorrect = true;
                if (i == 1 && placedPieces[i] == PieceType.MoveForward && level3FirstMoveCorrect)
                {
                    level3SecondMoveCorrect = true;
                }

            }
            if (placedPieces[i] == PieceType.MoveForward)
            {
                character.MoveRight();
                yield return new WaitForSeconds(0.5f);
                if (level3SecondMoveCorrect)
                {
                    character.DropDown();
                    yield return new WaitForSeconds(2.0f);
                    level3SecondMoveCorrect = false;
                }
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
            Debug.Log(placedPieces[i]);
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
                // Camera.main.transform.position = cameraStartPos;
                if (stars.GetStarsCollected() == 2)
                {
                    float cameraZ = Camera.main.transform.position.z;
                    Camera.main.transform.position = new Vector3(startPos.x, 0.0f, cameraZ);
                    //Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, cameraZ);
                }
                //  RemoveAllPieces();
                return;
            }
        }
        Debug.Log("Correct!");
        stars.SetStarsCollected();
        int thisStars = stars.GetStarsCollected();
        if (thisStars == 1)
        {
            StartCoroutine(character.LevelOneFin());
        }
        else if (thisStars == 2)
        {
            StartCoroutine(character.LevelTwoFin());
        }
        else if (thisStars == 3)
        {
            StartCoroutine(character.LevelThreeFin());
        }

        RemoveAllPieces();
        UpdatePuzzle(thisStars);
        Camera.main.transform.position = cameraStartPos;



    }

    public void RemoveAllPieces()
    {
        GameObject[] piecesInScene = GameObject.FindGameObjectsWithTag("Piece");
        foreach (GameObject go in piecesInScene)
            Destroy(go);
        for (int i = 0; i < placedPieces.Length; i++)
            placedPieces[i] = PieceType.Null;
    }

    void UpdatePuzzle(int num)
    {
        if (num == 1)
        {
            correctPieces[0] = PieceType.MoveForward;
            correctPieces[1] = PieceType.MoveForward;
            correctPieces[2] = PieceType.JumpForward;
            correctPieces[3] = PieceType.JumpForward;
            correctPieces[4] = PieceType.MoveForward;
            correctPieces[5] = PieceType.MoveForward;
        }
        else if (num == 2)
        {
            correctPieces[0] = PieceType.MoveForward;
            correctPieces[1] = PieceType.MoveForward;
            correctPieces[2] = PieceType.JumpBackward;
            correctPieces[3] = PieceType.JumpBackward;
            correctPieces[4] = PieceType.MoveBackward;
            correctPieces[5] = PieceType.MoveBackward;
        }
    }
}
