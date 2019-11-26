using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float umbralPulsacionLarga;
    private float duracionPulsacion = 0;
    private bool pulsado = false;
    public static bool playing = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.touches[0];
            if (t.phase == TouchPhase.Began)
            {
                pulsado = true;
            }
            if (t.phase == TouchPhase.Ended)
            {
                pulsado = false;
                if (duracionPulsacion < umbralPulsacionLarga)
                {
                    ShortPress();
                }
                duracionPulsacion = 0;
            }
        }
        if (pulsado)
        {
            duracionPulsacion += Time.deltaTime;
            if (duracionPulsacion > umbralPulsacionLarga)
            {
                pulsado = false;
                LongPress();
            }
        }
    }
    private void LongPress()
    {
        SceneManager.LoadScene(0);
    }
    private void ShortPress()
    {
        playing = !playing;
    }
}
