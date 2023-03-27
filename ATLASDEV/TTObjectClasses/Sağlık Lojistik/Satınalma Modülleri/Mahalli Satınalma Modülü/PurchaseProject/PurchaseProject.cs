
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
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
    public  partial class PurchaseProject : BasePurchaseAction, IPurchaseProjectWorkList
    {
        public partial class PurchaseProjectGlobalReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class PurchaseProjectReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetPriceFormulationCommissionMembersQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetFirmProductListReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetDirectPurchaseCommisionMembersQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetSupplyConditionRegistryReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetTenderCommisionDesicionQuery_Class : TTReportNqlObject 
        {
        }

        public partial class SatinAlmaIstekIzlemeQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetTenderCommisionMembersQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetSupplyAnalysisReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetFirmsWhichWinPurchaseReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetYearlyPurchaseDecisionReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetPurchaseProcurementReportQuery_Class : TTReportNqlObject 
        {
        }

        
                    
        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();

#endregion PostInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            



            if (TransDef != null)
            {
                Hashtable errorColl = StateValidate();
                if (errorColl.Count > 0)
                {
                    string errorString = SystemMessage.GetMessage(41);
                    for (int i = 1; i <= errorColl.Values.Count; i++)
                    {
                        errorString = errorString + errorColl[i].ToString() + "\n";
                    }

                    throw new TTUtils.TTException(errorString);
                }
                //                }
            }



#endregion PreUpdate
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            
            

            base.PostUpdate();

            if (TransDef == null)
                return;

            //Alımdan sorumlu ve istek sahibi sahalar farklı ise istek sahibi sahaya durum güncelleme gönderiyoruz
            if (string.IsNullOrEmpty(ResponsibleSiteID.ToString()) == false && string.IsNullOrEmpty(OwnerSiteID.ToString()) == false)
            {
                if (ResponsibleSiteID != OwnerSiteID)
                {
                    //TODO:Güncellemeyi Gönder
                }
            }

            //Remoting
            ResSection masterResource = MasterResource;
            MasterResource = null;
            List<TTObject> details = FillDetailsForRemote();
            //Sahadan Loj.Daireye___ HeadDoctorApproval1 --> LogisticBureauApproval
            if ((OriginalStateDef.StateDefID == PurchaseProject.States.RegionCommandCommanderApproval || OriginalStateDef.StateDefID == PurchaseProject.States.HeadDoctorApproval1) && TransDef.ToStateDefID == PurchaseProject.States.LogisticBureauApproval)
            {
               // TTMessage message = PurchaseProject.RemoteMethods.SavePurchaseProject((Guid)Sites.SiteMerkezSagKom, details);
              //  this.LBMessageID = message.MessageID;
            }

            //Loj.Daireden Sahaya Mahalli Alıma ___ LogisticBureauApproval --> ProjectCreating
            if (OriginalStateDef.StateDefID == PurchaseProject.States.LogisticBureauApproval && TransDef.ToStateDefID == PurchaseProject.States.ProjectCreating)
            {
                Guid siteID = new Guid(ResponsibleProcurementUnitDef.MilitaryUnit.Site.ObjectID.ToString());
                if (siteID != Sites.SiteMerkezSagKom)
                {
                    ResponsibleSiteID = siteID;
                   // TTMessage message = PurchaseProject.RemoteMethods.SavePurchaseProject(siteID, details);
                   // this.ResponsibleMessageID = message.MessageID;
                }
            }

            //Loj.Dairenden Sahaya Belge Düzeltme ___ LogisticBureauApproval --> ProjectRegistration
            if (OriginalStateDef.StateDefID == PurchaseProject.States.LogisticBureauApproval && TransDef.ToStateDefID == PurchaseProject.States.ProjectCreating)
            {
              //  TTMessage message = PurchaseProject.RemoteMethods.SavePurchaseProject((Guid)this.OwnerSiteID, details);
            }
            MasterResource = masterResource;


#endregion PostUpdate
        }

        protected void PostTransition_PriceFormulation2ProjectDetailing()
        {
            // From State : PriceFormulation   To State : ProjectDetailing
#region PostTransition_PriceFormulation2ProjectDetailing
            

            if(ConfirmNO == null)
            {
                if (ProcurementSource == ProcurementEnum.GeneralBudget)
                {
                    if (ConfirmNO_GB.Value.HasValue == false)
                        ConfirmNO_GB.GetNextValue();

                    ConfirmNO = ConfirmNO_GB.ToString() + "/" + DateTime.Now.Year.ToString().Substring(2);
                }
                else
                {
                    if (ConfirmNO_DS.Value.HasValue == false)
                        ConfirmNO_DS.GetNextValue();

                    ConfirmNO = ConfirmNO_DS.ToString() + "/" + DateTime.Now.Year.ToString().Substring(2);
                }
            }
            
            foreach(PurchaseProjectDetail ppd in PurchaseProjectDetails)
            {
                if(ppd.AppPriceCalculated == null)
                    continue;
                if((bool)ppd.AppPriceCalculated == false)
                {
                    ppd.CurrentStateDefID = PurchaseProjectDetail.States.Cancelled;
                    List<DemandDetail> list = new List<DemandDetail>();
                    foreach(DemandDetail dd in ppd.DemandDetails)
                        list.Add(dd);
                    
                    foreach(DemandDetail dd in list)
                        dd.PurchaseProjectDetail = null;
                }
            }
            

#endregion PostTransition_PriceFormulation2ProjectDetailing
        }

        protected void PostTransition_ContractEntry2Completed()
        {
            // From State : ContractEntry   To State : Completed
#region PostTransition_ContractEntry2Completed
            
            SendContractMessage();

#endregion PostTransition_ContractEntry2Completed
        }

        protected void PostTransition_HeadDoctorApproval12RegionCommandLogBureau()
        {
            // From State : HeadDoctorApproval1   To State : RegionCommandLogBureau
#region PostTransition_HeadDoctorApproval12RegionCommandLogBureau
            



            //            List<TTObject> list = FillDetailsForRemote();
            //
            //            TTMessage message = PurchaseProject.RemoteMethods.SavePurchaseProject(Sites.SiteMerkezSagKom, this, list);
            //            this.RegionCommandMessageID = message.MessageID;



#endregion PostTransition_HeadDoctorApproval12RegionCommandLogBureau
        }

        protected void PostTransition_HeadDoctorApproval12LogisticBureauApproval()
        {
            // From State : HeadDoctorApproval1   To State : LogisticBureauApproval
#region PostTransition_HeadDoctorApproval12LogisticBureauApproval
            
            PrepareLBApproveDetails();

#endregion PostTransition_HeadDoctorApproval12LogisticBureauApproval
        }

        protected void PostTransition_RegionCommandCommanderApproval2LogisticBureauApproval()
        {
            // From State : RegionCommandCommanderApproval   To State : LogisticBureauApproval
#region PostTransition_RegionCommandCommanderApproval2LogisticBureauApproval
            
            




            PrepareLBApproveDetails();

            List<TTObject> list = FillDetailsForRemote();

           // TTMessage message = PurchaseProject.RemoteMethods.SavePurchaseProject(Sites.SiteMerkezSagKom, list);
          //  this.LBMessageID = message.MessageID;



#endregion PostTransition_RegionCommandCommanderApproval2LogisticBureauApproval
        }

