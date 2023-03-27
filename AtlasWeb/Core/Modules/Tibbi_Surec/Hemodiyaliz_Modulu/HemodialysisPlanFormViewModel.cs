//$74A2C10E
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class HemodialysisOrderServiceController
    {
        partial void PreScript_HemodialysisPlanForm(HemodialysisPlanFormViewModel viewModel, HemodialysisOrder hemodialysisOrder, TTObjectContext objectContext)
        {
            if (hemodialysisOrder.SubEpisode.IsSGK == true)
            {
                viewModel.IsSGKPatient = true;
            }
            else
            {
                viewModel.IsSGKPatient = false;
            }

            List<ResEquipment> resEquipmentList = new List<ResEquipment>();
            var equipmentList = ResEquipment.GetHemodialysisResEquipment(objectContext);
            foreach (var equipment in equipmentList)
            {
                ResEquipment resEquipment = objectContext.GetObject(equipment.ObjectID.Value, equipment.ObjectDefID.Value) as ResEquipment;
                resEquipmentList.Add(resEquipment);
            }
            viewModel.ResEquipments = resEquipmentList.ToArray();
            ContextToViewModel(viewModel, objectContext);
        }

        //[HttpPost]
        //[AtlasRequiredRoles(TTRoleNames.Fizyoterapi_Rapor_Sorgulama)]
        public HemodialysisPlanFormViewModel GetMedulaReportInfo()
        {
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    Guid? activeEpisodeObjectID = Request.Headers.GetSelectedEpisodeID();
                    Episode activeEpisode = new Episode();
                    if (activeEpisodeObjectID.HasValue)
                    {
                        activeEpisode = objectContext.GetObject<Episode>(activeEpisodeObjectID.Value);
                    }

                    HemodialysisPlanFormViewModel viewModel = new HemodialysisPlanFormViewModel();
                    viewModel.ReportList = new List<HemodialysisReports>();


                    RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();

                    _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                    _raporOkuTCKimlikNodanDVO.raporTuru = "1";

                    if (activeEpisode.Patient.Privacy != null && activeEpisode.Patient.Privacy == true)//Gizli hasta ise
                    {
                        if (activeEpisode.Patient.PrivacyUniqueRefNo == null)//&& activeEpisode.Patient.PrivacyPatient.YUPASSNO == null
                        {
                            throw new Exception(TTUtils.CultureService.GetText("M26315", "Ki�inin Sistemde Tan�ml� Bir Kimlik Numaras� Yoktur. ��lem Yapmadan �nce Kimlik Bilgilerini G�ncelleyiniz!!!"));
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
                            throw new Exception(TTUtils.CultureService.GetText("M26315", "Ki�inin Sistemde Tan�ml� Bir Kimlik Numaras� Yoktur. ��lem Yapmadan �nce Kimlik Bilgilerini G�ncelleyiniz!!!"));
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
                            //viewModel.Message = "Sonuc A��klamas� : " + response.sonucAciklamasi + " Sonu� Kodu :" + response.sonucKodu;
                        }
                        if (response.raporlar == null)
                        {
                            //viewModel.Message = TTUtils.CultureService.GetText("M26311", "Ki�inin D�� XXXXXX Rapor Bilgisi Bulunamam��t�r.");
                        }
                        if (response.sonucKodu.Equals(0))
                        {
                            if (response.raporlar != null && response.raporlar.Length > 0)
                            {
                                foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
                                {
                                    HemodialysisReports _hemodialysisReports = new HemodialysisReports(objectContext);
                                    if (item.tedaviRapor != null && item.tedaviRapor.tedaviRaporTuru == 1) // tedaviRaporTuru==1-> Diyaliz Raporu
                                    {
                                        if (item.tedaviRapor.raporDVO.raporBilgisi.raporTesisKodu == Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX")))
                                        {
                                            _hemodialysisReports.DiagnosisGroup = item.tedaviRapor.raporDVO.tanilar.FirstOrDefault().taniKodu;
                                            //_hemodialysisReports.PackageProcedureInfo = tedaviIslemBilgisiDVO.diyalizRaporBilgisi.butKodu;
                                            _hemodialysisReports.ReportDate = DateTime.Parse(item.tedaviRapor.raporDVO.raporBilgisi.tarih);
                                            _hemodialysisReports.ReportEndDate = DateTime.Parse(item.tedaviRapor.raporDVO.bitisTarihi);
                                            //_hemodialysisReports.ReportInfo = " K�r :" + tedaviIslemBilgisiDVO.diyalizRaporBilgisi.seansSayi.ToString();
                                            _hemodialysisReports.ReportNo = item.raporTakipNo.ToString();
                                            _hemodialysisReports.ReportStartDate = DateTime.Parse(item.tedaviRapor.raporDVO.baslangicTarihi);
                                            //_hemodialysisReports.ReportTime = tedaviIslemBilgisiDVO.diyalizRaporBilgisi.seansGun;
                                            _hemodialysisReports.ReportType = item.tedaviRapor.raporDVO.duzenlemeTuru == "1" ? true : false;
                                            //_hemodialysisReports.SessionDay = tedaviIslemBilgisiDVO.diyalizRaporBilgisi.seansSayi;
                                            //_hemodialysisReports.SessionLimit = tedaviIslemBilgisiDVO.diyalizRaporBilgisi.seansSayi;
                                            _hemodialysisReports.TreatmentType = TreatmentQueryReportTypeEnum.FTR;

                                            foreach (RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisiDVO in item.tedaviRapor.islemler)
                                            {
                                                RaporIslemleri.diyalizRaporBilgisiDVO diyalizIslemBilgisi = tedaviIslemBilgisiDVO.diyalizRaporBilgisi;
                                                _hemodialysisReports.PackageProcedureInfo = diyalizIslemBilgisi.butKodu;
                                                _hemodialysisReports.ReportInfo = " K�r :" + diyalizIslemBilgisi.seansSayi.ToString();
                                                _hemodialysisReports.ReportTime = diyalizIslemBilgisi.seansGun;
                                                _hemodialysisReports.SessionDay = diyalizIslemBilgisi.seansSayi;
                                                _hemodialysisReports.SessionLimit = diyalizIslemBilgisi.seansSayi;
                                            }

                                            viewModel.ReportList.Add(_hemodialysisReports);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception(TTUtils.CultureService.GetText("M26314", "Ki�inin Rapor Bilgisi Bulunamam��t�r. L�tfen �nce Rapor Olu�turunuz !"));
                            }
                        }
                    }


                    return viewModel;
                }
            }
            catch (Exception)
            {

                throw new Exception("Rapor i�lemleri yap�lamam��t�r!");
            }
        }
    }
}

namespace Core.Models
{
    public partial class HemodialysisPlanFormViewModel : BaseViewModel
    {
        public bool IsSGKPatient { get; set; }//�cretli hasta,kurum hastas� ise:false -- Sgk hastas� ise true
        public List<HemodialysisReports> ReportList { get; set; }
    }
}
