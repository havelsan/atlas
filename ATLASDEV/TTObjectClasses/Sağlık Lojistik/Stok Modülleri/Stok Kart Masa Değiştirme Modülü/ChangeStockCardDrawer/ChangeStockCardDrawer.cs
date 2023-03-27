
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
    /// Stok Kart Masa Değiştirme
    /// </summary>
    public  partial class ChangeStockCardDrawer : BaseAction, IWorkListBaseAction
    {
        public partial class GetChangeStockCardDrawerReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetChangeStockCardDrawerByNewCardDrawer_Class : TTReportNqlObject 
        {
        }

        public partial class GetChangeStockCardDrawerByOldCardDrawer_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "NEWRESCARDDRAWER":
                    {
                        ResCardDrawer value = (ResCardDrawer)newValue;
#region NEWRESCARDDRAWER_SetParentScript
                        if (value != null)
            {
                if(OldResCardDrawer != null)
                {
                    if (value.ObjectID.Equals(OldResCardDrawer.ObjectID))
                        throw new TTException(SystemMessage.GetMessageV3(712, new string[] { OldResCardDrawer.Name.ToString(), value.Name.ToString() })); 
                }
            }
#endregion NEWRESCARDDRAWER_SetParentScript
                    }
                    break;
                case "STOCKCARD":
                    {
                        StockCard value = (StockCard)newValue;
#region STOCKCARD_SetParentScript
                        //                        if (value != null)
//                        {
//                            if (value.CardDrawer == null)
//                                throw new TTException("Masası olmayan kartın masasını değiştiremezsiniz.\r\nMasası olmayan kartların masa tanımını Stok Kart Tanımlarından yapınız.");
//                        }
#endregion STOCKCARD_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            

            StockCard.CardDrawer = OldResCardDrawer;

#endregion PostTransition_Completed2Cancelled
        }

        protected void PreTransition_New2Approved()
        {
            // From State : New   To State : Approved
#region PreTransition_New2Approved
            
            
            if(OldResCardDrawer != null)
            {
                if (OldResCardDrawer.ObjectID.Equals(NewResCardDrawer.ObjectID))
                    throw new TTException(SystemMessage.GetMessageV3(712, new string[] { OldResCardDrawer.Name.ToString(), NewResCardDrawer.Name.ToString()})); 
            }
            //this.StockCard.CardDrawer = NewResCardDrawer;
#endregion PreTransition_New2Approved
        }

        protected void PostTransition_Approved2Completed()
        {
            // From State : Approved   To State : Completed
#region PostTransition_Approved2Completed
            
            

            AccountancyStockCard accountancyStockCard = StockCard.GetAccountancyStockCard(AccountingTerm.Accountancy);
            if (accountancyStockCard != null)
            {
                accountancyStockCard.CardDrawer = NewResCardDrawer;
            }
            else
            {
                AccountancyStockCard newAccountancyStockCard = new AccountancyStockCard(ObjectContext);
                newAccountancyStockCard.StockCard = StockCard;
                newAccountancyStockCard.Accountancy = AccountingTerm.Accountancy;
                newAccountancyStockCard.CardDrawer = NewResCardDrawer;
                newAccountancyStockCard.CreationDate = Common.RecTime();
            }

#endregion PostTransition_Approved2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ChangeStockCardDrawer).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ChangeStockCardDrawer.States.New && toState == ChangeStockCardDrawer.States.Approved)
                PreTransition_New2Approved();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ChangeStockCardDrawer).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ChangeStockCardDrawer.States.Completed && toState == ChangeStockCardDrawer.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == ChangeStockCardDrawer.States.Approved && toState == ChangeStockCardDrawer.States.Completed)
                PostTransition_Approved2Completed();
        }

    }
}