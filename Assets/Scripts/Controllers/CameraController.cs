using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuaterView;

    [SerializeField]
    // 카메라와 타겟 오브젝트 간의 거리(카메라의 상대적 위치)
    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);

    [SerializeField]
    GameObject _player = null;  // 타겟 오브젝트를 Inspector 탭의 Player 항목으로 드래그 앤 드롭해야함

    void Start()
    {
        
    }

    // 타겟 오브젝트가 움직인 뒤(Update)에 따라가도록
    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuaterView)
        {
            RaycastHit hit;

            // 카메라와 타겟 오브젝트 사이에 다른 오브젝트가 있을 경우 줌인
            if (Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
                transform.position = _player.transform.position + _delta.normalized * dist;
            }

            // 사이에 다른 오브젝트가 없을 경우 타겟 오브젝트의 움직임을 따라감
            else
            {
                transform.position = _player.transform.position + _delta;
                transform.LookAt(_player.transform);
            }
        }       
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuaterView;
        _delta = delta;
    }
}
