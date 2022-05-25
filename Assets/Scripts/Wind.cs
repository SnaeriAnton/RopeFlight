using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Player _player;

    private float _threshold = 6;
    private bool _isPlay = false;

    private void OnEnable()
    {
        _player.Moved += OnPlay;
    }

    private void OnDisable()
    {
        _player.Moved -= OnPlay;
    }

    private void OnPlay(float speed)
    {
        if (speed >= _threshold && _isPlay == false)
        {
            _particleSystem.Play();
            _isPlay = true;
        }

        if (speed <= 2 && _isPlay == true)
        {
            _particleSystem.Stop();
            _isPlay = false;
        }
    }
}
