using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class AxeThrowing : MonoBehaviour
{
    [Header("References")]
    public Rigidbody axeRb;
    public Rigidbody handRb;
    public FixedJoint axeJoint;

    //[Header("Throw Settings")]
    //public float throwForce = 15f;
    //public float spinForce = 10f;

    //Starting position variables
    private Vector3 axeStartPos;
    private Quaternion axeStartRot;

    private Vector3 handStartPos;
    private Quaternion handStartRot;

    void Start()
    {

        // Save starting transforms
        axeStartPos = axeRb.transform.position;
        axeStartRot = axeRb.transform.rotation;

        Debug.Log("Hand Start Pos: " + axeStartPos);
        Debug.Log("Hand Start Rot: " + axeStartRot);

        handStartPos = handRb.transform.position;
        handStartRot = handRb.transform.rotation;
    }

    public void ThrowAxe()
    {
        // Disconnect joint
        axeJoint.connectedBody = null;

        //// Throw axe
        //axeRb.AddForce(transform.forward * throwForce, ForceMode.Impulse);

        //// Add spin
        //axeRb.AddTorque(transform.right * spinForce, ForceMode.Impulse);
    }

    public void ResetAxe()
    {
        // Stop movement
        axeRb.linearVelocity = Vector3.zero;
        axeRb.angularVelocity = Vector3.zero;

        handRb.linearVelocity = Vector3.zero;
        handRb.angularVelocity = Vector3.zero;

        // Reset transforms
        handRb.transform.position = handStartPos;
        handRb.transform.rotation = handStartRot;

        axeRb.transform.position = axeStartPos;
        axeRb.transform.rotation = axeStartRot;

        // Reconnect joint AFTER positioning
        axeJoint.connectedBody = axeRb;
    }
}