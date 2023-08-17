using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotController : MonoBehaviour
{
    [SerializeField, Header("照準のImage")] Image _crosshair;
    [SerializeField, Header("射程距離")] float _range = 10;
    [SerializeField, Header("射撃場所")] Transform _shotPosition;
    [SerializeField, Header("対象")] LayerMask _layerMask;
    [SerializeField] LineRenderer _lineRenderer;

    // Update is called once per frame
    void Update()
    {
        // マウスカーソルの位置をワールド座標に変換
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = _range; // 射程距離に設定
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

        // Crosshairの位置をマウスのワールド座標に合わせる
        _crosshair.rectTransform.position = Camera.main.WorldToScreenPoint(targetPosition);

        if (Input.GetButtonDown("Fire1"))
        {
            ShotLaser(hitPosition);
            if (hitCollider)
            {
                Debug.Log("当たりました");
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
