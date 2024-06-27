using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWeatherInfo : MonoBehaviour
{
    [Header("ボタンが押された際の、天気の詳細を表示させるパネルを設定")]
    [SerializeField] private GameObject weatherInfoPanel;　　//天気情報を表示するパネル


    [Header("表示する天気の詳細情報のTextを設定")]
    [SerializeField] private TextMeshProUGUI locationText; 　//場所を表示するTextMeshProUGUI
    [SerializeField] private TextMeshProUGUI temperatureText;//気温を表示するTextMeshProUGUI
    [SerializeField] private TextMeshProUGUI weatherText; 　 //天気を表示するTextMeshProUGUI
    [SerializeField] private TextMeshProUGUI windText;       //風速を表示するTextMeshProUGUI
    [SerializeField] private TextMeshProUGUI windDirectionText; //風向きを表示するTextMeshProUGUI
    [SerializeField] private TextMeshProUGUI maximumTemperatureText; //最高気温を表示するTextMeshProUGUI
    [SerializeField] private TextMeshProUGUI minimumTemperatureText; //最低気温を表示するTextMeshProUGUI
    [SerializeField] private TextMeshProUGUI timeStampText; //天気データの更新日時を表示するTextMeshProUGUI
    [SerializeField] private Image weatherImage; //天気の画像を表示する画像を設定


    [SerializeField] private WeatherWind weatherWind;//風の向きを調べる
    [SerializeField] private WeatherIcon weatherIcon;//天気アイコン設定


    private void Start () {
        weatherWind = new WeatherWind();
        weatherIcon = new WeatherIcon(weatherImage);
    }


    /// <summary>
    /// OpenWeatherAPI側から受け取る天気の情報をUIに対応させる処理
    /// </summary>
    /// <param name="response">天気情報情報のレスポンス</param>
    public void WeatherInfo ( IWeatherResponse response ) {
        //風向きを調べる
        string windDirection = weatherWind.GetWindDirection(response.Wind.Deg);

        //Start location----------------------------------------------
        locationText.text = $"場所 : {response.Name}";
        //end of location---------------------------------------------


        //Start Temp--------------------------------------------------
        temperatureText.text = $"気温 : {response.Main.Temp}℃";


        //最高最低気温の色分け
        if ( response.Main.TempMax > response.Main.TempMin ) {
            maximumTemperatureText.color = Color.red;
            minimumTemperatureText.color = Color.blue;
        }
        else {
            maximumTemperatureText.color = Color.black;
            minimumTemperatureText.color = Color.black;
        }

        maximumTemperatureText.text = $"最高気温 {response.Main.TempMax}℃";
        minimumTemperatureText.text = $"最低気温 {response.Main.TempMin}℃";
        //end of Temp--------------------------------------------------


        //Start Weather------------------------------------------------
        weatherText.text = $"天気 : {response.Weather[0].WeatherMain}";
        weatherIcon.SetWeatherIcon(response.Weather[0].WeatherMain);
        //end of Weather-----------------------------------------------


        //Start Wind---------------------------------------------------
        windDirectionText.text = $"風向き : {windDirection}";
        windText.text = $"風速 : {response.Wind.Speed}m/s";
        //end of Wind--------------------------------------------------


        //Start TimeStamp----------------------------------------------
        long timestamp = response.Timestamp;
        DateTimeOffset observationTime = DateTimeOffset.FromUnixTimeSeconds(timestamp);
        DateTime localTime = observationTime.LocalDateTime;
        string observationTimeString = localTime.ToString("yyyy/MM/dd HH:mm" + "現在");
        timeStampText.text = $"観測時間 : {observationTimeString}";
        //end of Timestamp---------------------------------------------
    }
}

