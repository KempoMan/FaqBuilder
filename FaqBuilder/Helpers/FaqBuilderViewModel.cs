using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaqBuilder.Interfaces;

namespace FaqBuilder.Helpers
{
    public class FaqBuilderViewModel : IFaqBuilderViewModel
    {
        public bool Success { get; set; } = true;
        public string Error { get; set; }
    }
}