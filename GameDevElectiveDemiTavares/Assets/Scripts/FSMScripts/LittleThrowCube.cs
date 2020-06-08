using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleThrowCube : MonoBehaviour
{
    void FixedUpdate(){
        transform.Translate(new Vector3(0f, 0f, 500 * Time.fixedDeltaTime), Space.Self);
    }

}