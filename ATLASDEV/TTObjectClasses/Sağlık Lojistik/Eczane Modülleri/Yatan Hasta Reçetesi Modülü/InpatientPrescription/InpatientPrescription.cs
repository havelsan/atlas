
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
    /// Yatan Hasta Reçetesi
    /// </summary>
    public  partial class InpatientPrescription : Prescription, IWorkListEpisodeAction, ICreatePrescriptionStockOut
    {
        public partial class GetDrugsFromExternalPharmacyReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetInPatientDrugPrescriptionTotalReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetInpatientPrescriptionDrugsQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetInpatientPrescriptionReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetDetailInPresciprtionReportQuery_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            



            base.PreInsert();
            Store pharmacyStore = Store.GetPharmacyStore(ObjectContext);
            if (pharmacyStore != null)
            {
                IList pharmacyResource = Resource.GetResourceByStore(ObjectContext, pharmacyStore.ObjectID);
                if (pharmacyResource.Count == 1)
                {
                    MasterResource = (ResSection)pharmacyResource[0];
                }
                else if (pharmacyResource.Count > 1)
                {
                    throw new Exception(SystemMessage.GetMessage(1008));
                }
            }


#endregion PreInsert
        }

        protected void PreTransition_ExternalPharmacySupply2DrugSupply()
        {
            // From State : ExternalPharmacySupply   To State : DrugSupply
#region PreTransition_ExternalPharmacySupply2DrugSupply
            








            /*if (this.ExternalPharmacy != null)
            {
                foreach (InpatientDrugOrder inpatientDrugOrder in this.InpatientDrugOrders)
                {
                    if (inpatientDrugOrder.CurrentStateDefID != InpatientDrugOrder.States.Cancelled)
                    {
                        DrugOrder drugOrder = (DrugOrder)this.ObjectContext.GetObject((Guid)inpatientDrugOrder.DrugOrderID, "DRUGORDER");
                        DateTime detailTime = Common.RecTime();
                        double totalAmount = (double)inpatientDrugOrder.Amount;
                        double detailCount = DrugOrder.GetDetailCount(drugOrder.Frequency);
                        double detailTimePeriod = DrugOrder.GetDetailTimePeriod(drugOrder.Frequency);
                        double unitAmount = 0;
                        DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);
                        detailCount = detailCount * (double)drugOrder.Day;
                        bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);

                        if (drugType)
                        {
                            unitAmount = (double)drugOrder.DoseAmount;
                        }
                        else
                        {
                            unitAmount = (double)drugOrder.DoseAmount * (double)drugDefinition.Dose;
                        }

                        drugOrder.Amount = (double)totalAmount;
                        for (int i = 0; i < detailCount; i++)
                        {
                            DrugOrderDetail drugOrderDetail = new DrugOrderDetail(drugOrder.ObjectContext);
                            drugOrderDetail.Material = (Material)drugOrder.Material;
                            drugOrderDetail.MasterResource = drugOrder.MasterResource;
                            drugOrderDetail.FromResource = drugOrder.FromResource;
                            drugOrderDetail.Episode = drugOrder.Episode;
                            drugOrderDetail.ActionDate = drugOrder.ActionDate;// Bu actionun açıldığı tarih olmalı. SS
                            drugOrderDetail.OrderPlannedDate = detailTime;
                            detailTime = detailTime.AddHours(detailTimePeriod);
                            drugOrderDetail.Amount = unitAmount;
                            drugOrderDetail.Day = drugOrder.Day;
                            drugOrderDetail.DoseAmount = drugOrder.DoseAmount;
                            drugOrderDetail.Frequency = drugOrder.Frequency;
                            drugOrderDetail.UsageNote = drugOrder.UsageNote;
                            drugOrderDetail.DrugOrder = drugOrder;
                            drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.ExPharmacySupply;
                            drugOrderDetail.Eligible = false;

                            foreach (DrugOrderDetail orderDetail in drugOrder.DrugOrderDetails)
                            {
                                orderDetail.NursingApplication = drugOrder.NursingApplication;
                            }
                        }
                        drugOrder.CurrentStateDefID = DrugOrder.States.Planned;

                        DrugOrderTransaction drugOrderTransaction = new DrugOrderTransaction(this.ObjectContext);
                        drugOrderTransaction.DrugOrder = drugOrder;
                        drugOrderTransaction.Amount = inpatientDrugOrder.Amount;
                        drugOrderTransaction.Volume = ((DrugDefinition)inpatientDrugOrder.Material).Volume * inpatientDrugOrder.Amount;
                        drugOrderTransaction.InOut = 1;
                        inpatientDrugOrder.CurrentStateDefID = InpatientDrugOrder.States.Planned;

                    }
                }
            }
            else
            {
                string message = SystemMessage.GetMessage(118);
                throw new Exception(message);
            }
            */

#endregion PreTransition_ExternalPharmacySupply2DrugSupply
        }

        protected void PreTransition_ExternalPharmacySupply2DrugControl()
        {
            // From State : ExternalPharmacySupply   To State : DrugControl
#region PreTransition_ExternalPharmacySupply2DrugControl
            
            
            


            if (!string.IsNullOrEmpty(EReceteNo))
            {
                Prescription.InpatientPrescriptionWebCaller callerObject = new Prescription.InpatientPrescriptionWebCaller();
                callerObject.ObjectID = ObjectID;

                if (string.IsNullOrEmpty(ERecetePassword))
                    throw new TTException("Doktorun E reçete şifresi girilmemiş.");
                
                EReceteIslemleri.ereceteSilCevapDVO response = EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, ProcedureDoctor.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEReceteDelete(this));
                if (response != null)
                {
                    if (response.sonucKodu.Equals("0000"))
                    {
                        TTUtils.InfoMessageService.Instance.ShowMessage("E reçete başarıyla iptal edilmiştir.");
                        EReceteNo = string.Empty;
                        EReceteDescription = string.Empty;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(response.uyariMesaji))
                            throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :")+ response.uyariMesaji);
                        else
                            throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                    }
                }
                TTMessage resOnay = EReceteIslemleri.WebMethods.ereceteOnayIptal(Sites.SiteLocalHost, ProcedureDoctor.UniqueNo.ToString(), ERecetePassword.ToString(), callerObject, Prescription.GetEreceteApprovalCancelRequest(this));
            }
