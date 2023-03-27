
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
    /// Nükleer Tıp Radyofarmasi Formu
    /// </summary>
    public partial class NuclearMedicineRadioPharmacyForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            PrintBarcodeButton.Click += new TTControlEventDelegate(PrintBarcodeButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            PrintBarcodeButton.Click -= new TTControlEventDelegate(PrintBarcodeButton_Click);
            base.UnBindControlEvents();
        }

        private void PrintBarcodeButton_Click()
        {
#region NuclearMedicineRadioPharmacyForm_PrintBarcodeButton_Click
            //const string asc01 = "\u0001";
            //const string asc02 = "\u0002";
            //const string crlf = "\r\n";

            //string name = this._NuclearMedicine.Episode.Patient.Name + " " + this._NuclearMedicine.Episode.Patient.Surname;
            //string age = this._NuclearMedicine.Episode.Patient.Age.ToString();
            //string sex = this._NuclearMedicine.Episode.Patient.Sex.ToString();
            //string uniquerefno = this._NuclearMedicine.Episode.Patient.UniqueRefNo.ToString();
            //string prepDate = this._NuclearMedicine.PharmaceuticalPrepDate.ToString();
            //string testno = this._NuclearMedicine.TestSequenceNo.ToString();
            //string etiket = "";

            //etiket += asc02 + "KI70x1" + crlf;
            //etiket += asc02 + "M3000" + crlf;
            //etiket += asc02 + "c0000" + crlf;
            //etiket += asc02 + "e" + crlf;
            //etiket += asc02 + "O0215" + crlf;
            //etiket += asc02 + "f255" + crlf;
            //etiket += asc01 + "D";
            //etiket += asc02 + "L" + crlf;
            //etiket += asc02 + "L" + crlf;
            //etiket += "D11" + crlf;
            //etiket += "PE" + crlf;
            //etiket += "SE" + crlf;
            //etiket += "H10" + crlf;
            //etiket += "1AA506900880056" + testno + crlf;
            //etiket += "141100002120042" + name + crlf;
            //etiket += "141100002110243" + uniquerefno + crlf;
            //etiket += "141100002110243" + age + crlf;
            //etiket += "121100000610047";
            //int i = 1;
            //foreach (NucMedRadPharmMatGrid radPharm in this._NuclearMedicine.RadPharmMaterials)
            //{
            //    etiket += "(" + i + ")" + radPharm.Material.Name + " " + radPharm.Amount + " doz ";
            //    i++;
            //}
            //etiket += crlf;
            //etiket += "121100000420046" + prepDate + crlf;
            //etiket += "Q0001" + crlf;
            //etiket += "E" + crlf;
            //System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\dene.prn");
            //sw.Write(etiket);
            //sw.Close();

            //try
            //{
            //    System.IO.Ports.SerialPort s = new System.IO.Ports.SerialPort("COM1", 9600, System.IO.Ports.Parity.None, 8);
            //    s.Handshake = System.IO.Ports.Handshake.None;
            //    s.Open();
            //    s.WriteTimeout = 5000;
            //    s.Write(etiket);
            //    s.Close();
            //}

            //catch (Exception ex)
            //{
            //    string hatamesaji = "Etiket yazdırma sırasında hata oluştu. \r\n" + ex.ToString();
            //}
            var a = 1;
#endregion NuclearMedicineRadioPharmacyForm_PrintBarcodeButton_Click
        }

        protected override void PreScript()
        {
#region NuclearMedicineRadioPharmacyForm_PreScript
    base.PreScript();
            if (this._NuclearMedicine.NuclearMedicineTests.Count > 0)
            {
                if (this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject != null)
                {
                    nucMedSelectedTesttxt.Text = this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name;
                }
            }

            InjectedBy.SelectedObject = Common.CurrentUser.UserObject;
            if (this._NuclearMedicine.Episode.Patient.ImportantMedicalInformation == null)
            {
                this.IsPregnant.Value = false;
            }

            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs[typeof(NucMedTreatmentMat).Name], (ITTGridColumn)this.GridNuclearMedicineMaterial.Columns["Material"]);
            //this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs[typeof(NucMedRadPharmMatGrid).Name], (ITTGridColumn)this.GridRadPharmMaterials.Columns["PharmMaterial"]);
#endregion NuclearMedicineRadioPharmacyForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region NuclearMedicineRadioPharmacyForm_PostScript
    base.PostScript(transDef);
           if(transDef != null)
            if (/*transDef.ToStateDefID == NuclearMedicine.States.Rejected ||*/ transDef.ToStateDefID == NuclearMedicine.States.Cancelled)
                return;

            if (String.IsNullOrEmpty(this._NuclearMedicine.NuclearMedicineTests[0].AccessionNo))
            {
                Guid AccessionNumber = new Guid("a40495b0-9265-432c-9467-f2b14f3b020c");
                this._NuclearMedicine.NuclearMedicineTests[0].AccessionNo = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[AccessionNumber], null, null).ToString();
            }


            #endregion NuclearMedicineRadioPharmacyForm_PostScript

        }
            
#region NuclearMedicineRadioPharmacyForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            TTMessage ttMessage = null;
            if (transDef.ToStateDefID == NuclearMedicine.States.Procedure)
            {
              
                    string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
                    if (sysparam == "TRUE")
                    {
                        try
                        {
                            Patient.SendPatientToPACS(this._NuclearMedicine.Episode.Patient);
                        }
                        catch (Exception ex)
                        {
                            String message = SystemMessage.GetMessage(200);
                            throw new TTUtils.TTException(message);
                        }

                        List<Guid> appIDs = new List<Guid>();
                        foreach (NuclearMedicineTest test in this._NuclearMedicine.NuclearMedicineTests)
                        {
                            appIDs.Add(test.ObjectID);
                        }
                        //if(this._NuclearMedicine.NuclearMedicineTests.Count > 0)
                        //    appIDs.Add(this._NuclearMedicine.NuclearMedicineTests[0].ObjectID);
                        try
                        {
                            //ttMessage = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.MediumPriority, "InternalTcpClient", "HL7Remoting", "SendHospitalMessageToEngine", null, appIDs, "O01", "PACS");
                        }
                        catch (Exception ex)
                        {
                            TTObjectContext newContext = new TTObjectContext(false);
                            TTObject nuclearMedicineObject = newContext.GetObject(this._NuclearMedicine.ObjectID, "NuclearMedicine");
                            NuclearMedicine nuclearMedicine = nuclearMedicineObject as NuclearMedicine;
                            //nuclearMedicine.IsMessageInPACS = false;
                            newContext.Save();
                            String message = SystemMessage.GetMessage(200);
                            throw new TTUtils.TTException(message);
                            //throw ex;
                        }
                    }
                
            }
        }
        
#endregion NuclearMedicineRadioPharmacyForm_Methods
    }
}