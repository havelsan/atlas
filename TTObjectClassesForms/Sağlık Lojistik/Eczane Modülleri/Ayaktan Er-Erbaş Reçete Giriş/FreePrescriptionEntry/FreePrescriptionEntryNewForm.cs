
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
    /// Ayaktan Er/Erbaş Reçete Giriş 
    /// </summary>
    public partial class FreePrescriptionEntryNewForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            cmdFindPatient.Click += new TTControlEventDelegate(cmdFindPatient_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdFindPatient.Click -= new TTControlEventDelegate(cmdFindPatient_Click);
            base.UnBindControlEvents();
        }

        private void cmdFindPatient_Click()
        {
#region FreePrescriptionEntryNewForm_cmdFindPatient_Click
   using(PatientSearchForm theForm = new PatientSearchForm())
            {
                Patient patient = (Patient)theForm.GetSelectedObject();

                if(patient != null)
                {
                    _FreePrescriptionEntry.Patient = patient;
                    this.UniqueNo.Text = patient.UniqueRefNo.ToString();
                    this.PatientName.Text = patient.FullName;
                    this.UniqueNo.ReadOnly = true;
                    this.PatientName.ReadOnly = true;
                }
                else
                    InfoBox.Show("Hasta bilgilerine ulaşılamıyor.");
            }
#endregion FreePrescriptionEntryNewForm_cmdFindPatient_Click
        }

        protected override void PreScript()
        {
#region FreePrescriptionEntryNewForm_PreScript
    base.PreScript();
            
            if (this._FreePrescriptionEntry.CurrentStateDefID == FreePrescriptionEntry.States.New)
            {
                string filterExpression = string.Empty;
                filterExpression = "STOCKS.STORE = " + ConnectionManager.GuidToString(this._FreePrescriptionEntry.Store.ObjectID) + " AND STOCKS.INHELD > 0";
                ((ITTListBoxColumn)((ITTGridColumn)this.FreePrescriptionEntryDetails.Columns["MaterialFreePrescriptionEntryDet"])).ListFilterExpression = filterExpression;
            }
#endregion FreePrescriptionEntryNewForm_PreScript

            }
                }
}