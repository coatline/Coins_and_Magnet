using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            transform.position = Vector3.MoveTowards(transform.position, mousePos, Time.deltaTime / ((transform.position.y - mousePos.y) / 5));
            LookAtMouse();
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            transform.position = Vector3.MoveTowards(transform.position, mousePos, Time.deltaTime * (((transform.position.y - mousePos.y) * -2) / 3));
            LookAtMouse();
        }
    }

    void LookAtMouse()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
