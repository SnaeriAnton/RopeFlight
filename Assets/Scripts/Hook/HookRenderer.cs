using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRenderer : MonoBehaviour
{
    [SerializeField] private Transform _transformPlayer;
    [SerializeField] private Transform _transform;
    [SerializeField] private LineRenderer _lineRenderer;

    private bool _isDrawing = false;

    public void DrawRope()
    {
        _isDrawing = true;
        _lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        if (_isDrawing == true)
        {
            _lineRenderer.SetPosition(0, _transformPlayer.position);
            _lineRenderer.SetPosition(1, _transform.position);
        }
    }

    public void Disable()
    {
        _isDrawing = false;
        _lineRenderer.positionCount = 0;
    }
}
