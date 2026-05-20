using UnityEngine;
using UnityEngine.InputSystem;

public class ArmMovement : MonoBehaviour
{
    public HingeJoint hinge;
    public float motorTargetVelocity = 400f;
    public float motorForce = 200f;

    private InputAction moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.Enable();
    }

    void FixedUpdate()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();

        // W/S or Up/Down
        float move = input.y * -1;

        // No input -> free movement
        if (Mathf.Abs(move) < 0.1f)
        {
            hinge.useMotor = false;
            return;
        }

        // Input detected -> enable motor
        hinge.useMotor = true;

        JointMotor motor = hinge.motor;

        // Set motor speed
        motor.targetVelocity = move * motorTargetVelocity;

        // Strength of the motor
        motor.force = motorForce;

        // Apply motor settings
        hinge.motor = motor;
    }
}
