using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private int baseSpeed = 10;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Vector3 inputDirection = new();
        if (Input.GetKey(KeyCode.W)) inputDirection.z += 1;
        if (Input.GetKey(KeyCode.S)) inputDirection.z -= 1;
        if (Input.GetKey(KeyCode.D)) inputDirection.x += 1;
        if (Input.GetKey(KeyCode.A)) inputDirection.x -= 1;

        inputDirection = Vector3.Normalize(inputDirection) * baseSpeed;

        characterController.SimpleMove(inputDirection * Time.fixedDeltaTime);
    }
}
