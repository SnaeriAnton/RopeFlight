using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField] private Transform _transformPlayer;
    [SerializeField] private Transform _transform;

    private float _speed = 2f;
    private float _offsetY = -0.9f;

    private void Update()
    {
        Track();
    }

    private void Track()
    {
        Vector3 _tragetPosition = new Vector3(_transform.position.x, _transformPlayer.position.y - _offsetY, _transform.position.z);
        _transform.position = Vector3.Lerp(transform.position, _tragetPosition, _speed * Time.deltaTime);
        _transform.position = new Vector3(_transformPlayer.position.x - 2.57f, _transform.position.y, _transform.position.z);
    }
}
