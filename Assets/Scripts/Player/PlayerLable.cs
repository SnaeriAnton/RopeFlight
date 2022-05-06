using UnityEngine;

public class PlayerLable : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private Quaternion _defaultRotatio;

    private void Start()
    {
        _defaultRotatio = _transform.rotation;
    }

    private void Update()
    {
        _transform.rotation = _defaultRotatio;
    }
}
