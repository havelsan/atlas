
//$A0262BC5
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TTStorageManager.Security;
using Core.Security;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class PhysiotherapyRequestServiceController
    {
        partial void PreScript_PhysiotherapyRequestPlannedForm(PhysiotherapyRequestPlannedFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTObjectContext objectContext)
        {
            //viewModel.IsPhysiotherapyRequestFormUsing = TTObjectClasses.SystemParameter.GetParameterValue("USEPHYSIOTHERAPYREQUESTFORM", "") == "TRUE" ? true : false;

            #region Týbbi bilgiler
            MedicalInformation MedicalInfo = physiotherapyRequest.Episode.Patient.MedicalInformation;
            if (MedicalInfo != null)
            {
                StringBuilder medicalInfoStr = new StringBuilder();
                if (MedicalInfo.HeartFailure == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "HeartFailure").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Broken == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Broken").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Pregnancy == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Pregnancy").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Diabetes == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Diabetes").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Malignancy == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Malignancy").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.MetalImplant == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "MetalImplant").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.VascularDisorder == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "VascularDisorder").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Infection == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Infection").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Stent == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Stent").FirstOrDefault().Caption);
                    medicalInfoStr.Append(", ");
                }
                if (MedicalInfo.Other == true)
                {
                    medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Other").FirstOrDefault().Caption);
                }
                viewModel.MedicalInfo = medicalInfoStr.ToString();
            }
            #endregion

            #region Anamnez Bilgileri

            if (physiotherapyRequest.Episode.Complaint != null)
            {
                viewModel.AnamnesisComplaintInfo = physiotherapyRequest.Episode.Complaint.ToString();
                viewModel.HideAnamnesisInfoButton = false;
            }
            if (physiotherapyRequest.Episode.PatientHistory != null)
            {
                viewModel.AnamnesisPatientHistoryInfo = physiotherapyRequest.Episode.PatientHistory.ToString();
                viewModel.HideAnamnesisInfoButton = false;
            }
            if (physiotherapyRequest.Episode.PhysicalExamination != null)
            {
                viewModel.AnamnesisPhysicalExaminationInfo = physiotherapyRequest.Episode.PhysicalExamination.ToString();
                viewModel.HideAnamnesisInfoButton = false;
            }
            if (physiotherapyRequest.Episode.MTSConclusion != null)
            {
                viewModel.AnamnesisMTSConclusionInfo = physiotherapyRequest.Episode.MTSConclusion.ToString();
                viewModel.HideAnamnesisInfoButton = false;
            }
            #endregion


            viewModel.IsSessionRecalculate = false;//seans öteleme için tüm iþlemlerin tarihleri deðiþtirilsin mi?//true ise seans ötelenir

            this.removeOutgoingTransitions(viewModel, physiotherapyRequest);

            viewModel.PatientObjectId = physiotherapyRequest.Episode.Patient.ObjectID.ToString();

            #region requesti olmayan orderDetailler baðlanýyor
            foreach (var item in physiotherapyRequest.PhysiotherapyOrders)
            {
                foreach (var detailItem in item.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyRequest == null))
                {
                    //if (detailItem.PhysiotherapyRequest == null && detailItem.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled)
                    //{
                    detailItem.PhysiotherapyRequest = physiotherapyRequest;
                    //}
                }
            }
            #endregion

            #region hatalý veriler düzeltiliyor
            foreach (var detailItem in physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyOrder == null))
            {
                //if (detailItem.PhysiotherapyOrder == null && detailItem.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled)
                //{
                detailItem.CurrentStateDefID = PhysiotherapyOrderDetail.States.Cancelled;
                //}
            }
            #endregion

            viewModel.OrderDetailInfoList = new List<PlannedOrderDetailSessionInfo>();

            int appliedSessionCount = 0;

            viewModel.CanComplatePhysiotherapyRequest = true;
            viewModel.expandedRowKeys = 1;
            PhysiotherapyOrderDetail lastCompletedOrderDetail = null;


            ////-------------------------------------------------------------------------------------------------------------------------------------------------------
            BindingList<PhysiotherapyOrderDetail.GetPhysiotherapyTreeList_Class> PhysiotherapyTreeList = PhysiotherapyOrderDetail.GetPhysiotherapyTreeList(physiotherapyRequest.ObjectID.ToString());
            if (PhysiotherapyTreeList.Count() > 0)
            {
                var PhySessionsList = PhysiotherapyTreeList.GroupBy(c => c.Physiotherapysessionid);
                int sessionCount = 1;
                int keycount = 1;
                foreach (var phySessionItem in PhySessionsList)
                {
                    bool IsAdditionalTreatment = false;
                    int keycountForDetail = keycount;
                    List<PlannedPhyOrderDetailInfo> OrderDetailList = new List<PlannedPhyOrderDetailInfo>();// tedavi listesi

                    var detailLists = PhysiotherapyTreeList.Where(x => x.Physiotherapysessionid == phySessionItem.Key);
                    foreach (var detailItem in detailLists)
                    {
                        keycountForDetail++;

                        PlannedPhyOrderDetailInfo _detailInfo = new PlannedPhyOrderDetailInfo
                        {
                            ApplicationAreaDef = detailItem.Applicationareadef != null ? detailItem.Applicationareadef : "",
                            ApplicationAreaInfo = detailItem.Applicationareainfo != null ? detailItem.Applicationareainfo : "",
                            Dose = detailItem.Dose,
                            Duration = detailItem.Duration.ToString(),
                            IsAdditionalProcess = detailItem.IsAdditionalProcess != null ? detailItem.IsAdditionalProcess.Value : false,//ek iþlem

                            OrderDetailCurrentStateDefID = detailItem.CurrentStateDefID.Value,
                            OrderDetailObjectID = detailItem.Orderdetailobjectid.Value,
                            OrderDetailObjectDef = detailItem.Orderdetailobjectdef,
                            OrderDetailPlannedDate = detailItem.Orderdetailplanneddate.Value,
                            OrderObjectID = detailItem.Orderobjectid.Value,

                            Physiotherapist = detailItem.Physiotherapist != null ? detailItem.Physiotherapist : "",
                            PhysiotherapyState = Common.GetDescriptionOfDataTypeEnum(detailItem.PhysiotherapyState),
                            PlannedDate = "",
                            SessionNumber = detailItem.SessionNumber.ToString() != null ? detailItem.SessionNumber.Value.ToString() : "",
                            TreatmentDiagnosisUnit = detailItem.Treatmentdiagnosisunit,
                            ProcedureObject = detailItem.Procedureobject != null ? detailItem.Procedureobject : "",
                            Package = detailItem.Package != null ? detailItem.Package : "",
                            PhyOrderIsPackageExists = detailItem.Package != null ? true : false,
                            TreatmentProperties = detailItem.TreatmentProperties != null ? detailItem.TreatmentProperties : "",
                            DoseDurationInfo = detailItem.DoseDurationInfo,
                            IsAdditionalTreatment = detailItem.IsAdditionalTreatment != null ? detailItem.IsAdditionalTreatment.Value : false,//ek tedavi
                            KeyNumber = keycountForDetail.ToString(),
                            PhysiotherapySessionId = detailItem.Physiotherapysessionid.ToString(),
                            PhysiotherapySessionDef = detailItem.Physiotherapysessiondef
                        };

                        OrderDetailList.Add(_detailInfo);
                        if (_detailInfo.IsAdditionalTreatment == true)
                        {
                            IsAdditionalTreatment = _detailInfo.IsAdditionalTreatment;//Ek Tedavi var ise true set et
                        }

                    }

                    PlannedOrderDetailSessionInfo PlannedPhyOrderDetailInfo = new PlannedOrderDetailSessionInfo
                    {
                        OrderDetailList = OrderDetailList,
                        ApplicationAreaDef = "",
                        ApplicationAreaInfo = "",
                        Dose = "",
                        Duration = "",
                        IsAdditionalProcess = false,

                        OrderDetailCurrentStateDefID = new Guid(),
                        OrderDetailObjectID = new Guid(),
                        OrderDetailObjectDef = "",
                        OrderDetailPlannedDate = DateTime.Now,
                        OrderObjectID = new Guid(),

                        Physiotherapist = "",
                        PhysiotherapyState = null,
                        PlannedDate = (IsAdditionalTreatment == true ? "Ek Tedavi " : "Seans : ") + sessionCount.ToString() + " - " + phySessionItem.FirstOrDefault().Physessionplanneddate.Value.ToShortDateString(),
                        SessionNumber = "!Seans : " + sessionCount.ToString(),
                        TreatmentDiagnosisUnit = "",
                        ProcedureObject = "",
                        Package = "",
                        PhyOrderIsPackageExists = false,
                        TreatmentProperties = "",
                        DoseDurationInfo = "",
                        IsAdditionalTreatment = false,
                        KeyNumber = keycount.ToString(),
                        PhysiotherapySessionId = phySessionItem.FirstOrDefault().Physiotherapysessionid.ToString(),
                        PhysiotherapySessionDef = phySessionItem.FirstOrDefault().Physiotherapysessiondef.ToString()
                    };
                    viewModel.OrderDetailInfoList.Add(PlannedPhyOrderDetailInfo);
                    sessionCount++;
                    keycountForDetail++;
                    keycount = keycountForDetail;
                    if (OrderDetailList.Where(d => d.OrderDetailCurrentStateDefID == PhysiotherapyOrderDetail.States.Completed).Count() > 0)
                    {
                        appliedSessionCount++;
                    }
                    if (phySessionItem.FirstOrDefault().Physessionplanneddate.Value.Date == Common.RecTime().Date)//bugünün seansýnýn listede açýk olarak geleceði belirtilecek
                    {
                        viewModel.expandedRowKeys = Convert.ToInt32(PlannedPhyOrderDetailInfo.KeyNumber);
                    }
                }
            }
            //else
            //{
            //    //Eðer hiç iþlem eklenmemiþse hata verme
            //    throw new Exception("Seans Hatasý!!!");
            //}

            ////-------------------------------------------------------------------------------------------------------------------------------------------------------

            viewModel.SessionChangedDate = DateTime.Now;

            viewModel.LastOrderDetailStartDate = Common.RecTime();
            viewModel.LastOrderDetailFinishDate = Common.RecTime();
            if (lastCompletedOrderDetail != null)//son seans tamamlama bilgileri tamamlama popup'ýna set ediliyor
            {
                TimeSpan startTs = lastCompletedOrderDetail.StartDate.Value.TimeOfDay;
                viewModel.LastOrderDetailStartDate = viewModel.LastOrderDetailStartDate.Date + startTs;

                TimeSpan finishTs = lastCompletedOrderDetail.FinishDate.Value.TimeOfDay;
                viewModel.LastOrderDetailFinishDate = viewModel.LastOrderDetailFinishDate.Date + finishTs;

                viewModel.LastOrderDetailResponsiblePhysiotherapist = lastCompletedOrderDetail.StarterResUser;

            }

            viewModel.PhysiotherapySessionRate = TTUtils.CultureService.GetText("M27137", "Uygulanan seans : ") + appliedSessionCount.ToString() + " / Toplam seans : " + viewModel.OrderDetailInfoList.Count().ToString();


            viewModel.HasRole_Fizyoterapi_Uygulamasi_Uygulama = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Uygulamasi_Uygulama);
            viewModel.HasRole_Fizyoterapi_Uygulamasi_Durdurma = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Uygulamasi_Durdurma);
            viewModel.HasRole_Fizyoterapi_Uygulamasi_Hasta_Gelmedi = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Uygulamasi_Hasta_Gelmedi);
            viewModel.HasRole_Fizyoterapi_Uygulamasi_Iptal_Et = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Uygulamasi_Iptal_Et);
            viewModel.HasRole_Fizyoterapi_Tarih_Guncelleme = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Tarih_Guncelleme);
            viewModel.HasRole_Fizyoterapi_Ek_Islem = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Ek_Islem);
            viewModel.HasRole_Fizyoterapi_Uygulamasi_Geri_Alma = Common.CurrentUser.HasRole(TTRoleNames.Fizyoterapi_Uygulamasi_Geri_Alma);

            // NOT: alltaki viewmodel için kullanýlacak
            viewModel.ProcedureObjectDataSource = PhysiotherapyDefinition.GetAllPhysiotherapyDefinitions(new TTObjectContext(true)).ToArray();

            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalýþmamalý
            viewModel.GridTreatmentMaterialsGridList = viewModel.GridTreatmentMaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();

            //Foreach bloðu local query ile materialler çekilirken tüm materialler alýnamadýðý için oluþturuldu.
            foreach (var item in viewModel.GridTreatmentMaterialsGridList)
            {
                var a = item.Material;
            }
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();

        }

        public List<TreatmentDiagnosisUnitInfo> GetTreatmentDiagnosisUnitInfos(Guid PhysiotherapyRequestObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                ResUser user = (ResUser)Common.CurrentUser.UserObject;
                var usersUnits = user.UserResources.Where(c => c.Resource.ObjectDef.Name.ToUpper().ToString() == "RESTREATMENTDIAGNOSISUNIT");
                List<Guid> userUnitIDs = new List<Guid>();
                if (usersUnits != null)
                {
                    foreach (var unit in usersUnits)
                    {
                        userUnitIDs.Add(unit.Resource.ObjectID);
                    }
                }

                List<TreatmentDiagnosisUnitInfo> TreatmentDiagnosisUnitInfos = new List<TreatmentDiagnosisUnitInfo>();
                if (userUnitIDs.Count > 0)
                {
                    foreach (var item in PhysiotherapyOrder.GetDistinctTreatmentDiagnosisUnitsByRequest(PhysiotherapyRequestObjectID, userUnitIDs, null))
                    {
                        if (item.TreatmentDiagnosisUnit != null)
                        {
                            var info = new TreatmentDiagnosisUnitInfo();
                            var unit = new ResTreatmentDiagnosisUnit();
                            unit = (ResTreatmentDiagnosisUnit)objectContext.GetObject<ResTreatmentDiagnosisUnit>(new Guid(item.TreatmentDiagnosisUnit?.ToString()), false);
                            info.TreatmentDiagnosisUnitID = unit.ObjectID;
                            info.TreatmentDiagnosisUnitName = unit.Name;
                            var treatmentNote = PhysiotherapyTreatmentNote.GetTreatmentNoteByEpisodeActionAndUnit(objectContext, PhysiotherapyRequestObjectID, info.TreatmentDiagnosisUnitID);
                            info.TreatmentNote = treatmentNote.Count() > 0 ? treatmentNote.FirstOrDefault().Description.ToString() : "";
                            info.TreatmentNoteId = treatmentNote.Count() > 0 ? treatmentNote.FirstOrDefault().ObjectID.ToString() : "";
                            if (item.CurrentStateDefID == PhysiotherapyOrder.States.Completed)
                                info.State = "Sonlandýrýldý";
                            else if (item.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception)
                                info.State = "Yeni";
                            TreatmentDiagnosisUnitInfos.Add(info);
                        }
                    }
                }
                return TreatmentDiagnosisUnitInfos;
            }
        }

        public PhysiotherapyRequestPlannedFormViewModel GetPhysiotherapyOrderAndData(Guid PhysiotherapyRequestObjectID, Guid PhysiotherapyRequestObjectDefID)
        {
            //public PhysiotherapyRequestPlannedFormViewModel CompleteSelectedSessionsByUnit(Guid PhysiotherapyRequestObjectID, Guid PhysiotherapyRequestObjectDefID, Guid TreatmentDiagnosisUnitID
            using (var objectContext = new TTObjectContext(false))
            {

                PhysiotherapyRequest physiotherapyRequest = objectContext.GetObject(PhysiotherapyRequestObjectID, PhysiotherapyRequestObjectDefID) as PhysiotherapyRequest;

                PhysiotherapyRequestPlannedFormViewModel viewModel = new PhysiotherapyRequestPlannedFormViewModel();
                viewModel.PhysiotherapyOrderList = new List<OrderInfo>();/*&& c.CurrentStateDefID != PhysiotherapyOrder.States.Completed*/
                foreach (var order in physiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID != PhysiotherapyOrder.States.Cancelled))
                {
                    OrderInfo _orderInfo = new OrderInfo
                    {
                        ApplicationArea = order?.FTRApplicationAreaDef?.ftrVucutBolgesiAdi,
                        ApplicationAreaInfo = order.ApplicationArea != null ? order.ApplicationArea : "",
                        Dose = order.Dose,
                        Duration = order.Duration.ToString(),
                        CurrentStateDefID = order.CurrentStateDefID.Value,
                        ProcedureObject = order.ProcedureObject.Name,
                        SessionCount = order.SessionCount.Value,
                        TreatmentDiagnosisUnit = order.TreatmentDiagnosisUnit.Name,
                        TreatmentProperties = order.TreatmentProperties,
                        IsPlannedBefore = order.PhysiotherapyOrderDetails.Count() > 0 ? true : false,
                        OrderObjectId = order.ObjectID,
                        OrderObjectDefId = order.ObjectDef.ID
                    };
                    viewModel.PhysiotherapyOrderList.Add(_orderInfo);
                }


                return viewModel;
            }
        }

        partial void PostScript_PhysiotherapyRequestPlannedForm(PhysiotherapyRequestPlannedFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (viewModel.selectedPhysiotherapyOrderPlannedFormViewModel != null)
            {
                PhysiotherapyOrderServiceController.SavePhysiotherapyOrderPlannedFormViewModelObject(objectContext, viewModel.selectedPhysiotherapyOrderPlannedFormViewModel);
            }
            if (transDef != null && transDef.ToStateDefID == PhysiotherapyRequest.States.Completed)
            {
                var executedPhysiotherapyOrderDetails = physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution);
                if (executedPhysiotherapyOrderDetails.Count() > 0)
                {
                    foreach (var detail in executedPhysiotherapyOrderDetails)
                    {
                        detail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Aborted;//Yeni Durumunda olan Ýþlemler durduruldu durumuna çekiliyor!
                        detail.PhysiotherapyState = PhysiotherapyStateEnum.Aborted;
                        detail.IsChangedAutomatically = true;
                    }
                }
                if (physiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID == PhysiotherapyOrder.States.Aborted || c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception || c.CurrentStateDefID == PhysiotherapyOrder.States.Rejected).Count() > 0)//Tamamlanmamýþ iþlemler tamamlanýyor!
                {
                    foreach (var order in physiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID == PhysiotherapyOrder.States.Aborted || c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception || c.CurrentStateDefID == PhysiotherapyOrder.States.Rejected))
                    {
                        order.CurrentStateDefID = PhysiotherapyOrder.States.Completed;
                        order.IsChangedAutomatically = true;
                    }
                }

            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Uygulamasi_Uygulama)]
        public PhysiotherapyRequestPlannedFormViewModel CompleteSelectedProceduresByID(PhysiotherapyRequestPlannedFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PhysiotherapyRequest request = objectContext.GetObject(viewModel._PhysiotherapyRequest.ObjectID, viewModel._PhysiotherapyRequest.ObjectDef) as PhysiotherapyRequest;
                DateTime subEpisodeOpeningDate = request.SubEpisode.OpeningDate.Value;
                IsSessionCompleted(request);
                if (request.SubEpisode.InpatientStatus == InpatientStatusEnum.Discharged)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M25799", "Hasta taburcu edildiði için seçilileri tamamla iþlemi yapamazsýnýz!"));
                }
                else
                {
                    List<PlannedPhyOrderDetailInfo> model = viewModel.selectedRowKeysResultList.Where(c => c.OrderDetailCurrentStateDefID != PhysiotherapyOrderDetail.States.Completed).ToList();
                    List<PhysiotherapyOrderDetail> podList = new List<PhysiotherapyOrderDetail>();

                    for (int i = 0; i < model.Count; i++)
                    {
                        PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(model[i].OrderDetailObjectID, model[i].OrderDetailObjectDef) as PhysiotherapyOrderDetail;
                        podList.Add(orderDetail);

                        if (model[i].StartDate != null)
                        {
                            if (subEpisodeOpeningDate > model[i].StartDate)//SubEpisode açýlýþ tarihinden önce tamamlanan iþlem olursa hata verilecek!
                            {
                                throw new Exception("F.T.R. istek tarihinden önce iþlem tamamlanamaz!");
                            }
                            orderDetail.StartDate = model[i].StartDate;
                            if (orderDetail.PlannedDate != null)
                            {   //Planlama tarihinin saati iþlem tamamlanýrken iþlemin tamamlandý dediði saati set ediyor.
                                DateTime plannedDateAndTime = orderDetail.PlannedDate.Value.Date + orderDetail.StartDate.Value.TimeOfDay;
                                orderDetail.PlannedDate = plannedDateAndTime;
                            }
                        }
                        if (model[i].FinishDate != null)
                        {
                            orderDetail.FinishDate = model[i].FinishDate;
                        }

                        if (orderDetail.PlannedDate != null)
                        {
                            orderDetail.PricingDate = orderDetail.PlannedDate;
                        }

                        if (orderDetail.PhysiotherapyOrder.PhysiotherapyReports == null && viewModel.Report != null)//raporu yoksa set et
                        {
                            orderDetail.PhysiotherapyOrder.PhysiotherapyReports = viewModel.Report;
                        }
                        if (orderDetail.PhysiotherapyOrder.PackageProcedure == null && viewModel.PackageProcedure != null)//paket yoksa set et
                        {
                            orderDetail.PhysiotherapyOrder.PackageProcedure = viewModel.PackageProcedure;
                        }
                        if (orderDetail.PhysiotherapyOrder.PackageProcedure == null && viewModel.PackageProcedure == null)//paket yoksa var olan order'ýn paketini set et
                        {
                            orderDetail.PhysiotherapyOrder.PackageProcedure = GetPackageProcedureDefinitionInfo(model, orderDetail);
                        }

                        orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Complated;
                        orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Completed;
                        if (model[i].ResponsiblePhysiotherapist != null)
                        {
                            orderDetail.StarterResUser = model[i].ResponsiblePhysiotherapist;
                            orderDetail.FinisherResUser = model[i].ResponsiblePhysiotherapist;
                            orderDetail.ProcedureByUser = model[i].ResponsiblePhysiotherapist;
                        }
                        else
                        {
                            ResUser currentResUser = (ResUser)(TTUser.CurrentUser.UserObject);

                            if (orderDetail.StarterResUser == null)
                            {
                                orderDetail.StarterResUser = currentResUser;
                            }
                            if (orderDetail.FinisherResUser == null)
                            {
                                orderDetail.FinisherResUser = currentResUser;
                            }
                            if (orderDetail.ProcedureByUser == null)
                            {
                                orderDetail.ProcedureByUser = model[i].ResponsiblePhysiotherapist;
                            }
                        }

                        ////Order Detaillerin Hepsi Tamamlandý Ýse Order da tamamlanmalý
                        //orderDetail.PhysiotherapyOrder = CompletePhysiotherapyOrder(orderDetail.PhysiotherapyOrder );
                    }

                    ////Order'larýn Hepsi Tamamlandý ise Tüm Seans/Tedavi Tamamlansýn
                    //request = CompletePhysiotherapyRequest(request);

                    objectContext.Save();

                    // FTR Paketlerinin medulaya hizmet kaydý yapýlmasý için 
                    PhysiotherapyOrderDetail.MedulaProcedureEntry(podList);
                }

                return GetPhysiotherapyRequestPlannedFormViewModel(request.ObjectID);
            }
        }

        public PackageProcedureDefinition GetPackageProcedureDefinitionInfo(List<PlannedPhyOrderDetailInfo> model, PhysiotherapyOrderDetail orderDetail)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PackageProcedureDefinition defaultPackageProcedure = null;

                foreach (var item in model.Where(t => t.TreatmentDiagnosisUnit == orderDetail.PhysiotherapyOrder.TreatmentDiagnosisUnit.Name))
                {
                    PhysiotherapyOrderDetail _orderDetail = objectContext.GetObject(item.OrderDetailObjectID, item.OrderDetailObjectDef) as PhysiotherapyOrderDetail;
                    if (_orderDetail != null && _orderDetail.PhysiotherapyOrder != null && _orderDetail.PhysiotherapyOrder.PackageProcedure != null)
                    {
                        defaultPackageProcedure = _orderDetail.PhysiotherapyOrder.PackageProcedure;
                        break;
                    }
                }
                if (defaultPackageProcedure == null)
                {
                    foreach (var item in model)
                    {
                        PhysiotherapyOrderDetail _orderDetail = objectContext.GetObject(item.OrderDetailObjectID, item.OrderDetailObjectDef) as PhysiotherapyOrderDetail;
                        if (_orderDetail != null && _orderDetail.PhysiotherapyOrder != null && _orderDetail.PhysiotherapyOrder.PackageProcedure != null)
                        {
                            defaultPackageProcedure = _orderDetail.PhysiotherapyOrder.PackageProcedure;
                            break;
                        }
                    }
                }
                return defaultPackageProcedure;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Uygulamasi_Iptal_Et)]
        public PhysiotherapyRequestPlannedFormViewModel DeleteSelectedProceduresByID(List<PlannedPhyOrderDetailInfo> model)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Guid requestId = new Guid();
                for (int i = 0; i < model.Count; i++)
                {
                    PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(model[i].OrderDetailObjectID, model[i].OrderDetailObjectDef) as PhysiotherapyOrderDetail;
                    PhysiotherapyRequest request = orderDetail.PhysiotherapyRequest != null ? orderDetail.PhysiotherapyRequest : orderDetail.PhysiotherapyOrder.PhysiotherapyRequest;
                    requestId = request.ObjectID;
                    IsSessionCompleted(request);

                    if (orderDetail.PhysiotherapySession.PhysiotherapyOrderDetails.Where(c => c.ObjectID != orderDetail.ObjectID && c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled).Count() == 0)//iptal edilmiþ nesne haricinde seans içinde iþlem yoksa seans silinir.
                    {
                        ((ITTObject)orderDetail.PhysiotherapySession).Delete();
                        objectContext.Save();
                    }

                    orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Cancel;
                    orderDetail.PhysiotherapySession = null;
                    orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Cancelled;

                    ResUser currentResUser = (ResUser)(TTUser.CurrentUser.UserObject);

                    if (orderDetail.StarterResUser == null)
                    {
                        orderDetail.StarterResUser = currentResUser;
                    }
                    orderDetail.FinisherResUser = currentResUser;

                    ////Order Detaillerin Hepsi Tamamlandý Ýse Order da tamamlanmalý
                    //orderDetail.PhysiotherapyOrder = CompletePhysiotherapyOrder(orderDetail.PhysiotherapyOrder);

                    ////Order'larýn Hepsi Tamamlandý ise Tüm Seans/Tedavi Tamamlansýn
                    //request = CompletePhysiotherapyRequest(request);
                }

                objectContext.Save();

                return GetPhysiotherapyRequestPlannedFormViewModel(requestId);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Tarih_Guncelleme)]
        public PhysiotherapyRequestPlannedFormViewModel ChangeProcedureDates(PhysiotherapyRequestPlannedFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                IsSessionCompleted(viewModel._PhysiotherapyRequest);//tamamlanmýþ tedavi üzerinde iþlem yapýlamaz
                PhysiotherapyRequest request = objectContext.GetObject(viewModel._PhysiotherapyRequest.ObjectID, viewModel._PhysiotherapyRequest.ObjectDef) as PhysiotherapyRequest;

                List<PlannedPhyOrderDetailInfo> selectedOrderDetailList = viewModel.selectedRowKeysResultList.OrderBy(c => c.OrderDetailPlannedDate).ToList();//seçilen seanslarý gruplama
                if (viewModel.IsSessionRecalculate == true)//Tüm seanslarý deðiþtirilen seanstan itibaren öteleme yapma
                {
                    if (selectedOrderDetailList.GroupBy(c => c.PhysiotherapySessionId).Count() > 1)//eðer birden fazla seans seçilmiþse devam etme
                    {
                        throw new Exception("Lütfen ötelemek istediðiniz tek bir seans seçiniz!");
                    }
                    else
                    {
                        if (viewModel.sessionRecalculateByDate != true)//Gün Seçimi ya da Gün aralýðý önemsenmeden öteleme
                        {
                            //if ()//haftasonu çalýþýlýyor ise
                            //{
                            //    //Gün Seçimi ya da Gün aralýðý önemsenmeden öteleme
                            //    var changingSessionList = request.PhysiotherapySessions.OrderBy(x => x.PlannedDate).Where(c => c.PlannedDate.Value.Date >= Convert.ToDateTime(selectedOrderDetailList.FirstOrDefault().OrderDetailPlannedDate).Date);//deðiþtirilen tarihten büyük-eþit olan seanslar ötelenecek
                            //    int dayCount = (viewModel.SessionChangedDate.Date - Convert.ToDateTime(selectedOrderDetailList.FirstOrDefault().OrderDetailPlannedDate).Date).Days;
                            //    foreach (var sessionItem in changingSessionList)
                            //    {
                            //        sessionItem.PlannedDate = sessionItem.PlannedDate.Value.AddDays(dayCount);
                            //        foreach (var orderDetailtem in sessionItem.PhysiotherapyOrderDetails)
                            //        {
                            //            orderDetailtem.PlannedDate = sessionItem.PlannedDate;//Seansla birlikte iþlem tarihleri de güncelleniyor.
                            //        }
                            //    }
                            //}
                            //else //haftasonu çalýþýlmýyor ise o günler de ötelenir.
                            //{

                            //Gün Seçimi ya da Gün aralýðý önemsenmeden öteleme haftasonu çalýþýlmýyor
                            var changingSessionList = request.PhysiotherapySessions.OrderBy(x => x.PlannedDate).Where(c => c.PlannedDate.Value.Date >= Convert.ToDateTime(selectedOrderDetailList.FirstOrDefault().OrderDetailPlannedDate).Date).ToList();//deðiþtirilen tarihten büyük-eþit olan seanslar ötelenecek

                            int dayCount = (viewModel.SessionChangedDate.Date - Convert.ToDateTime(selectedOrderDetailList.FirstOrDefault().OrderDetailPlannedDate.Date)).Days;
                            foreach (var sessionItem in changingSessionList)
                            {
                                var newDate = sessionItem.PlannedDate.Value.AddDays(dayCount);//ötetenince haftasonuna denk gelen iþlem??

                                BindingList<WorkDayExceptionDef.GetWorkDayExceptionDefs_Class> holidayList = WorkDayExceptionDef.GetWorkDayExceptionDefs("");//Resmi Tatil Günleri -- GetActiveWorkDayExceptionDefs

                                if (newDate.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    dayCount++;
                                    newDate = newDate.AddDays(1);//Cumartesi günü ise tüm iþlemler bir gün daha ötelendi
                                }
                                if (newDate.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    dayCount++;
                                    newDate = newDate.AddDays(1);//Pazar günü ise tüm iþlemler bir gün daha ötelendi
                                }

                                #region Resmi tatillere göre öteleme
                                foreach (WorkDayExceptionDef.GetWorkDayExceptionDefs_Class item in holidayList)
                                {
                                    if (item.Date != null && item.Date.Value.Date == newDate.Date)//Tatil günü kadar öteleme
                                    {
                                        dayCount++;
                                        newDate = newDate.AddDays(1);
                                    }
                                    if (newDate.DayOfWeek == DayOfWeek.Saturday)//planlanan gün cts ise
                                    {
                                        dayCount++;
                                        newDate = newDate.AddDays(1);
                                    }
                                    if (newDate.DayOfWeek == DayOfWeek.Sunday)//planlanan gün pazar ise
                                    {
                                        dayCount++;
                                        newDate = newDate.AddDays(1);
                                    }
                                }
                                #endregion Resmi tatillere göre öteleme

                                sessionItem.PlannedDate = newDate;
                                foreach (var orderDetailtem in sessionItem.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled))
                                {
                                    orderDetailtem.PlannedDate = sessionItem.PlannedDate;//Seansla birlikte iþlem tarihleri de güncelleniyor.
                                    orderDetailtem.PricingDate = orderDetailtem.PlannedDate;
                                }
                            }
                            //}
                        }
                        else//Gün Seçimi ya da Gün aralýðý ile öteleme
                        {
                            //seçili iþlemin bulunduðu session
                            PhysiotherapySessionInfo selectedSession = objectContext.GetObject(new Guid(selectedOrderDetailList.FirstOrDefault().PhysiotherapySessionId), selectedOrderDetailList.FirstOrDefault().PhysiotherapySessionDef) as PhysiotherapySessionInfo;

                            foreach (var orderDetail in selectedSession.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled))
                            {
                                PhysiotherapyOrder _order = orderDetail.OrderObject as PhysiotherapyOrder;

                                int startSessionNumber = _order.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled).OrderBy(c => c.PlannedDate).Where(x => x.PlannedDate.Value.Date <= orderDetail.PlannedDate.Value.Date).Count();//Kaçýncý seanstan itibaren hesaplama yapýlacaðý sayýlýyor

                                if (_order.IncludeMonday == true || _order.IncludeTuesday == true || _order.IncludeWednesday == true || _order.IncludeThursday == true || _order.IncludeFriday == true)//Haftaiçi herhangi bir gün iþaretli ise gün seçimine göre hesaplama yap
                                {
                                    reCalculateOrderDetails(_order, objectContext, viewModel.SessionChangedDate, true, startSessionNumber);
                                }
                                else if (_order.SeansGunSayisi != null || _order.SeansGunSayisi != 0)//SeansGunSayisi null ya da sýfýr deðilse gün aralýðýna göre hesaplama yap
                                {
                                    reCalculateOrderDetails(_order, objectContext, viewModel.SessionChangedDate, false, startSessionNumber);
                                }
                                else// haftaiçi gün seçimi olmamasýna raðmen seans gün sayýsý da boþsa gün seçimine göre hesaplama yap
                                {
                                    reCalculateOrderDetails(_order, objectContext, viewModel.SessionChangedDate, true, startSessionNumber);
                                }
                            }

                            #region SessionDüzenleme

                            var PhysiotherapyOrderDetailList = request.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled);
                            List<PhysiotherapySessionInfo> sessionList = request.PhysiotherapySessions.ToList();
                            if (sessionList.Count() > 0)
                            {
                                foreach (var item in sessionList)
                                {
                                    //var olan sessionlar silinecek!
                                    PhysiotherapySessionInfo sessionItem = request.PhysiotherapySessions.Where(x => x.ObjectID == item.ObjectID).FirstOrDefault();
                                    ((ITTObject)sessionItem).Delete();
                                }
                            }
                            foreach (var groupedItem in PhysiotherapyOrderDetailList.GroupBy(c => c.PlannedDate.Value.Date))
                            {
                                PhysiotherapySessionInfo _sessionInfo = new PhysiotherapySessionInfo(objectContext);
                                _sessionInfo.PlannedDate = groupedItem.FirstOrDefault().PlannedDate;
                                _sessionInfo.PhysiotherapyRequest = groupedItem.FirstOrDefault().PhysiotherapyRequest;
                                foreach (var orderDetail in groupedItem)
                                {
                                    orderDetail.PhysiotherapySession = _sessionInfo;
                                }
                            }

                            #endregion SessionDüzenleme
                        }
                    }
                }
                else//seçili iþlemlerin bulunduðu seanstaki tüm iþlemlerin tarihlerini deðiþtirir ama sonraki seanslarda öteleme yapmaz
                {
                    var sessionIdList = selectedOrderDetailList.GroupBy(c => c.PhysiotherapySessionId);
                    foreach (var sessionItemList in sessionIdList)
                    {
                        PhysiotherapySessionInfo phySession = objectContext.GetObject(new Guid(sessionItemList.FirstOrDefault().PhysiotherapySessionId), sessionItemList.FirstOrDefault().PhysiotherapySessionDef) as PhysiotherapySessionInfo;
                        var availableSession = request.PhysiotherapySessions.Where(c => c.PlannedDate.Value.Date == viewModel.SessionChangedDate.Date && c.ObjectID != phySession.ObjectID);//deðiþtirilecek tarihte baþka session var mý?
                        if (availableSession.Count() > 0)//deðiþtirilecek tarihte baþka session var ise eski session silinir ve mevcut session orderDetaile baðlanýr
                        {
                            var myListtt = phySession.PhysiotherapyOrderDetails.Where(x => x.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled).ToList();
                            ((ITTObject)phySession).Delete();
                            foreach (var detailItem in myListtt)
                            {
                                detailItem.PlannedDate = viewModel.SessionChangedDate;
                                detailItem.PricingDate = detailItem.PlannedDate;

                                detailItem.PhysiotherapySession = availableSession.FirstOrDefault();
                            }
                        }
                        else//deðiþtirilecek tarihte baþka session yok ise session tarihi deðiþtirilir
                        {
                            phySession.PlannedDate = viewModel.SessionChangedDate;
                            foreach (var detailItem in phySession.PhysiotherapyOrderDetails.Where(x => x.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled))
                            {
                                foreach (var selectedOrderDetail in phySession.PhysiotherapyOrderDetails.Where(x => x.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled))
                                {
                                    PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(selectedOrderDetail.ObjectID, selectedOrderDetail.ObjectDef) as PhysiotherapyOrderDetail;

                                    orderDetail.PlannedDate = viewModel.SessionChangedDate;
                                    orderDetail.PricingDate = orderDetail.PlannedDate;
                                }
                            }
                        }
                    }
                }
                //else//sadece seçili iþlemlerin tarihini deðiþtirme seans tarihi deðiþikliði ve öteleme yapmama
                //{
                //    foreach (PlannedPhyOrderDetailInfo selectedOrderDetail in selectedOrderDetailList)
                //    {
                //        PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(selectedOrderDetail.OrderDetailObjectID, selectedOrderDetail.OrderDetailObjectDef) as PhysiotherapyOrderDetail;

                //        var availableSession = request.PhysiotherapySessions.Where(c => c.PlannedDate.Value.Date == viewModel.SessionChangedDate.Date);
                //        if (availableSession.Count() > 0)//deðiþtirilecek tarihte baþka session var ise
                //        {
                //            orderDetail.PhysiotherapySession = availableSession.FirstOrDefault();
                //        }
                //        else//deðiþtirilecek tarihte baþka session yok ise
                //        {
                //            PhysiotherapySessionInfo _sessionInfo = new PhysiotherapySessionInfo(objectContext);
                //            _sessionInfo.PlannedDate = viewModel.SessionChangedDate;
                //            _sessionInfo.PhysiotherapyRequest = orderDetail.PhysiotherapyRequest;
                //            orderDetail.PhysiotherapySession = _sessionInfo;

                //        }

                //        var oldSession = orderDetail.PhysiotherapySession;
                //        if (oldSession.PhysiotherapyOrderDetails.Count() == 0)//iþlemin eski tarihindeki sessionda iþlem kalmadý ise eski tarihli session silinir.
                //        {
                //            ((ITTObject)oldSession).Delete();
                //        }

                //        orderDetail.PlannedDate = viewModel.SessionChangedDate;
                //        orderDetail.PricingDate = orderDetail.PlannedDate;
                //    }
                //}

                Max5DaysControlBySession(request);//iki seans arasý max 5 gün olabilir kontrolü ve yatan ayaktan için planm-lama yapýlacak vücut bölgesi-grup konrolü 

                objectContext.Save();

                return GetPhysiotherapyRequestPlannedFormViewModel(request.ObjectID);
            }

        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Uygulamasi_Durdurma)]
        public PhysiotherapyRequestPlannedFormViewModel AbortSelectedProceduresByID(List<PlannedPhyOrderDetailInfo> model)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Guid requestId = new Guid();
                for (int i = 0; i < model.Count; i++)
                {
                    PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(model[i].OrderDetailObjectID, model[i].OrderDetailObjectDef) as PhysiotherapyOrderDetail;
                    PhysiotherapyRequest request = orderDetail.PhysiotherapyRequest != null ? orderDetail.PhysiotherapyRequest : orderDetail.PhysiotherapyOrder.PhysiotherapyRequest;
                    requestId = request.ObjectID;
                    IsSessionCompleted(request);

                    orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Aborted;
                    orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Aborted;

                    ResUser currentResUser = (ResUser)(TTUser.CurrentUser.UserObject);

                    if (orderDetail.StarterResUser == null)
                    {
                        orderDetail.StarterResUser = currentResUser;
                    }
                    orderDetail.FinisherResUser = currentResUser;

                    ////Order Detaillerin Hepsi Tamamlandý Ýse Order da tamamlanmalý
                    //orderDetail.PhysiotherapyOrder = CompletePhysiotherapyOrder(orderDetail.PhysiotherapyOrder);


                    ////Order'larýn Hepsi Tamamlandý ise Tüm Seans/Tedavi Tamamlansýn
                    //request = CompletePhysiotherapyRequest(request);
                }

                objectContext.Save();

                return GetPhysiotherapyRequestPlannedFormViewModel(requestId);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Uygulamasi_Hasta_Gelmedi)]
        public PhysiotherapyRequestPlannedFormViewModel NotComeSelectedProceduresByID(List<PlannedPhyOrderDetailInfo> model)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Guid requestId = new Guid();
                for (int i = 0; i < model.Count; i++)
                {
                    PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(model[i].OrderDetailObjectID, model[i].OrderDetailObjectDef) as PhysiotherapyOrderDetail;
                    PhysiotherapyRequest request = orderDetail.PhysiotherapyRequest != null ? orderDetail.PhysiotherapyRequest : orderDetail.PhysiotherapyOrder.PhysiotherapyRequest;
                    requestId = request.ObjectID;
                    IsSessionCompleted(request);

                    orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.NotCome;
                    //orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Aborted;

                    ResUser currentResUser = (ResUser)(TTUser.CurrentUser.UserObject);

                    if (orderDetail.StarterResUser == null)
                    {
                        orderDetail.StarterResUser = currentResUser;
                    }
                    orderDetail.FinisherResUser = currentResUser;
                }

                objectContext.Save();

                return GetPhysiotherapyRequestPlannedFormViewModel(requestId);
            }
        }

        public void Max5DaysControlBySession(PhysiotherapyRequest physiotherapyRequest)
        {
            foreach (var orderDetail in physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.HasMemberChanged("PlannedDate") == true))
            {
                if (orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed)//Planlanan tarihi deðiþmiþse ve tamamlanmýþ iþlem ise hata verilir.
                {
                    throw new Exception("Tamamlanmýþ iþlem üzerinde deðiþiklik yapýlamaz!");
                }
            }
            ////yatan ayaktan için planlama yapýlacak vücut bölgesi-grup konrolü 
            //var reportList = physiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID != PhysiotherapyOrder.States.Cancelled && c.PackageProcedure != null).GroupBy(x => x.PackageProcedure);
            //if (physiotherapyRequest.SubEpisode.StarterEpisodeAction.SubEpisode.PatientStatus.Value == SubEpisodeStatusEnum.Outpatient && reportList.Count() > 1)
            //{
            //    throw new Exception("Ayaktan hasta için birden fazla paket hizmeti için planlama yapýlamaz !");
            //}
            //else if (physiotherapyRequest.SubEpisode.StarterEpisodeAction.SubEpisode.PatientStatus.Value != SubEpisodeStatusEnum.Outpatient && reportList.Count() > 2)
            //{
            //    throw new Exception("Yatan hasta için ikiden fazla vücut bölgesi için planlama yapýlamaz !");
            //}

            //iki seans arasý max 5 gün olabilir kontrolü
            List<PhysiotherapySessionInfo> sessionList = physiotherapyRequest.PhysiotherapySessions.OrderBy(c => c.PlannedDate).ToList();
            for (int i = 1; i < sessionList.Count(); i++)
            {
                var dayDifference = ((sessionList[i].PlannedDate.Value.Date) - (sessionList[i - 1].PlannedDate.Value.Date)).TotalDays;
                int weekendCount = 0;
                if (dayDifference > 5)
                {
                    if (dayDifference > 7)
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M26035", "Ýki seans arasýndaki fark 5 iþ gününden fazla olamaz!"));
                    }
                    else
                    {
                        var previousPlannedDate = sessionList[i].PlannedDate;
                        while (previousPlannedDate != sessionList[i].PlannedDate)
                        {
                            if (previousPlannedDate.Value.DayOfWeek == DayOfWeek.Saturday)//Planlanan gün cts ise
                            {
                                weekendCount++;
                            }
                            else if (previousPlannedDate.Value.DayOfWeek == DayOfWeek.Saturday)//Planlanan gün pazar ise
                            {
                                weekendCount++;
                            }
                        }

                        if ((dayDifference + weekendCount) > 7)//seans pazartesi baþlarsa ve haftasonu seans almazsa iki seans arasý haftasonu ile beraber 7 gün olup hata verecek.
                        {
                            throw new Exception(TTUtils.CultureService.GetText("M26035", "Ýki seans arasýndaki fark 5 iþ gününden fazla olamaz!"));
                        }
                    }
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Uygulamasi_Geri_Alma)]
        public PhysiotherapyRequestPlannedFormViewModel UndoProcedures(List<PlannedPhyOrderDetailInfo> model)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Guid requestId = new Guid();
                List<PhysiotherapyOrderDetail> podList = new List<PhysiotherapyOrderDetail>();
                for (int i = 0; i < model.Count; i++)
                {
                    PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(model[i].OrderDetailObjectID, model[i].OrderDetailObjectDef) as PhysiotherapyOrderDetail;
                    //IsSessionCompleted(orderDetail.PhysiotherapyRequest != null ? orderDetail.PhysiotherapyRequest : orderDetail.PhysiotherapyOrder.PhysiotherapyRequest);

                    // Completed dan Execution a geri dönülüyorsa
                    if (orderDetail.PrevState != null && orderDetail.PrevState.StateDefID == PhysiotherapyOrderDetail.States.Execution && orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed)
                        podList.Add(orderDetail);
                }
                // FTR Paket ve hizmetlerinin medula hizmet kayýtlarýný iptal eder 
                PhysiotherapyOrderDetail.MedulaProcedureEntryCancel(podList);
                objectContext.Save();

                for (int i = 0; i < model.Count; i++)
                {
                    PhysiotherapyOrderDetail orderDetail = objectContext.GetObject(model[i].OrderDetailObjectID, model[i].OrderDetailObjectDef) as PhysiotherapyOrderDetail;
                    PhysiotherapyRequest request = orderDetail.PhysiotherapyRequest != null ? orderDetail.PhysiotherapyRequest : orderDetail.PhysiotherapyOrder.PhysiotherapyRequest;
                    requestId = request.ObjectID;
                    IsSessionCompleted(request);

                    if (orderDetail.PrevState != null)
                    {
                        if (orderDetail.PrevState.StateDefID == PhysiotherapyOrderDetail.States.Execution)
                        {
                            orderDetail.StarterResUser = null;
                            orderDetail.StartDate = null;
                            orderDetail.FinishDate = null;
                        }

                        //Tamamlanmýþ orderdetail geri alýnmýþsa order da tamamlandý durumundan geri alýnmalý
                        if (orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed && orderDetail.PrevState.StateDefID != PhysiotherapyOrderDetail.States.Completed)
                        {
                            orderDetail.PhysiotherapyOrder.CurrentStateDefID = PhysiotherapyOrder.States.RequestAcception;
                            //Request tamamlandý durumunda ise geri alýnmalý
                            if (request.CurrentStateDefID == PhysiotherapyRequest.States.Completed)
                            {
                                request.CurrentStateDefID = request.PrevState.StateDefID;
                            }
                        }

                        orderDetail.CurrentStateDefID = orderDetail.PrevState.StateDefID;
                    }

                    if (orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Aborted)
                    {
                        orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Aborted;
                    }
                    if (orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Cancelled)
                    {
                        orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Cancel;
                    }
                    if (orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed)
                    {
                        orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Complated;
                    }
                    if (orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution)
                    {
                        orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.New;
                    }


                    ////Order Detaillerin Hepsi Tamamlandý Ýse Order da tamamlanmalý
                    //if (orderDetail.PhysiotherapyOrder.PhysiotherapyOrderDetails.Select(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution).Count() == 0)
                    //{
                    //    orderDetail.PhysiotherapyOrder = CompletePhysiotherapyOrder(orderDetail.PhysiotherapyOrder);
                    //}
                    //else //Tamamlanmýþ orderdetail geri alýnmýþsa order da tamamlandý durumundan geri alýnmalý
                    //{
                    //    orderDetail.PhysiotherapyOrder.CurrentStateDefID = PhysiotherapyOrder.States.RequestAcception;
                    //}

                    ////Order'larýn Hepsi Tamamlandý ise Tüm Seans/Tedavi Tamamlansýn
                    //request = CompletePhysiotherapyRequest(request);
                }

                objectContext.Save();

                return GetPhysiotherapyRequestPlannedFormViewModel(requestId);
            }
        }

        public PhysiotherapyRequestPlannedFormViewModel CancelPhysiotherapyRequestAndRefresh(PhysiotherapyRequestPlannedFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PhysiotherapyRequest request = objectContext.GetObject(viewModel._PhysiotherapyRequest.ObjectID, viewModel._PhysiotherapyRequest.ObjectDef) as PhysiotherapyRequest;
                IsSessionCompleted(request);
                if (request.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed).Count() > 0)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M27031", "Tamamlanmýþ iþlemleri olan tedavi isteðini iptal edemezsiniz!"));
                }
                request.CurrentStateDefID = PhysiotherapyRequest.States.Cancelled;

                objectContext.Save();

                return GetPhysiotherapyRequestPlannedFormViewModel(request.ObjectID);
            }
        }

        public void reCalculateOrderDetails(PhysiotherapyOrder physiotherapyOrder, TTObjectContext objectContext, DateTime newPhysiotherapyStartDate, bool daySelectionActive, int startSessionNumber)
        {
            DateTime _plannedDate = new DateTime();

            var OrderDetailList = physiotherapyOrder.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled).OrderBy(x => x.PlannedDate);

            if (newPhysiotherapyStartDate != null)
            {
                _plannedDate = newPhysiotherapyStartDate;

                BindingList<WorkDayExceptionDef.GetWorkDayExceptionDefs_Class> holidayList = WorkDayExceptionDef.GetWorkDayExceptionDefs("");//Resmi Tatil Günleri -- GetActiveWorkDayExceptionDefs

                #region Resmi tatillere göre öteleme
                foreach (WorkDayExceptionDef.GetWorkDayExceptionDefs_Class item in holidayList)
                {
                    if (item.Date != null && item.Date.Value.Date == _plannedDate.Date)
                    {
                        _plannedDate = _plannedDate.AddDays(1);
                    }
                }
                #endregion Resmi tatillere göre öteleme

                #region yeni fonk
                if (daySelectionActive == false)//Gün seçimi olmadan seans gün aralýðý kullanarak planlama
                {
                    if (physiotherapyOrder.IncludeSaturday != true && physiotherapyOrder.IncludeSunday != true)//Haftasonu (Cts-Pazar) Dahil Deðil 
                    {
                        for (int _sessionNumber = startSessionNumber; _sessionNumber <= physiotherapyOrder.FinishSession.Value; _sessionNumber++)
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)//planlanan gün cts ise
                            {
                                _plannedDate = _plannedDate.AddDays(1);
                            }
                            if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)//planlanan gün pazar ise
                            {
                                _plannedDate = _plannedDate.AddDays(1);
                            }

                            #region Resmi tatillere göre öteleme
                            foreach (WorkDayExceptionDef.GetWorkDayExceptionDefs_Class item in holidayList)
                            {
                                if (item.Date != null && item.Date.Value.Date == _plannedDate.Date)//Tatil günü kadar öteleme
                                {
                                    _plannedDate = _plannedDate.AddDays(1);
                                }
                                if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)//planlanan gün cts ise
                                {
                                    _plannedDate = _plannedDate.AddDays(1);
                                }
                                if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)//planlanan gün pazar ise
                                {
                                    _plannedDate = _plannedDate.AddDays(1);
                                }
                            }
                            #endregion Resmi tatillere göre öteleme

                            //    ----------  planlanan gün tedavi ünitesi çalýþmýyor ise o gün atlanýr    ----------
                            if (!((_plannedDate.DayOfWeek == DayOfWeek.Monday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnMonday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnMonday == false)
                                || (_plannedDate.DayOfWeek == DayOfWeek.Tuesday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnTuesday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnTuesday == false)
                                || (_plannedDate.DayOfWeek == DayOfWeek.Wednesday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnWednesday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnWednesday == false)
                                || (_plannedDate.DayOfWeek == DayOfWeek.Thursday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnThursday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnThursday == false)
                                || (_plannedDate.DayOfWeek == DayOfWeek.Friday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnFriday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnFriday == false)
                                || (_plannedDate.DayOfWeek == DayOfWeek.Saturday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday == false)
                                || (_plannedDate.DayOfWeek == DayOfWeek.Sunday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday == false)))
                            {
                                //PhysiotherapyOrderDetail _physiotherapyOrderDetail = OrderDetailList.ElementAt(_sessionNumber - startSessionNumber);//listedeki orderDetail bulunup onun plannedDate'i deðiþtirilir
                                PhysiotherapyOrderDetail _physiotherapyOrderDetail = OrderDetailList.Where(c => c.SessionNumber == _sessionNumber).FirstOrDefault();

                                _physiotherapyOrderDetail.PlannedDate = _plannedDate;

                                _physiotherapyOrderDetail.PricingDate = _physiotherapyOrderDetail.PlannedDate;

                            }

                            _plannedDate = _plannedDate.AddDays(physiotherapyOrder.SeansGunSayisi.Value);
                        }
                    }
                    else //Hastasonu En Az Bir Gün Dahil
                    {
                        for (int _sessionNumber = startSessionNumber; _sessionNumber <= physiotherapyOrder.FinishSession.Value; _sessionNumber++)
                        {

                            if (physiotherapyOrder.IncludeSaturday != true)//Cumartesi Dahil Deðil ise
                            {
                                if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)//planlanan gün cts ise
                                {
                                    _plannedDate = _plannedDate.AddDays(1);
                                }

                                #region Resmi tatillere göre öteleme
                                foreach (WorkDayExceptionDef.GetWorkDayExceptionDefs_Class item in holidayList)
                                {
                                    if (item.Date != null && item.Date.Value.Date == _plannedDate.Date)//Tatil günü kadar öteleme
                                    {
                                        _plannedDate = _plannedDate.AddDays(1);
                                    }
                                }
                                #endregion Resmi tatillere göre öteleme

                                if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)//planlanan gün cts ise
                                {
                                    _plannedDate = _plannedDate.AddDays(1);
                                }
                            }
                            else if (physiotherapyOrder.IncludeSunday != true)//Pazar Dahil Deðil ise
                            {
                                if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)//planlanan gün pazar ise
                                {
                                    _plannedDate = _plannedDate.AddDays(1);
                                }

                                #region Resmi tatillere göre öteleme
                                foreach (WorkDayExceptionDef.GetWorkDayExceptionDefs_Class item in holidayList)
                                {
                                    if (item.Date != null && item.Date.Value.Date == _plannedDate.Date)//Tatil günü kadar öteleme
                                    {
                                        _plannedDate = _plannedDate.AddDays(1);
                                    }
                                }
                                #endregion Resmi tatillere göre öteleme

                                if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)//planlanan gün pazar ise
                                {
                                    _plannedDate = _plannedDate.AddDays(1);
                                }
                            }
                            else//Haftasonu Dahil
                            {
                                #region Resmi tatillere göre öteleme
                                foreach (WorkDayExceptionDef.GetWorkDayExceptionDefs_Class item in holidayList)
                                {
                                    if (item.Date != null && item.Date.Value.Date == _plannedDate.Date)//Tatil günü kadar öteleme
                                    {
                                        _plannedDate = _plannedDate.AddDays(1);
                                    }
                                }
                                #endregion Resmi tatillere göre öteleme

                            }

                            //    ----------    planlanan gün tedavi ünitesi çalýþmýyor ise o gün atlanýr    ----------
                            if (!((_plannedDate.DayOfWeek == DayOfWeek.Monday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnMonday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnMonday == false)
                                || (_plannedDate.DayOfWeek == DayOfWeek.Tuesday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnTuesday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnTuesday == false)
                                || (_plannedDate.DayOfWeek == DayOfWeek.Wednesday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnWednesday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnWednesday == false)
                                || (_plannedDate.DayOfWeek == DayOfWeek.Thursday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnThursday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnThursday == false)
                                || (_plannedDate.DayOfWeek == DayOfWeek.Friday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnFriday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnFriday == false)
                                || (_plannedDate.DayOfWeek == DayOfWeek.Saturday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday == false)
                                || (_plannedDate.DayOfWeek == DayOfWeek.Sunday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday == false)))
                            {

                                PhysiotherapyOrderDetail _physiotherapyOrderDetail = OrderDetailList.ElementAt(_sessionNumber - startSessionNumber);//listedeki orderDetail bulunup onun plannedDate'i deðiþtirilir

                                _physiotherapyOrderDetail.PlannedDate = _plannedDate;

                                _physiotherapyOrderDetail.PricingDate = _physiotherapyOrderDetail.PlannedDate;

                            }

                            _plannedDate = _plannedDate.AddDays(physiotherapyOrder.SeansGunSayisi.Value);
                        }
                    }
                }
                else//Gün seçimi kullanarak planlama
                {
                    for (int _sessionNumber = startSessionNumber; _sessionNumber <= physiotherapyOrder.FinishSession.Value; _sessionNumber++)
                    {
                        int seansNo = _sessionNumber;
                        DateTime planlananTarih = _plannedDate;

                        bool isDateConflict = false;//gün eþleþmesi saðlanana kadar bir sonraki güne geçiliyor.
                        while (!isDateConflict)
                        {
                            #region Resmi tatillere göre öteleme
                            foreach (WorkDayExceptionDef.GetWorkDayExceptionDefs_Class item in holidayList)
                            {
                                if (item.Date != null && item.Date.Value.Date == _plannedDate.Date)
                                {
                                    _plannedDate = _plannedDate.AddDays(1);
                                }
                            }
                            #endregion Resmi tatillere göre öteleme

                            if ((physiotherapyOrder.IncludeMonday == true && _plannedDate.DayOfWeek == DayOfWeek.Monday) //Pazartesi
                                || (physiotherapyOrder.IncludeTuesday == true && _plannedDate.DayOfWeek == DayOfWeek.Tuesday)//Salý
                                || (physiotherapyOrder.IncludeWednesday == true && _plannedDate.DayOfWeek == DayOfWeek.Wednesday)//Çarþamba
                                || (physiotherapyOrder.IncludeThursday == true && _plannedDate.DayOfWeek == DayOfWeek.Thursday)//Perþembe
                                || (physiotherapyOrder.IncludeFriday == true && _plannedDate.DayOfWeek == DayOfWeek.Friday)//Cuma
                                || (physiotherapyOrder.IncludeSaturday == true && _plannedDate.DayOfWeek == DayOfWeek.Saturday)//Cumartesi
                                || (physiotherapyOrder.IncludeSunday == true && _plannedDate.DayOfWeek == DayOfWeek.Sunday)//Pazar
                                )
                            {
                                seansNo = _sessionNumber;
                                planlananTarih = _plannedDate;
                                isDateConflict = true;
                            }
                            _plannedDate = _plannedDate.AddDays(1);
                        }

                        //    ----------    1'den baþlamayan seanslarda o seans StartSession'a kadar atlanýr. && planlanan gün tedavi ünitesi çalýþmýyor ise o gün atlanýr    ----------
                        if (!((_plannedDate.DayOfWeek == DayOfWeek.Monday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnMonday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnMonday == false)
                            || (_plannedDate.DayOfWeek == DayOfWeek.Tuesday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnTuesday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnTuesday == false)
                            || (_plannedDate.DayOfWeek == DayOfWeek.Wednesday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnWednesday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnWednesday == false)
                            || (_plannedDate.DayOfWeek == DayOfWeek.Thursday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnThursday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnThursday == false)
                            || (_plannedDate.DayOfWeek == DayOfWeek.Friday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnFriday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnFriday == false)
                            || (_plannedDate.DayOfWeek == DayOfWeek.Saturday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday == false)
                            || (_plannedDate.DayOfWeek == DayOfWeek.Sunday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday == false)))
                        {
                            PhysiotherapyOrderDetail _physiotherapyOrderDetail = OrderDetailList.ElementAt(_sessionNumber - startSessionNumber);//listedeki orderDetail bulunup onun plannedDate'i deðiþtirilir

                            _physiotherapyOrderDetail.PlannedDate = planlananTarih;

                            _physiotherapyOrderDetail.PricingDate = _physiotherapyOrderDetail.PlannedDate;

                        }

                    }
                }
                #endregion
            }
        }

        protected void removeOutgoingTransitions(PhysiotherapyRequestPlannedFormViewModel viewModel, PhysiotherapyRequest physiotherapyRequest)
        {
            List<TTObjectStateTransitionDef> removedOutgoingTransitions = new List<TTObjectStateTransitionDef>();

            foreach (var trans in viewModel.OutgoingTransitions)
            {
                if (trans.ToStateDefID == PhysiotherapyRequest.States.Cancelled || trans.ToStateDefID == PhysiotherapyRequest.States.Completed)
                {
                    removedOutgoingTransitions.Add(trans);
                }

            }

            foreach (var removedtrans in removedOutgoingTransitions)
            {
                viewModel.OutgoingTransitions.Remove(removedtrans);
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Emri_Tamamlandi)]
        public PhysiotherapyRequestPlannedFormViewModel CompleteSelectedSessionsByUnit(Guid PhysiotherapyRequestObjectID, Guid PhysiotherapyRequestObjectDefID, Guid TreatmentDiagnosisUnitID, string TreatmentNote, string TreatmentNoteId)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest_Class> PhysiotherapyOrders = PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest(PhysiotherapyRequestObjectID, TreatmentDiagnosisUnitID).ToList();
                OrderInfo orderInfo = new OrderInfo();
                foreach (var physiotherapyOrder in PhysiotherapyOrders)
                {
                    if (!String.IsNullOrEmpty(TreatmentNote))
                    {
                        PhysiotherapyOrder orderObj = objectContext.GetObject(physiotherapyOrder.ObjectID.Value, physiotherapyOrder.ObjectDefID.Value) as PhysiotherapyOrder;
                        PhysiotherapyTreatmentNote note;
                        if (!String.IsNullOrEmpty(TreatmentNoteId))
                        {
                            note = objectContext.GetObject<PhysiotherapyTreatmentNote>(new Guid(TreatmentNoteId)) as PhysiotherapyTreatmentNote;
                        }
                        else
                        {
                            var physiotherapyTreatmentNote = PhysiotherapyTreatmentNote.GetTreatmentNoteByEpisodeActionAndUnit(objectContext, orderObj.PhysiotherapyRequest.ObjectID, TreatmentDiagnosisUnitID);
                            if (physiotherapyTreatmentNote.Count() > 0)//Daha önce kaydedilmiþ not varsa
                            {
                                note = physiotherapyTreatmentNote.FirstOrDefault();
                            }
                            else
                            {
                                note = new PhysiotherapyTreatmentNote(objectContext);
                            }
                        }
                        note.Description = TreatmentNote;
                        note.EntryDate = Common.RecTime();
                        note.EntryUser = Common.CurrentResource;
                        note.IsCompletedOrder = true;//Ünite-Seans Sonlandýrma iþlemi sonrasý girilen açýklama
                        note.IsCompletedRequest = false;
                        note.EpisodeAction = orderObj.PhysiotherapyRequest;
                        note.TreatmentDiagnosisUnit = orderObj.TreatmentDiagnosisUnit;

                    }

                    if (physiotherapyOrder.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception)
                    {
                        orderInfo.OrderObjectId = (Guid)physiotherapyOrder?.ObjectID;
                        orderInfo.OrderObjectDefId = (Guid)physiotherapyOrder?.ObjectDefID;
                        CompleteSession(orderInfo);
                    }
                    //else
                    //{
                    //    PhysiotherapyOrder order = objectContext.GetObject(physiotherapyOrder.ObjectID.Value, physiotherapyOrder.ObjectDefID.Value) as PhysiotherapyOrder;
                    //    //Order'larýn Hepsi Tamamlandý ise Tüm Seans Tamamlansýn
                    //    if (order.PhysiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception).Count() == 0)
                    //    {
                    //        order.PhysiotherapyRequest.CurrentStateDefID = PhysiotherapyRequest.States.Completed;
                    //    }

                    //    objectContext.Save();
                    //}
                }


                PhysiotherapyRequest _request = objectContext.GetObject(PhysiotherapyRequestObjectID, PhysiotherapyRequestObjectDefID) as PhysiotherapyRequest;
                //Order'larýn Hepsi Tamamlandý ise Tüm Seans Tamamlansýn
                if (_request.PhysiotherapyOrders.Where(c => c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception).Count() == 0)
                {
                    _request.CurrentStateDefID = PhysiotherapyRequest.States.Completed;
                }

                objectContext.Save();

                #region Seans Sonlandýrma
                EpisodeActionServiceController easc = new EpisodeActionServiceController();
                string _message = _request.Episode.Patient.Name + " " + _request.Episode.Patient.Surname + " isimli takipli hastanýn " + _request.SubEpisode.ProtocolNo + " 'lu kabulüne ait F.T.R seans sonlandýrma iþlemi yapýlmýþtýr";
                easc.FindTrackingFollowers(_request.Episode.Patient.ObjectID, _request.SubEpisode.ObjectID, true, true, _message, _message, SMSTypeEnum.FTRSessionCompleted);
                easc.Dispose();
                #endregion

                return GetPhysiotherapyRequestPlannedFormViewModel(PhysiotherapyRequestObjectID);
            }
        }

        public PhysiotherapyRequestPlannedFormViewModel UndoSelectedSessionsByUnit(TreatmentUnitAndRequest treatmentUnitAndRequest)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                if (treatmentUnitAndRequest.TreatmentDiagnosisInfoList.Count > 0)
                {

                    foreach (var treatmentUnit in treatmentUnitAndRequest.TreatmentDiagnosisInfoList)
                    {
                        List<PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest_Class> PhysiotherapyOrders = PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest(treatmentUnitAndRequest.PhysiotherapyRequestId, treatmentUnit.TreatmentDiagnosisUnitId, " AND this.CURRENTSTATEDEFID <> STATES.Cancelled").ToList();
                        OrderInfo orderInfo = new OrderInfo();
                        foreach (var physiotherapyOrder in PhysiotherapyOrders)
                        {
                            if (physiotherapyOrder.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception)
                            {
                                //throw new TTException("Yeni eklenmiþ seanslar üzerinde geri alma iþlemi yapýlamamaktadýr!");
                            }
                            else
                            {
                                PhysiotherapyOrder order = objectContext.GetObject(physiotherapyOrder.ObjectID.Value, physiotherapyOrder.ObjectDefID.Value) as PhysiotherapyOrder;
                                //IsSessionCompleted(order.PhysiotherapyRequest);

                                var changedAutomaticallyOrderDetail = order.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Aborted && c.IsChangedAutomatically == true);
                                if (changedAutomaticallyOrderDetail.Count() > 0)//Ýþlemler geri alýnýyor.
                                {
                                    foreach (var orderDetail in changedAutomaticallyOrderDetail)
                                    {
                                        orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Execution;
                                        orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.New;
                                        orderDetail.IsChangedAutomatically = false;
                                    }
                                }

                                order.CurrentStateDefID = PhysiotherapyOrder.States.RequestAcception;

                                objectContext.Save();
                            }
                        }
                    }

                    PhysiotherapyRequest request = objectContext.GetObject(treatmentUnitAndRequest.PhysiotherapyRequestId, treatmentUnitAndRequest.PhysiotherapyRequestDefId) as PhysiotherapyRequest;
                    if (request.CurrentStateDefID == PhysiotherapyRequest.States.Completed)
                    {
                        request.CurrentStateDefID = request.PrevState.StateDefID;
                    }

                    objectContext.Save();
                }

                return GetPhysiotherapyRequestPlannedFormViewModel(treatmentUnitAndRequest.PhysiotherapyRequestId);
            }
        }


        [HttpGet]
        public PhysiotherapyRequestPlannedFormViewModel GetPhysiotherapyRequestPlannedFormViewModel(Guid? id)
        {
            var formDefID = Guid.Parse("90d5e65b-9d39-4207-ac77-5b45922194db");
            var objectDefID = Guid.Parse("43225fba-1931-42a1-b745-23599ea82b65");
            var viewModel = new PhysiotherapyRequestPlannedFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._PhysiotherapyRequest = objectContext.GetObject(id.Value, objectDefID) as PhysiotherapyRequest;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysiotherapyRequest, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyRequest, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PhysiotherapyRequest);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PhysiotherapyRequest);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_PhysiotherapyRequestPlannedForm(viewModel, viewModel._PhysiotherapyRequest, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }
    }
}


