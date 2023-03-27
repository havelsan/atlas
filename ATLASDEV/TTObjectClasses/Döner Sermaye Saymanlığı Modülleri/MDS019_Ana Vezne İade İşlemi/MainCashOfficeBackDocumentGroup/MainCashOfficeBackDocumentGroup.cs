
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
    /// <summary>
    /// Vezne İade Döküman Grubu
    /// </summary>
    public  partial class MainCashOfficeBackDocumentGroup : AccountDocumentGroup
    {
#region Methods
        public void AddDocumentDetail(string pDesc, int pAmount, double pUnitPrice)
        {
            MainCashOfficeBackDocumentDetail cdet = new MainCashOfficeBackDocumentDetail(ObjectContext);
            cdet.Description = pDesc;
            cdet.Amount = pAmount;
            cdet.UnitPrice = pUnitPrice;
            cdet.AccountDocumentGroup = this;
            MainCashOfficeBackDocumentDetails.Add(cdet);
        }
        
#endregion Methods

    }
}