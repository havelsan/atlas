
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
    /// Satınalma Mevcut Arttırma İşlemi
    /// </summary>
    public partial class InheldIncreasingProcess : EntryCorrectionProcess
    {

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            #endregion PreInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate

            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            #endregion PostUpdate
        }

        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
            #region PreTransition_New2Completed

            foreach (InheldIncreasingProcessDet detail in this.InheldIncreasingProcessDets)
            {
                if (detail.AddedAmount > 0)
                {
                    detail.StockActionDetailIn.Amount += detail.AddedAmount;
                    StockTransaction stockTransaction = detail.StockActionDetailIn.StockTransactions.Select(string.Empty)[0];
                    stockTransaction.Amount += detail.AddedAmount;
                    stockTransaction.Stock.Inheld += detail.AddedAmount;
                    stockTransaction.Stock.TotalIn += detail.AddedAmount;
                    stockTransaction.Stock.TotalInPrice += (BigCurrency)detail.AddedAmount * stockTransaction.UnitPrice;
                    stockTransaction.Stock.StockLevels.Select(string.Empty)[0].Amount += detail.AddedAmount;
                }
            }

            #endregion PreTransition_New2Completed
        }

        protected void UndoTransition_New2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Completed
            #region UndoTransition_New2Completed
            #endregion UndoTransition_New2Completed
        }

        protected void PreTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PreTransition_New2Cancelled

            #endregion PreTransition_New2Cancelled
        }

        protected void UndoTransition_New2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Cancelled
            #region UndoTransition_New2Cancelled
            throw new Exception(SystemMessage.GetMessage(1228));
            #endregion UndoTransition_New2Cancelled
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancelled
            #endregion PreTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
            #region UndoTransition_Completed2Cancelled
            #endregion UndoTransition_Completed2Cancelled
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InheldIncreasingProcess).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == InheldIncreasingProcess.States.New && toState == InheldIncreasingProcess.States.Completed)
                PreTransition_New2Completed();
            else if (fromState == InheldIncreasingProcess.States.New && toState == InheldIncreasingProcess.States.Cancelled)
                PreTransition_New2Cancelled();
            else if (fromState == InheldIncreasingProcess.States.Completed && toState == InheldIncreasingProcess.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InheldIncreasingProcess).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == InheldIncreasingProcess.States.New && toState == InheldIncreasingProcess.States.Completed)
                UndoTransition_New2Completed(transDef);
            else if (fromState == InheldIncreasingProcess.States.New && toState == InheldIncreasingProcess.States.Cancelled)
                UndoTransition_New2Cancelled(transDef);
            else if (fromState == InheldIncreasingProcess.States.Completed && toState == InheldIncreasingProcess.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
        }
    }
}