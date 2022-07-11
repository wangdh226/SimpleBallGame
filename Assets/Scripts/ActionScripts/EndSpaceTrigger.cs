using System;
using UnityEngine;

public class EndSpaceTrigger : MonoBehaviour {
    public GameObject gameArea;
    public GameObject player;

    private Canvas game;
    private Canvas win;

    void Start() {
        game = GameObject.Find("Canvas - Game").GetComponent<Canvas>();
        win = GameObject.Find("Canvas - Win").GetComponent<Canvas>();

        game.enabled = true;
        win.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            (gameArea.GetComponent<Rigidbody>() as Rigidbody).isKinematic = true;
            (gameArea.GetComponent<ConstantForce>() as ConstantForce).enabled = false;
            (player.GetComponent<Rigidbody>() as Rigidbody).isKinematic = true;

            game.enabled = false;
            win.enabled = true;
            try {
                FindObjectOfType<AudioManager>().Play("SFX_Win");
            } catch (Exception e) {
                Debug.Log("could not find Audiomanager - " + e.ToString());
            }
        }
    }
}
