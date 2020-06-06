using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemiAI : BaseAI
{
    public override IEnumerator RunAI() {
        for (int i = 0; i < 10; i++)
        {
            yield return TurnWatchoutLeft(40);
            yield return Ahead(4);
            yield return FireFront(2);

        }
    }

    public override void OnScannedRobot(ScannedRobotEvent e){
        Debug.Log("Mama is that a Cube?" + e.Name + "That far?" + e.Distance);
    }
}
