using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Loader : MonoBehaviour
{
    int current_scene_index = 0;
    int load_scene_time_wait = 3;

    private void Start()
    {
        current_scene_index = SceneManager.GetActiveScene().buildIndex;
        
        if(current_scene_index == 0)
        {
            StartCoroutine(Load_Scene());
        }       
    }

    private IEnumerator Load_Scene()
    {        
        yield return new WaitForSeconds(load_scene_time_wait);
        Load_Next_Scene();
    }    

    public void Load_Next_Scene()
    {
        SceneManager.LoadScene(current_scene_index + 1);
    }
}
