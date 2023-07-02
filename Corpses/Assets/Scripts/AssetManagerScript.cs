using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class AssetManagerScript
{
    private static string imagePath = "Assets/Art/{0}"; // get path to load sprites from

    public static void LoadSprite(string spriteName, System.Action<Sprite> onLoaded) // load sprite
    {
        Addressables.LoadAssetAsync<Sprite>(string.Format(imagePath, spriteName)).Completed += (loadedSprite) => // load sprite and run function when loaded
        {
            onLoaded?.Invoke(loadedSprite.Result);
        };
    }
}
