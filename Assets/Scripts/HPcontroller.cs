using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPcontroller : MonoBehaviour
{
    //初期ライフの設定
    public int life = 5;
    public string life_string;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefsというデバイス依存の領域に、"Life"という名前でlifeを保存
        PlayerPrefs.SetInt("Life", life);
    }

    // Update is called once per frame
    void Update()
    {
        //常にライフの変更を取得
       life = PlayerPrefs.GetInt("Life");
       life_string = life.ToString();
       
    }

}
