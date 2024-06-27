using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// アイコンを取得するクラス。
/// </summary>
public class WeatherIcon {
    private Image weatherIcon;

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="weatherIcon">天気アイコンを表示するImageオブジェクト</param>
    public WeatherIcon(Image weatherIcon) {
        this.weatherIcon = weatherIcon;
    }


    /// <summary>
    /// 天気の画像を表示する処理
    /// </summary>
    public void SetWeatherIcon(string weatherDescription) {
        string iconName = GetIconName(weatherDescription); //天気に応じたアイコン名を取得

        //アイコン名が空じゃないかのチェック。空じゃなかったら、Resources/weatherIconsフォルダから画像を読み込む。
        if (!string.IsNullOrEmpty(iconName)) {
            Sprite icon = Resources.Load<Sprite>("weatherIcons/" + iconName);

            //アイコン画像が読み込まれたかチェックし、読み込まれてたらアイコンを表示させる。
            if (icon != null) {
                weatherIcon.sprite = icon;
                weatherIcon.enabled = true;
            }
        }
    }

    /// <summary>
    /// 天気に応じたアイコン名を返す処理
    /// </summary>
    /// <param name="weatherDescription"></param>
    /// <returns></returns>
    public string GetIconName(string weatherDescription) {
        switch (weatherDescription) {         
            case "Clear"://晴れ
            return "sunny";
           
            case "Clouds"://曇り
            return "cloudy";
           
            case "Rain"://雨
            return "rainy";

            case "Thunderstorm"://雷雨
            return "Thunder";


            case "Drizzle"://霧雨
                return "mist";

            case "Squall"://嵐
                return "arashi";

            case "Tornado"://台風
                return "Tornado";

            case "Snow"://雪
                return "snowy";

            default:
                return ""; //デフォルトのアイコン名を設定
        }
    }
}
