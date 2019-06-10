﻿using System;
 using System.Collections;
using System.Collections.Generic;
 using System.Net.Mail;
 using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    [SerializeField] [Range(-10, 5)] private float Speed = 1;
    public List<SpriteRenderer> sprites = new List<SpriteRenderer>();
    public Direction Dir = Direction.Right;

    private float heightCamera;
    private float widthCamera;

    private Vector3 PositionCam;
    private Camera cam;

    private Resolution currResolution;
    [SerializeField][Range(0, 0.5f)] private float margin = 0.1f;

    private int pixel_right;
    private int pixel_left;
    
    private float speed_mem;
    
    private void getDirection()
    {
        Vector2 mouse_pos = Input.mousePosition;
        if (Input.GetKey(KeyCode.LeftArrow)){
            Speed = speed_mem;
            Dir = Direction.Left;
        }
        // if (mouse_pos.x > pixel_right)
        // {
        //     Speed = speed_mem;
        //     Dir = Direction.Left;
        // }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Speed = speed_mem;
            Dir = Direction.Right;
        }
        else
        {
            Speed = 0;
        }
    }

    private void Awake()
    {
        cam = Camera.main;
        heightCamera = 2f * cam.orthographicSize;
        widthCamera = heightCamera * cam.aspect;
        
        currResolution = Screen.currentResolution;
        // pixel_right = Convert.ToInt32(currResolution.width * (1-margin));
        // pixel_left = Convert.ToInt32(currResolution.width *margin);
        
        speed_mem = Speed;
    }

    void Update ()
    {
        getDirection();
        
        foreach (var item in sprites)
        {
            if(Dir == Direction.Left)
            {
                if (item.transform.position.x + item.bounds.size.x / 2 < cam.transform.position.x - widthCamera / 2)
                {
                    SpriteRenderer sprite = sprites[0];
                    foreach (var i in sprites)
                    {
                        if (i.transform.position.x > sprite.transform.position.x)
                            sprite = i;
                    }

                    item.transform.position = new Vector2((sprite.transform.position.x + (sprite.bounds.size.x / 2) + (item.bounds.size.x / 2)), sprite.transform.position.y);
                }
            }
            else if (Dir == Direction.Right)
            {
                if (item.transform.position.x - item.bounds.size.x / 2 > cam.transform.position.x + widthCamera / 2)
                {
                    SpriteRenderer sprite = sprites[0];
                    foreach (var i in sprites)
                    {
                        if (i.transform.position.x < sprite.transform.position.x)
                            sprite = i;
                    }

                    item.transform.position = new Vector2((sprite.transform.position.x - (sprite.bounds.size.x / 2) - (item.bounds.size.x / 2)), sprite.transform.position.y);
                }
            }

            if (Dir == Direction.Left)
                item.transform.Translate(new Vector2(Time.deltaTime * Speed * -1, 0));
            else if (Dir == Direction.Right)
                item.transform.Translate(new Vector2(Time.deltaTime * Speed, 0));
        }

    }
}

public enum Direction
{
    Left,
    Right
}