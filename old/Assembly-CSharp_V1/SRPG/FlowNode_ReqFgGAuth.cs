﻿// Decompiled with JetBrains decompiler
// Type: SRPG.FlowNode_ReqFgGAuth
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using GR;
using UnityEngine;

namespace SRPG
{
  [FlowNode.NodeType("System/ReqFgGAuth", 32741)]
  [FlowNode.Pin(2, "Success", FlowNode.PinTypes.Output, 1)]
  [FlowNode.Pin(1, "Request", FlowNode.PinTypes.Input, 0)]
  public class FlowNode_ReqFgGAuth : FlowNode_Network
  {
    private const int PIN_ID_REQUEST = 1;
    private const int PIN_ID_SUCCESS = 2;
    private ReqFgGAuth.eAuthStatus mAuthStatusBefore;

    public override void OnActivate(int pinID)
    {
      if (pinID != 1 || ((Behaviour) this).get_enabled())
        return;
      this.mAuthStatusBefore = MonoSingleton<GameManager>.Instance.AuthStatus;
      this.ExecRequest((WebAPI) new ReqFgGAuth(new Network.ResponseCallback(((FlowNode_Network) this).ResponseCallback)));
      ((Behaviour) this).set_enabled(true);
    }

    private void Success(ReqFgGAuth.eAuthStatus authStatus)
    {
      MonoSingleton<GameManager>.Instance.AuthStatus = authStatus;
      ((Behaviour) this).set_enabled(false);
      this.ActivateOutputLinks(2);
    }

    private bool CheckStatusChanged(ReqFgGAuth.eAuthStatus status)
    {
      if (this.mAuthStatusBefore == ReqFgGAuth.eAuthStatus.None)
        return false;
      return this.mAuthStatusBefore != status;
    }

    public override void OnSuccess(WWWResult www)
    {
      if (Network.IsError)
      {
        Network.EErrCode errCode = Network.ErrCode;
        this.OnFailed();
      }
      else
      {
        WebAPI.JSON_BodyResponse<FlowNode_ReqFgGAuth.JSON_FgGAuth> jsonObject = JSONParser.parseJSONObject<WebAPI.JSON_BodyResponse<FlowNode_ReqFgGAuth.JSON_FgGAuth>>(www.text);
        DebugUtility.Assert(jsonObject != null, "res == null");
        int authStatus = jsonObject.body.auth_status;
        MonoSingleton<GameManager>.Instance.FgGAuthHost = jsonObject.body.auth_url;
        Network.RemoveAPI();
        switch (authStatus)
        {
          case 1:
            this.Success(ReqFgGAuth.eAuthStatus.Disable);
            break;
          case 2:
            this.Success(ReqFgGAuth.eAuthStatus.NotSynchronized);
            break;
          case 3:
            this.Success(ReqFgGAuth.eAuthStatus.Synchronized);
            if (GameUtility.GetCurrentScene() != GameUtility.EScene.HOME || !this.CheckStatusChanged(ReqFgGAuth.eAuthStatus.Synchronized))
              break;
            MonoSingleton<GameManager>.Instance.Player.OnFgGIDLogin();
            break;
          default:
            this.OnFailed();
            break;
        }
      }
    }

    private class JSON_FgGAuth
    {
      public int auth_status;
      public string auth_url;
    }
  }
}
