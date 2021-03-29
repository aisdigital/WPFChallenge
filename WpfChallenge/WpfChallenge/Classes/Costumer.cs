using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfChallenge.Classes
{
    public class Costumer
    {
        static int idCounter = 0;
        int mID;
        string mName;
        string mEmail;
        string mPhone;
        string mAddress;


        //Constructor
        public Costumer() { mID = idCounter; idCounter++; }

        public Costumer(Costumer original)
        {
            mID = original.mID;
            mName = original.mName;
            mEmail = original.mEmail;
            mPhone = original.mPhone;
            mAddress = original.mAddress;
        }

        //CopyData
        public void CopyData(Costumer newData)
        {
            mName = newData.mName;
            mEmail = newData.mEmail;
            mPhone = newData.mPhone;
            mAddress = newData.mAddress;
        }

        //Gets
        public string GetName() { return mName; }
        public string GetEmail() { return mEmail; }
        public string GetPhone() { return mPhone; }
        public string GetAddess() { return mAddress; }

        //Sets
        public void SetName(string name) { mName = name; }
        public void SetEmail(string email) 
        {
            mEmail = email;
        }
        public void SetPhone(string phone) 
        {
            mPhone = phone;
        }
        public void SetAddress(string address) { mAddress = address; }

        //Validations
        public bool ValidName()
        {
            if (mName != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidEmail()
        {
            if (mEmail.Contains('@'))
            {
                return true;
            }
            return false;
        }
        public bool ValidPhone()
        {
            int num;
            if (int.TryParse(mPhone, out num))
            {
                return true;
            }
            return false;
        }
        public bool ValidAddress()
        {
            if (mAddress != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Reader
        public override string ToString()
        {
            return "Name: " + mName + " /// E-Mail: " + mEmail + " /// Phone: " + mPhone + " /// Address: " + mAddress;
        }
    }
}
