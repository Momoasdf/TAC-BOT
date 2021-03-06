﻿// Decompiled with JetBrains decompiler
// Type: SRPG.LimitedShopLock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85BFDF7F-5712-4D45-9CD6-3465C703DFDF
// Assembly location: S:\Desktop\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

namespace SRPG
{
  [RequireComponent(typeof (Selectable))]
  public class LimitedShopLock : MonoBehaviour
  {
    [SerializeField]
    private GameObject LockObject;
    private Button mButton;

    public LimitedShopLock()
    {
      base.\u002Ector();
    }

    private void Awake()
    {
      Button component = (Button) ((Component) this).GetComponent<Button>();
      if (!Object.op_Inequality((Object) component, (Object) null))
        return;
      this.mButton = component;
    }

    private void Start()
    {
      this.UpdateLockState();
    }

    private void UpdateLockState()
    {
      if (Object.op_Equality((Object) this.mButton, (Object) null))
        return;
      this.LockObject.SetActive(!((Selectable) this.mButton).get_interactable());
    }
  }
}
