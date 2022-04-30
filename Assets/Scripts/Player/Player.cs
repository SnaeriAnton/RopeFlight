using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private float _jointSpring = 30f;
    [SerializeField] private float _jointDamper = 9f;
    [SerializeField] private float _maxDistance = 2.5f;

    private SpringJoint _springJoint;

    private void OnEnable()
    {
        _hook.IsActived += OnRigidbody;
    }

    private void OnDisable()
    {
        _hook.IsActived -= OnRigidbody;
    }

    private void OnRigidbody(bool value, Vector3 position)
    {
        if (value == true)
        {
            AddSpringJoint(position);
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

        //_springJoint.maxDistance = _maxDistance;
        _springJoint.minDistance = _maxDistance;
        _springJoint.spring = _jointSpring;
        _springJoint.damper = _jointDamper;
    }
}
