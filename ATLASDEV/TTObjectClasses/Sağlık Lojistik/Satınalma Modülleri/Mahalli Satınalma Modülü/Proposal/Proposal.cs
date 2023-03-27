
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
    /// Mahalli Satınalmada Firmaların Verdiği Her Teklif İçin Kullanılan Sınıf. Her Firma İçin Bir Adet Instance Yaratılır
    /// </summary>
    public  partial class Proposal : BaseAction
    {
        public partial class GetProposalledFirms_Class : TTReportNqlObject 
        {
        }

#region Methods
        //
        public void AddDetails()
        {
            foreach (PurchaseProjectDetail ppd in PurchaseProject.PurchaseProjectDetails)
            {
                ProposalDetail propd = new ProposalDetail(ObjectContext);
                propd.Proposal = this;
                propd.PurchaseItemDef = ppd.PurchaseItemDef;
                propd.Amount = ppd.Amount;
                propd.PurchaseProjectDetail = ppd;
                propd.Status = ProposalDetailStatusEnum.New;
                propd.OrderNo = ppd.OrderNO;
            }
        }
        
#endregion Methods

    }
}