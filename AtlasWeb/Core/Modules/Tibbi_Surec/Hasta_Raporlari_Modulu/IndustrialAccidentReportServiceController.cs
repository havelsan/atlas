using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class IndustrialAccidentReportServiceController : Controller
    {
        
        [HttpGet]
        public IndustrialAccidentReportFormViewModel LoadIndustrialAccidentReportModel(string EpisodeActionID )
        {
            IndustrialAccidentReportFormViewModel model = new IndustrialAccidentReportFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(new Guid(EpisodeActionID));
                SubEpisode subepisode = episodeAction.SubEpisode;
                Patient patient = subepisode.Episode.Patient;
                //Ad soyad tc dogum tarihi uyruk
                model.AdiSoyadi = patient.Name + " " + patient.Surname;
                model.TCKimlikNo = patient.UniqueRefNo == null ? "" : patient.UniqueRefNo.ToString();
                model.DogumTarihi = patient.BirthDate;
                model.Uyruk = patient.Nationality.Adi;
                model.SubepisodeID = subepisode.ObjectID.ToString();
                BindingList<IndustrialAccidentReport.GetIndustrialAccidentReportBySubepisode_Class> reportList = IndustrialAccidentReport.GetIndustrialAccidentReportBySubepisode(subepisode.ObjectID);
                if (reportList.Count > 0)
                {
                    model.IsNew = false;
                    IndustrialAccidentReport report = objectContext.GetObject<IndustrialAccidentReport>(new Guid(reportList[0].ObjectID.ToString()));
                    model.ObjectID = report.ObjectID.ToString();
                    model.IsYeriIl = report.City == null ? "" : report.City;
                    model.SaptanmaSekli = report.DeterminationWay == null ? "" : report.DeterminationWay;
                    model.MeslekHastaligiEtkenSuresi = report.DiseaseActiveTime == null ? "" : report.DiseaseActiveTime;
                    model.MeslekHastaligiEtkeni = report.DiseaseFactor == null ? "" : report.DiseaseFactor;
                    model.IsGoremezlikSeviyesi = report.IncapacityLevel == null ? "" : report.IncapacityLevel;
                    model.BildirimTarihi = report.NoticeDate;
                    model.BildirimTarihi2 = report.NoticeDate2;
                    model.Tel = report.PhoneNumber == null ? "" : report.PhoneNumber;
                    model.Gorevi = report.Position == null ? "" : report.Position;
                    model.Unite = report.Unit == null ? "" : report.Unit;
                    model.IsYeriAdres = report.WorkAddress == null ? "" : report.WorkAddress;
                    model.CalisilanOrtam = report.WorkEnvironment == null ? "" : report.WorkEnvironment;
                    model.IsYeriNo = report.WorkPlaceNo == null ? "" : report.WorkPlaceNo;
                    model.IsYeriUnvan = report.WorkTitle == null ? "" : report.WorkTitle;
                    model.Arac = report.WoundCause == null ? "" : report.WoundCause;
                    model.YaraninVucuttakiYeri = report.WoundLocation == null ? "" : report.WoundLocation;
                    model.YaraninTuru = report.WoundType == null ? "" : report.WoundType;
                    
                }
                else
                {
                    model.IsNew = true;
                    model.ObjectID = string.Empty;
                   //Yoksa obje yaratılıp döndürülecek
                }
            }
            return model;
        }

        [HttpPost]
        public void SaveIndustrialAccidentReportModel(IndustrialAccidentReportFormViewModel model)
        {
          
            using (var objectContext = new TTObjectContext(false))
            {

                if (model.IsNew == true)
                {
                    IndustrialAccidentReport report = new IndustrialAccidentReport(objectContext);
                    report.SubEpisode = objectContext.GetObject<SubEpisode>(new Guid(model.SubepisodeID));
                    report.City = model.IsYeriIl ==null?"": model.IsYeriIl;
                    report.DeterminationWay = model.SaptanmaSekli == null?"": model.SaptanmaSekli;
                    report.DiseaseActiveTime = model.MeslekHastaligiEtkenSuresi==null?"": model.MeslekHastaligiEtkenSuresi;
                    report.DiseaseFactor = model.MeslekHastaligiEtkeni==null?"": model.MeslekHastaligiEtkeni;
                    report.IncapacityLevel = model.IsGoremezlikSeviyesi == null ? "" : model.IsGoremezlikSeviyesi;
                    report.NoticeDate = model.BildirimTarihi;
                    report.NoticeDate2 = model.BildirimTarihi2;
                    report.PhoneNumber = model.Tel == null ? "" : model.Tel;
                    report.Position = model.Gorevi == null ? "" : model.Gorevi;
                    report.Unit = model.Unite == null ? "" : model.Unite;
                    report.WorkAddress = model.IsYeriAdres == null ? "" : model.IsYeriAdres;
                    report.WorkEnvironment = model.CalisilanOrtam == null ? "" : model.CalisilanOrtam;
                    report.WorkPlaceNo = model.IsYeriNo == null ? "" : model.IsYeriNo;
                    report.WorkTitle = model.IsYeriUnvan == null ? "" : model.IsYeriUnvan;
                    report.WoundCause = model.Arac == null ? "" : model.Arac;
                    report.WoundLocation = model.YaraninVucuttakiYeri == null ? "" : model.YaraninVucuttakiYeri;
                    report.WoundType = model.YaraninTuru == null ? "" : model.YaraninTuru;

                }
                else
                {
                    IndustrialAccidentReport report = objectContext.GetObject<IndustrialAccidentReport>(new Guid(model.ObjectID));
       
                    report.City = model.IsYeriIl == null ? "" : model.IsYeriIl;
                    report.DeterminationWay = model.SaptanmaSekli == null ? "" : model.SaptanmaSekli;
                    report.DiseaseActiveTime = model.MeslekHastaligiEtkenSuresi == null ? "" : model.MeslekHastaligiEtkenSuresi;
                    report.DiseaseFactor = model.MeslekHastaligiEtkeni == null ? "" : model.MeslekHastaligiEtkeni;
                    report.IncapacityLevel = model.IsGoremezlikSeviyesi == null ? "" : model.IsGoremezlikSeviyesi;
                    report.NoticeDate = model.BildirimTarihi;
                    report.NoticeDate2 = model.BildirimTarihi2;
                    report.PhoneNumber = model.Tel == null ? "" : model.Tel;
                    report.Position = model.Gorevi == null ? "" : model.Gorevi;
                    report.Unit = model.Unite == null ? "" : model.Unite;
                    report.WorkAddress = model.IsYeriAdres == null ? "" : model.IsYeriAdres;
                    report.WorkEnvironment = model.CalisilanOrtam == null ? "" : model.CalisilanOrtam;
                    report.WorkPlaceNo = model.IsYeriNo == null ? "" : model.IsYeriNo;
                    report.WorkTitle = model.IsYeriUnvan == null ? "" : model.IsYeriUnvan;
                    report.WoundCause = model.Arac == null ? "" : model.Arac;
                    report.WoundLocation = model.YaraninVucuttakiYeri == null ? "" : model.YaraninVucuttakiYeri;
                    report.WoundType = model.YaraninTuru == null ? "" : model.YaraninTuru;

                }

                objectContext.Save();

                
            }
           
        }
    }
}
