using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour
{
    private GameObject optionsPanel;
    private Animator optionsAC;

    public AudioMixer gameMixer;
    public Slider musicSlider, SFXSlider;

    public Animator transitionAC;
    public float transitionTime = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        optionsPanel = GameObject.Find("OptionsPanel");
        optionsAC = optionsPanel.GetComponent<Animator>();
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            SFXSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        }
        setMusicVolume();
        setSFXVolume();
    }

    public void loadScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        transitionAC.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }

    public void quitGame()
    {
        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            Application.Quit();
        }

    }

    public void toggleOptions()
    {
        optionsAC.SetBool("open", !optionsAC.GetBool("open"));
    }
    public void resetTutorial()
    {
        PlayerPrefs.SetInt("tutorialEnabled", 0);
    }

    public void setMusicVolume()
    {
        float volume = musicSlider.value;
        gameMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void setSFXVolume()
    {
        float volume = SFXSlider.value;
        gameMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }


}
