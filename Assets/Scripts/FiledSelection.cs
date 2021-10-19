using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

/// <summary>
/// �t�B�[���h�I����ʂ̃N���X 
/// </summary>
public class FiledSelection : MonoBehaviour
{
    [SerializeField] private Canvas m_topCanvas = default;
    [SerializeField] private Canvas m_FiledSelectionCanvas = default;

    private void Start()
    {
        m_FiledSelectionCanvas.gameObject.SetActive(false);
    }

    public void OnClick()
    {
        m_topCanvas.gameObject.SetActive(false);
        m_FiledSelectionCanvas.gameObject.SetActive(true);
    }

    void FiledSelect()
    {

    }
}
