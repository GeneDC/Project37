using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private int baseSpeed = 37;

    private CharacterController characterController;

    [SerializeField]
    private Material playerMaterial;

    [SerializeField]
    private Texture frontTexture;
    [SerializeField]
    private Texture backTexture;

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

        Debug.Assert(playerMaterial && frontTexture && backTexture, "Missing player materials or textures!");
        if (playerMaterial && frontTexture && backTexture)
        {
            if (inputDirection.z > 0)
            {
                playerMaterial.SetTexture("_MainTex", frontTexture);
            }
            else if (inputDirection.z < 0)
            {
                playerMaterial.SetTexture("_MainTex", backTexture);
            }
        }

        if (inputDirection.x > 0)
        {
            transform.localScale = new(-1, 1, 1);
        }
        else if (inputDirection.x < 0)
        {
            transform.localScale = new(1, 1, 1);
        }

        characterController.SimpleMove(inputDirection * Time.fixedDeltaTime);
    }

}
