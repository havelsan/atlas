
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
    /// Sağlık Kurulu İş Listesi
    /// </summary>
    public partial class HealthCommitteeWLForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            SelectButton.Click += new TTControlEventDelegate(SelectButton_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            SelectAllButton.Click += new TTControlEventDelegate(SelectAllButton_Click);
            ClearButton.Click += new TTControlEventDelegate(ClearButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SelectButton.Click -= new TTControlEventDelegate(SelectButton_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            SelectAllButton.Click -= new TTControlEventDelegate(SelectAllButton_Click);
            ClearButton.Click -= new TTControlEventDelegate(ClearButton_Click);
            base.UnBindControlEvents();
        }

        private void SelectButton_Click()
        {
#region HealthCommitteeWLForm_SelectButton_Click
   if(!string.IsNullOrEmpty(this.PatientBox.Text))
                 SearchPatient(this.PatientBox.Text);
#endregion HealthCommitteeWLForm_SelectButton_Click
        }

        private void ttbutton1_Click()
        {
#region HealthCommitteeWLForm_ttbutton1_Click
   this.PatientBox.Text = "";
            this.PatientBox.Tag = null;
#endregion HealthCommitteeWLForm_ttbutton1_Click
        }

        private void SelectAllButton_Click()
        {
#region HealthCommitteeWLForm_SelectAllButton_Click
   this.CheckUnCheckAll(true);
#endregion HealthCommitteeWLForm_SelectAllButton_Click
        }

        private void ClearButton_Click()
        {
#region HealthCommitteeWLForm_ClearButton_Click
   this.CheckUnCheckAll(false);
#endregion HealthCommitteeWLForm_ClearButton_Click
        }

#region HealthCommitteeWLForm_Methods
        ListView m_listResource = null;
        CheckedComboBox m_chCombo = new CheckedComboBox();
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            TextBox pBox = (TextBox)this.PatientBox;
            pBox.KeyUp += new KeyEventHandler(this.OnPatientBoxKeyUp);
            
            m_listResource = (ListView)this.MResources;
            m_listResource.CheckBoxes = true;
            
            this.FillResources();
            this.LoadCriteria();
            this.FillStateBox();
            this.FillPatientStatusBox();
            this.InitCheckedCombo();
            this.FillHospitalNameBox();
        }
        
        private void InitCheckedCombo()
        {
            this.m_chCombo.CheckOnClick = true;
            this.m_chCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.m_chCombo.DropDownHeight = 1;
            this.m_chCombo.FormattingEnabled = true;
            this.m_chCombo.IntegralHeight = false;
            //this.m_chCombo.Location = TestCombo.Location;
            this.m_chCombo.Name = "checkedComboBox1";
            //this.m_chCombo.Size = TestCombo.Size;
            this.m_chCombo.TabIndex = 10;
            this.m_chCombo.ValueSeparator = ", ";
            
            this.Controls.Add(this.m_chCombo);
        }
        
        private void OnPatientBoxKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13 && !string.IsNullOrEmpty(this.PatientBox.Text))
                SearchPatient(this.PatientBox.Text);
        }
        
        private void SearchPatient(string sText)
        {
            Patient patient= PatientAdmission.GetPatientBySearch(sText);
            if(patient!=null)
            {
                this.PatientBox.Text = patient.ID.Value.ToString() + " " + patient.FullName;
                this.PatientBox.Tag = patient;
            }
        }
        
        //       private void SearchPatient(string sText)
        // {
        //            if(sText!="")
        //            {
        //                TTList patientList= Patient.Search(sText);
        //                if(patientList!=null && patientList.FoundList!=null && patientList.FoundList.Count==0){// yanlızca yeni hastalar için Ara butonu çıktığından 0 yoksa aşağıdaki gibi 1 de olabilir
        //                    InfoBox.Show("Hasta bulanamadı");
        //                }
        //                else if(patientList.FoundList.Count==1){
        //                    patient== (Patient)patientList.FoundList[0];
        //                }
        //                else{
        //                    PatientSearchForm patientSearchForm = new PatientSearchForm(patientList);
        //                    patient = (Patient)patientSearchForm.GetSelectedObject();
        //                }
        //            }
        //            if(patient!=null)
        //            {
        //                this.PatientBox.Text = patient.ID.Value.ToString() + " " + patient.FullName;
        //                this.PatientBox.Tag = patient;
        //            }
        
        
        //            if(Common.IsNumeric(sText))
        //            {
        //                long pID = long.Parse(sText);
        //                BindingList<Patient> patients = Patient.GetPatientByPID(this.m_context, pID);
        //                if(patients.Count == 0)
        //                    this.ShowSearchForm();
        //                else
        //                {
        //                    this.PatientBox.Text = patients[0].ID.Value.ToString() + " " + patients[0].FullName;
        //                    this.PatientBox.Tag = patients[0];
        //                }
        //            }
        //            else
        //            {
        //                //name -surname search..not
        //                BindingList<Patient.GetPatientByInjection_Class> patients = this.GetReasultPatient();
