using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfChallenge.Classes;
using Xunit;

namespace WpfChallenge.TestEnviroment
{
    public class Tests
    {
        //FillingTests
        #region

        [Theory]
        [InlineData("Fred Asteir")]
        [InlineData("A2D")]
        [InlineData("Fredreric strifedf ejojeoc fçdjih dsuskshkeu h ruhkurk hkf hruk hr kfru hrkhsrtf htf htesf he flji  iljj lif jlfj ilfjs")]
        void CostumerFillingName(string name)
        {
            Costumer costumer = new Costumer();
            Assert.True(NameFilled(costumer, name));
        }

        [Theory]
        [InlineData("333474389")]
        [InlineData("233-78009")]
        [InlineData("Albert Einstein")]
        void CostumerFillingPhone(string phone)
        {
            Costumer costumer = new Costumer();
            Assert.True(PhoneFilled(costumer, phone));
        }

        [Theory]
        [InlineData("fred@asteir.com")]
        [InlineData("fredric")]
        [InlineData("23792297")]
        void CostumerFillingEmail(string email)
        {
            Costumer costumer = new Costumer();
            Assert.True(EmailFilled(costumer, email));
        }

        [Theory]
        [InlineData("Fred Asteir street")]
        [InlineData("12234 new hampshire")]
        [InlineData("@3$%¨&**")]
        void CostumerFillingAddress(string address)
        {
            Costumer costumer = new Costumer();
            Assert.True(AddressFilled(costumer, address));
        }

        bool NameFilled(Costumer costumer, string name)
        {
            costumer.SetName(name);
            if (costumer.GetName() == name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool PhoneFilled(Costumer costumer, string phone)
        {
            costumer.SetPhone(phone);
            if (costumer.GetPhone() == phone)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool EmailFilled(Costumer costumer, string email)
        {
            costumer.SetEmail(email);
            if (costumer.GetEmail() == email)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool AddressFilled(Costumer costumer, string address)
        {
            costumer.SetAddress(address);
            if (costumer.GetAddess() == address)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion                

        //ValidationTests
        #region

        [Theory]
        [InlineData("Fred Asteir")]
        [InlineData("A2D")]
        [InlineData("Fredreric strifedf ejojeoc fçdjih dsuskshkeu h ruhkurk hkf hruk hr kfru hrkhsrtf htf htesf he flji  iljj lif jlfj ilfjs")]
        void CostumerValidName(string name)
        {
            Costumer costumer = new Costumer();
            Assert.True(NameValid(costumer, name));
        }

        [Theory]
        [InlineData("")]       
        void WRONGCostumerValidName(string name)
        {
            Costumer costumer = new Costumer();
            Assert.False(NameValid(costumer, name));
        }

        [Theory]
        [InlineData("333474389")]
        [InlineData("56")]
        void CostumerValidPhone(string phone)
        {
            Costumer costumer = new Costumer();
            Assert.True(PhoneValid(costumer, phone));
        }

        [Theory]
        [InlineData("233-78009")]
        [InlineData("Albert Einstein")]
        void WRONGCostumerValidPhone(string phone)
        {
            Costumer costumer = new Costumer();
            Assert.False(PhoneValid(costumer, phone));
        }

        [Theory]
        [InlineData("fred@asteir.com")]
        [InlineData("fredric@hdiuhdi.gggrtttt")]
        void CostumerValidEmail(string email)
        {
            Costumer costumer = new Costumer();
            Assert.True(EmailValid(costumer, email));
        }

        [Theory]
        [InlineData("fredasteir.com")]
        [InlineData("23344465")]
        void WRONGCostumerValidEmail(string email)
        {
            Costumer costumer = new Costumer();
            Assert.False(EmailValid(costumer, email));
        }

        [Theory]
        [InlineData("Fred Asteir street")]
        [InlineData("12234 new hampshire")]
        [InlineData("@3$%¨&**")]
        void CostumerValidAddress(string address)
        {
            Costumer costumer = new Costumer();
            Assert.True(AddressValid(costumer, address));
        }

        [Theory]
        [InlineData("")]
        void WRONGCostumerValidAddress(string address)
        {
            Costumer costumer = new Costumer();
            Assert.False(AddressValid(costumer, address));
        }

        bool NameValid(Costumer costumer, string name)
        {
            costumer.SetName(name);
            return costumer.ValidName();
        }
        bool PhoneValid(Costumer costumer, string phone)
        {
            costumer.SetPhone(phone);
            return costumer.ValidPhone();
        }
        bool EmailValid(Costumer costumer, string email)
        {
            costumer.SetEmail(email);
            return costumer.ValidEmail();
        }
        bool AddressValid(Costumer costumer, string address)
        {
            costumer.SetAddress(address);
            return costumer.ValidAddress();
        }

        #endregion                
    }
}


