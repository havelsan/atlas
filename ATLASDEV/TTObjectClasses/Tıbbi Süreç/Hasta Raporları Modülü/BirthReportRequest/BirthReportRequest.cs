
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
    /// Birden Fazla Doğum Raporunun Yazılması İçin Kullanılan NEsnedir
    /// </summary>
    public  partial class BirthReportRequest : EpisodeAction
    {
#region Methods
        public BirthReportRequest(TTObjectContext objectContext, EpisodeAction episodeAction)
            : this(objectContext)
        {
            ActionDate = Common.RecTime();
            if (episodeAction is Surgery)
            {
                MasterResource = episodeAction.FromResource;
                FromResource = episodeAction.FromResource;
            }
            else
            {
                MasterResource = episodeAction.MasterResource;
                FromResource = episodeAction.MasterResource;
            }

            MasterAction = episodeAction;
            CurrentStateDefID = BirthReportRequest.States.New;
            Episode = episodeAction.Episode;
        }


        /*public RaporIslemleri.raporGirisDVO GetTakipNoileRaporBilgisiKaydet(BirthReportRequest brr)
          {
              RaporIslemleri.raporGirisDVO raporGirisDVO = new RaporIslemleri.raporGirisDVO();
              if ( brr.SubEpisode!=null && brr.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(brr.SubEpisode.SGKSEP.MedulaTakipNo))
              {
                
                  int countAlive = 0;

                  raporGirisDVO.ilacRapor = null;
                  //TODO : MEDULA20140501
                  raporGirisDVO.saglikTesisKodu =  SystemParameter.GetSaglikTesisKodu();
                  raporGirisDVO.tedaviRapor = null;
                  raporGirisDVO.isgoremezlikRapor = null;
                
             
 
                  RaporIslemleri.dogumRaporDVO _dogumRaporDVO = new RaporIslemleri.dogumRaporDVO();
                  if (this.BirthReports != null && this.BirthReports[0] != null)
                  {
                      _dogumRaporDVO.anesteziTipi = this.BirthReports[0].AestesiaType != null ? ((int)this.BirthReports[0].AestesiaType).ToString() : "";
                      _dogumRaporDVO.bebekDogumTarihi = this.BirthReports[0].BabyBirthDate != null ? this.BirthReports[0].BabyBirthDate.ToString() : "";
                      _dogumRaporDVO.dogumTipi = this.BirthReports[0].BornType != null ? Convert.ToInt32(this.BirthReports[0].BornType).ToString() : "";
                      _dogumRaporDVO.epizyotemi = this.BirthReports[0].Episiotomy != null ? ((int)this.BirthReports[0].Episiotomy).ToString() : "";
                  }
                  List<RaporIslemleri.cocukBilgisiDVO> _cocukBilgisiDVOList = new List<RaporIslemleri.cocukBilgisiDVO>();
                  foreach (BirthReport item in this.BirthReports)
                  {

                      RaporIslemleri.cocukBilgisiDVO _cocukBilgisiDVO = new RaporIslemleri.cocukBilgisiDVO();
                      _cocukBilgisiDVO.cinsiyet = item.Sex != null ? ((int)item.Sex).ToString() : "";
                      _cocukBilgisiDVO.dogumSaati = item.BirthTime != null ? item.BirthTime.ToString() : "";
                      _cocukBilgisiDVO.kilo = item.Weight != null ? item.Weight.ToString() : "";
                      _cocukBilgisiDVOList.Add(_cocukBilgisiDVO);
                      if (item.BabyStatus == BirthReportBabyStatus.Alive)
                          countAlive++;

                  }

                  _dogumRaporDVO.canliCocukSayisi = countAlive;
                  _dogumRaporDVO.cocuklar = _cocukBilgisiDVOList.ToArray();
                  _dogumRaporDVO.cocukSayisi = this.BirthReports.Count;

                  RaporIslemleri.raporDVO _raporDVO = new RaporIslemleri.raporDVO();

                  _raporDVO.aciklama = "";

                   _raporDVO.baslangicTarihi = ReportStartDatePhysiotherapyRequest.Text;
                   _raporDVO.bitisTarihi = ReportEndDatePhysiotherapyRequest.Text;
                  _raporDVO.durum = "";
                  _raporDVO.duzenlemeTuru = "2";
                  _raporDVO.klinikTani = "";
                  _raporDVO.protokolNo =  brr.Episode.HospitalProtocolNo.ToString();
                  _raporDVO.protokolTarihi = brr.SubEpisode.PatientAdmission.ActionDate != null ? brr.SubEpisode.PatientAdmission.ActionDate.Value.ToString("dd.MM.yyyy") : "";

                  List<RaporIslemleri.taniBilgisiDVO> _taniBilgisiDVOList = new List<RaporIslemleri.taniBilgisiDVO>();
                  foreach (DiagnosisGrid diagnosis in brr.Episode.Diagnosis)
                  {
                      RaporIslemleri.taniBilgisiDVO _taniBilgisiDVO = new RaporIslemleri.taniBilgisiDVO();
                      _taniBilgisiDVO.taniKodu = diagnosis.DiagnoseCode;
                      _taniBilgisiDVOList.Add(_taniBilgisiDVO);

                  }
                  if (_taniBilgisiDVOList.Count > 0)
                      _raporDVO.tanilar = _taniBilgisiDVOList.ToArray();

                  _raporDVO.turu = "1";
                  _raporDVO.takipNo = brr.Episode.SubEpisodes[0].SGKSEP.MedulaTakipNo;




                  List<RaporIslemleri.doktorBilgisiDVO> _doktorBilgisiDVOList = new List<RaporIslemleri.doktorBilgisiDVO>();
                  RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO = new RaporIslemleri.doktorBilgisiDVO();
                  _doktorBilgisiDVO.drAdi = brr.ProcedureDoctor.Person.Name;
                  _doktorBilgisiDVO.drBransKodu = brr.ProcedureDoctor.GetSpeciality() != null ? this._PhysiotherapyOrder.PhysiotherapyRequest.ProcedureDoctor.GetSpeciality().Code : "";
                  _doktorBilgisiDVO.drSoyadi = brr.ProcedureDoctor.Person.Surname;
                  _doktorBilgisiDVO.drTescilNo = brr.ProcedureDoctor.DiplomaRegisterNo;
                  _doktorBilgisiDVO.tipi = "2";
                  _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);
                  _raporDVO.doktorlar = _doktorBilgisiDVOList.ToArray();

                  _raporDVO.hakSahibi = null;

                  RaporIslemleri.raporBilgisiDVO _raporBilgisiDVO = new RaporIslemleri.raporBilgisiDVO();
                  _raporBilgisiDVO.AVakaTKaza = 3;
                    _raporBilgisiDVO.no = brr.ReportNo.Value.ToString();
                  _raporBilgisiDVO.raporSiraNo = 0;
                  _raporBilgisiDVO.raporTakipNo = "";
                  _raporBilgisiDVO.raporTesisKodu = SystemParameter.GetSaglikTesisKodu();
                   _raporBilgisiDVO.tarih = ReportStartDatePhysiotherapyRequest.Text;
                  _raporDVO.raporBilgisi = _raporBilgisiDVO;
                  _raporDVO.teshisler = null;


                
                  _dogumRaporDVO.raporDVO = _raporDVO;
                
                

              }
              return raporGirisDVO;

          }*/
        
#endregion Methods

    }
}