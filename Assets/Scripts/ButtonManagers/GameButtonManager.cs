using UnityEngine;

public class GameButtonManager : MonoBehaviour {
    public Canvas game;
    public Canvas options;
    public Canvas menu;

    private const float force = 10f;

    private GameObject player;
    private GameObject gameArea;

    private Rigidbody gameAreaRigidbody;
    private ConstantForce gameAreaConstantForce;
    private Rigidbody playerRigidbody;


    void Start() {
        // Instantiate private variables for use in other methods
        player = GameObject.Find("Player");
        gameArea = GameObject.Find("GameArea");
        playerRigidbody = player.GetComponent<Rigidbody>() as Rigidbody;
        gameAreaRigidbody = gameArea.GetComponent<Rigidbody>() as Rigidbody;
        gameAreaConstantForce = gameArea.GetComponent<ConstantForce>() as ConstantForce;
        
        // Setup gameArea start state
        gameAreaRigidbody.isKinematic = true;
        gameAreaConstantForce.enabled = false;

        // Setup canvas start state
        game.enabled = true;
        options.enabled = false;
        menu.enabled = false;
    }

    /* Button functionality implementations
     */
    public void Freeze() {
        gameAreaRigidbody.isKinematic = true;
        gameAreaConstantForce.enabled = false;
    }
    
    public void RotateCW() {
        gameAreaRigidbody.isKinematic = false;
        gameAreaConstantForce.enabled = true;
        gameAreaConstantForce.relativeTorque = new Vector3(0.0f, 0.0f, -force);
    }

    public void RotateCCW() {
        gameAreaRigidbody.isKinematic = false;
        gameAreaConstantForce.enabled = true;
        gameAreaConstantForce.relativeTorque = new Vector3(0.0f, 0.0f, force);
    }
    
    /* Methods for opening/closing menus
     */
    public void OpenMenu() {
        gameAreaRigidbody.isKinematic = true;
        gameAreaConstantForce.enabled = false;
        playerRigidbody.isKinematic = true;
        game.enabled = false;
        menu.enabled = true;
        options.enabled = false;
    }
    
    public void OpenOptions() {
        gameAreaRigidbody.isKinematic = true;
        gameAreaConstantForce.enabled = false;
        playerRigidbody.isKinematic = true;
        game.enabled = false;
        menu.enabled = false;
        options.enabled = true;
    }
    
    public void ExitMenu() {
        gameAreaRigidbody.isKinematic = false;
        gameAreaConstantForce.enabled = true;
        playerRigidbody.isKinematic = false;
        game.enabled = true;
        menu.enabled = false;
        options.enabled = false;
    }
}
