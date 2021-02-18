using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform _playerTransform;
    /// <summary>
    /// automatically moves camera in z by offset to look directly at Player
    /// parametrization by camera's y position and x rotation in (0,90)
    /// </summary>
    private float _zOffset;
    private void Awake()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject == null) Debug.LogWarning("Camera couldn't find object with \"Player\" tag in the scene to follow.");
        else
        {
            _playerTransform = playerObject.transform;
            float xAngle = transform.rotation.eulerAngles.x * (2 * Mathf.PI) / 360;
            float ctan = 1 / Mathf.Tan(xAngle);
            if (float.IsInfinity(ctan)) 
                _zOffset = 0f;
            else 
                _zOffset = -transform.position.y * ctan;
            //Debug.Log($"K¹t w osi x: {xAngle}");
        }
    }
    
    void LateUpdate()
    {
        if (_playerTransform != null) Follow(_playerTransform);
    }

    private void Follow(Transform playerTransform)
    {
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z + _zOffset);
    }
}
