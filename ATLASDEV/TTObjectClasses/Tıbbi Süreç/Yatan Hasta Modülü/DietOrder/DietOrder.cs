
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
    /// Yatan Hasta Diyet Order
    /// </summary>
    public  partial class DietOrder : BaseDietOrder
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "INPATIENTPHYSICIANAPPLICATION":
                    {
                        InPatientPhysicianApplication value = (InPatientPhysicianApplication)newValue;
                        #region INPATIENTPHYSICIANAPPLICATION_SetParentScript
                        if (value != null)
                        {
                            List<ResSection> actionDefualtMasterResourcesList = EpisodeAction.AcionDefualtMasterResources(ObjectContext, ActionTypeEnum.DietOrder, this);
                            foreach (var defualtMasterResource in actionDefualtMasterResourcesList)
                            {
                                MasterResource = (ResSection)defualtMasterResource;
                                break;
                            }
                            if (MasterResource == null)
                                MasterResource = (ResSection)value.MasterResource;
                            FromResource = (ResSection)value.MasterResource;


                            //this.FromResource = value.FromResource;
                            //this.MasterResource = value.MasterResource;
                            Episode = value.Episode;
                            //if (value.InPatientTreatmentClinicApp != null)
                            //{
                            //    if (value.InPatientTreatmentClinicApp.NursingApplications.Count > 0)
                            //    {
                            //        this.NursingApplication = value.InPatientTreatmentClinicApp.NursingApplications[0];
                            //    }
                            //}
                            //else if (value.EmergencyIntervention != null)
                            //{
                            //    if (value.EmergencyIntervention.NursingApplications.Count > 0)
                            //    {
                            //        this.NursingApplication = value.EmergencyIntervention.NursingApplications[0];
                            //    }
                            //}

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
            CreateOrderDetails();
            CurrentStateDefID = DietOrder.States.Planned;
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
            return (PeriodicOrderDetail)(new DietOrderDetail(this));
        }
        public override void CreateOrderDetails()
        {
            base.CreateOrderDetails();
        }
        public override void Cancel()
        {
            base.Cancel();
            foreach (DietOrderDetail dietOrderDetail in OrderDetails)
            {
                if (dietOrderDetail.CurrentStateDefID == DietOrderDetail.States.Execution)
                {
                    dietOrderDetail.ReasonOfCancel = ReasonOfCancel;
                    ((ITTObject)dietOrderDetail).Cancel();
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
                CurrentStateDefID = DietOrder.States.Planned;
            }

        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DietOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DietOrder.States.Planned && toState == DietOrder.States.Cancelled)
                PostTransition_Planned2Cancelled();
        }
    }
}