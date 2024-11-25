/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
 * Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 *
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Gs2.Installer
{
    public class LocalStateMachineKitInstaller : EditorWindow
    {
        private Status _status = Status.Present;
        
        private AddRequest addRequest;
        private ListRequest listRequest;
        
        [MenuItem ("Window/Game Server Services/LocalStateMachineKit for Unity Installer", priority = 3)]
        public static void Open ()
        {
            GetWindowWithRect<LocalStateMachineKitInstaller>(new Rect(0, 0, 700, 350), true, "LocalStateMachineKit-Installer");
        }

        void OnGUI() {
            GUILayout.Label("Game Server Services LocalStateMachineKit for Unity のインストールを開始します。");
            GUILayout.Label("");
            GUILayout.Label("インストールには Unity Package Manager を利用します。");
            GUILayout.Label("");
            GUILayout.Label("Begin installation of Game Server Services LocalStateMachineKit for Unity.");
            GUILayout.Label("");
            GUILayout.Label("The Unity Package Manager is used for installation.");
            GUILayout.Label("");
            
            switch (_status)
            {
                case Status.Present:
                    if (GUILayout.Button("Install"))
                    {
                        _status = Status.ImportScopedRegistry;
                    }
                    break;
                case Status.AddPackage:
                case Status.WaitingAddPackage:
                case Status.Installing:
                    GUILayout.Button("Installing... Please wait a moment.");
                    break;
                case Status.InstallComplete:
                    GUILayout.Label("インストールが完了しました。");
                    GUILayout.Label("");
                    GUILayout.Label("Installation is complete.");
                    GUILayout.Label("");
                    if (GUILayout.Button("Close"))
                    {
                        Close();
                    }
                    break;
            }
        }
        
        void Update()
        {
            switch (_status)
            {
                case Status.Present:
                    break;
                    
                case Status.ImportScopedRegistry:
                    if (!WelcomeWindow.IsImportedScopedRegistry())
                    {
                        WelcomeWindow.AddScopedRegistry(new WelcomeWindow.ScopedRegistry
                        {
                            name = "Game Server Services",
                            url = "https://upm.gs2.io/npm",
                            scopes = new string[]
                            {
                                "io.gs2"
                            }
                        });
                    }
                    _status = Status.AddPackage;
                    break;
                case Status.AddPackage:
                    addRequest = Client.Add("io.gs2.unity.sdk.local-state-machine-kit");
                    _status = Status.WaitingAddPackage;
                    break;
                case Status.WaitingAddPackage:
                    if (addRequest == null)
                    {
                        _status = Status.Present;
                        return;
                    }
                    
                    if (addRequest.IsCompleted)
                    {
                        if (addRequest.Status == StatusCode.Success)
                        {
                            listRequest = Client.List();
                            _status = Status.Installing;
                        }
                        else if (addRequest.Status >= StatusCode.Failure)
                        {
                            Debug.Log(addRequest.Error.message);
                            _status = Status.Present;
                        }
                    }
                    break;
                case Status.Installing:
                    if (listRequest == null)
                    {
                        listRequest = Client.List();
                    }
                    if (listRequest.IsCompleted)
                    {
                        if (listRequest.Status == StatusCode.Success)
                        {
                            if (listRequest.Result.Count(item => item.name == "io.gs2.unity.sdk.local-state-machine-kit") > 0)
                            {
                                _status = Status.InstallComplete;
                            }
                            else if (listRequest.Status >= StatusCode.Failure)
                            {
                                Debug.Log(addRequest.Error.message);
                                _status = Status.Present;
                            }
                        }
                        else if (addRequest.Status >= StatusCode.Failure)
                        {
                            Debug.Log(addRequest.Error.message);
                            _status = Status.Present;
                        }
                    }
                    break;                   
            }        
        }
    }
}