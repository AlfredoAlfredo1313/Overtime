using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerController Instance;

    Vector2 dir;
    float velo = 0.01f;

    private void Awake() {
        if(Instance == null) Instance = this;
        else Destroy(this);
    }

    private void FixedUpdate() {
        transform.Translate(dir * velo);
    }
    

    public void Move(Vector2 vec) {
        dir = vec;
    }
}
