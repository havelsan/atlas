
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
    public  partial class ProcedureOrderTreatmentMaterial : BaseTreatmentMaterial
    {
        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            
            if(SubactionProcedureFlowable!=null)
            {
                if(((ProcedureOrderDetail)SubactionProcedureFlowable).EpisodeAction != null)
                {
                    EpisodeAction ea = ((ProcedureOrderDetail)SubactionProcedureFlowable).EpisodeAction;
                    if(ea is ProcedureOrder)
                        ((ProcedureOrder)ea).TreatmentMaterials.Add(this);
//                    else if(ea is FollowUpExamination)
//                        ((FollowUpExamination)ea).TreatmentMaterials.Add(this);
//                    else if(ea is InPatientPhysicianApplication)
//                        ((InPatientPhysicianApplication)ea).TreatmentMaterials.Add(this);
                }
//                else if(((ProcedureOrderDetail)this.SubactionProcedureFlowable).ConsultationProcedure != null)
//                {
//                    
//                }
                //((ProcedureOrderDetail)this.SubactionProcedureFlowable).PatientExamination.TreatmentMaterials.Add(this);
            }
#endregion PreInsert
        }

#region Methods
        override public object GetDVO(AccountTransaction AccTrx)
        {
            return base.GetDVO(AccTrx);
        }
        
#endregion Methods

    }
}