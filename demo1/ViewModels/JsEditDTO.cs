using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.ViewModels
{
    public class JsEditDTO
    {
        public Model.js js { get; set; }
        public List<JsgnDTO> jsgns { get; set; }
    }
}