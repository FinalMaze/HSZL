using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region 单例模式
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get { return instance; }
    }
    #endregion

    ClipManager clipManager;
    SourceManager sourceManager;
    private void Awake()
    {
        instance = this;
        clipManager = new ClipManager();
        sourceManager = new SourceManager(gameObject);
        InvokeRepeating("DelFreeSource", 10, 5);
    }

    #region 播放音频
    public void StartAudio(string audioName)
    {
        AudioClip clip = clipManager.GetClip(audioName);
        AudioSource source = sourceManager.GetFreeSource();
        source.clip = clip;
        source.Play();
    }
    #endregion

    #region 停止播放指定音频
    public void StopAudio(string audioName)
    {
        sourceManager.GetSourceByClip(audioName).Stop();
        sourceManager.GetSourceByClip(audioName).clip = null;
    }
    #endregion

    #region 循环播放BGM
    public void LoopBGM(string bgmName)
    {
        // to do
    }
    #endregion

    #region 释放多余的音频播放器
    public void DelFreeSource()
    {
        sourceManager.DelSurplusSource();
    }
    #endregion
}
