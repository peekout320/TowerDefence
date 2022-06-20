using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {

        // 攻撃範囲用のコライダーに侵入したゲームオブジェクトの Tag が Enemy である場合
        if (collision.tag == "Enemy")
        {

            Debug.Log("敵発見");

            Destroy(collision.gameObject);

            // TODO 敵の情報(EnemyController)を取得する

            // TODO 情報を取得できたら、攻撃状態にする

            // TODO 攻撃の準備に入る

        }
    }
}
