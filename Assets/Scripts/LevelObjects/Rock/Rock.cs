using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Rock : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private ParticleSystem _particleSystem;

    private float _speedPosition = 10f;
    private float _speedRotation = 30f;
    private float _offsetPositionX = 9f;
    private float _offsetPositionY = 10f;
    private float _offsetPosition = 4f;

    private void Start()
    {
        _meshRenderer.enabled = true;
        _particleSystem.Play();
    }
    private void Update()
    {
        MoveTowrads();
        Rotate();
    }

    private void MoveTowrads()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, new Vector3(_transform.position.x + _offsetPositionX, _transform.position.y + _offsetPositionY, 0), _speedPosition * Time.deltaTime);
    }

    private void Rotate()
    {
        _transform.Rotate(new Vector3(_transform.position.x + _offsetPosition, _transform.position.y + _offsetPosition, _transform.position.z + _offsetPosition) * _speedRotation * Time.deltaTime);
    }
}
