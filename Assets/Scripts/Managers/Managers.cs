using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

// �ϳ��� ������ ���ڴµ� ��ü�ε� ����ϰ� �;� -> �̱��� ����(static �ʵ�)

public class Managers : MonoBehaviour
{
    static Managers s_instance; // ���� �ʵ�. Managers�� ó�� ���� �� ��������� �ϳ��� ����
    static Managers Instance { get { Init(); return s_instance; } }

    InputManager _input = new InputManager();   // �׳� �ʵ�
    public static InputManager Input { get { return Instance._input; } }

    SceneManagerEx _scene = new SceneManagerEx();
    public static SceneManagerEx Scene { get {  return Instance._scene; } }

    UIManager _ui = new UIManager();
    public static UIManager UI { get { return Instance._ui; } }

    public ResourceManager _resource = new ResourceManager();
    public static ResourceManager Resource { get { return Instance._resource; } }

    void Start()
    {
        Init();
    }

    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");

            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }        
    }
}
