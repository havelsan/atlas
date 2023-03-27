
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
    /// Ameliyat
    /// </summary>
    public partial class MainSurgeryProcedure : SurgeryProcedure
    {
        public partial class GetMainSurgeryPersonnelBySurgery_Class : TTReportNqlObject
        {
        }

        public partial class GetSurgeryProcedureCountByPatientGroupByDate_Class : TTReportNqlObject
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "MAINSURGERY":
                    {
                        Surgery value = (Surgery)newValue;
                        #region MAINSURGERY_SetParentScript
                        if (value != null)
                        {
                            Surgery = value;
                            ProcedureSpeciality = value.ProcedureSpeciality;
                            Department = value.FromResource;
                            if (ActionDate == null)
                            {
                                ActionDate = value.GetProperSurgeryDateOrRecTime();
                            }
                        }
                        #endregion MAINSURGERY_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            ControlToothNumber();
            #endregion PreInsert
        }
        
        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();
            ControlToothNumber();
            #endregion PreUpdate
        }

        #region Methods
        public void ControlToothNumber()
        {
            if (ProcedureObject != null && ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri && string.IsNullOrEmpty(ToothNumber))
                throw new TTException(TTUtils.CultureService.GetText("M25498", "Diş ameliyatları için diş numarası girilmesi zorunludur."));
        }

        public override void SetPerformedDate()
        {
            // CreationDate  Performed datedenBüyükse güncellenmeli
            if (Surgery.SurgeryStartTime != null && Surgery.SurgeryStartTime < CreationDate)
                CreationDate = Surgery.SurgeryStartTime;
            PerformedDate = Surgery.SurgeryEndTime;


        }


        #endregion Methods

    }
}