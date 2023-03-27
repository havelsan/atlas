using System.Collections.Generic;
using System.Linq;
using Core.Models;
using TTInstanceManagement;
using System;
using TTObjectClasses;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Filters;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class OrtodontiFormController : Controller
    {
        public class OnInitOutputDVO
        {
            public List<TedaviRaporiIslemKodlari> suts { get; set; }
            public List<ActiveMedulaProvision> provisions { get; set; }
            public string txtTCKNo { get; set; }
            public string txtBirthDate { get; set; }
            public string txtSex { get; set; }
        }

        public class ActiveMedulaProvision
        {
            public string TakipNo { get; set; }
            public string Brans { get; set; }
            public DateTime ProvisionDate { get; set; }
            public string BarsvuruNo { get; set; }
            public string ProtocolNo { get; set; }
            public DateTime OpenDate { get; set; }
            public string BransKodu { get; set; }
        }

        [HttpGet]
        public OnInitOutputDVO GetForm([FromQuery] string PatientObjectId)
        {
            OnInitOutputDVO output = new OnInitOutputDVO();
            List<TedaviRaporiIslemKodlari> suts = new List<TedaviRaporiIslemKodlari>();
            List<ActiveMedulaProvision> provisions = new List<ActiveMedulaProvision>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                Patient patient = (Patient)objectContext.GetObject(new Guid(PatientObjectId), typeof(Patient));
                List<SubEpisodeProtocol> retList = new List<SubEpisodeProtocol>();
                retList = patient.GetActiveSGKSEPs(null, null);
                foreach (SubEpisodeProtocol sep in retList)
                {
                    if (sep.MedulaTakipNo != null)
                    {
                        if (sep.Brans.Code == "5200")
                        {
                            ActiveMedulaProvision activeMedulaProvision = new ActiveMedulaProvision();
                            activeMedulaProvision.TakipNo = sep.MedulaTakipNo;
                            activeMedulaProvision.Brans = sep.Brans.Name_Shadow;
                            activeMedulaProvision.ProvisionDate = (DateTime)sep.MedulaProvizyonTarihi;
                            activeMedulaProvision.BarsvuruNo = sep.MedulaBasvuruNo;
                            activeMedulaProvision.ProtocolNo = sep.Episode.HospitalProtocolNo.ToString();
                            activeMedulaProvision.OpenDate = (DateTime)sep.Episode.OpeningDate;
                            activeMedulaProvision.BransKodu = sep.Brans.Code;
                            provisions.Add(activeMedulaProvision);
                        }
                    }
                }

                IBindingList sut = objectContext.QueryObjects("TEDAVIRAPORIISLEMKODLARI", "TEDAVIRAPORUTURUKODU='10'");
                foreach (TedaviRaporiIslemKodlari r in sut)
                    suts.Add(r);

                output.suts = suts;
                output.provisions = provisions;
                output.txtTCKNo = patient.UniqueRefNo.ToString();
                output.txtBirthDate = patient.BirthDate.ToString();
                output.txtSex = patient.Sex.ADI; 
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }
    }
}


