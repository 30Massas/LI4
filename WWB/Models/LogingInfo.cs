using System;
namespace WorldWideBasketball.Models
{
    public class LogingInfo
    {
        private Object t;

        private bool logged;

        private int status;
        /*  0 - nothing
         *  1 - created with success/registered recently
           -1 - email address invalid
            2 - passwords not equal
            3 - logged recently
            4 - recently logged out
            5 - wrong email/password
            6 - other
            7 - email address already in use
            8 - invalid Date
        */
        public LogingInfo()
        {
            this.logged = false;
            this.status = 0;
            this.t = null;
        }
        public LogingInfo(bool b)
        {
            this.logged = b;
            this.status = 0;
        }

        public bool getLogged()
        {
            return this.logged;
        }

        public void setLogged(bool b)
        {
            this.logged = b;
        }

        public int getStatus()
        {
            return this.status;
        }

        public void setStatus(int s)
        {
            this.status = s;
        }

        public Object getObject()
        {
            return this.t;
        }

        public void setObject(Object t)
        {
            this.t = t;
        }

    }
}
