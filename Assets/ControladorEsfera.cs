using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorEsfera : MonoBehaviour
{
    public float speed;
    public Text counterText;
    public Text finText;
    private int count;

    private void Start()
    {
        count = 0;
        updateCounter();
        finText.text = "";
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        GetComponent<Rigidbody>().AddForce(direction * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("capsules"))
        {
            Destroy(other.gameObject);
            count++;
            updateCounter();
        }
    }

    void updateCounter()
    {
        counterText.text = "Capsules: " + count;
        int numCapsules = GameObject.FindGameObjectsWithTag("capsules").Length;

        if(numCapsules == 1)
        {
            finText.text = "You've collected all the capsules.";
        }
    }
}
