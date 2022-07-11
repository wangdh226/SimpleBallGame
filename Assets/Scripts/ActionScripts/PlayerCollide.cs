using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    public Material border;
    public Material transient;

    private GameObject player;
    private BoxCollider boxCollider;
    private BoxCollider boxTrigger;
    private Renderer boxRenderer;
    
    void Start()
    {
        player = GameObject.Find("Player");
        initializeBox();
    }

    private void initializeBox() {
        boxRenderer = gameObject.GetComponent<Renderer>();

        BoxCollider[] colliders = gameObject.GetComponents<BoxCollider>();
        foreach (BoxCollider box in colliders) {
            // if z is > 1 since z doesn't actually matter, need to tell diff
            if(box.size.z == 1.1f) {
                // is physical box
                boxCollider = box;
            } else {
                // is trigger box
                boxTrigger = box;
            }
        }

        boxCollider.isTrigger = false;
        boxCollider.enabled = false;
        boxTrigger.isTrigger = true;
        boxTrigger.enabled = true;
        boxRenderer.material = transient;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            boxCollider.enabled = true;
            boxRenderer.material = border;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject == player) {
            boxCollider.enabled = false;
            boxRenderer.material = transient;
        }
    }
}
