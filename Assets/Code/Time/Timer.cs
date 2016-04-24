using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timerTime;

    [SerializeField]
    Text timer;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "TimeBonus")
            timerTime -= 30;
        if (other.gameObject.tag == "TimePenalty")
            timerTime += 30;
    }

    void Update()
    {
        timerTime += 1 * Time.deltaTime;
        timer.text = timerTime.ToString();
    }
}
