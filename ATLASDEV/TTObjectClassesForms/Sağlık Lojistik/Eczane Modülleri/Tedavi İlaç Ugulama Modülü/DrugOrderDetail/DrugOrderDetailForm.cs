
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
    /// Uygulama
    /// </summary>
    public partial class DrugOrderDetailForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region DrugOrderDetailForm_PreScript
    base.PreScript();
            DrugOrderDetail drugOrderDetail = _DrugOrderDetail;
            drugOrderDetail.ActionDate = DateTime.Now;
            DrugDefinition drugDefinition = ((DrugDefinition)drugOrderDetail.Material);
            bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
            double restDose = DrugOrderTransaction.GetRestDose (drugOrderDetail.DrugOrder);
            double dose = 0 ;
            
            if (restDose > 0)
            {
                dose = restDose ;
            }
            else
            {
                Dictionary<object, double> patientRestDictionary = DrugOrderTransaction.GetPatientRestDose(drugOrderDetail.Material, drugOrderDetail.Episode);
                foreach (KeyValuePair<object, double> restDic in patientRestDictionary)
                {
                    dose += (double)restDic.Value ;
                }
            }
            
            this.RestDose.Text = dose.ToString();
            
            this.DropStateButton(DrugOrderDetail.States.PatientDelivery);
            this.DropStateButton(DrugOrderDetail.States.ReturnPharmacy);
            
            switch (drugOrderDetail.CurrentStateDefID.Value.ToString())
            {
                case "cb22e74b-a2be-456f-8680-660d0b21dc24": // plan
                    drugOrderDetail.Stage = "Eczaneden İstenmedi!";
                    this.DropStateButton(DrugOrderDetail.States.Request);
                    this.DropStateButton(DrugOrderDetail.States.UseRestDose);
                    this.DropStateButton(DrugOrderDetail.States.Apply);
                    this.DropStateButton(DrugOrderDetail.States.Stop);
                    this.DropStateButton(DrugOrderDetail.States.Supply);
                    this.DropStateButton(DrugOrderDetail.States.Cancel);
                    break;
                case "da01e671-efb9-4d84-8122-4bae07e08c20"://İstek
                    drugOrderDetail.Stage = "Eczaneden İstendi Henüz Karşılanmadı!";
                    this.DropStateButton(DrugOrderDetail.States.Supply) ;
                    this.DropStateButton(DrugOrderDetail.States.Stop);
                    this.DropStateButton(DrugOrderDetail.States.Planned);
                    break;
                case "94c4b7eb-b764-4ca5-add6-76e2217f7dd4"://Hastanın Üzerinde
                    drugOrderDetail.Stage = "Daha Önce Karşılanan Doz Kullanılacaktır !!!";
                    this.DropStateButton (DrugOrderDetail.States.Planned);
                    if (!drugType)
                    {
                        this.ttcheckbox1.Visible = true ;
                    }
                    break;
                case "d4f85132-8d05-4dc7-b9b2-fc04bae622b0": // Karşılandı
                    drugOrderDetail.Stage = "Eczaneden İstendi Eczane Tarafından Karşılandı!";
                    this.DropStateButton (DrugOrderDetail.States.Planned);
                    this.DropStateButton(DrugOrderDetail.States.Stop);
                    if (!drugType)
                    {
                        this.ttcheckbox1.Visible = true ;
                    }
                    break;
                case "ad54f2c0-8ebe-4fbb-a57a-b7c870fd1fb3": // Eczacılık Bilimlerinden İstendi
                    drugOrderDetail.Stage = "Eczacılık Bilimlerinden İstendi";
                    this.DropStateButton (DrugOrderDetail.States.Supply);
                    this.DropStateButton(DrugOrderDetail.States.Cancel);
                    if (!drugType)
                    {
                        this.ttcheckbox1.Visible = true ;
                    }
                    break;
                case "f1b24e44-ecb3-4b44-9b23-1d77e9901721"://Durdur
                    this.DropStateButton(DrugOrderDetail.States.Supply);
                    this.DropStateButton(DrugOrderDetail.States.Request);
                    this.DropStateButton(DrugOrderDetail.States.Planned);
                    break;
                case "14ea4626-5b27-4663-82f9-64968cb4eb63": //Hastaya Teslim
                    drugOrderDetail.Stage = "Hasta / Hasta Yakınına teslim edildi.";
                    break;
                case "d39a37a6-610e-4143-aca2-691ce5818915": //Uygulandı
                    drugOrderDetail.Stage = "Uygulandı";
                    break;
                case "add6e452-c007-4849-b477-17d30400abe8"://İptal
                    drugOrderDetail.Stage = "Uygulama İptal Edildi!";
                    break;
                case "0586979d-523c-4800-995c-750ac3984606"://Dış Eczane Tarafından Karşılandı
                    drugOrderDetail.Stage = "Dış Eczane Tarafından Karşılandı";
                    this.DropStateButton(DrugOrderDetail.States.Cancel);
                    break;
                default:
                    throw new TTException(" Lütfen sistem yöneticisine başvurun!!");
            }
