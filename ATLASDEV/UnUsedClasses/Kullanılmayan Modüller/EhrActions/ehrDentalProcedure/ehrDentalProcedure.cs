
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
    public  partial class ehrDentalProcedure : ehrSubactionProcedure
    {
#region Methods
        protected override void OnBeforeImportFromObject(DataRow dataRow)
        {
            if(dataRow["TOOTHNUMBER"] != DBNull.Value)
            {
                string toothNum = dataRow["TOOTHNUMBER"].ToString();
                int toothInt;
                bool found = false;
                if (int.TryParse(toothNum, out toothInt))
                {
                    TTDataDictionary.TTDataType dt = TTObjectDefManager.Instance.DataTypes["TOOTHNUMBERENUM"];
                    if (dt.EnumValueDefs.ContainsKey(toothInt))
                        found = true;
                }
                        
                if (found == false)
                    dataRow["TOOTHNUMBER"] = DBNull.Value;
            }
        }
        
#endregion Methods

    }
}