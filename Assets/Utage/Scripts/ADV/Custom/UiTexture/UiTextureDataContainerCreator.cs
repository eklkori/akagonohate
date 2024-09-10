using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Utage
{
    //Ui用の追加テクスチャのデータコンテナのクリエイター
    //CustomProjectSettingに設定することで、Tipsデータを扱えるようになる
    [CreateAssetMenu(menuName = "Utage/CustomData/" + nameof(UiTextureDataContainer))]
    public class UiTextureDataContainerCreator : AdvCustomDataContainerCreator<UiTextureDataContainer>
    {
        //TIPSデータとして扱うシート名
        protected List<string> TargetNames => targetNames;
        [SerializeField] protected List<string> targetNames = new() { "UiTexture" };
        
        public override bool IsTargetDataName(string customDataName)
        {
            return TargetNames.Contains(customDataName);
        }

        public override AdvCustomDataContainer CreateCustomDataContainer(AdvCustomDataManager customDataManager)
        {
            return new UiTextureDataContainer(customDataManager);
        }
    }
}
