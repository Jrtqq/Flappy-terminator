using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _endPosition;

    private float _duration = 3f;
    private float _interpolant = 6f;

    public IEnumerator Play()
    {
        transform.position = _startPosition;
        float time = 0;

        while (time < _duration)
        {
            time += Time.deltaTime;

            transform.position = Vector3.Lerp(transform.position, _endPosition, _interpolant * Time.deltaTime);
            yield return null;
        }
    }
}
