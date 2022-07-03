using UnityEngine;

public class EndSpaceCollider : MonoBehaviour {
    public GameObject frame;
    public GameObject player;

    public Canvas game;
    public Canvas win;

    // Start is called before the first frame update
    void Start() {
        win.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        FindObjectOfType<AudioManager>().Play("Win");

        (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
        (frame.GetComponent("ConstantForce") as ConstantForce).enabled = false;
        (player.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;

        game.enabled = false;
        win.enabled = true;
    }
}
