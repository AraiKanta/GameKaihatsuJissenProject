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
    [SerializeField] private Canvas m_NOSCanvas = default;

    [SerializeField] private Button m_filedSelectionButton = default;
    [SerializeField] private Button m_nosButton = default;
    [SerializeField] private Button m_filedReturnButton = default;
    [SerializeField] private Button m_nosReturnButton = default;

    private void Awake()
    {
        m_filedReturnButton.onClick.AddListener(OnReturn);
        m_nosReturnButton.onClick.AddListener(OnReturn);
        m_filedSelectionButton.onClick.AddListener(OnFiledSelect);
        m_nosButton.onClick.AddListener(OnNOS);
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
        m_NOSCanvas.gameObject.SetActive(true);
    }

    public void OnReturn()
    {
        m_FiledSelectionCanvas.gameObject.SetActive(false);
        m_NOSCanvas.gameObject.SetActive(false);
        m_topCanvas.gameObject.SetActive(true);
    }
}
