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
    /// 全角判定
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
    /// Clickされたときの関数
    /// </summary>
    public void UpdateText() 
    {
        if (isZenkaku(m_inputField.text))
        {
            m_text.text = m_inputField.text;
            Debug.Log("全角入力です");
            KaibunCheck();
        }
        else
        {
            m_text.text = "全角入力して";
            Debug.Log("全角入力じゃない");
        }        
    }

    /// <summary>
    /// 回文判定の関数
    /// </summary>
    private void KaibunCheck()
    {
        string _str = m_inputField.text;
        
        //エラー処理
        if (string.IsNullOrEmpty(_str))
        {
            m_text.text = "<color=#0000ffff> テキストを入力してください </color>";
            return;
        }

        //文字の反転
        string Reverse_str = new string(_str.Reverse().ToArray());
        Debug.Log(Reverse_str);

        if (_str == Reverse_str)
        {
            m_text.text = "<color=#ffff00ff> 回文です </color>\n" + _str;
        }
        else
        {
            m_text.text = "<color=#ff0000ff> 回文じゃないです </color>\n" + _str;
        }
    }
}
