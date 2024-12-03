using System.Collections;
using Gs2.Core.Model;
using Gs2.Unity.Core;
using Gs2.Unity.Gs2Account.Model;
using Gs2.Unity.Util;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Gs2.Core.Domain;
using Gs2.Unity.Gs2Account.Domain.Model;
using Gs2.Gs2Auth.Domain.Model;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
//①ドキュメント資料のコピペ--------------------------------------
IEnumerator Start()
    {
        // Setup variables

        var clientId = "GKINt_dh5Ul_3QYZ_jliGx0Drm0mQHrcpU1hKgtB_ITGmN55Yzgou6XL-4U9-hFhA7f1PQeNztLJdWTjB-xijlBI0WH11iJujPIKiae";
        var clientSecret = "iKLpGoqbixqmmAGiLjEyNyRhsShesFfq";
        var accountNamespaceName = "default";

        // Initialize GS2 SDK
        Gs2Domain gs2;
        {
            var future = Gs2Client.CreateFuture(
                new BasicGs2Credential(
                    clientId,
                    clientSecret
                ),
                Region.ApNortheast1
            );
            yield return future;
            if (future.Error != null)
            {
                throw future.Error;
            }
            gs2 = future.Result;
        }

        // define GS2-Account namespace
        var gs2Account = gs2.Account.Namespace(
            accountNamespaceName
        );

        // Create an anonymous account
        EzAccount account;
        {
            Debug.Log("Create an anonymous account");
            var future = gs2Account.CreateFuture();
            yield return future;
            if (future.Error != null)
            {
                throw future.Error;
            }
            var future2 = future.Result.ModelFuture();
            yield return future2;
            if (future2.Error != null)
            {
                throw future2.Error;
            }
            account = future2.Result;
        }

        // Dump anonymous account

        Debug.Log($"UserId: {account.UserId}");
        Debug.Log($"Password: {account.Password}");

        // Log-in created anonymous account
        GameSession gameSession;
        {
            var future = gs2.LoginFuture(
                new Gs2AccountAuthenticator(
                    accountSetting: new AccountSetting
                    {
                        accountNamespaceName = accountNamespaceName,
                    }
                ),
                account.UserId,
                account.Password
            );
            yield return future;
            if (future.Error != null)
            {
                throw future.Error;
            }
            gameSession = future.Result;
        }

        // Load TakeOver settings
        {
            var it = gs2Account.Me(
                gameSession
            ).TakeOvers();
            while (it.HasNext())
            {
                yield return it.Next();
                if (it.Error != null)
                {
                    throw it.Error;
                }
                //Debug.Log($"Slot: {it.Current.Slot}");　　　　//エラー
                Debug.Log($"Identifier: {it.Current.UserIdentifier}");
            }
        }

        // Finalize GS2-SDK
        {
            var future = gs2.DisconnectFuture();
            yield return future;
            if (future.Error != null)
            {
                throw future.Error;
            }
        }
    }
    //ドキュメント資料のコピペEND--------------------------------

    //②以下、YouTubeの動画を元にエラーを潰したもの----------------
    //※コメントアウト行は、動画中で使用されていなかった行

    //    private async void Start()
    //    {
    //        async UniTask Impl()
    //        {
    //            var profile = new Profile(
    //                clientId: "GKINt_dh5Ul_3QYZ_jliGx0Drm0mQHrcpU1hKgtB_ITGmN55Yzgou6XL-4U9-hFhA7f1PQeNztLJdWTjB-xijlBI0WH11iJujPIKiae",
    //                clientSecret: "iKLpGoqbixqmmAGiLjEyNyRhsShesFfq",
    //                new Gs2BasicReopener(),
    //                Region.ApNortheast1
    //                );
    //            await profile.InitializeAsync();
    //            var gs2 = new Gs2Domain(profile);

    //            string userId = PlayerPrefs.GetString(key: "UserId");
    //            string password = PlayerPrefs.GetString(key: "Password");
    //            if (userId == "" || password == "")
    //            {
    //                var namespaceObject = gs2.Account.Namespace(
    //                    namespaceName: "default"
    //                );
    //                EzAccountDomain createResult = await namespaceObject.CreateAsync(
    //                );
    //                var account = await createResult.ModelAsync();

    //                PlayerPrefs.SetString("UserId", account.UserId);
    //                PlayerPrefs.SetString("Password", account.Password);
    //                PlayerPrefs.Save();

    //                userId = account.UserId;
    //                password = account.Password;
    //            }

    //            //認証処理------------
    //            //try
    //            //{
    //            var domain = gs2.Account.Namespace(
    //                namespaceName: "default"
    //            ).Account(
    //                userId: "user-0001"
    //            );
    //            var authenticationResult = await domain.AuthenticationAsync(
    //                password: "password-0001",
    //                keyId: "grn:gs2:ap-northeast-1:anBqMpIi-AkagonohateTest2:key:default:key:default"
    //            );
    //            //var item = await authenticationResult.ModelAsync();
    //            //var banStatuses = authenticationResult.BanStatuses;
    //            var body = authenticationResult.Body;
    //            var signature = authenticationResult.Signature;
    //            //}
    //            //    catch (Gs2.Gs2Account.Exception.PasswordIncorrect e)　//エラーになる
    //            //    {
    //            //    // Incorrect password specified. 間違ったパスワードが指定されました
    //            //}
    //            //    catch (Gs2.Gs2Account.Exception.BannedInfinity e)　//エラーになる
    //            //    {
    //            //    // Account has been suspended. アカウントが停止されました
    //            //}

    //            //ログイン処理----------
    //            var accountTokenObject = gs2.Auth.AccessToken(　　　　　　　　　//エラーになる
    //                );
    //            var result = await accountTokenObject.CreateAsync.LoginAsnyc(
    //                keyId: "",
    //                body: body,
    //                signature: signature
    //            );
    //            GameSession accessToken = await result.ModelAsync();

    //        }
    //        StartCoroutine(routine: Impl().ToCoroutine());
    //    }


}

