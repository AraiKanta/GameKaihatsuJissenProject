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
    [SerializeField] private Canvas m_nosCanvas = default;
    [Header("�����X�^�[��ʂ̃L�����o�X"), Tooltip("�����X�^�[��ʂ̃L�����o�X")]
    [SerializeField] private Canvas m_monsterCanvas = default;

    [Header("�t�B�[���h�I���{�^��"), Tooltip("�t�B�[���h�I���{�^��")]
    [SerializeField] private Button m_filedSelectionButton = default;
    [Header("�����ꗗ�I���{�^��"), Tooltip("�����ꗗ�I���{�^��")]
    [SerializeField] private Button m_nosButton = default;
    [Header("�g�b�v�ɖ߂�{�^��"), Tooltip("�g�b�v�ɖ߂�{�^��")]
    [SerializeField] private Button m_filedReturnButton = default;
    [Header("�g�b�v�ɖ߂�{�^��"), Tooltip("�g�b�v�ɖ߂�{�^��")]
    [SerializeField] private Button m_nosReturnButton = default;
    [Header("�O�̉�ʂɖ߂�{�^��"), Tooltip("�O�̉�ʂɖ߂�{�^��")]
    [SerializeField] private Button m_monsterReturnButton = default;


    [Header("�{�^���T�[�}���["), Tooltip("�{�^���T�[�}���[")]
    [SerializeField] GameObject m_buttonSummary = default;
    [Header("�t�B�[���h�̃{�^��"), Tooltip("�t�B�[���h�̃{�^��")]
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
        m_nosCanvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// �߂�
    /// </summary>
    public void OnReturn()
    {
        m_FiledSelectionCanvas.gameObject.SetActive(false);
        m_nosCanvas.gameObject.SetActive(false);
        m_topCanvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// �����X�^�[��ʂ���t�B�[���h�I����ʂɖ߂�
    /// </summary>
    public void OnOnePageReturn()
    {
        m_FiledSelectionCanvas.gameObject.SetActive(true);
        m_monsterCanvas.gameObject.SetActive(false);
    }
}
