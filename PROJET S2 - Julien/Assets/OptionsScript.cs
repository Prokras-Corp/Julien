using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
	public AudioMixer mixer;

	public Dropdown resolutionDropdown;
	Resolution[] resolutions;
	void Start()
	{
		resolutions = Screen.resolutions;
		resolutionDropdown.ClearOptions();

		int currentResIndex = 0;
		List<string> options = new List<string>();
		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + "x" + resolutions[i].height;
			options.Add(option);
			
			if (resolutions[i].width == Screen.currentResolution.width &&
			    resolutions[i].height == Screen.currentResolution.height)
			{
				currentResIndex = i;
			}
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResIndex;
		resolutionDropdown.RefreshShownValue();
	}


	public void SetResolution(int ResolutionIndex)
	{
		Resolution resolution = resolutions[ResolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}
	
	public void SetVolume(float volume)
	{
		mixer.SetFloat("Volume", volume);
	}

	public void SetQuality(int index)
	{
		QualitySettings.SetQualityLevel(index);
	}

	public void SetFullscreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}
}
