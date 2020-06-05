using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannedRobotEvent {
    public string Name;
    public float Distance; 
}
public class BaseAI
{
     public PlayerController Player = null;

    // Events
    public virtual void OnScannedRobot(ScannedRobotEvent e)
    {
        // 
    }

    public IEnumerator Ahead(float distance) {
        yield return Player.__Ahead(distance);
    }

    public IEnumerator Back(float distance) {
        yield return Player.__Back(distance);
    }

    public IEnumerator TurnWatchoutLeft(float angle) {
        yield return Player.__TurnWatchoutLeft(angle);
    }

    public IEnumerator TurnWatchoutRight(float angle) {
        yield return Player.__TurnWatchoutRight(angle);
    }

    public IEnumerator TurnLeft(float angle) {
        yield return Player.__TurnLeft(angle);
    }

    public IEnumerator TurnRight(float angle) {
        yield return Player.__TurnRight(angle);
    }

    public IEnumerator FireFront(float power) {
        yield return Player.__FireFront(power);
    }

    public IEnumerator FireLeft(float power) {
        yield return Player.__FireLeft(power);
    }

    public IEnumerator FireRight(float power) {
        yield return Player.__FireRight(power);
    }

    public virtual IEnumerator RunAI() {
        yield return null;
    }
}
