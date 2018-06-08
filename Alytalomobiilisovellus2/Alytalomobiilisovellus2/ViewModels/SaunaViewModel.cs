using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//poista nullable ja jätä pelkka int
namespace Alytalomobiilisovellus2.ViewModels
{
    public class SaunaViewModel
    {
        public int SaunaID { get; set; }
        public string SaunaNro { get; set; }
        public Nullable<int> SaunaNykyLampötila { get; set; }
        public Nullable<int> SaunaTavoiteLampötila { get; set; }
        public bool SaunaPäällä { get; set; }
        public bool SaunaOFF { get; set; }
    }
}