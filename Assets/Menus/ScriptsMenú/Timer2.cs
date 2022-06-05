using UnityEngine;
using TMPro;

public class Timer2 : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text timerTextP;


    public float timeElapsed;
    public int minutos, segundos, centesimas;

    private void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;
        minutos = (int)(timeElapsed / 60f);
        segundos = (int)(timeElapsed - minutos * 60f);
        centesimas = (int)((timeElapsed - (int)timeElapsed) * 1000f);

        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutos, segundos, centesimas);

        timerTextP.text = string.Format("{0:00} minutos con {1:00} segundos y {2:000} cent simas", minutos, segundos, centesimas);
       
    }
}
