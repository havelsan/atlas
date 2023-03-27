
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
    /// Filtre
    /// </summary>
    public partial class DrugOrderWLCriteriaForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            SelectButton.Click += new TTControlEventDelegate(SelectButton_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SelectButton.Click -= new TTControlEventDelegate(SelectButton_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void SelectButton_Click()
        {
#region DrugOrderWLCriteriaForm_SelectButton_Click
   this.ShowSearchForm();
#endregion DrugOrderWLCriteriaForm_SelectButton_Click
        }

        private void ttbutton1_Click()
        {
#region DrugOrderWLCriteriaForm_ttbutton1_Click
   this.PatientBox.Text = "";
            this.PatientBox.Tag = null;
#endregion DrugOrderWLCriteriaForm_ttbutton1_Click
        }

#region DrugOrderWLCriteriaForm_Methods
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            return DrugOrderDetail.DrugOrderDetailListNQL(context, dtStart, dtEnd, sExpression);
        }
        
        public override IList ExecuteReportNQL(DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            IList drugOrderDetailList = DrugOrderDetail.DrugOrderDetailListReportNQL(dtStart, dtEnd, sExpression);
            
            IList instanceList = new List<TTReportNqlObject>();
            foreach (TTReportNqlObject objEA in drugOrderDetailList)
            {
                if(objEA.TTObject is DrugOrderDetail)
                {
                    if (TTUser.CurrentUser.HasRight(objEA.TTObject.CurrentStateDef.FormDef, objEA.TTObject, this.OwnerDefinition.RightDefID.Value))
                        instanceList.Add(objEA);
                }
            }
            return instanceList;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            TextBox pBox = (TextBox)this.PatientBox;
            pBox.KeyUp += new KeyEventHandler(this.OnPatientBoxKeyUp);
            
            this.FillStateBox();
            this.OnLoadCriteria();
            this.StatusBox.SelectedIndex = 4 ;
        }
        
        private void OnPatientBoxKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13 && !string.IsNullOrEmpty(this.PatientBox.Text))
                this.SearchPatient(this.PatientBox.Text);
        }
        
        private void SearchPatient(string sText)
        {
            if(Common.IsNumeric(sText))
            {
                long pID = long.Parse(sText);
                BindingList<Patient> patients = Patient.GetPatientByPID(this.m_context, pID);
                if(patients.Count == 0)
                    this.ShowSearchForm();
                else
                {
                    this.PatientBox.Text = patients[0].ID.Value.ToString() + " " + patients[0].FullName;
                    this.PatientBox.Tag = patients[0];
                }
            }
            else
            {
                //name -surname search..not
                BindingList<Patient.GetPatientByInjection_Class> patients = this.GetReasultPatient();

                if(patients.Count == 0)
                    this.ShowSearchForm();
                else if(patients.Count == 1)
                {
                    long pID = long.Parse(patients[0].ID.Value.ToString());
                    Patient ptn = Patient.GetPatientByPID(this.m_context, pID)[0];
                    this.PatientBox.Text = ptn.ID.Value.ToString() + " " + ptn.FullName;
                    this.PatientBox.Tag = ptn;
                }
                else
                {
                    using(MultiSelectForm pForm = new MultiSelectForm())
                    {
                        foreach(Patient.GetPatientByInjection_Class pp in patients)
                        {
                            if(pp.ID != null)
                                pForm.AddMSItem(pp.ID.ToString() + " " + pp.Name + " " + pp.Surname, pp.ID.ToString(), pp);
                        }
                        
                        string sKey = pForm.GetMSItem(this,"Hasta Seçiniz");
                        if(!string.IsNullOrEmpty(sKey))
                        {
                            long pID = long.Parse(sKey);
                            Patient ptn = Patient.GetPatientByPID(this.m_context, pID)[0];
                            this.PatientBox.Text = ptn.ID.Value.ToString() + " " + ptn.FullName;
                            this.PatientBox.Tag = ptn;
                        }
                    }
                }
            }
        }
        
        private BindingList<Patient.GetPatientByInjection_Class> GetReasultPatient()
        {
            BindingList<Patient.GetPatientByInjection_Class> patients =new BindingList<Patient.GetPatientByInjection_Class>();
            string[] sSearchTexts = this.PatientBox.Text.Split(' ');
            string sSQL = "";
            
            foreach(string s in sSearchTexts)
            {
                sSQL = " WHERE NAME = '" + s.ToUpper(TTUtils.CultureService.Culture) + "'";
                patients = Patient.GetPatientByInjection(sSQL);
                
                if(patients.Count == 0)
                {
                    sSQL = " WHERE SURNAME = '" + s.ToUpper(TTUtils.CultureService.Culture) + "'";
                    patients = Patient.GetPatientByInjection(sSQL);
                }
                
                if(patients.Count > 0)
                    break;
            }
            
            return patients;
        }
        
        private void ShowSearchForm()
        {
            using(PatientSearchForm theForm = new PatientSearchForm())
            {
                Patient patient = (Patient)theForm.GetSelectedObject();
                if(patient != null)
                {
                    this.PatientBox.Text = patient.ID.Value.ToString() + " " + patient.FullName;
                    this.PatientBox.Tag = patient;
                }
            }
        }
        
        public override void OnSave()
        {
            try
            {
                //ID
                this.SaveCriteria("ID", "System.Int64", this.ActionID.Text);

                //STATE
                this.SaveCriteria("CURRENTSTATE","STATE",this.StatusBox.SelectedItem == null ? "" : this.StatusBox.SelectedItem.Value.ToString());
                
                //EPISODE.PATIENT
                Patient pPat = this.PatientBox.Tag as Patient;
                string sPID = "";
                if(pPat != null)
                    sPID = pPat.ObjectID.ToString();
                
                if(string.IsNullOrEmpty(this.PatientBox.Text))
                {
                    sPID = "";
                    this.PatientBox.Tag = null;
                }
                
                this.SaveCriteria("EPISODE.PATIENT","System.String", sPID);
            }
            catch(Exception ex)
            {
                InfoBox.Show(this, ex);
            }
        }
        
        public override void OnLoadCriteria()
        {
            base.OnLoadCriteria();
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
        
#endregion DrugOrderWLCriteriaForm_Methods
    }
}