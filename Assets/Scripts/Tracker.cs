using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField] private Transform _transformPlayer;
    [SerializeField] private Transform _transform;

    private void LateUpdate()
    {
        _transform.position = new Vector3(_transformPlayer.position.x, 1, _transform.position.z );
    }
}
