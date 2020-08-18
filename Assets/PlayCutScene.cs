using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class PlayCutScene : MonoBehaviour
{
    public GameObject cutScene;
    private bool CutPlayed = false;
    
    void Start()
    {
        CutPlayed = false;
    }
    
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "forest" && !CutPlayed)
        {
            //StartCoroutine(PlayCut());
        }
    }

    IEnumerator PlayCut()
    {
        CutPlayed = true;
        yield return new WaitForSeconds(1f);
        cutScene.GetComponent<PlayableDirector>().Play();
        
    }
}
