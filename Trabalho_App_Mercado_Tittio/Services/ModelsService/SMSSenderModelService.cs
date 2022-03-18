using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_App_Mercado_Tittio.Services.ModelsService
{
    public class SMSSenderModelService
    {
        public string key { get; set; }
        public int type { get; set; }
        public long number { get; set; }
        public string msg { get; set; }

        public SMSSenderModelService()
        {
            key = "DS3YQQZEEX3MT9JX69I4TSQSMN4YLTZQNW5QBMN7P8YU5EGNI5TQENTZG7XCJY41U8D4V65VIGYZ76G4SXOZGSQ3423VKS9JHBZ1LMJ1MSPLT9494MC0RV5YBG0GYFF0";
            type = 9;
        }
    }
}
