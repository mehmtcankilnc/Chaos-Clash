using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    public Slider progressBar;
    private void Start()
    {
        progressBar.value = 6;
        progressBar.maxValue = 106;
    }
    public void IncreaseProgress(int progress)
    {
        progressBar.value += progress;
    }
}
