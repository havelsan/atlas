
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
    /// El Senedi İade Belgesi için kullanılan temel sınıftır
    /// </summary>
    public  partial class VoucherReturnDocument : StockAction, IStockTransferTransaction, IVoucherReturnDocument
    {
        public partial class GetVoucherReturnDocumentCensusReportQuery_Class : TTReportNqlObject 
        {
        }

        protected void PostTransition_Approval2New()
        {
            // From State : Approval   To State : New
#region PostTransition_Approval2New
            
            foreach(VoucherReturnDocumentMaterial voucherReturnDocumentMaterial in VoucherReturnDocumentMaterials)
            {
                voucherReturnDocumentMaterial.RequireAmount = voucherReturnDocumentMaterial.Amount ;
            }

#endregion PostTransition_Approval2New
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(VoucherReturnDocument).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == VoucherReturnDocument.States.Approval && toState == VoucherReturnDocument.States.New)
                PostTransition_Approval2New();
        }
        #region Methods
        #region IStockOutTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }

        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        #region IStockTransferTransaction Members
        public void SetDestinationStore(Store value)
        {
            DestinationStore = value;
        }
        #endregion 
        #endregion
    }
}