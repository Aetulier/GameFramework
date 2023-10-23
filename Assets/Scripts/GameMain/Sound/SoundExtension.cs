//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using GameFramework.Sound;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameName
{
    public static class SoundExtension
    {
        public static int PlayLoopSoundBaseTrans(this SoundComponent soundComponent, string SoundName,string soundGroupName,Transform trans, float volume = 1, object userData = null)
        {
            PlaySoundParams playSoundParams = PlaySoundParams.Create();
            playSoundParams.Priority = 10;
            playSoundParams.Loop = true;
            playSoundParams.VolumeInSoundGroup = volume;
            playSoundParams.SpatialBlend = 1f;
            playSoundParams.MaxDistance = 10;
            playSoundParams.FadeInSeconds = 0.2f;
            return soundComponent.PlaySound_T(AssetUtility.GetSoundAsset(SoundName), soundGroupName, 0, playSoundParams, trans, userData);
        }
        public static int PlayOneSoundBaseTrans(this SoundComponent soundComponent, string SoundName, string soundGroupName, Transform trans,float volume = 1, object userData = null)
        {
            PlaySoundParams playSoundParams = PlaySoundParams.Create();
            playSoundParams.Priority = 10;
            playSoundParams.Loop = false;
            playSoundParams.VolumeInSoundGroup = volume;
            playSoundParams.SpatialBlend = 1f;
            playSoundParams.MaxDistance = 10;
            return soundComponent.PlaySound_T(AssetUtility.GetSoundAsset(SoundName), soundGroupName, 0, playSoundParams, trans, userData);
        }
        public static int PlayOneSoundBaseTransWalk(this SoundComponent soundComponent, string SoundName, string soundGroupName, Transform trans, float volume = 1, object userData = null)
        {
            PlaySoundParams playSoundParams = PlaySoundParams.Create();
            playSoundParams.Priority = 10;
            playSoundParams.Loop = false;
            playSoundParams.VolumeInSoundGroup = volume;
            playSoundParams.SpatialBlend = 1f;
            playSoundParams.MaxDistance = 10;
            playSoundParams.FadeInSeconds = 0.2f;
            return soundComponent.PlaySound_T(AssetUtility.GetSoundAsset(SoundName), soundGroupName, 0, playSoundParams, trans, userData);
        }
        public static int PlayOneSoundBaseTransFade(this SoundComponent soundComponent, string SoundName, string soundGroupName, Transform trans,float FadeTime, object userData = null)
        {
            PlaySoundParams playSoundParams = PlaySoundParams.Create();
            playSoundParams.Priority = 10;
            playSoundParams.Loop = false;
            playSoundParams.VolumeInSoundGroup = 1;
            playSoundParams.SpatialBlend = 1f;
            playSoundParams.MaxDistance = 10;
            playSoundParams.FadeInSeconds = FadeTime;
            return soundComponent.PlaySound_T(AssetUtility.GetSoundAsset(SoundName), soundGroupName, 0, playSoundParams, trans, userData);
        }
        public static int PlayLoopSoundBasePos(this SoundComponent soundComponent, string SoundName, string soundGroupName, Vector3 worldPosition, object userData = null)
        {
            PlaySoundParams playSoundParams = PlaySoundParams.Create();
            playSoundParams.Priority = 10;
            playSoundParams.Loop = true;
            playSoundParams.VolumeInSoundGroup = 1;
            playSoundParams.SpatialBlend = 1f;
            playSoundParams.MaxDistance = 10;
            return soundComponent.PlaySound(AssetUtility.GetSoundAsset(SoundName), soundGroupName, 0, playSoundParams, worldPosition, userData);
        }
        public static int PlayOneSoundBasePos(this SoundComponent soundComponent, string SoundName, string soundGroupName, Vector3 worldPosition, object userData = null)
        {
            PlaySoundParams playSoundParams = PlaySoundParams.Create();
            playSoundParams.Priority = 10;
            playSoundParams.Loop = false;
            playSoundParams.VolumeInSoundGroup = 1;
            playSoundParams.SpatialBlend = 1f;
            playSoundParams.MaxDistance = 10;
            return soundComponent.PlaySound(AssetUtility.GetSoundAsset(SoundName), soundGroupName, 0, playSoundParams, worldPosition, userData);
        }
        public static int PlayOneSound(this SoundComponent soundComponent, string SoundName, string soundGroupName, object userData = null)
        {
            PlaySoundParams playSoundParams = PlaySoundParams.Create();
            playSoundParams.Priority = 10;
            playSoundParams.Loop = false;
            playSoundParams.VolumeInSoundGroup = 1;
            playSoundParams.SpatialBlend = 0f;
            return soundComponent.PlaySound(AssetUtility.GetSoundAsset(SoundName), soundGroupName, 0, playSoundParams, userData);
        }
        public static int PlayLoopSound(this SoundComponent soundComponent, string SoundName, string soundGroupName, float volume = 1, object userData = null)
        {
            PlaySoundParams playSoundParams = PlaySoundParams.Create();
            playSoundParams.Priority = 0;
            playSoundParams.Loop = true;
            playSoundParams.VolumeInSoundGroup = volume;
            playSoundParams.SpatialBlend = 0f;
            return soundComponent.PlaySound(AssetUtility.GetSoundAsset(SoundName), soundGroupName, 0, playSoundParams, userData);
        }

    }
}
