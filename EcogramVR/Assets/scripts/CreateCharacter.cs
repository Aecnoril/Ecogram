using UnityEngine;
using System.Collections;

public class CreateCharacter : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "RightController")
        {
            Destroy(col.gameObject);
        }
    }
}