using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    Button btn;
    public GameObject thisPiece;
    void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(CreatePuzzlePiece);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePuzzlePiece()
    {
        Instantiate(thisPiece, new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10.0f), Quaternion.identity);
    }
}
