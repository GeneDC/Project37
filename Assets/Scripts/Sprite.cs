using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    [SerializeField]
    private Material materialCopy;

    [SerializeField]
    private Texture frontTexture;
    [SerializeField]
    private Texture backTexture;

    private static readonly Vector3 leftScale = new(1f, 1f, 1f);
    private static readonly Vector3 rightScale = new(-1f, 1f, 1f);


    private void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        materialCopy = Instantiate(meshRenderer.material);
        meshRenderer.material = materialCopy;

        Debug.Assert(frontTexture != null, "Missing 'Front Texture' ref");
        Debug.Assert(backTexture != null, "Missing 'Back Texture' ref");
    }

    public void SetDirection(Vector3 direction)
    {
        Refresh(direction);
    }

    private void Refresh(Vector3 direction)
    {
        if (!(materialCopy && frontTexture && backTexture))
        {
            return;
        }

        materialCopy.SetTexture("_MainTex", frontTexture);

        // Front and back textures for up and down, defaulting to using the front
        if (direction.z <= 0)
        {
            materialCopy.SetTexture("_MainTex", frontTexture);
        }
        else if (direction.z > 0)
        {
            materialCopy.SetTexture("_MainTex", backTexture);
        }

        // Mirror using scale for left and right directions
        if (direction.x > 0)
        {
            transform.localScale = rightScale;
        }
        else if (direction.x < 0)
        {
            transform.localScale = leftScale;
        }
    }
}
