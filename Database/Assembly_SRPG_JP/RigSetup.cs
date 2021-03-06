﻿// Decompiled with JetBrains decompiler
// Type: SRPG.RigSetup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85BFDF7F-5712-4D45-9CD6-3465C703DFDF
// Assembly location: S:\Desktop\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

namespace SRPG
{
  public class RigSetup : ScriptableObject
  {
    public string RootBoneName;
    public RigSetup.SkeletonInfo[] Skeletons;
    public string LeftHand;
    public List<string> LeftHandChangeLists;
    public string RightHand;
    public List<string> RightHandChangeLists;
    public List<string> OptionAttachLists;
    public float EquipmentScale;
    [Description("この骨格の基準となる身長です")]
    public float Height;
    public string Head;

    public RigSetup()
    {
      base.\u002Ector();
    }

    [Serializable]
    public class BoneInfo
    {
      public string name = string.Empty;
      public Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f);
      public Vector3 scale = new Vector3(1f, 1f, 1f);
    }

    [Serializable]
    public class SkeletonInfo
    {
      public string name = string.Empty;
      public RigSetup.BoneInfo[] bones = new RigSetup.BoneInfo[0];
    }
  }
}
