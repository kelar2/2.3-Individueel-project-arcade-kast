using UnityEngine;

public class BasicAxeThrowing : MonoBehaviour
{
    public Vector3 force;
    public Vector3 rotationDirection;
    public float rotationSpeed;

    //Starting information for resetting the axe
    private Vector3 startPosition;
    private Quaternion startRotation;

    public Rigidbody axe;

    private void Start()
    {
        axe.isKinematic = true;

        // Save starting transform
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void ThrowAxe()
    {
        axe.isKinematic = false;
        axe.AddForce(force);
        axe.AddTorque(rotationDirection.normalized * rotationSpeed);
    }

    public void ResetAxe()
    {
        if (axe.isKinematic == false)
        {
            // Stop all movement
            axe.linearVelocity = Vector3.zero;
            axe.angularVelocity = Vector3.zero;
        }

        // Move axe back
        transform.position = startPosition;
        transform.rotation = startRotation;

        // Freeze it again
        axe.isKinematic = true;
    }
}