//
        //                if(patients.Count == 0)
        //                    this.ShowSearchForm();
        //                else if(patients.Count == 1)
        //                {
        //                    long pID = long.Parse(patients[0].ID.Value.ToString());
        //                    Patient ptn = Patient.GetPatientByPID(this.m_context, pID)[0];
        //                    this.PatientBox.Text = ptn.ID.Value.ToString() + " " + ptn.FullName;
        //                    this.PatientBox.Tag = ptn;
        //                }
        //                else
        //                {
        //                    using(MultiSelectForm pForm = new MultiSelectForm())
        //                    {
        //                        foreach(Patient.GetPatientByInjection_Class pp in patients)
        //                        {
        //                            if(pp.ID != null)
        //                                pForm.AddMSItem(pp.ID.ToString() + " " + pp.Name + " " + pp.Surname, pp.ID.ToString(), pp);
        //                        }
//
        //                        string sKey = pForm.GetMSItem(this,"Hasta Seçiniz");
        //                        if(!string.IsNullOrEmpty(sKey))
        //                        {
        //                            long pID = long.Parse(sKey);
        //                            Patient ptn = Patient.GetPatientByPID(this.m_context, pID)[0];
        //                            this.PatientBox.Text = ptn.ID.Value.ToString() + " " + ptn.FullName;
        //                            this.PatientBox.Tag = ptn;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        
        //        private BindingList<Patient.GetPatientByInjection_Class> GetReasultPatient()
        //        {
        //            BindingList<Patient.GetPatientByInjection_Class> patients =new BindingList<Patient.GetPatientByInjection_Class>();
        //            string[] sSearchTexts = this.PatientBox.Text.Split(' ');
        //            string sSQL = "";
//
        //            foreach(string s in sSearchTexts)
        //            {
        //                sSQL = " WHERE NAME = '" + s.ToUpper(TTUtils.CultureService.Culture) + "'";
        //                patients = Patient.GetPatientByInjection(sSQL);
//
        //                if(patients.Count == 0)
        //                {
        //                    sSQL = " WHERE SURNAME = '" + s.ToUpper(TTUtils.CultureService.Culture) + "'";
        //                    patients = Patient.GetPatientByInjection(sSQL);
        //                }
//
        //                if(patients.Count > 0)
        //                    break;
        //            }
