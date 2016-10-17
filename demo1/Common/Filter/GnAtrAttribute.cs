using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Common
{
    public class GnAtrAttribute:Attribute
    {
        protected string _name;
        protected string _version;
        protected bool _ispublic;
        public GnAtrAttribute(string name,string version,bool ispublic)
        {
            this._name = name;
            this._version = version;
            this._ispublic = ispublic;
        }


        public string name
        {
            get { return _name; }
        }

        public string version
        {
            get { return _version; }
        }
        public bool ispublic
        {
            get { return _ispublic; }
        }
        
    }
}