namespace Core.Models
{
    public partial class PhysiotherapyRequestPlannedFormViewModel
    {
        public int expandedRowKeys { get; set; }//hangi seansýn listede açýk olarak geleceði belirtilecek
        public List<PlannedPhyOrderDetailInfo> selectedRowKeysResultList { get; set; }//seçili iþlem listesi
        public bool IsSessionRecalculate { get; set; }//seans öteleme için tüm iþlemlerin tarihleri deðiþtirilsin mi?//true ise seans ötelenir
        public bool sessionRecalculateByDate { get; set; }//seans öteleme için günlere sadýk kalýnsýn mý?
        public DateTime SessionChangedDate { get; set; }//tarih deðiþimi-öteleme için tarih seçimi

        public string Message { get; set; }

        public List<ReportItem> ReportItemList { get; set; }

        public PackageProcedureDefinition PackageProcedure { get; set; }
        public PhysiotherapyReports Report { get; set; }
        public TreatmentQueryReportTypeEnum TreatmentType { get; set; }

        public bool CanComplatePhysiotherapyRequest { get; set; }

        //Yetki Kontrolü
        public bool HasRole_Fizyoterapi_Uygulamasi_Uygulama;
        public bool HasRole_Fizyoterapi_Uygulamasi_Durdurma;
        public bool HasRole_Fizyoterapi_Uygulamasi_Hasta_Gelmedi;
        public bool HasRole_Fizyoterapi_Uygulamasi_Iptal_Et;
        public bool HasRole_Fizyoterapi_Tarih_Guncelleme;
        public bool HasRole_Fizyoterapi_Ek_Islem;
        public bool HasRole_Fizyoterapi_Uygulamasi_Geri_Alma;

