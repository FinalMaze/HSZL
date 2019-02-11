using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceManager
{
    #region 构造函数初始化
    GameObject tmpObj;
    public SourceManager(GameObject obj)
    {
        tmpObj = obj;
        Initial(obj);
    }
    void Initial(GameObject obj)
    {
        for (int i = 0; i < 3; i++)
        {
            AudioSource source = obj.AddComponent<AudioSource>();
            audioSourceList.Add(source);
        }
    }
    #endregion

    #region 集合
    private List<AudioSource> audioSourceList = new List<AudioSource>();
    private List<AudioSource> tempList = new List<AudioSource>();
    #endregion

    #region 得到一个空闲的音频播放器
    public AudioSource GetFreeSource()
    {
        for (int i = 0; i < audioSourceList.Count; i++)
        {
            if (audioSourceList[i].clip == null)
            {
                return audioSourceList[i];
            }
        }
        AudioSource source = tmpObj.AddComponent<AudioSource>();
        audioSourceList.Add(source);
        return source;
    }
    #endregion

    #region 根据音频名称得到音频播放器
    public AudioSource GetSourceByClip(string clipName)
    {
        foreach (AudioSource source in audioSourceList)
        {
            if (source.clip.name == clipName)
            {
                return source;
            }
        }
        Debug.LogWarning("没有找到音频名称为" + clipName + "的播放器");
        return null;
    }
    #endregion

    #region 删除多余的空闲音频播放器
    public void DelSurplusSource()
    {
        int count = 0;
        for (int i = 0; i < audioSourceList.Count; i++)
        {
            if (!audioSourceList[i].isPlaying)
            {
                count++;
                audioSourceList[i].clip = null;
                if (count > 3)
                {
                    tempList.Add(audioSourceList[i]);
                }
            }
        }
        if (tempList.Count>0)
        {
            for (int i = 0; i < tempList.Count; i++)
            {
                DelSource(tempList[i]);
            }
            tempList.Clear();
        }
    }

    public void DelSource(AudioSource source)
    {
        audioSourceList.Remove(source);
        GameObject.Destroy(source);
    }

    #endregion
}