#endregion DrugOrderDetailForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DrugOrderDetailForm_PostScript
    base.PostScript(transDef);
            int aaaa;
//            if(transDef!=null)
//            {
//                if(transDef.ToStateDefID==DrugOrderDetail.States.Apply)
//                {
//                    DrugOrderDetail drugOrderDetail = _DrugOrderDetail;
//                    DrugOrder drugOrder = drugOrderDetail.DrugOrder ;
//                    
//                    // PatientRestDose güncelleniyor.
//                    double patientRestDose = 0;
//                    double usedAmount = 0 ;
//                    double usedVolume = 0;
//                    double usedCount = 0;
//                    bool fullDose = false ;
//                    
//                    bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material);
//
//                    if (drugType)
//                    {
//                        usedAmount = (double)drugOrderDetail.Amount;
//                        usedVolume = (double)drugOrderDetail.Amount * (double)((DrugDefinition)drugOrderDetail.Material).Volume;
//                    }
//                    else
//                    {
//                        usedAmount = (double)drugOrderDetail.Amount / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
//                        usedVolume = (double)drugOrderDetail.Amount;
//                    }
//
//                    double restDose = DrugOrderTransaction.GetRestDose (drugOrder);
//
//                    if (restDose > 0)
//                    {
//                        patientRestDose = restDose - (double)drugOrderDetail.Amount;
//                        if (patientRestDose >= 0)  //TotalDose 'u kullanıcı bitirirse kalan orderler ne olacak ?
//                        {
//                            if (patientRestDose == 0)
//                            {
//                                fullDose = true;
//                            }
//
//                            DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);
//
//                            newDrugOrderTransaction.DrugOrder = drugOrder;
//                            newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
//                            newDrugOrderTransaction.InOut = 2;
//                            if (!(bool)drugOrderDetail.DrugDone)
//                            {
//                                newDrugOrderTransaction.Amount = usedAmount;
//                                newDrugOrderTransaction.Volume = usedVolume;
//                            }
//                            else
//                            {
//                                newDrugOrderTransaction.Amount = restDose / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
//                                newDrugOrderTransaction.Volume = restDose;
//                                fullDose = true;
//                                //Buraya mesaj verdirilmesi gerekiyor.
//                            }
//                        }
//                        else
//                        {
//                            throw new Exception("Hastanın bu uygulama için belirtiğiniz miktarda dozu bulunmamaktadır.");
//                        }
//                    }
//                    else
//                    {
//                        Dictionary<object, double> patientRestDictionary = DrugOrderTransaction.GetPatientRestDose(drugOrderDetail.Material, drugOrderDetail.Episode);
//                        foreach (KeyValuePair<object, double> restDic in patientRestDictionary)
//                        {
//                            if (restDic.Value >= (double)drugOrderDetail.Amount & usedCount == 0 )
//                            {
//                                DrugOrderTransaction newDrugOrderTransaction = new DrugOrderTransaction(drugOrderDetail.ObjectContext);
//
//                                newDrugOrderTransaction.DrugOrder = (DrugOrder)restDic.Key ;
//                                newDrugOrderTransaction.DrugOrderDetail = drugOrderDetail;
//                                newDrugOrderTransaction.InOut = 2;
//                                usedCount = 1;
//                                if (!(bool)drugOrderDetail.DrugDone)
//                                {
//                                    newDrugOrderTransaction.Amount = usedAmount;
//                                    newDrugOrderTransaction.Volume = usedVolume;
//                                }
//                                else
//                                {
//                                    newDrugOrderTransaction.Amount = restDose / (double)((DrugDefinition)drugOrderDetail.Material).Volume;
//                                    newDrugOrderTransaction.Volume = restDose;
//                                    fullDose = true;
//                                    //Buraya mesaj verdirilmesi gerekiyor.
//                                }
//                                
//                            }
//                        }
//                    }
//                    
//                    if (fullDose)
//                    {
//                        foreach (DrugOrderDetail anotherDrugOrderDetail in  drugOrderDetail.KScheduleCollectedOrder.DrugOrderDetails)
//                        {
//                            if (anotherDrugOrderDetail.CurrentStateDefID == new Guid ("d4f85132-8d05-4dc7-b9b2-fc04bae622b0") & anotherDrugOrderDetail.ObjectID != drugOrderDetail.ObjectID )
//                            {
//                                anotherDrugOrderDetail.CurrentStateDefID = new Guid("cb22e74b-a2be-456f-8680-660d0b21dc24");
//                            }
//                        }
//                    }
//                    
//                    
//                    // Order Statusu güncelleniyor. SS
//                    int CompletedAplication = 0 ;
//                    int NonCompletedAplication = 0;
//                    if (drugOrder.DrugOrderDetails.Count == 1)
//                    {
//                        drugOrder.CurrentStateDefID = new Guid (DrugOrder.States.Completed.ToString());
//                    }
//                    else
//                    {
//                        foreach(DrugOrderDetail oldDrugOrderDetail in drugOrder.DrugOrderDetails)
//                        {
//                            if (oldDrugOrderDetail != drugOrderDetail)
//                            {
//                                if (oldDrugOrderDetail.CurrentStateDefID == new Guid("d39a37a6-610e-4143-aca2-691ce5818915") || oldDrugOrderDetail.CurrentStateDefID == new Guid("add6e452-c007-4849-b477-17d30400abe8"))
//                                {
//                                    CompletedAplication = CompletedAplication + 1 ;
//                                }
//                                else
//                                {
//                                    NonCompletedAplication = NonCompletedAplication + 1 ;
//                                }
//                            }
//                        }
//                        
//                        if (CompletedAplication == 0)
//                        {
//                            // drugOrder.CurrentStateDefID = new Guid("c227b72e-56bc-4279-81dd-a2be3a843ee0");
//                            
//                            drugOrder.CurrentStateDefID = DrugOrder.States.Planned;
//                            drugOrder.Update();
//                            drugOrder.CurrentStateDefID = DrugOrder.States.Continued;
//                            
//                        }
//                        else if ( drugOrder.DrugOrderDetails.Count - 1 == CompletedAplication )
//                        {
//                            // drugOrder.CurrentStateDefID = new Guid ("c423baa7-7c23-4a04-beef-0162ad204877");
//                            if(drugOrderDetail.DrugOrder.GetType()== typeof(DrugOrder))
//                                drugOrderDetail.DrugOrder.CurrentStateDefID = DrugOrder.States.Completed;
//                        }
//                    }
//                }
//                if(transDef.ToStateDefID==DrugOrderDetail.States.Cancel)
//                {
//                    DrugOrderDetail drugOrderDetail = _DrugOrderDetail;
//                    DrugOrder drugOrder = (DrugOrder)drugOrderDetail.DrugOrder;
//                    int CompletedApplication = 0 ;
//                    int NonCopmpletedAplication = 0;
//                    if (drugOrder.DrugOrderDetails.Count == 1)
//                    {
//                        drugOrder.CurrentStateDefID = new Guid ("c423baa7-7c23-4a04-beef-0162ad204877");
//                    }
//                    else
//                    {
//                        foreach(DrugOrderDetail oldDrugOrderDetail in drugOrder.DrugOrderDetails)
//                        {
//                            if (oldDrugOrderDetail != drugOrderDetail)
//                            {
//                                if (oldDrugOrderDetail.CurrentStateDefID == new Guid("d39a37a6-610e-4143-aca2-691ce5818915") || oldDrugOrderDetail.CurrentStateDefID == new Guid("add6e452-c007-4849-b477-17d30400abe8"))
//                                {
//                                    CompletedApplication = CompletedApplication + 1 ;
//                                }
//                                else
//                                {
//                                    NonCopmpletedAplication = NonCopmpletedAplication + 1 ;
//                                }
//                            }
//                        }
//                        
//                        if (CompletedApplication == 0)
//                        {
//                            drugOrder.CurrentStateDefID = new Guid("c227b72e-56bc-4279-81dd-a2be3a843ee0");
//                        }
//                        else if ( drugOrder.DrugOrderDetails.Count - 1 == CompletedApplication )
//                        {
//                            drugOrder.CurrentStateDefID = new Guid ("c423baa7-7c23-4a04-beef-0162ad204877");
//                        }
//                    }
//                }
//            }
#endregion DrugOrderDetailForm_PostScript

            }
                }
}