
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPosition : MonoBehaviour
{


    public Transform positionOfFollowObj;

    // Update is called once per frame
    void Update()
    {
        transform.position = positionOfFollowObj.position + new Vector3(0f,12f,0f);
    }
}