        //public bool IsPhysiotherapyRequestFormUsing { get; set; }//Sistem parametresi kontrol

        public string MedicalInfo { get; set; }
        public string AnamnesisComplaintInfo { get; set; }
        public string AnamnesisPatientHistoryInfo { get; set; }
        public string AnamnesisPhysicalExaminationInfo { get; set; }
        public string AnamnesisMTSConclusionInfo { get; set; }
        public bool HideAnamnesisInfoButton = true;

        public List<TreatmentDiagnosisUnitInfo> TreatmentDiagnosisUnitInfos { get; set; }

        public string PatientObjectId { get; set; }

        public PlannedPhyOrderDetailInfo ChangedOrderDetail { get; set; }

        public List<PlannedOrderDetailSessionInfo> OrderDetailInfoList { get; set; }
        //public List<PlannedPhyOrderDetailInfo> OrderDetailInfoList { get; set; }
        //public List<PlannedPhyOrderDetailInfo> AdditionalOrderDetailInfoList { get; set; }//Ek Tedavi

        public string PhysiotherapySessionRate { get; set; }

        public List<OrderInfo> PhysiotherapyOrderList { get; set; }
        public PhysiotherapyOrderPlannedFormViewModel selectedPhysiotherapyOrderPlannedFormViewModel { get; set; }

