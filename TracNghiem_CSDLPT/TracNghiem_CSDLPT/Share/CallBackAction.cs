using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiem_CSDLPT.Share
{
    public class CallBackAction
    {
        public Action BackAction { get; set; }
        public DataTable Table { get; set; } 

        public CallBackAction()
        {
            this.BackAction = Action.None;
            this.Table = null;
        }

        public CallBackAction(Action action, DataTable table)
        {
            this.BackAction = action;
            this.Table = table;
        }

        public void FillData(Action action, DataTable table)
        {
            this.BackAction = action;
            this.Table = table;
        }

        public void Reset()
        {
            this.BackAction = Action.None;
            this.Table = null;
        }

        public override String ToString()
        {
            return "";
        }
    }
}
