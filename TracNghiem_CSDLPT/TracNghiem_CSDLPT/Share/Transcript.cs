using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiem_CSDLPT.Share
{
    public class Transcript
    {
        public String StudentCode { get; set; }
        public String FullName { get; set; }
        public String MarksStr { get; private set; }

        private float _marks;

        public float Marks
        {
            get { return _marks; }

            set
            {
                _marks = value;

                ConverToString();
            }
        }


        private void ConverToString()
        {
            String str_mark = _marks.ToString();

            String[] str = str_mark.Split('.');

            if(str.Length == 1)
            {
                MarksStr = "Không";
                return;
            }

            String words = String.Empty;

            words += ReadNumber(int.Parse(str[0]));
            words += " phẩy ";
            words += ReadNumber(int.Parse(str[1]));

            MarksStr = words;
        }

        private String ReadNumber(int number)
        {
            string[] Ones = { "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín", "Mười", "Mười một", "Mười hai", "Mười ba", "Mười bốn", "Mười lăm", "Mười sáu", "Mười bảy", "Mười tám", "Mười chín" };
            string[] Tens = { "Mười", "Hai mươi", "Ba mươi", "Bốn mươi", "Năm mươi", "Sáu mươi", "Bảy mươi", "Tám mươi", "Chín mươi" };

            string strWords = "";

            if (number > 999 && number < 10000)
            {
                int i = number / 1000;
                strWords = strWords + Ones[i - 1] + " Ngàn ";
                number = number % 1000;
            }


            if (number > 99 && number < 1000)
            {
                int i = number / 100;
                strWords = strWords + Ones[i - 1] + " Trăm ";
                number = number % 100;
            }

            if (number > 19 && number < 100)
            {
                int i = number / 10;
                strWords = strWords + Tens[i - 1] + " ";
                number = number % 10;
            }

            if (number > 0 && number < 20)
            {
                strWords = strWords + Ones[number - 1];
            }

            if (number == 0)
            {
                strWords = "Không";
            }

            return strWords;
        }
    }
}
