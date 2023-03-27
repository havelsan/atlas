
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Ayaktan Hasta Reçetesi
    /// </summary>
    public partial class OutPatientPrescription : Prescription, IWorkListEpisodeAction, ICreatePrescriptionStockOut
    {
        public partial class GetOutPatientDrugPrescriptionTotalReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetOutpatientPrescriptionReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetOutPatientPrescriptionByObjectIDs_Class : TTReportNqlObject
        {
        }

        public partial class GetDetailOutPresciprtionReportQuery_Class : TTReportNqlObject
        {
        }

        protected override void PreInsert()
        {
            #region PreInsert




            base.PreInsert();
            if (Episode.PatientStatus == PatientStatusEnum.Outpatient || Episode.PatientStatus == PatientStatusEnum.Discharge)
            {
                foreach (OutPatientDrugOrder drugOrder in OutPatientDrugOrders)
                {
                    drugOrder.Store = MasterResource.Store;
                }

            }
            //else
            //{
            //    bool isDıschargeApp = true;
            //    foreach (InPatientTreatmentClinicApplication app in this.Episode.InPatientTreatmentClinicApplications)
            //    {
            //        foreach (InPatientPhysicianApplication pApp in app.InPatientPhysicianApplication)
            //        {
            //            if (pApp.CurrentStateDefID == InPatientPhysicianApplication.States.Application )
            //            {
            //                isDıschargeApp = false;
            //            }
            //        }
            //    }
            //    if( isDıschargeApp == false)
            //        throw new Exception("Hastanın taburcu işlemi başlatılmadığı için taburcu reçetesi yazamazsınız.");
            //}













            #endregion PreInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            if (CurrentStateDefID == OutPatientPrescription.States.Completed || CurrentStateDefID == OutPatientPrescription.States.CompletedWithSign)
            {
                SendENabizPresciptionForCancelled();
                // if (this.SubEpisode != null && this.SendToENabiz())
                //   new SendToENabiz(this.ObjectContext, this.SubEpisode, this.SubEpisode.ObjectID, this.SubEpisode.ObjectDef.Name, "103", Common.RecTime());
            }
            #endregion PostUpdate
        }

        protected void PreTransition_DrugPayables2Cancelled()
        {
            // From State : DrugPayables   To State : Cancelled
            #region PreTransition_DrugPayables2Cancelled

            NoStepBackPrescription(this);

            #endregion PreTransition_DrugPayables2Cancelled
        }

        protected void PreTransition_DrugPayables2Completed()
        {
            // From State : DrugPayables   To State : Completed
            #region PreTransition_DrugPayables2Completed














            BindingList<PharmacyStoreDefinition> outPatientPharmacy = PharmacyStoreDefinition.GetOutpatientPharmacyStore(ObjectContext);
            foreach (OutPatientDrugOrder drugOrder in OutPatientDrugOrders)
            {
                if (drugOrder.DrugSupply == OutPatientDrugSupplyEnum.Supply)
                {
                    //if (drugOrder.Material.ExistingInheld(outPatientPharmacy[0]))
                    //{
                    if (drugOrder.Material.IsOldMaterial == false)
                    {
                        if (drugOrder.Material is DrugDefinition)
                        {
                            SubActionMatPricingDet subActionMatPricingDet = new SubActionMatPricingDet(ObjectContext);
                            subActionMatPricingDet.Amount = drugOrder.PackageAmount;
                            subActionMatPricingDet.Description = drugOrder.Material.Name.ToString();
                            subActionMatPricingDet.ExternalCode = drugOrder.Material.Barcode.ToString();
                            if (drugOrder.ReceivedPrice == null)
                            {
                                subActionMatPricingDet.PatientPrice = 0;
                            }
                            else
                            {
                                subActionMatPricingDet.PatientPrice = drugOrder.ReceivedPrice;
                            }
                            //subActionMatPricingDet.PatientPrice = 0; // Hasta payı hiç oluşmayacak. SS.
                            subActionMatPricingDet.PayerPrice = drugOrder.Material.CurrentPrice - subActionMatPricingDet.PatientPrice;
                            subActionMatPricingDet.SubActionMaterial = drugOrder;
                        }
                        else
                        {
                            SubActionMatPricingDet subActionMatPricingDet = new SubActionMatPricingDet(ObjectContext);
                            subActionMatPricingDet.Amount = drugOrder.Amount;
                            subActionMatPricingDet.Description = drugOrder.Material.Name;
                            subActionMatPricingDet.ExternalCode = drugOrder.Material.Name;
                            subActionMatPricingDet.PatientPrice = 0;
                            subActionMatPricingDet.PayerPrice = drugOrder.MagistralPreparationAction.TotalPrice;
                            subActionMatPricingDet.SubActionMaterial = drugOrder;

                        }
                    }
                    drugOrder.CurrentStateDefID = OutPatientDrugOrder.States.Completed;
                }
                else
                {
                    drugOrder.CurrentStateDefID = OutPatientDrugOrder.States.UnCompleted;
                }

            }











            #endregion PreTransition_DrugPayables2Completed
        }

        protected void UndoTransition_DrugPayables2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : DrugPayables   To State : Completed
            #region UndoTransition_DrugPayables2Completed
            NoBackStateBack();
            #endregion UndoTransition_DrugPayables2Completed
        }

        protected void PreTransition_ExternalPharmacySupply2DrugPayables()
        {
            // From State : ExternalPharmacySupply   To State : DrugPayables
            #region PreTransition_ExternalPharmacySupply2DrugPayables













            if (ExternalPharmacy == null)
            {
                throw new Exception(SystemMessage.GetMessage(1205));
            }











            #endregion PreTransition_ExternalPharmacySupply2DrugPayables
        }

        protected void PreTransition_ExternalPharmacySupply2ProvisionTake()
        {
            // From State : ExternalPharmacySupply   To State : ProvisionTake
            #region PreTransition_ExternalPharmacySupply2ProvisionTake





            if (ExternalPharmacy == null)
            {
                throw new Exception(SystemMessage.GetMessage(1205));
            }

            bool sendProvision = false;
            foreach (OutPatientDrugOrder drugOrder in OutPatientDrugOrders)
            {
                if (drugOrder.Material is MagistralPreparationDefinition == false)
                {
                    if (drugOrder.DrugSupply == OutPatientDrugSupplyEnum.Supply)
                    {
                        sendProvision = true;
                        break;
                    }
                }
            }
            if (sendProvision)
            {
                if (FreeDiagnosis == null && SPTSDiagnosises.Count == 0)
                {
                    throw new Exception(SystemMessage.GetMessage(1206));
                }
                else
                {
                    //XXXXXXSptsClasses.ReceteInfo receteInfo = ((XXXXXXSptsClasses.ReceteInfo)Prescription.GetReceteInfo(this));
                    //TTMessage message = TTMessageFactory.ASyncCall(Sites.SiteMerkezSPTS, TTMessagePriorityEnum.HighPriority, "XXXXXXDLL", "XXXXXXDLL", "ReceteGiris", null, receteInfo);
                    //this.SPTSMessageID = message.MessageID;
                }
            }
            else
            {
                throw new TTException(SystemMessage.GetMessage(1207));
            }




            #endregion PreTransition_ExternalPharmacySupply2ProvisionTake
        }

        protected void PreTransition_ProvisionTake2DrugControl()
        {
            // From State : ProvisionTake   To State : DrugControl
            #region PreTransition_ProvisionTake2DrugControl















            //XXXXXXSptsClasses.ProvReturn message = (XXXXXXSptsClasses.ProvReturn)TTMessageFactory.SyncCall(Sites.SiteMerkezSPTS, "XXXXXXDLL", "XXXXXXDLL", "ReceteIptal", this.SPTSProvisionID.ToString());
            //if (message.sonuckodu == -1)
            //{
            //    throw new TTException(message.SonucAcıklaması.ToString());
            //}
            //else
            //{
            //    foreach (OutPatientDrugOrder drugOrder in this.OutPatientDrugOrders)
            //    {
            //        drugOrder.SPTSProvisionResult = false;
            //        drugOrder.SPTSProvisionDetail = "";
            //    }
            //    this.SPTSProvisionDesc = "";

            //   InfoBox.Alert(message.SonucAcıklaması.ToString(), MessageIconEnum.InformationMessage);
            //}












            #endregion PreTransition_ProvisionTake2DrugControl
        }

        protected void PreTransition_Request2DrugControl()
        {
            // From State : Request   To State : DrugControl
            #region PreTransition_Request2DrugControl


            string patientSafetyForm = string.Empty;
            bool control = false;
            foreach (OutPatientDrugOrder drugOrder in OutPatientDrugOrders)
            {
                if (drugOrder.RequiredAmount == null)
                {
                    double i = (int)DrugOrder.GetDetailCount(drugOrder.Frequency) * (double)drugOrder.DoseAmount;
                    drugOrder.RequiredAmount = 1 + Math.Round(i / (double)drugOrder.Material.PackageAmount);
                }

                if (((DrugDefinition)drugOrder.Material).PatientSafetyFrom.HasValue && (bool)((DrugDefinition)drugOrder.Material).PatientSafetyFrom)
                {
                    if (drugOrder.DescriptionType != DescriptionTypeEnum.PatientSafetyAndMonitoringFormDescription || string.IsNullOrEmpty(drugOrder.Description))
                    {
                        control = true;
                        patientSafetyForm = patientSafetyForm + drugOrder.Material.Name + "\n";
                    }
                }
            }

            if (control)
                throw new TTException(TTUtils.CultureService.GetText("M25193", "Aşagıdaki İlaç(ların) Hasta Güvenlik ve İzleme Formu bilgilerini girmelisiniz !\n") + patientSafetyForm);


            #endregion PreTransition_Request2DrugControl
        }

        protected void PostTransition_Request2DrugControl()
        {
            // From State : Request   To State : DrugControl
            #region PostTransition_Request2DrugControl








            if (TTObjectClasses.SystemParameter.IsDigitalSignatureIntegration)
            {
                ResUser resUser = TTUser.CurrentUser.UserObject as ResUser;
                if (resUser == null)
                    throw new TTException(SystemMessage.GetMessage(1208));

                Prescription.DigitalSignedPrescription digitalSignedPrescription = new Prescription.DigitalSignedPrescription(resUser, this);
                SignedData = TTUtils.SerializationHelper.SerializeObject(digitalSignedPrescription);
            }






            #endregion PostTransition_Request2DrugControl
        }

        protected void PreTransition_Request2Completed()
        {
            // From State : Request   To State : Completed
            #region PreTransition_Request2Completed

            /*
            string noBarcode = string.Empty;
            string patientSafetyForm = string.Empty;
            bool control = false;
            foreach (OutPatientDrugOrder drugOrder in this.OutPatientDrugOrders)
            {
                if (drugOrder.Material.Barcode == null)
                {
                    control = true;
                    noBarcode = noBarcode + drugOrder.Material.Name + "\n";
                }
                if (((DrugDefinition)drugOrder.Material).PatientSafetyFrom.HasValue && (bool)((DrugDefinition)drugOrder.Material).PatientSafetyFrom)
                {
                    if (drugOrder.DescriptionType != DescriptionTypeEnum.PatientSafetyAndMonitoringFormDescription || string.IsNullOrEmpty(drugOrder.Description))
                    {
                        control = true;
                        patientSafetyForm = patientSafetyForm + drugOrder.Material.Name + "\n";
                    }
                }
            }

            if (control)
            {
                if (string.IsNullOrEmpty(noBarcode))
                    throw new TTException("Barkodu Olmayan İlaçlar Yazılamaz !\n" + noBarcode);
                if (string.IsNullOrEmpty(patientSafetyForm))
                    throw new TTException("Aşagıdaki İlaç(ların) Hasta Güvenlik ve İzleme Formu bilgilerini girmelisiniz !\n" + patientSafetyForm);
            }

            if (this.EReceteNo == null)
            {
                if (this.SubEpisode.IsSGK)
                {
                    if (this.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this.SubEpisode.SGKSEP.MedulaTakipNo))
                    {
                        Prescription.OutPatientPrescriptionWebCaller callerObject = new Prescription.OutPatientPrescriptionWebCaller();
                        callerObject.ObjectID = this.ObjectID;

                        if (string.IsNullOrEmpty(this.ERecetePassword))
                            throw new TTException("E Reçete şifrenizi giriniz");

                        EReceteIslemleri.ereceteGirisCevapDVO response = EReceteIslemleri.WebMethods.ereceteGirisSynCall(Sites.SiteLocalHost, Common.CurrentResource.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEReceteInputRequest(this));
                        if (response != null)
                        {
                            if (response.sonucKodu.Equals("0000"))
                            {
                                InfoBox.Alert(response.ereceteDVO.ereceteNo.ToString() + " e reçete numarası ile reçete kaydedilmiştir.", MessageIconEnum.InformationMessage);
                                this.EReceteNo = response.ereceteDVO.ereceteNo;
                                this.EReceteDescription = " E Reçete başarılı bir şekilde kaydedilmiştir.";

                                if (this.SubEpisode.SGKSEP.MedulaTedaviTuru.tedaviTuruAdi == "Günübirlik Tedavi")
                                {
                                    ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                                    SendEreceteDailyPresApproval(currentUser);
                                }


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
                    else
                        throw new TTException("Hastaya Medula Provizyon Alınmadığında Dolayı e-Reçete Kaydı Yapılamamıştır.");
                }
            }*/


            #endregion PreTransition_Request2Completed
        }

        protected void PostTransition_Request2Completed()
        {
            // From State : Request   To State : Completed
            #region PostTransition_Request2Completed



            try
            {
                if (IsRepeated.HasValue)
                {
                    if ((bool)IsRepeated)
                    {
                        ResUser user = (ResUser)ObjectContext.GetObject(Common.CurrentResource.ObjectID, typeof(ResUser));
                        user.ErecetePassword = ERecetePassword;
                    }
                }
            }
            catch (Exception ex)
            {
                TTUtils.InfoMessageService.Instance.ShowMessage(ex.ToString());
            }


            #endregion PostTransition_Request2Completed
        }

        protected void UndoTransition_Request2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Request   To State : Completed
            #region UndoTransition_Request2Completed
            NoBackStateBack();
            #endregion UndoTransition_Request2Completed
        }

        protected void PreTransition_Request2CompletedWithSign()
        {
            // From State : Request   To State : CompletedWithSign
            #region PreTransition_Request2CompletedWithSign




            //
            string noBarcode = string.Empty;
            string patientSafetyForm = string.Empty;
            bool control = false;
            foreach (OutPatientDrugOrder drugOrder in OutPatientDrugOrders)
            {
                if (drugOrder.Material.Barcode == null)
                {
                    control = true;
                    noBarcode = noBarcode + drugOrder.Material.Name + "\n";
                }
                if (((DrugDefinition)drugOrder.Material).PatientSafetyFrom.HasValue && (bool)((DrugDefinition)drugOrder.Material).PatientSafetyFrom)
                {
                    if (drugOrder.DescriptionType != DescriptionTypeEnum.PatientSafetyAndMonitoringFormDescription || string.IsNullOrEmpty(drugOrder.Description))
                    {
                        control = true;
                        patientSafetyForm = patientSafetyForm + drugOrder.Material.Name + "\n";
                    }
                }
            }

            if (control)
            {
                if (string.IsNullOrEmpty(noBarcode))
                    throw new TTException(TTUtils.CultureService.GetText("M25240", "Barkodu Olmayan İlaçlar Yazılamaz !\n") + noBarcode);
                if (string.IsNullOrEmpty(patientSafetyForm))
                    throw new TTException(TTUtils.CultureService.GetText("M25193", "Aşagıdaki İlaç(ların) Hasta Güvenlik ve İzleme Formu bilgilerini girmelisiniz !\n") + patientSafetyForm);
            }

            if (SubEpisode.IsSGK && EReceteNo == null)
            {
                if (SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(SubEpisode.SGKSEP.MedulaTakipNo))
                {
                    Prescription.OutPatientPrescriptionWebCaller callerObject = new Prescription.OutPatientPrescriptionWebCaller();
                    callerObject.ObjectID = ObjectID;
                }
            }


            #endregion PreTransition_Request2CompletedWithSign
        }

        protected void PostTransition_Request2CompletedWithSign()
        {
            // From State : Request   To State : CompletedWithSign
            #region PostTransition_Request2CompletedWithSign

            //
            try
            {
                if (IsRepeated.HasValue)
                {
                    if ((bool)IsRepeated)
                    {
                        ResUser user = (ResUser)ObjectContext.GetObject(Common.CurrentResource.ObjectID, typeof(ResUser));
                        user.ErecetePassword = ERecetePassword;
                    }
                }
            }
            catch (Exception ex)
            {
                TTUtils.InfoMessageService.Instance.ShowMessage(ex.ToString());

            }

            #endregion PostTransition_Request2CompletedWithSign
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled
            try
            {
                if (EReceteNo != null)
                {
                    SendENabizPresciptionForCancelled();
                }
            }
            catch (Exception ex)
            {
                TTUtils.InfoMessageService.Instance.ShowMessage(ex.ToString());
            }

            #endregion PostTransition_Completed2Cancelled
        }


        protected void UndoTransition_Request2CompletedWithSign(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Request   To State : CompletedWithSign
            #region UndoTransition_Request2CompletedWithSign

            //
            NoBackStateBack();

            #endregion UndoTransition_Request2CompletedWithSign
        }

        protected void PreTransition_Completed2Request()
        {
            // From State : Completed   To State : Request
            #region PreTransition_Completed2Request

            NoStepBackPrescription(this);

            Prescription.OutPatientPrescriptionWebCaller callerObject = new Prescription.OutPatientPrescriptionWebCaller();
            callerObject.ObjectID = ObjectID;

            if (string.IsNullOrEmpty(ERecetePassword))
                throw new TTException("E reçete şirfeniz girilmemiş");

            if (string.IsNullOrEmpty(EReceteNo) == false)
            {   //EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost,this.ProcedureDoctor.Person.UniqueRefNo.ToString() ,this.ERecetePassword.ToString(), callerObject, Prescription.GetEReceteDelete(this));
                EReceteIslemleri.ereceteSilCevapDVO response = EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, ProcedureDoctor.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEReceteDelete(this));
                if (response != null)
                {
                    if (response.sonucKodu.Equals("0000"))
                    {
                        TTUtils.InfoMessageService.Instance.ShowMessage("E reçete başarıyla iptal edilmiştir.");
                        EReceteNo = null;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(response.uyariMesaji))
                            throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :") + response.uyariMesaji);
                        else
                            throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                    }
                }
            }

            #endregion PreTransition_Completed2Request
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancelled


            //this.CancelStockPrescriptionOut(this);


            if (string.IsNullOrEmpty(EReceteNo) == false)
            {
                Prescription.OutPatientPrescriptionWebCaller callerObject = new Prescription.OutPatientPrescriptionWebCaller();
                callerObject.ObjectID = ObjectID;

                if (string.IsNullOrEmpty(ERecetePassword))
                    throw new TTException("E reçete şirfeniz girilmemiş");

                //EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost,this.ProcedureDoctor.Person.UniqueRefNo.ToString() ,this.ERecetePassword.ToString(), callerObject, Prescription.GetEReceteDelete(this));
                EReceteIslemleri.ereceteSilCevapDVO response = EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, ProcedureDoctor.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEReceteDelete(this));
                if (response != null)
                {
                    if (response.sonucKodu.Equals("0000"))
                    {
                        TTUtils.InfoMessageService.Instance.ShowMessage("E reçete başarıyla iptal edilmiştir.");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(response.uyariMesaji))
                            throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :") + response.uyariMesaji);
                        else
                            throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                    }
                }
            }

            foreach (OutPatientDrugOrder outPatientDrugOrder in OutPatientDrugOrders)
            {
                if (outPatientDrugOrder.StockActionDetail != null)
                {
                    StockOut stockOut = (StockOut)outPatientDrugOrder.StockActionDetail.StockAction;
                    if (stockOut.CurrentStateDefID == StockOut.States.Completed)
                    {
                        stockOut.CurrentStateDefID = StockOut.States.Cancelled;
                        outPatientDrugOrder.CurrentStateDefID = OutPatientDrugOrder.States.Cancelled;
                    }
                    else
                    {
                        throw new TTException(SystemMessage.GetMessage(1209));
                    }
                }
            }

            #endregion PreTransition_Completed2Cancelled
        }

        protected void PreTransition_DrugControl2DrugPayables()
        {
            // From State : DrugControl   To State : DrugPayables
            #region PreTransition_DrugControl2DrugPayables





            foreach (OutPatientDrugOrder outPatientDrugOrder in OutPatientDrugOrders)
            {
                if (outPatientDrugOrder.DrugSupply == OutPatientDrugSupplyEnum.Distribute)
                    throw new TTException(SystemMessage.GetMessage(1210));
            }



            #endregion PreTransition_DrugControl2DrugPayables
        }

        protected void PreTransition_DrugControl2ExternalPharmacySupply()
        {
            // From State : DrugControl   To State : ExternalPharmacySupply
            #region PreTransition_DrugControl2ExternalPharmacySupply



            bool distribute = false;
            foreach (OutPatientDrugOrder drugOrder in OutPatientDrugOrders)
            {
                if (drugOrder.DrugSupply == OutPatientDrugSupplyEnum.Distribute)
                {
                    distribute = true;
                    break;
                }
            }
            if (distribute == false)
            {
                throw new TTException(SystemMessage.GetMessage(1211));
            }




            #endregion PreTransition_DrugControl2ExternalPharmacySupply
        }

        protected void PostTransition_DrugControl2ExternalPharmacySupply()
        {
            // From State : DrugControl   To State : ExternalPharmacySupply
            #region PostTransition_DrugControl2ExternalPharmacySupply


            double totalPrice = 0;
            foreach (OutPatientDrugOrder drugOrder in OutPatientDrugOrders)
            {
                if (drugOrder.PackageAmount != null)
                {
                    if (drugOrder.DrugSupply == OutPatientDrugSupplyEnum.Distribute)
                    {
                        totalPrice += (double)drugOrder.Material.CurrentPrice;
                    }
                }
            }
            PrescriptionPrice = totalPrice;




            #endregion PostTransition_DrugControl2ExternalPharmacySupply
        }

        protected void PreTransition_DrugControl2ProvisionTake()
        {
            // From State : DrugControl   To State : ProvisionTake
            #region PreTransition_DrugControl2ProvisionTake











            bool sendProvision = false;
            bool outPharmacySend = false;
            foreach (OutPatientDrugOrder drugOrder in OutPatientDrugOrders)
            {
                if (drugOrder.Material is MagistralPreparationDefinition == false)
                {
                    if (drugOrder.DrugSupply == OutPatientDrugSupplyEnum.Supply)
                    {
                        sendProvision = true;
                    }
                    else if (drugOrder.DrugSupply == OutPatientDrugSupplyEnum.Distribute)
                    {
                        outPharmacySend = true;
                    }
                }
            }

            if (outPharmacySend == false)
            {
                if (sendProvision)
                {
                    if (FreeDiagnosis == null && SPTSDiagnosises.Count == 0)
                    {
                        throw new Exception(SystemMessage.GetMessage(1206));
                    }
                    else
                    {
                        //XXXXXXSptsClasses.ReceteInfo receteInfo = ((XXXXXXSptsClasses.ReceteInfo)Prescription.GetReceteInfo(this));
                        //TTMessage message = TTMessageFactory.ASyncCall(Sites.SiteMerkezSPTS, TTMessagePriorityEnum.HighPriority, "XXXXXXDLL", "XXXXXXDLL", "ReceteGiris", null, receteInfo);
                        //this.SPTSMessageID = message.MessageID;
                    }
                }

                //if (outPharmacySend)
                //{
                //    if (this.SendOutPharmacy != true)
                //    {
                //        if (this.FreeDiagnosis == null && this.SPTSDiagnosises.Count == 0)
                //        {
                //            throw new Exception("Tanı olmadan provizyon alamazsınız.");
                //        }
                //        else
                //        {
                //            XXXXXXSptsClasses.ReceteInfo receteInfo = ((XXXXXXSptsClasses.ReceteInfo)Prescription.GetDısReceteInfo(this));
                //            TTMessage message = TTMessageFactory.ASyncCall(Sites.SiteMerkezSPTS, TTMessagePriorityEnum.HighPriority, "XXXXXXDLL", "XXXXXXDLL", "DisReceteGiris", receteInfo);
                //            this.SendOutPharmacy = true;
                //        }
                //    }
                //}

            }
            else
            {
                throw new TTException(SystemMessage.GetMessage(1212));
            }










            #endregion PreTransition_DrugControl2ProvisionTake
        }

        protected void PreTransition_DrugControl2Request()
        {
            // From State : DrugControl   To State : Request
            #region PreTransition_DrugControl2Request



            NoStepBackPrescription(this);

            foreach (OutPatientDrugOrder drugOrder in OutPatientDrugOrders)
            {
                if (drugOrder.RequiredAmount != null)
                    drugOrder.RequiredAmount = null;
            }


            #endregion PreTransition_DrugControl2Request
        }

        protected void PreTransition_DrugControl2Completed()
        {
            // From State : DrugControl   To State : Completed
            #region PreTransition_DrugControl2Completed





            foreach (OutPatientDrugOrder drugOrder in OutPatientDrugOrders)
            {
                drugOrder.CurrentStateDefID = OutPatientDrugOrder.States.UnCompleted;
            }

            if (SendOutPharmacy != null)
            {
                if (SendOutPharmacy != true)
                {
                    if (FreeDiagnosis == null && SPTSDiagnosises.Count == 0)
                    {
                        throw new Exception(SystemMessage.GetMessage(1206));
                    }
                    else
                    {
                        //XXXXXXSptsClasses.ReceteInfo receteInfo = ((XXXXXXSptsClasses.ReceteInfo)Prescription.GetDısReceteInfo(this));
                        //TTMessage message = TTMessageFactory.ASyncCall(Sites.SiteMerkezSPTS, TTMessagePriorityEnum.HighPriority, "XXXXXXDLL", "XXXXXXDLL", "DisReceteGiris", null, receteInfo);
                        //this.SendOutPharmacy = true;
                    }
                }
            }





            #endregion PreTransition_DrugControl2Completed
        }

        protected void UndoTransition_DrugControl2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : DrugControl   To State : Completed
            #region UndoTransition_DrugControl2Completed
            NoBackStateBack();
            #endregion UndoTransition_DrugControl2Completed
        }

        protected void PreTransition_DrugControl2Cancelled()
        {
            // From State : DrugControl   To State : Cancelled
            #region PreTransition_DrugControl2Cancelled

            Prescription.OutPatientPrescriptionWebCaller callerObject = new Prescription.OutPatientPrescriptionWebCaller();
            callerObject.ObjectID = ObjectID;

            if (string.IsNullOrEmpty(EReceteNo) == false)
            {
                //EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, this.ProcedureDoctor.Person.UniqueRefNo.ToString(), this.ProcedureDoctor.ErecetePassword.ToString(), callerObject, Prescription.GetEReceteDelete(this));
                EReceteIslemleri.ereceteSilCevapDVO response = EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, ProcedureDoctor.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEReceteDelete(this));
                if (response != null)
                {
                    if (response.sonucKodu.Equals("0000"))
                    {
                        TTUtils.InfoMessageService.Instance.ShowMessage("E reçete başarıyla iptal edilmiştir.");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(response.uyariMesaji))
                            throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :") + response.uyariMesaji);
                        else
                            throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                    }
                }
            }


            #endregion PreTransition_DrugControl2Cancelled
        }

        protected void PreTransition_DrugControl2MagistralPreparation()
        {
            // From State : DrugControl   To State : MagistralPreparation
            #region PreTransition_DrugControl2MagistralPreparation





            foreach (OutPatientDrugOrder drugOrder in _OutPatientDrugOrders)
            {

                MagistralPreparationAction magistralPreparationAction = new MagistralPreparationAction(ObjectContext);

                MagistralPreparationDetail magistralPreparationDetail = new MagistralPreparationDetail(ObjectContext);
                magistralPreparationDetail.MagistralPreparationDef = (MagistralPreparationDefinition)drugOrder.Material;
                magistralPreparationDetail.Amount = drugOrder.Amount;
                magistralPreparationAction.MagistralPreparationDetails.Add(magistralPreparationDetail);

                foreach (MagistralDrugDetail magistralDrugDetail in drugOrder.MagistralDrugDetails)
                {
                    MagistralPreparationUsedDrug magistralPreparationUsedDrug = new MagistralPreparationUsedDrug(ObjectContext);
                    magistralPreparationUsedDrug.DrugDefinition = (DrugDefinition)magistralDrugDetail.Material;
                    magistralPreparationUsedDrug.Amount = magistralDrugDetail.PreparatAmount;
                    magistralPreparationAction.MagistralPreparationUsedDrugs.Add(magistralPreparationUsedDrug);
                }

                foreach (MagistralChemicalDetail magistralChemicalDetail in drugOrder.MagistralChemicalDetails)
                {
                    MagistralPreparationUsedChemical magistralPreparationUsedChemical = new MagistralPreparationUsedChemical(ObjectContext);
                    magistralPreparationUsedChemical.MagistralChemicalDefinition = magistralChemicalDetail.MagistralChemicalDefinition;
                    magistralPreparationUsedChemical.Amount = magistralChemicalDetail.ChemicalAmount;
                    magistralPreparationAction.MagistralPreparationUsedChemicals.Add(magistralPreparationUsedChemical);
                }
                magistralPreparationAction.Store = MasterResource.Store;
                magistralPreparationAction.CurrentStateDefID = MagistralPreparationAction.States.Request;
                drugOrder.MagistralPreparationAction = magistralPreparationAction;
            }





            #endregion PreTransition_DrugControl2MagistralPreparation
        }

        protected void PreTransition_CompletedWithSign2Request()
        {
            // From State : CompletedWithSign   To State : Request
            #region PreTransition_CompletedWithSign2Request


            NoStepBackPrescription(this);

            Prescription.OutPatientPrescriptionWebCaller callerObject = new Prescription.OutPatientPrescriptionWebCaller();
            callerObject.ObjectID = ObjectID;



            #endregion PreTransition_CompletedWithSign2Request
        }

        protected void PreTransition_CompletedWithSign2Cancelled()
        {
            // From State : CompletedWithSign   To State : Cancelled
            #region PreTransition_CompletedWithSign2Cancelled



            // this.CancelStockPrescriptionOut(this);



            foreach (OutPatientDrugOrder outPatientDrugOrder in OutPatientDrugOrders)
            {
                if (outPatientDrugOrder.StockActionDetail != null)
                {
                    StockOut stockOut = (StockOut)outPatientDrugOrder.StockActionDetail.StockAction;
                    if (stockOut.CurrentStateDefID == StockOut.States.Completed)
                    {
                        stockOut.CurrentStateDefID = StockOut.States.Cancelled;
                        outPatientDrugOrder.CurrentStateDefID = OutPatientDrugOrder.States.Cancelled;
                    }
                    else
                    {
                        throw new TTException(SystemMessage.GetMessage(1209));
                    }
                }
            }


            #endregion PreTransition_CompletedWithSign2Cancelled
        }

        #region Methods

        #region ICreatePrescriptionStockOut Members
        public ResSection GetFromResource()
        {
            return FromResource;
        }
        public void SetFromResource(ResSection value)
        {
            FromResource = value;
        }

        public PrescriptionPaper GetPrescriptionPaper()
        {
            return PrescriptionPaper;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }

        public PrescriptionTypeEnum? GetPrescriptionType()
        {
            return PrescriptionType;
        }
        #endregion
        public void AddDrug(Guid DrugID)
        {
            DrugDefinition drug = (DrugDefinition)ObjectContext.GetObject(DrugID, typeof(DrugDefinition));
            OutPatientDrugOrder outPatientDrugOrder = new OutPatientDrugOrder(ObjectContext);
            outPatientDrugOrder.PhysicianDrug = drug;
            outPatientDrugOrder.Material = drug;
            outPatientDrugOrder.OutPatientPrescription = this;
            if (drug.RouteOfAdmin != null && drug.RouteOfAdmin.DrugUsageType != null)
                outPatientDrugOrder.DrugUsageType = drug.RouteOfAdmin.DrugUsageType;
            outPatientDrugOrder.PeriodUnitType = PeriodUnitTypeEnum.DayPeriod;
            outPatientDrugOrder.Day = 1;
            if (drug.Frequency != null)
                outPatientDrugOrder.Frequency = drug.Frequency;
            if (drug.RoutineDose != null)
                outPatientDrugOrder.DoseAmount = drug.RoutineDose;

            //drugOrderIntroductionDet.DrugOrderIntroduction = this;
        }


        public OutPatientPrescription(TTObjectContext objectContext, EpisodeAction episodeAction)
            : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            //Episodeun AfterSetinde  this.InPatientPhysicianApplication==null kontrolü olduğu için SetMandatoryEpisodeActionProperties()kullanılmadı.
            //this.SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientPhysicianApplication,inPatientPhysicianApplication.MasterResource,inPatientPhysicianApplication.MasterResource,false);
            CurrentStateDefID = OutPatientPrescription.States.Request;
            ProcedureSpeciality = episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;
            Episode = episodeAction.Episode;
        }

        public OutPatientPrescription(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable)
            : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = subactionProcedureFlowable.MasterResource;
            FromResource = subactionProcedureFlowable.MasterResource;
            //Episodeun AfterSetinde  this.InPatientPhysicianApplication==null kontrolü olduğu için SetMandatoryEpisodeActionProperties()kullanılmadı.
            //this.SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientPhysicianApplication,inPatientPhysicianApplication.MasterResource,inPatientPhysicianApplication.MasterResource,false);
            CurrentStateDefID = OutPatientPrescription.States.Request;
            ProcedureSpeciality = subactionProcedureFlowable.ProcedureSpeciality;
            MasterAction = subactionProcedureFlowable.EpisodeAction;
            Episode = subactionProcedureFlowable.Episode;
        }

        public override List<SubActionMaterial> GetAccountableSubActionMaterials()
        {

            List<SubActionMaterial> myCol = base.GetAccountableSubActionMaterials();
            foreach (OutPatientDrugOrder drugOrder in OutPatientDrugOrders)
            {
                if (drugOrder.Material.Chargable == true)
                {
                    if (drugOrder.Eligible == true)
                        myCol.Add((SubActionMaterial)drugOrder);
                }
            }
            return myCol;

        }



        public void SendEreceteDailyPresApproval(ResUser currentUser)
        {
            long uniqueNo = (long)Convert.ToDouble(currentUser.UniqueNo);
            //            EReceteIslemleri.ereceteOnayCevapDVO dailyPresOnay = EReceteIslemleri.WebMethods.ereceteOnay(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEreceteDailyPresApprovalRequest(this, uniqueNo));
            //            if (dailyPresOnay != null)
            //            {
            //                if (dailyPresOnay.sonucKodu.Equals("0000"))
            //                {
            //                    InfoBox.Alert(this.EReceteNo.ToString() + " e reçete numarası ile reçete Günübirlik Hasta onayı alınmıştır.", MessageIconEnum.InformationMessage);
            //                    this.EReceteDescription = " E Reçete başarılı bir şekilde Günübirlik Hasta onayı almıştır.";
            //                }
            //                else
            //                {
            //                    if (!string.IsNullOrEmpty(dailyPresOnay.uyariMesaji))
            //                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + dailyPresOnay.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + dailyPresOnay.uyariMesaji);
            //                    else
            //                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + dailyPresOnay.sonucMesaji);
            //                }
            //            }
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(OutPatientPrescription).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == OutPatientPrescription.States.Request && toState == OutPatientPrescription.States.DrugControl)
                PreTransition_Request2DrugControl();
            else if (fromState == OutPatientPrescription.States.Request && toState == OutPatientPrescription.States.Completed)
                PreTransition_Request2Completed();
            else if (fromState == OutPatientPrescription.States.Request && toState == OutPatientPrescription.States.CompletedWithSign)
                PreTransition_Request2CompletedWithSign();
            else if (fromState == OutPatientPrescription.States.Completed && toState == OutPatientPrescription.States.Request)
                PreTransition_Completed2Request();
            else if (fromState == OutPatientPrescription.States.Completed && toState == OutPatientPrescription.States.Cancelled)
                PreTransition_Completed2Cancelled();
            else if (fromState == OutPatientPrescription.States.DrugControl && toState == OutPatientPrescription.States.Request)
                PreTransition_DrugControl2Request();
            else if (fromState == OutPatientPrescription.States.DrugControl && toState == OutPatientPrescription.States.Completed)
                PreTransition_DrugControl2Completed();
            else if (fromState == OutPatientPrescription.States.DrugControl && toState == OutPatientPrescription.States.Cancelled)
                PreTransition_DrugControl2Cancelled();
            else if (fromState == OutPatientPrescription.States.CompletedWithSign && toState == OutPatientPrescription.States.Request)
                PreTransition_CompletedWithSign2Request();
            else if (fromState == OutPatientPrescription.States.CompletedWithSign && toState == OutPatientPrescription.States.Cancelled)
                PreTransition_CompletedWithSign2Cancelled();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(OutPatientPrescription).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == OutPatientPrescription.States.Request && toState == OutPatientPrescription.States.DrugControl)
                PostTransition_Request2DrugControl();
            else if (fromState == OutPatientPrescription.States.Request && toState == OutPatientPrescription.States.Completed)
                PostTransition_Request2Completed();
            else if (fromState == OutPatientPrescription.States.Request && toState == OutPatientPrescription.States.CompletedWithSign)
                PostTransition_Request2CompletedWithSign();
            else if (fromState == OutPatientPrescription.States.Completed && toState == OutPatientPrescription.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(OutPatientPrescription).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == OutPatientPrescription.States.Request && toState == OutPatientPrescription.States.Completed)
                UndoTransition_Request2Completed(transDef);
            else if (fromState == OutPatientPrescription.States.Request && toState == OutPatientPrescription.States.CompletedWithSign)
                UndoTransition_Request2CompletedWithSign(transDef);
            else if (fromState == OutPatientPrescription.States.DrugControl && toState == OutPatientPrescription.States.Completed)
                UndoTransition_DrugControl2Completed(transDef);
        }

    }
}