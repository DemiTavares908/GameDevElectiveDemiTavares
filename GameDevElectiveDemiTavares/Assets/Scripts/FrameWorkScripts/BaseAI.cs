using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannedRobotEvent {
    public string Name;
    public float Distance; 
}
public class BaseAI
{
     public PlayerController Play = null;

    // Events
    public virtual void OnScannedRobot(ScannedRobotEvent e)
    {
        // 
    }

    public IEnumerator Ahead(float distance) {
        yield return Play.__Ahead(distance);
    }

    public IEnumerator Back(float distance) {
        yield return Play.__Back(distance);
    }

    public IEnumerator TurnWatchoutLeft(float angle) {
        yield return Play.__TurnWatchoutLeft(angle);
    }

    public IEnumerator TurnWatchoutRight(float angle) {
        yield return Play.__TurnWatchoutRight(angle);
    }

    public IEnumerator TurnLeft(float angle) {
        yield return Play.__TurnLeft(angle);
    }

    public IEnumerator TurnRight(float angle) {
        yield return Play.__TurnRight(angle);
    }

    public IEnumerator FireFront(float power) {
        yield return Play.__FireFront(power);
    }

    public IEnumerator FireLeft(float power) {
        yield return Play.__FireLeft(power);
    }

    public IEnumerator FireRight(float power) {
        yield return Play.__FireRight(power);
    }

    public virtual IEnumerator RunAI() {
        yield return null;
    }
}
