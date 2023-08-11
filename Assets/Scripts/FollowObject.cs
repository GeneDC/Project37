using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    private GameObject followObject;

    private Vector3 followOffset = Vector3.zero;

    private void Start()
    {
        if (followObject != null)
        {
            StartFollow(followObject);
        }
    }

    private void LateUpdate()
    {
        transform.position = followObject.transform.position + followOffset;
    }

    public void StartFollow(GameObject gameObject)
    {
        followObject = gameObject;
        followOffset = transform.position - followObject.transform.localPosition;
    }
}
