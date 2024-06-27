using UnityEngine;

public class WeatherController : MonoBehaviour {
	private WeatherService weatherService;
	private DisplayWeatherInfo displayWeatherInfo;

	public void Initialize(WeatherService weatherService, DisplayWeatherInfo displayWeatherInfo) {
		this.weatherService = weatherService;
		this.displayWeatherInfo = displayWeatherInfo;
	}

	public void StartWeatherCoroutine(int cityId) {
		if (gameObject.activeInHierarchy) {
			StartCoroutine(weatherService.GetWeather(cityId, displayWeatherInfo.WeatherInfo));
		}
		else {
			Debug.LogError("The game object is not active, cannot start coroutine.");
		}
	}
}