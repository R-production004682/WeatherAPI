using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene�J�ڂ����鏈��
/// </summary>
public class SceneTransition : MonoBehaviour
{
    /// <summary>
    /// �{�^�����N���b�N������A��ʑJ�ڂ�����
    /// <summary>
    public void OnButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
