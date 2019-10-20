using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

 
    public Slider Sliderload;
   
  


    void Start()
    {
        Sliderload = GameObject.Find("Slider").GetComponent<Slider>();
        Sliderload.gameObject.SetActive(false);

       

       

    }

    public void Select(int LevelIndex)
    {
        
        StartCoroutine(LoadAsynchronously(LevelIndex));
        if (Sliderload.gameObject.activeSelf)
        {
            Sliderload.gameObject.SetActive(false);
        }
        else
        {
            Sliderload.gameObject.SetActive(true);
        }
    }

  
    IEnumerator LoadAsynchronously (int LevelIndex)
    {
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(LevelIndex);

       
        
        while(!operation.isDone)
        {
            
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Sliderload.value = progress;

            
            Time.timeScale = 1;
            yield return null;
        }
    }
    

   

}


