using UnityEngine;

public class EndSpaceTrigger : MonoBehaviour {
    public GameObject gameArea;
    public GameObject player;

    public Canvas game;
    public Canvas win;

    void Start() {
        win.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == player) {
            FindObjectOfType<AudioManager>().Play("SFX_Win");

            (gameArea.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
            (gameArea.GetComponent("ConstantForce") as ConstantForce).enabled = false;
            (player.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;

            game.enabled = false;
            win.enabled = true;
        }
    }
}
