using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] AnimationCurve scaleCurve;

    [SerializeField] float period;

    // Update is called once per frame
    void Update()
    {
        float remainder = Time.time % period;
        transform.localScale = Vector3.one * scaleCurve.Evaluate(remainder);
    }
}