#endregion PreTransition_ExternalPharmacySupply2DrugControl
        }

        protected void PreTransition_ExternalPharmacySupply2Cancelled()
        {
            // From State : ExternalPharmacySupply   To State : Cancelled
#region PreTransition_ExternalPharmacySupply2Cancelled
            
//            if (!string.IsNullOrEmpty(EReceteNo))
//            {
//                Prescription.InpatientPrescriptionWebCaller callerObject = new Prescription.InpatientPrescriptionWebCaller();
//                callerObject.ObjectID = this.ObjectID;
//
//                if (string.IsNullOrEmpty(this.ERecetePassword))
//                    throw new TTException("Doktorun E reçete şifresi girilmemiş.");
//
//                if ( this.IsSignedPrescription() )
//                {
//                    EReceteIslemleri.imzaliEreceteSilCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteSilSync(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEReceteSignedDelete(this));
//                    if (response != null)
//                    {
//                        if (response.sonucKodu.Equals("0000"))
//                        {
//                            InfoBox.Alert("E reçete başarıyla iptal edilmiştir.");
//                        }
//                        else
//                        {
//                            if (!string.IsNullOrEmpty(response.uyariMesaji))
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
//                            else
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
//                        }
//                    }
//                    TTMessage resOnay = EReceteIslemleri.WebMethods.imzaliEreceteOnayIptalAsync(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), callerObject, Prescription.GetEreceteSignedApprovalCancelRequest(this));
//                }
//                else
//                {
//                    EReceteIslemleri.ereceteSilCevapDVO response = EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEReceteDelete(this));
//                    if (response != null)
//                    {
//                        if (response.sonucKodu.Equals("0000"))
//                        {
//                            InfoBox.Alert("E reçete başarıyla iptal edilmiştir.");
//                        }
//                        else
//                        {
//                            if (!string.IsNullOrEmpty(response.uyariMesaji))
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
//                            else
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
//                        }
//                    }
//                    TTMessage resOnay = EReceteIslemleri.WebMethods.ereceteOnayIptal(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), callerObject, Prescription.GetEreceteApprovalCancelRequest(this));
//                }
//            }
            
            //this.CancelStockPrescriptionOut(this);

#endregion PreTransition_ExternalPharmacySupply2Cancelled
        }

        protected void PreTransition_Request2InfectionApproval()
        {
            // From State : Request   To State : InfectionApproval
#region PreTransition_Request2InfectionApproval
            
            Prescription.InpatientPrescriptionWebCaller callerObject = new Prescription.InpatientPrescriptionWebCaller();
            callerObject.ObjectID = ObjectID;

            if (SubEpisode.IsSGK)
            {
                if (SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(SubEpisode.SGKSEP.MedulaTakipNo))
                {
                    if(string.IsNullOrEmpty(EReceteNo))
                    {
                        if (string.IsNullOrEmpty(ERecetePassword))
                            throw new TTException("Doktorun E reçete şifresi girilmemiştir");

                        bool kontrol = false;
                        foreach (InpatientDrugOrder drugOrder in _InpatientDrugOrders)
                        {
                            if (drugOrder.CurrentStateDefID != InpatientDrugOrder.States.Cancelled)
                                kontrol = true;

                        }

                        if (kontrol == false)
                            throw new TTException("Tüm ilaçları iptal etiğiniz için Ereçeteyi iptal'e göndermelisiniz.");
                        else
                            SendErecete();
                    }
                }
                else
                    throw new TTException(TTUtils.CultureService.GetText("M25886", "Hastaya Medula Provizyon Alınmadığında Dolayı e-Reçete Kaydı Yapılamamıştır."));
            }


#endregion PreTransition_Request2InfectionApproval
        }

        protected void PreTransition_DrugControl2Cancelled()
        {
            // From State : DrugControl   To State : Cancelled
#region PreTransition_DrugControl2Cancelled
            
           // this.CancelStockPrescriptionOut(this);

#endregion PreTransition_DrugControl2Cancelled
        }

        protected void PreTransition_DrugControl2EreceteCompleted()
        {
            // From State : DrugControl   To State : EreceteCompleted
#region PreTransition_DrugControl2EreceteCompleted
            
            
            
            
            Prescription.InpatientPrescriptionWebCaller callerObject = new Prescription.InpatientPrescriptionWebCaller();
            callerObject.ObjectID = ObjectID;

            if (SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(SubEpisode.SGKSEP.MedulaTakipNo))
            {
                if (string.IsNullOrEmpty(ERecetePassword))
                    throw new TTException("Doktorun E reçete şifresi girilmemiştir");

                bool kontrol = false;
                foreach (InpatientDrugOrder drugOrder in _InpatientDrugOrders)
                {
                    if (drugOrder.CurrentStateDefID != InpatientDrugOrder.States.Cancelled)
                        kontrol = true;

                }

                if (kontrol == false)
                {
                    throw new TTException("Tüm ilaçları iptal etiğiniz için Ereçeteyi iptal'e göndermelisiniz.");
                }
                else
                {
                    EReceteIslemleri.ereceteGirisCevapDVO response = EReceteIslemleri.WebMethods.ereceteGirisSynCall(Sites.SiteLocalHost, ProcedureDoctor.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEReceteInputRequest(this));
                    if (response != null)
                    {
                        if (response.sonucKodu.Equals("0000"))
                        {
                            EReceteNo = response.ereceteDVO.ereceteNo;
                            EReceteIslemleri.ereceteOnayCevapDVO resOnay = EReceteIslemleri.WebMethods.ereceteOnay(Sites.SiteLocalHost, ProcedureDoctor.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEreceteApprovalRequest(this));
                            if (resOnay != null)
                            {
                                if (resOnay.sonucKodu.Equals("0000"))
                                {
                                    TTUtils.InfoMessageService.Instance.ShowMessage(EReceteNo.ToString() + " e reçete numarası ile reçete kaydedilmiştir.");
                                    EReceteDescription = " E Reçete başarılı bir şekilde kaydedilmiştir.";
                                }
                                else
                                {
                                    EReceteIslemleri.ereceteSilCevapDVO responseSil = EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, ProcedureDoctor.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEReceteDelete(this));
                                    if (responseSil != null)
                                    {
                                        if (responseSil.sonucKodu.Equals("0000") == false)
                                        {
                                            throw new TTException(EReceteNo.ToString() + " nolu e reçete iptal edilemedi bilgi işleme haber veriniz");
                                        }
                                    }
                                    if (!string.IsNullOrEmpty(resOnay.uyariMesaji))
                                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + resOnay.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :")+ response.uyariMesaji);
                                    else
                                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + resOnay.sonucMesaji);
                                }
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(response.uyariMesaji))
                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :")+ response.uyariMesaji);
                            else
                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                        }
                    }
                }
            }
            else
                throw new TTException(TTUtils.CultureService.GetText("M25886", "Hastaya Medula Provizyon Alınmadığında Dolayı e-Reçete Kaydı Yapılamamıştır."));

