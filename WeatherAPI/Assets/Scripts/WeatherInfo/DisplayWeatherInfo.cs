using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWeatherInfo : MonoBehaviour
{
    [Header("�{�^���������ꂽ�ۂ́A�V�C�̏ڍׂ�\��������p�l����ݒ�")]
    [SerializeField] private GameObject weatherInfoPanel;�@�@//�V�C����\������p�l��


    [Header("�\������V�C�̏ڍ׏���Text��ݒ�")]
    [SerializeField] private TextMeshProUGUI locationText; �@//�ꏊ��\������TextMeshProUGUI
    [SerializeField] private TextMeshProUGUI temperatureText;//�C����\������TextMeshProUGUI
    [SerializeField] private TextMeshProUGUI weatherText; �@ //�V�C��\������TextMeshProUGUI
    [SerializeField] private TextMeshProUGUI windText;       //������\������TextMeshProUGUI
    [SerializeField] private TextMeshProUGUI windDirectionText; //��������\������TextMeshProUGUI
    [SerializeField] private TextMeshProUGUI maximumTemperatureText; //�ō��C����\������TextMeshProUGUI
    [SerializeField] private TextMeshProUGUI minimumTemperatureText; //�Œ�C����\������TextMeshProUGUI
    [SerializeField] private TextMeshProUGUI timeStampText; //�V�C�f�[�^�̍X�V������\������TextMeshProUGUI
    [SerializeField] private Image weatherImage; //�V�C�̉摜��\������摜��ݒ�


    [SerializeField] private WeatherWind weatherWind;//���̌����𒲂ׂ�
    [SerializeField] private WeatherIcon weatherIcon;//�V�C�A�C�R���ݒ�


    private void Start () {
        weatherWind = new WeatherWind();
        weatherIcon = new WeatherIcon(weatherImage);
    }


    /// <summary>
    /// OpenWeatherAPI������󂯎��V�C�̏���UI�ɑΉ������鏈��
    /// </summary>
    /// <param name="response">�V�C�����̃��X�|���X</param>
    public void WeatherInfo ( IWeatherResponse response ) {
        //�������𒲂ׂ�
        string windDirection = weatherWind.GetWindDirection(response.Wind.Deg);

        //Start location----------------------------------------------
        locationText.text = $"�ꏊ : {response.Name}";
        //end of location---------------------------------------------


        //Start Temp--------------------------------------------------
        temperatureText.text = $"�C�� : {response.Main.Temp}��";


        //�ō��Œ�C���̐F����
        if ( response.Main.TempMax > response.Main.TempMin ) {
            maximumTemperatureText.color = Color.red;
            minimumTemperatureText.color = Color.blue;
        }
        else {
            maximumTemperatureText.color = Color.black;
            minimumTemperatureText.color = Color.black;
        }

        maximumTemperatureText.text = $"�ō��C�� {response.Main.TempMax}��";
        minimumTemperatureText.text = $"�Œ�C�� {response.Main.TempMin}��";
        //end of Temp--------------------------------------------------


        //Start Weather------------------------------------------------
        weatherText.text = $"�V�C : {response.Weather[0].WeatherMain}";
        weatherIcon.SetWeatherIcon(response.Weather[0].WeatherMain);
        //end of Weather-----------------------------------------------


        //Start Wind---------------------------------------------------
        windDirectionText.text = $"������ : {windDirection}";
        windText.text = $"���� : {response.Wind.Speed}m/s";
        //end of Wind--------------------------------------------------


        //Start TimeStamp----------------------------------------------
        long timestamp = response.Timestamp;
        DateTimeOffset observationTime = DateTimeOffset.FromUnixTimeSeconds(timestamp);
        DateTime localTime = observationTime.LocalDateTime;
        string observationTimeString = localTime.ToString("yyyy/MM/dd HH:mm" + "����");
        timeStampText.text = $"�ϑ����� : {observationTimeString}";
        //end of Timestamp---------------------------------------------
    }
}

