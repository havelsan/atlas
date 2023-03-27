
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
    public  partial class SubSurgeryProcedure : SurgeryProcedure
    {
        public partial class GetPersonnelBySubSurgery_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "SUBSURGERY":
                    {
                        SubSurgery value = (SubSurgery)newValue;
                        #region SUBSURGERY_SetParentScript
                        if (value != null)
                        {
                            Surgery = value.Surgery;
                            ProcedureSpeciality = value.ProcedureSpeciality;
                            Department = value.FromResource;

                            // SubSurgery'ın ProcedureDoctor'unu kendi ProcedureDoctor alanına set eder
                            if (value.ProcedureDoctor != null)
                                ProcedureDoctor = value.ProcedureDoctor;
                            //
                            if (ActionDate == null)
                            {
                                ActionDate = value.Surgery.GetProperSurgeryDateOrRecTime();
                            }
                        }
                        #endregion SUBSURGERY_SetParentScript
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

#endregion PreInsert
        }

      
#region Methods
        public override void SetPerformedDate()
        {
            if (Surgery.SurgeryStartTime != null && Surgery.SurgeryStartTime < CreationDate)
                CreationDate = Surgery.SurgeryStartTime;
            PerformedDate = Surgery.SurgeryEndTime;
        }
        
        public override bool GetProcedureDoctorFromMyEpisodeAction()// Episode Actionı Surgery oysa ProcedureDoctorunu SubSurgeryden almalı
        {
            return false;
        }
        
#endregion Methods

    }
}