using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            LevelController.instance.GameOver();
            ball.transform.position = new Vector3(ball.transform.position.x, transform.position.y + 0.5f, ball.transform.position.z);
            ball.GameOver();
        }
    }
}
