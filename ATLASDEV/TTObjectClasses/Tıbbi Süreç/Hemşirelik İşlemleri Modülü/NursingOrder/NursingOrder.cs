
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
    /// Hemşire Takip Gözlem Talimatları (Klinik İşlemleri) 'nin Gerçekleştirildiği Nesnedir
    /// </summary>
    public  partial class NursingOrder : BaseNursingOrder
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "NURSINGAPPLICATION":
                    {
                        NursingApplication value = (NursingApplication)newValue;
#region NURSINGAPPLICATION_SetParentScript
                        if(value!=null)
            {
                MedulaHastaKabul=value.MedulaHastaKabul;
            }
#endregion NURSINGAPPLICATION_SetParentScript
                    }
                    break;
                case "INPATIENTPHYSICIANAPPLICATION":
                    {
                        InPatientPhysicianApplication value = (InPatientPhysicianApplication)newValue;
#region INPATIENTPHYSICIANAPPLICATION_SetParentScript
                        if (value!=null)
            {
                FromResource=value.FromResource;
                MasterResource=value.MasterResource;
                Episode=value.Episode;
                if (value.InPatientTreatmentClinicApp!=null)
                {
                    if (value.InPatientTreatmentClinicApp.NursingApplications.Count>0)
                    {
                        NursingApplication=value.InPatientTreatmentClinicApp.NursingApplications[0];
                    }
                }else if(value.EmergencyIntervention!=null)
                {
                    if (value.EmergencyIntervention.NursingApplications.Count>0)
                    {
                        NursingApplication=value.EmergencyIntervention.NursingApplications[0];
                    } 
                }
                
            }
#endregion INPATIENTPHYSICIANAPPLICATION_SetParentScript
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
            if (OrderDetails == null || OrderDetails.Count == 0)//detaylar clienttan geliyorsa tekrar oluşturma
                CreateOrderDetails();
            CurrentStateDefID=NursingOrder.States.Planned;
            ActionDate = DateTime.Now;
            OrderDate = DateTime.Now;
            #endregion PreInsert
        }

        protected override void PreDelete()
        {
#region PreDelete
            
            base.PreDelete();
          
            throw new Exception(SystemMessage.GetMessage(1179));

#endregion PreDelete
        }

        protected override void PostDelete()
        {
#region PostDelete
            base.PostDelete();

#endregion PostDelete
        }

        protected void PostTransition_Planned2Cancelled()
        {
            // From State : Planned   To State : Cancelled
#region PostTransition_Planned2Cancelled
            Cancel();
#endregion PostTransition_Planned2Cancelled
        }

#region Methods
        public override PeriodicOrderDetail CreateOrderDetail()
        {
            return  (PeriodicOrderDetail) (new NursingOrderDetail(this));
        }
        public override void CreateOrderDetails()
        {
            base.CreateOrderDetails();
        }
        public override void Cancel()
        {
            base.Cancel();
            foreach(NursingOrderDetail nursingOrderDetail in OrderDetails)
            {
                if(nursingOrderDetail.CurrentStateDefID==NursingOrderDetail.States.Execution)
                {
                    nursingOrderDetail.ReasonOfCancel=ReasonOfCancel;
                    ((ITTObject)nursingOrderDetail).Cancel();
                }
                
            }
            
        }
        //override public bool IsPropertyReadonly(TTObjectPropertyDef propDef)
        //{
        //    if (((ITTObject)this).IsNew == true)
        //    {
        //        return false;
        //    }
        //    if (propDef.PropertyDefID != new Guid("506f86d7-780a-40d5-87b0-0443e3c646b3") && propDef.PropertyDefID != new Guid("04abbf28-747a-4b49-9cf0-4b4601f1e311") && propDef.PropertyDefID != new Guid("ef9dab05-aab7-47a8-9666-1876a1a68a50"))
        //        return true;
        //    return false;
        //}
        //override public bool IsParentRelationReadonly(TTObjectRelationDef relDef)
        //{
        //    if (((ITTObject)this).IsNew == true)
        //        return false;
        //    if (relDef.ParentObjectDefID == new Guid("f18cbf08-9ee2-40de-8029-c3f7e739c3a4"))// SubEpisode
        //        return false;
        //    return true;
        //}

        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
            {
                CurrentStateDefID=NursingOrder.States.Planned;
            }

        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(NursingOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == NursingOrder.States.Planned && toState == NursingOrder.States.Cancelled)
                PostTransition_Planned2Cancelled();
        }

    }
}