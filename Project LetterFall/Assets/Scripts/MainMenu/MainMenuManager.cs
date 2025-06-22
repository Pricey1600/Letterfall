using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private GameObject optionsPanel;
    private Animator optionsAC;

    public AudioMixer gameMixer;
    public Slider musicSlider, SFXSlider;

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

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
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
