using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _xAxisInput;
    private float _zAxisInput;
    [SerializeField]
    private float _speed;
    private Camera _mainCamera;
    private Plane _groundPlane;
    private Vector3 _lookAtPoint;
    public Vector3 LookAtPoint { get => _lookAtPoint; }
    public Vector3 ShootAtPoint { get; set; }

    private void Awake()
    {
        _mainCamera = Camera.main;
        GameObject ground = GameObject.Find("GroundPlane");
        if (ground != null)
            _groundPlane = new Plane(ground.transform.up, ground.transform.position);
        else
        {
            Debug.LogWarning("Couldn't find \"GroundPlane\" object.");
            _groundPlane = new Plane(Vector3.up, Vector3.zero);
        }
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        Ray r = _mainCamera.ScreenPointToRay(Input.mousePosition);
        _groundPlane.Raycast(r, out float distance);
        Vector3 temp = r.GetPoint(distance);
        ShootAtPoint = temp;
        temp.y = transform.position.y;
        _lookAtPoint = temp;
        transform.LookAt(LookAtPoint);
    }

    private void MovePlayer()
    {
        _xAxisInput = Input.GetAxis("Horizontal");
        _zAxisInput = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(_xAxisInput, 0f, _zAxisInput).normalized * _speed * Time.deltaTime;
    }
}
