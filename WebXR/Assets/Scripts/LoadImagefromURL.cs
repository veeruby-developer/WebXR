using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadImagefromURL : MonoBehaviour
{
    public RawImage YourRawImage;
    public Material Screen;
    public Texture2D texture;
    public string url = "https://cdn.filestackcontent.com/AjxDul8lkT0e67xuC1ltLz/resize=height:200/http://167.172.214.108/images/gallery/image%20(1).png";

    // Start is called before the first frame update
     void Start()
    {
        StartCoroutine(DownloadImage(url));
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            //YourRawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        Debug.Log(((DownloadHandlerTexture)request.downloadHandler).texture);
        Screen.mainTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}
