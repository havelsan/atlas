
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
    /// Sağlık Kurulu XXXXXX Okul Tc Kimlik No Eşleştirme
    /// </summary>
    public partial class HCMilitaryUnitTCNoMatchForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ReportButton.Click += new TTControlEventDelegate(ReportButton_Click);
            DeleteButton.Click += new TTControlEventDelegate(DeleteButton_Click);
            SaveButton.Click += new TTControlEventDelegate(SaveButton_Click);
            ImportFileButton.Click += new TTControlEventDelegate(ImportFileButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ReportButton.Click -= new TTControlEventDelegate(ReportButton_Click);
            DeleteButton.Click -= new TTControlEventDelegate(DeleteButton_Click);
            SaveButton.Click -= new TTControlEventDelegate(SaveButton_Click);
            ImportFileButton.Click -= new TTControlEventDelegate(ImportFileButton_Click);
            base.UnBindControlEvents();
        }

        private void ReportButton_Click()
        {
#region HCMilitaryUnitTCNoMatchForm_ReportButton_Click
   Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
   TTReportTool.PropertyCache<object> year = new TTReportTool.PropertyCache<object>();
   TTReportTool.PropertyCache<object> militaryUnit = new TTReportTool.PropertyCache<object>();
   try
   {
       year.Add("VALUE", Convert.ToInt16(this.Year.Text.ToString()));
       militaryUnit.Add("VALUE", this.MilitaryUnitList.SelectedObject.ObjectID.ToString());
       parameter.Add("YEAR", year);
       parameter.Add("MILTARYUNIT", militaryUnit);
       TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HCMilitaryUnitTCNoMatchReport), true, 1, parameter);
   }
            catch
   {
       InfoBox.Show("Lütfen Tarih ve XXXXXX Okul bilgisini giriniz.");
   }
#endregion HCMilitaryUnitTCNoMatchForm_ReportButton_Click
        }

        private void DeleteButton_Click()
        {
#region HCMilitaryUnitTCNoMatchForm_DeleteButton_Click
   int counter = 0;
   if(this.AlreadyExistTcIdentifyNo.Count > 0 && this.MilitaryUnitList.SelectedObjectID != null && this.Year!= null)
            {
                try
                {
                    while (counter < this.AlreadyExistTcIdentifyNo.Count)
                    {
                        TTObjectContext context = new TTObjectContext(false);
                        IBindingList hcMilitaryUnitTCNoMatchList = context.QueryObjects("HCMILITARYUNITTCNOMATCH", "TCNO='" + this.AlreadyExistTcIdentifyNo[counter] + "' AND YEAR =" + this.Year.Text + " AND MILITARYUNIT = '" + this.MilitaryUnitList.SelectedObjectID.ToString() + "'");
                        HCMilitaryUnitTCNoMatch hcm = (HCMilitaryUnitTCNoMatch)hcMilitaryUnitTCNoMatchList[0];
                        ((ITTObject)hcm).Delete();
                        context.Save();
                        context.Dispose();
                        counter++;
                    }
                    InfoBox.Show("Silme işlemi Başarılı", MessageIconEnum.InformationMessage);
                    
                }
                catch(Exception e)
                {
                    InfoBox.Show(e);
                }
                this.TcIdentifyNo.Clear();
                this.AlreadyExistTcIdentifyNo.Clear();
                this.FileName.Visible = false;
   }
   else
       InfoBox.Show("Lütfen Dosya Yükleme, Yıl bilgisi ve XXXXXX Okul bilgisi girme işlemlerini yapınız.");
#endregion HCMilitaryUnitTCNoMatchForm_DeleteButton_Click
        }

        private void SaveButton_Click()
        {
#region HCMilitaryUnitTCNoMatchForm_SaveButton_Click
   int counter = 0;
            if((this.TcIdentifyNo.Count > 0 || this.AlreadyExistTcIdentifyNo.Count > 0) && this.MilitaryUnitList.SelectedObjectID != null && this.Year!= null)
            {
                try
                {
                    while (counter < this.TcIdentifyNo.Count)
                    {
                        TTObjectContext context = new TTObjectContext(false);
                        HCMilitaryUnitTCNoMatch hcm = new HCMilitaryUnitTCNoMatch(context);
                        hcm.TCNo = this.TcIdentifyNo[counter];
                        hcm.Year = Convert.ToInt16(this.Year.Text);
                        hcm.IsRead = false;
                        hcm.MilitaryUnit = (MilitaryUnit)context.GetObject(new Guid(this.MilitaryUnitList.SelectedObjectID.ToString()), typeof(MilitaryUnit));
                        context.Save();
                        context.Dispose();
                        counter++;
                    }
                    if(this.AlreadyExistTcIdentifyNo.Count == 0)
                        InfoBox.Show("Kayıt Başarılı", MessageIconEnum.InformationMessage);
                    else
                    {
                        string infoForExistID = "Kayıt Başarılı. \nDiğer okullarda kayıtları olduğu için başarısız olan kayıtlar:\n";
                        foreach(string tc in this.AlreadyExistTcIdentifyNo)
                            infoForExistID += tc + ", ";
                        InfoBox.Show(infoForExistID.Substring(0,infoForExistID.Length-2),MessageIconEnum.InformationMessage);
                    }
                }
                catch(Exception e)
                {
                    InfoBox.Show(e);
                }
                this.TcIdentifyNo.Clear();
                this.AlreadyExistTcIdentifyNo.Clear();
                this.FileName.Visible = false;
            }
            else
                InfoBox.Show("Lütfen Dosya Yükleme, Yıl bilgisi ve XXXXXX Okul bilgisi girme işlemlerini yapınız.");
#endregion HCMilitaryUnitTCNoMatchForm_SaveButton_Click
        }

        private void ImportFileButton_Click()
        {
#region HCMilitaryUnitTCNoMatchForm_ImportFileButton_Click
   string line;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Yüklenecek dosyayı belirleyin";
            dialog.DefaultExt = "txt";
            dialog.Filter = "Metin dosyalar (*.txt)|*.txt|Tüm dosyalar (*.*)|*.*";
            dialog.RestoreDirectory = true;
            TTObjectContext context = new TTObjectContext(false);
            DialogResult dialogResult = dialog.ShowDialog(this);
            
            if(dialogResult == DialogResult.OK)
            {
                this.TcIdentifyNo.Clear();
                this.AlreadyExistTcIdentifyNo.Clear();
                System.IO.StreamReader streamReader = new System.IO.StreamReader(dialog.FileName);
                while((line = streamReader.ReadLine()) != null)
                {
                    IBindingList hcMilitaryUnitTCNoMatchList = context.QueryObjects("HCMILITARYUNITTCNOMATCH", "TCNO='" + line + "' AND YEAR =" + DateTime.Today.Year);
                    if(hcMilitaryUnitTCNoMatchList.Count > 0)
                        this.AlreadyExistTcIdentifyNo.Add(line);
                    else
                        this.TcIdentifyNo.Add(line);
                }
                streamReader.Close();
                this.FileName.Text = dialog.FileName;
                this.FileName.Visible = true;
            }
            context.Dispose();
#endregion HCMilitaryUnitTCNoMatchForm_ImportFileButton_Click
        }

#region HCMilitaryUnitTCNoMatchForm_Methods
        public List<string> TcIdentifyNo = new List<string>();
        public List<string> AlreadyExistTcIdentifyNo = new List<string>();
        
#endregion HCMilitaryUnitTCNoMatchForm_Methods
    }
}