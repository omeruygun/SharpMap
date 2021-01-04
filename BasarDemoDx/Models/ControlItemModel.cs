using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasarDemoDx.Models
{
    public class ControlItemModel
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public ControlItemModel()
        {

        }
        public ControlItemModel(string text,object value)
        {
            Text = text;
            Value = value;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
