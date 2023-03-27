
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
    public partial class HastaSorgulamaFormu : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            btnExceleAktar.Click += new TTControlEventDelegate(btnExceleAktar_Click);
            ttbtnListele.Click += new TTControlEventDelegate(ttbtnListele_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnExceleAktar.Click -= new TTControlEventDelegate(btnExceleAktar_Click);
            ttbtnListele.Click -= new TTControlEventDelegate(ttbtnListele_Click);
            base.UnBindControlEvents();
        }

        private void btnExceleAktar_Click()
        {
#region HastaSorgulamaFormu_btnExceleAktar_Click
   try
            {
                if (gridInpatientPatient.Rows.Count == 0)
                {
                    InfoBox.Show("Excele aktarmak için hasta grubu seçiniz.");
                    return;
                }

                //SaveFileDialog saveFileDialog = new SaveFileDialog();
                //saveFileDialog.Filter = "Excel 97-2003 Workbook (*.xls)|*.xls";
                //saveFileDialog.DefaultExt = "xls";
                //saveFileDialog.RestoreDirectory = true;

                //DialogResult dialogResult = saveFileDialog.ShowDialog(this);
                //if (dialogResult == DialogResult.OK)
                //{
                //    this.gridInpatientPatient.ExportGridToExcel(saveFileDialog.FileName, false);
                //}
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion HastaSorgulamaFormu_btnExceleAktar_Click
        }

        private void ttbtnListele_Click()
        {
#region HastaSorgulamaFormu_ttbtnListele_Click
   gridInpatientPatient.Rows.Clear();
            
            if (gridHAstaGruplari.Rows.Count > 0)
            {
                List<int> hastaGrubuList = new List<int>();
                
                TTObjectContext objectContext = new TTObjectContext(false);

                foreach (ITTGridRow item in gridHAstaGruplari.Rows)
                {
                    if ((item.Cells[hastaGrubu.Name].Value) != null)
                    {
                        if (!hastaGrubuList.Contains(Convert.ToInt32(item.Cells[hastaGrubu.Name].Value)))
                        {
                            hastaGrubuList.Add(Convert.ToInt32(item.Cells[hastaGrubu.Name].Value));
                        }
                    }
                }
                
                foreach (KeyValuePair<Guid, Sites> targetSite in Sites.AllActiveSitesWithoutCurrentSiteAndLOCALHOST)
                {
                    if (targetSite.Value.Name != "LOCALHOST" )
                    {
                        TTObjectContext context = new TTObjectContext(true);
                        // PatientGroupDefinition patientGroup = (PatientGroupDefinition)context.GetObject(this.cmbPatientGroup.SelectedItem, typeof(PatientGroupDefinition));
                        // Common.GetEnumValueDefOfEnumValue(
                        try
                        {
                            //foreach (InPatientTreatmentClinicApplication.GetInpatientByPatientGroup_Class inpatient in InPatientTreatmentClinicApplication.RemoteMethods.GetRemoteInpatients(targetSite.Key,hastaGrubuList))
                            //{
                            //    ITTGridRow newRow = gridInpatientPatient.Rows.Add();
                            //    newRow.Cells[textUniqueRefNo.Name].Value = inpatient.UniqueRefNo;
                            //    newRow.Cells[textPatientName.Name].Value = inpatient.Name;
                            //    newRow.Cells[textPatientSurname.Name].Value = inpatient.Surname;
                            //    newRow.Cells[textHospital.Name].Value = targetSite.Value.Name;
                            //    newRow.Cells[textService.Name].Value = inpatient.Klinik;
                            //    newRow.Cells[textRoomBed.Name].Value = inpatient.Oda;
                            //    newRow.Cells[textbed.Name].Value = inpatient.Yatak;
                            //    newRow.Cells[textInpatientDate.Name].Value = inpatient.XXXXXXyatistarihi;
                      
                            //}
                        }
                        catch (Exception ex)
                        {
                            ITTGridRow newRow = gridInpatientPatient.Rows.Add();
                            newRow.Cells[textUniqueRefNo.Name].Value = "";
                            newRow.Cells[textPatientName.Name].Value = "";
                            newRow.Cells[textPatientSurname.Name].Value = "";
                            newRow.Cells[textRank.Name].Value = "";
                            newRow.Cells[textclass.Name].Value = "";
                            newRow.Cells[textMilitaryUnit.Name].Value = "";
                            newRow.Cells[textHospital.Name].Value = targetSite.Value.Name;
                            newRow.Cells[textService.Name].Value = "SAHAYA ULAŞILAMIYOR";
                            newRow.Cells[textRoomBed.Name].Value = "";
                            newRow.Cells[textbed.Name].Value = "";
                            newRow.Cells[textInpatientDate.Name].Value = "";
                             newRow.Cells[textPatientGroup.Name].Value = "";
                        }
                    }
                }

                //
                //                        BackgroundWorker bw = new BackgroundWorker();
                //                    bw.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
                //                    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
                //                    Application.DoEvents();
                //                    bw.RunWorkerAsync(new KeyValuePair<Guid, String>(targetSite.Key, this.PatientGroupListBox.SelectedObjectID.ToString()));

                // }
                
            }
            else
            {
                InfoBox.Show("Hasta grubu seçmelisiniz.",MessageIconEnum.ErrorMessage);
            }
#endregion HastaSorgulamaFormu_ttbtnListele_Click
        }

#region HastaSorgulamaFormu_Methods
        /*
        private object _lockListView = new object();
        
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            KeyValuePair<Guid,List<InPatientInfoClass.InPatientInfo>> result = (KeyValuePair<Guid,List<InPatientInfoClass.InPatientInfo>>)e.Result;
            List<InPatientInfoClass.InPatientInfo> patientInfos = result.Value;
            if (patientInfos != null)
            {
                if (patientInfos.Count > 0)
                {
                    lock(_lockListView)
                    {
                        foreach (InPatientInfoClass.InPatientInfo patientInfo in patientInfos)
                        {
                            ITTListViewItem listViewItem = PatientInfoList.Items.Add(patientInfo.name);
                            listViewItem.Tag = patientInfo;
                            listViewItem.SubItems.Add(patientInfo.name.ToString());
                            listViewItem.SubItems.Add(patientInfo.surname.ToString());
                            listViewItem.SubItems.Add(patientInfo.hospitalName.ToString());
                            listViewItem.SubItems.Add(patientInfo.clinic.ToString());
                        }
                    }
                }
            }
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            KeyValuePair<Guid, String> param = (KeyValuePair<Guid, String>)e.Argument;
            try
            {
                List<InPatientInfoClass.InPatientInfo> patientInfos = GetPatientInfo_ServerSide(param.Value);
                e.Result = new KeyValuePair<Guid,List<InPatientInfoClass.InPatientInfo>>(param.Key, patientInfos);
            }
            catch
            {
                e.Result = new KeyValuePair<Guid,List<InPatientInfoClass.InPatientInfo>>(param.Key, null);
            }
        }
        
        public static List<InPatientInfoClass.InPatientInfo> GetPatientInfo_ServerSide(string GroupObjectID)
        {

            TTObjectContext context = new TTObjectContext(true);
            List<InPatientInfoClass.InPatientInfo> returnValueList = new List<InPatientInfoClass.InPatientInfo>();
            

            Guid patientGroupObjectID = new Guid(GroupObjectID) ;
            PatientGroupDefinition patientGroup = (PatientGroupDefinition)context.GetObject(patientGroupObjectID, typeof(PatientGroupDefinition));

            BindingList< Patient> patientList = Patient.GetInpatientPatientsByPatientGroup(context, Convert.ToInt32(patientGroup.OrderNo));

            foreach (Patient patient in patientList)
            {
                foreach(EpisodeAction episodeAction in patient.InpatientEpisode.EpisodeActions)
                {
                    if(episodeAction is InPatientTreatmentClinicApplication)
                    {
                        InPatientInfoClass.InPatientInfo returnValue = new InPatientInfoClass.InPatientInfo();
                        returnValue.clinic = ((InPatientTreatmentClinicApplication)episodeAction).BaseInpatientAdmission.PhysicalStateClinic.Name;
                        returnValue.name = patient.Name;
                        returnValue.surname = patient.Surname;  
                      
                       // returnValue.hospitalName = txtSiteName.Text;
                       returnValueList.Add(returnValue);
                    }
                }
            }
            
            //  BindingList<Patient> patientList= Patient.GetAllPatients(context," AND INPATIENTEPISODE IS NOT NULL AND PATIENTGROUP = '" + GroupObjectID + "'");
         */   
            /* Material material = (Material)context.GetObject(new Guid(MaterialObjectID),typeof(Material));
            foreach (MainStoreDefinition mainstore in MainStoreDefinition.GetAllMainStores(context))
            {
                IList stocks = context.QueryObjects("STOCK", "MATERIAL ='" + MaterialObjectID + "' AND STORE =" + ConnectionManager.GuidToString(mainstore.ObjectID));
                RemotingInfoClass.MaterialInheldInfo materialInheld = new RemotingInfoClass.MaterialInheldInfo();
                materialInheld.accountancy = mainstore.Accountancy;
                materialInheld.mainStoreObjectID = mainstore.ObjectID;
                if(stocks.Count > 0)
                {
                    if(stocks.Count == 1)
                    {
                        Stock stock = (Stock)stocks[0];
                        materialInheld.inheld = (Currency)stock.Inheld ;
                        materialInheld.consigned = (Currency)stock.Consigned;
                        materialInheld.maxLevel = (Currency)stock.MaximumLevel;
                        materialInheld.minLevel = (Currency)stock.MinimumLevel;
                    }
                }
                else
                {
                    materialInheld.inheld = 0;
                    materialInheld.consigned = 0;
                    materialInheld.maxLevel = 0;
                    materialInheld.minLevel = 0;
                }
                returnValue.Add(materialInheld);
            }*/
//            return returnValueList;
//        }
//
        
#endregion HastaSorgulamaFormu_Methods
    }
}