//YouTube資料から作成END-----------------------------------------

////③以下、Qiitaに記載のテンプレートコピペ(最後まで)------------
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Gs2.Core;
//using Gs2.Unity.Gs2Account.Model;
//using Gs2.Unity.Gs2Account.Result;
//using Gs2.Unity.Util;
//using UnityEngine;

//public class Gs2AccountSample2 : MonoBehaviour
//{
//    // GS2-Identifier で発行したクライアントID
//    public string clientId;

//    // GS2-Identifier で発行したクライアントシークレット
//    public string clientSecret;

//    // アカウントを作成する GS2-Account のネームスペース名
//    public string accountNamespaceName;

//    // アカウントの認証結果に付与する署名を計算するのに使用する暗号鍵
//    public string accountEncryptionKeyId;

//    void Start()
//    {
//        StartCoroutine(Create());
//    }

//    public IEnumerator Create()
//    {
//        // GS2 SDK のクライアントを初期化

//        Debug.Log("GS2 SDK のクライアントを初期化");

//        var profile = new Gs2.Unity.Util.Profile(
//            clientId: clientId,
//            clientSecret: clientSecret,
//            reopener: new Gs2BasicReopener()
//        );

//        {
//            AsyncResult<object> asyncResult = null;

//            var current = profile.Initialize(
//                r => { asyncResult = r; }　　//エラーになる
//            );

//            yield return current;

//            // コルーチンの実行が終了した時点で、コールバックは必ず呼ばれています

//            // クライアントの初期化に失敗した場合は終了
//            if (asyncResult.Error != null)
//            {
//                OnError(asyncResult.Error);
//                yield break;
//            }
//        }

//        var gs2 = new Gs2.Unity.Client(profile);　　//エラー

//        // アカウントを新規作成

//        Debug.Log("アカウントを新規作成");

//        EzAccount account = null;

//        {
//            AsyncResult<EzCreateResult> asyncResult = null;

//            var current = gs2.Account.Create(
//                r => { asyncResult = r; },
//                accountNamespaceName
//            );

//            yield return current;

//            // コルーチンの実行が終了した時点で、コールバックは必ず呼ばれています

//            // アカウントが作成できなかった場合は終了
//            if (asyncResult.Error != null)
//            {
//                OnError(asyncResult.Error);
//                yield break;
//            }

//            // 作成したアカウント情報を取得
//            account = asyncResult.Result.Item;
//        }

//        // GS2 SDK の終了処理

//        Debug.Log("GS2 SDK の終了処理");

//        {
//            // ゲームを終了するときなどに呼び出してください。
//            // 頻繁に呼び出すことは想定していません。
//            var current = profile.Finalize();

//            yield return current;
//        }
//    }

//    private void OnError(Exception e)
//    {
//        Debug.Log(e.ToString());
//    }
//}