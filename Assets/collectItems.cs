using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class collectItems : MonoBehaviour
{

    [SerializeField]
    private float time;

    [SerializeField]
    Text timer;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "TimeBonus")
        {
            time -= 30;
            if (time < 0)
            {
                time = 0;
            }
            GameObject.Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "TimePenalty")
        {
            time += 30;
            GameObject.Destroy(other.gameObject);
        }
    }
    void Update()
    {
        time += 1 * Time.deltaTime;
        timer.text = time.ToString();
    }
}