using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField]
    Image _fill;
    Camera _mainCamera;

    private void Awake()
    {
        GetComponentInParent<PlayerStats>().OnHPDrop += UpdateFill;
        _mainCamera = Camera.main;
    }

    private void UpdateFill(float pct)
    {
        _fill.fillAmount = Mathf.Clamp(pct, 0, 1);
    }

    private void LateUpdate()
    {
        transform.LookAt(_mainCamera.transform);
    }
}
