
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public  partial class StockActionSignDetail : TTObject
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "SIGNUSER":
                    {
                        ResUser value = (ResUser)newValue;
#region SIGNUSER_SetParentScript
                        if(value != null)
            {
                string name = string.Empty;
                if (value.MilitaryClass != null)
                    name = name + value.MilitaryClass.ShortName;

                if (value.Rank != null)
                    name = name + value.Rank.ShortName;


                //this.EmploymentRecordID = value.EmploymentRecordID;
                NameString = name + value.Name;
                
            }
#endregion SIGNUSER_SetParentScript
                    }
                    break;

            }
        }

        public static List<StockActionSignDetail> StockActionSignUsersMethod(SignUserTypeEnum[] signUserTypes)
        {
            List<StockActionSignDetail> stockActionSingDetails = new List<StockActionSignDetail>(); 
            foreach(SignUserTypeEnum signUserReturn in signUserTypes)
            {
                TTObjectContext context = new TTObjectContext(false);
                StockActionSignDetail stockActionSignDetail = new StockActionSignDetail(context);
                stockActionSignDetail.SignUserType = signUserReturn;
                stockActionSignDetail.IsDeputy = false;
                stockActionSingDetails.Add(stockActionSignDetail);
            }
            return stockActionSingDetails;
        }

    }
}