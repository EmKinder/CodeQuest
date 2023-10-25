using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    Tween activeTween;
   // public CharacterMovement character;
    // Start is called before the first frame update
     public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
        {
            if (activeTween == null)
            {
                activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
            }
        }

    private void Update()
    {
        if (activeTween != null)
        {
            if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.1f)
            {
                float timeFraction = (Time.time - activeTween.StartTime) / activeTween.Duration;
                timeFraction = Mathf.Pow(timeFraction, 3);
                activeTween.Target.position = Vector3.Lerp(activeTween.StartPos,
                                                          activeTween.EndPos,
                                                           timeFraction);
                // character.movementSqrMagnitude = 1.0f;
            }
            else
            {
                activeTween.Target.position = activeTween.EndPos;
                activeTween = null;
                //character.movementSqrMagnitude = 0.0f;
            }
        }
    }

    public bool HasActiveTween()
    {
        if (activeTween != null)
            return true;
        return false;
    }
}
