//$358A124E
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

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class ParticipatnFreeDrugReportServiceController : Controller
    {
        public class eraporGiris_Input
        {
            public TTObjectClasses.ParticipatnFreeDrugReport pfr
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.IlacRaporuServis.eraporGirisIstekDVO eraporGiris(eraporGiris_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pfr != null)
                    input.pfr = (TTObjectClasses.ParticipatnFreeDrugReport)objectContext.AddObject(input.pfr);
                var ret = ParticipatnFreeDrugReport.eraporGiris(input.pfr);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class eraporSil_Input
        {
            public TTObjectClasses.ParticipatnFreeDrugReport pfr
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.IlacRaporuServis.eraporSilIstekDVO eraporSil(eraporSil_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pfr != null)
                    input.pfr = (TTObjectClasses.ParticipatnFreeDrugReport)objectContext.AddObject(input.pfr);
                var ret = ParticipatnFreeDrugReport.eraporSil(input.pfr);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class eraporSorgula_Input
        {
            public TTObjectClasses.ParticipatnFreeDrugReport pfr
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.IlacRaporuServis.eraporSorguIstekDVO eraporSorgula(eraporSorgula_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pfr != null)
                    input.pfr = (TTObjectClasses.ParticipatnFreeDrugReport)objectContext.AddObject(input.pfr);
                var ret = ParticipatnFreeDrugReport.eraporSorgula(input.pfr);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class eraporListeSorgula_Input
        {
            public TTObjectClasses.ParticipatnFreeDrugReport pfr
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.IlacRaporuServis.eraporListeSorguIstekDVO eraporListeSorgula(eraporListeSorgula_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pfr != null)
                    input.pfr = (TTObjectClasses.ParticipatnFreeDrugReport)objectContext.AddObject(input.pfr);
                var ret = ParticipatnFreeDrugReport.eraporListeSorgula(input.pfr);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class eraporOnay_Input
        {
            public TTObjectClasses.ParticipatnFreeDrugReport pfr
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.IlacRaporuServis.eraporOnayIstekDVO eraporOnay(eraporOnay_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pfr != null)
                    input.pfr = (TTObjectClasses.ParticipatnFreeDrugReport)objectContext.AddObject(input.pfr);
                var ret = ParticipatnFreeDrugReport.eraporOnay(input.pfr);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class eraporOnayRed_Input
        {
            public TTObjectClasses.ParticipatnFreeDrugReport pfr
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.IlacRaporuServis.eraporOnayRedIstekDVO eraporOnayRed(eraporOnayRed_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pfr != null)
                    input.pfr = (TTObjectClasses.ParticipatnFreeDrugReport)objectContext.AddObject(input.pfr);
                var ret = ParticipatnFreeDrugReport.eraporOnayRed(input.pfr);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class eraporOnayBekleyenListeSorgu_Input
        {
            public TTObjectClasses.ParticipatnFreeDrugReport pfr
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.IlacRaporuServis.eraporOnayBekleyenListeSorguIstekDVO eraporOnayBekleyenListeSorgu(eraporOnayBekleyenListeSorgu_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pfr != null)
                    input.pfr = (TTObjectClasses.ParticipatnFreeDrugReport)objectContext.AddObject(input.pfr);
                var ret = ParticipatnFreeDrugReport.eraporOnayBekleyenListeSorgu(input.pfr);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class eraporBashekimOnay_Input
        {
            public TTObjectClasses.ParticipatnFreeDrugReport pfr
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.IlacRaporuServis.eraporBashekimOnayIstekDVO eraporBashekimOnay(eraporBashekimOnay_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pfr != null)
                    input.pfr = (TTObjectClasses.ParticipatnFreeDrugReport)objectContext.AddObject(input.pfr);
                var ret = ParticipatnFreeDrugReport.eraporBashekimOnay(input.pfr);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class eraporBashekimOnayRed_Input
        {
            public TTObjectClasses.ParticipatnFreeDrugReport pfr
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.IlacRaporuServis.eraporBashekimOnayRedIstekDVO eraporBashekimOnayRed(eraporBashekimOnayRed_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pfr != null)
                    input.pfr = (TTObjectClasses.ParticipatnFreeDrugReport)objectContext.AddObject(input.pfr);
                var ret = ParticipatnFreeDrugReport.eraporBashekimOnayRed(input.pfr);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class eraporBashekimOnayBekleyenListeSorgu_Input
        {
            public TTObjectClasses.ParticipatnFreeDrugReport pfr
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.IlacRaporuServis.eraporBashekimOnayBekleyenListeSorguIstekDVO eraporBashekimOnayBekleyenListeSorgu(eraporBashekimOnayBekleyenListeSorgu_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pfr != null)
                    input.pfr = (TTObjectClasses.ParticipatnFreeDrugReport)objectContext.AddObject(input.pfr);
                var ret = ParticipatnFreeDrugReport.eraporBashekimOnayBekleyenListeSorgu(input.pfr);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class eraporAciklamaEkle_Input
        {
            public TTObjectClasses.ParticipatnFreeDrugReport pfr
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.IlacRaporuServis.eraporAciklamaEkleIstekDVO eraporAciklamaEkle(eraporAciklamaEkle_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pfr != null)
                    input.pfr = (TTObjectClasses.ParticipatnFreeDrugReport)objectContext.AddObject(input.pfr);
                var ret = ParticipatnFreeDrugReport.eraporAciklamaEkle(input.pfr);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class eraporEtkinMaddeEkle_Input
        {
            public TTObjectClasses.ParticipatnFreeDrugReport pfr
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.IlacRaporuServis.eraporEtkinMaddeEkleIstekDVO eraporEtkinMaddeEkle(eraporEtkinMaddeEkle_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pfr != null)
                    input.pfr = (TTObjectClasses.ParticipatnFreeDrugReport)objectContext.AddObject(input.pfr);
                var ret = ParticipatnFreeDrugReport.eraporEtkinMaddeEkle(input.pfr);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class eraporTaniEkle_Input
        {
            public TTObjectClasses.ParticipatnFreeDrugReport pfr
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.IlacRaporuServis.eraporTaniEkleIstekDVO eraporTaniEkle(eraporTaniEkle_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pfr != null)
                    input.pfr = (TTObjectClasses.ParticipatnFreeDrugReport)objectContext.AddObject(input.pfr);
                var ret = ParticipatnFreeDrugReport.eraporTaniEkle(input.pfr);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class eraporTeshisEkle_Input
        {
            public TTObjectClasses.ParticipatnFreeDrugReport pfr
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.IlacRaporuServis.eraporTeshisEkleIstekDVO eraporTeshisEkle(eraporTeshisEkle_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pfr != null)
                    input.pfr = (TTObjectClasses.ParticipatnFreeDrugReport)objectContext.AddObject(input.pfr);
                var ret = ParticipatnFreeDrugReport.eraporTeshisEkle(input.pfr);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetParticipatnFreeDrugReportRNQL_Input
        {
            public Guid TTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL_Class> GetParticipatnFreeDrugReportRNQL(GetParticipatnFreeDrugReportRNQL_Input input)
        {
            var ret = ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL(input.TTOBJECTID);
            return ret;
        }

        public class GetCompletedBySubEpisode_Input
        {
            public Guid SUBEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<ParticipatnFreeDrugReport> GetCompletedBySubEpisode(GetCompletedBySubEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ParticipatnFreeDrugReport.GetCompletedBySubEpisode(objectContext, input.SUBEPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}