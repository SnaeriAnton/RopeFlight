using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Finger : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Image _image;
    [SerializeField] private InputManager _inputManager;

    private Vector3 _defaultPosition;

    private void OnEnable()
    {
        _inputManager.FingerTouched += OnSetPosition;
        _defaultPosition = _transform.position;
    }

    private void OnDisable()
    {
        _inputManager.FingerTouched -= OnSetPosition;
    }

    private void OnSetPosition(Vector3 position)
    {
        if (position == Vector3.zero)
        {
            ManagerSpriteRenderer(false);
        }
        else
        {
            ManagerSpriteRenderer(true);
            _transform.position = new Vector3(position.x, position.y, _defaultPosition.z);
        }
    }

    private void ManagerSpriteRenderer(bool value)
    {
        _image.enabled = value;
    }
}
