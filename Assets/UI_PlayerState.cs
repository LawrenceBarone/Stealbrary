using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerState : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] S_BookPile bookpile;
    [SerializeField] Gradient colorGradient;

    float angle;
    Vector3 currentAngle;

    public void SetAngleToFall(float _angle)
    {
        angle = _angle;
    }

    public void SetCurrentAngle(Vector3 _currentAngle)
    {
        currentAngle = _currentAngle;
    }

    private void FixedUpdate()
    {
        showStateUI();
    }
    void showStateUI()
    {
        
        float x = Mathf.Abs(currentAngle.x);
        float z = Mathf.Abs(currentAngle.z);
        float magnitudeOfAngle = (x + z) / angle;
        img.color = colorGradient.Evaluate(magnitudeOfAngle);
        img.fillAmount = magnitudeOfAngle;

    }
    
}
