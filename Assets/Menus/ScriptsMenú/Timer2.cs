using UnityEngine;
using TMPro;

public class Timer2 : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    public float timeElapsed;
    public int minutos, segundos, centesimas;

    private void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;
        minutos = (int)(timeElapsed / 60f);
        segundos = (int)(timeElapsed - minutos * 60f);
        centesimas = (int)((timeElapsed - (int)timeElapsed) * 100f);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, centesimas);
    }
}
