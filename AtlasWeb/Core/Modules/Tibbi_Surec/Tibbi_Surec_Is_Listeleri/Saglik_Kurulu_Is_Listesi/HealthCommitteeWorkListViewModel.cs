using System;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using Infrastructure.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.ComponentModel;
using System.Linq;
using TTDefinitionManagement;
using System.Collections;
using static TTObjectClasses.TreatmentDischarge;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class HealthCommitteeWorkListServiceController : BaseEpisodeActionWorkListServiceController
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Saglik_Kurulu_Veri_Hazirlama_Memuru,TTRoleNames.Saglik_Kurulu_Memuru,TTRoleNames.Saglik_Kurulu_Kisim_Amiri, TTRoleNames.Saglik_Kurulu_Tamamlanan_Islem_Geri_Alma, 
            TTRoleNames.Saglik_Kurulu_Islem_Geri_Alma,TTRoleNames.Bastabip,TTRoleNames.Bastabip_Yardimcisi)]
        public HealthCommitteeWorkListViewModel LoadHealthCommitteeWorkListViewModel()
        {
            var viewModel = new HealthCommitteeWorkListViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel.WorkList = new List<HealthCommitteeWorkListItem>();

                #region SEARCH CRITERIA
                viewModel._SearchCriteria = new HealthCommitteeWorkListSearchCriteria();
                viewModel._SearchCriteria.WorkListStartDate = Common.RecTime();
                DateTime dt = DateTime.Now;

                viewModel._SearchCriteria.WorkListEndDate = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
                viewModel._SearchCriteria.VoteStatus = 2;
                #endregion

                viewModel.HCRequestReasonList = HCRequestReason.GetHCRequestReason(objectContext).Where(z=>z.IsActive != false).ToList<HCRequestReason>();

                #region EpisodeAction Tipi Seçimi


                #endregion

                objectContext.FullPartialllyLoadedObjects();

                return viewModel;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Saglik_Kurulu_Veri_Hazirlama_Memuru, TTRoleNames.Saglik_Kurulu_Memuru, TTRoleNames.Saglik_Kurulu_Kisim_Amiri, TTRoleNames.Saglik_Kurulu_Tamamlanan_Islem_Geri_Alma,
            TTRoleNames.Saglik_Kurulu_Islem_Geri_Alma, TTRoleNames.Bastabip, TTRoleNames.Bastabip_Yardimcisi)]
        public HealthCommitteeWorkListViewModel GetHealthCommitteeWorkList(HealthCommitteeWorkListSearchCriteria sc)
        {
            int workListMaxItemCount = Common.WorklistMaxItemCount();
            int counter = 0;

            // GENEL 
            ResUser CurrentUser = Common.CurrentResource;
            var viewModel = new HealthCommitteeWorkListViewModel();
            viewModel.WorkList = new List<HealthCommitteeWorkListItem>();
            viewModel.maxWorklistItemCount = 0;
            //
            string _filter = string.Empty;

            if (!string.IsNullOrEmpty(sc.PatientObjectID))
            {
                _filter += " AND this.Episode.Patient.OBJECTID = '" + sc.PatientObjectID + "' ";
                //_filter += " AND this.PatientExaminationType = " + Common.GetEnumValueDefOfEnumValue(PatientExaminationEnum.HealthCommittee).Value.ToString();
            }

            if (sc._HCRequestReason != null)
            {
                _filter += " AND THIS.HCREQUESTREASON ='" + sc._HCRequestReason + "'";
            }

            if (sc.VoteStatus != 2)//tümü
            {
                _filter += " AND THIS.Ration ='" + sc.VoteStatus + "'";
            }

            //Sağlık Kurulu Muayenesi
            if (String.IsNullOrEmpty(sc.PatientObjectID))
                _filter += " AND this.REQUESTDATE BETWEEN " + GetDateAsString(sc.WorkListStartDate.Value.Date) + " AND " + GetDateAsString(sc.WorkListEndDate);

            string examination_States = string.Empty;
            if (sc.HCStateItems.Exists(x => x.TypeID == 0))//Yeni
            {
                if (!string.IsNullOrEmpty(examination_States))
                    examination_States += ",";
                examination_States += "States.New";
            }
            if (sc.HCStateItems.Exists(x => x.TypeID == 1))//Onay Bekleyen
            {
                if (!string.IsNullOrEmpty(examination_States))
                    examination_States += ",";
                examination_States += "States.New";
            }
            if (sc.HCStateItems.Exists(x => x.TypeID == 2))//Heyet Kabul
            {
                if (!string.IsNullOrEmpty(examination_States))
                    examination_States += ",";
                examination_States += "States.Report";
            }
            if (sc.HCStateItems.Exists(x => x.TypeID == 3))//Tamamlandı
            {
                if (!string.IsNullOrEmpty(examination_States))
                    examination_States += ",";
                examination_States += "States.Completed";
            }
            if (sc.HCStateItems.Exists(x => x.TypeID == 4))//İptal
            {
                if (!string.IsNullOrEmpty(examination_States))
                    examination_States += ",";
                examination_States += "States.Cancelled";
            }

            if (!string.IsNullOrEmpty(examination_States))
                _filter += " AND this.CURRENTSTATEDEFID IN(" + examination_States + ")";

            if (!String.IsNullOrEmpty(sc.ProtocolNo))
            {
                if (sc.ProtocolNo.Contains("-"))
                    _filter = " AND THIS.SUBEPISODE.PROTOCOLNO = '" + sc.ProtocolNo.Trim() + "'";
                else
                {
                    _filter = " AND THIS.SUBEPISODE.PROTOCOLNO LIKE '" + sc.ProtocolNo.Trim() + "%'";
                }
            }

            try
            {
                using (TTObjectContext objectContext = new TTObjectContext(true))
                {
                    var hcList = HealthCommittee.GetHealthCommitteeForWL(objectContext, _filter);
                    foreach (var hcFWL in hcList)
                    {
                        HealthCommittee hc = (HealthCommittee)objectContext.GetObject((Guid)hcFWL.ObjectID, "HealthCommittee");
                        // GENEL 
                        if (this.HasWorkListWorkListRight(objectContext, hc))// BASEDEN KULLANILIYOR  
                        {
                            HealthCommitteeWorkListItem workListItem = new HealthCommitteeWorkListItem();
                            //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları
                            var episode = hc.Episode;
                            workListItem.ObjectDefID = hcFWL.ObjectDefID.ToString();
                            workListItem.ObjectDefName = hcFWL.ObjectDefName;
                            workListItem.ObjectID = (Guid)hcFWL.ObjectID;
                            // Ikon set etmece
                            string PriorityStatus = hcFWL.Prioritystatus;
                            this.setWorkListIkonPropertyies(PriorityStatus, episode.Patient, workListItem);
                            workListItem.isEmergency = hcFWL.Isemergency == true ? true : false;
                            //

                            if (hcFWL.Date != null)
                                workListItem.startDate = Convert.ToDateTime(hcFWL.Date);
                            workListItem.PatientNameSurname = hcFWL.Patientnamesurname.ToString();
                            workListItem.KabulNo = hcFWL.Kabulno == null ? "" : hcFWL.Kabulno.ToString();

                            #region TAMAMLANMAMIŞ MUAYENE KONTROL
                            bool UnCompletedExaminationExists = HealthCommittee.UnCompletedExaminationExists(hc);
                            if (UnCompletedExaminationExists)
                            {
                                workListItem.RowColor = "#ffa2a2";
                                workListItem.ExaminationStatus = "Sonuçlanmamış Sağlık Kurulu Muayene İşlemleri Mevcut !";
                            }
                            else
                                workListItem.ExaminationStatus = "Sağlık Kurulu Muayene İşlemleri Sonuçlanmıştır";
                            #endregion

                            workListItem.UniqueRefno = hcFWL.UniqueRefNo == null ? "" : hcFWL.UniqueRefNo.ToString();
                            //workListItem.EpisodeActionName = hcFWL.Episodeactionname == null ? "" : hcFWL.Episodeactionname.ToString();
                            workListItem.statusName = hcFWL.Statename == null ? "" : hcFWL.Statename.ToString();
                            workListItem.StateID = hcFWL.CurrentStateDefID == null ? "" : hcFWL.CurrentStateDefID.ToString();
                            //workListItem.ResourceName = hcFWL.Masterresource == null ? "" : hcFWL.Masterresource.ToString(); ;
                            workListItem.ComingReason = hcFWL.Admissiontype == null ? "" : hcFWL.Admissiontype.ToString();  // Geliş Sebebi
                            workListItem.PayerInfo = hcFWL.Payername == null ? "" : hcFWL.Payername.ToString();
                            workListItem.ReportName = hc.HCRequestReason.ReasonName;
                            //workListItem.PatientClassGroup = hcFWL.Hastaturu == null ? "" : hcFWL.Hastaturu.ToString();
                            //workListItem.ApplicationReason = hcFWL.Basvuruturu == null ? "" : hcFWL.Basvuruturu.ToString();
                            if (hcFWL.BirthDate != null)
                                workListItem.BirthDate = hcFWL.BirthDate.Value; // Doğum Tarihi
                            workListItem.FatherName = hcFWL.FatherName == null ? "" : hcFWL.FatherName.ToString();  // Baba adı
                            workListItem.PhoneNumber = hcFWL.Telno == null ? "" : hcFWL.Telno.ToString();  // Telefon Numarası
                            workListItem.ReasonOfCancel = hcFWL.ReasonOfCancel;

                            viewModel.WorkList.Add(workListItem);
                            // GENEL 
                            counter++;
                            if (counter > workListMaxItemCount)
                            {
                                viewModel.maxWorklistItemCount += counter;
                                break;
                            }
                            //
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            viewModel.WorkList = viewModel.WorkList.OrderByDescending(dr => dr.startDate).ToList();
            return viewModel;
        }

        public string ChangeStatusName(Guid id)
        {
            string statusName = string.Empty;

            switch (id.ToString())
            {
                case "cb22e74b-a2be-456f-8680-660d0b21dc24": // plan
                    statusName = TTUtils.CultureService.GetText("M25573", "Eczaneden İstenmedi!");
                    break;
                case "da01e671-efb9-4d84-8122-4bae07e08c20": //İstek
                    statusName = TTUtils.CultureService.GetText("M25572", "Eczaneden İstendi");
                    break;
                case "94c4b7eb-b764-4ca5-add6-76e2217f7dd4": //Hastanın Üzerinde
                    statusName = TTUtils.CultureService.GetText("M25385", "Var Olan Kullanım");
                    break;
                case "d4f85132-8d05-4dc7-b9b2-fc04bae622b0": // Karşılandı
                    statusName = TTUtils.CultureService.GetText("M25571", "Eczaneden İstendi Eczane Tarafından Karşılandı!");
                    break;
                case "ad54f2c0-8ebe-4fbb-a57a-b7c870fd1fb3": // Eczacılık Bilimlerinden İstendi
                    statusName = "Eczacılık Bilimlerinden İstendi";
                    break;
                case "f1b24e44-ecb3-4b44-9b23-1d77e9901721": //Durdur
                    statusName = TTUtils.CultureService.GetText("M25549", "Durduruldu");
                    break;
                case "14ea4626-5b27-4663-82f9-64968cb4eb63": //Hastaya Teslim
                    statusName = TTUtils.CultureService.GetText("M25771", "Hasta / Hasta Yakınına teslim edildi.");
                    break;
                case "d39a37a6-610e-4143-aca2-691ce5818915": //Uygulandı
                    statusName = TTUtils.CultureService.GetText("M27138", "Uygulandı");
                    break;
                case "add6e452-c007-4849-b477-17d30400abe8": //İptal
                    statusName = TTUtils.CultureService.GetText("M27135", "Uygulama İptal Edildi!");
                    break;
                case "0586979d-523c-4800-995c-750ac3984606": //Dış Eczane Tarafından Karşılandı
                    statusName = TTUtils.CultureService.GetText("M25431", "Dış Eczane Tarafından Karşılandı");
                    break;
                case "4223ab9b-1b9f-4f59-845f-b903adcda8a0"://Eczaneye İade
                    statusName = TTUtils.CultureService.GetText("M25574", "Eczaneye İade");
                    break;
                default:
                    statusName = TTUtils.CultureService.GetText("M27042", "Tanımsız durum.Lütfen sistem yöneticisine başvurun!!");
                    break;
            }
            return statusName;
        }

    }
}
namespace Core.Models
{
    public partial class HealthCommitteeWorkListViewModel : BaseEpisodeActionWorkListFormViewModel
    {
        public List<HealthCommitteeWorkListItem> WorkList;
        public HealthCommitteeWorkListSearchCriteria _SearchCriteria
        {
            get;
            set;
        }
        public List<HCRequestReason> HCRequestReasonList { get; set; }

        public HealthCommitteeWorkListViewModel()
        {
            this._SearchCriteria = new HealthCommitteeWorkListSearchCriteria();
            this.WorkList = new List<HealthCommitteeWorkListItem>();
            this.HCRequestReasonList = new List<HCRequestReason>();
        }
    }

    [Serializable]
    public class HealthCommitteeWorkListSearchCriteria : BaseEpisodeActionWorkListSearchCriteria
    {
        public List<ListObject> HCStateItems { get; set; }
        public string _HCRequestReason { get; set; }
        public int VoteStatus { get; set; }
        public string ProtocolNo { get; set; }
    }

    public class HealthCommitteeWorkListItem : BaseEpisodeActionWorkListItem
    {
        public DateTime startDate
        {
            get;
            set;
        }

        public DateTime endDate
        {
            get;
            set;
        }

        public string PatientNameSurname
        {
            get;
            set;
        }

        public string statusName
        {
            get;
            set;
        }

        public string ReportName { get; set; }// Aslında ReasonName

        public string KabulNo { get; set; }
        public string ExaminationStatus { get; set; }

        #region HIDDEN COLUMN

        public string ComingReason { get; set; }

        public string PayerInfo { get; set; }

        public DateTime BirthDate { get; set; }

        public string FatherName { get; set; }

        public string PhoneNumber { get; set; }

        public string UniqueRefno
        {
            get;
            set;
        }

        public string ReasonOfCancel
        {
            get;
            set;
        }

        public string HastaTuru { get; set; }

        public string BasvuruTuru { get; set; }

        #endregion

        #region GRIDDE KULLANILMAYAN PROPERTYLER
        public Guid id
        {
            get;
            set;
        }
        public Guid stateDefID
        {
            get;
            set;
        }

        public OrderTypeEnum typeId
        {
            get;
            set;
        }

        public string typeName { get; set; }

        public string StateID
        {
            get;
            set;
        }
        #endregion

        #region ICONS
        public bool HasTightContactIsolation { get; set; }
        public bool HasFallingRisk { get; set; }
        public bool HasDropletIsolation { get; set; }
        public bool HasAirborneContactIsolation { get; set; }
        public bool HasContactIsolation { get; set; }
        public string OzelDurum { get; set; }
        #endregion
    }

}
