using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UniRx;

public class ButtonResponsibility : MonoBehaviour {
	private WeatherService weatherService;
	private DisplayWeatherInfo displayWeatherInfo;
	private int cityId;

	public void Initialize(WeatherService weatherService, DisplayWeatherInfo displayWeatherInfo, int cityId) {
		this.weatherService = weatherService;
		this.displayWeatherInfo = displayWeatherInfo;
		this.cityId = cityId;
	}

	public void SetButton(Button button) {
		button.OnClickAsObservable()
			.Subscribe(_ => StartCoroutine(weatherService.GetWeather(cityId, displayWeatherInfo.WeatherInfo)))
			.AddTo(this);
	}
}