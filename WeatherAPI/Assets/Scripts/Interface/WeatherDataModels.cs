using System;
using System.Collections.Generic;

/// <summary>
/// サーバからのデータを格納しているインターフェース
/// WARNING : Json側のデータの名前と一致したものを書かなければ動かないので、
///           名前が一致しているかどうか確認する。
/// </summary>
[Serializable]
public class WeatherResponse : IWeatherResponse {
    public string name;//地名のデータ
    public Main main;
    public Wind wind;
    public List<Weather> weather;
    public long dt;//最終更新時間（観測時間）のデータ

    //IWeatherResponseインターフェースの実装
    string IWeatherResponse.Name => name;
    IMain IWeatherResponse.Main => main;
    IWind IWeatherResponse.Wind => wind;
    List<IWeather> IWeatherResponse.Weather => weather.ConvertAll(w => (IWeather)w);
    long IWeatherResponse.Timestamp => dt;
}

[Serializable]
public class Main : IMain {
    public float temp;//気温のデータ
    public float temp_min;//最低気温のデータ
    public float temp_max;//最高気温のデータ
    public int humidity;//湿度のデータ
    float IMain.Temp => temp;
    float IMain.TempMin => temp_min;
    float IMain.TempMax => temp_max;
    int IMain.Humidity => humidity;
}

[Serializable]
public class Wind : IWind {
    public float speed;//風速
    public int deg;//風向き

    float IWind.Speed => speed;
    int IWind.Deg => deg;
}

[Serializable]
public class Weather : IWeather {
    public string main;//天気の情報
    string IWeather.WeatherMain => main;
}