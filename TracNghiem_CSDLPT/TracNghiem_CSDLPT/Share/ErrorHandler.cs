using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TracNghiem_CSDLPT.Share
{
    public static class ErrorHandler
    {
        public delegate void ControlStringConsumer(Control control, string text);

        public static void ShowError(Control cShow, String[] errorCode)
        {
            if(errorCode.Length == 0)
            {
                return;
            }

            if(errorCode.Length == 1)
            {
                SetText(cShow, ErrorCode.GetPropertyValue(errorCode[0]));
            }
            else
            {
                String errMess = String.Empty;

                foreach(String str in errorCode)
                {
                    errMess += ErrorCode.GetPropertyValue(str);
                }
                SetText(cShow, errMess);
            }
            AddTimerToShow(cShow);
        }

        public static void SetText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new ControlStringConsumer(SetText), new object[] { control, text });  // invoking itself
            }
            else
            {
                control.Text = text;      // the "functional part", executing only on the main thread
            }
        }

        private static void AddTimerToShow(Control cShow)
        {
            TimerAction.AddTimer((sender, elh)=> {
                SetText(cShow, String.Empty);
            });
        }


    }
}