#endregion PreTransition_DrugControl2EreceteCompleted
        }

        protected void PreTransition_DrugControl2EreceteSend()
        {
            // From State : DrugControl   To State : EreceteSend
#region PreTransition_DrugControl2EreceteSend
            
            
            
            Prescription.InpatientPrescriptionWebCaller callerObject = new Prescription.InpatientPrescriptionWebCaller();
            callerObject.ObjectID = ObjectID;

            if (SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(SubEpisode.SGKSEP.MedulaTakipNo))
            {
                if(string.IsNullOrEmpty(ERecetePassword))
                    throw new TTException("Doktorun E reçete şifresi girilmemiştir");

                bool kontrol =false;
               foreach(InpatientDrugOrder drugOrder in _InpatientDrugOrders)
                {
                    if(drugOrder.CurrentStateDefID != InpatientDrugOrder.States.Cancelled)
                        kontrol =true;
                    
                }
                        
                if(kontrol == false)
                {
                 throw new TTException("Tüm ilaçları iptal etiğiniz için  Ereçeteyi iptal'e göndermelisiniz .");
                }
                   
                else 
                {
                EReceteIslemleri.ereceteGirisCevapDVO response = EReceteIslemleri.WebMethods.ereceteGirisSynCall(Sites.SiteLocalHost, ProcedureDoctor.UniqueNo.ToString(), ERecetePassword.ToString(),Prescription.GetEReceteInputRequest(this));
                if (response != null)
                {
                    if (response.sonucKodu.Equals("0000"))
                    {
                        EReceteNo = response.ereceteDVO.ereceteNo;
                        EReceteIslemleri.ereceteOnayCevapDVO resOnay = EReceteIslemleri.WebMethods.ereceteOnay(Sites.SiteLocalHost, ProcedureDoctor.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEreceteApprovalRequest(this));
                        if(resOnay != null)
                        {
                            if(resOnay.sonucKodu.Equals("0000"))
                            {
                                TTUtils.InfoMessageService.Instance.ShowMessage(EReceteNo.ToString() + " e reçete numarası ile reçete kaydedilmiştir.");
                                EReceteDescription = " E Reçete başarılı bir şekilde kaydedilmiştir.";
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(resOnay.uyariMesaji))
                                    throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :")+ response.uyariMesaji);
                                else
                                    throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(response.uyariMesaji))
                            throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :")+ response.uyariMesaji);
                        else
                            throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                    }
                }
            }
            }


#endregion PreTransition_DrugControl2EreceteSend
        }

        protected void PreTransition_DrugSupply2Completed()
        {
            // From State : DrugSupply   To State : Completed
#region PreTransition_DrugSupply2Completed
            




            bool completedOrder = true;
            foreach (InpatientDrugOrder inpatientDrugOrder in InpatientDrugOrders)
            {
                DrugOrder drugOrder = (DrugOrder)ObjectContext.GetObject((Guid)inpatientDrugOrder.DrugOrderID, "DRUGORDER");
                if (drugOrder.CurrentStateDefID != DrugOrder.States.Completed && drugOrder.CurrentStateDefID != DrugOrder.States.Cancelled)
                {
                    completedOrder = false;
                }
            }
            if (completedOrder == false)
            {
                string message = SystemMessage.GetMessage(119);
                throw new Exception(message);
            }
            else
            {
                foreach (InpatientDrugOrder inpatientDrugOrder in InpatientDrugOrders)
                {
                    if (inpatientDrugOrder.CurrentStateDefID != InpatientDrugOrder.States.Cancelled)
                    {
                        inpatientDrugOrder.CurrentStateDefID = InpatientDrugOrder.States.Completed;
                    }
                }
            }



#endregion PreTransition_DrugSupply2Completed
        }

        protected void UndoTransition_DrugSupply2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : DrugSupply   To State : Completed
