using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Camera _camera;

    private float _maxDistanceRay = 10000000000000;
    private float _distanceFromCamera = 7.7f;
    private bool _foliage = false;
    private Vector3 _screenWorldPosition;
    private Vector3 _mousePosition;
    private RaycastHit _raycastHit;

    public UnityAction<Vector3> Touched;
    public UnityAction<Vector3> FingerTouched;
    public UnityAction<bool> Test;

    private void Update()
    {
        _screenWorldPosition = GetScreenPoistion();

        if (Input.GetMouseButtonDown(0))
        {
            Touch();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Touched?.Invoke(Vector3.zero);
            FingerTouched?.Invoke(Vector3.zero);
        }

        if (_foliage == true)
        {
            Touched?.Invoke(SetNewPosition());
            FingerTouched?.Invoke(_mousePosition);
            _foliage = false;
        }
    }

    private Vector3 GetScreenPoistion()
    {
        Vector3 screenPosition = GetMousePosition();
        Vector3 screenWorldPosition = _camera.ScreenToWorldPoint(screenPosition);
        return screenWorldPosition;
    }

    private Vector3 SetNewPosition()
    {
        Vector3 newPosition = new Vector3(_screenWorldPosition.x, _screenWorldPosition.y, _raycastHit.point.z);
        return newPosition;
    }

    private void Touch()
    {
        _foliage = Physics.Raycast(_camera.transform.position, _camera.ScreenPointToRay(Input.mousePosition).direction, out _raycastHit, _maxDistanceRay, _layerMask);
    }

    private Vector3 GetMousePosition()
    {
        _mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distanceFromCamera);
        return _mousePosition;
    }
}
