using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Business.Types
{
    public class ServiceMessage
    {
        private bool isSucceed;
        private string message;

        public bool IsSucceed
        {
            get { return isSucceed; }
            set { isSucceed = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }

    public class ServiceMessage<T>
    {
        private bool isSucceed;
        private string message;
        private T? data;

        public bool IsSucceed
        {
            get { return isSucceed; }
            set { isSucceed = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public T? Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
