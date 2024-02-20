using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuaterView;

    [SerializeField]
    // ī�޶�� Ÿ�� ������Ʈ ���� �Ÿ�(ī�޶��� ����� ��ġ)
    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);

    [SerializeField]
    GameObject _player = null;  // Ÿ�� ������Ʈ�� Inspector ���� Player �׸����� �巡�� �� ����ؾ���

    void Start()
    {
        
    }

    // Ÿ�� ������Ʈ�� ������ ��(Update)�� ���󰡵���
    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuaterView)
        {
            RaycastHit hit;

            // ī�޶�� Ÿ�� ������Ʈ ���̿� �ٸ� ������Ʈ�� ���� ��� ����
            if (Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
                transform.position = _player.transform.position + _delta.normalized * dist;
            }

            // ���̿� �ٸ� ������Ʈ�� ���� ��� Ÿ�� ������Ʈ�� �������� ����
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
