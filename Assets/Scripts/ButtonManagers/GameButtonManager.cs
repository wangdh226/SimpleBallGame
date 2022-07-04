using UnityEngine;

public class GameButtonManager : MonoBehaviour {
    public GameObject frame;
    public GameObject player;

    public Canvas game;
    public Canvas options;
    public Canvas menu;
    public Canvas win;

    private Rigidbody frameRigidbody;
    private ConstantForce frameConstantForce;
    private Rigidbody playerRigidbody;

    void Start() {
        game.enabled = true;
        options.enabled = false;
        menu.enabled = false;
        win.enabled = false;

        frameRigidbody = frame.GetComponent("Rigidbody") as Rigidbody;
        frameConstantForce = frame.GetComponent("ConstantForce") as ConstantForce;
        playerRigidbody = player.GetComponent("Rigidbody") as Rigidbody;
    }

    /* Button functionality implementations
     */
    public void Freeze() {
        frameRigidbody.isKinematic = true;
        frameConstantForce.enabled = false;
    }
    
    public void RotateCW() {
        frameRigidbody.isKinematic = false;
        frameConstantForce.enabled = true;
        frameConstantForce.relativeTorque = new Vector3(0.0f, 0.0f, -10.0f);
    }
    
    public void RotateCCW() {
        frameRigidbody.isKinematic = false;
        frameConstantForce.enabled = true;
        frameConstantForce.relativeTorque = new Vector3(0.0f, 0.0f, 10.0f);
    }
    
    /* Methods for opening/closing menus
     */
    public void OpenMenu() {
        frameRigidbody.isKinematic = true;
        frameConstantForce.enabled = false;
        playerRigidbody.isKinematic = true;
        game.enabled = false;
        menu.enabled = true;
        options.enabled = false;
    }
    
    public void OpenOptions() {
        frameRigidbody.isKinematic = true;
        frameConstantForce.enabled = false;
        playerRigidbody.isKinematic = true;
        game.enabled = false;
        menu.enabled = false;
        options.enabled = true;
    }
    
    public void ExitMenu() {
        frameRigidbody.isKinematic = false;
        frameConstantForce.enabled = true;
        playerRigidbody.isKinematic = false;
        game.enabled = true;
        menu.enabled = false;
        options.enabled = false;
    }
}
