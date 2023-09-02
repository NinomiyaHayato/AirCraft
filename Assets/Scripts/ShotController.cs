using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotController : MonoBehaviour
{
    [SerializeField, Header("�˒�����")] float _range = 10;
    [SerializeField, Header("�ˌ��ꏊ")] Transform _shotPosition;
    [SerializeField, Header("�Ώ�")] LayerMask _layerMask;
    [SerializeField, Header("�Ə�")] Image _crossHair;

    void Update()
    {

        Ray ray = new Ray(_shotPosition.position, -_shotPosition.right);

        Debug.DrawRay(ray.origin, ray.direction * _range, Color.red);

        RaycastHit hit = default;
        Vector3 hitPosition = _shotPosition.transform.position + _shotPosition.forward * _range;
        Collider hitCollider = default;
        if (Physics.Raycast(ray, out hit, _range, _layerMask))
        {
            hitPosition = hit.point;
            hitCollider = hit.collider;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (hitCollider)
            {
                Debug.Log("������܂���");
            }
        }
        _crossHair.transform.position = _shotPosition.transform.position - _shotPosition.right * (_range - 1);
    }
}
