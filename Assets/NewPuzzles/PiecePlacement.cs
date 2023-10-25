using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlacement : PieceTypes
{
    [SerializeField] public PieceType thisPieceType;
    [SerializeField] PieceType placedPiece = PieceType.Null;
    bool sizeChanged = false;
    bool normalSize = true;
    bool blockOccupied = false;
    Piece thisBlock;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Piece")
        {
            if (!blockOccupied)
            {
                // Debug.Log("Triggering");
                thisBlock = other.gameObject.GetComponent<Piece>();
                if (!thisBlock.getIsHolding())
                {
                    other.gameObject.transform.position = this.gameObject.transform.position;
                    placedPiece = thisBlock.getPieceType();
                    Debug.Log(placedPiece);
                    blockOccupied = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Piece" && blockOccupied)
        {
            {
                thisBlock = other.gameObject.GetComponent<Piece>();
                {
                    if (thisBlock.getPieceType() == placedPiece)
                    {
                        blockOccupied = false;
                        placedPiece = PieceType.Null;
                    }
                }
            }
        }
    }

    public PieceType GetThisPieceType()
    {
        return placedPiece;
    }
}
