using UnityEngine;

public class DancingCapsule : MonoBehaviour
{
    public float minDanceSpeed = 3.0f;
    public float maxDanceSpeed = 7.0f;
    private float danceSpeed;

    public float minDanceHeight = 0.3f;
    public float maxDanceHeight = 0.7f;
    private float danceHeight;

    private Vector3 startPosition;
    private bool isDancing = true;

    void Start()
    {
        startPosition = transform.position;

        danceSpeed = Random.Range(minDanceSpeed, maxDanceSpeed);
        danceHeight = Random.Range(minDanceHeight, maxDanceHeight);
    }

    void Update()
    {
        if (isDancing)
        {
            Vector3 newPosition = startPosition;
            newPosition.y += Mathf.Sin(Time.time * danceSpeed) * danceHeight;
            transform.position = newPosition;
        }
    }

    public void SetDancing(bool status)
    {
        isDancing = status;
        if (!isDancing)
        {
            
            ResetToStartPosition();
        }
    }

    private void ResetToStartPosition()
    {
        transform.position = startPosition;
    }
}
