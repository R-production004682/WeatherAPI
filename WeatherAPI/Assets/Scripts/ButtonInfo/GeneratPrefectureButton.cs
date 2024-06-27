using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneratPrefectureButton : MonoBehaviour
{
	[Header("47都道府県分の複製するボタンの設定")]
	[SerializeField, Tooltip("ボタンのプレハブを格納")] private GameObject buttonPrefab;
	[SerializeField, Tooltip("ボタンの生成間隔を調整")] private int generateInterval = 30;

	private const int FIRST_GENERATE_POSITION = 16;

	[SerializeField] private PrefectureCityData prefectureCityData;
	[SerializeField] private ButtonResponsibility buttonResponsibilityPrefab;
	[SerializeField] private DisplayWeatherInfo displayWeatherInfo;

	private WeatherService weatherService;

	private void Awake() {
		weatherService = new WeatherService();
	}

	private void Start() {
		int generatePosition = FIRST_GENERATE_POSITION;

		foreach (var prefectureData in prefectureCityData.PrefectureList) {
			GameObject buttonObject = Instantiate(buttonPrefab);
			InitializeButton(buttonObject, prefectureData.prefectureName, generatePosition, prefectureData.prefectureCityID);
			generatePosition += generateInterval;
		}
	}

	private void InitializeButton(GameObject buttonObject, string buttonText, int generatePosition, int cityId) {
		buttonObject.transform.SetParent(this.transform);
		buttonObject.transform.localPosition = new Vector3(0, generatePosition, 0);
		buttonObject.transform.localRotation = Quaternion.identity;
		buttonObject.transform.localScale = Vector3.one * 0.9f;

		TextMeshProUGUI buttonTextMeshPro = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
		if (buttonTextMeshPro != null) {
			buttonTextMeshPro.text = buttonText;
		}

		Button buttonComponent = buttonObject.GetComponent<Button>();
		ButtonResponsibility buttonResponsibilityInstance = buttonObject.AddComponent<ButtonResponsibility>();
		buttonResponsibilityInstance.Initialize(weatherService, displayWeatherInfo, cityId);
		buttonResponsibilityInstance.SetButton(buttonComponent);
	}
}
