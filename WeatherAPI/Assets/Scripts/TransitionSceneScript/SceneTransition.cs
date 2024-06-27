using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene遷移させる処理
/// </summary>
public class SceneTransition : MonoBehaviour
{
    /// <summary>
    /// ボタンをクリックしたら、画面遷移させる
    /// <summary>
    public void OnButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
