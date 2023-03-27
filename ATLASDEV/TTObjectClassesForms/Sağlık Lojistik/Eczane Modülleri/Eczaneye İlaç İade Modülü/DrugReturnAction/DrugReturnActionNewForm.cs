
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Eczaneye İlaç İade
    /// </summary>
    public partial class DrugReturnActionNewForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
            #region DrugReturnActionNewForm_PreScript
            base.PreScript();

            if (this._DrugReturnAction.Episode.PatientStatus == PatientStatusEnum.Outpatient)
            {
                throw new Exception("Ayaktan hastalar için Eczaneye İlaç İade işlemi yapılamaz.");
            }

            Dictionary<DrugOrderTransaction, double> allDrugOrderTransaction = DrugOrderTransaction.GetReturnableDrugOrderTransactions(_DrugReturnAction.Episode);
            foreach (KeyValuePair<DrugOrderTransaction, double> drugOrderTransaction in allDrugOrderTransaction)
            {
                DrugReturnActionDetail drugReturnActionDetail = new DrugReturnActionDetail(_DrugReturnAction.ObjectContext);
                drugReturnActionDetail.DrugOrderTransaction = drugOrderTransaction.Key;
                drugReturnActionDetail.Amount = drugOrderTransaction.Value;
                drugReturnActionDetail.SendAmount = drugOrderTransaction.Value;
                drugReturnActionDetail.DrugReturnAction = _DrugReturnAction;
            }
            #endregion DrugReturnActionNewForm_PreScript

        }
    }
}