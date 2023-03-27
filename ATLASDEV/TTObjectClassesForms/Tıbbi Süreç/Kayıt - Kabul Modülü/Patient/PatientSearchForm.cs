
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
    /// Hasta Arama Formu
    /// </summary>
    public partial class PatientSearchForm : TTListForm
    {
        override protected void BindControlEvents()
        {
            Foreign.CheckedChanged += new TTControlEventDelegate(Foreign_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Foreign.CheckedChanged -= new TTControlEventDelegate(Foreign_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void Foreign_CheckedChanged()
        {
#region PatientSearchForm_Foreign_CheckedChanged
   if (this.Foreign.Value == true)
            {
                this.txtUniqueRefNo.Text = string.Empty;
                this.ForeignUniqueNo.ReadOnly = false;
                this.txtUniqueRefNo.ReadOnly = true;
            }
            else
            {
                this.ForeignUniqueNo.Text = string.Empty;
                this.ForeignUniqueNo.ReadOnly = true;
                this.txtUniqueRefNo.ReadOnly = false;

            }
#endregion PatientSearchForm_Foreign_CheckedChanged
        }

        protected override void PreScript()
        {
#region PatientSearchForm_PreScript
    base.PreScript();
            
            /*

             */

    dataGrid.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dataGrid_RowPrePaint);

            
        if (TTObjectClasses.SystemParameter.GetParameterValue("SEARCHPATIENBYPATIENTID", "TRUE").Trim() == "FALSE")
        {
            txtID.Visible = false;
            labelID.Visible = false;
        }
        else
        {
            txtID.Visible = true;
            labelID.Visible = true;
        }
#endregion PatientSearchForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PatientSearchForm_PostScript
    base.PostScript(transDef);
#endregion PatientSearchForm_PostScript

            }
            
#region PatientSearchForm_Methods
        int timerCount = 0;
        Timer t = new Timer();

        public PatientSearchForm()
            : this(TTList.NewList("PatientSearchList", null))
        {
            t.Interval = 300;
            t.Enabled = false;
            t.Tick += new EventHandler(this.timer_Tick);
        }

        public PatientSearchForm(TTList ttList, string labelString)
            : this(ttList)
        {
            t.Interval = 300;
            t.Enabled = true;
            t.Tick += new EventHandler(this.timer_Tick);
            labelNoPatientFound.Text = labelString;
        }

        public PatientSearchForm(Patient patient)
            : this()
        {
            if (patient.UniqueRefNo != null)
                txtUniqueRefNo.Text = patient.UniqueRefNo.ToString();
            if (patient.ForeignUniqueRefNo != null)
                ForeignUniqueNo.Text = patient.ForeignUniqueRefNo.ToString();
            if (patient.YUPASSNO != null)
                txtYuPassNo.Text = patient.YUPASSNO.ToString();
            if (patient.UnIdentified != null)
                UnIdentified.ControlValue = patient.UnIdentified.Value;
            if (patient.Name != null)
                txtPatientName.Text = patient.Name.ToString();
            if (patient.Surname != null)
                txtPatientSurname.Text = patient.Surname.ToString();
            if (patient.FatherName != null)
                txtFatherName.Text = patient.FatherName.ToString();
            if (patient.MotherName != null)
                txtMotherName.Text = patient.MotherName.ToString();
            //if (patient.Sex != null)
            //{
            //    foreach (TTComboBoxItem item in cbCinsiyet.Items)
            //    {
            //        if ((int)item.Value == (int)patient.Sex.Value)
            //        {
            //            cbCinsiyet.SelectedItem = item;
            //            break;
            //        }
            //    }
            //}
            if (patient.BirthDate != null)
                dateBirthDate.ControlValue = patient.BirthDate;
            if (patient.CountryOfBirth != null)
                CountryOfBirth.SelectedObjectID = patient.CountryOfBirth.ObjectID;
            if (patient.CityOfBirth != null)
                CityOfBirth.SelectedObjectID = patient.CityOfBirth.ObjectID;
            if (patient.TownOfBirth != null)
                TownOfBirth.SelectedObjectID = patient.TownOfBirth.ObjectID;
         /*   if (patient.RetirementFundID != null)
                txtRetirementFundID.Text = patient.RetirementFundID.ToString();*/
            this.OnSearch();

        }

        protected override void OnClear()
        {
            base.OnClear();
            this.Foreign.Value = false;
            this.UnIdentified.Value = false;
            this.txtPatientName.Focus();
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            timerCount++;
            if (timerCount < 8)
            {
                int rem = 0;
                int res = Math.DivRem(timerCount, 2, out rem);
                if (rem == 1)
                    labelNoPatientFound.Visible = true; // (labelNoPatientFound.Visible==false);
                else
                    labelNoPatientFound.Visible = false;
            }
            else
            {
                t.Enabled = false;
                labelNoPatientFound.Visible = true;
                timerCount = 0;
            }
            //labelNoPatientFound.ForeColor = System.Drawing.Color.FromArgb(labelNoPatientFound.ForeColor.ToArgb() + Convert.ToInt32(Microsoft.VisualBasic.VBMath.Rnd()*1000000));
        }

        private Button btnBirlestir;
        private Button btnKayitBilgileri;

        protected override void OnDrawForm()
        {
            this.dataGrid.MultiSelect = true;
            base.OnDrawForm();

            if (Common.CurrentUser.IsSuperUser || Common.CurrentUser.HasRole(Common.MergePatientsRoleID))
            {
                btnBirlestir = new Button();
                btnBirlestir.Text = "Birleştir";
                //btnBirlestir.Location = new Point(90, cmdCancel.Top);
                btnBirlestir.Click += new EventHandler(btnBirlestir_Click);
                pnlButtons.Controls.Add(btnBirlestir);
            }
            if (Common.CurrentUser.IsSuperUser || Common.CurrentUser.HasRole(Common.ReadPatientInfoRoleID))
            {
                btnKayitBilgileri = new Button();
                btnKayitBilgileri.Text = "Kimlik Bilgileri";
                //btnKayitBilgileri.Location = new Point(10, cmdCancel.Top);
                btnKayitBilgileri.Click += new EventHandler(btnKayitBilgileri_Click);
                pnlButtons.Controls.Add(btnKayitBilgileri);
            }

            this.cmdSearch.Text = "Hasta Ara";
            this.cmdOK.Text = "Hastayı Seç";
            //this.pnlCriteria.Height = CRITERIA_DEFAULT_HEIGHT;
            //labelNoPatientFound.Location = new Point((this.Width/2)-(labelNoPatientFound.Size.Width/2),60);
            this.Refresh();
        }

        /// <summary>
        /// Hasta arama Filteresini oluşturur
        /// </summary>
        /// <returns></returns>

        protected override string GetFilterExpression()
        {
            string filterExpression = null;
            string opr = null;
            string injection = null;
            bool criteriaEntered = false;

            TTObjectContext objectContext = new TTObjectContext(true);

            //TC Kimlik No
            if (txtUniqueRefNo.Text.Length > 0 && Common.IsNumeric(txtUniqueRefNo.Text))
            {
                criteriaEntered = true;
                if (filterExpression != null)
                {
                    filterExpression += " AND ";
                }
                filterExpression += "(UNIQUEREFNO = " + txtUniqueRefNo.Text.ToString() + " )";
                return filterExpression;
            }

            //Kimlik/Sigorta No (Yabancı Hastalar)
            if (ForeignUniqueNo.Text.Length > 0 && Common.IsNumeric(ForeignUniqueNo.Text))
            {
                criteriaEntered = true;
                if (filterExpression != null)
                {
                    filterExpression += " AND ";
                }
                filterExpression += "(FOREIGNUNIQUEREFNO = " + ForeignUniqueNo.Text.ToString() + " )";
                return filterExpression;
            }
            
            //YUPASS No (YUPASS lı Hastalar)
            if (txtYuPassNo.Text.Length > 0 && Common.IsNumeric(txtYuPassNo.Text))
            {
                criteriaEntered = true;
                if (filterExpression != null)
                {
                    filterExpression += " AND ";
                }
                filterExpression += "(YUPASSNO = " + txtYuPassNo.Text.ToString() + " )";
                return filterExpression;
            }

            //ID
            txtID.Text = txtID.Text.Trim();
            if (txtID.Text.Length > 0 && txtID.Text.Length <= 9)
            {
                criteriaEntered = true;
                if (Common.IsNumeric(txtID.Text))
                {
                    filterExpression = "(ID = " + txtID.Text + ")";
                    return filterExpression;
                }
            }

            //UnIdentified
            if ((bool)UnIdentified.ControlValue != false)
            {
                criteriaEntered = true;
                if (Convert.ToBoolean(UnIdentified.ControlValue))
                {
                    filterExpression = "(UNIDENTIFIED = 1)";
                    return filterExpression;
                }
            }
            List<Guid> PatientObjectIDs = new List<Guid>();
            //ArrayList PatientObjectIDs = new ArrayList();

            // Name ve Surname arama
            if (txtPatientName.Text.Trim().Length > 0 && txtPatientSurname.Text.Trim().Length > 0)
            {
                ArrayList NameTokens = new ArrayList();
                ArrayList SurnameTokens = new ArrayList();
                criteriaEntered = true;
                injection = null;

                if (txtPatientName.Text.Trim().Length > 0)
                {
                    NameTokens = Common.Tokenize(txtPatientName.Text.Trim(), true);
                    for (int i = 0; i <= NameTokens.Count - 1; i++)
                    {
                        if (i > 0)
                            injection += " OR ";
                        else
                            injection += " AND (";
                        string s = NameTokens[i].ToString();

                        if (s.IndexOf('%') != -1)
                            opr = "LIKE";
                        else
                            opr = "=";
                        injection += "TOKEN " + opr + " '" + s + "' ";

                    }
                    injection += ") AND TOKENTYPE = 0";
                }

                if (txtPatientSurname.Text.Trim().Length > 0)
                {
                    SurnameTokens = Common.Tokenize(txtPatientSurname.Text, true);
                    for (int i = 0; i <= SurnameTokens.Count - 1; i++)
                    {
                        if (i > 0)
                            injection += " OR ";
                        else
                        {
                            if (txtPatientName.Text.Trim().Length > 0)
                                injection += " OR (";
                            else
                                injection += " AND (";
                        }
                        string s = SurnameTokens[i].ToString();

                        if (s.IndexOf('%') != -1)
                            opr = "LIKE";
                        else
                            opr = "=";
                        injection += "TOKEN " + opr + " '" + s + "' ";
                    }
                    injection += ") AND TOKENTYPE = 1";
                }
                if (injection != null)
                {
                    BindingList<PatientToken.GetByInjection_Class> myTokenList = PatientToken.GetByInjection(injection);
                    if (txtPatientName.Text.Trim().Length > 0 && txtPatientSurname.Text.Trim().Length > 0)
                    {

                        Dictionary<Guid, int> Duplicates = new Dictionary<Guid, int>();
                        //ArrayList MatchedIDs = new ArrayList();
                        List<Guid> MatchedIDs = new List<Guid>();
                        injection = "";
                        foreach (PatientToken.GetByInjection_Class t in myTokenList)
                        {
                            if(t.Patientobjectid != null)
                            {
                                string strId = t.Patientobjectid.ToString();
                                Guid patientObjectGuid = new Guid(Convert.ToString(t.Patientobjectid));

                                if (!Duplicates.ContainsKey(patientObjectGuid))
                                    Duplicates.Add(patientObjectGuid, 1);
                                else
                                {
                                    int count = 0;
                                    Duplicates.TryGetValue(patientObjectGuid, out count);
                                    Duplicates.Remove(patientObjectGuid);
                                    Duplicates.Add(patientObjectGuid, count + 1);
                                }
                            }
                        }

                        foreach (KeyValuePair<Guid, int> pair in Duplicates)
                        {
                            if (pair.Value == (NameTokens.Count + SurnameTokens.Count))
                            {
                                if (!MatchedIDs.Contains(pair.Key))
                                    MatchedIDs.Add(pair.Key);
                            }
                        }
                        foreach (Guid matchedGuid in MatchedIDs)
                        {
                            if (!PatientObjectIDs.Contains(matchedGuid))
                                PatientObjectIDs.Add(matchedGuid);
                        }
                    }
                }
            }
            else if (txtPatientName.Text.Trim().Length > 0)
            {
                //Name
                txtPatientName.Text = txtPatientName.Text.Trim();

                criteriaEntered = true;
                injection = null;
                ArrayList NameTokens = new ArrayList();
                NameTokens = Common.Tokenize(txtPatientName.Text, true);

                for (int i = 0; i <= NameTokens.Count - 1; i++)
                {
                    if (i > 0)
                        injection += " OR ";
                    else
                        injection += " AND (";
                    string s = NameTokens[i].ToString();

                    if (s.IndexOf('%') != -1)
                        opr = "LIKE";
                    else
                        opr = "=";
                    injection += "TOKEN " + opr + " '" + s + "' ";
                }
                if (injection != null)
                {
                    injection += ") AND TOKENTYPE = 0";
                    //                    dd
                    BindingList<PatientToken.GetByInjection_Class> tokenList = PatientToken.GetByInjection(injection);
                    foreach (PatientToken.GetByInjection_Class t in tokenList)
                    {
                        if (t.Patientobjectid != null)
                        {
                            if (!PatientObjectIDs.Contains(t.Patientobjectid.Value))
                                PatientObjectIDs.Add(t.Patientobjectid.Value);
                        }
                    }
                }
            }
            else if (txtPatientSurname.Text.Trim().Length > 0)  //Soyadı
            {
                txtPatientSurname.Text = txtPatientSurname.Text.Trim();

                criteriaEntered = true;
                injection = null;
                ArrayList NameTokens = new ArrayList();
                NameTokens = Common.Tokenize(txtPatientSurname.Text, true);
                //
                for (int i = 0; i <= NameTokens.Count - 1; i++)
                {
                    if (i > 0)
                        injection += " OR ";
                    else
                        injection += " AND (";
                    string s = NameTokens[i].ToString();

                    if (s.IndexOf('%') != -1)
                        opr = "LIKE";
                    else
                        opr = "=";
                    injection += "TOKEN " + opr + " '" + s + "' ";
                }
                if (injection != null)
                {
                    injection += ") AND TOKENTYPE = 1";
                    //                    dd
                    BindingList<PatientToken.GetByInjection_Class> tokenList = PatientToken.GetByInjection(injection);
                    foreach (PatientToken.GetByInjection_Class t in tokenList)
                    {
                        if (t.Patientobjectid != null)
                        {
                            if (!PatientObjectIDs.Contains(t.Patientobjectid.Value))
                                PatientObjectIDs.Add(t.Patientobjectid.Value);
                        }
                    }
                }
            }
            if (PatientObjectIDs.Count > 0)
            {
                filterExpression = Common.CreateFilterExpressionOfGuidList(filterExpression,String.Empty, PatientObjectIDs);
            }

           

            if (filterExpression != null)
            {
                //Baba Adı
                if (txtFatherName.Text.Length > 0)
                {
                    criteriaEntered = true;
                    if (filterExpression != null)
                    {
                        filterExpression += " AND ";
                    }
                    if (txtFatherName.Text.ToString().IndexOf('%') != -1)
                        filterExpression += "(FATHERNAME LIKE '" + txtFatherName.Text + "%')";
                    else
                        filterExpression += "(FATHERNAME = '" + txtFatherName.Text + "')";
                }

                //Anne Adı
                if (txtMotherName.Text.Length > 0)
                {
                    criteriaEntered = true;
                    if (filterExpression != null)
                    {
                        filterExpression += " AND ";
                    }
                    if (txtMotherName.Text.ToString().IndexOf('%') != -1)
                        filterExpression += "(MOTHERNAME LIKE '" + txtMotherName.Text + "%')";
                    else
                        filterExpression += "(MOTHERNAME = '" + txtMotherName.Text + "')";
                }

                //Cinsiyet
                if (cbCinsiyet.SelectedIndex > 0)
                {
                    criteriaEntered = true;
                    string filter = "(SEX=" + (cbCinsiyet.ControlValue).ToString() + ")";
                    if (filterExpression == null)
                        filterExpression = "(" + filter + ")";
                    else
                        filterExpression += " AND (" + filter + ")";
                }


                //Doğum Tarihi
                if (dateBirthDate.ControlValue != null)
                {
                    criteriaEntered = true;
                    string firstDate = "01.01." + (Convert.ToDateTime(dateBirthDate.ControlValue).Date).ToString("yyyy") + " 00:00:00";
                    string lastDate = "31.12." + (Convert.ToDateTime(dateBirthDate.ControlValue).Date).ToString("yyyy") + " 23:59:59";

                    //                    string filter = "(BIRTHDATE >= '" + (Convert.ToDateTime(firstDate).Date).ToString("yyyy-MM-dd HH:mm") + "' AND";
                    //                    filter += " BIRTHDATE <= '" + (Convert.ToDateTime(lastDate).Date).ToString("yyyy-MM-dd HH:mm") + "')";
                    string filter = "(BIRTHDATE >= '" + (Convert.ToDateTime(firstDate).Date.ToShortDateString()) + "' AND";
                    filter += " BIRTHDATE <= '" + (Convert.ToDateTime(lastDate).Date.ToShortDateString()) + "')";
                    if (filterExpression == null)
                        filterExpression = "(" + filter + ")";
                    else
                        filterExpression += " AND (" + filter + ")";
                }

                //Ülke
                if (CountryOfBirth.SelectedObjectID != null)
                {
                    criteriaEntered = true;
                    string filter = "(COUNTRYOFBIRTH = '" + CountryOfBirth.SelectedObjectID.ToString() + "')";
                    if (filterExpression == null)
                        filterExpression = "(" + filter + ")";
                    else
                        filterExpression += " AND (" + filter + ")";
                }

                //İl
                if (CityOfBirth.SelectedObjectID != null)
                {
                    criteriaEntered = true;
                    string filter = "(CITYOFBIRTH = '" + CityOfBirth.SelectedObjectID.ToString() + "')";
                    if (filterExpression == null)
                        filterExpression = "(" + filter + ")";
                    else
                        filterExpression += " AND (" + filter + ")";
                }

                //ilçe
                if (TownOfBirth.SelectedObjectID != null)
                {
                    criteriaEntered = true;
                    string filter = "(TOWNOFBIRTH = '" + TownOfBirth.SelectedObjectID.ToString() + "')";
                    if (filterExpression == null)
                        filterExpression = "(" + filter + ")";
                    else
                        filterExpression += " AND (" + filter + ")";
                }

            }

            if (filterExpression == null)
                filterExpression = "1=0";
            if (criteriaEntered == true)
                labelNoPatientFound.Text = "Girdiğiniz kriterlere uygun sonuç bulunamadı!";
            else
                labelNoPatientFound.Text = "En az bir tane geçerli kriter girmelisiniz!";
            return filterExpression;
        }

        /// <summary>
        /// Hasta arama
        /// </summary>
        protected override void OnSearch()
        {
           // Cursor current = Cursor.Current;
           // Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (!Common.CurrentUser.IsSuperUser)
                    if (!Common.CurrentUser.HasRole(Common.SearchPatientRoleID))
                {
                    String message = SystemMessage.GetMessage(84);
                    throw new TTUtils.TTException(message);
                    //throw new Exception("Hasta arama için yetkiniz yok.");
                }
                IList list = _ttList.GetObjectListByExpression(GetFilterExpression());
                dataGrid.DataSource = list;
                labelNoPatientFound.Visible = false;
                if (list.Count > 0)
                {
                    if (list.Count > 100)
                    {
                        labelNoPatientFound.Text = "100'den fazla kayıt var. T.C. Kimlik No ile arama yapınız!";
                        t.Enabled = true;
                    }
                    t.Enabled = false;
                    
                    dataGrid.Focus();
                }
                else
                {
                    labelNoPatientFound.Text = "Girdiğiniz kriterlere uygun sonuç bulunamadı!";
                    t.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
            finally
            {
          //      Cursor.Current = current;
            }
        }



        /// <summary>
        /// Smart Kart Takılı ise TC kimlik noyu arama formuna aktarır.
        /// </summary>
        /// <param name="readerName"></param>
        override protected void SmartCardInserted(string readerName)
        {
            KimlikBilgileri k = SmartCard.ReadSmartCardData(readerName);
            string TCKimlikNo = k.TCKimlikNo;
            if (string.IsNullOrEmpty(TCKimlikNo))
            {
                txtUniqueRefNo.Text = TCKimlikNo;
            }
        }
        /// <summary>
        /// SmartCard çıkarılınca TC kimlik noyu boşaltır.
        /// </summary>
        /// <param name="readerName"></param>
        override protected void SmartCardEjected(string readerName)
        {
            txtUniqueRefNo.Text = "";
        }

        void dataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow gridRow = dataGrid.Rows[e.RowIndex];
            if (gridRow.DataBoundItem != null)
            {
                Patient patient = (Patient)gridRow.DataBoundItem;
                if (patient.MergedToPatient != null)
                {
                    gridRow.DefaultCellStyle.ForeColor = Color.Red;
                    Font font = new Font(gridRow.DataGridView.DefaultCellStyle.Font.FontFamily, gridRow.DataGridView.DefaultCellStyle.Font.Size, FontStyle.Bold);
                    gridRow.DefaultCellStyle.Font = font;
                }
            }
        }
        
#endregion PatientSearchForm_Methods

#region PatientSearchForm_ClientSideMethods
        /// <summary>
        /// Hasta birleştirir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnBirlestir_Click(object sender, EventArgs e)
        {
            if (!Common.CurrentUser.IsSuperUser)
            {
                if (!Common.CurrentUser.HasRole(Common.MergePatientsRoleID))
                {
                    String message = SystemMessage.GetMessage(78);
                    throw new TTUtils.TTException(message);
                    //throw new Exception("Hasta dosyası birleştirme için yetkiniz yok.");
                }
            }
            if (this.dataGrid.SelectedRows.Count < 2)
            {
                String message = SystemMessage.GetMessage(79);
                throw new TTUtils.TTException(message);
                //throw new Exception("Hasta dosyası birleştirme için birden fazla hasta seçmelisiniz.");
            }

            if (ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Hasta Dosyası Birleştirme", "Seçilen hastaların dosyaları birleştirilecektir. \r\nDevam etmek istediğinize emin misiniz?") == "H")
            {
                String message = SystemMessage.GetMessage(80);
                throw new TTUtils.TTException(message);
                //throw new Exception("İşlemden vazgeçildi");
            }            
            MergePatients();              
        } 
        
        
        /// <summary>
        /// Kayıt bilgilerini gösterir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnKayitBilgileri_Click(object sender, EventArgs e)
        {           
            TTObjectContext objectContext = new TTObjectContext(false);
            PatientForm frm = new PatientForm();
            foreach (DataGridViewRow row in dataGrid.SelectedRows)
            {
                Guid patientObjectID = ((Patient)row.DataBoundItem).ObjectID;
                Patient patient = (Patient)objectContext.GetObject(patientObjectID, "Patient");
                frm.ShowEdit(this.ParentForm, patient);
            }           
        }
        
        /// <summary>
        /// Hastaları birleştirir
        /// </summary>
        private void MergePatients()
        {
         // //  Cursor current = Cursor.Current;
        //    Cursor.Current = Cursors.WaitCursor;
            TTObjectContext objectContext = new TTObjectContext(false);
            Guid savePoint = objectContext.BeginSavePoint();
            try
            {
                MultiSelectForm MSItem = new MultiSelectForm();
                ArrayList selectedPatientList = new ArrayList();
                foreach (DataGridViewRow row in dataGrid.SelectedRows)
                {
                    Guid patientObjectID = ((Patient)row.DataBoundItem).ObjectID;
                    Patient patient = (Patient)objectContext.GetObject(patientObjectID, "Patient");
                    selectedPatientList.Add(patient);
                    MSItem.AddMSItem(patient.ID.ToString() + " " + patient.Name + " " + patient.Surname, patient.ObjectID.ToString(), patient);
                }
                string key = MSItem.GetMSItem(this, "Kayıtların birleşeceği hastayı seçiniz.", false, true, false, false, false, false);
                if (!string.IsNullOrEmpty(key))
                {
                    bool merge = false;
                    Guid targetPatientObjectID = ((Patient)MSItem.MSSelectedItemObject).ObjectID;
                    Patient targetPatient = (Patient)objectContext.GetObject(targetPatientObjectID, "Patient");
                    if (targetPatient.MergedToPatient != null)
                    {
                        Patient mp = (Patient)objectContext.GetObject(targetPatient.MergedToPatient.ObjectID, "Patient");

                        string[] hataParamList = new string[] { "'" + targetPatient.ID.ToString() + " " + targetPatient.Name + " " + targetPatient.Surname + "'", "'" + mp.ID.ToString() + " " + mp.Name + " " + mp.Surname + "'" };
                        String message = SystemMessage.GetMessageV3(81, hataParamList);
                        throw new TTUtils.TTException(message);

                    }
                    ArrayList sourcePatientEpisodes;
                    foreach (Patient sourcePatient in selectedPatientList)
                    {
                        if (sourcePatient.ObjectID != targetPatient.ObjectID)
                        {
                            if (sourcePatient.MergedToPatient != null)
                            {
                                Patient mp = (Patient)objectContext.GetObject(sourcePatient.MergedToPatient.ObjectID, "Patient");
                                string[] hataParamList = new string[] { "'" + sourcePatient.ID.ToString() + " " + sourcePatient.Name + " " + sourcePatient.Surname + "'", "'" + mp.ID.ToString() + " " + mp.Name + " " + mp.Surname + "'" };
                                String message = SystemMessage.GetMessageV3(81, hataParamList);
                                throw new TTUtils.TTException(message);
                            }

                            //--
                            string differentProperties = "";
                            string ignoredPrpoerties = ",EHR,ImportantMedicalInformation,InpatientEpisode,MergedToPatient,PatientFolder,Service,";
                            foreach (TTObjectPropertyDef propDef in sourcePatient.ObjectDef.AllPropertyDefs)
                            {
                                if (!(ignoredPrpoerties.Contains("," + propDef.CodeName.ToString() + ",")))
                                {
                                    //TODO : System.Reflection.PropertyInfo sebebiyle servera taşınmalı
                                    System.Reflection.PropertyInfo propInfo = sourcePatient.GetType().GetProperty(propDef.CodeName.ToString());
                                    if (propInfo != null)
                                    {
                                        object sourcePatientPropertyObject = propInfo.GetValue(sourcePatient, null);
                                        object targetPatientPropertyObject = propInfo.GetValue(targetPatient, null);
                                        string sourcePatientPropertyValue = sourcePatientPropertyObject == null ? "" : sourcePatientPropertyObject.ToString().Trim();
                                        string targetPatientPropertyValue = targetPatientPropertyObject == null ? "" : targetPatientPropertyObject.ToString().Trim();
                                        if (sourcePatientPropertyValue != targetPatientPropertyValue)
                                        {
                                            string caption = propDef.Caption == null ? propDef.Description : propDef.Caption;
                                            if (String.IsNullOrEmpty(caption))
                                                caption = propDef.CodeName;
                                            differentProperties += " , " + caption;
                                        }
                                    }
                                }
                            }

                            foreach (TTObjectRelationDef relDef in sourcePatient.ObjectDef.AllParentRelationDefs)
                            {
                                if (!(ignoredPrpoerties.Contains("," + relDef.CodeName.ToString() + ",")))
                                {
                                    //TODO : System.Reflection.PropertyInfo sebebiyle servera taşınmalı
                                    System.Reflection.PropertyInfo propInfo = sourcePatient.GetType().GetProperty(relDef.CodeName.ToString());
                                    if (propInfo != null)
                                    {
                                        object sourcePatientPropertyObject = propInfo.GetValue(sourcePatient, null);
                                        object targetPatientPropertyObject = propInfo.GetValue(targetPatient, null);
                                        string sourcePatientPropertyValue = sourcePatientPropertyObject == null ? "" : sourcePatientPropertyObject.ToString().Trim();
                                        string targetPatientPropertyValue = targetPatientPropertyObject == null ? "" : targetPatientPropertyObject.ToString().Trim();
                                        if (sourcePatientPropertyValue != targetPatientPropertyValue)
                                        {
                                            string caption = relDef.ParentCaption == null ? relDef.ParentName : relDef.ParentCaption;
                                            differentProperties += " , " + caption;
                                        }
                                    }
                                }
                            }
                            string result = "E";
                            if (!String.IsNullOrEmpty(differentProperties))
                            {
                                result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Birleştirilmek istenen hastalar farklıdır", sourcePatient.ID.ToString() + " " + sourcePatient.Name + " " + sourcePatient.Surname + " Hastasının " + differentProperties + " özellikleri " + targetPatient.ID.ToString() + " " + targetPatient.Name + " " + targetPatient.Surname + " hastasından farklıdır.Devam etmek istediğinize emin misiniz?");
                            }
                            if (result == "E")
                            {
                                //--
                                merge = true;
                                sourcePatientEpisodes = new ArrayList();
                                foreach (Episode e in sourcePatient.Episodes)
                                {
                                    sourcePatientEpisodes.Add(e);
                                }
                                foreach (Episode e in sourcePatientEpisodes)
                                {
                                    e.OldPatient = e.Patient; //To save old patient for dismerge.
                                    e.Patient = targetPatient;
                                }
                                sourcePatient.MergedToPatient = targetPatient;
                                sourcePatient.UniqueRefNo = null;
                                sourcePatient.Note = "Hastanın dosyası, " + Common.RecTime().ToShortDateString() + " tarihinde " + targetPatient.ID.ToString() + " " + targetPatient.Name + " " + targetPatient.Surname + " hastası ile birleştirilmiştir.";

                                //SITEID ye bagli olarak kontrol yapilmis, istenirse sistem parametresine bagli olarak PACS a patient bilgisi gonderilebilir.
                                SendMergeInfoToPACS(sourcePatient.ObjectID.ToString());
                            }
                            else
                            {
                                InfoBox.Alert(sourcePatient.ID.ToString() + " " + sourcePatient.Name + " " + sourcePatient.Surname + " Hastasının, " + targetPatient.ID.ToString() + " " + targetPatient.Name + " " + targetPatient.Surname + " hastası ile birleştirilmesinden vazgeçildi.");
                            }
                        }
                    }
                    if (merge)
                    {
                        objectContext.Save();
                        InfoBox.Alert(SystemMessage.GetMessage(82));
                    }
                    //TODO BG task (28057) girildi 
                    //OnSearch();
                }
                else
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(80));
                }

            }
            catch (Exception ex)
            {
                objectContext.RollbackSavePoint(savePoint);
                InfoBox.Alert(ex);
            }
            finally
            {
                //Cursor.Current = current;
            }
        }
        
        
        /// <summary>
        /// Hasta birleştirme bilgilerini Pacs'a gönder...
        /// </summary>
        /// <param name="patientID"></param>
        private void SendMergeInfoToPACS(string patientID)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            Patient patient = (Patient)objectContext.GetObject(new Guid(patientID), "Patient");
            if(patient.MergedToPatient != null)
            {
                string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
                if (sysparam == "TRUE")
                {
                    List<Guid> patientIDs = new List<Guid>();
                    patientIDs.Add(new Guid(patientID));
                    try
                    {
                        //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.MediumPriority, "InternalTcpClient", "HL7Remoting", "SendHospitalMessageToEngine", null, patientIDs, "A40", "PACS");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        
#endregion PatientSearchForm_ClientSideMethods
    }
}