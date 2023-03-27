
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
    /// RuleTestForm
    /// </summary>
    public partial class RuleTestForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            EpisodeComboBox.SelectedIndexChanged += new TTControlEventDelegate(EpisodeComboBox_SelectedIndexChanged);
            CheckRule.Click += new TTControlEventDelegate(CheckRule_Click);
            PatientListBox.SelectedObjectChanged += new TTControlEventDelegate(PatientListBox_SelectedObjectChanged);
            MaterialListBox.SelectedObjectChanged += new TTControlEventDelegate(MaterialListBox_SelectedObjectChanged);
            ProcedureListBox.SelectedObjectChanged += new TTControlEventDelegate(ProcedureListBox_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            EpisodeComboBox.SelectedIndexChanged -= new TTControlEventDelegate(EpisodeComboBox_SelectedIndexChanged);
            CheckRule.Click -= new TTControlEventDelegate(CheckRule_Click);
            PatientListBox.SelectedObjectChanged -= new TTControlEventDelegate(PatientListBox_SelectedObjectChanged);
            MaterialListBox.SelectedObjectChanged -= new TTControlEventDelegate(MaterialListBox_SelectedObjectChanged);
            ProcedureListBox.SelectedObjectChanged -= new TTControlEventDelegate(ProcedureListBox_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void EpisodeComboBox_SelectedIndexChanged()
        {
#region RuleTestForm_EpisodeComboBox_SelectedIndexChanged
   if (EpisodeComboBox.SelectedItem != null)
            {
                Episode episode = (Episode)EpisodeComboBox.SelectedItem.Value;
                EpisodeActionComboBox.Items.Clear();
                foreach (EpisodeAction episodeAction in episode.EpisodeActions)
                {
                    if (episodeAction.ActionDate.HasValue)
                    {
                        TTComboBoxItem item = new TTComboBoxItem(episodeAction.ActionDate.Value.ToShortDateString() + " " + episodeAction.ActionDate.Value.ToShortTimeString() + " " + episodeAction.ObjectDef.ApplicationName, episodeAction);
                        EpisodeActionComboBox.Items.Add(item);
                    }
                }
                FillMaterialListView();
                FillProcedureListView();
            }
            else
            {
                ClearForm();
            }
#endregion RuleTestForm_EpisodeComboBox_SelectedIndexChanged
        }

        private void CheckRule_Click()
        {
#region RuleTestForm_CheckRule_Click
   //   tttextbox1.Text = string.Empty;
//
//            Patient patient = PatientListBox.SelectedObject as Patient;
//            if (patient != null)
//            {
//                ISUTPatient sutPatient = (ISUTPatient)patient;
//                if (EpisodeComboBox.SelectedItem != null)
//                {
//                    ISUTEpisode sutEpisode = (ISUTEpisode)EpisodeComboBox.SelectedItem.Value;
//                    if (EpisodeActionComboBox.SelectedItem != null)
//                    {
//                        ISUTEpisodeAction episodeAction = (ISUTEpisodeAction)EpisodeActionComboBox.SelectedItem.Value;
//
//                        Material material = MaterialListBox.SelectedObject as Material;
//                        if (material != null)
//                        {
//                            List<RuleBase.RuleResult> ruleResults = material.RunRules(TTObjectDefManager.ServerTime, episodeAction);
//                            foreach (RuleBase.RuleResult result in ruleResults)
//                            {
//                                tttextbox1.Text += result.RuleDescription + "\r\n";
//                            }
//                        }
//
//                        ProcedureDefinition procedure = ProcedureListBox.SelectedObject as ProcedureDefinition;
//                        if (procedure != null)
//                        {
//                            List<RuleBase.RuleResult> ruleResults = procedure.RunRules(TTObjectDefManager.ServerTime, episodeAction);
//                            foreach (RuleBase.RuleResult result in ruleResults)
//                            {
//                                tttextbox1.Text += result.RuleDescription + "\r\n";
//                            }
//                        }
//                    }
//                }
//            }
#endregion RuleTestForm_CheckRule_Click
        }

        private void PatientListBox_SelectedObjectChanged()
        {
#region RuleTestForm_PatientListBox_SelectedObjectChanged
   if (PatientListBox.SelectedObject != null)
            {
                Patient patient = (Patient)PatientListBox.SelectedObject;
                EpisodeComboBox.Items.Clear();
                foreach (Episode episode in patient.Episodes)
                {
                    if (episode.OpeningDate.HasValue)
                    {
                        TTComboBoxItem item = new TTComboBoxItem(episode.OpeningDate.Value.ToShortDateString() + " " + episode.OpeningDate.Value.ToShortTimeString() , episode);
                        EpisodeComboBox.Items.Add(item);
                    }
                }
                FillMaterialListView();
                FillProcedureListView();
            }
            else
            {
                ClearForm();
            }
#endregion RuleTestForm_PatientListBox_SelectedObjectChanged
        }

        private void MaterialListBox_SelectedObjectChanged()
        {
#region RuleTestForm_MaterialListBox_SelectedObjectChanged
   if (MaterialListBox.SelectedObject != null)
            {
                FillMaterialListView();
            }
            else
            {
                SUTMaterialDetailsListView.Items.Clear();
            }
#endregion RuleTestForm_MaterialListBox_SelectedObjectChanged
        }

        private void ProcedureListBox_SelectedObjectChanged()
        {
#region RuleTestForm_ProcedureListBox_SelectedObjectChanged
   if (ProcedureListBox.SelectedObject != null)
            {
                FillProcedureListView();
            }
            else
            {
                SUTProcedureDetailsListView.Items.Clear();
            }
#endregion RuleTestForm_ProcedureListBox_SelectedObjectChanged
        }

#region RuleTestForm_Methods
        private void ClearForm()
        {

            SUTMaterialDetailsListView.Items.Clear();
            SUTProcedureDetailsListView.Items.Clear();

            EpisodeComboBox.Items.Clear();
            EpisodeComboBox.SelectedItem = null;
            EpisodeActionComboBox.Items.Clear();
            EpisodeActionComboBox.SelectedItem = null;

            MaterialListBox.SelectedObject = null;
            ProcedureListBox.SelectedObject = null;

        }

        private void FillMaterialListView()
        {
//            if (MaterialListBox.SelectedObject != null)
//            {
//                DateTime d = TTObjectDefManager.ServerTime;
//                DateTime startDate = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
//                DateTime endDate = new DateTime(d.Year, d.Month, d.Day, 23, 59, 59);
//
//                SUTMaterialDetailsListView.Items.Clear();
//                Material material = (Material)MaterialListBox.SelectedObject;
//                if (PatientListBox.SelectedObject != null)
//                {
//                    ISUTPatient patient = (ISUTPatient)PatientListBox.SelectedObject;
//                    ISUTMaterialTotalAmount materialDetail = patient.SUTMaterialTotalAmount(material.ObjectID, startDate, endDate);
//                    ITTListViewItem listViewItem = SUTMaterialDetailsListView.Items.Add(materialDetail.TotalAmount.ToString());
//                    listViewItem.SubItems.Add(typeof(Patient).Name);
//                }
//
//                if (EpisodeComboBox.SelectedItem != null)
//                {
//                    ISUTEpisode episode = (ISUTEpisode)EpisodeComboBox.SelectedItem.Value;
//                    ISUTMaterialTotalAmount materialDetail = episode.SUTMaterialTotalAmount(material.ObjectID, startDate, endDate);
//                    ITTListViewItem listViewItem = SUTMaterialDetailsListView.Items.Add(materialDetail.TotalAmount.ToString());
//                    listViewItem.SubItems.Add(typeof(Episode).Name);
//                }
//
//                if (EpisodeActionComboBox.SelectedItem != null)
//                {
//                    ISUTEpisodeAction episodeAction = (ISUTEpisodeAction)EpisodeActionComboBox.SelectedItem.Value;
//                    ISUTMaterialTotalAmount materialDetail = episodeAction.SUTMaterialTotalAmount(material.ObjectID, startDate, endDate);
//                    ITTListViewItem listViewItem = SUTMaterialDetailsListView.Items.Add(materialDetail.TotalAmount.ToString());
//                    listViewItem.SubItems.Add(typeof(EpisodeAction).Name);
//                }
//            }

        }

        private void FillProcedureListView()
        {
//            if (ProcedureListBox.SelectedObject != null)
//            {
//                DateTime d = TTObjectDefManager.ServerTime;
//                DateTime startDate = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
//                DateTime endDate = new DateTime(d.Year, d.Month, d.Day, 23, 59, 59);
//
//                SUTProcedureDetailsListView.Items.Clear();
//                ProcedureDefinition procedure = (ProcedureDefinition)ProcedureListBox.SelectedObject;
//                if (PatientListBox.SelectedObject != null)
//                {
//                    ISUTPatient patient = (ISUTPatient)PatientListBox.SelectedObject;
//                    ISUTProcedureTotalAmount procedureDetail = patient.SUTProcedureTotalAmount(procedure.ObjectID, startDate, endDate);
//                    ITTListViewItem listViewItem = SUTProcedureDetailsListView.Items.Add(procedureDetail.TotalAmount.ToString());
//                    listViewItem.SubItems.Add(typeof(Patient).Name);
//                }
//
//                if (EpisodeComboBox.SelectedItem != null)
//                {
//                    ISUTEpisode episode = (ISUTEpisode)EpisodeComboBox.SelectedItem.Value;
//                    ISUTProcedureTotalAmount procedureDetail = episode.SUTProcedureTotalAmount(procedure.ObjectID, startDate, endDate);
//                    ITTListViewItem listViewItem = SUTProcedureDetailsListView.Items.Add(procedureDetail.TotalAmount.ToString());
//                    listViewItem.SubItems.Add(typeof(Episode).Name);
//                }
//
//                if (EpisodeActionComboBox.SelectedItem != null)
//                {
//                    ISUTEpisodeAction episodeAction = (ISUTEpisodeAction)EpisodeActionComboBox.SelectedItem.Value;
//                    ISUTProcedureTotalAmount procedureDetail = episodeAction.SUTProcedureTotalAmount(procedure.ObjectID, startDate, endDate);
//                    ITTListViewItem listViewItem = SUTProcedureDetailsListView.Items.Add(procedureDetail.TotalAmount.ToString());
//                    listViewItem.SubItems.Add(typeof(EpisodeAction).Name);
//                }
//            }
        }
        
#endregion RuleTestForm_Methods
    }
}