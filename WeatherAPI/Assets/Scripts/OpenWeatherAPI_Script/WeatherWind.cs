using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  風の方角を取得するクラス
/// </summary>
public class WeatherWind{
    /// <summary>
    /// 風向きを返す処理
    /// </summary>
    /// <param name="degrees"></param>
    /// <returns></returns>
    public string GetWindDirection(int degrees) {
        string[] direction = 
        {
            "北"     ,
            "北北東" ,
            "北東"   ,
            "東北東" ,
            "東"     ,
            "東南東" ,
            "南東"   ,
            "南南東" , 
            "南"     ,
            "南南西" , 
            "南西"   ,
            "西南西" ,
            "西"     ,
            "西北西" ,
            "北西"   ,
            "北北西"
        };

        /*NOTE : 方位の基準を16方位として考えた。
         北の角度が0度から始まるので、degreesに、11.25度を加えて角度をずらす。
         そして、22.5度ごとに角度を区切り、最後に16方位で乗算すると、配列のインデックスに該当するindexが求まる。*/
        int index = (int)((degrees + 11.25f) / 22.5f) % 16;
        return direction[index];
    }
}
