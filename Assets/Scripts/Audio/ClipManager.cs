using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipManager
{
    #region 构造函数初始化
    public ClipManager()
    {
        Initial();
    }
    private string path;
    public void Initial()
    {
        foreach (string clip in allClipName)
        {
            path = "Audio/" + clip;
            AudioClip temp = Resources.Load(path) as AudioClip;
            allClip.Add(temp);
        }
    }
    #endregion

    #region 集合
    private static string[] allClipName = Enum.GetNames(typeof(AudioData.Clip));
    private static List<AudioClip> allClip = new List<AudioClip>();
    #endregion

    #region 根据音频名称得到音频
    public AudioClip GetClip(string clipName)
    {
        foreach (AudioClip clip in allClip)
        {
            if (clip.name == clipName)
            {
                return clip;
            }
        }
        return null;
    }
    #endregion
}
