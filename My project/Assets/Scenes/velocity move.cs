using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocitymove : MonoBehaviour{
    
    Transform m_transform;  //Transform是Unity內建的class 她記錄著玩家的座標 可以透過更改Transform.position更改我的位置
    Rigidbody2D m_rigidbody;  //Rigidbody是Unity內建的物理系統 , Rigidbody2D.velocity 能更改玩家移動速度

    float velocity_x, velocity_y;  //宣告變數來告訴系統 我的移動速度應該是多少((見Update()

    void Start()
    {
      m_transform = gameObject.GetComponent<Transform>();  
      //雖然第七行把m_transform宣告出來 但是系統並不會知道這個Transform是屬於誰的座標
      //gameObject默認代表我自己 .GetComponent表示取得我自己的<Transform>物件  這樣便能告訴系統m_transform是我自己的Transform物件
      m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
      //同上理 告訴系統這是我的Rigidbody2D
    }

    void Update()
    {
      if(Input.GetKey (KeyCode.W)){  //Unity專有語法 如果滑鼠W按著時為True
      //Input.GetKey      表示持續按著
      //Input.GetKeyDown  表示按鍵按下瞬間
      //Input.GetKeyUp    表示按鍵放開瞬間
 
        velocity_y = 1f;  //將 velocity_y 變數 轉為 1
      }else if(Input.GetKey (KeyCode.S)){ //如果滑鼠S按著時為True
        velocity_y = -1f;  //將 velocity_y 變數 轉為 -1
      }else{
        velocity_y = 0f;
      }

      if(Input.GetKey (KeyCode.D)){
        velocity_x = 1f;
      }else if(Input.GetKey (KeyCode.A)){
        velocity_x = -1f;
      }else{
        velocity_x = 0f;
      }

      m_rigidbody.linearVelocity = new Vector3(velocity_x, velocity_y, 0f);  //將數值轉為Vector3形式並存入m_rigidbody.velocity
    }
}