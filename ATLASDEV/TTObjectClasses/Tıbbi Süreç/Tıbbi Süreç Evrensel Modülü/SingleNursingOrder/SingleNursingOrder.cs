
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
    /// Hemşire Takip Gözlem Talimatları (Anestezi Konsültasyonu)
    /// </summary>
    public  partial class SingleNursingOrder : BaseNursingOrder
    {


        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "PHYSICIANAPPLICATION":
                    {
                        PhysicianApplication value = (PhysicianApplication)newValue;
                        #region PHYSICIANAPPLICATION_SetParentScript
                        if (value != null)
                        {
                            FromResource = value.FromResource;
                            MasterResource = value.MasterResource;
                            Episode = value.Episode;
                            Frequency = TTObjectClasses.FrequencyEnum.Q24H;
                            AmountForPeriod = 1;
                            RecurrenceDayAmount = 1;
                            CurrentStateDefID = SingleNursingOrder.States.New;
                        }
                        #endregion PHYSICIANAPPLICATION_SetParentScript
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
            CurrentStateDefID = SingleNursingOrder.States.New;
#endregion PreInsert
        }

        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
#region PostTransition_New2Cancelled
            
            Cancel();
#endregion PostTransition_New2Cancelled
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
            return  (PeriodicOrderDetail) (new SingleNursingOrderDetail(this));
        }
        public override void CreateOrderDetails()
        {
            base.CreateOrderDetails();
        }
        public override void Cancel()
        {
            base.Cancel();
            CurrentStateDefID = SingleNursingOrder.States.Cancelled;
        }
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
            {
                CurrentStateDefID = SingleNursingOrder.States.New;
            }

        }
        override public bool IsPropertyReadonly(TTObjectPropertyDef propDef)
        {
            if(((ITTObject)this).IsNew==true)
            {
                return false;
            }
            if(propDef.PropertyDefID!=new Guid("506f86d7-780a-40d5-87b0-0443e3c646b3") && propDef.PropertyDefID!=new Guid("04abbf28-747a-4b49-9cf0-4b4601f1e311") && propDef.PropertyDefID!=new Guid("ef9dab05-aab7-47a8-9666-1876a1a68a50") && propDef.PropertyDefID != new Guid("940e9d9a-1bfa-44b5-bbae-5f5a9156c396"))//ActionDate,ReasonOfCancel,WorkListDate,OlapLastUpdate
                return true;
            return false;
        }
        override public bool IsParentRelationReadonly(TTObjectRelationDef relDef)
        {
            if (relDef.RelationDefID == new Guid("ccc2d35b-17a4-49b3-8660-5c407fa412c9") && SingleNursingOrderDetail == null)//SingleNursingOrderDetail
                return false;
            if(relDef.ParentObjectDefID == new Guid("f18cbf08-9ee2-40de-8029-c3f7e739c3a4"))// SubEpisode
                return false;
            if (((ITTObject)this).IsNew == true)
                return false;
            return true;
        }
        
        
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SingleNursingOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SingleNursingOrder.States.New && toState == SingleNursingOrder.States.Cancelled)
                PostTransition_New2Cancelled();
            else if (fromState == SingleNursingOrder.States.Planned && toState == SingleNursingOrder.States.Cancelled)
                PostTransition_Planned2Cancelled();
        }

    }
}