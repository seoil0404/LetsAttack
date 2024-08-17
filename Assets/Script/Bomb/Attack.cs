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
        // 버튼 컴포넌트를 가져옵니다.
        button = GetComponent<Button>();

        // 버튼이 눌러졌을 때 실행할 함수 연결
        button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
