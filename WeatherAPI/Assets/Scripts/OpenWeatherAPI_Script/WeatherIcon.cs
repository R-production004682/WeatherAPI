using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �A�C�R�����擾����N���X�B
/// </summary>
public class WeatherIcon {
    private Image weatherIcon;

    /// <summary>
    /// �R���X�g���N�^�B
    /// </summary>
    /// <param name="weatherIcon">�V�C�A�C�R����\������Image�I�u�W�F�N�g</param>
    public WeatherIcon(Image weatherIcon) {
        this.weatherIcon = weatherIcon;
    }


    /// <summary>
    /// �V�C�̉摜��\�����鏈��
    /// </summary>
    public void SetWeatherIcon(string weatherDescription) {
        string iconName = GetIconName(weatherDescription); //�V�C�ɉ������A�C�R�������擾

        //�A�C�R�������󂶂�Ȃ����̃`�F�b�N�B�󂶂�Ȃ�������AResources/weatherIcons�t�H���_����摜��ǂݍ��ށB
        if (!string.IsNullOrEmpty(iconName)) {
            Sprite icon = Resources.Load<Sprite>("weatherIcons/" + iconName);

            //�A�C�R���摜���ǂݍ��܂ꂽ���`�F�b�N���A�ǂݍ��܂�Ă���A�C�R����\��������B
            if (icon != null) {
                weatherIcon.sprite = icon;
                weatherIcon.enabled = true;
            }
        }
    }

    /// <summary>
    /// �V�C�ɉ������A�C�R������Ԃ�����
    /// </summary>
    /// <param name="weatherDescription"></param>
    /// <returns></returns>
    public string GetIconName(string weatherDescription) {
        switch (weatherDescription) {         
            case "Clear"://����
            return "sunny";
           
            case "Clouds"://�܂�
            return "cloudy";
           
            case "Rain"://�J
            return "rainy";

            case "Thunderstorm"://���J
            return "Thunder";


            case "Drizzle"://���J
                return "mist";

            case "Squall"://��
                return "arashi";

            case "Tornado"://�䕗
                return "Tornado";

            case "Snow"://��
                return "snowy";

            default:
                return ""; //�f�t�H���g�̃A�C�R������ݒ�
        }
    }
}
