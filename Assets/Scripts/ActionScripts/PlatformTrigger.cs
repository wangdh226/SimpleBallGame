using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public Animator triggerPlatform;
    public GameObject player;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            triggerPlatform.SetTrigger("Start");
        }
    }
}