        public DateTime LastOrderDetailStartDate { get; set; }
        public DateTime LastOrderDetailFinishDate { get; set; }
        public ResUser LastOrderDetailResponsiblePhysiotherapist { get; set; }

        public ProcedureDefinition[] ProcedureObjectDataSource { get; set; }


    }

    public class PlannedOrderDetailSessionInfo
    {
        public List<PlannedPhyOrderDetailInfo> OrderDetailList { get; set; }

        public string KeyNumber { get; set; }

        public string SessionNumber { get; set; }
        public string PlannedDate { get; set; }
        public string PhysiotherapyState { get; set; }
        public string ApplicationAreaDef { get; set; }
        public string ApplicationAreaInfo { get; set; }
        public string TreatmentDiagnosisUnit { get; set; }
        public string Duration { get; set; }
        public string Dose { get; set; }
        public string DoseDurationInfo { get; set; }
        public string Physiotherapist { get; set; }
        public Boolean IsAdditionalProcess { get; set; }//order detail ek iþlem
        public Boolean IsAdditionalTreatment { get; set; }//order detail ek tedavi
        public Guid CurrentUserObjectId { get; set; }//Ýþlemi Yapan
        public string ProcedureObject { get; set; }//Fizyoterapi iþlemi
        public string Package { get; set; }
        public bool PhyOrderIsPackageExists { get; set; }

