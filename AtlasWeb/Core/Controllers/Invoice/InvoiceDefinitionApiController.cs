using Infrastructure.Filters;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using static TTObjectClasses.SubEpisodeProtocol;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers.Invoice
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class InvoiceDefinitionApiController : Controller
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Medula_Raporlari_Yeni, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetTedaviTuru()
        {
            listboxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<TedaviTuru>().ToArray();
                var query =
                    from i in ttList
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.tedaviTuruKodu.Trim() + ' ' + i.tedaviTuruAdi.Trim(), Code = i.tedaviTuruKodu.Trim() };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Medula_Raporlari_Yeni, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetinvoiceControlNQLDef()
        {
            listboxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<InvoiceControlNQLDef>(" ISACTIVE = 1 ").OrderBy(x => x.OrderNo).ToArray();
                var query =
                    from i in ttList
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.Name.Trim(), Code = i.NQL.Trim() };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }
            //listboxObject[] result = new listboxObject[12];
            //result[0] = new listboxObject();
            //result[0].Code = "ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND INVOICEINCLUSION = 1).SUM(UNITPRICE) > 0 AND ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED ).SUM(MEDULAPRICE) = 0 ";
            //result[0].ObjectID = new Guid("b4a221b6-b5a1-41c9-8f26-acd29955dab5");
            //result[0].Name = "SGK hastaları için ücret dönmeyen takipler";
            //result[1] = new listboxObject();
            //result[1].Code = "ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND SUBACTIONPROCEDURE.PROCEDUREOBJECT.MEDULAPROCEDURETYPE = 1 AND INVOICEINCLUSION = 1 AND MEDULAPRICE = 0).EXISTS() ";
            //result[1].ObjectID = new Guid("b4a221b6-b5a1-41c9-8f26-acd29955dab6");
            //result[1].Name = "Muayene hizmetine tutar dönmeyenler";
            //result[2] = new listboxObject();
            //result[2].Code = "ACCOUNTTRANSACTIONS(CURRENTSTATE = STATES.MEDULADONTSEND AND SUBACTIONPROCEDURE.PROCEDUREOBJECT.SUTAPPENDIX = 1 ).EXISTS() ";
            //result[2].ObjectID = new Guid("b4a221b6-b5a1-41c9-8f26-acd29955dab7");
            //result[2].Name = "Ek2A2 hizmetine ücret dönmeyenler (Gönderilmeyecek Statüsünde Olanlar)";
            //result[3] = new listboxObject();
            //result[3].Code = "ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.MEDULADONTSEND AND CURRENTSTATE <> STATES.CANCELLED AND SUBACTIONPROCEDURE.PROCEDUREOBJECT.SUTAPPENDIX = 1 AND MEDULAPRICE = 0 ).EXISTS() ";
            //result[3].ObjectID = new Guid("b4a221b6-b5a1-41c9-8f26-acd29955dab8");
            //result[3].Name = "Ek2A2 hizmetine ücret dönmeyenler";
            //result[4] = new listboxObject();
            //result[4].Code = "ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND INVOICEINCLUSION = 1 AND MEDULAPRICE = 0 ).EXISTS() ";
            //result[4].ObjectID = new Guid("b4a221b6-b5a1-41c9-8f26-acd29955dab9");
            //result[4].Name = "Fatura kapsamında olup ücret dönmeyenler hizmetler";
            //result[5] = new listboxObject();
            //result[5].Code = "ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED AND INVOICEINCLUSION = 1).SUM(UNITPRICE*AMOUNT) >   ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED ).SUM(MEDULAPRICE) ";
            //result[5].ObjectID = new Guid("b4a221b6-b5a1-41c9-8f26-acd29955dac1");
            //result[5].Name = "Takibi eksik faturalanan dosyalar";

            //result[6] = new listboxObject();
            //result[6].Code = "ACCOUNTTRANSACTIONS(CURRENTSTATE = STATES.MEDULADONTSEND AND SUBACTIONPROCEDURE.PROCEDUREOBJECT.SUTAPPENDIX = 3 ).EXISTS() ";
            //result[6].ObjectID = new Guid("b4a221b6-b5a1-41c9-8f26-acd29955dac2");
            //result[6].Name = "Ek2C hizmetine ücret dönmeyenler (Gönderilmeyecek Statüsünde Olanlar)";
            //result[7] = new listboxObject();
            //result[7].Code = "ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.MEDULADONTSEND AND CURRENTSTATE <> STATES.CANCELLED AND SUBACTIONPROCEDURE.PROCEDUREOBJECT.SUTAPPENDIX = 3 AND MEDULAPRICE = 0 ).EXISTS() ";
            //result[7].ObjectID = new Guid("b4a221b6-b5a1-41c9-8f26-acd29955dac3");
            //result[7].Name = "Ek2C hizmetine ücret dönmeyenler";

            //result[8] = new listboxObject();
            //result[8].Code = "ACCOUNTTRANSACTIONS(CURRENTSTATE = STATES.MEDULADONTSEND AND SUBACTIONPROCEDURE.PROCEDUREOBJECT.MEDULAPROCEDURETYPE = 10 ).EXISTS() ";
            //result[8].ObjectID = new Guid("b4a221b6-b5a1-41c9-8f26-acd29955dac2");
            //result[8].Name = "Kan Ürününe ücret dönmeyenler (Gönderilmeyecek Statüsünde Olanlar)";
            //result[9] = new listboxObject();
            //result[9].Code = "ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.MEDULADONTSEND AND CURRENTSTATE <> STATES.CANCELLED AND SUBACTIONPROCEDURE.PROCEDUREOBJECT.MEDULAPROCEDURETYPE = 10 AND MEDULAPRICE = 0 ).EXISTS() ";
            //result[9].ObjectID = new Guid("b4a221b6-b5a1-41c9-8f26-acd29955dac3");
            //result[9].Name = "Kan Ürününe hizmetine ücret dönmeyenler";

            //result[10] = new listboxObject();
            //result[10].Code = "ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED  AND SUBACTIONMATERIAL.MATERIAL.OBJECTDEFNAME NOT IN ('DRUGDEFINITION','MAGISTRALPREPARATIONDEFINITION') AND UNITPRICE <= 3 ).EXISTS() ";
            //result[10].ObjectID = new Guid("b4a221b6-b5a1-41c9-8f26-acd29955dac2");
            //result[10].Name = "X liranın altında gönderilmeyecek durumunda MALZEMESİ olan takipler";
            //result[11] = new listboxObject();
            //result[11].Code = "ACCOUNTTRANSACTIONS(CURRENTSTATE <> STATES.CANCELLED  AND SUBACTIONMATERIAL.MATERIAL.OBJECTDEFNAME   IN ('DRUGDEFINITION','MAGISTRALPREPARATIONDEFINITION') AND UNITPRICE <= 3 ).EXISTS() ";
            //result[11].ObjectID = new Guid("b4a221b6-b5a1-41c9-8f26-acd29955dac3");
            //result[11].Name = "X liranın altında gönderilmeyecek durumunda İLACI olan takipler";


            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Medula_Raporlari_Yeni, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public List<listboxObject> GetProcedureStateDef()
        {
            List<listboxObject> result = new List<listboxObject>();

            string objectDefNames = TTObjectClasses.SystemParameter.GetParameterValue("INVOICEBLOCKINGOBJECTDEFNAMES", "");
            if (!string.IsNullOrWhiteSpace(objectDefNames))
            {
                objectDefNames = objectDefNames.Replace("\n", String.Empty);
                objectDefNames = objectDefNames.Replace("\r", String.Empty);
                objectDefNames = objectDefNames.Replace("\t", String.Empty);
                objectDefNames = objectDefNames.Trim().ToUpperInvariant();
                List<string> objectDefNameList = objectDefNames.Split(',').ToList();

                foreach (TTObjectDef objDef in TTObjectDefManager.Instance.ObjectDefs.Values.Where(x => objectDefNameList.Contains(x.Name.ToUpperInvariant())).OrderBy(x => x.DisplayText))
                {
                    foreach (TTObjectStateDef stateDef in objDef.StateDefs.Values.OrderBy(x => x.DisplayText))
                        if (stateDef.Status != StateStatusEnum.Cancelled && stateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
                            result.Add(new listboxObject { ObjectID = stateDef.StateDefID, Name = (objDef.DisplayText + " - " + stateDef.DisplayText).Trim() });
                }
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetDoctor()
        {
            listboxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = ResUser.ClinicDoctorListNQL(objectContext, " AND ISACTIVE = 1");
                var query =
                    from i in ttList
                    select new listboxObject
                    {
                        ObjectID = i.ObjectID,
                        Name = i.Name,
                        Code = "" //Tescil no olursa gelecek.
                    };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetSection()
        {
            listboxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = ResSection.GetAllRessectionForSubepisodeNQL(objectContext, " AND ISACTIVE = 1");
                var query =
                    from i in ttList
                    select new listboxObject
                    {
                        ObjectID = i.ObjectID,
                        Name = i.Name,
                        Code = "" //Tescil no olursa gelecek.
                    };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetProvizyonTipi()
        {
            listboxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<ProvizyonTipi>().ToArray();
                var query =
                    from i in ttList
                    orderby i.provizyonTipiKodu
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.provizyonTipiKodu.Trim() + ' ' + i.provizyonTipiAdi.Trim(), Code = i.provizyonTipiKodu.Trim() };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetTedaviTipi()
        {
            listboxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<TedaviTipi>().ToArray();
                var query =
                    from i in ttList
                    orderby Convert.ToInt32(i.tedaviTipiKodu)
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.tedaviTipiKodu.Trim() + ' ' + i.tedaviTipiAdi.Trim(), Code = i.tedaviTipiKodu.Trim() };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetTakipTipi()
        {
            listboxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<TakipTipi>().ToArray();
                var query =
                    from i in ttList
                    orderby i.takipTipiKodu
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.takipTipiKodu.Trim() + ' ' + i.takipTipiAdi.Trim(), Code = i.takipTipiKodu.Trim() };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetBrans()
        {
            listboxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<SpecialityDefinition>().ToArray();
                var query =
                    from i in ttList
                    orderby i.Name
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.Code.Trim() + ' ' + i.Name.Trim(), Code = i.Code.Trim() };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetDevredilenKurum()
        {
            listboxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<DevredilenKurum>().ToArray();
                var query =
                    from i in ttList
                    orderby Convert.ToInt32(i.devredilenKurumKodu)
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.devredilenKurumKodu.Trim() + ' ' + i.devredilenKurumAdi.Trim(), Code = i.devredilenKurumKodu.Trim() };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetTriage()
        {
            listboxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<SKRSTRIAJKODU>().ToArray();
                var query =
                    from i in ttList
                    orderby Convert.ToInt32(i.KODU)
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.KODU.Trim() + ' ' + i.ADI.Trim(), Code = i.KODU.Trim() };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetTaburcuKodu()
        {
            listboxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<TaburcuKodu>().ToArray();
                var query =
                    from i in ttList
                    orderby Convert.ToInt32(i.taburcuKodu)
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.taburcuKodu.Trim() + ' ' + i.taburcuKoduAdi.Trim(), Code = i.taburcuKodu.Trim() };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetIstisnaiHal()
        {
            listboxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<IstisnaiHal>().ToArray();
                var query =
                    from i in ttList
                    orderby i.Kodu
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.Kodu.ToString() + ' ' + i.Adi.Trim(), Code = i.Kodu.ToString() };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetSigortaliTuru()
        {
            listboxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<SigortaliTuru>().ToArray();
                var query =
                    from i in ttList
                    orderby Convert.ToInt32(i.sigortaliTuruKodu)
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.sigortaliTuruKodu.Trim() + ' ' + i.sigortaliTuruAdi.Trim(), Code = i.sigortaliTuruKodu.Trim() };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetOzelDurum()
        {
            listboxObject[] result;
            List<listboxObject> ozelDurumList = new List<listboxObject>();
            ozelDurumList.Add(new listboxObject { ObjectID = Guid.Empty, Name = "", Code = "" });
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<OzelDurum>().ToArray();
                var query =
                    from i in ttList
                    orderby i.ozelDurumKodu
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.ozelDurumKodu.Trim() + ' ' + i.ozelDurumAdi.Trim(), Code = i.ozelDurumKodu.Trim() };
                ozelDurumList.AddRange(query.ToList());
                result = ozelDurumList.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetKesi()
        {
            listboxObject[] result;
            List<listboxObject> kesiList = new List<listboxObject>();
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<AyniFarkliKesi>().ToArray();
                var query =
                    from i in ttList
                    orderby i.ayniFarkliKesiKodu
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.ayniFarkliKesiKodu.Trim() + ' ' + i.ayniFarkliKesiAdi.Trim(), Code = i.ayniFarkliKesiKodu.Trim() };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }
            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public listboxObject[] GetInvoiceUsers()
        {
            listboxObject[] result;
            List<listboxObject> kesiList = new List<listboxObject>();
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList  = objectContext.QueryObjects<ResUser>(" USERTYPE = 267").ToArray();
                var query =
                    from i in ttList
                    orderby i.Name
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.Name + ' ' , Code = i.LogonName };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }
            return result;
        }


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Kurum_Degistirme)]
        public listboxObject[] GetPayer()
        {
            listboxObject[] result;
            List<listboxObject> payerList = new List<listboxObject>();
            payerList.Add(new listboxObject { ObjectID = Guid.Empty, Name = "", Code = "" });
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<PayerDefinition>().Where(x => x.IsActive == true).ToArray().OrderBy(x => x.Code);
                var query =
                    from i in ttList
                    orderby i.Name
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.Code.HasValue? i.Code.Value + " - " + i.Name:i.Name, Code = ((int)i.Type.PayerType).ToString() };
                payerList.AddRange(query.ToList());
                result = payerList.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma, TTRoleNames.Hasta_Kabul_Kurum_Degistirme)]
        public listboxObject[] GetProtocol(Guid payerObjectID)
        {
            listboxObject[] result;
            List<listboxObject> protocolList = new List<listboxObject>();
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = PayerProtocolDefinition.GetByPayer(objectContext, payerObjectID);
                var query =
                    from i in ttList
                    orderby i.Protocolname
                    select new listboxObject { ObjectID = i.Protocolobjectid, Name = i.Protocolname, Code = i.Protocolcode };
                protocolList.AddRange(query.ToList());
                result = protocolList.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Tanimlari_Okuma)]
        public listboxObject[] GetTaburcuTipi()
        {
            listboxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = objectContext.QueryObjects<DischargeTypeDefinition>("ISACTIVE = 1").ToArray();
                var query =
                    from i in ttList
                    orderby i.Name
                    select new listboxObject { ObjectID = i.ObjectID, Name = i.Name };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

    }
}