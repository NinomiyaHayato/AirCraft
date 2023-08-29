using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotController : MonoBehaviour
{
    [SerializeField, Header("�˒�����")] float _range = 10;
    [SerializeField, Header("�ˌ��ꏊ")] Transform _shotPosition;
    [SerializeField, Header("�Ώ�")] LayerMask _layerMask;
    [SerializeField] LineRenderer _lineRenderer;
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
            ShotLaser(hitPosition);
            if (hitCollider)
            {
                Debug.Log("������܂���");
            }
        }
    }

    void ShotLaser(Vector3 destination)
    {
        Vector3[] shotLaserPosition = { _shotPosition.position, destination };
        _lineRenderer.positionCount = shotLaserPosition.Length;
        _lineRenderer.SetPositions(shotLaserPosition);
    }
}
