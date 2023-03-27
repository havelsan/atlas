
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
    public partial class FTRPackageProcedure : SubActionPackageProcedure
    {
        #region Methods

        //public override void Cancel()
        //{
        //    MedulaProcedureEntryCancel();
        //    base.Cancel();
        //}

        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (accTrx != null)
                return accTrx.SubEpisodeProtocol.Brans.Code;

            return null;
        }

        public override string GetDVORaporTakipNo()
        {
            if (PhysiotherapyOrderDetail.PhysiotherapyOrder != null && PhysiotherapyOrderDetail.PhysiotherapyOrder.PhysiotherapyReports != null)
                return PhysiotherapyOrderDetail.PhysiotherapyOrder.PhysiotherapyReports.ReportNo;

            return null;
        }

        public override bool SendToENabiz(bool isNewInserted)
        {
            if (IsOldAction == true)
                return false;
            if (CurrentStateDefID == FTRPackageProcedure.States.Completed)
            {
                return true;
            }
            return false;
        }

        public override bool CheckSubepisodeClosingDate()
        {
            return false;
        }

        public override void AccountOperationAfterUpdate() { }

        #endregion Methods

    }
}