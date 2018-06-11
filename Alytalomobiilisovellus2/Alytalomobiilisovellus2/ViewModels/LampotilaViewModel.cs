using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alytalomobiilisovellus2.ViewModels
{
    public class LampotilaViewModel
    {
        public int LampotilaID { get; set; }
        public Nullable<int> TavoiteLampotila { get; set; }
        public Nullable<int> TaloNykyLampotila { get; set; }
        public bool LämmitysON { get; set; }
        public bool LämmitysOFF { get; set; }
    }
}