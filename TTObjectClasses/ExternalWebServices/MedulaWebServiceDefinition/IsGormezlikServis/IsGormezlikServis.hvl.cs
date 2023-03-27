
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IsGormezlikServis")] 

    public  partial class IsGormezlikServis : TTObject
    {
        public class IsGormezlikServisList : TTObjectCollection<IsGormezlikServis> { }
                    
        public class ChildIsGormezlikServisCollection : TTObject.TTChildObjectCollection<IsGormezlikServis>
        {
            public ChildIsGormezlikServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIsGormezlikServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static CevapDTO mevcutRaporGetirSync(Guid siteID, string tcKimlikNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (CevapDTO) TTMessageFactory.SyncCall(siteID, new Guid("c73043bb-97de-41fa-b790-038bb3af8709"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IsGormezlikServis+WebMethods, TTObjectClasses","mevcutRaporGetirSync_ServerSide", tcKimlikNo);
            }


            private static CevapDTO mevcutRaporGetirSync_ServerSide(string tcKimlikNo)
            {

#region mevcutRaporGetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IsGormezlikServis";
                    header.ServiceId = "2cddf4f4-6277-445e-9772-8770398527b2";
                    header.MethodName = "mevcutRaporGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tcKimlikNo", (object)tcKimlikNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    CevapDTO cevap = default(CevapDTO);
                    cevap = (CevapDTO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion mevcutRaporGetirSync_Body

            }

            public static CevapDTO rapor2VerIptalSync(Guid siteID, string rtn)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (CevapDTO) TTMessageFactory.SyncCall(siteID, new Guid("a286002b-a505-42e6-8ec5-b6cd72fbec8e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IsGormezlikServis+WebMethods, TTObjectClasses","rapor2VerIptalSync_ServerSide", rtn);
            }


            private static CevapDTO rapor2VerIptalSync_ServerSide(string rtn)
            {

#region rapor2VerIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IsGormezlikServis";
                    header.ServiceId = "2cddf4f4-6277-445e-9772-8770398527b2";
                    header.MethodName = "rapor2VerIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("rtn", (object)rtn),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    CevapDTO cevap = default(CevapDTO);
                    cevap = (CevapDTO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion rapor2VerIptalSync_Body

            }

            public static CevapDTO rapor2VerSync(Guid siteID, string rtn, int rsn, string rapordurum, string duzenlemeTuru)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (CevapDTO) TTMessageFactory.SyncCall(siteID, new Guid("8bfab21f-e03e-496d-97c5-ea354cfe4f58"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IsGormezlikServis+WebMethods, TTObjectClasses","rapor2VerSync_ServerSide", rtn, rsn, rapordurum, duzenlemeTuru);
            }


            private static CevapDTO rapor2VerSync_ServerSide(string rtn, int rsn, string rapordurum, string duzenlemeTuru)
            {

#region rapor2VerSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IsGormezlikServis";
                    header.ServiceId = "2cddf4f4-6277-445e-9772-8770398527b2";
                    header.MethodName = "rapor2Ver";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("rtn", (object)rtn),
                        Tuple.Create("rsn", (object)rsn),
                        Tuple.Create("rapordurum", (object)rapordurum),
                        Tuple.Create("duzenlemeTuru", (object)duzenlemeTuru),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    CevapDTO cevap = default(CevapDTO);
                    cevap = (CevapDTO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion rapor2VerSync_Body

            }

            public static CevapDTO raporGetirSync(Guid siteID, string raporTakipNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (CevapDTO) TTMessageFactory.SyncCall(siteID, new Guid("88eab206-4dec-4e88-9c54-b65ec3dd698d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IsGormezlikServis+WebMethods, TTObjectClasses","raporGetirSync_ServerSide", raporTakipNo);
            }


            private static CevapDTO raporGetirSync_ServerSide(string raporTakipNo)
            {

#region raporGetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IsGormezlikServis";
                    header.ServiceId = "2cddf4f4-6277-445e-9772-8770398527b2";
                    header.MethodName = "raporGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("raporTakipNo", (object)raporTakipNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    CevapDTO cevap = default(CevapDTO);
                    cevap = (CevapDTO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion raporGetirSync_Body

            }

            public static CevapDTO raporGuncelleSync(Guid siteID, IsgoremezlikRaporDVO isgoremezlikRaporDVO)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (CevapDTO) TTMessageFactory.SyncCall(siteID, new Guid("1ee4e616-e734-492a-9e2c-edfd85f47c06"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IsGormezlikServis+WebMethods, TTObjectClasses","raporGuncelleSync_ServerSide", isgoremezlikRaporDVO);
            }


            private static CevapDTO raporGuncelleSync_ServerSide(IsgoremezlikRaporDVO isgoremezlikRaporDVO)
            {

#region raporGuncelleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IsGormezlikServis";
                    header.ServiceId = "2cddf4f4-6277-445e-9772-8770398527b2";
                    header.MethodName = "raporGuncelle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("isgoremezlikRaporDVO", (object)isgoremezlikRaporDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    CevapDTO cevap = default(CevapDTO);
                    cevap = (CevapDTO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion raporGuncelleSync_Body

            }

            public static CevapDTO raporKaydetSync(Guid siteID, IsgoremezlikRaporDVO isgoremezlikRaporDVO)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (CevapDTO) TTMessageFactory.SyncCall(siteID, new Guid("ee7da5ea-036f-4c3d-b61e-f596ca912fdf"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IsGormezlikServis+WebMethods, TTObjectClasses","raporKaydetSync_ServerSide", isgoremezlikRaporDVO);
            }


            private static CevapDTO raporKaydetSync_ServerSide(IsgoremezlikRaporDVO isgoremezlikRaporDVO)
            {

#region raporKaydetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IsGormezlikServis";
                    header.ServiceId = "2cddf4f4-6277-445e-9772-8770398527b2";
                    header.MethodName = "raporKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("isgoremezlikRaporDVO", (object)isgoremezlikRaporDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    CevapDTO cevap = default(CevapDTO);
                    cevap = (CevapDTO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion raporKaydetSync_Body

            }

            public static CevapDTO raporListeGetirSync(Guid siteID, string date1, string tesisKodu, string pass)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (CevapDTO) TTMessageFactory.SyncCall(siteID, new Guid("9e1c6c78-3121-4615-b3b5-3f18a8ab1e87"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IsGormezlikServis+WebMethods, TTObjectClasses","raporListeGetirSync_ServerSide", date1, tesisKodu, pass);
            }


            private static CevapDTO raporListeGetirSync_ServerSide(string date1, string tesisKodu, string pass)
            {

#region raporListeGetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IsGormezlikServis";
                    header.ServiceId = "2cddf4f4-6277-445e-9772-8770398527b2";
                    header.MethodName = "raporListeGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("date1", (object)date1),
                        Tuple.Create("tesisKodu", (object)tesisKodu),
                        Tuple.Create("pass", (object)pass),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    CevapDTO cevap = default(CevapDTO);
                    cevap = (CevapDTO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion raporListeGetirSync_Body

            }

            public static CevapDTO raporListesiGetirSync(Guid siteID, string tcNo, string tesisKodu)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (CevapDTO) TTMessageFactory.SyncCall(siteID, new Guid("99f900a6-14e6-4fd8-9f8d-17cea5affef0"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IsGormezlikServis+WebMethods, TTObjectClasses","raporListesiGetirSync_ServerSide", tcNo, tesisKodu);
            }


            private static CevapDTO raporListesiGetirSync_ServerSide(string tcNo, string tesisKodu)
            {

#region raporListesiGetirSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IsGormezlikServis";
                    header.ServiceId = "2cddf4f4-6277-445e-9772-8770398527b2";
                    header.MethodName = "raporListesiGetir";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("tcNo", (object)tcNo),
                        Tuple.Create("tesisKodu", (object)tesisKodu),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    CevapDTO cevap = default(CevapDTO);
                    cevap = (CevapDTO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion raporListesiGetirSync_Body

            }

            public static CevapDTO raporOnaylaSync(Guid siteID, string raporTakipNo, string raporSiraNo, string tesisKodu, string bashekimTcNo, string pass)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (CevapDTO) TTMessageFactory.SyncCall(siteID, new Guid("7ead3382-1b5b-4dfb-87d7-2459a41c53eb"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IsGormezlikServis+WebMethods, TTObjectClasses","raporOnaylaSync_ServerSide", raporTakipNo, raporSiraNo, tesisKodu, bashekimTcNo, pass);
            }


            private static CevapDTO raporOnaylaSync_ServerSide(string raporTakipNo, string raporSiraNo, string tesisKodu, string bashekimTcNo, string pass)
            {

#region raporOnaylaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IsGormezlikServis";
                    header.ServiceId = "2cddf4f4-6277-445e-9772-8770398527b2";
                    header.MethodName = "raporOnayla";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("raporTakipNo", (object)raporTakipNo),
                        Tuple.Create("raporSiraNo", (object)raporSiraNo),
                        Tuple.Create("tesisKodu", (object)tesisKodu),
                        Tuple.Create("bashekimTcNo", (object)bashekimTcNo),
                        Tuple.Create("pass", (object)pass),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    CevapDTO cevap = default(CevapDTO);
                    cevap = (CevapDTO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion raporOnaylaSync_Body

            }

            public static CevapDTO raporOnSecimSync(Guid siteID, IsgoremezlikRaporDVO isgoremezlikRaporDVO)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (CevapDTO) TTMessageFactory.SyncCall(siteID, new Guid("c3121e9f-639d-4d39-bfb9-2792ca496bdc"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IsGormezlikServis+WebMethods, TTObjectClasses","raporOnSecimSync_ServerSide", isgoremezlikRaporDVO);
            }


            private static CevapDTO raporOnSecimSync_ServerSide(IsgoremezlikRaporDVO isgoremezlikRaporDVO)
            {

#region raporOnSecimSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IsGormezlikServis";
                    header.ServiceId = "2cddf4f4-6277-445e-9772-8770398527b2";
                    header.MethodName = "raporOnSecim";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("isgoremezlikRaporDVO", (object)isgoremezlikRaporDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    CevapDTO cevap = default(CevapDTO);
                    cevap = (CevapDTO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion raporOnSecimSync_Body

            }

            public static CevapDTO raporSilSync(Guid siteID, string rtn, int rsn, int vaka, string tesisKodu)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (CevapDTO) TTMessageFactory.SyncCall(siteID, new Guid("b50785cd-2984-45cf-94fa-40a008d5b7a1"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IsGormezlikServis+WebMethods, TTObjectClasses","raporSilSync_ServerSide", rtn, rsn, vaka, tesisKodu);
            }


            private static CevapDTO raporSilSync_ServerSide(string rtn, int rsn, int vaka, string tesisKodu)
            {

#region raporSilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IsGormezlikServis";
                    header.ServiceId = "2cddf4f4-6277-445e-9772-8770398527b2";
                    header.MethodName = "raporSil";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("rtn", (object)rtn),
                        Tuple.Create("rsn", (object)rsn),
                        Tuple.Create("vaka", (object)vaka),
                        Tuple.Create("tesisKodu", (object)tesisKodu),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    CevapDTO cevap = default(CevapDTO);
                    cevap = (CevapDTO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion raporSilSync_Body

            }

            public static CevapDTO saglikKurulunaSevketSync(Guid siteID, string rtn, int rsn, string rapordurum)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (CevapDTO) TTMessageFactory.SyncCall(siteID, new Guid("3329d8c0-e2cf-4ae1-8587-2dfa98db4862"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IsGormezlikServis+WebMethods, TTObjectClasses","saglikKurulunaSevketSync_ServerSide", rtn, rsn, rapordurum);
            }


            private static CevapDTO saglikKurulunaSevketSync_ServerSide(string rtn, int rsn, string rapordurum)
            {

#region saglikKurulunaSevketSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IsGormezlikServis";
                    header.ServiceId = "2cddf4f4-6277-445e-9772-8770398527b2";
                    header.MethodName = "saglikKurulunaSevket";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("rtn", (object)rtn),
                        Tuple.Create("rsn", (object)rsn),
                        Tuple.Create("rapordurum", (object)rapordurum),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    CevapDTO cevap = default(CevapDTO);
                    cevap = (CevapDTO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion saglikKurulunaSevketSync_Body

            }

            public static CevapDTO saglikKurulunaSevkIptalSync(Guid siteID, string rtn)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (CevapDTO) TTMessageFactory.SyncCall(siteID, new Guid("ea180f74-105d-4c82-a05f-7e3470d60627"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.IsGormezlikServis+WebMethods, TTObjectClasses","saglikKurulunaSevkIptalSync_ServerSide", rtn);
            }


            private static CevapDTO saglikKurulunaSevkIptalSync_ServerSide(string rtn)
            {

#region saglikKurulunaSevkIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.IsGormezlikServis";
                    header.ServiceId = "2cddf4f4-6277-445e-9772-8770398527b2";
                    header.MethodName = "saglikKurulunaSevkIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("rtn", (object)rtn),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    CevapDTO cevap = default(CevapDTO);
                    cevap = (CevapDTO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion saglikKurulunaSevkIptalSync_Body

            }

        }
                    
        protected IsGormezlikServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IsGormezlikServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IsGormezlikServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IsGormezlikServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IsGormezlikServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ISGORMEZLIKSERVIS", dataRow) { }
        protected IsGormezlikServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ISGORMEZLIKSERVIS", dataRow, isImported) { }
        public IsGormezlikServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IsGormezlikServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IsGormezlikServis() : base() { }

    }
}