using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveAnnouncer : MonoBehaviour
{
    [SerializeField] Text _waveText;

    void Start()
    {
        
    }


    void Update()
    {
        
    }


    public void SetWaveNumber(int _wave)
    {
        _waveText.text = "Next Wave #" + _wave.ToString();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }

}
