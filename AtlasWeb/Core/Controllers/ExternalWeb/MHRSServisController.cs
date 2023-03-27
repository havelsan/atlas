//$5718B117
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.MHRSServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class MHRSServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public MHRSServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class RandevuDurumGuncelleSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public RandevuDurumGuncelleTalepType RandevuDurumGuncelleTalep
            {
                get;
                set;
            }
        }

        public RandevuDurumGuncelleCevapType RandevuDurumGuncelleSync(RandevuDurumGuncelleSyncInput input)
        {
            var result = MHRSServis.WebMethods.RandevuDurumGuncelleSync(input.siteID, input.RandevuDurumGuncelleTalep);
            return result;
        }

        public class KurumTaslakCetvelEklemeSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumTaslakCetvelEklemeTalepType KurumTaslakCetvelEklemeTalep
            {
                get;
                set;
            }
        }

        public KurumTaslakCetvelEklemeCevapType KurumTaslakCetvelEklemeSync(KurumTaslakCetvelEklemeSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumTaslakCetvelEklemeSync(input.siteID, input.KurumTaslakCetvelEklemeTalep);
            return result;
        }

        public class KurumTaslakCetvelGuncellemeSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumTaslakCetvelGuncellemeTalepType KurumTaslakCetvelGuncellemeTalep
            {
                get;
                set;
            }
        }

        public KurumTaslakCetvelGuncellemeCevapType KurumTaslakCetvelGuncellemeSync(KurumTaslakCetvelGuncellemeSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumTaslakCetvelGuncellemeSync(input.siteID, input.KurumTaslakCetvelGuncellemeTalep);
            return result;
        }

        public class KurumTaslakCetvelKesinlestirmeSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumTaslakCetvelKesinlestirmeTalepType KurumTaslakCetvelKesinlestirmeTalep
            {
                get;
                set;
            }
        }

        public KurumTaslakCetvelKesinlestirmeCevapType KurumTaslakCetvelKesinlestirmeSync(KurumTaslakCetvelKesinlestirmeSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumTaslakCetvelKesinlestirmeSync(input.siteID, input.KurumTaslakCetvelKesinlestirmeTalep);
            return result;
        }

        public class RandevuEklemeSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public RandevuEklemeTalepType RandevuEklemeTalep
            {
                get;
                set;
            }
        }

        public RandevuEklemeCevapType RandevuEklemeSync(RandevuEklemeSyncInput input)
        {
            var result = MHRSServis.WebMethods.RandevuEklemeSync(input.siteID, input.RandevuEklemeTalep);
            return result;
        }

        public class RandevuKlinikSorgulamaObjSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public RandevuKlinikSorgulamaTalepType RandevuKlinikSorgulamaObjTalep
            {
                get;
                set;
            }
        }

        public RandevuKlinikSorgulamaObjCevapType RandevuKlinikSorgulamaObjSync(RandevuKlinikSorgulamaObjSyncInput input)
        {
            var result = MHRSServis.WebMethods.RandevuKlinikSorgulamaObjSync(input.siteID, input.RandevuKlinikSorgulamaObjTalep);
            return result;
        }

        public class KurumTaslakCetvelSilmeSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumTaslakCetvelSilmeTalepType KurumTaslakCetvelSilmeTalep
            {
                get;
                set;
            }
        }

        public KurumTaslakCetvelSilmeCevapType KurumTaslakCetvelSilmeSync(KurumTaslakCetvelSilmeSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumTaslakCetvelSilmeSync(input.siteID, input.KurumTaslakCetvelSilmeTalep);
            return result;
        }

        public class KurumKesinCetvelSilmeSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumKesinCetvelSilmeTalepType KurumKesinCetvelSilmeTalep
            {
                get;
                set;
            }
        }

        public KurumKesinCetvelSilmeCevapType KurumKesinCetvelSilmeSync(KurumKesinCetvelSilmeSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumKesinCetvelSilmeSync(input.siteID, input.KurumKesinCetvelSilmeTalep);
            return result;
        }

        public class RandevuIptalSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public RandevuIptalTalepType RandevuIptalTalep
            {
                get;
                set;
            }
        }

        public RandevuIptalCevapType RandevuIptalSync(RandevuIptalSyncInput input)
        {
            var result = MHRSServis.WebMethods.RandevuIptalSync(input.siteID, input.RandevuIptalTalep);
            return result;
        }

        public class KurumRandevuSorgulamaObjSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumRandevuSorgulamaTalepType KurumRandevuSorgulamaTalep
            {
                get;
                set;
            }
        }

        public KurumRandevuSorgulamaObjCevapType KurumRandevuSorgulamaObjSync(KurumRandevuSorgulamaObjSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumRandevuSorgulamaObjSync(input.siteID, input.KurumRandevuSorgulamaTalep);
            return result;
        }

        public class KurumIstisnaEklemeSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumIstisnaEklemeTalepType KurumIstisnaEklemeTalep
            {
                get;
                set;
            }
        }

        public KurumIstisnaEklemeCevapType KurumIstisnaEklemeSync(KurumIstisnaEklemeSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumIstisnaEklemeSync(input.siteID, input.KurumIstisnaEklemeTalep);
            return result;
        }

        public class KurumIstisnaSilmeSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumIstisnaSilmeTalepType KurumIstisnaSilmeTalep
            {
                get;
                set;
            }
        }

        public KurumIstisnaSilmeCevapType KurumIstisnaSilmeSync(KurumIstisnaSilmeSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumIstisnaSilmeSync(input.siteID, input.KurumIstisnaSilmeTalep);
            return result;
        }

        public class KurumIstisnaSorgulamaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumIstisnaSorgulamaTalepType KurumIstisnaSorgulamaTalep
            {
                get;
                set;
            }
        }

        public KurumIstisnaSorgulamaCevapType KurumIstisnaSorgulamaSync(KurumIstisnaSorgulamaSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumIstisnaSorgulamaSync(input.siteID, input.KurumIstisnaSorgulamaTalep);
            return result;
        }

        public class KurumTaslakCetvelSorgulamaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumTaslakCetvelSorgulamaTalepType KurumTaslakCetvelSorgulamaTalep
            {
                get;
                set;
            }
        }

        public KurumTaslakCetvelSorgulamaCevapType KurumTaslakCetvelSorgulamaSync(KurumTaslakCetvelSorgulamaSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumTaslakCetvelSorgulamaSync(input.siteID, input.KurumTaslakCetvelSorgulamaTalep);
            return result;
        }

        public class KurumKesinCetvelSorgulamaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumKesinCetvelSorgulamaTalepType KurumKesinCetvelSorgulamaTalep
            {
                get;
                set;
            }
        }

        public KurumKesinCetvelSorgulamaCevapType KurumKesinCetvelSorgulamaSync(KurumKesinCetvelSorgulamaSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumKesinCetvelSorgulamaSync(input.siteID, input.KurumKesinCetvelSorgulamaTalep);
            return result;
        }

        public class YesilListeVatandasEklemeSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public YesilListeVatandasEklemeTalepType YesilListeVatandasEklemeTalep
            {
                get;
                set;
            }
        }

        public YesilListeVatandasEklemeCevapType YesilListeVatandasEklemeSync(YesilListeVatandasEklemeSyncInput input)
        {
            var result = MHRSServis.WebMethods.YesilListeVatandasEklemeSync(input.siteID, input.YesilListeVatandasEklemeTalep);
            return result;
        }

        public class YesilListeVatandasSorgulamaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public YesilListeVatandasSorgulamaTalepType YesilListeVatandasSorgulamaTalep
            {
                get;
                set;
            }
        }

        public YesilListeVatandasSorgulamaCevapType YesilListeVatandasSorgulamaSync(YesilListeVatandasSorgulamaSyncInput input)
        {
            var result = MHRSServis.WebMethods.YesilListeVatandasSorgulamaSync(input.siteID, input.YesilListeVatandasSorgulamaTalep);
            return result;
        }

        public class YesilListeVatandasOnaylamaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public YesilListeVatandasOnaylamaTalepType YesilListeVatandasOnaylamaTalep
            {
                get;
                set;
            }
        }

        public YesilListeVatandasOnaylamaCevapType YesilListeVatandasOnaylamaSync(YesilListeVatandasOnaylamaSyncInput input)
        {
            var result = MHRSServis.WebMethods.YesilListeVatandasOnaylamaSync(input.siteID, input.YesilListeVatandasOnaylamaTalep);
            return result;
        }

        public class KurumAltKlinikSorgulamaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumAltKlinikSorgulamaTalepType KurumAltKlinikSorgulamaTalep
            {
                get;
                set;
            }
        }

        public KurumAltKlinikSorgulamaCevapType KurumAltKlinikSorgulamaSync(KurumAltKlinikSorgulamaSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumAltKlinikSorgulamaSync(input.siteID, input.KurumAltKlinikSorgulamaTalep);
            return result;
        }

        public class KurumKlinikSorgulamaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumKlinikSorgulamaTalepType KurumKlinikSorgulamaTalep
            {
                get;
                set;
            }
        }

        public KurumKlinikSorgulamaCevapType KurumKlinikSorgulamaSync(KurumKlinikSorgulamaSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumKlinikSorgulamaSync(input.siteID, input.KurumKlinikSorgulamaTalep);
            return result;
        }

        public class KurumAltKlinikEklemeSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumAltKlinikEklemeTalepType KurumAltKlinikEklemeTalep
            {
                get;
                set;
            }
        }

        public KurumAltKlinikEklemeCevapType KurumAltKlinikEklemeSync(KurumAltKlinikEklemeSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumAltKlinikEklemeSync(input.siteID, input.KurumAltKlinikEklemeTalep);
            return result;
        }

        public class KurumKlinikEklemeSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumKlinikEklemeTalepType KurumKlinikEklemeTalep
            {
                get;
                set;
            }
        }

        public KurumKlinikEklemeCevapType KurumKlinikEklemeSync(KurumKlinikEklemeSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumKlinikEklemeSync(input.siteID, input.KurumKlinikEklemeTalep);
            return result;
        }

        public class KurumHekimEklemeSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KurumHekimEklemeTalepType KurumHekimEklemeTalep
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public KurumHekimEklemeCevapType KurumHekimEklemeSync(KurumHekimEklemeSyncInput input)
        {
            var result = MHRSServis.WebMethods.KurumHekimEklemeSync(input.siteID, input.KurumHekimEklemeTalep);
            return result;
        }
    }
}