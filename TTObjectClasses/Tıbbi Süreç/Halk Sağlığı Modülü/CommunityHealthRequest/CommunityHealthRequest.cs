
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
    public  partial class CommunityHealthRequest : BaseAction, IWorkListBaseAction
    {
        public double? ToplamMeq
        {
            get
            {
                try
                {
#region ToplamMeq_GetScript                    
                    double toplamMeq = 0;
                foreach (var procedure in Procedures)
                {
                    toplamMeq = toplamMeq + (double) procedure.Meq ;
                }
                return toplamMeq;
#endregion ToplamMeq_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ToplamMeq") + " : " + ex.Message, ex);
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "COMMUNITYHEALTHPAYER":
                    {
                        CommunityPayer value = (CommunityPayer)newValue;
#region COMMUNITYHEALTHPAYER_SetParentScript
                        if(MyGeneralInvoice != null)
            {
                if(MyGeneralInvoice.CurrentStateDefID == GeneralInvoice.States.Invoiced)
                    throw new TTUtils.TTException("'Hizmet Karşılığı Kurum Faturası' işlemi tamamlandıktan sonra Kurum değiştirilemez");
                else
                {
                    MyGeneralInvoice.CommunityHealthPayer = value;
                }
            }
#endregion COMMUNITYHEALTHPAYER_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected void PostTransition_New2RequestAcception()
        {
            // From State : New   To State : RequestAcception
#region PostTransition_New2RequestAcception
            
            FireGeneralInvoice();
#endregion PostTransition_New2RequestAcception
        }

        protected void UndoTransition_New2RequestAcception(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : RequestAcception
#region UndoTransition_New2RequestAcception
            if(!IsNoCharge())
            {
                NoBackStateBack();
            }
#endregion UndoTransition_New2RequestAcception
        }

        protected void PreTransition_Procedure2Cancelled()
        {
            // From State : Procedure   To State : Cancelled
#region PreTransition_Procedure2Cancelled
            CheckCancel();
#endregion PreTransition_Procedure2Cancelled
        }

        protected void UndoTransition_Procedure2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Procedure   To State : Cancelled
#region UndoTransition_Procedure2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Procedure2Cancelled
        }

        protected void PostTransition_RequestAcception2Procedure()
        {
            // From State : RequestAcception   To State : Procedure
#region PostTransition_RequestAcception2Procedure
            CheckIfGeneralInvoiceIsCompleted();
#endregion PostTransition_RequestAcception2Procedure
        }

        protected void UndoTransition_RequestAcception2Procedure(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Procedure
#region UndoTransition_RequestAcception2Procedure
            if(!IsNoCharge())
            {
                NoBackStateBack();
            }
#endregion UndoTransition_RequestAcception2Procedure
        }

        protected void PreTransition_RequestAcception2Cancelled()
        {
            // From State : RequestAcception   To State : Cancelled
#region PreTransition_RequestAcception2Cancelled
            CheckCancel();
#endregion PreTransition_RequestAcception2Cancelled
        }

        protected void UndoTransition_RequestAcception2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Cancelled
#region UndoTransition_RequestAcception2Cancelled
            NoBackStateBack();
#endregion UndoTransition_RequestAcception2Cancelled
        }

#region Methods
        public bool IsNoCharge()
        {
            if(NoCharge.HasValue)
            {
                return NoCharge.Value;
            }
            return false;
        }
        
        
        public void FireGeneralInvoice()
        {
            if(!IsNoCharge())
            {
                if (MyGeneralInvoice == null)
                {
                    MyGeneralInvoice  = new GeneralInvoice(ObjectContext, this);
                }
            }
        }
        
        public void CheckIfGeneralInvoiceIsCompleted()
        {
            if(!IsNoCharge())
            {
                if(MyGeneralInvoice == null)
                    throw new TTUtils.TTException("'Hizmet Karşılığı Kurum Faturası' işlemi başlatılmamıştır. İşleme devam edilemez");
                else
                {
                    if(MyGeneralInvoice.CurrentStateDefID != GeneralInvoice.States.Invoiced)
                        throw new TTUtils.TTException("'Hizmet Karşılığı Kurum Faturası' işlemi tamamlanmadan işleme devam edilemez");
                }
            }

        }
        
        public void CheckCancel()
        {
            if(!IsNoCharge())
            {
                if(MyGeneralInvoice != null)
                {
                    if(MyGeneralInvoice.CurrentStateDefID == GeneralInvoice.States.Invoiced)
                        throw new TTUtils.TTException("'Hizmet Karşılığı Kurum Faturası' işlemi tamamlandığı için işleme iptal edilemez");
                    else if(MyGeneralInvoice.CurrentStateDefID == GeneralInvoice.States.New)
                    {
                        MyGeneralInvoice.CurrentStateDefID = GeneralInvoice.States.Cancelled;
                    }
                }
            }

        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CommunityHealthRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CommunityHealthRequest.States.Procedure && toState == CommunityHealthRequest.States.Cancelled)
                PreTransition_Procedure2Cancelled();
            else if (fromState == CommunityHealthRequest.States.RequestAcception && toState == CommunityHealthRequest.States.Cancelled)
                PreTransition_RequestAcception2Cancelled();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CommunityHealthRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CommunityHealthRequest.States.New && toState == CommunityHealthRequest.States.RequestAcception)
                PostTransition_New2RequestAcception();
            else if (fromState == CommunityHealthRequest.States.RequestAcception && toState == CommunityHealthRequest.States.Procedure)
                PostTransition_RequestAcception2Procedure();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CommunityHealthRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CommunityHealthRequest.States.New && toState == CommunityHealthRequest.States.RequestAcception)
                UndoTransition_New2RequestAcception(transDef);
            else if (fromState == CommunityHealthRequest.States.Procedure && toState == CommunityHealthRequest.States.Cancelled)
                UndoTransition_Procedure2Cancelled(transDef);
            else if (fromState == CommunityHealthRequest.States.RequestAcception && toState == CommunityHealthRequest.States.Procedure)
                UndoTransition_RequestAcception2Procedure(transDef);
            else if (fromState == CommunityHealthRequest.States.RequestAcception && toState == CommunityHealthRequest.States.Cancelled)
                UndoTransition_RequestAcception2Cancelled(transDef);
        }

    }
}