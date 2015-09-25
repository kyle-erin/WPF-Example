using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Example
{
    class UserInfo
    {
        // First name
        public string mFirst
        {
            get; set;
        }

        // Middle initial
        public string mMI
        {
            get; set;
        }

        // Last name
        public string mLast
        {
            get; set;
        }

        // Email
        public string mEmail
        {
            get; set;
        }

        // Gender
        public string mGender
        {
            get; set;
        }

        public UserInfo(string first, string mi, string last, string email, string gender)
        {
            mFirst = first;
            mMI = mi;
            mLast = last;
            mEmail = email;
            mGender = gender;
        }
    }
}
