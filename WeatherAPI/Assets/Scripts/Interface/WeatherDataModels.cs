using System;
using System.Collections.Generic;

/// <summary>
/// �T�[�o����̃f�[�^���i�[���Ă���C���^�[�t�F�[�X
/// WARNING : Json���̃f�[�^�̖��O�ƈ�v�������̂������Ȃ���Γ����Ȃ��̂ŁA
///           ���O����v���Ă��邩�ǂ����m�F����B
/// </summary>
[Serializable]
public class WeatherResponse : IWeatherResponse {
    public string name;//�n���̃f�[�^
    public Main main;
    public Wind wind;
    public List<Weather> weather;
    public long dt;//�ŏI�X�V���ԁi�ϑ����ԁj�̃f�[�^

    //IWeatherResponse�C���^�[�t�F�[�X�̎���
    string IWeatherResponse.Name => name;
    IMain IWeatherResponse.Main => main;
    IWind IWeatherResponse.Wind => wind;
    List<IWeather> IWeatherResponse.Weather => weather.ConvertAll(w => (IWeather)w);
    long IWeatherResponse.Timestamp => dt;
}

[Serializable]
public class Main : IMain {
    public float temp;//�C���̃f�[�^
    public float temp_min;//�Œ�C���̃f�[�^
    public float temp_max;//�ō��C���̃f�[�^
    public int humidity;//���x�̃f�[�^
    float IMain.Temp => temp;
    float IMain.TempMin => temp_min;
    float IMain.TempMax => temp_max;
    int IMain.Humidity => humidity;
}

[Serializable]
public class Wind : IWind {
    public float speed;//����
    public int deg;//������

    float IWind.Speed => speed;
    int IWind.Deg => deg;
}

[Serializable]
public class Weather : IWeather {
    public string main;//�V�C�̏��
    string IWeather.WeatherMain => main;
}