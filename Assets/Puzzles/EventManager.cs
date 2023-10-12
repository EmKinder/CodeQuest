using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] GameObject[] puzzles;
    bool puzzleActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
                    Instantiate(go);

                }
            }
        }
    }

    public bool GetPuzzleActive()
    {
        return puzzleActive;
    }
}
