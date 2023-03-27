
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
    /// Kan Ãœrünleri(Testler)
    /// </summary>
    public partial class BloodBankBloodProducts : SubactionProcedureFlowable, IWorkList
    {
        public partial class GetBloodProductBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetBloodProductByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetBloodProducts_Class : TTReportNqlObject
        {
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();

            if (ProductNumber != null)
            {
                foreach (AccountTransaction AccTrx in AccountTransactions)
                {
                    if (AccTrx.CurrentStateDefID != AccountTransaction.States.Cancelled && AccTrx.Description.IndexOf(" (No: ") == -1)
                    {
                        if (ISBTUnitNumber == null || ISBTUnitNumber == String.Empty)
                        {
                            AccTrx.Description = AccTrx.Description + " (No: " + ProductNumber + ")";
                        }
                        else
                        {
                            AccTrx.Description = AccTrx.Description + " (No: " + ProductNumber + ")" + "(ISBTNo: " + ISBTUnitNumber + "-" + ISBTElementCode + ")";
                        }
                    }
                }

                foreach (BloodBankSubProduct bbSub in BloodBankSubProducts)
                {
                    foreach (AccountTransaction AccTrx in bbSub.AccountTransactions)
                    {
                        if (AccTrx.CurrentStateDefID != AccountTransaction.States.Cancelled && AccTrx.Description.IndexOf(" (No: ") == -1)
                        {
                            if (ISBTUnitNumber == null || ISBTUnitNumber == String.Empty)
                            {
                                AccTrx.Description = AccTrx.Description + " (No: " + ProductNumber + ")";
                            }
                            else
                            {
                                AccTrx.Description = AccTrx.Description + " (No: " + ProductNumber + ")" + "(ISBTNo: " + ISBTUnitNumber + "-" + ISBTElementCode + ")";
                            }
                        }
                    }

                    if (ISBTUnitNumber == null || ISBTUnitNumber == String.Empty)
                    {
                        bbSub.ExtraDescription = " (No: " + ProductNumber + ")";
                    }
                    else
                    {
                        bbSub.ExtraDescription = " (No: " + ProductNumber + ")" + "(ISBTNo: " + ISBTUnitNumber + "-" + ISBTElementCode + ")";
                    }

                }

                if (ISBTUnitNumber == null || ISBTUnitNumber == String.Empty)
                {
                    ExtraDescription = " (No: " + ProductNumber + ")";
                }
                else
                {
                    ExtraDescription = " (No: " + ProductNumber + ")" + "(ISBTNo: " + ISBTUnitNumber + "-" + ISBTElementCode + ")";
                }
            }

            #endregion PostUpdate
        }

        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PostTransition_New2Cancelled

            Cancel();

            #endregion PostTransition_New2Cancelled
        }

        #region Methods

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (BloodProductRequest != null && BloodProductRequest.RequestDoctor != null && !string.IsNullOrEmpty(BloodProductRequest.RequestDoctor.DiplomaRegisterNo))
                return BloodProductRequest.RequestDoctor.DiplomaRegisterNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        public override string GetDVOIsbtUniteNo()
        {
            if (!string.IsNullOrEmpty(ISBTUnitNumber))
                return ISBTUnitNumber.ToUpper();

            return null;
        }

        public override string GetDVOIsbtBilesenNo()
        {
            if (!string.IsNullOrEmpty(ISBTElementCode))
                return ISBTElementCode.ToUpper();

            return null;
        }     

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(BloodBankBloodProducts).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == BloodBankBloodProducts.States.New && toState == BloodBankBloodProducts.States.Cancelled)
                PostTransition_New2Cancelled();
        }

    }
}