using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SplineMesh;

public class RopeRenderer : MonoBehaviour
{
    [SerializeField] private Spline _spline;
    [SerializeField] private Transform _transformPlayer;
    [SerializeField] private Transform _transform;
    [SerializeField] private GameObject _rope;

    private bool _isDrawing = false;

    public void DrawRope()
    {
        _rope.SetActive(true);
        _isDrawing = true;
    }

    private void LateUpdate()
    {
        if (_isDrawing == true)
        {
            _spline.nodes[0].Position = _transformPlayer.position;
            _spline.nodes[1].Position = _transform.position;
        }
    }

    public void Disable()
    {
        _rope.SetActive(false);
        _isDrawing = false;
    }
}
