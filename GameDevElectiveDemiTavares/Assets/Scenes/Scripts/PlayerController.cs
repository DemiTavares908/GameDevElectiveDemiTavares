using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Bumper = null;
    private BaseAI ai = null;
    public GameObject LittleThrowCube = null;
    public Transform CubeFrontSpawnPoint = null;
    public Transform CubeLeftSpawnPoint = null;
    public Transform CubeRightSpawnPoint = null;
    public GameObject Watchout = null;
    
    private float PlayerSpeed = 50.0f;
    private float RotationSpeed = 150.0f;
    private float FloorSize = 500.0f;

    public void SetAI(BaseAI _ai){
        ai = ai;
        ai.Player = this;
    }

    public void StartFight(){
        Debug.Log("Are you working?");
        StartCoroutine(ai.RunAI());
    }

    void OnTriggerStay(Collider other){
        if(other.tag =="Player") {
            ScannedRobotEvent scannedRobotEvent = new ScannedRobotEvent();
            scannedRobotEvent.Distance = Vector3.Distance(transform.position, other.transform.position);
            scannedRobotEvent.Name = other.name;
            ai.OnScannedRobot(scannedRobotEvent);
        }
    }

    public IEnumerator __Ahead(float distance) {
        int numFrames = (int)(distance / PlayerSpeed * Time.fixedDeltaTime);
        for (int f = 0; f < numFrames; f++) {
            transform.Translate(new Vector3(0f, 0f, PlayerSpeed * Time.fixedDeltaTime), Space.Self);
            Vector3 clampedPosition = Vector3.Max(Vector3.Min(transform.position, new Vector3(FloorSize, 0, FloorSize)), new Vector3(-FloorSize, 0, -FloorSize));
            transform.position = clampedPosition;

            yield return new WaitForFixedUpdate();            
        }
    }

    public IEnumerator __Back(float distance) {
        int numFrames = (int)(distance / PlayerSpeed * Time.fixedDeltaTime);
        for (int f = 0; f < numFrames; f++) {
            transform.Translate(new Vector3(0f, 0f, -PlayerSpeed * Time.fixedDeltaTime), Space.Self);
            Vector3 clampedPosition = Vector3.Max(Vector3.Min(transform.position, new Vector3(FloorSize, 0, FloorSize)), new Vector3(-FloorSize, 0, -FloorSize));
            transform.position = clampedPosition;

            yield return new WaitForFixedUpdate();            
        }
    }

    public IEnumerator __TurnLeft(float angle) {
        int numFrames = (int)(angle / (RotationSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++) {
            transform.Rotate(0f, -RotationSpeed * Time.fixedDeltaTime, 0f);

            yield return new WaitForFixedUpdate();            
        }
    }

    public IEnumerator __TurnRight(float angle) {
        int numFrames = (int)(angle / (RotationSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++) {
            transform.Rotate(0f, RotationSpeed * Time.fixedDeltaTime, 0f);

            yield return new WaitForFixedUpdate();            
        }
    }

    public IEnumerator __DoNothing() {
        yield return new WaitForFixedUpdate();
    }

    public IEnumerator __FireFront(float power) {
        GameObject newInstance = Instantiate(LittleThrowCube, CubeFrontSpawnPoint.position, CubeFrontSpawnPoint.rotation);
        yield return new WaitForFixedUpdate();
    }

    public IEnumerator __FireLeft(float power) {
        GameObject newInstance = Instantiate(LittleThrowCube, CubeLeftSpawnPoint.position, CubeLeftSpawnPoint.rotation);
        yield return new WaitForFixedUpdate();
    }

    public IEnumerator __FireRight(float power) {
        GameObject newInstance = Instantiate(LittleThrowCube, CubeRightSpawnPoint.position, CubeRightSpawnPoint.rotation);
        yield return new WaitForFixedUpdate();
    }

    public IEnumerator __TurnWatchoutLeft(float angle) {
        int numFrames = (int)(angle / (RotationSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++) {
            Watchout.transform.Rotate(0f, -RotationSpeed * Time.fixedDeltaTime, 0f);

            yield return new WaitForFixedUpdate();            
        }
    }

    public IEnumerator __TurnWatchoutRight(float angle) {
        int numFrames = (int)(angle / (RotationSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++) {
            Watchout.transform.Rotate(0f, RotationSpeed * Time.fixedDeltaTime, 0f);

            yield return new WaitForFixedUpdate();            
        }
    }
}
