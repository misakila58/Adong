﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseScreen;

    public Text BGMValue;
    public Text SFXValue;

    public AudioMixer mixer;

    void Start()
    {
        mixer.SetFloat("BGMVolume", PlayerPrefs.GetFloat("BGMVolume"));
        mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
    }

    void Update()
    {
        BGMValue.text = $"{PlayerPrefs.GetFloat("BGMVolume") + 20}";
        SFXValue.text = $"{PlayerPrefs.GetFloat("SFXVolume") + 20}";
    }

    public void PauseGame()
    {
        if (!pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
            GamePaused = true;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
            GamePaused = false;
        }
        AudioManager.instance.Play("touch");
    }

    public void Resume()
    {
        AudioManager.instance.Play("touch");
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;
    }

    public void Menu()
    {
        AudioManager.instance.Play("touch");
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;
        SceneManager.LoadScene(0);
    }

    public void BGMLeftButton()
    {
        AudioManager.instance.Play("touch");
        mixer.SetFloat("BGMVolume", PlayerPrefs.GetFloat("BGMVolume") - 2);
        PlayerPrefs.SetFloat("BGMVolume", PlayerPrefs.GetFloat("BGMVolume") - 2);
    }
    public void BGMRightButton()
    {
        AudioManager.instance.Play("touch");
        mixer.SetFloat("BGMVolume", PlayerPrefs.GetFloat("BGMVolume") + 2);
        PlayerPrefs.SetFloat("BGMVolume", PlayerPrefs.GetFloat("BGMVolume") + 2);
    }

    public void SFXLeftButton()
    {
        AudioManager.instance.Play("touch");
        mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume") - 2);
        PlayerPrefs.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume") - 2);
    }
    public void SFXRightButton()
    {
        AudioManager.instance.Play("touch");
        mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume") + 2);
        PlayerPrefs.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume") + 2);
    }
}