using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiem_CSDLPT.Share
{
    public class TestInfo
    {
        public String StudentCode { get; set; }
        public String StudentName { get; set; }
        public String CourseCode { get; set; }
        public String CourseName { get; set; }
        public int TimesStep { get; set; }
        public int TotalTime { get; set; }
        public DateTime DateExam { get; set; }
        public String ClassName { get; set; }

        public List<ExamTest> listQuestion { get; set; }
    }
}
