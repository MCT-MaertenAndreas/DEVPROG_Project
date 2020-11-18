using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EindProject.Models
{
    public class NavigationItem
    {
        public string Title { get; set; }
        public ImageSource Image { get; set; }
        public Type TargetType { get; set; }
    }
}
