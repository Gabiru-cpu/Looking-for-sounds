using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class visao : MonoBehaviour
{

    public Transform target;
    public float VisionAngle = 90;
    public float DistanceMax = 10;
    public float TempoDeAlerta = 4;

    void Update()
    {
        TempoDeAlerta += Time.deltaTime;

        if(TempoDeAlerta >= 4)
        {
            TempoDeAlerta = 4;

        }


        if (OnVision())
        {
            //lembrar de mudar pra seguir o player qnd conseguir fazer o inimigo rondar o cenario!!
            print("player dentro da visao" + target.name);
            TempoDeAlerta = 0;
        }

        void Round()
        {

        }
    }

    bool OnVision()
    {

        Vector3 dir = target.position - transform.position;
        float angulo = Vector3.Angle(dir, transform.forward);
        float CurrentDis = Vector3.Distance(target.position, transform.position);

        RaycastHit hit;

        if (angulo <= VisionAngle && CurrentDis <= DistanceMax)
        {
            if(Physics.Linecast(transform.position,target.position,out hit))
            {
                if(hit.transform.tag == "Player")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
