using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoviment : MonoBehaviour
{
    public static MouseMoviment instace;

    Animator anim;
    public float sensibilidade = 100f;
    public Transform corpoDoPlayer;
    float xRotacao = 0f;

    void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
    }

    void Start()
    {
        transform.tag = "Player";
        Cursor.lockState = CursorLockMode.Locked;

        anim = GetComponent<Animator>();

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidade * Time.deltaTime;
        //nao permitir virar o peescoco q nem a samara
        xRotacao -= mouseY;
        xRotacao = Mathf.Clamp(xRotacao, -90f, 25f);

        transform.localRotation = Quaternion.Euler(xRotacao, 0f, 0f);
        corpoDoPlayer.Rotate(Vector3.up * mouseX);

    }
    public void treme()
    {
        anim.Play("Shake");
    }

    public void prd()
    {
        anim.Play("Idle");
    }
}
