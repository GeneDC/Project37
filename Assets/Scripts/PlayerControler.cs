using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private int baseSpeed = 37;

    private CharacterController characterController;

    private Sprite sprite;

    void Start()
    {
        sprite = GetComponentInChildren<Sprite>();
        Debug.Assert(sprite != null, "Can't find 'Sprite' component in children.");

        characterController = GetComponent<CharacterController>();
        Debug.Assert(characterController != null, "Can't find 'CharacterController' component.");
    }

    private void FixedUpdate()
    {
        Vector3 inputDirection = new();
        if (Input.GetKey(KeyCode.W)) inputDirection.z += 1;
        if (Input.GetKey(KeyCode.S)) inputDirection.z -= 1;
        if (Input.GetKey(KeyCode.D)) inputDirection.x += 1;
        if (Input.GetKey(KeyCode.A)) inputDirection.x -= 1;

        inputDirection = Vector3.Normalize(inputDirection) * baseSpeed;

        if (characterController)
        {
            characterController.Move(inputDirection * Time.fixedDeltaTime);
        }

        if (sprite)
        {
            sprite.SetDirection(inputDirection);
        }
    }

}
