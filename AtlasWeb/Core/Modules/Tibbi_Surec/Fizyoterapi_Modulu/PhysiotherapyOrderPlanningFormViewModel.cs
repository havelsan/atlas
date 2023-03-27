//$1BDD46B5
using System;
using Core.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Infrastructure.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using TTVisual;
using TTDefinitionManagement;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class PhysiotherapyOrderServiceController
    {
        partial void PreScript_PhysiotherapyOrderPlanningForm(PhysiotherapyOrderPlanningFormViewModel viewModel, PhysiotherapyOrder physiotherapyOrder, TTObjectContext objectContext)
        {
            viewModel.IsPhysiotherapyRequestFormUsing = TTObjectClasses.SystemParameter.GetParameterValue("USEPHYSIOTHERAPYREQUESTFORM", "") == "TRUE" ? true : false;

            viewModel.IsAppointmentActive = TTObjectClasses.SystemParameter.GetParameterValue("IsAppointmentActive", "FALSE") == "FALSE" ? false : true;
            
            if (viewModel.IsPhysiotherapyRequestFormUsing == false)//?????????????
            {
                Guid? activeEpisodeObjectID = viewModel.GetSelectedEpisodeActionID();
                if (activeEpisodeObjectID.HasValue)
                {
                    EpisodeAction activeEpisodeAction = objectContext.GetObject<EpisodeAction>(activeEpisodeObjectID.Value);
                    physiotherapyOrder.Episode = activeEpisodeAction.Episode;
                    physiotherapyOrder.PhysiotherapyRequest = activeEpisodeAction as PhysiotherapyRequest;//????????????????

                    if (physiotherapyOrder.SubEpisode == null)
                        physiotherapyOrder.SetMandatoryEpisodeActionProperties(physiotherapyOrder.PhysiotherapyRequest, physiotherapyOrder.PhysiotherapyRequest.MasterResource, true);
                }
            }

            #region hatal� veriler d�zeltiliyor

            //foreach (var ordersItems in physiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrders)
            //{
            //    foreach (var orderDetailItems in ordersItems.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyRequest == null))
            //    {
            //        //if (orderDetailItems.PhysiotherapyRequest == null && orderDetailItems.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled)
            //        //{
            //        orderDetailItems.PhysiotherapyRequest = physiotherapyOrder.PhysiotherapyRequest;
            //        //}
            //    }
            //}
            //foreach (var detailItem in physiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyOrder == null))
            //{
            //    //if (detailItem.PhysiotherapyOrder == null && detailItem.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled)
            //    //{
            //    detailItem.CurrentStateDefID = PhysiotherapyOrderDetail.States.Cancelled;
            //    //}
            //}
            #endregion

            if (physiotherapyOrder.SubEpisode.IsSGK == true)
            {
                viewModel.IsSGKPatient = true;
            }
            else
            {
                viewModel.IsSGKPatient = false;
            }

            viewModel.IsReadOnlyFields = false;

            var executionPhysiotherapyOrderDetails = physiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution);

            //Daha �nce girilen veriler default set ediliyor
            if (physiotherapyOrder.PhysiotherapyRequest != null && physiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrders.Count > 1)
            {
                PhysiotherapyOrder _lastPhysiotherapyOrder = new PhysiotherapyOrder();
                if (executionPhysiotherapyOrderDetails.Count() > 0)
                {
                    _lastPhysiotherapyOrder = executionPhysiotherapyOrderDetails.FirstOrDefault().PhysiotherapyOrder;
                    viewModel.IsReadOnlyFields = true;
                }
                else
                {
                    _lastPhysiotherapyOrder = physiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID == PhysiotherapyOrder.States.Completed || c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception).FirstOrDefault();
                }
                physiotherapyOrder.IsPaidTreatment = _lastPhysiotherapyOrder.IsPaidTreatment;


                if (physiotherapyOrder.SeansGunSayisi == null && physiotherapyOrder.IncludeFriday == null && // planlama yap�lmam�� ve herhangi bir g�n se�imi kaydedilmemi� ise eski i�lemin se�imleri i�aretlenecek
                    physiotherapyOrder.IncludeMonday == null && physiotherapyOrder.IncludeSaturday == null &&
                    physiotherapyOrder.IncludeSunday == null && physiotherapyOrder.IncludeThursday == null &&
                    physiotherapyOrder.IncludeTuesday == null && physiotherapyOrder.IncludeWednesday == null)
                {
                    physiotherapyOrder.SeansGunSayisi = _lastPhysiotherapyOrder.SeansGunSayisi;
                    physiotherapyOrder.IncludeFriday = _lastPhysiotherapyOrder.IncludeFriday;
                    physiotherapyOrder.IncludeMonday = _lastPhysiotherapyOrder.IncludeMonday;
                    physiotherapyOrder.IncludeSaturday = _lastPhysiotherapyOrder.IncludeSaturday;
                    physiotherapyOrder.IncludeSunday = _lastPhysiotherapyOrder.IncludeSunday;
                    physiotherapyOrder.IncludeThursday = _lastPhysiotherapyOrder.IncludeThursday;
                    physiotherapyOrder.IncludeTuesday = _lastPhysiotherapyOrder.IncludeTuesday;
                    physiotherapyOrder.IncludeWednesday = _lastPhysiotherapyOrder.IncludeWednesday;

                    physiotherapyOrder.PhysiotherapyStartDate = _lastPhysiotherapyOrder.PhysiotherapyStartDate;
                }

                if (physiotherapyOrder.PhysiotherapyStartDate.HasValue)
                    viewModel.startDate = physiotherapyOrder.PhysiotherapyStartDate != null ? physiotherapyOrder.PhysiotherapyStartDate.Value : Common.RecTime();

                var planDate = physiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrderDetails.Where(x => x.PhysiotherapyOrder != null && x.PhysiotherapyOrder.IsAdditionalTreatment != true).OrderByDescending(c => c.PlannedDate).FirstOrDefault()?.PlannedDate;
                if (planDate.HasValue)
                    viewModel.endDate = planDate.Value;
            }

            DateTime newDate = new DateTime();
            if (viewModel.startDate == newDate)
            {
                viewModel.startDate = Common.RecTime();
            }
            if (viewModel.endDate == newDate)
            {
                viewModel.endDate = Common.RecTime();
            }

            viewModel.ReportList = new List<PhysiotherapyReports>();
            foreach (var orderItem in physiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrders.Where(x => x.PhysiotherapyReports != null && x.PhysiotherapyReports.ReportNo != null).GroupBy(x => x.PhysiotherapyReports.ReportNo).ToList())
            {
                viewModel.ReportList.Add(orderItem.FirstOrDefault().PhysiotherapyReports);
            }

            if ((physiotherapyOrder.PhysiotherapyReports == null || physiotherapyOrder.PhysiotherapyReports.ReportNo == null) && physiotherapyOrder.FTRApplicationAreaDef != null && physiotherapyOrder.PackageProcedure != null)//orderlar i��erisinde ayn� v�cut b�lgesine ait rapor default olarak set edildi
            {
                var existingReport = physiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrders.Where(c => c.PhysiotherapyReports != null && c.PhysiotherapyReports.ReportNo != null && c.FTRApplicationAreaDef == physiotherapyOrder.FTRApplicationAreaDef && c.PackageProcedure == physiotherapyOrder.PackageProcedure);

                if (existingReport.Count() > 0)
                {
                    physiotherapyOrder.PhysiotherapyReports = existingReport.FirstOrDefault().PhysiotherapyReports;
                    viewModel.IsReportExistsAndCalculateDetail = true;//Raporu var
                }
            }

            if (physiotherapyOrder.PhysiotherapyReports == null || physiotherapyOrder.PhysiotherapyReports.ReportNo == null)//Rapor ba�lat�ld�
            {
                physiotherapyOrder.PhysiotherapyReports = new PhysiotherapyReports(objectContext);
            }

            if (physiotherapyOrder.PhysiotherapyReports != null && physiotherapyOrder.PhysiotherapyReports.FTRApplicationAreaDef != null && physiotherapyOrder.FTRApplicationAreaDef == null)
            {
                physiotherapyOrder.FTRApplicationAreaDef = physiotherapyOrder.PhysiotherapyReports.FTRApplicationAreaDef;//Rapordan gelen v�cut b�lgesi default olarak set edildi
            }

            if (physiotherapyOrder.PhysiotherapyReports != null && physiotherapyOrder.PhysiotherapyReports.LocalReportId != null)
            {
                viewModel.IsMedulaNotWorking = true; //true ise medula �al��m�yor. Lokal medula raporlar� sorgulanacak
            }

            // �stteki viewmodelden alacak
            // viewModel.ProcedureObjectDataSource = PhysiotherapyDefinition.GetAllPhysiotherapyDefinitions(new TTObjectContext(true)).ToArray();

            if (physiotherapyOrder.ProcedureObject != null)
            {
                List<ProcedureDefinition> _sdf = new List<ProcedureDefinition>();
                _sdf.Add(physiotherapyOrder.ProcedureObject);
                viewModel.ProcedureObjectList = _sdf.ToArray();
            }

            //e�er �cretli physiotherapyOrder'�n herhangi bir PhysiotherapyOrderDetail'i tamamlanm�� ise �cret durumu de�i�emez!
            if (physiotherapyOrder.PhysiotherapyOrderDetails.Where(x => x.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution).Count() > 0)
            {
                viewModel.IsPaymentObject = true;
            }
            else
            {
                viewModel.IsPaymentObject = false;
            }

            PayerTypeEnum? payerType = physiotherapyOrder.SubEpisode.OpenSubEpisodeProtocol.Payer.Type.PayerType;
            if (physiotherapyOrder.SubEpisode.OpenSubEpisodeProtocol != null && payerType.HasValue && payerType == PayerTypeEnum.Paid)//�cretli hasta ise �cretli checki true yap�l�p readonly olacak
            {
                viewModel.IsPaymentObject = true;
                physiotherapyOrder.IsPaidTreatment = true;
            }

            #region Rapor var ise detay hesapla, rapor yok ise �cretli olarak i�aretlenmeden hesaplama yapma
            if ((physiotherapyOrder.PhysiotherapyReports == null || (physiotherapyOrder.PhysiotherapyReports != null && physiotherapyOrder.PhysiotherapyReports.ReportNo == null)) && physiotherapyOrder.IsPaidTreatment == false)
            {
                viewModel.IsReportExistsAndCalculateDetail = false;//hesaplama yap�lamaz
            }
            else
            {
                viewModel.IsReportExistsAndCalculateDetail = true;//hesaplama yap�labilir
            }
            #endregion

            var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, physiotherapyOrder.ObjectDef.ID, "PhysiotherapyOrderTemplate").ToList();
            viewModel.userTemplateList = new List<UserTemplateModel>();
            foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList.Where(t => t.TAObjectID.ToString() != physiotherapyOrder.ObjectID.ToString()))
            {
                UserTemplateModel templateModel = new UserTemplateModel();
                templateModel.ObjectID = item.ObjectID;
                templateModel.TAObjectID = item.TAObjectID;
                templateModel.TAObjectDefID = item.TAObjectDefID;
                templateModel.Description = item.Description;
                viewModel.userTemplateList.Add(templateModel);
            }

            if (viewModel.IsAppointmentActive)
            {
                var appointmentObj = Appointment.GetByEpisodeActionAndState(objectContext, physiotherapyOrder.ObjectID.ToString(), Appointment.States.New.ToString());
                if (appointmentObj.Count > 0)
                {
                    viewModel._Appointment = appointmentObj.FirstOrDefault();
                }
                else
                {
                    viewModel._Appointment = new Appointment(objectContext);
                }

                viewModel._Appointment.EpisodeAction = physiotherapyOrder;
                viewModel._Appointment.AppDate = physiotherapyOrder.PhysiotherapyStartDate != null ? physiotherapyOrder.PhysiotherapyStartDate : Common.RecTime();
                viewModel._Appointment.Resource = physiotherapyOrder.TreatmentRoom;
                viewModel._Appointment.MasterResource = physiotherapyOrder.TreatmentDiagnosisUnit;
            }

            ContextToViewModel(viewModel, objectContext);
        }

        partial void PostScript_PhysiotherapyOrderPlanningForm(PhysiotherapyOrderPlanningFormViewModel viewModel, PhysiotherapyOrder physiotherapyOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (physiotherapyOrder.PackageProcedure == null)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26680", "Paket hizmeti se�meden devam edemezsiniz."));

            physiotherapyOrder.MasterResource = physiotherapyOrder.TreatmentDiagnosisUnit;

            if (physiotherapyOrder.FinishSession != null && physiotherapyOrder.StartSession != null)
            {
                physiotherapyOrder.Amount = physiotherapyOrder.FinishSession - physiotherapyOrder.StartSession + 1;
            }
            else
            {
                physiotherapyOrder.Amount = 0;
            }

            if (physiotherapyOrder.PhysiotherapyReports != null && physiotherapyOrder.PhysiotherapyReports.ReportNo == null)
            {
                physiotherapyOrder.PhysiotherapyReports = null;
            }
            else if (physiotherapyOrder.PhysiotherapyReports != null && physiotherapyOrder.PhysiotherapyReports.ReportNo != null)
            {
                //Mevcut rapora ait order varsa ayn� rapor �zerinden i�lem yap�lmal�
                var sameReportOrder = physiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrders.Where(c => c.ObjectID != physiotherapyOrder.ObjectID && c.PhysiotherapyReports != null && c.PhysiotherapyReports.ReportNo == physiotherapyOrder.PhysiotherapyReports.ReportNo);

                if (physiotherapyOrder.PhysiotherapyReports == null && sameReportOrder.Count() > 0)/*&& c.PhysiotherapyReports.ReportNo == physiotherapyOrder.PhysiotherapyReports.ReportNo*/
                {
                    physiotherapyOrder.PhysiotherapyReports = sameReportOrder.FirstOrDefault().PhysiotherapyReports;
                }
            }

            if (physiotherapyOrder.PhysiotherapyReports != null && physiotherapyOrder.PhysiotherapyReports.FTRApplicationAreaDef != null && physiotherapyOrder.FTRApplicationAreaDef == null)
            {
                physiotherapyOrder.FTRApplicationAreaDef = physiotherapyOrder.PhysiotherapyReports.FTRApplicationAreaDef;
            }

            if (physiotherapyOrder.PhysiotherapyRequest != null && physiotherapyOrder.PhysiotherapyRequest.ProcedureDoctor != null)
            {
                physiotherapyOrder.ProcedureDoctor = physiotherapyOrder.PhysiotherapyRequest.ProcedureDoctor;
            }



            if (viewModel.ProcedureObjectList.Length > 0)
            {
                physiotherapyOrder.ProcedureObject = viewModel.ProcedureObjectList[0];

                if (physiotherapyOrder.StartSession > physiotherapyOrder.FinishSession)
                {
                    throw new Exception("Ba�lang�� Seans� Biti� Seans�ndan B�y�k Olamaz!");
                }

                //Daha �nceden planlama yap�lm��sa ve herhangi bir i�lem durdurulmu� ya da tamamlanm��sa yeniden hesaplama yap�lmaz
                if (physiotherapyOrder.PhysiotherapyOrderDetails != null &&
                    physiotherapyOrder.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Aborted || c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed).Count() == 0)
                {
                    foreach (var item in physiotherapyOrder.PhysiotherapyOrderDetails)//Daha �nceden planlama yap�lm��sa yenisi yap�l�rken eskiler silinmeli
                    {
                        item.CurrentStateDefID = PhysiotherapyOrderDetail.States.Cancelled;
                    }
                    if (viewModel.IsReportExistsAndCalculateDetail == true)
                    {
                        CalculateOrderDetails(viewModel, physiotherapyOrder, transDef, objectContext);
                    }
                }
                else
                {
                    throw new Exception("Planlamas� yap�lm�� i�lemin �zerinde de�i�iklik yap�lamaz!");
                }

            }

            if (viewModel.ProcedureObjectList.Length > 1)
            {
                for (int i = 1; i < viewModel.ProcedureObjectList.Length; i++)
                {
                    PhysiotherapyOrder order = new PhysiotherapyOrder(objectContext);

                    order.ProcedureObject = viewModel.ProcedureObjectList[i];

                    order.MasterResource = physiotherapyOrder.TreatmentDiagnosisUnit;
                    order.PackageProcedure = physiotherapyOrder.PackageProcedure;
                    order.DoseDurationInfo = physiotherapyOrder.DoseDurationInfo;

                    order.IsPaidTreatment = physiotherapyOrder.IsPaidTreatment;
                    order.ProcedureDoctor = physiotherapyOrder.ProcedureDoctor;
                    order.PhysiotherapyRequest = physiotherapyOrder.PhysiotherapyRequest;
                    order.ApplicationArea = physiotherapyOrder.ApplicationArea;
                    order.Dose = physiotherapyOrder.Dose;
                    order.Duration = physiotherapyOrder.Duration;
                    order.FinishSession = physiotherapyOrder.FinishSession;
                    order.IncludeFriday = physiotherapyOrder.IncludeFriday;
                    order.IncludeMonday = physiotherapyOrder.IncludeMonday;
                    order.IncludeSaturday = physiotherapyOrder.IncludeSaturday;
                    order.IncludeSunday = physiotherapyOrder.IncludeSunday;
                    order.IncludeThursday = physiotherapyOrder.IncludeThursday;
                    order.IncludeTuesday = physiotherapyOrder.IncludeTuesday;
                    order.IncludeWednesday = physiotherapyOrder.IncludeWednesday;
                    order.PhysiotherapyStartDate = physiotherapyOrder.PhysiotherapyStartDate;
                    order.raporTakipNo = physiotherapyOrder.raporTakipNo;
                    order.SeansGunSayisi = physiotherapyOrder.SeansGunSayisi;
                    order.StartSession = physiotherapyOrder.StartSession;
                    order.TreatmentProperties = physiotherapyOrder.TreatmentProperties;
                    order.FTRApplicationAreaDef = physiotherapyOrder.FTRApplicationAreaDef;
                    order.PhysiotherapyReports = physiotherapyOrder.PhysiotherapyReports;
                    order.ResUser = physiotherapyOrder.ResUser;
                    order.TreatmentDiagnosisUnit = physiotherapyOrder.TreatmentDiagnosisUnit;
                    order.TreatmentRoom = physiotherapyOrder.TreatmentRoom;
                    order.Amount = physiotherapyOrder.Amount;
                    order.SessionCount = physiotherapyOrder.SessionCount;
                    order.IsAdditionalTreatment = physiotherapyOrder.IsAdditionalTreatment;


                    //Daha �nceden planlama yap�lm��sa ve herhangi bir i�lem durdurulmu� ya da tamamlanm��sa yeniden hesaplama yap�lmaz
                    if (order.PhysiotherapyOrderDetails != null &&
                        order.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Aborted && c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed).Count() == 0)
                    {
                        foreach (var item in order.PhysiotherapyOrderDetails)//var olan order detailller temizleniyor
                        {
                            item.CurrentStateDefID = PhysiotherapyOrderDetail.States.Cancelled;
                        }
                        //order.PhysiotherapyOrderDetails.Clear();
                        //CalculateOrderDetails(viewModel, physiotherapyOrder, transDef, objectContext);
                        if (viewModel.IsReportExistsAndCalculateDetail)
                        {
                            CalculateOrderDetails(viewModel, order, transDef, objectContext);
                        }

                    }
                    else
                    {
                        throw new Exception("Planlamas� yap�lm�� i�lemin �zerinde de�i�iklik yap�lamaz!");
                    }
                }
            }

            Max5DaysControl(physiotherapyOrder.PhysiotherapyRequest);
        }

        /*Medula Raporu Sorgulama : Hasta Sgk hastas� ise yaz�lan medula raporlar� sorgulan�yor.*/
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Rapor_Sorgulama)]
        public PhysiotherapyOrderPlanningFormViewModel GetReportInfoByTreatmentType(ReportTypeWithEpisodeId reportTypeWithEpisodeId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                TreatmentQueryReportTypeEnum treatmentType = reportTypeWithEpisodeId.treatmentType;
                Guid? activeEpisodeObjectID = reportTypeWithEpisodeId.activeEpisodeObjectID;
                Episode activeEpisode = new Episode();
                if (activeEpisodeObjectID.HasValue)
                {
                    activeEpisode = objectContext.GetObject<Episode>(activeEpisodeObjectID.Value);
                }

                PhysiotherapyOrderPlanningFormViewModel viewModel = new PhysiotherapyOrderPlanningFormViewModel();
                viewModel.Message = "";
                viewModel.ReportItemList = new List<ReportItem>();

                if (treatmentType != null)
                {

                    RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
                    //TODO : MEDULA20140501
                    _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                    _raporOkuTCKimlikNodanDVO.raporTuru = "1";

                    if (activeEpisode.Patient.Privacy != null && activeEpisode.Patient.Privacy == true)//Gizli hasta ise
                    {
                        if (activeEpisode.Patient.PrivacyUniqueRefNo == null)//&& activeEpisode.Patient.PrivacyPatient.YUPASSNO == null
                        {
                            viewModel.Message = TTUtils.CultureService.GetText("M26315", "Ki�inin Sistemde Tan�ml� Bir Kimlik Numaras� Yoktur. ��lem Yapmadan �nce Kimlik Bilgilerini G�ncelleyiniz!!!");
                        }

                        if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("TEDAVIRAPORUSORGU", "TRUE")) == true)
                        {
                            _raporOkuTCKimlikNodanDVO.tckimlikNo = activeEpisode.Patient.PrivacyUniqueRefNo.Value.ToString();
                        }
                        else
                        {
                            _raporOkuTCKimlikNodanDVO.tckimlikNo = activeEpisode.Patient.PrivacyUniqueRefNo.Value.ToString();
                        }
                    }
                    else//Gizli hasta de�ilse
                    {
                        if (activeEpisode.Patient.UniqueRefNo == null && activeEpisode.Patient.YUPASSNO == null)
                        {
                            viewModel.Message = TTUtils.CultureService.GetText("M26315", "Ki�inin Sistemde Tan�ml� Bir Kimlik Numaras� Yoktur. ��lem Yapmadan �nce Kimlik Bilgilerini G�ncelleyiniz!!!");
                        }

                        if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("TEDAVIRAPORUSORGU", "TRUE")) == true)
                        {

                            if (activeEpisode.Patient.YUPASSNO != null)
                                _raporOkuTCKimlikNodanDVO.tckimlikNo = activeEpisode.Patient.YUPASSNO.Value.ToString();
                            else
                                _raporOkuTCKimlikNodanDVO.tckimlikNo = activeEpisode.Patient.UniqueRefNo.Value.ToString();
                        }
                        else
                        {
                            if (activeEpisode.Patient.UniqueRefNo != null)
                                _raporOkuTCKimlikNodanDVO.tckimlikNo = activeEpisode.Patient.UniqueRefNo.Value.ToString();
                            else
                                _raporOkuTCKimlikNodanDVO.tckimlikNo = activeEpisode.Patient.YUPASSNO.Value.ToString();
                        }
                    }

                    RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);

                    if (response != null)
                    {
                        if (!response.sonucKodu.Equals(0))
                        {

                            viewModel.Message = "Sonuc A��klamas� : " + response.sonucAciklamasi + " Sonu� Kodu :" + response.sonucKodu;
                        }
                        if (response.raporlar == null)
                        {
                            viewModel.Message = TTUtils.CultureService.GetText("M26311", "Ki�inin D�� XXXXXX Rapor Bilgisi Bulunamam��t�r.");
                        }
                        if (response.sonucKodu.Equals(0))
                        {
                            if (response.raporlar != null && response.raporlar.Length > 0)
                            {
                                string raporTuru = string.Empty;
                                IList fTRVucutBolgesiList = FTRVucutBolgesi.GetFTRVucutBolgesi(objectContext);
                                foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
                                {
                                    Boolean saveRaport = false;
                                    ReportItem _reportItem = new ReportItem();
                                    PhysiotherapyReports _physiotherapyReport = new PhysiotherapyReports(objectContext);
                                    if (item.tedaviRapor != null)
                                    {
                                        if (item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu == Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX")))
                                        {
                                            _physiotherapyReport.TreatmentType = treatmentType;
                                            //Tan� Grubu
                                            if (treatmentType == TreatmentQueryReportTypeEnum.FTR)
                                            {
                                                if (item.tedaviRapor.tedaviRaporTuru == 5 || item.tedaviRapor.tedaviRaporTuru == 7)
                                                {
                                                    foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
                                                    {
                                                        _physiotherapyReport.ReportType = item.tedaviRapor.raporDVO.duzenlemeTuru == "1" ? true : false;
                                                        foreach (FTRVucutBolgesi fTRVucutBolgesi in fTRVucutBolgesiList)
                                                        {
                                                            if (fTRVucutBolgesi.ftrVucutBolgesiKodu == tedaviIslemBilgisiDVO.ftrRaporBilgisi.ftrVucutBolgesiKodu)
                                                            {
                                                                _physiotherapyReport.FTRApplicationAreaDef = fTRVucutBolgesi;
                                                                _physiotherapyReport.ReportInfo = " K�r :" + tedaviIslemBilgisiDVO.ftrRaporBilgisi.seansSayi.ToString();
                                                                _physiotherapyReport.SessionLimit = tedaviIslemBilgisiDVO.ftrRaporBilgisi.seansSayi;
                                                                _physiotherapyReport.PackageProcedureInfo = tedaviIslemBilgisiDVO.ftrRaporBilgisi.butKodu;
                                                                _physiotherapyReport.TreatmentProcessType = tedaviIslemBilgisiDVO.ftrRaporBilgisi.tedaviTuru;
                                                                _physiotherapyReport.ReportTime = tedaviIslemBilgisiDVO.ftrRaporBilgisi.seansGun;
                                                            }
                                                        }
                                                    }
                                                    if (item.tedaviRapor.tedaviRaporTuru == 7)
                                                    {
                                                        _physiotherapyReport.ReportNo = item.raporTakipNo.ToString();
                                                        _physiotherapyReport.ReportDate = DateTime.Parse(item.tedaviRapor.raporDVO.raporBilgisi.tarih);
                                                        _physiotherapyReport.ReportStartDate = DateTime.Parse(item.tedaviRapor.raporDVO.baslangicTarihi);
                                                        _physiotherapyReport.ReportEndDate = DateTime.Parse(item.tedaviRapor.raporDVO.bitisTarihi);
                                                        _physiotherapyReport.DiagnosisGroup = item.tedaviRapor.raporDVO.tanilar.FirstOrDefault().taniKodu;
                                                        saveRaport = true;
                                                    }
                                                    else
                                                    {
                                                        _physiotherapyReport.ReportNo = item.raporTakipNo.ToString();
                                                        _physiotherapyReport.ReportDate = DateTime.Parse(item.tedaviRapor.raporDVO.raporBilgisi.tarih);
                                                        _physiotherapyReport.ReportStartDate = DateTime.Parse(item.tedaviRapor.raporDVO.baslangicTarihi);
                                                        _physiotherapyReport.ReportEndDate = DateTime.Parse(item.tedaviRapor.raporDVO.bitisTarihi);
                                                        _physiotherapyReport.DiagnosisGroup = item.tedaviRapor.raporDVO.tanilar.FirstOrDefault().taniKodu;
                                                        saveRaport = true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (item.tedaviRapor.tedaviRaporTuru == 3)
                                                {
                                                    foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
                                                    {
                                                        foreach (FTRVucutBolgesi fTRVucutBolgesi in fTRVucutBolgesiList)
                                                        {
                                                            if (fTRVucutBolgesi.ftrVucutBolgesiKodu == tedaviIslemBilgisiDVO.eswtRaporBilgisi.eswtVucutBolgesiKodu)
                                                            {
                                                                _physiotherapyReport.FTRApplicationAreaDef = fTRVucutBolgesi;
                                                                _physiotherapyReport.ReportInfo = " K�r :" + tedaviIslemBilgisiDVO.eswtRaporBilgisi.seansSayi.ToString();
                                                                _physiotherapyReport.SessionLimit = tedaviIslemBilgisiDVO.eswtRaporBilgisi.seansSayi;
                                                                _physiotherapyReport.PackageProcedureInfo = tedaviIslemBilgisiDVO.eswtRaporBilgisi.butKodu;
                                                                _physiotherapyReport.TreatmentProcessType = "";
                                                                _physiotherapyReport.ReportTime = tedaviIslemBilgisiDVO.eswtRaporBilgisi.seansGun;
                                                            }
                                                        }
                                                    }
                                                    if (item.tedaviRapor.tedaviRaporTuru == 7)
                                                    {
                                                        _physiotherapyReport.ReportNo = item.raporTakipNo.ToString();
                                                        _physiotherapyReport.ReportDate = DateTime.Parse(item.tedaviRapor.raporDVO.raporBilgisi.tarih);
                                                        _physiotherapyReport.ReportStartDate = DateTime.Parse(item.tedaviRapor.raporDVO.baslangicTarihi);
                                                        _physiotherapyReport.ReportEndDate = DateTime.Parse(item.tedaviRapor.raporDVO.bitisTarihi);
                                                        _physiotherapyReport.DiagnosisGroup = item.tedaviRapor.raporDVO.tanilar.FirstOrDefault().taniKodu;
                                                        saveRaport = true;
                                                    }
                                                    else
                                                    {

                                                        _physiotherapyReport.ReportNo = item.raporTakipNo.ToString();
                                                        _physiotherapyReport.ReportDate = DateTime.Parse(item.tedaviRapor.raporDVO.raporBilgisi.tarih);
                                                        _physiotherapyReport.ReportStartDate = DateTime.Parse(item.tedaviRapor.raporDVO.baslangicTarihi);
                                                        _physiotherapyReport.ReportEndDate = DateTime.Parse(item.tedaviRapor.raporDVO.bitisTarihi);
                                                        _physiotherapyReport.DiagnosisGroup = item.tedaviRapor.raporDVO.tanilar.FirstOrDefault().taniKodu;
                                                        saveRaport = true;
                                                    }
                                                }
                                            }

                                        }
                                    }

                                    if (saveRaport == true)//e�er kaydedilecek rapor varsa
                                    {
                                        _reportItem.FTRApplicationAreaDef = _physiotherapyReport.FTRApplicationAreaDef;

                                        _reportItem.ReportObj = _physiotherapyReport;

                                        _reportItem.ReportNo = _physiotherapyReport.ReportNo;
                                        _reportItem.ReportDate = _physiotherapyReport.ReportDate != null ? _physiotherapyReport.ReportDate.Value.ToString("yyyy/MM/dd") : "";
                                        _reportItem.ReportStartDate = _physiotherapyReport.ReportStartDate != null ? _physiotherapyReport.ReportStartDate.Value.ToString("yyyy/MM/dd") : "";
                                        _reportItem.ReportEndDate = _physiotherapyReport.ReportEndDate != null ? _physiotherapyReport.ReportEndDate.Value.ToString("yyyy/MM/dd") : "";
                                        _reportItem.ApplicationAreaName = _physiotherapyReport.FTRApplicationAreaDef == null ? "" : _physiotherapyReport.FTRApplicationAreaDef.ftrVucutBolgesiAdi;
                                        _reportItem.ReportType = _physiotherapyReport.ReportType == true ? TTUtils.CultureService.GetText("M25931", "Heyet Raporu") : TTUtils.CultureService.GetText("M27086", "Tek Hekim Raporu");
                                        _reportItem.ReportInfo = _physiotherapyReport.ReportInfo;
                                        _reportItem.ReportTime = _physiotherapyReport.ReportTime != null ? _physiotherapyReport.ReportTime.ToString() : "";
                                        _reportItem.TreatmentType = Common.GetDisplayTextOfDataTypeEnum(_physiotherapyReport.TreatmentType);
                                        _reportItem.DiagnosisGroup = _physiotherapyReport.DiagnosisGroup;
                                        _reportItem.SessionLimit = _physiotherapyReport.SessionLimit != null ? _physiotherapyReport.SessionLimit.Value : 0;

                                        if (_physiotherapyReport.PackageProcedureInfo != null)
                                        {
                                            _reportItem.PackageProcedureDefinition = PackageProcedureDefinition.GetFTRPackageProceduresByCode(objectContext, _physiotherapyReport.PackageProcedureInfo).FirstOrDefault();
                                        }

                                        viewModel.ReportItemList.Add(_reportItem);
                                    }
                                }
                            }
                            else
                            {
                                viewModel.Message = TTUtils.CultureService.GetText("M26314", "Ki�inin Rapor Bilgisi Bulunamam��t�r. L�tfen �nce Rapor Olu�turunuz !");
                            }
                        }
                    }

                }
                else
                {
                    //_PhysiotherapyRequest.ReportNo = null;
                    //MedulaRaporTakipNo.Visible = false;
                    //labelMedulaRaporTakipNo.Visible = false;
                    //lblRaporBilgileri.Visible = false;
                    //MedulaRaporBilgileri.Visible = false;
                    //MedulaRaporTakipNo.Text = "";
                    //MedulaRaporBilgileri.Text = "";
                }

                return viewModel;
            }
        }


        /*Kurum Medula Raporu Sorgulama : Hasta Sgk hastas� ise ama medula �al��ma problemi varsa lokalde yaz�lan medula raporlar� sorgulan�yor. IsSendedMedula true olan ve medula raporu olan raporlar sorgulan�yor.*/
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Rapor_Sorgulama)]
        public PhysiotherapyOrderPlanningFormViewModel GetInstitutionMedulaReportByTreatmentType(ReportTypeWithEpisodeId reportTypeWithEpisodeId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                TreatmentQueryReportTypeEnum treatmentType = reportTypeWithEpisodeId.treatmentType;
                Guid? activeEpisodeObjectID = reportTypeWithEpisodeId.activeEpisodeObjectID;
                Episode activeEpisode = new Episode();
                if (activeEpisodeObjectID.HasValue)
                {
                    activeEpisode = objectContext.GetObject<Episode>(activeEpisodeObjectID.Value);
                }

                PhysiotherapyOrderPlanningFormViewModel viewModel = new PhysiotherapyOrderPlanningFormViewModel();
                viewModel.Message = "";
                viewModel.ReportItemList = new List<ReportItem>();

                if (treatmentType != null)
                {
                    if (activeEpisode == null || activeEpisode.Patient == null)
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M26310", "Ki�i bilgilerinde hata mevcuttur. L�tfen sistem y�neticinizle ba�lant� kurunuz!"));
                    }

                    if (activeEpisode.Patient.Privacy != null && activeEpisode.Patient.Privacy == true) //Gizli hasta ise
                    {
                        if (activeEpisode.Patient.PrivacyUniqueRefNo == null)//&& activeEpisode.Patient.YUPASSNO == null
                        {
                            viewModel.Message = TTUtils.CultureService.GetText("M26315", "Ki�inin Sistemde Tan�ml� Bir Kimlik Numaras� Yoktur. ��lem Yapmadan �nce Kimlik Bilgilerini G�ncelleyiniz!!!");
                        }
                    }
                    else  //Gizli hasta de�ilse
                    {
                        if (activeEpisode.Patient.UniqueRefNo == null && activeEpisode.Patient.YUPASSNO == null)
                        {
                            viewModel.Message = TTUtils.CultureService.GetText("M26315", "Ki�inin Sistemde Tan�ml� Bir Kimlik Numaras� Yoktur. ��lem Yapmadan �nce Kimlik Bilgilerini G�ncelleyiniz!!!");
                        }
                    }


                    if (treatmentType == TreatmentQueryReportTypeEnum.FTR)
                    {
                        BindingList<MedulaTreatmentReport.GetFtrMedulaReportInfoByPatient_Class> responseRaporlar = MedulaTreatmentReport.GetFtrMedulaReportInfoByPatient(activeEpisode.Patient.ObjectID);

                        if (responseRaporlar != null && responseRaporlar.Count > 0)
                        {
                            string raporTuru = string.Empty;
                            IList fTRVucutBolgesiList = FTRVucutBolgesi.GetFTRVucutBolgesi(objectContext);
                            foreach (var responseRaporlarItem in responseRaporlar)
                            {
                                Boolean saveRaport = false;
                                ReportItem _reportItem = new ReportItem();
                                PhysiotherapyReports _physiotherapyReport = new PhysiotherapyReports(objectContext);
                                _physiotherapyReport.TreatmentType = treatmentType;

                                _physiotherapyReport.ReportType = responseRaporlarItem.Reporttype == true ? true : false;
                                foreach (FTRVucutBolgesi fTRVucutBolgesi in fTRVucutBolgesiList)
                                {
                                    if (fTRVucutBolgesi.ObjectID == responseRaporlarItem.Ftrapplicationareadef)
                                    {
                                        _physiotherapyReport.FTRApplicationAreaDef = fTRVucutBolgesi;
                                    }
                                }
                                _physiotherapyReport.ReportInfo = " K�r :" + responseRaporlarItem.Sessionlimit;
                                _physiotherapyReport.SessionLimit = responseRaporlarItem.Sessionlimit;
                                _physiotherapyReport.PackageProcedureInfo = responseRaporlarItem.Packageprocedureinfo;
                                _physiotherapyReport.TreatmentProcessType = responseRaporlarItem.Treatmentprocesstype;
                                _physiotherapyReport.ReportTime = 365;



                                _physiotherapyReport.ReportNo = responseRaporlarItem.ReportNo != null ? responseRaporlarItem.ReportNo.ToString() : "";
                                _physiotherapyReport.ReportDate = responseRaporlarItem.RaporGonderimTarihi;
                                _physiotherapyReport.ReportStartDate = responseRaporlarItem.StartDate;
                                _physiotherapyReport.ReportEndDate = responseRaporlarItem.EndDate;
                                _physiotherapyReport.DiagnosisGroup = responseRaporlarItem.Diagnosecode;
                                _physiotherapyReport.LocalReportId = responseRaporlarItem.ObjectID;
                                saveRaport = true;


                                if (saveRaport == true)//e�er kaydedilecek rapor varsa
                                {
                                    _reportItem.FTRApplicationAreaDef = _physiotherapyReport.FTRApplicationAreaDef;

                                    _reportItem.ReportObj = _physiotherapyReport;

                                    _reportItem.ReportNo = _physiotherapyReport.ReportNo;
                                    _reportItem.ReportDate = _physiotherapyReport.ReportDate != null ? _physiotherapyReport.ReportDate.Value.ToString("yyyy/MM/dd") : "";
                                    _reportItem.ReportStartDate = _physiotherapyReport.ReportStartDate != null ? _physiotherapyReport.ReportStartDate.Value.ToString("yyyy/MM/dd") : "";
                                    _reportItem.ReportEndDate = _physiotherapyReport.ReportEndDate != null ? _physiotherapyReport.ReportEndDate.Value.ToString("yyyy/MM/dd") : "";
                                    _reportItem.ApplicationAreaName = _physiotherapyReport.FTRApplicationAreaDef == null ? "" : _physiotherapyReport.FTRApplicationAreaDef.ftrVucutBolgesiAdi;
                                    _reportItem.ReportType = _physiotherapyReport.ReportType == true ? TTUtils.CultureService.GetText("M25931", "Heyet Raporu") : TTUtils.CultureService.GetText("M27086", "Tek Hekim Raporu");
                                    _reportItem.ReportInfo = _physiotherapyReport.ReportInfo;
                                    _reportItem.ReportTime = _physiotherapyReport.ReportTime != null ? _physiotherapyReport.ReportTime.ToString() : "";
                                    _reportItem.TreatmentType = Common.GetDisplayTextOfDataTypeEnum(_physiotherapyReport.TreatmentType);
                                    _reportItem.DiagnosisGroup = _physiotherapyReport.DiagnosisGroup;
                                    _reportItem.SessionLimit = _physiotherapyReport.SessionLimit != null ? _physiotherapyReport.SessionLimit.Value : 0;

                                    if (_physiotherapyReport.PackageProcedureInfo != null)
                                    {
                                        _reportItem.PackageProcedureDefinition = PackageProcedureDefinition.GetFTRPackageProceduresByCode(objectContext, _physiotherapyReport.PackageProcedureInfo).FirstOrDefault();
                                    }

                                    viewModel.ReportItemList.Add(_reportItem);
                                }
                            }
                        }
                        else
                        {
                            viewModel.Message = TTUtils.CultureService.GetText("M26314", "Ki�inin Rapor Bilgisi Bulunamam��t�r. L�tfen �nce Rapor Olu�turunuz !");
                        }
                    }
                    else
                    {
                        BindingList<MedulaTreatmentReport.GetEswtMedulaReportInfoByPatient_Class> responseRaporlar = MedulaTreatmentReport.GetEswtMedulaReportInfoByPatient(activeEpisode.Patient.ObjectID);

                        if (responseRaporlar != null && responseRaporlar.Count > 0)
                        {
                            string raporTuru = string.Empty;
                            IList fTRVucutBolgesiList = FTRVucutBolgesi.GetFTRVucutBolgesi(objectContext);
                            foreach (var responseRaporlarItem in responseRaporlar)
                            {
                                Boolean saveRaport = false;
                                ReportItem _reportItem = new ReportItem();
                                PhysiotherapyReports _physiotherapyReport = new PhysiotherapyReports(objectContext);
                                _physiotherapyReport.TreatmentType = treatmentType;

                                _physiotherapyReport.ReportType = responseRaporlarItem.Reporttype == true ? true : false;
                                foreach (FTRVucutBolgesi fTRVucutBolgesi in fTRVucutBolgesiList)
                                {
                                    if (fTRVucutBolgesi.ObjectID == responseRaporlarItem.Ftrapplicationareadef)
                                    {
                                        _physiotherapyReport.FTRApplicationAreaDef = fTRVucutBolgesi;
                                    }
                                }
                                _physiotherapyReport.ReportInfo = " K�r :" + responseRaporlarItem.Sessionlimit;
                                _physiotherapyReport.SessionLimit = responseRaporlarItem.Sessionlimit;
                                _physiotherapyReport.PackageProcedureInfo = responseRaporlarItem.Packageprocedureinfo;
                                _physiotherapyReport.TreatmentProcessType = "A";
                                _physiotherapyReport.ReportTime = 365;



                                _physiotherapyReport.ReportNo = responseRaporlarItem.ReportNo != null ? responseRaporlarItem.ReportNo.ToString() : "";
                                _physiotherapyReport.ReportDate = responseRaporlarItem.RaporGonderimTarihi;
                                _physiotherapyReport.ReportStartDate = responseRaporlarItem.StartDate;
                                _physiotherapyReport.ReportEndDate = responseRaporlarItem.EndDate;
                                _physiotherapyReport.DiagnosisGroup = responseRaporlarItem.Diagnosecode;
                                _physiotherapyReport.LocalReportId = responseRaporlarItem.ObjectID;

                                saveRaport = true;


                                if (saveRaport == true)//e�er kaydedilecek rapor varsa
                                {
                                    _reportItem.FTRApplicationAreaDef = _physiotherapyReport.FTRApplicationAreaDef;

                                    _reportItem.ReportObj = _physiotherapyReport;

                                    _reportItem.ReportNo = _physiotherapyReport.ReportNo;
                                    _reportItem.ReportDate = _physiotherapyReport.ReportDate != null ? _physiotherapyReport.ReportDate.Value.ToString("yyyy/MM/dd") : "";
                                    _reportItem.ReportStartDate = _physiotherapyReport.ReportStartDate != null ? _physiotherapyReport.ReportStartDate.Value.ToString("yyyy/MM/dd") : "";
                                    _reportItem.ReportEndDate = _physiotherapyReport.ReportEndDate != null ? _physiotherapyReport.ReportEndDate.Value.ToString("yyyy/MM/dd") : "";
                                    _reportItem.ApplicationAreaName = _physiotherapyReport.FTRApplicationAreaDef == null ? "" : _physiotherapyReport.FTRApplicationAreaDef.ftrVucutBolgesiAdi;
                                    _reportItem.ReportType = _physiotherapyReport.ReportType == true ? TTUtils.CultureService.GetText("M25931", "Heyet Raporu") : TTUtils.CultureService.GetText("M27086", "Tek Hekim Raporu");
                                    _reportItem.ReportInfo = _physiotherapyReport.ReportInfo;
                                    _reportItem.ReportTime = _physiotherapyReport.ReportTime != null ? _physiotherapyReport.ReportTime.ToString() : "";
                                    _reportItem.TreatmentType = Common.GetDisplayTextOfDataTypeEnum(_physiotherapyReport.TreatmentType);
                                    _reportItem.DiagnosisGroup = _physiotherapyReport.DiagnosisGroup;
                                    _reportItem.SessionLimit = _physiotherapyReport.SessionLimit != null ? _physiotherapyReport.SessionLimit.Value : 0;

                                    if (_physiotherapyReport.PackageProcedureInfo != null)
                                    {
                                        _reportItem.PackageProcedureDefinition = PackageProcedureDefinition.GetFTRPackageProceduresByCode(objectContext, _physiotherapyReport.PackageProcedureInfo).FirstOrDefault();
                                    }

                                    viewModel.ReportItemList.Add(_reportItem);
                                }
                            }
                        }
                        else
                        {
                            viewModel.Message = TTUtils.CultureService.GetText("M26314", "Ki�inin Rapor Bilgisi Bulunamam��t�r. L�tfen �nce Rapor Olu�turunuz !");
                        }
                    }
                }

                return viewModel;
            }
        }


        /*Kurum Raporu Sorgulama : Hasta Sgk hastas� de�ilse lokalde yaz�lan kurum raporlar� sorgulan�yor. IsSendedMedula false olan medula raporu olmayanlar yani kurum raporlar� sorgulan�yor.*/
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Rapor_Sorgulama)]
        public PhysiotherapyOrderPlanningFormViewModel GetInstitutionReportInfoByTreatmentType(ReportTypeWithEpisodeId reportTypeWithEpisodeId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                TreatmentQueryReportTypeEnum treatmentType = reportTypeWithEpisodeId.treatmentType;
                Guid? activeEpisodeObjectID = reportTypeWithEpisodeId.activeEpisodeObjectID;
                Episode activeEpisode = new Episode();
                if (activeEpisodeObjectID.HasValue)
                {
                    activeEpisode = objectContext.GetObject<Episode>(activeEpisodeObjectID.Value);
                }

                PhysiotherapyOrderPlanningFormViewModel viewModel = new PhysiotherapyOrderPlanningFormViewModel();
                viewModel.Message = "";
                viewModel.ReportItemList = new List<ReportItem>();

                if (treatmentType != null)
                {
                    if (activeEpisode == null || activeEpisode.Patient == null)
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M26310", "Ki�i bilgilerinde hata mevcuttur. L�tfen sistem y�neticinizle ba�lant� kurunuz!"));
                    }

                    if (activeEpisode.Patient.Privacy != null && activeEpisode.Patient.Privacy == true) //Gizli hasta ise
                    {
                        if (activeEpisode.Patient.PrivacyUniqueRefNo == null)// && activeEpisode.Patient.YUPASSNO == null
                        {
                            viewModel.Message = TTUtils.CultureService.GetText("M26315", "Ki�inin Sistemde Tan�ml� Bir Kimlik Numaras� Yoktur. ��lem Yapmadan �nce Kimlik Bilgilerini G�ncelleyiniz!!!");
                        }
                    }
                    else //Gizli hasta de�ilse
                    {
                        if (activeEpisode.Patient.UniqueRefNo == null && activeEpisode.Patient.YUPASSNO == null)
                        {
                            viewModel.Message = TTUtils.CultureService.GetText("M26315", "Ki�inin Sistemde Tan�ml� Bir Kimlik Numaras� Yoktur. ��lem Yapmadan �nce Kimlik Bilgilerini G�ncelleyiniz!!!");
                        }
                    }

                    if (treatmentType == TreatmentQueryReportTypeEnum.FTR)
                    {
                        BindingList<MedulaTreatmentReport.GetFtrReportInfoByPatient_Class> responseRaporlar = MedulaTreatmentReport.GetFtrReportInfoByPatient(activeEpisode.Patient.ObjectID);

                        if (responseRaporlar != null && responseRaporlar.Count > 0)
                        {
                            string raporTuru = string.Empty;
                            IList fTRVucutBolgesiList = FTRVucutBolgesi.GetFTRVucutBolgesi(objectContext);
                            foreach (var responseRaporlarItem in responseRaporlar)
                            {
                                Boolean saveRaport = false;
                                ReportItem _reportItem = new ReportItem();
                                PhysiotherapyReports _physiotherapyReport = new PhysiotherapyReports(objectContext);
                                _physiotherapyReport.TreatmentType = treatmentType;

                                _physiotherapyReport.ReportType = responseRaporlarItem.Reporttype == true ? true : false;
                                foreach (FTRVucutBolgesi fTRVucutBolgesi in fTRVucutBolgesiList)
                                {
                                    if (fTRVucutBolgesi.ObjectID == responseRaporlarItem.Ftrapplicationareadef)
                                    {
                                        _physiotherapyReport.FTRApplicationAreaDef = fTRVucutBolgesi;
                                    }
                                }
                                _physiotherapyReport.ReportInfo = " K�r :" + responseRaporlarItem.Sessionlimit;
                                _physiotherapyReport.SessionLimit = responseRaporlarItem.Sessionlimit;
                                _physiotherapyReport.PackageProcedureInfo = responseRaporlarItem.Packageprocedureinfo;
                                _physiotherapyReport.TreatmentProcessType = responseRaporlarItem.Treatmentprocesstype;
                                _physiotherapyReport.ReportTime = 365;



                                _physiotherapyReport.ReportNo = responseRaporlarItem.ReportNo != null ? responseRaporlarItem.ReportNo.ToString() : "";
                                _physiotherapyReport.ReportDate = responseRaporlarItem.RaporGonderimTarihi;
                                _physiotherapyReport.ReportStartDate = responseRaporlarItem.StartDate;
                                _physiotherapyReport.ReportEndDate = responseRaporlarItem.EndDate;
                                _physiotherapyReport.DiagnosisGroup = responseRaporlarItem.Diagnosecode;
                                _physiotherapyReport.LocalReportId = responseRaporlarItem.ObjectID;
                                saveRaport = true;


                                if (saveRaport == true)//e�er kaydedilecek rapor varsa
                                {
                                    _reportItem.FTRApplicationAreaDef = _physiotherapyReport.FTRApplicationAreaDef;

                                    _reportItem.ReportObj = _physiotherapyReport;

                                    _reportItem.ReportNo = _physiotherapyReport.ReportNo;
                                    _reportItem.ReportDate = _physiotherapyReport.ReportDate != null ? _physiotherapyReport.ReportDate.Value.ToString("yyyy/MM/dd") : "";
                                    _reportItem.ReportStartDate = _physiotherapyReport.ReportStartDate != null ? _physiotherapyReport.ReportStartDate.Value.ToString("yyyy/MM/dd") : "";
                                    _reportItem.ReportEndDate = _physiotherapyReport.ReportEndDate != null ? _physiotherapyReport.ReportEndDate.Value.ToString("yyyy/MM/dd") : "";
                                    _reportItem.ApplicationAreaName = _physiotherapyReport.FTRApplicationAreaDef == null ? "" : _physiotherapyReport.FTRApplicationAreaDef.ftrVucutBolgesiAdi;
                                    _reportItem.ReportType = _physiotherapyReport.ReportType == true ? TTUtils.CultureService.GetText("M25931", "Heyet Raporu") : TTUtils.CultureService.GetText("M27086", "Tek Hekim Raporu");
                                    _reportItem.ReportInfo = _physiotherapyReport.ReportInfo;
                                    _reportItem.ReportTime = _physiotherapyReport.ReportTime != null ? _physiotherapyReport.ReportTime.ToString() : "";
                                    _reportItem.TreatmentType = Common.GetDisplayTextOfDataTypeEnum(_physiotherapyReport.TreatmentType);
                                    _reportItem.DiagnosisGroup = _physiotherapyReport.DiagnosisGroup;
                                    _reportItem.SessionLimit = _physiotherapyReport.SessionLimit != null ? _physiotherapyReport.SessionLimit.Value : 0;

                                    if (_physiotherapyReport.PackageProcedureInfo != null)
                                    {
                                        _reportItem.PackageProcedureDefinition = PackageProcedureDefinition.GetFTRPackageProceduresByCode(objectContext, _physiotherapyReport.PackageProcedureInfo).FirstOrDefault();
                                    }

                                    viewModel.ReportItemList.Add(_reportItem);
                                }
                            }
                        }
                        else
                        {
                            viewModel.Message = TTUtils.CultureService.GetText("M26314", "Ki�inin Rapor Bilgisi Bulunamam��t�r. L�tfen �nce Rapor Olu�turunuz !");
                        }
                    }
                    else
                    {
                        BindingList<MedulaTreatmentReport.GetEswtReportInfoByPatient_Class> responseRaporlar = MedulaTreatmentReport.GetEswtReportInfoByPatient(activeEpisode.Patient.ObjectID);

                        if (responseRaporlar != null && responseRaporlar.Count > 0)
                        {
                            string raporTuru = string.Empty;
                            IList fTRVucutBolgesiList = FTRVucutBolgesi.GetFTRVucutBolgesi(objectContext);
                            foreach (var responseRaporlarItem in responseRaporlar)
                            {
                                Boolean saveRaport = false;
                                ReportItem _reportItem = new ReportItem();
                                PhysiotherapyReports _physiotherapyReport = new PhysiotherapyReports(objectContext);
                                _physiotherapyReport.TreatmentType = treatmentType;

                                _physiotherapyReport.ReportType = responseRaporlarItem.Reporttype == true ? true : false;
                                foreach (FTRVucutBolgesi fTRVucutBolgesi in fTRVucutBolgesiList)
                                {
                                    if (fTRVucutBolgesi.ObjectID == responseRaporlarItem.Ftrapplicationareadef)
                                    {
                                        _physiotherapyReport.FTRApplicationAreaDef = fTRVucutBolgesi;
                                    }
                                }
                                _physiotherapyReport.ReportInfo = " K�r :" + responseRaporlarItem.Sessionlimit;
                                _physiotherapyReport.SessionLimit = responseRaporlarItem.Sessionlimit;
                                _physiotherapyReport.PackageProcedureInfo = responseRaporlarItem.Packageprocedureinfo;
                                _physiotherapyReport.TreatmentProcessType = "A";
                                _physiotherapyReport.ReportTime = 365;



                                _physiotherapyReport.ReportNo = responseRaporlarItem.ReportNo != null ? responseRaporlarItem.ReportNo.ToString() : "";
                                _physiotherapyReport.ReportDate = responseRaporlarItem.RaporGonderimTarihi;
                                _physiotherapyReport.ReportStartDate = responseRaporlarItem.StartDate;
                                _physiotherapyReport.ReportEndDate = responseRaporlarItem.EndDate;
                                _physiotherapyReport.DiagnosisGroup = responseRaporlarItem.Diagnosecode;
                                _physiotherapyReport.LocalReportId = responseRaporlarItem.ObjectID;

                                saveRaport = true;


                                if (saveRaport == true)//e�er kaydedilecek rapor varsa
                                {
                                    _reportItem.FTRApplicationAreaDef = _physiotherapyReport.FTRApplicationAreaDef;

                                    _reportItem.ReportObj = _physiotherapyReport;

                                    _reportItem.ReportNo = _physiotherapyReport.ReportNo;
                                    _reportItem.ReportDate = _physiotherapyReport.ReportDate != null ? _physiotherapyReport.ReportDate.Value.ToString("yyyy/MM/dd") : "";
                                    _reportItem.ReportStartDate = _physiotherapyReport.ReportStartDate != null ? _physiotherapyReport.ReportStartDate.Value.ToString("yyyy/MM/dd") : "";
                                    _reportItem.ReportEndDate = _physiotherapyReport.ReportEndDate != null ? _physiotherapyReport.ReportEndDate.Value.ToString("yyyy/MM/dd") : "";
                                    _reportItem.ApplicationAreaName = _physiotherapyReport.FTRApplicationAreaDef == null ? "" : _physiotherapyReport.FTRApplicationAreaDef.ftrVucutBolgesiAdi;
                                    _reportItem.ReportType = _physiotherapyReport.ReportType == true ? TTUtils.CultureService.GetText("M25931", "Heyet Raporu") : TTUtils.CultureService.GetText("M27086", "Tek Hekim Raporu");
                                    _reportItem.ReportInfo = _physiotherapyReport.ReportInfo;
                                    _reportItem.ReportTime = _physiotherapyReport.ReportTime != null ? _physiotherapyReport.ReportTime.ToString() : "";
                                    _reportItem.TreatmentType = Common.GetDisplayTextOfDataTypeEnum(_physiotherapyReport.TreatmentType);
                                    _reportItem.DiagnosisGroup = _physiotherapyReport.DiagnosisGroup;
                                    _reportItem.SessionLimit = _physiotherapyReport.SessionLimit != null ? _physiotherapyReport.SessionLimit.Value : 0;

                                    if (_physiotherapyReport.PackageProcedureInfo != null)
                                    {
                                        _reportItem.PackageProcedureDefinition = PackageProcedureDefinition.GetFTRPackageProceduresByCode(objectContext, _physiotherapyReport.PackageProcedureInfo).FirstOrDefault();
                                    }

                                    viewModel.ReportItemList.Add(_reportItem);
                                }
                            }
                        }
                        else
                        {
                            viewModel.Message = TTUtils.CultureService.GetText("M26314", "Ki�inin Rapor Bilgisi Bulunamam��t�r. L�tfen �nce Rapor Olu�turunuz !");
                        }
                    }
                }

                return viewModel;
            }
        }

        public void CalculateOrderDetails(PhysiotherapyOrderPlanningFormViewModel viewModel, PhysiotherapyOrder physiotherapyOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            List<PhysiotherapyOrderDetail> physiotherapyOrderDetailList = new List<PhysiotherapyOrderDetail>();

            DateTime _plannedDate = new DateTime();
            if (viewModel._PhysiotherapyOrder.PhysiotherapyStartDate != null)
            {
                _plannedDate = viewModel._PhysiotherapyOrder.PhysiotherapyStartDate.Value;

                BindingList<WorkDayExceptionDef.GetWorkDayExceptionDefs_Class> holidayList = WorkDayExceptionDef.GetWorkDayExceptionDefs("");//Resmi Tatil G�nleri -- GetActiveWorkDayExceptionDefs

                #region Resmi tatillere g�re �teleme
                foreach (WorkDayExceptionDef.GetWorkDayExceptionDefs_Class item in holidayList)
                {
                    if (item.Date != null && item.Date.Value.Date == _plannedDate.Date)
                    {
                        _plannedDate = _plannedDate.AddDays(1);
                    }
                }
                #endregion Resmi tatillere g�re �teleme

                #region yeni fonk
                if (viewModel.daySelectionActive == false && viewModel._PhysiotherapyOrder.SeansGunSayisi != 0)//G�n se�imi olmadan seans g�n aral��� kullanarak planlama
                {
                    if (viewModel._PhysiotherapyOrder.IncludeSaturday != true && viewModel._PhysiotherapyOrder.IncludeSunday != true)//Haftasonu (Cts-Pazar) Dahil De�il 
                    {
                        for (int _sessionNumber = 1; _sessionNumber <= viewModel._PhysiotherapyOrder.FinishSession.Value; _sessionNumber++)
                        {
                            if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)//planlanan g�n cts ise
                            {
                                _plannedDate = _plannedDate.AddDays(1);
                            }
                            if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)//planlanan g�n pazar ise
                            {
                                _plannedDate = _plannedDate.AddDays(1);
                            }

                            #region Resmi tatillere g�re �teleme
                            foreach (WorkDayExceptionDef.GetWorkDayExceptionDefs_Class item in holidayList)
                            {
                                if (item.Date != null && item.Date.Value.Date == _plannedDate.Date)//Tatil g�n� kadar �teleme
                                {
                                    _plannedDate = _plannedDate.AddDays(1);
                                }
                                bool isTreatmentDiagnosisUnitOpen = false;//�nite mevcut g�nde �al��m�yor ise �al��t��� g�ne kadar �telenir.
                                while (!isTreatmentDiagnosisUnitOpen)
                                {
                                    if (((_plannedDate.DayOfWeek == DayOfWeek.Monday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnMonday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnMonday == false)
                                        || (_plannedDate.DayOfWeek == DayOfWeek.Tuesday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnTuesday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnTuesday == false)
                                        || (_plannedDate.DayOfWeek == DayOfWeek.Wednesday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnWednesday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnWednesday == false)
                                        || (_plannedDate.DayOfWeek == DayOfWeek.Thursday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnThursday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnThursday == false)
                                        || (_plannedDate.DayOfWeek == DayOfWeek.Friday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnFriday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnFriday == false)
                                        || (_plannedDate.DayOfWeek == DayOfWeek.Saturday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday == false)
                                        || (_plannedDate.DayOfWeek == DayOfWeek.Sunday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday == false)))
                                    {
                                        _plannedDate = _plannedDate.AddDays(1);
                                    }
                                    else
                                    {
                                        isTreatmentDiagnosisUnitOpen = true;
                                    }
                                }
                            }
                            #endregion Resmi tatillere g�re �teleme

                            //    ----------    1'den ba�lamayan seanslarda o seans StartSession'a kadar atlan�r. && planlanan g�n tedavi �nitesi �al��m�yor ise o g�n atlan�r    ----------
                            if (viewModel._PhysiotherapyOrder.StartSession.Value <= _sessionNumber)
                            {

                                PhysiotherapyOrderDetail _physiotherapyOrderDetail = new PhysiotherapyOrderDetail(objectContext);

                                _physiotherapyOrderDetail.SessionNumber = _sessionNumber;
                                _physiotherapyOrderDetail.PlannedDate = _plannedDate;


                                _physiotherapyOrderDetail.PhysiotherapyState = PhysiotherapyStateEnum.New;

                                _physiotherapyOrderDetail.PhysiotherapyOrder = physiotherapyOrder;
                                _physiotherapyOrderDetail.PhysiotherapyRequest = physiotherapyOrder.PhysiotherapyRequest;
                                _physiotherapyOrderDetail.ProcedureObject = physiotherapyOrder.ProcedureObject;
                                _physiotherapyOrderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Execution;

                                _physiotherapyOrderDetail.MasterResource = physiotherapyOrder.TreatmentDiagnosisUnit;
                                _physiotherapyOrderDetail.Amount = 1;

                                _physiotherapyOrderDetail.MedulaReportNo = physiotherapyOrder.PhysiotherapyReports != null ? (physiotherapyOrder.PhysiotherapyReports.ReportNo != null ? physiotherapyOrder.PhysiotherapyReports.ReportNo : "") : "";
                                _physiotherapyOrderDetail.TreatmentRoom = physiotherapyOrder.TreatmentRoom;

                                _physiotherapyOrderDetail.PricingDate = _physiotherapyOrderDetail.PlannedDate;

                                _physiotherapyOrderDetail.IsAdditionalProcess = viewModel.IsAdditionalProcess == true ? true : false;
                                _physiotherapyOrderDetail.ProcedureDoctor = physiotherapyOrder.ProcedureDoctor;


                            }

                            _plannedDate = _plannedDate.AddDays(viewModel._PhysiotherapyOrder.SeansGunSayisi.Value);
                        }
                    }
                    else //Hastasonu En Az Bir G�n Dahil
                    {
                        for (int _sessionNumber = 1; _sessionNumber <= viewModel._PhysiotherapyOrder.FinishSession.Value; _sessionNumber++)
                        {

                            if (viewModel._PhysiotherapyOrder.IncludeSaturday != true)//Cumartesi Dahil De�il ise
                            {
                                if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)//planlanan g�n cts ise
                                {
                                    _plannedDate = _plannedDate.AddDays(1);
                                }

                                #region Resmi tatillere g�re �teleme
                                foreach (WorkDayExceptionDef.GetWorkDayExceptionDefs_Class item in holidayList)
                                {
                                    if (item.Date != null && item.Date.Value.Date == _plannedDate.Date)//Tatil g�n� kadar �teleme
                                    {
                                        _plannedDate = _plannedDate.AddDays(1);
                                    }
                                }
                                #endregion Resmi tatillere g�re �teleme

                                if (_plannedDate.DayOfWeek == DayOfWeek.Saturday)//planlanan g�n cts ise
                                {
                                    _plannedDate = _plannedDate.AddDays(1);
                                }
                            }
                            else if (viewModel._PhysiotherapyOrder.IncludeSunday != true)//Pazar Dahil De�il ise
                            {
                                if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)//planlanan g�n pazar ise
                                {
                                    _plannedDate = _plannedDate.AddDays(1);
                                }

                                #region Resmi tatillere g�re �teleme
                                foreach (WorkDayExceptionDef.GetWorkDayExceptionDefs_Class item in holidayList)
                                {
                                    if (item.Date != null && item.Date.Value.Date == _plannedDate.Date)//Tatil g�n� kadar �teleme
                                    {
                                        _plannedDate = _plannedDate.AddDays(1);
                                    }
                                    bool isTreatmentDiagnosisUnitOpen = false;//�nite mevcut g�nde �al��m�yor ise �al��t��� g�ne kadar �telenir.
                                    while (!isTreatmentDiagnosisUnitOpen)
                                    {
                                        if (((_plannedDate.DayOfWeek == DayOfWeek.Monday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnMonday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnMonday == false)
                                            || (_plannedDate.DayOfWeek == DayOfWeek.Tuesday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnTuesday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnTuesday == false)
                                            || (_plannedDate.DayOfWeek == DayOfWeek.Wednesday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnWednesday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnWednesday == false)
                                            || (_plannedDate.DayOfWeek == DayOfWeek.Thursday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnThursday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnThursday == false)
                                            || (_plannedDate.DayOfWeek == DayOfWeek.Friday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnFriday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnFriday == false)
                                            || (_plannedDate.DayOfWeek == DayOfWeek.Saturday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday == false)
                                            || (_plannedDate.DayOfWeek == DayOfWeek.Sunday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday == false)))
                                        {
                                            _plannedDate = _plannedDate.AddDays(1);
                                        }
                                        else
                                        {
                                            isTreatmentDiagnosisUnitOpen = true;
                                        }
                                    }
                                }
                                #endregion Resmi tatillere g�re �teleme

                                if (_plannedDate.DayOfWeek == DayOfWeek.Sunday)//planlanan g�n pazar ise
                                {
                                    _plannedDate = _plannedDate.AddDays(1);
                                }
                            }
                            else//Haftasonu Dahil
                            {
                                #region Resmi tatillere g�re �teleme
                                foreach (WorkDayExceptionDef.GetWorkDayExceptionDefs_Class item in holidayList)
                                {
                                    if (item.Date != null && item.Date.Value.Date == _plannedDate.Date)//Tatil g�n� kadar �teleme
                                    {
                                        _plannedDate = _plannedDate.AddDays(1);
                                    }
                                    bool isTreatmentDiagnosisUnitOpen = false;//�nite mevcut g�nde �al��m�yor ise �al��t��� g�ne kadar �telenir.
                                    while (!isTreatmentDiagnosisUnitOpen)
                                    {
                                        if (((_plannedDate.DayOfWeek == DayOfWeek.Monday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnMonday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnMonday == false)
                                            || (_plannedDate.DayOfWeek == DayOfWeek.Tuesday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnTuesday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnTuesday == false)
                                            || (_plannedDate.DayOfWeek == DayOfWeek.Wednesday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnWednesday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnWednesday == false)
                                            || (_plannedDate.DayOfWeek == DayOfWeek.Thursday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnThursday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnThursday == false)
                                            || (_plannedDate.DayOfWeek == DayOfWeek.Friday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnFriday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnFriday == false)
                                            || (_plannedDate.DayOfWeek == DayOfWeek.Saturday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday == false)
                                            || (_plannedDate.DayOfWeek == DayOfWeek.Sunday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday == false)))
                                        {
                                            _plannedDate = _plannedDate.AddDays(1);
                                        }
                                        else
                                        {
                                            isTreatmentDiagnosisUnitOpen = true;
                                        }
                                    }
                                }
                                #endregion Resmi tatillere g�re �teleme

                            }

                            //    ----------    1'den ba�lamayan seanslarda o seans StartSession'a kadar atlan�r. && planlanan g�n tedavi �nitesi �al��m�yor ise o g�n atlan�r    ----------
                            if (viewModel._PhysiotherapyOrder.StartSession.Value <= _sessionNumber)
                            {

                                PhysiotherapyOrderDetail _physiotherapyOrderDetail = new PhysiotherapyOrderDetail(objectContext);

                                _physiotherapyOrderDetail.SessionNumber = _sessionNumber;
                                _physiotherapyOrderDetail.PlannedDate = _plannedDate;


                                _physiotherapyOrderDetail.PhysiotherapyState = PhysiotherapyStateEnum.New;

                                _physiotherapyOrderDetail.PhysiotherapyOrder = physiotherapyOrder;
                                _physiotherapyOrderDetail.PhysiotherapyRequest = physiotherapyOrder.PhysiotherapyRequest;
                                _physiotherapyOrderDetail.ProcedureObject = physiotherapyOrder.ProcedureObject;
                                _physiotherapyOrderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Execution;

                                _physiotherapyOrderDetail.MasterResource = physiotherapyOrder.TreatmentDiagnosisUnit;
                                _physiotherapyOrderDetail.Amount = 1;

                                _physiotherapyOrderDetail.MedulaReportNo = physiotherapyOrder.PhysiotherapyReports != null ? (physiotherapyOrder.PhysiotherapyReports.ReportNo != null ? physiotherapyOrder.PhysiotherapyReports.ReportNo : "") : "";
                                _physiotherapyOrderDetail.TreatmentRoom = physiotherapyOrder.TreatmentRoom;

                                _physiotherapyOrderDetail.PricingDate = _physiotherapyOrderDetail.PlannedDate;

                                _physiotherapyOrderDetail.IsAdditionalProcess = viewModel.IsAdditionalProcess == true ? true : false;
                                _physiotherapyOrderDetail.ProcedureDoctor = physiotherapyOrder.ProcedureDoctor;

                            }
                            else if (viewModel._PhysiotherapyOrder.StartSession.Value <= _sessionNumber // �nitenin se�ilen haftasonu �al��mamas� sebebiyle i�lem atlan�yorsa hata verilir.
                                && ((_plannedDate.DayOfWeek == DayOfWeek.Saturday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday == false)
                               || (_plannedDate.DayOfWeek == DayOfWeek.Sunday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday == false)))
                            {
                                throw new Exception("Tedavi �nitesinin �al��mad��� g�n se�ili oldu�u i�in i�leme devam edilemedi!");
                            }

                            _plannedDate = _plannedDate.AddDays(viewModel._PhysiotherapyOrder.SeansGunSayisi.Value);
                        }
                    }
                }
                else//G�n se�imi kullanarak planlama
                {
                    for (int _sessionNumber = 1; _sessionNumber <= viewModel._PhysiotherapyOrder.FinishSession.Value; _sessionNumber++)
                    {
                        int seansNo = _sessionNumber;
                        DateTime planlananTarih = _plannedDate;

                        bool isDateConflict = false;//g�n e�le�mesi sa�lanana kadar bir sonraki g�ne ge�iliyor.
                        while (!isDateConflict)
                        {
                            #region Resmi tatillere g�re �teleme
                            foreach (WorkDayExceptionDef.GetWorkDayExceptionDefs_Class item in holidayList)
                            {
                                if (item.Date != null && item.Date.Value.Date == _plannedDate.Date)//Tatil g�n� kadar �teleme
                                {
                                    _plannedDate = _plannedDate.AddDays(1);
                                }
                                bool isTreatmentDiagnosisUnitOpen = false;//�nite mevcut g�nde �al��m�yor ise �al��t��� g�ne kadar �telenir.
                                while (!isTreatmentDiagnosisUnitOpen)
                                {
                                    if (((_plannedDate.DayOfWeek == DayOfWeek.Monday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnMonday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnMonday == false)
                                        || (_plannedDate.DayOfWeek == DayOfWeek.Tuesday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnTuesday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnTuesday == false)
                                        || (_plannedDate.DayOfWeek == DayOfWeek.Wednesday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnWednesday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnWednesday == false)
                                        || (_plannedDate.DayOfWeek == DayOfWeek.Thursday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnThursday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnThursday == false)
                                        || (_plannedDate.DayOfWeek == DayOfWeek.Friday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnFriday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnFriday == false)
                                        || (_plannedDate.DayOfWeek == DayOfWeek.Saturday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSaturday == false)
                                        || (_plannedDate.DayOfWeek == DayOfWeek.Sunday && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday != null && physiotherapyOrder.TreatmentDiagnosisUnit.OpenOnSunday == false)))
                                    {
                                        _plannedDate = _plannedDate.AddDays(1);
                                    }
                                    else
                                    {
                                        isTreatmentDiagnosisUnitOpen = true;
                                    }
                                }
                            }
                            #endregion Resmi tatillere g�re �teleme

                            if ((viewModel._PhysiotherapyOrder.IncludeMonday == true && _plannedDate.DayOfWeek == DayOfWeek.Monday) //Pazartesi
                                || (viewModel._PhysiotherapyOrder.IncludeTuesday == true && _plannedDate.DayOfWeek == DayOfWeek.Tuesday)//Sal�
                                || (viewModel._PhysiotherapyOrder.IncludeWednesday == true && _plannedDate.DayOfWeek == DayOfWeek.Wednesday)//�ar�amba
                                || (viewModel._PhysiotherapyOrder.IncludeThursday == true && _plannedDate.DayOfWeek == DayOfWeek.Thursday)//Per�embe
                                || (viewModel._PhysiotherapyOrder.IncludeFriday == true && _plannedDate.DayOfWeek == DayOfWeek.Friday)//Cuma
                                || (viewModel._PhysiotherapyOrder.IncludeSaturday == true && _plannedDate.DayOfWeek == DayOfWeek.Saturday)//Cumartesi
                                || (viewModel._PhysiotherapyOrder.IncludeSunday == true && _plannedDate.DayOfWeek == DayOfWeek.Sunday)//Pazar
                                )
                            {
                                seansNo = _sessionNumber;
                                planlananTarih = _plannedDate;
                                isDateConflict = true;
                            }
                            _plannedDate = _plannedDate.AddDays(1);
                        }

                        //    ----------    1'den ba�lamayan seanslarda o seans StartSession'a kadar atlan�r. && planlanan g�n tedavi �nitesi �al��m�yor ise o g�n atlan�r    ----------
                        if (viewModel._PhysiotherapyOrder.StartSession.Value <= _sessionNumber)
                        {
                            PhysiotherapyOrderDetail _physiotherapyOrderDetail = new PhysiotherapyOrderDetail(objectContext);

                            _physiotherapyOrderDetail.SessionNumber = seansNo;
                            _physiotherapyOrderDetail.PlannedDate = planlananTarih;

                            _physiotherapyOrderDetail.PhysiotherapyState = PhysiotherapyStateEnum.New;

                            _physiotherapyOrderDetail.PhysiotherapyOrder = physiotherapyOrder;
                            _physiotherapyOrderDetail.PhysiotherapyRequest = physiotherapyOrder.PhysiotherapyRequest;
                            _physiotherapyOrderDetail.ProcedureObject = physiotherapyOrder.ProcedureObject;
                            _physiotherapyOrderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Execution;

                            _physiotherapyOrderDetail.MasterResource = physiotherapyOrder.TreatmentDiagnosisUnit;
                            _physiotherapyOrderDetail.Amount = 1;

                            _physiotherapyOrderDetail.MedulaReportNo = physiotherapyOrder.PhysiotherapyReports != null ? (physiotherapyOrder.PhysiotherapyReports.ReportNo != null ? physiotherapyOrder.PhysiotherapyReports.ReportNo : "") : "";
                            _physiotherapyOrderDetail.TreatmentRoom = physiotherapyOrder.TreatmentRoom;

                            _physiotherapyOrderDetail.PricingDate = _physiotherapyOrderDetail.PlannedDate;

                            _physiotherapyOrderDetail.IsAdditionalProcess = viewModel.IsAdditionalProcess == true ? true : false;
                            _physiotherapyOrderDetail.ProcedureDoctor = physiotherapyOrder.ProcedureDoctor;

                        }
                        else if (viewModel._PhysiotherapyOrder.StartSession.Value <= _sessionNumber) // �nitenin se�ilen g�n �al��mamas� sebebiyle i�lem atlan�yorsa hata verilir.
                        {
                            throw new Exception("Tedavi �nitesinin �al��mad��� g�n se�ili oldu�u i�in i�leme devam edilemedi!");
                        }

                    }
                }
                #endregion

                #region Seans Numaralar� tekrar d�zenleniyor.
                var request = physiotherapyOrder.PhysiotherapyRequest;
                //Ek tedavi olmayan OrderDetail
                var groupedOrderDetailList = request.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyOrder != null && c.PhysiotherapyOrder.IsAdditionalTreatment != true);
                int count = 1;
                foreach (var item in groupedOrderDetailList.OrderBy(c => c.PlannedDate).GroupBy(c => c.PlannedDate.Value.Date))
                {
                    var selectedOrderDetailList = groupedOrderDetailList.Where(x => x.PlannedDate.Value.Date == item.Key.Date);
                    foreach (var selectedOrderDetail in selectedOrderDetailList)
                    {
                        selectedOrderDetail.SessionNumber = count;
                    }

                    count++;
                }

                //Ek tedavi olan OrderDetail
                var groupedAdditionalOrderDetailList = request.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled && c.PhysiotherapyOrder != null && c.PhysiotherapyOrder.IsAdditionalTreatment == true);
                int countAdditional = 1;
                foreach (var item in groupedAdditionalOrderDetailList.OrderBy(c => c.PlannedDate).GroupBy(c => c.PlannedDate.Value.Date))
                {
                    var selectedOrderDetailList = groupedAdditionalOrderDetailList.Where(x => x.PlannedDate.Value.Date == item.Key.Date);
                    foreach (var selectedOrderDetail in selectedOrderDetailList)
                    {
                        selectedOrderDetail.SessionNumber = countAdditional;
                    }

                    countAdditional++;
                }
                #endregion

                // SubEpisode olu�turma, takip alma ve �cretlendirme i�lemleri buraya ta��nd�
                if (physiotherapyOrder.IsOldAction != true)
                {
                    // AltVaka Olu�turulur
                    physiotherapyOrder.PhysiotherapyRequest.SubEpisode.ArrangeMeOrCreateNewSubEpisode(physiotherapyOrder.PhysiotherapyRequest, false, true);

                    foreach (PhysiotherapyOrderDetail poDetail in physiotherapyOrder.PhysiotherapyOrderDetails.Where(x => x.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution))
                    {
                        if (poDetail.PlannedDate.Value.Date == physiotherapyOrder.PhysiotherapyRequest.SubEpisode.OpeningDate.Value.Date)
                            poDetail.PlannedDate.Value.AddMinutes(2);

                        // �cretlendirmeler yap�l�r
                        poDetail.AccountingOperation();
                    }
                }
            }
        }

        public static PhysiotherapyOrderPlanningFormViewModel GetPhysiotherapyOrderPlanningFormViewModel(PhysiotherapyOrder order)
        {
            PhysiotherapyOrderServiceController physiotherapyOrderServiceController = new PhysiotherapyOrderServiceController();
            PhysiotherapyOrderPlanningFormViewModel physiotherapyOrderPlanningFormViewModel = new PhysiotherapyOrderPlanningFormViewModel();
            physiotherapyOrderPlanningFormViewModel = physiotherapyOrderServiceController.PhysiotherapyOrderPlanningForm(order.ObjectID);
            return physiotherapyOrderPlanningFormViewModel;
        }


        public PhysiotherapyOrderPlanningFormViewModel GetPhysiotherapyOrderPlanningFormViewModelById(OrderInfo orderInfo)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PhysiotherapyOrderServiceController physiotherapyOrderServiceController = new PhysiotherapyOrderServiceController();
                PhysiotherapyOrderPlanningFormViewModel physiotherapyOrderPlanningFormViewModel = new PhysiotherapyOrderPlanningFormViewModel();
                physiotherapyOrderPlanningFormViewModel = physiotherapyOrderServiceController.PhysiotherapyOrderPlanningForm(orderInfo.OrderObjectId);
                physiotherapyOrderPlanningFormViewModel.openFromGrid = true;
                PhysiotherapyOrder order = objectContext.GetObject(orderInfo.OrderObjectId, orderInfo.OrderObjectDefId) as PhysiotherapyOrder;
                if (order.PhysiotherapyRequest != null && order.PhysiotherapyRequest.PhysiotherapyRequestDate != null)
                {
                    physiotherapyOrderPlanningFormViewModel._physiotherapyRequestDate = order.PhysiotherapyRequest.PhysiotherapyRequestDate.Value;
                }

                return physiotherapyOrderPlanningFormViewModel;
            }
        }

        public static void SavePhysiotherapyOrderPlanningFormViewModelObject(TTObjectContext objectContext, PhysiotherapyOrderPlanningFormViewModel viewModel)
        {
            PhysiotherapyOrderServiceController physiotherapyOrderServiceController = new PhysiotherapyOrderServiceController();
            physiotherapyOrderServiceController.SavePhysiotherapyOrderPlanningFormViewModel(objectContext, viewModel);
        }

        public void SavePhysiotherapyOrderPlanningFormViewModel(TTObjectContext objectContext, PhysiotherapyOrderPlanningFormViewModel viewModel)
        {
            var formDefID = Guid.Parse("87df6e56-4417-4e38-a6fd-66ee06820ccc");
            objectContext.AddToRawObjectList(viewModel.PhysiotherapyReportss);
            objectContext.AddToRawObjectList(viewModel.FTRVucutBolgesis);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.PhysiotherapyDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResTreatmentDiagnosisUnits);
            objectContext.AddToRawObjectList(viewModel.PhysiotherapyOrderDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._PhysiotherapyOrder);

            objectContext.ProcessRawObjects(false);

            var physiotherapyOrder = (PhysiotherapyOrder)objectContext.GetLoadedObject(viewModel._PhysiotherapyOrder.ObjectID);

            if (viewModel.ProcedureObjectList != null && viewModel.ProcedureObjectList.Count() > 0)
            {
                physiotherapyOrder.ProcedureObject = viewModel.ProcedureObjectList.FirstOrDefault();
            }

            TTDefinitionManagement.TTFormDef.CheckFormSecurity(physiotherapyOrder, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyOrder, formDefID);

            if (viewModel.PhysiotherapyOrderDetailsGridList != null)
            {
                foreach (var item in viewModel.PhysiotherapyOrderDetailsGridList)
                {
                    var physiotherapyOrderDetailsImported = (PhysiotherapyOrderDetail)objectContext.GetLoadedObject(item.ObjectID);
                    physiotherapyOrderDetailsImported.PhysiotherapyOrder = physiotherapyOrder;
                }
            }
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(physiotherapyOrder);
            PostScript_PhysiotherapyOrderPlanningForm(viewModel, physiotherapyOrder, transDef, objectContext);


        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Ek_Islem)]
        public PhysiotherapyOrderPlanningFormViewModel GetNewPhysiotherapyOrderPlanningFormViewModel(PhysiotherapyRequest physiotherapyRequest, TTObjectContext objectContext = null)
        {
            var formDefID = Guid.Parse("87df6e56-4417-4e38-a6fd-66ee06820ccc");
            var objectDefID = Guid.Parse("ee1a78c9-9c9d-4fb5-9a00-e719b53ca848");
            var viewModel = new PhysiotherapyOrderPlanningFormViewModel();
            var contextControl = false;
            // using (var objectContext = new TTObjectContext(false))
            //{

            if (objectContext == null)
            {
                objectContext = new TTObjectContext(false);
                contextControl = true;
            }
            viewModel._PhysiotherapyOrder = new PhysiotherapyOrder(objectContext);
            var entryStateID = Guid.Parse("16b54535-aacc-414b-ab69-b06759532cd7");
            viewModel._PhysiotherapyOrder.CurrentStateDefID = entryStateID;
            viewModel.PhysiotherapyOrderDetailsGridList = new TTObjectClasses.PhysiotherapyOrderDetail[] { };
            viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysiotherapyOrder, formDefID);
            viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysiotherapyOrder, formDefID);
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PhysiotherapyOrder);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PhysiotherapyOrder);

            PhysiotherapyRequest _physiotherapyRequest = objectContext.GetObject<PhysiotherapyRequest>(physiotherapyRequest.ObjectID);
            viewModel._PhysiotherapyOrder.SetMandatoryEpisodeActionProperties(_physiotherapyRequest, _physiotherapyRequest.MasterResource, true);
            viewModel._PhysiotherapyOrder.PhysiotherapyRequest = physiotherapyRequest;
            viewModel._physiotherapyRequestDate = physiotherapyRequest.PhysiotherapyRequestDate.Value;

            PreScript_PhysiotherapyOrderPlanningForm(viewModel, viewModel._PhysiotherapyOrder, objectContext);
            objectContext.FullPartialllyLoadedObjects();
            if (contextControl)
                objectContext.Dispose();
            //}
            return viewModel;
        }

        public void Max5DaysControl(PhysiotherapyRequest physiotherapyRequest)
        {
            //iki seans aras� max 5 g�n olabilir kontrol� ve yatan ayaktan i�in planm-lama yap�lacak v�cut b�lgesi-grup konrol� 
            var reportList = physiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID != PhysiotherapyOrder.States.Cancelled && c.PackageProcedure != null).GroupBy(x => x.PackageProcedure);
            if (physiotherapyRequest.SubEpisode.StarterEpisodeAction.SubEpisode.PatientStatus.Value == SubEpisodeStatusEnum.Outpatient && reportList.Count() > 1)
            {
                throw new Exception("Ayaktan hasta i�in birden fazla paket hizmeti i�in planlama yap�lamaz !");
            }
            else if (physiotherapyRequest.SubEpisode.StarterEpisodeAction.SubEpisode.PatientStatus.Value != SubEpisodeStatusEnum.Outpatient && reportList.Count() > 2)
            {
                throw new Exception("Yatan hasta i�in ikiden fazla paket hizmeti i�in planlama yap�lamaz !");
            }

            List<PhysiotherapyOrderDetail> orderDetailList = physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled).OrderBy(c => c.PlannedDate).ToList();

            BindingList<WorkDayExceptionDef.GetWorkDayExceptionDefs_Class> holidayList = WorkDayExceptionDef.GetWorkDayExceptionDefs("");//Resmi Tatil G�nleri -- GetActiveWorkDayExceptionDefs

            for (int i = 1; i < orderDetailList.Count(); i++)
            {
                var dayDifference = ((orderDetailList[i].PlannedDate.Value.Date) - (orderDetailList[i - 1].PlannedDate.Value.Date)).TotalDays;//iki tarih aras�ndaki g�n say�s�
                int weekendCount = CountWeekEnds(orderDetailList[i - 1].PlannedDate.Value.Date, orderDetailList[i].PlannedDate.Value.Date);//iki tarih aras�ndaki haftasonu say�s�
                dayDifference = dayDifference - weekendCount;//iki tarih aras�ndaki haftasonu hari� i�g�n� say�s�
                if (dayDifference > 5)
                {
                    //G�n fark�n� hesaplarken tatil g�nleri hari� say�lmas� gerekiyor. iki tarih aras�ndaki haftasonuna denk gelmeyen tatil g�nlerinin say�s�
                    var holidayCount = holidayList.Where(
                        c => c.Date.Value.Date < orderDetailList[i].PlannedDate.Value.Date &&
                        c.Date.Value.Date > orderDetailList[i - 1].PlannedDate.Value.Date &&
                        (c.Date.Value.DayOfWeek != DayOfWeek.Saturday || c.Date.Value.DayOfWeek != DayOfWeek.Sunday)).Count();

                    dayDifference = dayDifference - holidayCount; //G�n fark�n� hesaplarken tatil g�nleri hari� say�lmas� gerekiyor. iki tarih aras�nda tatil g�nlerine denk gelmeyen i�g�n� say�s�

                    if (dayDifference > 5)//iki tarih aras�nda tatil g�nlerine denk gelmeyen i�g�n� say�s� 5'i ge�emez!
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M26035", "�ki seans aras�ndaki fark 5 i� g�n�nden fazla olamaz!"));
                    }
                    //else
                    //{
                    //    var previousPlannedDate = orderDetailList[i].PlannedDate;
                    //    while (previousPlannedDate != orderDetailList[i].PlannedDate)
                    //    {
                    //        if (previousPlannedDate.Value.DayOfWeek == DayOfWeek.Saturday)//Planlanan g�n cts ise
                    //        {
                    //            weekendCount++;
                    //        }
                    //        else if (previousPlannedDate.Value.DayOfWeek == DayOfWeek.Saturday)//Planlanan g�n pazar ise
                    //        {
                    //            weekendCount++;
                    //        }
                    //    }

                    //    if ((dayDifference + weekendCount) > 7)
                    //    {
                    //        throw new Exception(TTUtils.CultureService.GetText("M26035", "�ki seans aras�ndaki fark 5 i� g�n�nden fazla olamaz!"));
                    //    }
                    //}
                }
            }
        }

        public static int CountWeekEnds(DateTime startDate, DateTime endDate)//�ki tarih aras�ndaki haftasonu g�nlerinin say�s�
        {
            int weekEndCount = 0;
            if (startDate > endDate)
            {
                DateTime temp = startDate;
                startDate = endDate;
                endDate = temp;
            }
            TimeSpan diff = endDate - startDate;
            int days = diff.Days;
            for (var i = 0; i <= days; i++)
            {
                var testDate = startDate.AddDays(i);
                if (testDate.DayOfWeek == DayOfWeek.Saturday || testDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    weekEndCount += 1;
                }
            }
            return weekEndCount;
        }

        [HttpPost]
        public PhysiotherapyOrderPlanningFormViewModel PhysiotherapyOrderFormTemplate(Guid TAObjectID, Guid ActiveEpisodeActionID)
        {
            PhysiotherapyOrderServiceController physiotherapyOrderServiceController = new PhysiotherapyOrderServiceController();
            PhysiotherapyOrderPlanningFormViewModel viewModel = new PhysiotherapyOrderPlanningFormViewModel();


            using (var objectContext = new TTObjectContext(false))
            {
                PhysiotherapyRequest request = objectContext.GetObject<PhysiotherapyRequest>(ActiveEpisodeActionID);
                viewModel = physiotherapyOrderServiceController.GetNewPhysiotherapyOrderPlanningFormViewModel(request, objectContext);
                if (TAObjectID != null)
                {
                    PhysiotherapyOrder templatePhysiotherapyOrder = objectContext.GetObject<PhysiotherapyOrder>(TAObjectID);
                    //  PhysiotherapyOrder order = viewModel._PhysiotherapyOrder;
                    //  PhysiotherapyRequest request = objectContext.GetObject<PhysiotherapyRequest>(ActiveEpisodeActionID);
                    viewModel._PhysiotherapyOrder.PhysiotherapyRequest = request;
                    viewModel._PhysiotherapyOrder.Episode = request.Episode;
                    viewModel.ProcedureObjectSource = PhysiotherapyDefinition.GetAllPhysiotherapyDefinitions(new TTObjectContext(true)).ToArray();
                    viewModel._PhysiotherapyOrder.TreatmentDiagnosisUnit = templatePhysiotherapyOrder.TreatmentDiagnosisUnit;
                    viewModel._PhysiotherapyOrder.FTRApplicationAreaDef = templatePhysiotherapyOrder.FTRApplicationAreaDef;
                    viewModel._PhysiotherapyOrder.ApplicationArea = templatePhysiotherapyOrder.ApplicationArea;
                    viewModel._PhysiotherapyOrder.Duration = templatePhysiotherapyOrder.Duration;
                    viewModel._PhysiotherapyOrder.Dose = templatePhysiotherapyOrder.Dose;
                    viewModel._PhysiotherapyOrder.DoseDurationInfo = templatePhysiotherapyOrder.DoseDurationInfo;
                    viewModel._PhysiotherapyOrder.ProcedureDoctor = templatePhysiotherapyOrder.ProcedureDoctor;
                    viewModel._PhysiotherapyOrder.PackageProcedure = templatePhysiotherapyOrder.PackageProcedure;
                    viewModel._PhysiotherapyOrder.SeansGunSayisi = templatePhysiotherapyOrder.SeansGunSayisi;
                    viewModel._PhysiotherapyOrder.FinishSession = templatePhysiotherapyOrder.FinishSession;
                    viewModel._PhysiotherapyOrder.ProcedureObject = templatePhysiotherapyOrder.ProcedureObject;
                    List<ProcedureDefinition> tempList = new List<ProcedureDefinition>();
                    tempList.Add(templatePhysiotherapyOrder.ProcedureObject);
                    viewModel.ProcedureObjectList = tempList.ToArray();
                    viewModel._PhysiotherapyOrder.IncludeMonday = templatePhysiotherapyOrder.IncludeMonday;
                    viewModel._PhysiotherapyOrder.IncludeTuesday = templatePhysiotherapyOrder.IncludeTuesday;
                    viewModel._PhysiotherapyOrder.IncludeWednesday = templatePhysiotherapyOrder.IncludeWednesday;
                    viewModel._PhysiotherapyOrder.IncludeThursday = templatePhysiotherapyOrder.IncludeThursday;
                    viewModel._PhysiotherapyOrder.IncludeFriday = templatePhysiotherapyOrder.IncludeFriday;
                    viewModel._PhysiotherapyOrder.IncludeSaturday = templatePhysiotherapyOrder.IncludeSaturday;
                    viewModel._PhysiotherapyOrder.IncludeSunday = templatePhysiotherapyOrder.IncludeSunday;
                    viewModel._PhysiotherapyOrder.StartSession = 1; //default set edilmis

                    if (viewModel._PhysiotherapyOrder.StartSession != null && viewModel._PhysiotherapyOrder.FinishSession != null)
                    {
                        viewModel._PhysiotherapyOrder.SessionCount = viewModel._PhysiotherapyOrder.FinishSession - viewModel._PhysiotherapyOrder.StartSession + 1;
                    }
                    viewModel.PhysiotherapyRequest = templatePhysiotherapyOrder.PhysiotherapyRequest;


                    ContextToViewModel(viewModel, objectContext);
                    objectContext.FullPartialllyLoadedObjects();

                }
            }

            return viewModel;
        }


        [HttpPost]
        public List<UserTemplateModel> SavePhysiotherapyOrderPlanningUserTemplate(UserTemplateModel userTemplate)
        {
            List<UserTemplateModel> userTemplatesList = new List<UserTemplateModel>();

            using (var objectContext = new TTObjectContext(false))
            {
                if (userTemplate.ObjectID != null)
                {
                    UserTemplate oldUserTemplate = objectContext.GetObject<UserTemplate>((Guid)userTemplate.ObjectID);
                    oldUserTemplate.FiliterData = "DELETED-PhysiotherapyOrderTemplate";
                }
                else
                {
                    UserTemplate newUserTemplate = new UserTemplate(objectContext);
                    newUserTemplate.TAObjectDefID = userTemplate.TAObjectDefID;
                    newUserTemplate.TAObjectID = userTemplate.TAObjectID;
                    newUserTemplate.FiliterData = "PhysiotherapyOrderTemplate";
                    newUserTemplate.ResUser = Common.CurrentResource;
                    newUserTemplate.Description = userTemplate.Description;
                }

                objectContext.Save();
                var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, (Guid)userTemplate.TAObjectDefID, "PhysiotherapyOrderTemplate").ToList();
                foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList)
                {
                    UserTemplateModel templateModel = new UserTemplateModel();
                    templateModel.ObjectID = item.ObjectID;
                    templateModel.TAObjectID = item.TAObjectID;
                    templateModel.TAObjectDefID = item.TAObjectDefID;
                    templateModel.Description = item.Description;
                    userTemplatesList.Add(templateModel);
                }
            }
            return userTemplatesList;
        }



        public PhysiotherapyOrderPlanningFormViewModel GetPhysiotherapyOrderDetailAppointmentObject(Guid ObjectID, Guid ObjectDefID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PhysiotherapyOrder PhysiotherapyOrder = objectContext.GetObject(ObjectID, ObjectDefID) as PhysiotherapyOrder;

                PhysiotherapyOrderPlanningFormViewModel viewModel = new PhysiotherapyOrderPlanningFormViewModel();

                var appointmentObj = Appointment.GetByEpisodeActionAndState(objectContext, PhysiotherapyOrder.ObjectID.ToString(), Appointment.States.New.ToString());
                if (appointmentObj.Count > 0)
                {
                    viewModel._Appointment = appointmentObj.FirstOrDefault();
                }
                else
                {
                    viewModel._Appointment = new Appointment(objectContext);
                }

                viewModel._Appointment.EpisodeAction = PhysiotherapyOrder;
                viewModel._Appointment.AppDate = PhysiotherapyOrder.PhysiotherapyStartDate != null ? PhysiotherapyOrder.PhysiotherapyStartDate : Common.RecTime();
                viewModel._Appointment.Resource = PhysiotherapyOrder.TreatmentRoom;
                viewModel._Appointment.MasterResource = PhysiotherapyOrder.TreatmentDiagnosisUnit;

                return viewModel;
            }
        }
    }
}

