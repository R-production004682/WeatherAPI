using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


/// <summary>
/// �V�C���̎擾�����Ă���N���X�B
/// </summary>
public class WeatherService
{
    private const string apikey = "d8bb2adf4f5044b1c4b1cb4a08b11a50";

    /*NOTE : URL�̑g�ݗ��ĕ� : https://api.openweathermap.org/data/2.5/weather?id=�s�s�R�[�h&appid=API Key
     API Key�́A���̂܂܏������璷���̂ŁA�u�������邽��{1}�Ŏw��B
    �u'units=metric'�v�Őێ��ŉ��x���擾���邱�Ƃ��ł���B*/
    private const string apiUrl = "https://api.openweathermap.org/data/2.5/weather?id={0}&appid={1}&units=metric";


    /// <summary>
    /// HTTP�ʐM�̏����B�V�C���擾���邽�߂̃R���[�`���B
    /// </summary>
    /// <param name="cityid">�s�s�ԍ�</param>
    /// <param name="callback">�V�C���擾��ɌĂяo���R�[���o�b�N�֐�
    /// �iGameManager.cs��DisplayWeatherInfo���i�[����j</param>
    /// <returns>�R���[�`��</returns>
    public IEnumerator GetWeather(int cityid , Action<IWeatherResponse> callback) {
        string url = string.Format(apiUrl, cityid , apikey);
        Debug.Log($"Request URL : {url}");

        using (UnityWebRequest request = UnityWebRequest.Get(url)) {
            yield return request.SendWebRequest();//HTTP�ɐڑ����鏈��

            if (request.result == UnityWebRequest.Result.ConnectionError ||
                request.result == UnityWebRequest.Result.ProtocolError) {
                //�f�o�b�O�̂��߂ɁA�ڑ��G���[�ƃv���g�R���̃G���[�ԍ����R���\�[���ɏo��
                Debug.Log($"Error : {request.error} , Status Code : {request.responseCode}");
                callback?.Invoke(null);//callback��null�ȊO�̂Ƃ��A������ʂ��B
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
                    //�f�V���A���C�Y�̃G���[�n���h�����O
                    Debug.LogError($"Desirialization error : {ex.Message}");
                    callback?.Invoke(null);
                    yield break;
                }
                callback?.Invoke(response);
            }
        }
    }
}


/*NOTE : �ȉ��̃C���^�[�t�F�[�X�́A�O����API�ƒʐM���A
WeatherDataModels�Œ�`���ꂽ�f�[�^�ƃ}�b�s���O���ĕԂ�����*/

/// <summary>
/// �V�C���̃��X�|���X�C���^�[�t�F�[�X
/// </summary>
public interface IWeatherResponse {
    string Name { get; }
    IMain Main { get; }
    IWind Wind { get; }

    List<IWeather> Weather { get; }
    long Timestamp { get; }
}

/// <summary>
/// ���C���V�C���i�C���j�̃C���^�[�t�F�[�X
/// </summary>
public interface IMain {
    float Temp { get; }
    float TempMin { get; }
    float TempMax { get; }
    int Humidity { get; }
}

/// <summary>
/// ���̏����󂯎��C���^�[�t�F�[�X�B
/// </summary>
public interface IWind {
    float Speed { get; }
    int Deg { get; }
}

/// <summary>
/// �V�C�ڍ׏��i�����A�܂�Ȃǂ̃f�[�^�j�̃C���^�[�t�F�[�X�B
/// </summary>
public interface IWeather {
    string WeatherMain { get; }
}