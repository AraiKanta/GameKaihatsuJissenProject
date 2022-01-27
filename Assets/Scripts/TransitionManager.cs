using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// 遷移管理のクラス 
/// </summary>
public class TransitionManager : MonoBehaviour
{
    [Header("トップ画面のキャンバス"),Tooltip("トップ画面のキャンバス")]
    [SerializeField] private Canvas m_topCanvas = default;
    [Header("フィールド選択画面のキャンバス"), Tooltip("フィールド選択画面のキャンバス")]
    [SerializeField] private Canvas m_FiledSelectionCanvas = default;
    [Header("討伐一覧画面のキャンバス"), Tooltip("討伐一覧画面のキャンバス")]
    [SerializeField] private Canvas m_nosCanvas = default;
    [Header("モンスター画面のキャンバス"), Tooltip("モンスター画面のキャンバス")]
    [SerializeField] private Canvas m_monsterCanvas = default;

    [Header("フィールド選択ボタン"), Tooltip("フィールド選択ボタン")]
    [SerializeField] private Button m_filedSelectionButton = default;
    [Header("討伐一覧選択ボタン"), Tooltip("討伐一覧選択ボタン")]
    [SerializeField] private Button m_nosButton = default;
    [Header("トップに戻るボタン"), Tooltip("トップに戻るボタン")]
    [SerializeField] private Button m_filedReturnButton = default;
    [Header("トップに戻るボタン"), Tooltip("トップに戻るボタン")]
    [SerializeField] private Button m_nosReturnButton = default;
    [Header("前の画面に戻るボタン"), Tooltip("前の画面に戻るボタン")]
    [SerializeField] private Button m_monsterReturnButton = default;


    [Header("ボタンサーマリー"), Tooltip("ボタンサーマリー")]
    [SerializeField] GameObject m_buttonSummary = default;
    [Header("フィールドのボタン"), Tooltip("フィールドのボタン")]
    [SerializeField] GameObject[] m_buttonPrefab = default;
    private void Awake()
    {
        m_topCanvas.gameObject.SetActive(true);
        m_FiledSelectionCanvas.gameObject.SetActive(false);
        m_nosCanvas.gameObject.SetActive(false);
        m_monsterCanvas.gameObject.SetActive(false);

        m_filedReturnButton.onClick.AddListener(OnReturn);
        m_nosReturnButton.onClick.AddListener(OnReturn);
        m_filedSelectionButton.onClick.AddListener(OnFiledSelect);
        m_nosButton.onClick.AddListener(OnNOS);
        m_monsterReturnButton.onClick.AddListener(OnOnePageReturn);
    }

    /// <summary>
    /// フィールドセレクションボタン
    /// </summary>
    public void OnFiledSelect()
    {
        m_topCanvas.gameObject.SetActive(false);
        m_FiledSelectionCanvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// 討伐一覧ボタン
    /// </summary>
    public void OnNOS()
    {
        m_topCanvas.gameObject.SetActive(false);
        m_nosCanvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// 戻る
    /// </summary>
    public void OnReturn()
    {
        m_FiledSelectionCanvas.gameObject.SetActive(false);
        m_nosCanvas.gameObject.SetActive(false);
        m_topCanvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// モンスター画面からフィールド選択画面に戻る
    /// </summary>
    public void OnOnePageReturn()
    {
        m_FiledSelectionCanvas.gameObject.SetActive(true);
        m_monsterCanvas.gameObject.SetActive(false);
    }
}
