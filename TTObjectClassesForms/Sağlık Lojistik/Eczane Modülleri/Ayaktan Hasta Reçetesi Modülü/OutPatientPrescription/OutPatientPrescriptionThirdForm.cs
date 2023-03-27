
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
    /// Ayaktan Hasta Reçetesi
    /// </summary>
    public partial class OutPatientPrescriptionThirdForm : OutPatientPrescriptionBaseForm
    {
        override protected void BindControlEvents()
        {
            OutPatientDrugOrders.CellContentClick += new TTGridCellEventDelegate(OutPatientDrugOrders_CellContentClick);
            btnEReceteNoInQuiry.Click += new TTControlEventDelegate(btnEReceteNoInQuiry_Click);
            cmdAddDetail.Click += new TTControlEventDelegate(cmdAddDetail_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            OutPatientDrugOrders.CellContentClick -= new TTGridCellEventDelegate(OutPatientDrugOrders_CellContentClick);
            btnEReceteNoInQuiry.Click -= new TTControlEventDelegate(btnEReceteNoInQuiry_Click);
            cmdAddDetail.Click -= new TTControlEventDelegate(cmdAddDetail_Click);
            base.UnBindControlEvents();
        }

        private void OutPatientDrugOrders_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region OutPatientPrescriptionThirdForm_OutPatientDrugOrders_CellContentClick
   if (OutPatientDrugOrders.CurrentCell.OwningColumn.Name == "cmdSelectBarcodeLevel")
            {
                if (OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value != null)
                {
                    DrugDefinition drugDefinition = (DrugDefinition)_OutPatientPrescription.ObjectContext.GetObject(new Guid(OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value.ToString()), "DRUGDEFINITION");
                    MultiSelectForm multiSelectForm = new MultiSelectForm();
                    foreach (MaterialBarcodeLevel barcodeLevel in drugDefinition.MaterialBarcodeLevels)
                    {
                        multiSelectForm.AddMSItem(barcodeLevel.Name.ToString(), barcodeLevel.Name.ToString(), barcodeLevel);
                    }
                    string key = multiSelectForm.GetMSItem(ParentForm, "İlaç Formunu Seçiniz");
                    if (!string.IsNullOrEmpty(key))
                    {
                        OutPatientDrugOrders.Rows[rowIndex].Cells["BarcodeLevel"].Value = ((MaterialBarcodeLevel)multiSelectForm.MSSelectedItemObject).Name.ToString();
                    }
                }
            }
#endregion OutPatientPrescriptionThirdForm_OutPatientDrugOrders_CellContentClick
        }

        private void btnEReceteNoInQuiry_Click()
        {
#region OutPatientPrescriptionThirdForm_btnEReceteNoInQuiry_Click
   //            Prescription.OutPatientPrescriptionWebCaller callerObject = new Prescription.OutPatientPrescriptionWebCaller();
            //            callerObject.ObjectID=_OutPatientPrescription.ObjectID;
            //            
            //            TTMessage response = EReceteIslemleri.RemoteMethods.ereceteSorgula(Sites.SiteLocalHost, Prescription.GetEreceteInQuiry(_OutPatientPrescription),callerObject);
            //            if (response != null)
            //            {
            //                if (((EReceteIslemleri.EreceteSorguCevapDVO)response.ReturnValue).sonucKodu.Equals("0000"))
            //                {
            //                    InfoBox.Show("e-Reçete Numarası : " + ((EReceteIslemleri.EreceteSorguCevapDVO)response.ReturnValue).ereceteDVO.ereceteNo + " olan Reçete e-Reçete Sisteminde Kayıtlıdır");
            //                }                
            //                else
            //                {
            //                    if(!string.IsNullOrEmpty(((EReceteIslemleri.EreceteSorguCevapDVO)response.ReturnValue).uyariMesaji))
            //                    {
            //                        InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + ((EReceteIslemleri.EreceteSorguCevapDVO)response.ReturnValue).sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + ((EReceteIslemleri.EreceteSorguCevapDVO)response.ReturnValue).uyariMesaji);
            //                    }
            //                    else
            //                    {
            //                         InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + ((EReceteIslemleri.EreceteSorguCevapDVO)response.ReturnValue).sonucMesaji );
            //                    }                  
            //                   
            //                    
            //                }
            //            }
#endregion OutPatientPrescriptionThirdForm_btnEReceteNoInQuiry_Click
        }

        private void cmdAddDetail_Click()
        {
#region OutPatientPrescriptionThirdForm_cmdAddDetail_Click
   if (string.IsNullOrEmpty(_OutPatientPrescription.EReceteNo) == false)
            {
                ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                if (currentUser.UniqueNo.Equals(_OutPatientPrescription.ProcedureDoctor.UniqueNo))
                {
                    TTVisual.TTForm eReceteDetailForm = new TTFormClasses.OutPatientPresDetailForm();
                    eReceteDetailForm.ShowEdit(this, _OutPatientPrescription, true);
                }
                else
                {
                    InfoBox.Show("E-Reçete sizin adınıza alınmamış. Bu nedenle detay ekleyemezsiniz.", MessageIconEnum.ErrorMessage);
                }
            }
            else
                InfoBox.Show("Reçete E Reçete'ye yollanmamış. Bu nedenle detay ekleyemezsiniz.", MessageIconEnum.ErrorMessage);
#endregion OutPatientPrescriptionThirdForm_cmdAddDetail_Click
        }

        protected override void PreScript()
        {
#region OutPatientPrescriptionThirdForm_PreScript
    base.PreScript();

            Dictionary<Guid, string> diagForPres = new Dictionary<Guid, string>();
            foreach (DiagnosisGrid diag in _OutPatientPrescription.Episode.Diagnosis)
            {
                if (diagForPres.ContainsKey(diag.Diagnose.ObjectID) == false)
                {
                    DiagnosisForPresc diagForPresc = new DiagnosisForPresc(_OutPatientPrescription.ObjectContext);
                    diagForPresc.Code = diag.Diagnose.Code;
                    diagForPresc.Name = diag.Diagnose.Name.ToString();
                    _OutPatientPrescription.SPTSDiagnosises.Add(diagForPresc);
                    diagForPres.Add(diag.Diagnose.ObjectID, diag.Diagnose.Code);
                }
            }

            if (string.IsNullOrEmpty(_OutPatientPrescription.EReceteNo))
                this.DropStateButton(OutPatientPrescription.States.Request);

            if (this.OutPatientDrugOrders.Rows.Count > 0)
            {
                for (int i = 0; i < this.OutPatientDrugOrders.Rows.Count; i++)
                {
                    if (this.OutPatientDrugOrders.Rows[i].Cells["PROVISIONDETAIL"].Value != null)
                    {
                        if (Convert.ToBoolean(this.OutPatientDrugOrders.Rows[i].Cells["PROVISIONRESULT"].Value))
                        {
                            ((TTGrid)this.OutPatientDrugOrders).Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                        }
                        else
                        {
                            ((TTGrid)this.OutPatientDrugOrders).Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        ((TTGrid)this.OutPatientDrugOrders).Rows[i].Cells["RECEIVEDPRICE"].ReadOnly = false;
                    }
                }
            }
#endregion OutPatientPrescriptionThirdForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region OutPatientPrescriptionThirdForm_PostScript
    base.PostScript(transDef);
            //    BindingList<OutPatientPrescription> pres = OutPatientPrescription.GetReceiptNoNQL(_OutPatientPrescription.ObjectContext, _OutPatientPrescription.ReceiptNO.ToString());
            //    if (pres.Count > 1)
            //    {
            //        throw new TTException("Bu Makbuz Numarası ile daha önce reçete karşılanmıştır.");
            //    }
#endregion OutPatientPrescriptionThirdForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region OutPatientPrescriptionThirdForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);

            if (transDef != null )
            {
                if (transDef.FromStateDefID == OutPatientPrescription.States.CompletedWithSign && transDef.ToStateDefID == OutPatientPrescription.States.Cancelled)
                    _OutPatientPrescription.CancelStockPrescriptionOut(this._OutPatientPrescription);

                if ( transDef.FromStateDefID == OutPatientPrescription.States.Completed && transDef.ToStateDefID == OutPatientPrescription.States.Cancelled)
                    _OutPatientPrescription.CancelStockPrescriptionOut(this._OutPatientPrescription);

                
                if (transDef.FromStateDefID == OutPatientPrescription.States.CompletedWithSign && (transDef.ToStateDefID == OutPatientPrescription.States.Cancelled ||transDef.ToStateDefID == OutPatientPrescription.States.Request))
                    CancelERecete();
            }
#endregion OutPatientPrescriptionThirdForm_ClientSidePostScript

        }

#region OutPatientPrescriptionThirdForm_ClientSideMethods
        public void CancelERecete()
        {
            if (string.IsNullOrEmpty(_OutPatientPrescription.EReceteNo) == false)
            {
                Prescription.OutPatientPrescriptionWebCaller callerObject = new Prescription.OutPatientPrescriptionWebCaller();
                callerObject.ObjectID = _OutPatientPrescription.ObjectID;

                if (string.IsNullOrEmpty(_OutPatientPrescription.ERecetePassword))
                    throw new TTException("E reçete şirfeniz girilmemiş");

                TTObjectClasses.EReceteIslemleri.ereceteSilIstekDVO silIstekDvo = Prescription.GetEReceteDelete(_OutPatientPrescription);
                string imzalanacakXml = Common.SerializeObjectToXml(silIstekDvo);
                imzalanacakXml = imzalanacakXml.Replace("ereceteSilIstekDVO", "imzaliEreceteSilBilgisi");
                byte[] signedContent = CommonForm.SignContent(imzalanacakXml);
                if (signedContent == null)
                    throw new TTException("E-reçete iptal içeriği imzalanamadı");

                TTObjectClasses.EReceteIslemleri.imzaliEreceteSilIstekDVO imzaliEreceteSilIstek = new TTObjectClasses.EReceteIslemleri.imzaliEreceteSilIstekDVO();
                imzaliEreceteSilIstek.doktorTcKimlikNo = silIstekDvo.doktorTcKimlikNo.ToString();
                imzaliEreceteSilIstek.imzaliEreceteSil = signedContent;
                imzaliEreceteSilIstek.tesisKodu = silIstekDvo.tesisKodu.ToString();
                imzaliEreceteSilIstek.surumNumarasi = "1";

                EReceteIslemleri.imzaliEreceteSilCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteSilSync(Sites.SiteLocalHost, _OutPatientPrescription.ProcedureDoctor.UniqueNo.ToString(), _OutPatientPrescription.ERecetePassword.ToString(), imzaliEreceteSilIstek);
                if (response != null)
                {
                    if (response.sonucKodu.Equals("0000"))
                    {
                        InfoBox.Alert("E reçete başarıyla iptal edilmiştir.");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(response.uyariMesaji))
                            throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
                        else
                            throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                    }
                }
            }
        }
        
#endregion OutPatientPrescriptionThirdForm_ClientSideMethods
    }
}