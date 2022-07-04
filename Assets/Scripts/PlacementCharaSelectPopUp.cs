using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlacementCharaSelectPopUp : MonoBehaviour
{
    [SerializeField]
    private Button btnClosePopUp;

    [SerializeField]
    private Button btnChoseChara;

    [SerializeField]
    private CanvasGroup canvasGroup;

    private CharaGenerator charaGenerator;


    // TODO 制御を行いたい各コンポーネントの情報をアサインするための変数群を追加する


    /// <summary>
    /// ポップアップの設定
    /// </summary>
    /// <param name="charaGenerator"></param>
    public void SetUpPlacementCharaSelectPopUp(CharaGenerator charaGenerator)
    {

        this.charaGenerator = charaGenerator;

        // TODO 他に設定項目があったら追加する


        // ポップアップを一度見えない状態にする
        canvasGroup.alpha = 0;

        // 各ボタンの操作を押せない状態にする
        SwithcActivateButtons(false);


        // TODO スクリプタブル・オブジェクトに登録されているキャラ分のボタンのゲームオブジェクトを生成


        // TODO 最初に生成したボタンの場合


        // TODO 選択しているキャラとして初期値に設定


        // 各ボタンにメソッドを登録
        btnChoseChara.onClick.AddListener(OnClickSubmitChoseChara);

        btnClosePopUp.onClick.AddListener(OnClickClosePopUp);

        // 各ボタンを押せる状態にする
        SwithcActivateButtons(true);
    }

    /// <summary>
    /// 各ボタンのアクティブ状態の切り替え
    /// </summary>
    /// <param name="isSwitch"></param>
    public void SwithcActivateButtons(bool isSwitch)
    {
        btnChoseChara.interactable = isSwitch;
        btnClosePopUp.interactable = isSwitch;
    }

    /// <summary>
    /// ポップアップの表示
    /// </summary>
    public void ShowPopUp()
    {

        // TODO 各キャラのボタンの制御


        // ポップアップの表示
        canvasGroup.DOFade(1.0f, 0.5f);
    }

    /// <summary>
    /// 選択しているキャラを配置するボタンを押した際の処理
    /// </summary>
    private void OnClickSubmitChoseChara()
    {

        // TODO コストの支払いが可能か最終確認


        // TODO 選択しているキャラの生成


        // ポップアップの非表示
        HidePopUp();
    }

    /// <summary>
    /// 配置を止めるボタンを押した際の処理
    /// </summary>
    private void OnClickClosePopUp()
    {

        // ポップアップの非表示
        HidePopUp();
    }

    /// <summary>
    /// ポップアップの非表示
    /// </summary>
    private void HidePopUp()
    {

        // TODO 各キャラのボタンの制御


        // ポップアップの非表示
        //canvasGroup.DOFade(0, 0.5f).OnComplete(() => charaGenerator.InactivatePlacementCharaSelectPopUp());  // 次の手順でメソッドを追加するので、それまでコメントアウトしておいてください。
    }
}