
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
    public  partial class NursingDailyLifeActivity : BaseNursingDataEntry
    {
        #region Methods
        //protected override bool IsReadOnly()
        //{
        //    if(((ITTObject)this).IsNew!=true)
        //        return true;

        //    return false;
        //}
        public override string GetApplicationSummary()
        {
            string tempString = String.Empty;

            foreach (var dailyLifeActivity in NursingFunctionalDailyLifeActivities)
            {
                if (dailyLifeActivity.IsCheck.HasValue && dailyLifeActivity.IsCheck.Value)
                    tempString += dailyLifeActivity.DailyLifeActivity.Name + ",";
            }

            return tempString;
        }

        public override string GetRowColor()
        {
            return string.Empty;
        }

        #endregion Methods

    }
}