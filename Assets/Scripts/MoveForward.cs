using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }
}
