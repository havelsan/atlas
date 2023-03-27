
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
    public  abstract  partial class BaseDeleteRecordDocument : StockAction
    {
    /// <summary>
    /// Aktarılan Belge Numarası
    /// </summary>
        public string ReturningDocumentNumber
        {
            get
            {
                try
                {
#region ReturningDocumentNumber_GetScript                    
                    string retValue = string.Empty;
            if(ReturningDocument != null)
                retValue = ReturningDocument.ToString();
            return retValue;
#endregion ReturningDocumentNumber_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ReturningDocumentNumber") + " : " + ex.Message, ex);
                }
            }
        }

    }
}