using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utlity
{
    public class Result : IResult
    {
        private int _affectedRows = 0;
        public int AffectedRows
        {
            get
            {
                return _affectedRows;
            }

            set
            {
                _affectedRows = value;
            }
        }

        private string _message = string.Empty;
        public string Message
        {
            get
            {
                return _message;
            }

            set
            {
                _message = value;
            }
        }
        private dynamic _scalar;
        public dynamic Scalar
        {
            get
            {
                return _scalar;
            }

            set
            {
                _scalar = value;
            }
        }


        private bool _success = false;
        public bool Success
        {
            get
            {
                return _success;
            }

            set
            {
                _success = value;
            }
        }

        public dynamic Source { get; set; }

    }
}
