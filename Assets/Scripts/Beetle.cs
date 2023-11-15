using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    public float minJumpForce = 5f;
    public float maxJumpForce = 10f;
    public float minTorque = -5f;
    public float maxTorque = 5f;
    public float minTimeBetweenJumps = 1f;
    public float maxTimeBetweenJumps = 3f;
    public Transform groundCheck;
    public LayerMask groundMask;

    private Rigidbody rb;
    private bool isGrounded;
    private float nextJumpTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if the object is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);
        
        if (Time.time >= nextJumpTime && isGrounded)
        {
            ApplyJumpForce();
            nextJumpTime = Time.time + Random.Range(minTimeBetweenJumps, maxTimeBetweenJumps);
        }
    }

    private void ApplyJumpForce()
    {
        // Generate a random jump force and torque
        float jumpForce = Random.Range(minJumpForce, maxJumpForce);
        float torque = Random.Range(minTorque, maxTorque);

        // Apply the jump force
        Vector3 jumpDirection = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f)).normalized;
        rb.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);

        // Apply torque
        rb.AddTorque(Vector3.up * torque, ForceMode.Impulse);
    }
}
