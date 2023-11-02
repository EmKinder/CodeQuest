using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Piece : PieceTypes
{
    // public PieceTypes thisPiece;
    [SerializeField] public PieceType thisPieceType;
    bool isHolding = true;
    //[SerializeField] public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("PuzzleCanvas").transform);
        this.gameObject.GetComponentInChildren<Canvas>().overrideSorting = true;
    }

    // Update is called once per frame
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
        return thisPieceType;
    }
}
