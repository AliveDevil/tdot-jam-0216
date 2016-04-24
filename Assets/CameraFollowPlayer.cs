using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

    [SerializeField]
    Transform player;



	// Update is called once per frame
	void Update () {
        transform.Translate();
	}
}
