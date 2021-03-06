﻿using System.Collections.Generic;

namespace FaqBuilder.Models
{
    public class ControllerInput
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Motion { get; set; }

        public string Description { get; set; }

        public int PlatformId { get; set; }

        public Platform Platform { get; set; }
    }
}