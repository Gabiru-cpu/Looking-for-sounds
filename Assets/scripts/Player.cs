using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public CharacterController controller;

    public Slider vidaPlayer, estamina;
    public int teste = 0;
    public float Crono, CronoEstamina, speed = 17f, gravidd = -19f, distanciadChao = 0.4f, altpulo = 3f;

    public Transform groundCheck;
    public LayerMask groundMask;

    Vector3 vGravitacional;
    bool noChao;
    void Update()
    {
        noChao = Physics.CheckSphere(groundCheck.position, distanciadChao, groundMask);

        if(noChao && vGravitacional.y < 0)
        {
            vGravitacional.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        vGravitacional.y += gravidd * Time.deltaTime;

        controller.Move(vGravitacional * Time.deltaTime);


        //camera tremer ao andar
        if (x != 0 || z != 0)
        {
            MouseMoviment.instace.treme();
        }
        else
        {
            MouseMoviment.instace.prd();
        }

        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            vGravitacional.y = Mathf.Sqrt(altpulo * -2f * gravidd);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) & estamina.value >= 1)
        {
            speed = 27;
            controller.height = 2;
            
        }

        if(speed == 27)
        {
            estamina.value--;
            CronoEstamina = 0f;
        }

        if (estamina.value <= 0)
        {
            speed = 17; 
             
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 17;
            controller.height = 2;

        }

        //agaixar
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            controller.height = 0.5f;

        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            controller.height = 2;

        }



        //timers de stamina&regen de vida
        Crono += Time.deltaTime;
        CronoEstamina += Time.deltaTime;

        if (vidaPlayer.value == 100)
        {
            Crono = 0f;
        }


        if (Crono >= 10f & vidaPlayer.value <= 99)
        {
            vidaPlayer.value++;
        }
        if (vidaPlayer.value <= 0)
        {
            //colocar para ir  para tela de game over
        }

        if (CronoEstamina >= 5)
        {
            CronoEstamina = 5;
        }
        if (CronoEstamina == 5 & estamina.value <= 499)
        {
            estamina.value++;
        }

    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Inimigos")
        {
            vidaPlayer.value--;
            Crono = 0f;
        }

    }
 
}

