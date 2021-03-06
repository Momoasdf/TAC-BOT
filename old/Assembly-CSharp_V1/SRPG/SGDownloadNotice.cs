﻿// Decompiled with JetBrains decompiler
// Type: SRPG.SGDownloadNotice
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

namespace SRPG
{
  public class SGDownloadNotice : MonoBehaviour
  {
    [SerializeField]
    private SRPG_Button m_decideButton;
    [SerializeField]
    private Toggle m_agreeToggle;
    [SerializeField]
    private Toggle m_bgdlcToggle;

    public SGDownloadNotice()
    {
      base.\u002Ector();
    }

    private void Start()
    {
      ((Selectable) this.m_decideButton).set_interactable(false);
      this.m_bgdlcToggle.set_isOn(BackgroundDownloader.Instance.IsEnabled);
    }

    public void OnTermsOfUseAgreed()
    {
      ((Selectable) this.m_decideButton).set_interactable(this.m_agreeToggle.get_isOn());
    }

    public void OnBackgroundDownloadAgreed()
    {
      BackgroundDownloader.Instance.IsEnabled = this.m_bgdlcToggle.get_isOn();
    }
  }
}
