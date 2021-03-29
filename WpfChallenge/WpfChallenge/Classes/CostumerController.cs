using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfChallenge.Classes
{
     public class CostumerController
    {
        static CostumerController mInstance;

        List<Costumer> mCostumers;
        
        Costumer mCurrentCostumer;

        //Singleton
        public static CostumerController GetInstance()
        {
            if (mInstance == null)
            {
                mInstance = new CostumerController();
            }
            return mInstance;
        }
        public CostumerController()
        {
            mCostumers = new List<Costumer>();
            mCurrentCostumer = null;
        }
        public Costumer GetCostumerByIndex(int index)
        {
            if (mCostumers[index] != null)
            {
                mCurrentCostumer = mCostumers[index];
                return mCostumers[index];
            }
            return null;
        }
        public void AddCostumer(Costumer costumer)
        {
            Costumer newCostumer = new Costumer(costumer);
            mCostumers.Add(newCostumer);
        }
        public void RemoveCostumer(Costumer costumer)
        {
            mCostumers.Remove(costumer);
        }

        public Costumer GetCurrentCostumer() { return mCurrentCostumer; }
        public void SetCurrentCostumer(Costumer costumer) { mCurrentCostumer = costumer; }
        public Costumer[] GetAllCostumers()
        {
            Costumer[] result = new Costumer[mCostumers.Count];
            for (int i = 0; i < mCostumers.Count; i++)
            {
                result[i] = mCostumers[i];
            }
            return result;
        }
    }
}
