using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherAI : BaseAI
{
    public override IEnumerator RunAI() {
        while (true)
        {
            yield return TurnLeft(150);
            yield return Ahead(20);
        }
    }

    public override void OnScannedRobot(ScannedRobotEvent e){
    }
}