namespace Core.Models
{
    public partial class PhysiotherapyOrderPlanningFormViewModel
    {
        public bool IsAppointmentActive { get; set; }
        public bool IsPaymentObject { get; set; }//zorunlu �cretli i�lem mi 
        public bool IsReadOnlyFields { get; set; }

        public DateTime startDate { get; set; }//fizyoterapi ba�lang�� tarihi
        public DateTime endDate { get; set; }//Fizyoterapi biti� tarihi

        public bool IsAdditionalProcess { get; set; }//Ek ��lem mi?
        public bool IsPhysiotherapyRequestFormUsing { get; set; }
        public bool daySelectionActive { get; set; }

        public string Message { get; set; }

        public List<ReportItem> ReportItemList { get; set; }

        // public ProcedureDefinition[] ProcedureObjectDataSource { get; set; }
        public ProcedureDefinition[] ProcedureObjectList { get; set; }

        public bool IsReportExistsAndCalculateDetail { get; set; }//Rapor var ise detay hesapla, rapor yok ise �cretli olarak i�aretlenmeden hesaplama yapma
        public List<PhysiotherapyReports> ReportList { get; set; }//Rapor var ise rapor se�imini otomatik olarak a�

        public bool IsSGKPatient { get; set; }//�cretli hasta,kurum hastas� ise:false -- Sgk hastas� ise true

