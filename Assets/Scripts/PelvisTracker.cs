using UnityEngine;

public class PelvisTracker : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _transformPelvis;

    private void Update()
    {
        _transform.position = _transformPelvis.position;
    }
}
