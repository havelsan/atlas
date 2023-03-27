
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
    /// Randevu Listesi
    /// </summary>
    public partial class AppointmentWLCriteriaForm : BaseCriteriaForm
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
#region AppointmentWLCriteriaForm_SelectButton_Click
   if(!string.IsNullOrEmpty(this.PatientBox.Text))
                SearchPatient(this.PatientBox.Text);
#endregion AppointmentWLCriteriaForm_SelectButton_Click
        }

        private void ttbutton1_Click()
        {
#region AppointmentWLCriteriaForm_ttbutton1_Click
   this.PatientBox.Text = "";
            this.PatientBox.Tag = null;
#endregion AppointmentWLCriteriaForm_ttbutton1_Click
        }

#region AppointmentWLCriteriaForm_Methods
        ListView m_listResource = null;
        
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
        
        
        
        private void FillResources()
        {
            //fill resources here
            this.m_listResource.Items.Clear();
            foreach (UserResource userResource in TTObjectClasses.Common.CurrentResource.UserResources)
            {
                ListViewItem item = new ListViewItem(userResource.Resource.Name);
                item.Tag = userResource;
                item.Checked = false;
                
                this.m_listResource.Items.Add(item);
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
        
        private void LoadCriteria()
        {
            CriteriaValue crValM = this.GetCriteriaValue("MASTERRESOURCE");
            if(crValM != null && !string.IsNullOrEmpty(crValM.Value))
            {
                string[] values = crValM.Value.Split(',');
                foreach(string ID in values)
                {
                    this.SelectResource(ID);
                }
            }
            
            //            CriteriaValue crValP = this.GetCriteriaValue("SELECTEDPATIENT");
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
            //            CriteriaValue crValS = this.GetCriteriaValue("STATE_STATUS");
            //            if(crValS != null && !string.IsNullOrEmpty(crValS.Value))
            //            {
            //                TTComboBoxItem pItem = null;
            //                foreach(TTComboBoxItem item in this.StatusBox.Items)
            //                {
            //                    if(item.Value == crValS.Value)
            //                        pItem = item;
            //                }
//
            //                this.StatusBox.SelectedItem = pItem;
            //            }
        }
        
        private void SelectResource(string ID)
        {
            foreach (ListViewItem item in this.m_listResource.Items)
            {
                UserResource userResource = (UserResource)item.Tag;
                if(ID == userResource.ObjectID.ToString())
                {
                    item.Checked = true;
                    break;
                }
            }
        }
        
        public static ArrayList Tokenize(string s, bool wildCard)
        {
            string ts;
            string tmpToken = "";
            char subChar;
            const string alphaChar = "ABCÇDEFGĞHIİJKLMNOÖPQRSŞTUÜWXVYZabcçdefgğhıijklmnoöpqrsştuüwxvyz.";
            ArrayList Tokens = new ArrayList();
            if (!String.IsNullOrEmpty(s))
            {
                ts = Globals.CUCase(s, true, false);
                for (int i = 0; i <= ts.Length - 1; i++)
                {
                    subChar = ts.Substring(i, 1).ToCharArray(0, 1)[0];
                    if (Globals.LatinAlphabetUsed && alphaChar.IndexOf(subChar) != -1)
                        tmpToken += subChar.ToString();
                    else if (!Globals.LatinAlphabetUsed && subChar != ' ')
                        tmpToken += subChar.ToString();
                    else if (wildCard && subChar == '%')
                        tmpToken += subChar.ToString();
                    else
                    {
                        if (tmpToken.Length > 0)
                            Tokens.Add(tmpToken);
                        tmpToken = "";
                    }
                }
                if (tmpToken.Length > 0)
                    Tokens.Add(tmpToken);
            }
            return Tokens;
        }
        
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            if(String.IsNullOrEmpty(this.ActionID.Text) == true)
                return AdmissionAppointment.GetByWorklistDate(context, dtStart, dtEnd, sExpression);
            else
                return AdmissionAppointment.GetByFilterExpression(context,sExpression);
            
        }
        
        public override void OnSave()
        {
            try
            {
                //MASTERRESOURCE
                string sResources = "";
                //SELECTEDPATIENT
                string sPID = "";
                //PATIENTNAME
                string patientName = "";
                //PATIENTSURNAME
                string patientSurname = "";
                //ID
                string sActionID = "";
                //APPDEF
                string appDef = "";
                //STATE
                string sState = "";
                
                if(String.IsNullOrEmpty(this.ActionID.Text) == false)
                {
                    sActionID = this.ActionID.Text;
                }
                else
                {
                    //MASTERRESOURCE
                    int nCounter = 0;
                    foreach(ListViewItem item in this.m_listResource.CheckedItems)
                    {
                        UserResource res = (UserResource)item.Tag;
                        sResources += res.Resource.ObjectID.ToString();
                        if((nCounter + 1) < this.m_listResource.CheckedItems.Count)
                            sResources += ",";
                        nCounter++;
                    }
                    
                    //SELECTEDPATIENT
                    Patient pPat = this.PatientBox.Tag as Patient;
                    if(pPat != null)
                        sPID = pPat.ObjectID.ToString();
                    
                    //PATIENTNAME SURNAME
                    if(pPat == null && String.IsNullOrEmpty(this.PatientBox.Text) == false)
                    {
                        ArrayList nameTokens = Tokenize(this.PatientBox.Text, false);
                        if (nameTokens.Count > 1)
                        {
                            for (int i = 0; i < nameTokens.Count - 1; i++)
                            {
                                if (i == 0)
                                    patientName = nameTokens[i].ToString();
                                else
                                    patientName = patientName + " " + nameTokens[i].ToString();
                            }
                            patientSurname = nameTokens[nameTokens.Count - 1].ToString();
                        }
                    }

                    
                    //ID
                    sActionID = this.ActionID.Text;
                    
                    //APPDEF
                    if(this.AppointmentDefinition.SelectedObject != null)
                        appDef = this.AppointmentDefinition.SelectedObject.ObjectID.ToString();
                    
                    //STATE
                    if(this.StatusBox.SelectedItem == null)
                        sState = "";
                    else
                        sState = this.StatusBox.SelectedItem.Value.ToString();
                }
                //MASTERRESOURCE
                this.SaveCriteria("MASTERRESOURCE","System.String",sResources);
                
                //SELECTEDPATIENT
                this.SaveCriteria("SELECTEDPATIENT","System.String",sPID);
                
                //PATIENTNAME
                this.SaveCriteria("PATIENTNAME","System.String",patientName);
                
                //PATIENTSURNAME
                this.SaveCriteria("PATIENTSURNAME", "System.String",patientSurname);
                
                //ID
                this.SaveCriteria("ID", "System.Int64",sActionID);
                
                //APPDEF
                this.SaveCriteria("APPOINTMENTDEFINITION", "System.String", appDef);
                
                //STATE
                this.SaveCriteria("CURRENTSTATE","STATE",sState);
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
        
#endregion AppointmentWLCriteriaForm_Methods
    }
}