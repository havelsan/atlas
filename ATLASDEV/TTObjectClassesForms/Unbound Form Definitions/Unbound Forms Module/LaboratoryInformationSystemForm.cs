
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
    /// Laboratuvar İşlemleri
    /// </summary>
    public partial class LaboratoryInformationSystemForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            tlbLaboratory.ItemClicked += new TTToolStripItemClicked(tlbLaboratory_ItemClicked);
            lvwPatient.SelectedIndexChanged += new TTControlEventDelegate(lvwPatient_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            tlbLaboratory.ItemClicked -= new TTToolStripItemClicked(tlbLaboratory_ItemClicked);
            lvwPatient.SelectedIndexChanged -= new TTControlEventDelegate(lvwPatient_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void tlbLaboratory_ItemClicked(ITTToolStripItem item)
        {
#region LaboratoryInformationSystemForm_tlbLaboratory_ItemClicked
   switch(item.Name)
            {
                case "tlbOpen":
                    firstLab(item);
                    break;
                case "tlbOpenPatient":
                    firstLab(item);
                    break;
                case "tlbSearchPatient":
                    SearchPatient();
                    break;
                case "tlbExit":
                    break;
                default:
                    break;                    
            }
#endregion LaboratoryInformationSystemForm_tlbLaboratory_ItemClicked
        }

        private void lvwPatient_SelectedIndexChanged()
        {
#region LaboratoryInformationSystemForm_lvwPatient_SelectedIndexChanged
   if (lvwPatient.SelectedItems.Count > 0)
            ShowLaboratoryByPatient(lvwPatient.SelectedItems[0].Tag.ToString());
#endregion LaboratoryInformationSystemForm_lvwPatient_SelectedIndexChanged
        }

#region LaboratoryInformationSystemForm_Methods
        private Patient _patient;

        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (_patient == null)
            {
                PatientSearchForm patientSearchForm = new PatientSearchForm();
                Patient p = (Patient) patientSearchForm.GetSelectedObject();
                if (p != null)
                    ShowLaboratory(p,true);
            }
        }
        
        protected override void OnInitializeControls()
        {
            base.OnInitializeControls();
            
            lvwLaboratory.Columns.Clear();
            lvwLaboratory.Columns.Add("Episode No", 100);
            lvwLaboratory.Columns.Add("İşlem No", 100);
            lvwLaboratory.Columns.Add("İşlem Durumu", 100);
            lvwPatient.Columns.Add("Hasta Adı", 100);
        }
        
        private void SearchPatient()
        {
            PatientSearchForm patientSearchForm = new PatientSearchForm();
            Patient p = (Patient) patientSearchForm.GetSelectedObject();
            if (p != null)
                ShowLaboratory(p,true);
        }

        public void ShowLaboratoryByPatient(String PatientObjectId)
        {
            TTObjectContext context = new TTObjectContext(true);
            IList RadTestDef = context.QueryObjects("PATIENT", "OBJECTID = '" + PatientObjectId.ToString() + "'");
            Patient p = (Patient) RadTestDef[0];
            if (p != null)
                ShowLaboratory(p,false);
        }

        private void ShowLaboratory(Patient patient, Boolean AddtoPatientList)
        {
            _patient = patient;
            FillLaboratories(AddtoPatientList);
            this.Show();
        }

        private void FillLaboratories(Boolean AddPatient)
        {
            lvwLaboratory.Items.Clear();
            TTObjectContext context = new TTObjectContext(true);
            Patient p = (Patient)context.GetObject(_patient.ObjectID, _patient.ObjectDef);

            if (AddPatient)
            {
                ITTListViewItem listpItem = new TTListViewItem();
                listpItem.Text = p.Name.ToString();
                listpItem.Tag = p.ObjectID;
                if (!(lvwPatient.Items.Contains(listpItem)))
                {   
                    lvwPatient.Items.Add(listpItem);
                }        
                else
                    MessageBox.Show("Hasta Eklenmiş");
            }
            
            foreach (Episode episode in p.Episodes)
            {
                foreach (EpisodeAction action in episode.EpisodeActions)
                {
                    ITTListViewItem listItem = new TTListViewItem();
                    if (action.ID != null)
                    {
                        if (action.ObjectDef.Name.ToString() == "RADIOLOGYTEST")
                        {
                            listItem.Text = episode.ID.ToString();
                            listItem.SubItems.Add(action.ID.ToString());
                            if (action.CurrentStateDefID != null)
                                listItem.SubItems.Add(action.CurrentStateDefID.ToString());
                            listItem.Tag = action.ObjectID;
                            lvwLaboratory.Items.Add(listItem);
                        }
                    }
                }
                if (lvwLaboratory.Items.Count>0 && lvwLaboratory.SelectedItems.Count==0)
                    lvwLaboratory.Items[0].Selected = true;
            }
            context.Dispose();
        }
        
        void firstLab(ITTToolStripItem item)
        {
            MessageBox.Show("a");
        }
        
#endregion LaboratoryInformationSystemForm_Methods
    }
}