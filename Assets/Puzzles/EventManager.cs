using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] GameObject[] puzzles;
    bool puzzleActive = false;
    GameObject activePuzzle;
    bool puzzleSuccess = false;
    string activePuzzleName;
    Canvas instructionText;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("InstructionText"))
        {
            instructionText = GameObject.FindGameObjectWithTag("InstructionText").GetComponent<Canvas>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPuzzle(string name)
    {
        if (!puzzleActive)
        {
            foreach (GameObject go in puzzles)
            {
                if (go.name == name)
                {
                   activePuzzleName = name;
                   activePuzzle = (GameObject)Instantiate(go);
                   //Instantiate(activePuzzle);
                   puzzleActive = true;
                   if(instructionText != null)
                    {
                        instructionText.enabled = false;
                    }
 
                }
            }
        }
    }

    public bool GetPuzzleActive()
    {
        return puzzleActive;
    }

    public bool GetLastPuzzleSuccess()
    {
        return puzzleSuccess;
    }

    public string GetPuzzleActiveName()
    {
        return activePuzzleName; 
    }

    public void SetPuzzleActiveName(string name)
    {
        activePuzzleName = name;
    }
    public void SetLastPuzzleSuccess(bool success)
    {
        puzzleSuccess = success;
    }

    public void EndPuzzle()
    {
        puzzleSuccess = true;
        puzzleActive = false;
        DestroyImmediate(activePuzzle, true);
        activePuzzle = null;

    }
}
