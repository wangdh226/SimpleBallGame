using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject frame;
    public GameObject player;
    public UnityEngine.UI.Button CCWButton;
    public UnityEngine.UI.Button CWButton;
    public UnityEngine.UI.Button freezeButton;
    public UnityEngine.UI.Button menuButton;

    // Start is called before the first frame update
    void Start()
    {
        freezeButton.onClick.AddListener(delegate { SwitchButtonHandler(0); });
        CWButton.onClick.AddListener(delegate { SwitchButtonHandler(1); });
        CCWButton.onClick.AddListener(delegate { SwitchButtonHandler(2); });
        menuButton.onClick.AddListener(delegate { SwitchButtonHandler(3); });
    }

    // Update is called once per frame
    void Update() { }

    void SwitchButtonHandler(int index)
    {
        switch (index)
        {
            case 0:
                (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
                (frame.GetComponent("ConstantForce") as ConstantForce).enabled = false;
                Debug.Log("freeze");
                break;
            case 1:
                (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = false;
                (frame.GetComponent("ConstantForce") as ConstantForce).enabled = true;
                (frame.GetComponent("ConstantForce") as ConstantForce).relativeTorque = new Vector3(0.0f, 0.0f, 10.0f);
                Debug.Log("CW");
                break;
            case 2:
                (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = false;
                (frame.GetComponent("ConstantForce") as ConstantForce).enabled = true;
                (frame.GetComponent("ConstantForce") as ConstantForce).relativeTorque = new Vector3(0.0f, 0.0f, -10.0f);
                Debug.Log("CCW");
                break;
            case 3:
                (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
                (frame.GetComponent("ConstantForce") as ConstantForce).enabled = false;
                (player.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
                Debug.Log("menu");
                break;
        }
    }
}
