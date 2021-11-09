using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Linq;

public class InputManager : MonoBehaviour
{
    [SerializeField] InputField m_inputField;
    [SerializeField] Button m_button;
    [SerializeField] Text m_text;

    static Encoding m_encoding = Encoding.GetEncoding("Shift_JIS");

    /// <summary>
    /// �S�p����
    /// </summary>
    /// <param name="Str"></param>
    /// <returns></returns>
    public static bool isZenkaku(string Str)
    {
        int Num = m_encoding.GetByteCount(Str);
        return Num == Str.Length * 2;
    }

    private void Awake()
    {
        m_button.onClick.AddListener(UpdateText);
        m_text.text = string.Empty;
    }

    /// <summary>
    /// Click���ꂽ�Ƃ��̊֐�
    /// </summary>
    public void UpdateText() 
    {
        if (isZenkaku(m_inputField.text))
        {
            m_text.text = m_inputField.text;
            Debug.Log("�S�p���͂ł�");
            KaibunCheck();
        }
        else
        {
            m_text.text = "�S�p���͂���";
            Debug.Log("�S�p���͂���Ȃ�");
        }        
    }

    /// <summary>
    /// �񕶔���̊֐�
    /// </summary>
    private void KaibunCheck()
    {
        string _str = m_inputField.text;
        
        //�G���[����
        if (string.IsNullOrEmpty(_str))
        {
            m_text.text = "<color=#0000ffff> �e�L�X�g����͂��Ă������� </color>";
            return;
        }

        //�����̔��]
        string Reverse_str = new string(_str.Reverse().ToArray());
        Debug.Log(Reverse_str);

        if (_str == Reverse_str)
        {
            m_text.text = "<color=#ffff00ff> �񕶂ł� </color>\n" + _str;
        }
        else
        {
            m_text.text = "<color=#ff0000ff> �񕶂���Ȃ��ł� </color>\n" + _str;
        }
    }
}
