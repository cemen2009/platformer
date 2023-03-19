using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 temporaryPosition;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        // changing X position of cameraa according to player X position
        temporaryPosition = this.transform.position;
        temporaryPosition.x = playerTransform.position.x;
        this.transform.position = temporaryPosition;
    }
}
