using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Example
{
    class Storage
    {
        // Keep private for singleton pattern
        private static Storage mInstance;

        private static string FILENAME_PATH = "data.txt";

        private Storage(){}

        public static Storage Instance
        {
            get
            {
                if(mInstance == null)
                {
                    mInstance = new Storage();
                }
                return mInstance;
            }
        }

        // Saves the user information to a text file
        // Returns success of saving
        public Boolean saveInfo(UserInfo info)
        {
            Boolean ret = false;
            string[] data = { info.mFirst, info.mMI, info.mLast, info.mEmail, info.mGender };
            System.IO.File.WriteAllLines(FILENAME_PATH, data);

            string[] test = System.IO.File.ReadAllLines(FILENAME_PATH);
            ret = data.SequenceEqual(test);
            return ret;
        }

        // Returns the saved UserInfo data
        public UserInfo readInfo()
        {
            UserInfo info = null;
            try
            {
                string[] data = File.ReadAllLines(FILENAME_PATH);
                if (data.Length >= 5)
                {
                    info = new UserInfo(data[0], data[1], data[2], data[3], data[4]);
                }
            }
            catch(FileNotFoundException ex)
            {
                // File not found, no saved userinfo
            }
            
            return info;
        }

    }
}
