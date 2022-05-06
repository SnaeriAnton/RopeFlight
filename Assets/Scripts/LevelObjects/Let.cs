using UnityEngine;

public class Let : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;

    private void Start()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    private void EnableRotation()
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            EnableRotation();
        }
    }
}
