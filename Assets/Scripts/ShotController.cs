using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotController : MonoBehaviour
{
    [SerializeField, Header("�Ə���Image")] Image _crosshair;
    [SerializeField, Header("�˒�����")] float _range = 10;
    [SerializeField, Header("�ˌ��ꏊ")] Transform _shotPosition;
    [SerializeField, Header("�Ώ�")] LayerMask _layerMask;
    [SerializeField] LineRenderer _lineRenderer;

    // Update is called once per frame
    void Update()
    {
        // �}�E�X�J�[�\���̈ʒu�����[���h���W�ɕϊ�
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = _range; // �˒������ɐݒ�
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Ray ray = new Ray(_shotPosition.position, targetPosition - _shotPosition.position);
        Debug.DrawRay(ray.origin, ray.direction * _range, Color.red);
        RaycastHit hit = default;
        Vector3 hitPosition = _shotPosition.position + ray.direction * _range;
        Collider hitCollider = default;

        if (Physics.Raycast(ray, out hit, _range))
        {
            hitPosition = hit.point;
            hitCollider = hit.collider;
        }

        // Crosshair�̈ʒu���}�E�X�̃��[���h���W�ɍ��킹��
        _crosshair.rectTransform.position = Camera.main.WorldToScreenPoint(targetPosition);

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
