using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


/// <summary>
/// 天気情報の取得をしているクラス。
/// </summary>
public class WeatherService
{
    private const string apikey = "d8bb2adf4f5044b1c4b1cb4a08b11a50";

    /*NOTE : URLの組み立て方 : https://api.openweathermap.org/data/2.5/weather?id=都市コード&appid=API Key
     API Keyは、そのまま書いたら長いので、置き換えるため{1}で指定。
    「'units=metric'」で摂氏で温度を取得することができる。*/
    private const string apiUrl = "https://api.openweathermap.org/data/2.5/weather?id={0}&appid={1}&units=metric";


    /// <summary>
    /// HTTP通信の処理。天気を取得するためのコルーチン。
    /// </summary>
    /// <param name="cityid">都市番号</param>
    /// <param name="callback">天気情報取得後に呼び出すコールバック関数
    /// （GameManager.csのDisplayWeatherInfoを格納する）</param>
    /// <returns>コルーチン</returns>
    public IEnumerator GetWeather(int cityid , Action<IWeatherResponse> callback) {
        string url = string.Format(apiUrl, cityid , apikey);
        Debug.Log($"Request URL : {url}");

        using (UnityWebRequest request = UnityWebRequest.Get(url)) {
            yield return request.SendWebRequest();//HTTPに接続する処理

            if (request.result == UnityWebRequest.Result.ConnectionError ||
                request.result == UnityWebRequest.Result.ProtocolError) {
                //デバッグのために、接続エラーとプロトコルのエラー番号をコンソールに出力
                Debug.Log($"Error : {request.error} , Status Code : {request.responseCode}");
                callback?.Invoke(null);//callbackがnull以外のとき、処理を通す。
            }
            else {
                Debug.Log($"Response : {request.downloadHandler.text}");
                WeatherResponse response;
                try {
                    response = JsonUtility.FromJson<WeatherResponse>(request.downloadHandler.text);

                    if (response == null) {
                        Debug.LogError($"Desirialization response is null");
                    }
                }
                catch (System.Exception ex) {
                    //デシリアライズのエラーハンドリング
                    Debug.LogError($"Desirialization error : {ex.Message}");
                    callback?.Invoke(null);
                    yield break;
                }
                callback?.Invoke(response);
            }
        }
    }
}


/*NOTE : 以下のインターフェースは、外部のAPIと通信し、
WeatherDataModelsで定義されたデータとマッピングして返す役割*/

/// <summary>
/// 天気情報のレスポンスインターフェース
/// </summary>
public interface IWeatherResponse {
    string Name { get; }
    IMain Main { get; }
    IWind Wind { get; }

    List<IWeather> Weather { get; }
    long Timestamp { get; }
}

/// <summary>
/// メイン天気情報（気温）のインターフェース
/// </summary>
public interface IMain {
    float Temp { get; }
    float TempMin { get; }
    float TempMax { get; }
    int Humidity { get; }
}

/// <summary>
/// 風の情報を受け取るインターフェース。
/// </summary>
public interface IWind {
    float Speed { get; }
    int Deg { get; }
}

/// <summary>
/// 天気詳細情報（晴れや、曇りなどのデータ）のインターフェース。
/// </summary>
public interface IWeather {
    string WeatherMain { get; }
}