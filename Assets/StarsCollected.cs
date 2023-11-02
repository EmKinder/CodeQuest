using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsCollected : MonoBehaviour
{
    int num;
    int levelAttempts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStarsCollected()
    {
        num++;
    }

    public int GetStarsCollected()
    {
        return num;
    }

    public void SetLevelAttempts()
    {
        levelAttempts++;
    }

    public int GetLevelAttempts()
    {
        return levelAttempts;
    }
}