//
        //            return patients;
        //        }
        
        //        private void ShowSearchForm()
        //        {
        //            using(PatientSearchForm theForm = new PatientSearchForm())
        //            {
        //                Patient patient = (Patient)theForm.GetSelectedObject();
        //                if(patient != null)
        //                {
        //                    this.PatientBox.Text = patient.ID.Value.ToString() + " " + patient.FullName;
        //                    this.PatientBox.Tag = patient;
        //                }
        //            }
        //        }
        
        private void FillResources()
        {
            //fill resources here
            this.m_listResource.Items.Clear();
            SortedList<string,UserResource> sList = new SortedList<string,UserResource>();
            foreach (UserResource userResource in TTObjectClasses.Common.CurrentResource.UserResources)
            {
                if(sList.ContainsKey(userResource.Resource.Name + userResource.Resource.ObjectID.ToString()) == false)
                    sList.Add(userResource.Resource.Name + userResource.Resource.ObjectID.ToString(),userResource);
            }
            
            foreach(KeyValuePair<string,UserResource> kvp in sList)
            {
                UserResource uRes =(UserResource)kvp.Value;
                ListViewItem item = new ListViewItem(uRes.Resource.Name);
                item.Tag = uRes;
                item.Checked = false;
                
                this.m_listResource.Items.Add(item);
            }
        }
        
        private void FillLoadResourceCombo()
        {
            //fill resources here
            this.m_chCombo.Items.Clear();
            SortedList<string,UserResource> sList = new SortedList<string,UserResource>();
            foreach (UserResource userResource in TTObjectClasses.Common.CurrentResource.UserResources)
            {
                if(sList.ContainsKey(userResource.Resource.Name + userResource.Resource.ObjectID.ToString()) == false)
                    sList.Add(userResource.Resource.Name + userResource.Resource.ObjectID.ToString(),userResource);
            }

            string[] values = null;
            CriteriaValue crValM1 = this.GetCriteriaValue("MASTERRESOURCE");
            if(crValM1 != null && !string.IsNullOrEmpty(crValM1.Value))
            {
                values = crValM1.Value.Split(',');
            }
            
            foreach(KeyValuePair<string,UserResource> kvp in sList)
            {
                TTComboBoxItem item = new TTComboBoxItem(kvp.Value.Resource.Name, kvp.Value);
                bool bChecked = false;
                
                if(values != null)
                {
                    foreach(string ID in values)
                    {
                        if(kvp.Value.Resource.ObjectID.Equals(ID))
                        {
                            bChecked = true;
                            break;
                        }
                    }
                }
                this.m_chCombo.Items.Add(item, bChecked);
            }
        }
        
        private void FillStateBox()
        {
            var pBox = this.StatusBox;
            
            TTComboBoxItem it0 = new TTComboBoxItem("", "");
            pBox.Items.Add(it0);
            
            TTComboBoxItem it1 = new TTComboBoxItem("İptaller", "CANCELLED");
            pBox.Items.Add(it1);

            TTComboBoxItem it2 = new TTComboBoxItem("Başarılı Tamamlanmış", "SUCCESSFUL");
            pBox.Items.Add(it2);
            
            TTComboBoxItem it3 = new TTComboBoxItem("Başarısız Tamamlanmış", "UNSUCCESSFUL");
            pBox.Items.Add(it3);
            
            TTComboBoxItem it4 = new TTComboBoxItem("Tamamlanmamış", "UNCOMPLETED");
            pBox.Items.Add(it4);
        }
        
        private void FillPatientStatusBox()
        {
            ComboBox pBox = (ComboBox)this.PatientStatus;
            
            TTComboBoxItem it0 = new TTComboBoxItem("", "");
            pBox.Items.Add(it0);
            
            TTComboBoxItem it1 = new TTComboBoxItem("Ayaktan", "0");
            pBox.Items.Add(it1);

            TTComboBoxItem it2 = new TTComboBoxItem("Yatan", "1");
            pBox.Items.Add(it2);
            
            TTComboBoxItem it3 = new TTComboBoxItem("Taburcu", "2");
            pBox.Items.Add(it3);
            
        }
        
        private void FillHospitalNameBox()
        {
            ComboBox pBox = (ComboBox)this.HospitalName;
            
            TTComboBoxItem item0 = new TTComboBoxItem("", "");
            pBox.Items.Add(item0);
            
            IList hospitalList = ResHospital.GetResHospitals(this.ObjectContext);
            foreach (ResHospital hospital in hospitalList)
            {
                TTComboBoxItem item1 = new TTComboBoxItem(hospital.Name.ToString(), hospital.ObjectID.ToString());
                pBox.Items.Add(item1);
            }
        }
        
        private void LoadCriteria()
        {
            this.DeSelectAllResources();
            CriteriaValue crValM = this.GetCriteriaValue("MASTERRESOURCE");
            if(crValM != null && !string.IsNullOrEmpty(crValM.Value))
            {
                string[] values = crValM.Value.Split(',');
                foreach(string ID in values)
                {
                    this.SelectResource(ID);
                }
            }

            
            this.FillLoadResourceCombo();
            
            this.chkPlan.Value = false;
            CriteriaValue crValPlan = this.GetCriteriaValue("ORDEROBJECT");
            if(crValPlan != null)
            {
                if(crValPlan.Value == "IS NULL")
                    this.chkPlan.Value = false;
                else
                    this.chkPlan.Value = true;
            }
            else
                this.chkPlan.Value = false;
            
            this.StatusBox.SelectedItem = null;
            CriteriaValue crValS = this.GetCriteriaValue("CURRENTSTATE");
            if(crValS != null && !string.IsNullOrEmpty(crValS.Value))
            {
                TTComboBoxItem pItem = null;
                foreach(TTComboBoxItem item in this.StatusBox.Items)
                {
                    if (item.Value.ToString() == crValS.Value.ToString())
                        pItem = item;
                }

                this.StatusBox.SelectedItem = pItem;
            }
            
            this.chkEmergency.Value = false;
            CriteriaValue crValEmergency = this.GetCriteriaValue("EMERGENCY");
            if(crValEmergency != null)
            {
                if(crValEmergency.Value == "True")
                    this.chkEmergency.Value = true;
                else
                    this.chkEmergency.Value = false;
            }
            else
                this.chkEmergency.Value = false;
            
            this.PatientStatus.SelectedItem = null;
            CriteriaValue crValPatientStatus = this.GetCriteriaValue("EPISODE.PATIENTSTATUS");
            if(crValPatientStatus != null && !string.IsNullOrEmpty(crValPatientStatus.Value))
            {
                TTComboBoxItem pItem = null;
                foreach(TTComboBoxItem item in this.PatientStatus.Items)
                {
                    if (item.Value.ToString() == crValPatientStatus.Value.ToString())
                        pItem = item;
                }

                this.PatientStatus.SelectedItem = pItem;
            }
            
            this.HospitalName.SelectedItem = null;
            CriteriaValue crValH = this.GetCriteriaValue("HOSPITAL");
            if(crValH != null && !string.IsNullOrEmpty(crValH.Value))
            {
                TTComboBoxItem hItem = null;
                foreach(TTComboBoxItem item in this.HospitalName.Items)
                {
                    if (item.Value.ToString() == crValH.Value.ToString())
                        hItem = item;
                }

                this.HospitalName.SelectedItem = hItem;
            }
            
            if (this.GetCriteriaValue("REPORTNO") != null)
                this.ReportNo.Text = this.GetCriteriaValue("REPORTNO").Value;
            
            if (this.GetCriteriaValue("ID") != null)
                this.ActionID.Text = this.GetCriteriaValue("ID").Value;
            
            //load edilmesine gerk olmadığından kaldırıldı...YY
            //            CriteriaValue crValP = this.GetCriteriaValue("EPISODE.PATIENT");
            //            if(crValP != null && !string.IsNullOrEmpty(crValP.Value))
            //            {
            //                try
            //                {
            //                    BindingList<Patient> plist = Patient.GetPatientByID(this.m_context, crValP.Value);
            //                    this.PatientBox.Text = plist[0].ID.Value.ToString() + " " + plist[0].FullName;
            //                    this.PatientBox.Tag = plist[0];
            //                }
            //                catch(Exception ex)
            //                {
            //                    InfoBox.Show(ex);
            //                }
            //            }
//
        }
        
        private void DeSelectAllResources()
        {
            foreach (ListViewItem item in this.m_listResource.Items)
            {
                item.Checked = false;
            }
        }
        
        private void SelectResource(string ID)
        {
            foreach (ListViewItem item in this.m_listResource.Items)
            {
                UserResource userResource = (UserResource)item.Tag;
                if(ID == userResource.Resource.ObjectID.ToString())
                {
                    item.Checked = true;
                    break;
                }
            }
        }
        
        
        private void CheckUnCheckAll(bool bCheck)
        {
            for (int i = 0; i < this.m_chCombo.Items.Count; i++)
            {
                this.m_chCombo.SetItemChecked(i, bCheck);
            }
        }
        
        public override void OnSave()
        {
            try
            {
                base.OnSave();
                //REPORTNO
                this.SaveCriteria("REPORTNO","System.Int64", this.ReportNo.Text);
                //HOSPITAL
                this.SaveCriteria("HOSPITAL","System.String",this.HospitalName.SelectedItem == null ? "" : this.HospitalName.SelectedItem.Value.ToString());
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
        }
        
        public override void OnLoadCriteria()
        {
            this.LoadCriteria();
        }
        
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            if(String.IsNullOrEmpty(this.ActionID.Text) == true && String.IsNullOrEmpty(this.ReportNo.Text) == true)
                return HealthCommittee.GetHealthCommitteeWL(context, dtStart, dtEnd, sExpression);
            else
                return HealthCommittee.GetByFilterExpression(context,sExpression);
        }
        
#endregion HealthCommitteeWLForm_Methods
    }
}