#region Methods
        public override string ToString()
        {
            return TTUtils.CultureService.GetText("M26706", "Proje No:")+ PurchaseProjectNO.Value.ToString() + " - Step: " + CurrentStateDef.ToString();
        }

        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if (ttObject.IsNew)
            {
                PurchaseProjectNO.GetNextValue();
                OwnerSiteID = SystemParameter.GetSite().ObjectID;
            }
        }


        public List<TTObject> FillDetailsForRemote() //Remote bağlantı için gönderilecek proje nesnelerini hazırlar
        {
            List<TTObject> list = new List<TTObject>();
            list.Add((TTObject)this);
            foreach (PurchaseProjectDetail ppd in PurchaseProjectDetails)
            {
                if (ppd.CurrentStateDefID != PurchaseProjectDetail.States.Cancelled)
                    list.Add((TTObject)ppd);
            }
            return list;
        }

        public void PrepareLBApproveDetails()
        //Lojistik dairenin onaylayacağı her proje detayı için default değerleri hazırlar.
        {
            LBApproveDetail det;
            foreach (PurchaseProjectDetail ppd in PurchaseProjectDetails)
            {
                if (ppd.LBApproveDetails.Count == 0)
                {
                    det = new LBApproveDetail(ObjectContext);
                    det.PurchaseProjectDetail = ppd;
                    det.Amount = 0;
                    det.ApproveType = LBApproveDetailTypeEnum.Cancel;
                    det = new LBApproveDetail(ObjectContext);
                    det.PurchaseProjectDetail = ppd;
                    det.Amount = 0;
                    det.ApproveType = LBApproveDetailTypeEnum.CounterBalance;
                    det = new LBApproveDetail(ObjectContext);
                    det.PurchaseProjectDetail = ppd;
                    det.Amount = 0;
                    det.ApproveType = LBApproveDetailTypeEnum.Internal;
                    det = new LBApproveDetail(ObjectContext);
                    det.PurchaseProjectDetail = ppd;
                    det.Amount = 0;
                    det.ApproveType = LBApproveDetailTypeEnum.Local;
                }
            }
        }


        public void SetOrderNOs()
        {
            //Proje detaylarındaki sıra no.larını düzenler
            int orderNo = 0;
            foreach (PurchaseProjectDetail ppd in PurchaseProjectDetails)
            {
                orderNo++;
                ppd.OrderNO = orderNo;
            }
        }

        public int GetTotalProposalCount(bool IncludeDeniedProposals)
        {
            //Toplam teklif sayısını parametreye göre iptaller dahil yada hariç olarak bulur
            int PropCnt = 0;
            int EPropCnt = 0;

            foreach (Proposal p in Proposals)
            {
                foreach (ProposalDetail pd in p.ProposalDetails)
                {
                    if (pd.Status == ProposalDetailStatusEnum.Best || pd.Status == ProposalDetailStatusEnum.Second || pd.Status == ProposalDetailStatusEnum.Lost)
                    {
                        PropCnt++;
                        EPropCnt++;
                    }
                    else if (pd.Status == ProposalDetailStatusEnum.Denied)
                    {
                        PropCnt++;
                    }
                }
            }

            if (IncludeDeniedProposals)
                return PropCnt;
            else
                return EPropCnt;
        }


        public void GetAvailableProjectDetails(ArrayList ResourcesColl, ArrayList ItemColl, ArrayList PIClassColl)
        {
            //Verilen parametreler dahilinde ihaleye çıkabilecek durumdaki istekleri gruplayarak getirir
            foreach (PurchaseProjectDetail ppd in PurchaseProjectDetails)
            {
                ppd.DemandDetails.Clear();
            }
            PurchaseProjectDetails.Clear();


            //Listeleme Kriterlerini Belirleyelim
            bool fresource = true;
            bool checkResource = false;
            bool fItem = true;
            bool checkItem = false;
            bool fPIClass = true;
            bool checkPIClass = false;

            if (ResourcesColl.Count > 0) //Servis Filtresi
                checkResource = true;

            if (ItemColl.Count > 0) //Satınalma Kalemi Filtresi
                checkItem = true;

            foreach (PurchaseProjectDetail ppd in PurchaseProjectDetails)
            {
                ppd.PurchaseProject = null;
            }

            IList<DemandTypeEnum> list = new List<DemandTypeEnum>();
            list.Add(DemandTypeEnum.InterimPurchase);
            list.Add(DemandTypeEnum.ServicePurchase);

            foreach (Demand d in Demand.GetAvailableDemands((TTObjectContext)ObjectContext, list))
            {
                foreach (DemandDetail dd in d.DemandDetails)
                {
                    if (dd.PurchaseProjectDetail == null)
                    {
                        if (checkResource)
                        {
                            if (ResourcesColl.Contains(dd.Demand.MasterResource))
                                fresource = true;
                            else
                                fresource = false;
                        }

                        if (checkItem)
                        {
                            if (ItemColl.Contains(dd.PurchaseItemDef))
                                fItem = true;
                            else
                                fItem = false;
                        }

                        if (fresource && fItem)
                        {
                            bool NewRec = true;
                            foreach (PurchaseProjectDetail existingppd in PurchaseProjectDetails)
                            {
                                if (dd.PurchaseItemDef != null && existingppd.PurchaseItemDef != null)
                                {
                                    if (dd.PurchaseItemDef == existingppd.PurchaseItemDef)//Varsa Amount Update Et
                                    {
                                        NewRec = false;
                                        existingppd.RequestedAmount += dd.Amount;
                                        dd.PurchaseProjectDetail = existingppd;
                                    }
                                }
                            }
                            if (NewRec || dd.PurchaseItemDef == null)//Yoksa projeye yeni detail ekle
                            {
                                PurchaseProjectDetail ppd = new PurchaseProjectDetail(ObjectContext);
                                ppd.CurrentStateDefID = PurchaseProjectDetail.States.New;
                                ppd.OrderNO = PurchaseProjectDetails.Count + 1;
                                ppd.PurchaseItemDef = dd.PurchaseItemDef;
                                ppd.RequestedAmount = dd.Amount;
                                if(dd.PurchaseItemDef.StockCard != null)
                                    ppd.NSN = dd.PurchaseItemDef.StockCard.NATOStockNO;
                                ppd.DemandDetails.Add(dd);
                                ppd.PurchaseProject = this;
                            }
                        }
                    }
                }
            }
        }

        public void PrepareContracts()
        {
            //            //Kazanan firmalar için ilgili malzemeleri barındıran sözleşmeleri hazırlar
            //            this.ClearContracts();
            //            //            if(this.PurchaseTypeMatPro == PurchaseTypeEnum_Material_Procedure.ProcedureProcurement)
            //            //                return;
            //
            //            bool addContract = false;
            //            foreach (Proposal p in this.Proposals)
            //            {
            //                addContract = false;
            //                foreach (ProposalDetail pd in p.ProposalDetails)
            //                {
            //                    if (pd.Status == ProposalDetailStatusEnum.Best)
            //                    {
            //                        addContract = true;
            //                        break;
            //                    }
            //                }
            //
            //                if (addContract)
            //                {
            //                    double totalContractValue = 0;
            //                    double totalProposalPrices = 0;
            //                    int valPropc = 0;
            //                    Contract contract = new Contract(this.ObjectContext);
            //                    contract.CurrentStateDefID = Contract.States.Active;
            //                    contract.PurchaseProject = this;
            //                    contract.Supplier = p.Supplier;
            //                    foreach (ProposalDetail pd in p.ProposalDetails)
            //                    {
            //                        if (pd.Status == ProposalDetailStatusEnum.Best)
            //                        {
            //                            ContractDetail cd = new ContractDetail(this.ObjectContext);
            //                            cd.CurrentStateDefID = ContractDetail.States.New;
            //                            cd.PurchaseItemDef = pd.PurchaseItemDef;
            ////                            if (pd.Material == null && this.PurchaseTypeMatPro == PurchaseTypeEnum_Material_Procedure.MaterialProcurement)
            ////                                throw new TTUtils.TTException(SystemMessage.GetMessage(27));
            //                            if (pd.Material != null)
            //                                cd.Material = pd.Material;
            //                            cd.Contract = contract;
            //                            cd.Amount = pd.Amount;
            //                            totalContractValue += (double)pd.ProposalPrice * (double)cd.Amount;
            //                            cd.PurchaseProjectDetail = pd.PurchaseProjectDetail;
            //                            contract.ConclusionNo = pd.PurchaseProjectDetail.ConclusionNO;
            //                            pd.PurchaseProjectDetail.ContractDetail = cd;
            //                            cd.UnitPrice = pd.ProposalPrice;
            //                            cd.TotalPropCount = pd.PurchaseProjectDetail.ProposalDetails.Count;
            //                            foreach (ProposalDetail pd1 in pd.PurchaseProjectDetail.ProposalDetails)
            //                            {
            //                                if (pd1.Status != ProposalDetailStatusEnum.Denied && pd1.ProposalPrice != null)
            //                                {
            //                                    valPropc++;
            //                                    totalProposalPrices += (double)pd1.ProposalPrice;
            //                                }
            //                            }
            //                            cd.ValidPropCount = valPropc;
            //                            cd.AverageProposalPrice = totalProposalPrices / (double)cd.PurchaseProjectDetail.ProposalDetails.Count;
            //                            totalProposalPrices = 0;
            //                            cd.ProposalDetails.Add(pd);
            //                            valPropc = 0;
            //                        }
            //                        else if (pd.Status == ProposalDetailStatusEnum.New)
            //                        {
            //                            pd.Status = ProposalDetailStatusEnum.Lost;
            //                        }
            //                    }
            //                    contract.TotalContractValue = totalContractValue;
            //                    double kararPulu = Convert.ToDouble(SystemParameter.GetParameterValue("PPKararPuluOrani", "0"));
            //                    if (kararPulu == 0)
            //                        throw new TTUtils.TTException(SystemMessage.GetMessage(28));
            //                    contract.DecisionStampAmount = Convert.ToDouble(totalContractValue * kararPulu);
            //                    double katiTeminat = Convert.ToDouble(SystemParameter.GetParameterValue("PPKatiTeminatOrani", "0"));
            //                    if (katiTeminat == 0)
            //                        throw new TTUtils.TTException(SystemMessage.GetMessage(29));
            //                    contract.ContractBondAmount = Convert.ToDouble(totalContractValue * katiTeminat);
            //                    double sozlesmePulu = Convert.ToDouble(SystemParameter.GetParameterValue("PPSozlesmePuluOrani", "0"));
            //                    if (sozlesmePulu == 0)
            //                        throw new TTUtils.TTException(SystemMessage.GetMessage(30));
            //                    contract.ContractStampAmount = Convert.ToDouble(totalContractValue * sozlesmePulu);
            //                }
            //            }
        }

        public void SendContractMessage()
        {
            //İstek sahiplerine sistem üzerinden ihalenin durumu ile ilgili bilgi mesajı gönderir
            ResUser resUser = null;
            ArrayList demands = new ArrayList();
            foreach (PurchaseProjectDetail ppd in PurchaseProjectDetails)
            {
                if (ppd.CurrentStateDefID != PurchaseProjectDetail.States.Cancelled)
                {
                    foreach (DemandDetail dd in ppd.DemandDetails)
                    {
                        if (dd.Cancelled == false && dd.Demand.IsCancelled == false && demands.Contains(dd.Demand) == false)
                        {
                            demands.Add(dd.Demand);
                        }
                    }
                }
            }

            foreach (Demand d in demands)
            {
                foreach (TTObjectState objectState in d.GetStateHistory())
                {
                    if (objectState.StateDefID == Demand.States.New)
                    {
                        resUser = (ResUser)objectState.User.UserObject;
                        if (resUser != null)
                        {
                            UserMessage message = new UserMessage(ObjectContext);
                            message.IsSystemMessage = true;
                            message.MessageDate = DateTime.Now;
                            message.Subject = TTUtils.CultureService.GetText("M27073", "Tedarik Bilgilendirmesi");
                            message.SenderStatus   = MessageStatusEnum.Sent;
                            message.ReceiverStatus = MessageStatusEnum.UnRead;
                            message.ToUser = resUser;
                            message.Sender = resUser;
                            message.SetRTFBody(d.RequestNo + " no.lu isteğinizin alım süreci tamamlanıp sözleşmesi yapılmıştır.");
                            break;
                        }
                    }
                }
            }
        }

        public void ClearContracts()
        {
            //İhaleye bağlı tüm sözleşmeleri iptal eder
            List<Contract> delList = new List<Contract>();
            foreach (Contract c in Contracts)
            {
                c.ContractDetails.DeleteChildren();
                delList.Add(c);
            }

            foreach (Contract cont in delList)
            {
                ((ITTObject)cont).Delete();
            }
        }

        public Dictionary<FirmDocument, FirmDocument> GetPurchasingDocuments()
        {
            Dictionary<FirmDocument, FirmDocument> docs = new Dictionary<FirmDocument, FirmDocument>();
            PurchaseTypeDefinition ptd = PurchaseTypeDefinition;
            foreach (FirmDocument fd in ptd.FirmDocuments)
            {
                docs.Add(fd, fd);
            }
            return docs;
        }

        public Dictionary<PurchasingDocumentState, PurchasingDocumentState> GetMissingDocuments()
        {
            //İhale tipine göre zorunlu olan belgeler arasından eksik belgeleri tespit eder
            Dictionary<PurchasingDocumentState, PurchasingDocumentState> missingDocs = new Dictionary<PurchasingDocumentState, PurchasingDocumentState>();
            foreach (PurchaseProjectProposalFirm pppf in PurchaseProjPropFirms)
            {
                if ((bool)pppf.Deny == false)
                {
                    foreach (PurchasingDocumentState pds in pppf.PurchasingDocumentStates)
                    {
                        if ((bool)pds.Needed)
                        {
                            if (!(bool)pds.Approved)
                            {
                                missingDocs.Add(pds, pds);
                            }
                        }
                    }
                }
            }
            return missingDocs;
        }




        public void PrepareDocuments(Supplier supplier)
        {
            //Bir ihalenin tipine göre hangi belgeler zorunluysa onları ilgili sınıflara doldurur
            foreach (PurchaseProjectProposalFirm pf in PurchaseProjPropFirms)
            {
                if (pf.Supplier == supplier)
                {
                    pf.CurrentStateDefID = PurchaseProjectProposalFirm.States.Cancelled;
                }
            }

            //İhale türünün gerekli belgelerini bulalym
            Dictionary<FirmDocument, FirmDocument> DocColl = GetPurchasingDocuments();
            PurchaseProjectProposalFirm pppf = new PurchaseProjectProposalFirm(ObjectContext);
            pppf.CurrentStateDefID = PurchaseProjectProposalFirm.States.New;
            pppf.Supplier = supplier;
            PurchaseProjPropFirms.Add(pppf);
            //Her firma için belge kayıtlarını hazırlayalım
            foreach (NeededDocument nd in NeededDocuments)
            {
                if (nd.CurrentStateDefID != NeededDocument.States.Cancelled)
                {
                    PurchasingDocumentState pds = new PurchasingDocumentState(ObjectContext);
                    pds.CurrentStateDefID = PurchasingDocumentState.States.New;
                    pds.PurchaseProjectProposalFirm = pppf;
                    pds.PurchasingDocsForFirmsDef = nd.PurchasingDocsForFirmsDef;
                    pds.DocName = nd.DocName;
                    pds.Needed = nd.Mandatory;
                    pds.Update();
                }
            }
            pppf.Update();
        }

        public void CreateNeededDocuments()
        {
            //Zorunlu belgeleri ihalenin zorunlu belgelerini temsil eden NeededDocument sınıfına doldurur
            foreach (NeededDocument ndc in NeededDocuments)
            {
                ndc.CurrentStateDefID = NeededDocument.States.Cancelled;
            }

            //Yhale türünün gerekli belgelerini bulalym
            Dictionary<FirmDocument, FirmDocument> DocColl = GetPurchasingDocuments();

            foreach (KeyValuePair<FirmDocument, FirmDocument> kp in DocColl)
            {
                NeededDocument nd = new NeededDocument(ObjectContext);
                nd.CurrentStateDefID = NeededDocument.States.New;
                FirmDocument fd = (FirmDocument)kp.Key;
                nd.PurchasingDocsForFirmsDef = fd.PurchasingDocsForFirmsDef;
                nd.DocName = fd.PurchasingDocsForFirmsDef.DocumentName;
                nd.Mandatory = fd.Mandatory;
                NeededDocuments.Add(nd);
            }
        }

        public Hashtable StateValidate()
        {
            //İhalede her adım atlarken çalışarak ilgili adıma ait hataları kontrol eder
            Hashtable errorColl = new Hashtable();
            int ErrorCount = 0;
            if (TransDef != null)
            {
                //PROJE OLUŞTURMA
                if (TransDef.FromStateDefID == PurchaseProject.States.ProjectRegistration)
                {
                    bool missing = false;

                    foreach (PurchaseProjectDetail ppd in PurchaseProjectDetails)
                    {
                        if (ppd.RequestedAmount == null)
                        {
                            missing = true;
                        }
                    }

                    if (missing)
                    {
                        ErrorCount++;
                        errorColl.Add(ErrorCount, TTUtils.CultureService.GetText("M26528", "Miktarlar boş olamaz"));
                    }
                }

                ////LOJ.DAYRE ONAY ////
                else if (TransDef.FromStateDefID == PurchaseProject.States.LogisticBureauApproval)
                {
                    if (TransDef.ToStateDefID != PurchaseProject.States.ProjectRegistration)
                    {
                        bool missing = false;

                        foreach (PurchaseProjectDetail ppd in PurchaseProjectDetails)
                        {
                            if (ppd.Amount == null)
                            {
                                missing = true;
                            }
                        }

                        if (missing)
                        {
                            ErrorCount++;
                            errorColl.Add(ErrorCount, TTUtils.CultureService.GetText("M26636", "Onaylanan miktarlar boş olamaz"));
                        }
                    }
                }


                //// PROJE DETAYLANDIRMA ///////
            }
            return errorColl;
        }

        public void SetActCount()
        {
            int i = 0;
            foreach (PurchaseProjectDetail ppd in PurchaseProjectDetails)
            {
                if (ppd.CurrentStateDefID != PurchaseProjectDetail.States.Cancelled)
                    i++;
            }

            ActCount = i;

        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PurchaseProject).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PurchaseProject.States.PriceFormulation && toState == PurchaseProject.States.ProjectDetailing)
                PostTransition_PriceFormulation2ProjectDetailing();
            else if (fromState == PurchaseProject.States.ContractEntry && toState == PurchaseProject.States.Completed)
                PostTransition_ContractEntry2Completed();
            else if (fromState == PurchaseProject.States.HeadDoctorApproval1 && toState == PurchaseProject.States.RegionCommandLogBureau)
                PostTransition_HeadDoctorApproval12RegionCommandLogBureau();
            else if (fromState == PurchaseProject.States.HeadDoctorApproval1 && toState == PurchaseProject.States.LogisticBureauApproval)
                PostTransition_HeadDoctorApproval12LogisticBureauApproval();
            else if (fromState == PurchaseProject.States.RegionCommandCommanderApproval && toState == PurchaseProject.States.LogisticBureauApproval)
                PostTransition_RegionCommandCommanderApproval2LogisticBureauApproval();
        }

    }
}