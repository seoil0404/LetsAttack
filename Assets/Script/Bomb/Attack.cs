using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Attack : Bomb_Manager
{
    private Button button;
    void OnButtonClick()
    {
        Shoot();
    }
    // Start is called before the first frame update
    void Awake()
    {
        // ��ư ������Ʈ�� �����ɴϴ�.
        button = GetComponent<Button>();

        // ��ư�� �������� �� ������ �Լ� ����
        button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
