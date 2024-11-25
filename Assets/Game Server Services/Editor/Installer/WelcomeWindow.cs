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
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Gs2.Installer
{
    enum SdkStatus
    {
        Present,
        ImportScopedRegistry,
        AddCSharpPackage,
        WaitingAddCSharpPackage,
        AddUnityPackage,
        WaitingAddUnityPackage,
        Installing,
        InstallComplete,
    }
    
    public class WelcomeWindow : EditorWindow
    {
        private SdkStatus _status = SdkStatus.Present;

        static AddRequest addRequest;
        static ListRequest listRequest;
        
        [MenuItem ("Window/Game Server Services/SDK Installer", priority = 1)]
        public static void Open ()
        {
            GetWindowWithRect<WelcomeWindow>(new Rect(0, 0, 700, 350), true, "GS2 SDK-Installer");
        }

        void OnGUI() {
            GUILayout.Label("Game Server Services SDK for Unity のインストールを開始します。");
            GUILayout.Label("");
            GUILayout.Label("インストールには Unity Package Manager を利用します。");
            GUILayout.Label("");
            GUILayout.Label("");
            GUILayout.Label("Begin installation of Game Server Services SDK for Unity.");
            GUILayout.Label("");
            GUILayout.Label("The Unity Package Manager is used for installation.");
            GUILayout.Label("");

            switch (_status)
            {
                case SdkStatus.Present:
                    if (GUILayout.Button("Install"))
                    {
                        _status = SdkStatus.ImportScopedRegistry;
                    }
                    break;
                case SdkStatus.ImportScopedRegistry:
                    GUILayout.Button("Importing Scoped Registry... Please wait a moment.");
                    break;
                case SdkStatus.AddCSharpPackage:
                case SdkStatus.WaitingAddCSharpPackage:
                    GUILayout.Button("Installing C# SDK... Please wait a moment.");
                    break;
                case SdkStatus.AddUnityPackage:
                case SdkStatus.WaitingAddUnityPackage:
                    GUILayout.Button("Installing Unity SDK... Please wait a moment.");
                    break;
                case SdkStatus.Installing:
                    GUILayout.Button("Installing... Please wait a moment.");
                    break;
                case SdkStatus.InstallComplete:
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
                case SdkStatus.Present:
                    break;

                case SdkStatus.ImportScopedRegistry:
                    if (!IsImportedScopedRegistry())
                    {
                        AddScopedRegistry(new ScopedRegistry
                        {
                            name = "Game Server Services",
                            url = "https://upm.gs2.io/npm",
                            scopes = new string[]
                            {
                                "io.gs2"
                            }
                        });
                    }
                    _status = SdkStatus.AddCSharpPackage;
                    break;
                case SdkStatus.AddCSharpPackage:
                    addRequest = Client.Add("io.gs2.csharp.sdk");
                    _status = SdkStatus.WaitingAddCSharpPackage;
                    break;
                case SdkStatus.WaitingAddCSharpPackage:
                    if (addRequest == null)
                    {
                        _status = SdkStatus.Present;
                        return;
                    }
                    
                    if (addRequest.IsCompleted)
                    {
                        if (addRequest.Status == StatusCode.Success)
                        {
                            _status = SdkStatus.AddUnityPackage;
                        }
                        else if (addRequest.Status >= StatusCode.Failure)
                        {
                            Debug.Log(addRequest.Error.message);
                            _status = SdkStatus.Present;
                        }
                    }
                    break;
                case SdkStatus.AddUnityPackage:
                    addRequest = Client.Add("io.gs2.unity.sdk");
                    _status = SdkStatus.WaitingAddUnityPackage;
                    break;
                case SdkStatus.WaitingAddUnityPackage:
                    if (addRequest == null)
                    {
                        listRequest = Client.List();
                        _status = SdkStatus.Installing;
                        return;
                    }

                    if (addRequest.IsCompleted)
                    {
                        if (addRequest.Status == StatusCode.Success)
                        {
                            listRequest = Client.List();
                            _status = SdkStatus.Installing;
                        }
                        else if (addRequest.Status >= StatusCode.Failure)
                        {
                            Debug.Log(addRequest.Error.message);
                            _status = SdkStatus.Present;
                        }
                    }
                    break;
                case SdkStatus.Installing:
                    if (listRequest == null)
                    {
                        listRequest = Client.List();
                    }
                    if (listRequest.IsCompleted)
                    {
                        if (listRequest.Status == StatusCode.Success)
                        {
                            if (listRequest.Result.Count(item => item.name == "io.gs2.csharp.sdk") > 0 &&
                                listRequest.Result.Count(item => item.name == "io.gs2.unity.sdk") > 0)
                            {
                                _status = SdkStatus.InstallComplete;
                            }
                            else if (listRequest.Status >= StatusCode.Failure)
                            {
                                Debug.Log(addRequest.Error.message);
                                _status = SdkStatus.Present;
                            }
                        }
                        else if (addRequest.Status >= StatusCode.Failure)
                        {
                            Debug.Log(addRequest.Error.message);
                            _status = SdkStatus.Present;
                        }
                    }
                    break;
            }
            
            Repaint();
        }
        
        public static bool IsImportedScopedRegistry()
        {
            var manifestPath = Path.Combine(Application.dataPath, "..", "Packages/manifest.json");
            var manifestJson = File.ReadAllText(manifestPath);
 
            var manifest = JsonConvert.DeserializeObject<ManifestJson>(manifestJson);
 
            if (manifest.scopedRegistries.Count > 0)
            {
                foreach (var scopedRegistry in manifest.scopedRegistries)
                {
                    foreach (var scope in scopedRegistry.scopes)
                    {
                        if (scope == "io.gs2")
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        
        public static void AddScopedRegistry(ScopedRegistry ScopeRegistry)
        {
            var manifestPath = Path.Combine(Application.dataPath, "..", "Packages/manifest.json");
            var manifestJson = File.ReadAllText(manifestPath);
 
            var manifest = JsonConvert.DeserializeObject<ManifestJson>(manifestJson);
 
            manifest.scopedRegistries.Add(ScopeRegistry);
 
            File.WriteAllText(manifestPath, JsonConvert.SerializeObject(manifest, Formatting.Indented));
        }
        
        public class ScopedRegistry {
            public string name;
            public string url;
            public string[] scopes;
        }
 
        public class ManifestJson {
            public Dictionary<string,string> dependencies = new Dictionary<string, string>();
 
            public List<ScopedRegistry> scopedRegistries = new List<ScopedRegistry>();
        }
    }
}