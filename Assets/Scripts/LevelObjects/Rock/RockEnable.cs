using UnityEngine;

public class RockEnable : MonoBehaviour
{
    [SerializeField] private Rock _rock;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _rock.enabled = true;
        }
    }
}