        public bool IsMedulaNotWorking { get; set; }//Medulas�z Rapor Sorgulamak i�in! true ise medula �al��m�yor
        public DateTime _physiotherapyRequestDate { get; set; }
        public bool openFromGrid { get; set; }
        public List<UserTemplateModel> userTemplateList { get; set; }
        public UserTemplateModel selectedUserTemplate { get; set; }
        public ProcedureDefinition[] ProcedureObjectSource { get; set; }
        public PhysiotherapyRequest PhysiotherapyRequest { get; set; }



        public Appointment _Appointment { get; set; }
    }

    //public class ReportItem
    //{
    //    public PhysiotherapyReports ReportObj { get; set; }
    //    public FTRVucutBolgesi FTRApplicationAreaDef { get; set; }

    //    public int SessionLimit { get; set; }

    //    public string ReportNo { get; set; }
    //    public string ReportDate { get; set; }
    //    public string ReportStartDate { get; set; }
    //    public string ReportEndDate { get; set; }
    //    public string ApplicationAreaName { get; set; }
    //    public string ReportType { get; set; }
    //    public string ReportInfo { get; set; }
    //    public string ReportTime { get; set; }
    //    public string TreatmentType { get; set; }
    //    public string DiagnosisGroup { get; set; }

    //    public PackageProcedureDefinition PackageProcedureDefinition { get; set; }

    //}
}
