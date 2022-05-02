using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hook : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private HookRenderer _renderer;
    [SerializeField] private MeshRenderer _meshrenderer;

    public UnityAction<bool, Vector3> IsActived;

    private void OnEnable()
    {
        _inputManager.IsTouch += OnSetPosition;
    }

    private void OnDisable()
    {
        _inputManager.IsTouch -= OnSetPosition;
    }

    public void ManadgerMeshRenderer(bool value)
    {
        _meshrenderer.enabled = value;
    }

    private void OnSetPosition(Vector3 position)
    {
        if (position == Vector3.zero)
        {
            _renderer.Disable();
            IsActived?.Invoke(false, position);
        }
        else
        {
            IsActived?.Invoke(true, position);
            _renderer.DrawRope();
            _transform.position = position;
        }
    }
}
