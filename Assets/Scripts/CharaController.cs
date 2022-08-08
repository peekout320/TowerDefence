using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField, Header("攻撃力")]
    private int attackPower = 1;

    [SerializeField, Header("攻撃するまでの待機時間")]
    private float intervalAttackTime = 60.0f;

    [SerializeField]
    private bool isAttack;

    [SerializeField]
    private EnemyController enemy;

    [SerializeField]
    private int attackCount = 3;

    [SerializeField]
    private UnityEngine.UI.Text txtAttackCount;

    [SerializeField]
    private BoxCollider2D attackRangeArea;

    [SerializeField]
    private CharaData charaData;

    private GameManager gameManager;

    private Animator anime;

    private string overrideClipName = "Chara_anime_0";

    private AnimatorOverrideController overrideController;

    //private void Start()
    //{
    //    UpdateDisplayAttackCount();
    //}

    private void OnTriggerStay2D(Collider2D collision)

    {
        // 攻撃中ではない場合で、かつ、敵の情報を未取得である場合
        if (!isAttack && !enemy)
        {

            Debug.Log("敵発見");

            // 敵の情報(EnemyController)を取得する。EnemyController がアタッチされているゲームオブジェクトを判別しているので、Tag による判定と同じ動作で判定が行えます。
            if (collision.gameObject.TryGetComponent(out enemy))
            {

                // 情報を取得できたら、攻撃状態にする
                isAttack = true;

                // 攻撃の準備に入る
                StartCoroutine(PrepareteAttack());
            }
        }
    }

    /// <summary>
    /// 攻撃準備
    /// </summary>
    /// <returns></returns>
    public IEnumerator PrepareteAttack()
    {
        Debug.Log("攻撃準備開始");

        int timer = 0;

        // 攻撃中の間だけループ処理を繰り返す
        while (isAttack)
        {
            if (gameManager.currentGameState == GameManager.GameState.Play)
            {

                timer++;

                // 攻撃のための待機時間が経過したら    
                if (timer > intervalAttackTime)
                {
                    // 次の攻撃に備えて、待機時間のタイマーをリセット
                    timer = 0;

                    // 攻撃
                    Attack();

                    // 攻撃回数関連の処理をここに記述する            
                    attackCount--;

                    // 残り攻撃回数の表示更新
                    UpdateDisplayAttackCount();

                    // 攻撃回数がなくなったら
                    if (attackCount <= 0)
                    {

                        // キャラ破壊
                        Destroy(gameObject);

                        // キャラのリストから情報を削除
                        gameManager.RemoveCharasList(this);
                    }
                }
            }

            // １フレーム処理を中断する(この処理を書き忘れると無限ループになり、Unity エディターが動かなくなって再起動することになります。注意！)
            yield return null;
        }
    }

    /// <summary>
    /// 攻撃
    /// </summary>
    private void Attack()
    {
        Debug.Log("攻撃");

        // TODO キャラの上に攻撃エフェクトを生成

        // 敵キャラ側に用意したダメージ計算用のメソッドを呼び出して、敵にダメージを与える
        enemy.CulcDamage(attackPower);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("敵なし");

            isAttack = false;
            enemy = null;
        }
    }
    /// <summary>
    /// 残り攻撃回数の表示更新
    /// </summary>
    private void UpdateDisplayAttackCount()
    {
        txtAttackCount.text = attackCount.ToString();
    }

    /// <summary>
    /// キャラの設定
    /// </summary>
    /// <param name="charaData"></param>
    /// <param name="gameManager"></param>
    public void SetUpChara(CharaData charaData, GameManager gameManager)
    {

        this.charaData = charaData;
        this.gameManager = gameManager;

        // 各値を CharaData から取得して設定
        attackPower = this.charaData.attackPower;

        intervalAttackTime = this.charaData.intervalAttackTime;

        // DataBaseManager に登録されている AttackRangeSizeSO スクリプタブル・オブジェクトのデータと照合を行い、CharaData の AttackRangeType の情報を元に Size を設定
        attackRangeArea.size = DataBaseManager.instance.GetAttackRangeSize(this.charaData.attackRange);

        attackCount = this.charaData.maxAttackCount;

        // 残りの攻撃回数の表示更新
        UpdateDisplayAttackCount();

        // キャラごとの AnimationClip を設定
        SetUpAnimation();
    }

    /// <summary>
    /// Motion に登録されている AnimationClip を変更
    /// </summary>
    private void SetUpAnimation()
    {
        if (TryGetComponent(out anime))
        {

            overrideController = new AnimatorOverrideController();

            overrideController.runtimeAnimatorController = anime.runtimeAnimatorController;
            anime.runtimeAnimatorController = overrideController;

            AnimatorStateInfo[] layerInfo = new AnimatorStateInfo[anime.layerCount];

            for (int i = 0; i < anime.layerCount; i++)
            {
                layerInfo[i] = anime.GetCurrentAnimatorStateInfo(i);
            }

            overrideController[overrideClipName] = this.charaData.charaAnime;

            anime.runtimeAnimatorController = overrideController;

            anime.Update(0.0f);

            for (int i = 0; i < anime.layerCount; i++)
            {
                anime.Play(layerInfo[i].fullPathHash, i, layerInfo[i].normalizedTime);
            }
        }
    }
}