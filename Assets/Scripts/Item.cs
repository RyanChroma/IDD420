using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected GameObject player => GameObject.FindGameObjectWithTag("Player");
    public virtual void onPickUP()
    {

    }
}
