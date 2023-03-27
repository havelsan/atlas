
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
    /// Lojistik ikmal faaliyetlerinde kullanılan temel detay sınıfıdır
    /// </summary>
    public  partial class LBPurchaseProjectDetail : TTObject
    {
#region Methods
        public void CalculateApproveDetails()
        {
            //Onaylanan, tertip edilen ve red edilen miktarlara göre toplam rakamları oluşturur
            double approved = 0;
            double cancelled = 0;
            foreach (LBApproveDetail lbad in LBApproveDetails)
            {
                if (lbad.ApproveType == LBApproveDetailTypeEnum.Local)
                    approved += (double)lbad.Amount;
                else
                    cancelled += (double)lbad.Amount;
            }
            
            ApprovedAmount = approved;
            CancelledAmount = cancelled;
        }
        
#endregion Methods

    }
}