﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P05.BirthdayCelebrations
{
    public class Robot : IRobot
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; private set; }

        public string Id { get; private set; }
    }
}
