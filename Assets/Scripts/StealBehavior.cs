using UnityEngine;
using System.Collections;

public class StealBehavior : MonoBehaviour {
    GameObject copiedObject = null;
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Camera cam = Camera.main;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            if (hit.collider == null) {
                Debug.Log("Clicked nothing");
            }
            // If this instance of this component is in any of the collider's
            // parents, the click is on the controlled character
            else if (System.Array.Exists(hit.transform.GetComponentsInParent<StealBehavior>(),
                                    element => element == this)) {
                Debug.Log("Clicked self");
                setCopiedObject(null);
            }
            else {
                Debug.Log("Clicked "+hit.transform.name);
                setCopiedObject((GameObject)Object.Instantiate(hit.transform.gameObject, new Vector3(), new Quaternion()));
            }
        }
    }

    void setCopiedObject(GameObject newCopy) {
        if (copiedObject != null) {
            Object.Destroy(copiedObject);
        }
        var em = GetComponent<ParticleSystem>().emission;
        if (newCopy == null) {
            em.enabled = true;
        }
        else {
            em.enabled = false;
            newCopy.transform.SetParent(transform, false);
            foreach (AI ai in newCopy.GetComponentsInChildren<AI>()) {
                ai.enabled = false;
            }
            foreach (Rigidbody2D rb in newCopy.GetComponentsInChildren<Rigidbody2D>()) {
                rb.simulated = false;
            }
        }
        copiedObject = newCopy;
    }
}
