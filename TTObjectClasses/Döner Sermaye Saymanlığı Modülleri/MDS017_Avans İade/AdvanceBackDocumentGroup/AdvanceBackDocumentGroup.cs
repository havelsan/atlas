
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
    /// Avans İade Döküman Grubu
    /// </summary>
    public  partial class AdvanceBackDocumentGroup : AccountDocumentGroup
    {
#region Methods
        public AdvanceBackDocumentDetail AddDocumentDetail(string pDesc, int pAmount, double pUnitPrice)
        {
            AdvanceBackDocumentDetail advBackDet = new AdvanceBackDocumentDetail(ObjectContext);
            advBackDet.Description = pDesc;
            advBackDet.Amount = pAmount;
            advBackDet.UnitPrice = pUnitPrice;
            advBackDet.AccountDocumentGroup = this;
            AdvanceBackDocumentDetails.Add(advBackDet);
            return advBackDet;
        }
        
#endregion Methods

    }
}