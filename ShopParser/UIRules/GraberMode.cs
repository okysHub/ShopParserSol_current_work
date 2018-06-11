using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopParser.UIRules

{
    public class GraberMode
    {
        private string _action;
        private string _description;

        public string Action { get => _action; set => _action = value; }
        public string Description { get => _description; set => _description = value; }
    }
}