using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
    [SerializeField] RaySender raySender;
    [SerializeField] float zPositionOffset;
    [SerializeField] float pushBackMagnitude;
    Vector3 newPosition;
    private void FixedUpdate()
    {

        if (Input.GetMouseButton(0))
        {
            newPosition = raySender.RayHitPosition;
            newPosition.z = newPosition.z + zPositionOffset;
            transform.position = newPosition;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Paddle Bounce");
        //EditorApplication.isPaused = true;
        ContactPoint contact = collision.GetContact(0);
        Debug.DrawLine(contact.point, contact.normal, Color.white, 2f);
        Debug.DrawLine(contact.point, transform.position, Color.blue, 2f);
        Debug.Log(transform.InverseTransformPoint(contact.point) );
        Vector3 force = transform.InverseTransformPoint(contact.point);
        force.z = 0;
        force = force * pushBackMagnitude;
        collision.other.gameObject.GetComponent<Rigidbody>().AddForce(force);
    }
}
