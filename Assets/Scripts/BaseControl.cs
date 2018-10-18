using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControl : MonoBehaviour {

    public float speed = 200f;
    public Transform[] cylinders;
    public float offSetMove = -32f;
    private ScoreTrigger[] scores;

    private void Start()
    {
        RandomRotate();
        scores = GetComponentsInChildren<ScoreTrigger>();
    }
    private void Update()
    {
        if (LevelController.instance.gameOver)
        {
            return;
        }
        Rotate();
    }

    private void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * -1, 0) * speed * Time.deltaTime);
        }
    }

    private void RandomRotate()
    {
        for (int i = 0; i < cylinders.Length; i++)
        {
            cylinders[i].rotation = Quaternion.Euler(0, Random.Range(0,360), 0);
        }
    }

    private void Reposition()
    {
        transform.position = new Vector3(0, transform.position.y + offSetMove, 0);
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i].SetColliders(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Reposition();
            RandomRotate();
        }
    }
}
