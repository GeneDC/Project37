using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject playerRef;

    [SerializeField]
    private int speed = 100;

    private Sprite sprite;
    private CharacterController characterController;

    private void Start()
    {
        Debug.Assert(playerRef != null, "Missing 'Player Ref' reference.");

        sprite = GetComponentInChildren<Sprite>();
        Debug.Assert(sprite != null, "Can't find 'Sprite' component in children.");

        characterController = gameObject.GetComponent<CharacterController>();
        Debug.Assert(characterController != null, "Can't find 'CharacterController' component.");
    }

    private void FixedUpdate()
    {
        if (playerRef == null || characterController == null)
        {
            return;
        }

        Vector3 vecToPlayer = playerRef.transform.position - transform.position;
        float distanceToPlayer = vecToPlayer.magnitude;
        Vector3 directionToPlayer = vecToPlayer.normalized;

        Vector3 movement = Mathf.Min(distanceToPlayer, speed * Time.fixedDeltaTime) * directionToPlayer;

        characterController.SimpleMove(movement);

        sprite.SetDirection(movement);
    }
}
