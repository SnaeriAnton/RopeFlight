using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private Rigidbody _rigidbody;
    private float _jointSpring = 32f;
    private float _jointDamper = 22f;
    private float _maxDistance = 0.5f;

    private SpringJoint _springJoint;
    private float _speed;

    public UnityAction<float> Moved;

    public UnityAction IsFlew;

    private void OnEnable()
    {
        _hook.IsActived += OnRigidbody;
    }

    private void OnDisable()
    {
        _hook.IsActived -= OnRigidbody;
    }

    private void Update()
    {
        MoveSpeed();
        Moved?.Invoke(_speed);
    }

    private void MoveSpeed()
    {
        _speed = _rigidbody.velocity.magnitude;
    }

    private void OnRigidbody(bool value, Vector3 position)
    {
        if (value == true)
        {
            AddSpringJoint(position);
            IsFlew?.Invoke();
        }
        else
        {
            Destroy(_springJoint);
        }
    }

    private void AddSpringJoint(Vector3 position)
    {
        _springJoint = this.gameObject.AddComponent<SpringJoint>();
        _springJoint.autoConfigureConnectedAnchor = false;
        _springJoint.connectedAnchor = position;
        _springJoint.minDistance = _maxDistance;
        _springJoint.spring = _jointSpring;
        _springJoint.damper = _jointDamper;
    }
}
