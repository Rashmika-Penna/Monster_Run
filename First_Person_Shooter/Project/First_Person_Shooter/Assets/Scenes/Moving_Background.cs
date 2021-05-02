﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Background : MonoBehaviour
{
    [SerializeField] float background_scrolling_speed = 0.5f;
    Material background_material;
    Vector2 background_offset;

    private void Start()
    {
        background_material = GetComponent<Renderer>().material;
        background_offset = new Vector2(background_scrolling_speed, 0f);
    }

    private void Update()
    {
        background_material.mainTextureOffset += background_offset * Time.deltaTime;
    }
}
