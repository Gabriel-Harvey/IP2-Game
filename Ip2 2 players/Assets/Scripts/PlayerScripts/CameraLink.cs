using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLink : MonoBehaviour
{
    MultipleTargetCamera multipleTarget;

    private void Awake()
    {
        multipleTarget = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MultipleTargetCamera>();
    }

    void Start()
    {
        multipleTarget.targets.Add(gameObject.transform);
    }

}
