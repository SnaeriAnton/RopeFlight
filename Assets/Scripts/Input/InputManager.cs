using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _hookObject;
    [SerializeField] private Hook _hook;

    private float _maxDistanceRay = 10000000000000;
    private float _distanceFromCamera = 10f;
    private bool _foliage = false;
    private Vector3 _screenWorldPosition;

    public UnityAction<Vector3> IsTouch;

    private void Update()
    {         
        _screenWorldPosition = GetScreenPoistion();


        if (Input.GetMouseButtonDown(0))
        {
            Touch();
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsTouch?.Invoke(Vector3.zero);
            _hook.ManadgerMeshRenderer(false);
            //_hookObject.SetActive(false);
        }

        if (_foliage == true)
        {
            //_hookObject.SetActive(true);
            _hook.ManadgerMeshRenderer(true);
            IsTouch?.Invoke(_screenWorldPosition);
            _foliage = false;
        }
    }

    private Vector3 GetScreenPoistion()
    {
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distanceFromCamera);
        Vector3 screenWorldPosition = _camera.ScreenToWorldPoint(screenPosition);
        return screenWorldPosition;
    }

    private void Touch()
    {
        _foliage = Physics.Raycast(_camera.transform.position, _camera.ScreenPointToRay(Input.mousePosition).direction, _maxDistanceRay, _layerMask);
    }
}
