using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ShowAd : MonoBehaviour {

	public void PlayAd()
    {
        if(Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}
