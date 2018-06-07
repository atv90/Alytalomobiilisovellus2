using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alytalomobiilisovellus2.ViewModels
{
    public class ValoViewModel
    {
        public int ValoID { get; set; }
        public bool ValotPaalla { get; set; }
        public bool Valot0 { get; set; }
        public bool Valot33 { get; set; }
        public bool Valot66 { get; set; }
        public bool Valot100 { get; set; }
        public string ValoHuone { get; set; }
        public DateTime? ValoTime0 { get; set; }
        public DateTime? ValoTime33 { get; set; }
        public DateTime? ValoTime66 { get; set; }
        public DateTime? ValoTime100 { get; set; }
    }
}