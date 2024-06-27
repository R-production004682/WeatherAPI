using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲーム全体の管理を行っているクラス。
/// ボタンの生成、天気情報の取得および、表示をしているクラス。
/// </summary>


[RequireComponent(typeof(GeneratPrefectureButton))]
public class GameManager : MonoBehaviour
{

   

    [Header("画像イメージを表示する UGUIのPanelを設定")]
    [SerializeField] private Image weatherIcon; //天気アイコンを表示するためのImageコンポーネント


    [SerializeField] private GeneratPrefectureButton generateButton;


    /// <summary>
    /// weatherServiceの初期化
    /// WeatherIconManagerの初期化
    /// ボタンの生成
    /// </summary>
    private void Start() {
        weatherIcon.enabled = false;
        generateButton = GetComponent<GeneratPrefectureButton>();
    }
}

