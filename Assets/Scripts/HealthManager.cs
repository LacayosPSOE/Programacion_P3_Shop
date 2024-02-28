using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int _maxHealth;
    public int  _currentHealth;

    public RectTransform _transform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                  _currentHealth -= 10;
                Vector2 _howBig = _transform.sizeDelta;
                 _howBig.x = _howBig.x - 100;
                _transform.sizeDelta = _howBig;

                }
            }
    }
}