        public string TreatmentProperties { get; set; }//Açýklama

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public ResUser ResponsiblePhysiotherapist { get; set; }

        //public PhysiotherapyOrderDetail OrderDetailItem { get; set; }
        public DateTime OrderDetailPlannedDate { get; set; }
        public Guid OrderDetailCurrentStateDefID { get; set; }
        public Guid OrderDetailObjectID { get; set; }
        public string OrderDetailObjectDef { get; set; }

        public Guid OrderObjectID { get; set; }


        public string PhysiotherapySessionId { get; set; }
        public string PhysiotherapySessionDef { get; set; }
    }

    public class PlannedPhyOrderDetailInfo
    {
        public string KeyNumber { get; set; }

        public string SessionNumber { get; set; }
        public string PlannedDate { get; set; }
        public string PhysiotherapyState { get; set; }
        public string ApplicationAreaDef { get; set; }
        public string ApplicationAreaInfo { get; set; }
        public string TreatmentDiagnosisUnit { get; set; }
        public string Duration { get; set; }
        public string Dose { get; set; }
        public string DoseDurationInfo { get; set; }
        public string Physiotherapist { get; set; }
        public Boolean IsAdditionalProcess { get; set; }//order detail ek iþlem
        public Boolean IsAdditionalTreatment { get; set; }//order detail ek tedavi
        public Guid CurrentUserObjectId { get; set; }//Ýþlemi Yapan
        public string ProcedureObject { get; set; }//Fizyoterapi iþlemi
        public string Package { get; set; }

        public bool PhyOrderIsPackageExists { get; set; }

        public string TreatmentProperties { get; set; }//Açýklama

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public ResUser ResponsiblePhysiotherapist { get; set; }

        //public PhysiotherapyOrderDetail OrderDetailItem { get; set; }
        public DateTime OrderDetailPlannedDate { get; set; }
        public Guid OrderDetailCurrentStateDefID { get; set; }
        public Guid OrderDetailObjectID { get; set; }
        public string OrderDetailObjectDef { get; set; }

        public Guid OrderObjectID { get; set; }


        public string PhysiotherapySessionId { get; set; }
        public string PhysiotherapySessionDef { get; set; }
    }

    public class TreatmentUnitAndRequest
    {
        public Guid PhysiotherapyRequestId { get; set; }
        public Guid PhysiotherapyRequestDefId { get; set; }
        public List<TreatmentDiagnosisInfo> TreatmentDiagnosisInfoList { get; set; }
    }
}
