using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objecttracker : MonoBehaviour
{
    [SerializeField] private float _far;
    [SerializeField] private float _step;
    [SerializeField] private GameObject _target;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_target.transform.position.x, _target.transform.position.y, _far), _step * Time.deltaTime);
    }

}
