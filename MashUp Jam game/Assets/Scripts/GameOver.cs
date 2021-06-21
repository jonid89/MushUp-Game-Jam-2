using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    

    void Start()
    {
        StartCoroutine(FadeOut());
    }

    
    void Update()
    {
    
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
