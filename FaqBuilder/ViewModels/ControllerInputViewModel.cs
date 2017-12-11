using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaqBuilder.Models;

namespace FaqBuilder.ViewModels
{
    public class ControllerInputViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Motion { get; set; }

        public string Description { get; set; }

        public int PlatformId { get; set; }

        public PlatformViewModel Platform { get; set; }
    }
}