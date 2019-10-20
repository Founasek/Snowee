using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SocialLinks : MonoBehaviour {



    public void OpenFacebookPage()
    {

        if (checkPackageAppIsPresent("com.facebook.katana"))
        {
            Application.OpenURL("fb://page/1983302928558271"); //there is Facebook app installed so let's use it
        }
        else
        {
            Application.OpenURL("https://www.facebook.com/Founejan.cz"); // no Facebook app - use built-in web browser
        }
    }


    public void OpenTwitter()
    {
        Application.OpenURL("twitter://user?screen_name=Founasek");
    }
    



    public void SendEmail()
    {
        string email = "info@founejan.cz";
        string subject = MyEscapeURL("Snowee");
        string body = MyEscapeURL("");
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }
    string MyEscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+", "%20");
    }



    private bool checkPackageAppIsPresent(string package)
    {
        AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");

        //take the list of all packages on the device
        AndroidJavaObject appList = packageManager.Call<AndroidJavaObject>("getInstalledPackages", 0);
        int num = appList.Call<int>("size");
        for (int i = 0; i < num; i++)
        {
            AndroidJavaObject appInfo = appList.Call<AndroidJavaObject>("get", i);
            string packageNew = appInfo.Get<string>("packageName");
            if (packageNew.CompareTo(package) == 0)
            {
                return true;
            }
        }
        return false;
    }
}
