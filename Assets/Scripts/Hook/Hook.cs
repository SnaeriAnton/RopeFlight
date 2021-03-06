using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class Hook : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private RopeRenderer _ropeRenderer;
    [SerializeField] private MeshRenderer _meshrenderer;
    [SerializeField] private ParticleSystem _particleSystem;

    public UnityAction<bool, Vector3> IsActived;

    private void OnEnable()
    {
        _inputManager.Touched += OnSetPosition;
    }

    private void OnDisable()
    {
        _inputManager.Touched -= OnSetPosition;
    }

    public void ManadgerMeshRenderer(bool value)
    {
        _meshrenderer.enabled = value;
    }

    private void OnSetPosition(Vector3 position)
    {
        if (position == Vector3.zero)
        {
            _ropeRenderer.Disable();
            ManadgerMeshRenderer(false);
            IsActived?.Invoke(false, position);
        }
        else
        {
            ManadgerMeshRenderer(true);
            IsActived?.Invoke(true, position);
            _ropeRenderer.DrawRope();
            _transform.position = position;
            _particleSystem.Play();
        }
    }
}
