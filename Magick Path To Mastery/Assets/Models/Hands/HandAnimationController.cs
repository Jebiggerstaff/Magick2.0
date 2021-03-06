﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationController : MonoBehaviour
{
    public AnimationClip handClose;
    public AnimationClip Evocation;
    public AnimationClip Enchantment;
    public AnimationClip Transmutation;
    public AnimationClip Conjuration;


    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            gameObject.GetComponent<Animator>().SetBool("isEvocation", true);
            Invoke("StopEvocationAnim",Evocation.length);
        }

        if (Input.GetKeyDown("e"))
        {
            gameObject.GetComponent<Animator>().SetBool("isEnchantment", true);
            Invoke("StopEnchantmentAnim",Enchantment.length);
        }

        if (Input.GetKeyDown("r"))
        {
            gameObject.GetComponent<Animator>().SetBool("isTransmutation", true);
            Invoke("StopTransmutationAnim",Transmutation.length);
        }

        if (Input.GetKeyDown("f"))
        {
            gameObject.GetComponent<Animator>().SetBool("isConjuration", true);
            Invoke("StopConjurationAnim",Conjuration.length);
        }

        if (Input.GetKeyDown("z"))
        {
            gameObject.GetComponent<Animator>().SetBool("isHandClose", true);
            Invoke("StopHandCloseAnim",handClose.length);
        }
    }

    void StopEvocationAnim()
    {
        gameObject.GetComponent<Animator>().SetBool("isEvocation", false);

    }

    void StopEnchantmentAnim()
    {
        gameObject.GetComponent<Animator>().SetBool("isEnchantment", false);

    }

    void StopTransmutationAnim()
    {
        gameObject.GetComponent<Animator>().SetBool("isTransmutation", false);

    }

    void StopConjurationAnim()
    {
        gameObject.GetComponent<Animator>().SetBool("isConjuration", false);

    }

    void StopHandCloseAnim()
    {
        gameObject.GetComponent<Animator>().SetBool("isHandClose", false);

    }
}
