using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class KarimBookSubject
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                
            }
        }

        private string _subjectName;
        public string SubjectName
        {
            get { return _subjectName; }
            set
            {
                _subjectName = value;

            }
        }
    }
}
