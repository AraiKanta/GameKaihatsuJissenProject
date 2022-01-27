using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// �J�ڊǗ��̃N���X 
/// </summary>
public class TransitionManager : MonoBehaviour
{
    [Header("�g�b�v��ʂ̃L�����o�X"),Tooltip("�g�b�v��ʂ̃L�����o�X")]
    [SerializeField] private Canvas m_topCanvas = default;
    [Header("�t�B�[���h�I����ʂ̃L�����o�X"), Tooltip("�t�B�[���h�I����ʂ̃L�����o�X")]
    [SerializeField] private Canvas m_FiledSelectionCanvas = default;
    [Header("�����ꗗ��ʂ̃L�����o�X"), Tooltip("�����ꗗ��ʂ̃L�����o�X")]
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
    /// �t�B�[���h�Z���N�V�����{�^��
    /// </summary>
    public void OnFiledSelect()
    {
        m_topCanvas.gameObject.SetActive(false);
        m_FiledSelectionCanvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// �����ꗗ�{�^��
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