#region UndoTransition_DrugSupply2Completed
            NoBackStateBack();
#endregion UndoTransition_DrugSupply2Completed
        }

        protected void PreTransition_EreceteSend2EreceteCompleted()
        {
            // From State : EreceteSend   To State : EreceteCompleted
#region PreTransition_EreceteSend2EreceteCompleted
            
            
            if(IsRepeated.HasValue)
            {
                if ((bool)IsRepeated)
                {
                    ResUser user = (ResUser)ObjectContext.GetObject(ProcedureDoctor.ObjectID, typeof(ResUser));
                    user.ErecetePassword = ERecetePassword;
                }
            }

#endregion PreTransition_EreceteSend2EreceteCompleted
        }

        protected void PreTransition_EreceteSend2EreceteCancelled()
        {
            // From State : EreceteSend   To State : EreceteCancelled
#region PreTransition_EreceteSend2EreceteCancelled
            
            
//            Prescription.InpatientPrescriptionWebCaller callerObject = new Prescription.InpatientPrescriptionWebCaller();
//            callerObject.ObjectID = this.ObjectID;
//
//            if (string.IsNullOrEmpty(this.ERecetePassword))
//                throw new TTException("Doktorun E reçete şifresi girilmemiş.");
//
//            if (!string.IsNullOrEmpty(EReceteNo))
//            {
//                if ( this.IsSignedPrescription() )
//                {
//                    EReceteIslemleri.imzaliEreceteSilCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteSilSync(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEReceteSignedDelete(this));
//                    if (response != null)
//                    {
//                        if (response.sonucKodu.Equals("0000"))
//                        {
//                            InfoBox.Alert("E reçete başarıyla iptal edilmiştir.");
//                        }
//                        else
//                        {
//                            if (!string.IsNullOrEmpty(response.uyariMesaji))
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
//                            else
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
//                        }
//                    }
//                    TTMessage resOnay = EReceteIslemleri.WebMethods.imzaliEreceteOnayIptalAsync(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), callerObject, Prescription.GetEreceteSignedApprovalCancelRequest(this));
//                }
//                else
//                {
//                    EReceteIslemleri.ereceteSilCevapDVO response = EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEReceteDelete(this));
//                    if (response != null)
//                    {
//                        if (response.sonucKodu.Equals("0000"))
//                        {
//                            InfoBox.Alert("E reçete başarıyla iptal edilmiştir.");
//                        }
//                        else
//                        {
//                            if (!string.IsNullOrEmpty(response.uyariMesaji))
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
//                            else
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
//                        }
//                    }
//                    TTMessage resOnay = EReceteIslemleri.WebMethods.ereceteOnayIptal(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), callerObject, Prescription.GetEreceteApprovalCancelRequest(this));
//                }
//            }
            
            //this.CancelStockPrescriptionOut(this);

#endregion PreTransition_EreceteSend2EreceteCancelled
        }

        protected void PreTransition_EreceteCompleted2Cancelled()
        {
            // From State : EreceteCompleted   To State : Cancelled
#region PreTransition_EreceteCompleted2Cancelled
            
            
            //this.CancelStockPrescriptionOut(this);
            
//            Prescription.InpatientPrescriptionWebCaller callerObject = new Prescription.InpatientPrescriptionWebCaller();
//            callerObject.ObjectID = this.ObjectID;
//
//            if (string.IsNullOrEmpty(this.ERecetePassword))
//                throw new TTException("Doktorun E reçete şifresi girilmemiş.");
//            
//            if (!string.IsNullOrEmpty(this.EReceteNo))
//            {
//                if ( this.IsSignedPrescription() )
//                {
//                    EReceteIslemleri.imzaliEreceteSilCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteSilSync(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEReceteSignedDelete(this));
//                    if (response != null)
//                    {
//                        if (response.sonucKodu.Equals("0000"))
//                        {
//                            InfoBox.Alert("E reçete başarıyla iptal edilmiştir.");
//                        }
//                        else
//                        {
//                            if (!string.IsNullOrEmpty(response.uyariMesaji))
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
//                            else
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
//                        }
//                    }
//                    TTMessage resOnay = EReceteIslemleri.WebMethods.imzaliEreceteOnayIptalAsync(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), callerObject, Prescription.GetEreceteSignedApprovalCancelRequest(this));
//                    if (string.IsNullOrEmpty(this.EHURecetePassword) == false && string.IsNullOrEmpty(this.EHUUniqueNo) == false)
//                    {
//                        long uniqueNo = (long)Convert.ToDouble(this.EHUUniqueNo);
//                        TTMessage ehuOnayIptal = EReceteIslemleri.WebMethods.imzaliEreceteOnayIptalAsync(Sites.SiteLocalHost, this.EHUUniqueNo, this.EHURecetePassword, callerObject, Prescription.GetEreceteSignedEHUCancelRequest(this, uniqueNo));
//                    }
//                }
//                else
//                {
//                    EReceteIslemleri.ereceteSilCevapDVO response = EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEReceteDelete(this));
//                    if (response != null)
//                    {
//                        if (response.sonucKodu.Equals("0000"))
//                        {
//                            InfoBox.Alert("E reçete başarıyla iptal edilmiştir.");
//                        }
//                        else
//                        {
//                            if (!string.IsNullOrEmpty(response.uyariMesaji))
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
//                            else
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
//                        }
//                    }
//                    TTMessage resOnay = EReceteIslemleri.WebMethods.ereceteOnayIptal(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), callerObject, Prescription.GetEreceteApprovalCancelRequest(this));
//                    if (string.IsNullOrEmpty(this.EHURecetePassword) == false && string.IsNullOrEmpty(this.EHUUniqueNo) == false)
//                    {
//                        long uniqueNo = (long)Convert.ToDouble(this.EHUUniqueNo);
//                        TTMessage ehuOnayIptal = EReceteIslemleri.WebMethods.ereceteOnayIptal(Sites.SiteLocalHost, this.EHUUniqueNo, this.EHURecetePassword, callerObject, Prescription.GetEreceteEHUCancelRequest(this, uniqueNo));
//                    }
//                }
//            }

#endregion PreTransition_EreceteCompleted2Cancelled
        }

        protected void PreTransition_EreceteCancelled2Cancelled()
        {
            // From State : EreceteCancelled   To State : Cancelled
#region PreTransition_EreceteCancelled2Cancelled
            
            
            
            //this.CancelStockPrescriptionOut(this);
            
//            Prescription.InpatientPrescriptionWebCaller callerObject = new Prescription.InpatientPrescriptionWebCaller();
//            callerObject.ObjectID = this.ObjectID;
//
//            if (string.IsNullOrEmpty(this.ERecetePassword))
//                throw new TTException("Doktorun E reçete şifresi girilmemiştir");
//
//            if (string.IsNullOrEmpty(this.EReceteNo) == false)
//            {
//                if ( this.IsSignedPrescription() )
//                {
//                    EReceteIslemleri.imzaliEreceteSilCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteSilSync(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEReceteSignedDelete(this));
//                    if (response != null)
//                    {
//                        if (response.sonucKodu.Equals("0000"))
//                        {
//                            InfoBox.Alert("E reçete başarıyla iptal edilmiştir.");
//                        }
//                        else
//                        {
//                            if (!string.IsNullOrEmpty(response.uyariMesaji))
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
//                            else
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
//                        }
//                    }
//                    EReceteIslemleri.WebMethods.imzaliEreceteOnayIptalAsync(Sites.SiteLocalHost, this.ProcedureDoctor.Person.UniqueRefNo.ToString(), this.ERecetePassword.ToString(), callerObject, Prescription.GetEreceteSignedApprovalCancelRequest(this));
//                }
//                else
//                {
//                    EReceteIslemleri.ereceteSilCevapDVO response = EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEReceteDelete(this));
//                    if (response != null)
//                    {
//                        if (response.sonucKodu.Equals("0000"))
//                        {
//                            InfoBox.Alert("E reçete başarıyla iptal edilmiştir.");
//                        }
//                        else
//                        {
//                            if (!string.IsNullOrEmpty(response.uyariMesaji))
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
//                            else
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
//                        }
//                    }
//                    EReceteIslemleri.WebMethods.ereceteOnayIptal(Sites.SiteLocalHost, this.ProcedureDoctor.Person.UniqueRefNo.ToString(), this.ERecetePassword.ToString(), callerObject, Prescription.GetEreceteApprovalCancelRequest(this));
//                }
//            }

#endregion PreTransition_EreceteCancelled2Cancelled
        }

        protected void PreTransition_InfectionApproval2Cancelled()
        {
            // From State : InfectionApproval   To State : Cancelled
#region PreTransition_InfectionApproval2Cancelled
            
            //this.CancelStockPrescriptionOut(this);

            //CancelErecete();

#endregion PreTransition_InfectionApproval2Cancelled
        }

        protected void PreTransition_SendToDoctor2Cancelled()
        {
            // From State : SendToDoctor   To State : Cancelled
#region PreTransition_SendToDoctor2Cancelled
            
            //this.CancelStockPrescriptionOut(this);

//            Prescription.InpatientPrescriptionWebCaller callerObject = new Prescription.InpatientPrescriptionWebCaller();
//            callerObject.ObjectID = this.ObjectID;
//
//            if (string.IsNullOrEmpty(this.ERecetePassword))
//                throw new TTException("Doktorun E reçete şifresi girilmemiş.");
//            
//            if (!string.IsNullOrEmpty(this.EReceteNo))
//            {
//                if ( this.IsSignedPrescription() )
//                {
//                    EReceteIslemleri.imzaliEreceteSilCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteSilSync(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEReceteSignedDelete(this));
//                    if (response != null)
//                    {
//                        if (response.sonucKodu.Equals("0000"))
//                        {
//                            InfoBox.Alert("E reçete başarıyla iptal edilmiştir.");
//                            this.EReceteNo = string.Empty;
//                        }
//                        else
//                        {
//                            if (!string.IsNullOrEmpty(response.uyariMesaji))
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
//                            else
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
//                        }
//                    }
//                    
//                    TTMessage resOnay = EReceteIslemleri.WebMethods.imzaliEreceteOnayIptalAsync(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), callerObject, Prescription.GetEreceteSignedApprovalCancelRequest(this));
//                }
//                else
//                {
//                    EReceteIslemleri.ereceteSilCevapDVO response = EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), Prescription.GetEReceteDelete(this));
//                    if (response != null)
//                    {
//                        if (response.sonucKodu.Equals("0000"))
//                        {
//                            InfoBox.Alert("E reçete başarıyla iptal edilmiştir.");
//                            this.EReceteNo = string.Empty;
//                        }
//                        else
//                        {
//                            if (!string.IsNullOrEmpty(response.uyariMesaji))
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
//                            else
//                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
//                        }
//                    }
//                    TTMessage resOnay = EReceteIslemleri.WebMethods.ereceteOnayIptal(Sites.SiteLocalHost, this.ProcedureDoctor.UniqueNo.ToString(), this.ERecetePassword.ToString(), callerObject, Prescription.GetEreceteApprovalCancelRequest(this));
//                }
//            }

        

#endregion PreTransition_SendToDoctor2Cancelled
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

        protected void PostTransition_Request2Cancelled()
        {
            // From State : Request   To State : Cancelled
            #region PostTransition_Request2Cancelled
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

            #endregion PostTransition_Request2Cancelled
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
        public InpatientPrescription(TTObjectContext objectContext, EpisodeAction episodeAction)
            : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = InpatientPrescription.States.Request;
            ProcedureSpeciality = episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;
            Episode = episodeAction.Episode;
        }

        public InpatientPrescription(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable)
            : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = subactionProcedureFlowable.MasterResource;
            FromResource = subactionProcedureFlowable.MasterResource;
            CurrentStateDefID = InpatientPrescription.States.Request;
            ProcedureSpeciality = subactionProcedureFlowable.ProcedureSpeciality;
            MasterAction = subactionProcedureFlowable.EpisodeAction;
            Episode = subactionProcedureFlowable.Episode;
        }

        public override List<SubActionMaterial> GetAccountableSubActionMaterials()
        {
             List<SubActionMaterial> myCol = base.GetAccountableSubActionMaterials();
                foreach (InpatientDrugOrder drugOrder in InpatientDrugOrders)
                {
                    if (drugOrder.Material.Chargable == true)
                    {
                        if (drugOrder.Eligible == true)
                            myCol.Add((SubActionMaterial)drugOrder);
                    }
                }
                return myCol;
            
        }
        
        public bool IsInfectionApproval()
        {
            bool IsInfectionApproval = false ;
            
            foreach(InpatientDrugOrder inpatientDrugOrder in InpatientDrugOrders)
            {
                DrugDefinition  drugDefinition = (DrugDefinition)inpatientDrugOrder.Material;
                ResUser user = (ResUser)ProcedureDoctor;
                if (drugDefinition.InfectionApproval.HasValue && (bool)drugDefinition.InfectionApproval)
                {
                    IsInfectionApproval = true;
                    //  break;
                }
                if (IsInfectionApproval)
                {
                    if(inpatientDrugOrder.Day <= 3)
                    {
                        IsInfectionApproval = false;
                        break;
                    }
                    else
                    {
                        foreach (ResourceSpecialityGrid resource in user.ResourceSpecialities)
                        {
                            if (resource.Speciality.EHU != null && resource.Speciality.EHU == true)
                            {
                                IsInfectionApproval = false;
                                break;
                            }
                            else
                            {
                                IsInfectionApproval = true;
                                break;
                            }
                        }
                    }
                }
            }
            return IsInfectionApproval ;
        }

        public bool IsSendEreceteEHUApproval()
        {
            bool isSendEreceteEHUApproval = false;
            foreach (InpatientDrugOrder inpatientDrugOrder in InpatientDrugOrders)
            {
                DrugDefinition drugDefinition = (DrugDefinition)inpatientDrugOrder.Material;
                ResUser user = (ResUser)ProcedureDoctor;
                if (drugDefinition.InfectionApproval.HasValue && (bool)drugDefinition.InfectionApproval)
                {
                    isSendEreceteEHUApproval = true;
                    // break;
                }
                if(isSendEreceteEHUApproval)
                {
                    if(inpatientDrugOrder.Day <= 3)
                    {
                        isSendEreceteEHUApproval = false;
                        break;
                    }
                    else
                    {
                        foreach (ResourceSpecialityGrid resource in user.ResourceSpecialities)
                        {
                            if (resource.Speciality.EHU != null && resource.Speciality.EHU == true)
                            {
                                isSendEreceteEHUApproval = false;
                                break;
                            }
                            else
                            {
                                isSendEreceteEHUApproval = true;
                                break;
                            }
                        }
                    }
                    
                }
            }
            return isSendEreceteEHUApproval;
        }
        
        public void SendErecete()
        {
            EReceteIslemleri.ereceteGirisCevapDVO response = EReceteIslemleri.WebMethods.ereceteGirisSynCall(Sites.SiteLocalHost, ProcedureDoctor.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEReceteInputRequest(this));
            if (response != null)
            {
                if (response.sonucKodu.Equals("0000"))
                {
                    EReceteNo = response.ereceteDVO.ereceteNo;
                    EReceteIslemleri.ereceteOnayCevapDVO resOnay = EReceteIslemleri.WebMethods.ereceteOnay(Sites.SiteLocalHost, ProcedureDoctor.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEreceteApprovalRequest(this));
                    if (resOnay != null)
                        
                    {
                        if (resOnay.sonucKodu.Equals("0000"))
                        {
                            TTUtils.InfoMessageService.Instance.ShowMessage(EReceteNo.ToString() + " e reçete numarası ile reçete kaydedilmiştir.");
                            EReceteDescription = " E Reçete başarılı bir şekilde kaydedilmiştir.";
                        }
                        else
                        {
                            EReceteIslemleri.ereceteSilCevapDVO responseSil = EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, ProcedureDoctor.UniqueNo.ToString(), ERecetePassword.ToString(), Prescription.GetEReceteDelete(this));
                            if (responseSil != null)
                            {
                                if (responseSil.sonucKodu.Equals("0000") == false)
                                {
                                    throw new TTException(EReceteNo.ToString() + " nolu e reçete iptal edilemedi bilgi işleme haber veriniz");
                                }
                            }
                            if (!string.IsNullOrEmpty(resOnay.uyariMesaji))
                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + resOnay.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :")+ response.uyariMesaji);
                            else
                                throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + resOnay.sonucMesaji);
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(response.uyariMesaji))
                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :")+ response.uyariMesaji);
                    else
                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                }
            }
        }
        
       

        public void SendEreceteEHUApproval(ResUser currentUser)
        {
            long uniqueNo = (long)Convert.ToDouble(currentUser.UniqueNo);
            EReceteIslemleri.ereceteOnayCevapDVO ehuOnay = EReceteIslemleri.WebMethods.ereceteOnay(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), EHURecetePassword.ToString(), Prescription.GetEreceteEHUApprovalRequest(this, uniqueNo));
            if (ehuOnay != null)
            {
                if (ehuOnay.sonucKodu.Equals("0000"))
                {
                    TTUtils.InfoMessageService.Instance.ShowMessage(EReceteNo.ToString() + " e reçete numarası ile reçete EHU onayı alınmıştır.");
                    EReceteDescription = " E Reçete başarılı bir şekilde EHU onayı almıştır.";
                    EHUUniqueNo = currentUser.UniqueNo.ToString() ;
                    
                    if(IsRepeated.HasValue && (bool)IsRepeated.Value)
                    {
                        TTObjectContext context = new TTObjectContext(false);
                        ResUser updatedUser = (ResUser)context.GetObject(currentUser.ObjectID, currentUser.ObjectDef);
                        updatedUser.ErecetePassword = EHURecetePassword ;
                        context.Save();
                        ((ITTObject)currentUser).Refresh();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(ehuOnay.uyariMesaji))
                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + ehuOnay.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :")+ ehuOnay.uyariMesaji);
                    else
                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + ehuOnay.sonucMesaji);
                }
            }
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InpatientPrescription).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == InpatientPrescription.States.Request && toState == InpatientPrescription.States.InfectionApproval)
                PreTransition_Request2InfectionApproval();
            else if (fromState == InpatientPrescription.States.InfectionApproval && toState == InpatientPrescription.States.Cancelled)
                PreTransition_InfectionApproval2Cancelled();
        }


        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InpatientPrescription).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == InpatientPrescription.States.Completed && toState == InpatientPrescription.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == InpatientPrescription.States.Request && toState == InpatientPrescription.States.Cancelled)
                PostTransition_Request2Cancelled();

        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InpatientPrescription).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
        }

    }
}