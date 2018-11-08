using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSystemConsole
{
    [Serializable]
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public Answer() {  }
        public Answer(int AnswerId, string AnswerText)
        {
            this.AnswerId = AnswerId;
            this.AnswerText = AnswerText;
        }
        public override string ToString()
        {
            return String.Format("\t{0,2} {1};", AnswerId, AnswerText);
        }
    }
}