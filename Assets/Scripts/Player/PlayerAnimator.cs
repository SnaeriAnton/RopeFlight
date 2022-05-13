using RootMotion.Dynamics;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _player;
    [SerializeField] private PuppetMaster _puppetMaster;

    private void OnEnable()
    {
        _player.IsFlew += OnDisableAnimator;
    }

    private void OnDisableAnimator()
    {
        _animator.enabled = false;
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = false;
        }
        _rigidbody.isKinematic = false;
        _puppetMaster.enabled = true;
        _player.IsFlew -= OnDisableAnimator;
    }
}
