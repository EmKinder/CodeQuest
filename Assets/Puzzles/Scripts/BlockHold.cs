using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockHold : PieceTypes
{
    // Start is called before the first frame update
    bool isHolding = false;
    [SerializeField] PlaceablePiece thisPiece;
    PieceType thisPieceType;
    TextMeshPro thisText;
    Color thisColour;

    void Start()
    {
        this.gameObject.GetComponent<BoxCollider2D>().size /= 4;
    }

    void Update()
    {
        if (isHolding)
        {
            this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10.0f));

        }

    }

    private void OnMouseDown()
    {
        if (!isHolding)
            isHolding = true;
        else
            isHolding = false;
    }

    public bool getIsHolding()
    {
        return isHolding;
    }

    public PieceType getPieceType()
    {
        //Debug.Log(thisPiece.thisPieceType);
        return thisPiece.thisPieceType;
    }

    public string getText()
    {
        return thisPiece.thisText.text;
    }

    public Color getColor()
    {
        return thisPiece.thisBackground.color;
    }

}
