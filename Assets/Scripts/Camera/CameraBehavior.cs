using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 temporaryPosition;
    private float clampX = 46f;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        // changing X position of cameraa according to player X position
        temporaryPosition = this.transform.position;
        temporaryPosition.x = Mathf.Clamp(playerTransform.position.x, -clampX, clampX);
        this.transform.position = temporaryPosition;
    }
}
