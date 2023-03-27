
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MHRSServis")] 

    public  partial class MHRSServis : TTObject
    {
        public class MHRSServisList : TTObjectCollection<MHRSServis> { }
                    
        public class ChildMHRSServisCollection : TTObject.TTChildObjectCollection<MHRSServis>
        {
            public ChildMHRSServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMHRSServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static KurumAltKlinikEklemeCevapType KurumAltKlinikEklemeSync(Guid siteID, KurumAltKlinikEklemeTalepType KurumAltKlinikEklemeTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumAltKlinikEklemeCevapType) TTMessageFactory.SyncCall(siteID, new Guid("d4d36586-cce2-4bee-b844-cfe4e18b8906"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumAltKlinikEklemeSync_ServerSide", KurumAltKlinikEklemeTalep);
            }


            private static KurumAltKlinikEklemeCevapType KurumAltKlinikEklemeSync_ServerSide(KurumAltKlinikEklemeTalepType KurumAltKlinikEklemeTalep)
            {

#region KurumAltKlinikEklemeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumAltKlinikEkleme";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumAltKlinikEklemeTalep", (object)KurumAltKlinikEklemeTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumAltKlinikEklemeCevapType cevap = default(KurumAltKlinikEklemeCevapType);
                    cevap = (KurumAltKlinikEklemeCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumAltKlinikEklemeSync_Body

            }

            public static KurumAltKlinikSorgulamaCevapType KurumAltKlinikSorgulamaSync(Guid siteID, KurumAltKlinikSorgulamaTalepType KurumAltKlinikSorgulamaTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumAltKlinikSorgulamaCevapType) TTMessageFactory.SyncCall(siteID, new Guid("a1d9dfc4-ed00-4b4b-898c-270d48929ff0"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumAltKlinikSorgulamaSync_ServerSide", KurumAltKlinikSorgulamaTalep);
            }


            private static KurumAltKlinikSorgulamaCevapType KurumAltKlinikSorgulamaSync_ServerSide(KurumAltKlinikSorgulamaTalepType KurumAltKlinikSorgulamaTalep)
            {

#region KurumAltKlinikSorgulamaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumAltKlinikSorgulama";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumAltKlinikSorgulamaTalep", (object)KurumAltKlinikSorgulamaTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumAltKlinikSorgulamaCevapType cevap = default(KurumAltKlinikSorgulamaCevapType);
                    cevap = (KurumAltKlinikSorgulamaCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumAltKlinikSorgulamaSync_Body

            }

            public static KurumHekimEklemeCevapType KurumHekimEklemeSync(Guid siteID, KurumHekimEklemeTalepType KurumHekimEklemeTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumHekimEklemeCevapType) TTMessageFactory.SyncCall(siteID, new Guid("13cb9507-3c8f-44eb-b175-f1eae55ca742"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumHekimEklemeSync_ServerSide", KurumHekimEklemeTalep);
            }


            private static KurumHekimEklemeCevapType KurumHekimEklemeSync_ServerSide(KurumHekimEklemeTalepType KurumHekimEklemeTalep)
            {

#region KurumHekimEklemeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumHekimEkleme";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumHekimEklemeTalep", (object)KurumHekimEklemeTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumHekimEklemeCevapType cevap = default(KurumHekimEklemeCevapType);
                    cevap = (KurumHekimEklemeCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumHekimEklemeSync_Body

            }

            public static KurumIsKuraliEklemeCevapType KurumIsKuraliEklemeSync(Guid siteID, KurumIsKuraliEklemeTalepType KurumIsKuraliEklemeTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumIsKuraliEklemeCevapType) TTMessageFactory.SyncCall(siteID, new Guid("f45a9cd1-c916-4b56-954c-70fb27854f1e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumIsKuraliEklemeSync_ServerSide", KurumIsKuraliEklemeTalep);
            }


            private static KurumIsKuraliEklemeCevapType KurumIsKuraliEklemeSync_ServerSide(KurumIsKuraliEklemeTalepType KurumIsKuraliEklemeTalep)
            {

#region KurumIsKuraliEklemeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumIsKuraliEkleme";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumIsKuraliEklemeTalep", (object)KurumIsKuraliEklemeTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumIsKuraliEklemeCevapType cevap = default(KurumIsKuraliEklemeCevapType);
                    cevap = (KurumIsKuraliEklemeCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumIsKuraliEklemeSync_Body

            }

            public static KurumIsKuraliSilmeCevapType KurumIsKuraliSilmeSync(Guid siteID)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumIsKuraliSilmeCevapType) TTMessageFactory.SyncCall(siteID, new Guid("ec635653-3b8c-4212-be8a-fe9d044308b6"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumIsKuraliSilmeSync_ServerSide");
            }


            private static KurumIsKuraliSilmeCevapType KurumIsKuraliSilmeSync_ServerSide()
            {

#region KurumIsKuraliSilmeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumIsKuraliSilme";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumIsKuraliSilmeCevapType cevap = default(KurumIsKuraliSilmeCevapType);
                    cevap = (KurumIsKuraliSilmeCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumIsKuraliSilmeSync_Body

            }

            public static KurumIsKuraliSorgulamaCevapType KurumIsKuraliSorgulamaSync(Guid siteID)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumIsKuraliSorgulamaCevapType) TTMessageFactory.SyncCall(siteID, new Guid("4e9ff3e3-a459-499f-bcfb-98a91509e9eb"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumIsKuraliSorgulamaSync_ServerSide");
            }


            private static KurumIsKuraliSorgulamaCevapType KurumIsKuraliSorgulamaSync_ServerSide()
            {

#region KurumIsKuraliSorgulamaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumIsKuraliSorgulama";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumIsKuraliSorgulamaCevapType cevap = default(KurumIsKuraliSorgulamaCevapType);
                    cevap = (KurumIsKuraliSorgulamaCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumIsKuraliSorgulamaSync_Body

            }

            public static KurumIstisnaEklemeCevapType KurumIstisnaEklemeSync(Guid siteID, KurumIstisnaEklemeTalepType KurumIstisnaEklemeTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumIstisnaEklemeCevapType) TTMessageFactory.SyncCall(siteID, new Guid("17a4463c-3c20-41f2-b1bb-d11ad5b9dcf7"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumIstisnaEklemeSync_ServerSide", KurumIstisnaEklemeTalep);
            }


            private static KurumIstisnaEklemeCevapType KurumIstisnaEklemeSync_ServerSide(KurumIstisnaEklemeTalepType KurumIstisnaEklemeTalep)
            {

#region KurumIstisnaEklemeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumIstisnaEkleme";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumIstisnaEklemeTalep", (object)KurumIstisnaEklemeTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumIstisnaEklemeCevapType cevap = default(KurumIstisnaEklemeCevapType);
                    cevap = (KurumIstisnaEklemeCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumIstisnaEklemeSync_Body

            }

            public static KurumIstisnaSilmeCevapType KurumIstisnaSilmeSync(Guid siteID, KurumIstisnaSilmeTalepType KurumIstisnaSilmeTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumIstisnaSilmeCevapType) TTMessageFactory.SyncCall(siteID, new Guid("c05f8f01-eab4-448b-a417-2ef3aa950a0d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumIstisnaSilmeSync_ServerSide", KurumIstisnaSilmeTalep);
            }


            private static KurumIstisnaSilmeCevapType KurumIstisnaSilmeSync_ServerSide(KurumIstisnaSilmeTalepType KurumIstisnaSilmeTalep)
            {

#region KurumIstisnaSilmeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumIstisnaSilme";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumIstisnaSilmeTalep", (object)KurumIstisnaSilmeTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumIstisnaSilmeCevapType cevap = default(KurumIstisnaSilmeCevapType);
                    cevap = (KurumIstisnaSilmeCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumIstisnaSilmeSync_Body

            }

            public static KurumIstisnaSorgulamaCevapType KurumIstisnaSorgulamaSync(Guid siteID, KurumIstisnaSorgulamaTalepType KurumIstisnaSorgulamaTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumIstisnaSorgulamaCevapType) TTMessageFactory.SyncCall(siteID, new Guid("9e9823fb-3a1e-4e34-ae6e-a73cffbe813d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumIstisnaSorgulamaSync_ServerSide", KurumIstisnaSorgulamaTalep);
            }


            private static KurumIstisnaSorgulamaCevapType KurumIstisnaSorgulamaSync_ServerSide(KurumIstisnaSorgulamaTalepType KurumIstisnaSorgulamaTalep)
            {

#region KurumIstisnaSorgulamaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumIstisnaSorgulama";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumIstisnaSorgulamaTalep", (object)KurumIstisnaSorgulamaTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumIstisnaSorgulamaCevapType cevap = default(KurumIstisnaSorgulamaCevapType);
                    cevap = (KurumIstisnaSorgulamaCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumIstisnaSorgulamaSync_Body

            }

            public static KurumKesinCetvelSilmeCevapType KurumKesinCetvelSilmeSync(Guid siteID, KurumKesinCetvelSilmeTalepType KurumKesinCetvelSilmeTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumKesinCetvelSilmeCevapType) TTMessageFactory.SyncCall(siteID, new Guid("a85b3cc0-5b15-4f03-815c-98da7ffb9c85"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumKesinCetvelSilmeSync_ServerSide", KurumKesinCetvelSilmeTalep);
            }


            private static KurumKesinCetvelSilmeCevapType KurumKesinCetvelSilmeSync_ServerSide(KurumKesinCetvelSilmeTalepType KurumKesinCetvelSilmeTalep)
            {

#region KurumKesinCetvelSilmeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumKesinCetvelSilme";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumKesinCetvelSilmeTalep", (object)KurumKesinCetvelSilmeTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumKesinCetvelSilmeCevapType cevap = default(KurumKesinCetvelSilmeCevapType);
                    cevap = (KurumKesinCetvelSilmeCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumKesinCetvelSilmeSync_Body

            }

            public static KurumKesinCetvelSorgulamaCevapType KurumKesinCetvelSorgulamaSync(Guid siteID, KurumKesinCetvelSorgulamaTalepType KurumKesinCetvelSorgulamaTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumKesinCetvelSorgulamaCevapType) TTMessageFactory.SyncCall(siteID, new Guid("3cc24dd0-b28e-436e-bcea-1047abfd0b9e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumKesinCetvelSorgulamaSync_ServerSide", KurumKesinCetvelSorgulamaTalep);
            }


            private static KurumKesinCetvelSorgulamaCevapType KurumKesinCetvelSorgulamaSync_ServerSide(KurumKesinCetvelSorgulamaTalepType KurumKesinCetvelSorgulamaTalep)
            {

#region KurumKesinCetvelSorgulamaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumKesinCetvelSorgulama";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumKesinCetvelSorgulamaTalep", (object)KurumKesinCetvelSorgulamaTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumKesinCetvelSorgulamaCevapType cevap = default(KurumKesinCetvelSorgulamaCevapType);
                    cevap = (KurumKesinCetvelSorgulamaCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumKesinCetvelSorgulamaSync_Body

            }

            public static KurumKlinikEklemeCevapType KurumKlinikEklemeSync(Guid siteID, KurumKlinikEklemeTalepType KurumKlinikEklemeTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumKlinikEklemeCevapType) TTMessageFactory.SyncCall(siteID, new Guid("671cde17-25bd-4741-99c5-9ae031fe2991"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumKlinikEklemeSync_ServerSide", KurumKlinikEklemeTalep);
            }


            private static KurumKlinikEklemeCevapType KurumKlinikEklemeSync_ServerSide(KurumKlinikEklemeTalepType KurumKlinikEklemeTalep)
            {

#region KurumKlinikEklemeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumKlinikEkleme";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumKlinikEklemeTalep", (object)KurumKlinikEklemeTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumKlinikEklemeCevapType cevap = default(KurumKlinikEklemeCevapType);
                    cevap = (KurumKlinikEklemeCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumKlinikEklemeSync_Body

            }

            public static KurumKlinikSorgulamaCevapType KurumKlinikSorgulamaSync(Guid siteID, KurumKlinikSorgulamaTalepType KurumKlinikSorgulamaTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumKlinikSorgulamaCevapType) TTMessageFactory.SyncCall(siteID, new Guid("fa5ceafc-8213-46c5-b6ab-b0802e3ef524"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumKlinikSorgulamaSync_ServerSide", KurumKlinikSorgulamaTalep);
            }


            private static KurumKlinikSorgulamaCevapType KurumKlinikSorgulamaSync_ServerSide(KurumKlinikSorgulamaTalepType KurumKlinikSorgulamaTalep)
            {

#region KurumKlinikSorgulamaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumKlinikSorgulama";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumKlinikSorgulamaTalep", (object)KurumKlinikSorgulamaTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumKlinikSorgulamaCevapType cevap = default(KurumKlinikSorgulamaCevapType);
                    cevap = (KurumKlinikSorgulamaCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumKlinikSorgulamaSync_Body

            }

            public static KurumRandevuSorgulamaObjCevapType KurumRandevuSorgulamaObjSync(Guid siteID, KurumRandevuSorgulamaTalepType KurumRandevuSorgulamaTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumRandevuSorgulamaObjCevapType) TTMessageFactory.SyncCall(siteID, new Guid("adac6021-ad67-46c4-a5e0-9842257eda08"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumRandevuSorgulamaObjSync_ServerSide", KurumRandevuSorgulamaTalep);
            }


            private static KurumRandevuSorgulamaObjCevapType KurumRandevuSorgulamaObjSync_ServerSide(KurumRandevuSorgulamaTalepType KurumRandevuSorgulamaTalep)
            {

#region KurumRandevuSorgulamaObjSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumRandevuSorgulamaObj";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumRandevuSorgulamaTalep", (object)KurumRandevuSorgulamaTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumRandevuSorgulamaObjCevapType cevap = default(KurumRandevuSorgulamaObjCevapType);
                    cevap = (KurumRandevuSorgulamaObjCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumRandevuSorgulamaObjSync_Body

            }

            public static KurumTaslakCetvelEklemeCevapType KurumTaslakCetvelEklemeSync(Guid siteID, KurumTaslakCetvelEklemeTalepType KurumTaslakCetvelEklemeTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumTaslakCetvelEklemeCevapType) TTMessageFactory.SyncCall(siteID, new Guid("9fac79f3-656f-41ad-9d40-78faf581473c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumTaslakCetvelEklemeSync_ServerSide", KurumTaslakCetvelEklemeTalep);
            }


            private static KurumTaslakCetvelEklemeCevapType KurumTaslakCetvelEklemeSync_ServerSide(KurumTaslakCetvelEklemeTalepType KurumTaslakCetvelEklemeTalep)
            {

#region KurumTaslakCetvelEklemeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumTaslakCetvelEkleme";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumTaslakCetvelEklemeTalep", (object)KurumTaslakCetvelEklemeTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumTaslakCetvelEklemeCevapType cevap = default(KurumTaslakCetvelEklemeCevapType);
                    cevap = (KurumTaslakCetvelEklemeCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumTaslakCetvelEklemeSync_Body

            }

            public static KurumTaslakCetvelGuncellemeCevapType KurumTaslakCetvelGuncellemeSync(Guid siteID, KurumTaslakCetvelGuncellemeTalepType KurumTaslakCetvelGuncellemeTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumTaslakCetvelGuncellemeCevapType) TTMessageFactory.SyncCall(siteID, new Guid("157e07db-c74b-4c81-b589-2e713c992f3e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumTaslakCetvelGuncellemeSync_ServerSide", KurumTaslakCetvelGuncellemeTalep);
            }


            private static KurumTaslakCetvelGuncellemeCevapType KurumTaslakCetvelGuncellemeSync_ServerSide(KurumTaslakCetvelGuncellemeTalepType KurumTaslakCetvelGuncellemeTalep)
            {

#region KurumTaslakCetvelGuncellemeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumTaslakCetvelGuncelleme";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumTaslakCetvelGuncellemeTalep", (object)KurumTaslakCetvelGuncellemeTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumTaslakCetvelGuncellemeCevapType cevap = default(KurumTaslakCetvelGuncellemeCevapType);
                    cevap = (KurumTaslakCetvelGuncellemeCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumTaslakCetvelGuncellemeSync_Body

            }

            public static KurumTaslakCetvelKesinlestirmeCevapType KurumTaslakCetvelKesinlestirmeSync(Guid siteID, KurumTaslakCetvelKesinlestirmeTalepType KurumTaslakCetvelKesinlestirmeTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumTaslakCetvelKesinlestirmeCevapType) TTMessageFactory.SyncCall(siteID, new Guid("25bf06aa-8ade-4956-a07b-12b9ad9d4180"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumTaslakCetvelKesinlestirmeSync_ServerSide", KurumTaslakCetvelKesinlestirmeTalep);
            }


            private static KurumTaslakCetvelKesinlestirmeCevapType KurumTaslakCetvelKesinlestirmeSync_ServerSide(KurumTaslakCetvelKesinlestirmeTalepType KurumTaslakCetvelKesinlestirmeTalep)
            {

#region KurumTaslakCetvelKesinlestirmeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumTaslakCetvelKesinlestirme";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumTaslakCetvelKesinlestirmeTalep", (object)KurumTaslakCetvelKesinlestirmeTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumTaslakCetvelKesinlestirmeCevapType cevap = default(KurumTaslakCetvelKesinlestirmeCevapType);
                    cevap = (KurumTaslakCetvelKesinlestirmeCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumTaslakCetvelKesinlestirmeSync_Body

            }

            public static KurumTaslakCetvelSilmeCevapType KurumTaslakCetvelSilmeSync(Guid siteID, KurumTaslakCetvelSilmeTalepType KurumTaslakCetvelSilmeTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumTaslakCetvelSilmeCevapType) TTMessageFactory.SyncCall(siteID, new Guid("0c464943-da72-432a-b66e-13a2cf70e83e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumTaslakCetvelSilmeSync_ServerSide", KurumTaslakCetvelSilmeTalep);
            }


            private static KurumTaslakCetvelSilmeCevapType KurumTaslakCetvelSilmeSync_ServerSide(KurumTaslakCetvelSilmeTalepType KurumTaslakCetvelSilmeTalep)
            {

#region KurumTaslakCetvelSilmeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumTaslakCetvelSilme";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumTaslakCetvelSilmeTalep", (object)KurumTaslakCetvelSilmeTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumTaslakCetvelSilmeCevapType cevap = default(KurumTaslakCetvelSilmeCevapType);
                    cevap = (KurumTaslakCetvelSilmeCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumTaslakCetvelSilmeSync_Body

            }

            public static KurumTaslakCetvelSorgulamaCevapType KurumTaslakCetvelSorgulamaSync(Guid siteID, KurumTaslakCetvelSorgulamaTalepType KurumTaslakCetvelSorgulamaTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KurumTaslakCetvelSorgulamaCevapType) TTMessageFactory.SyncCall(siteID, new Guid("bf646ed6-672f-4c1b-b2ae-dc0c9149587a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","KurumTaslakCetvelSorgulamaSync_ServerSide", KurumTaslakCetvelSorgulamaTalep);
            }


            private static KurumTaslakCetvelSorgulamaCevapType KurumTaslakCetvelSorgulamaSync_ServerSide(KurumTaslakCetvelSorgulamaTalepType KurumTaslakCetvelSorgulamaTalep)
            {

#region KurumTaslakCetvelSorgulamaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "KurumTaslakCetvelSorgulama";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("KurumTaslakCetvelSorgulamaTalep", (object)KurumTaslakCetvelSorgulamaTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    KurumTaslakCetvelSorgulamaCevapType cevap = default(KurumTaslakCetvelSorgulamaCevapType);
                    cevap = (KurumTaslakCetvelSorgulamaCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KurumTaslakCetvelSorgulamaSync_Body

            }

            public static RandevuDurumGuncelleCevapType RandevuDurumGuncelleSync(Guid siteID, RandevuDurumGuncelleTalepType RandevuDurumGuncelleTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (RandevuDurumGuncelleCevapType) TTMessageFactory.SyncCall(siteID, new Guid("8a4b6b7d-2bc4-47da-a90d-766a2b931093"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","RandevuDurumGuncelleSync_ServerSide", RandevuDurumGuncelleTalep);
            }


            private static RandevuDurumGuncelleCevapType RandevuDurumGuncelleSync_ServerSide(RandevuDurumGuncelleTalepType RandevuDurumGuncelleTalep)
            {

#region RandevuDurumGuncelleSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "RandevuDurumGuncelle";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("RandevuDurumGuncelleTalep", (object)RandevuDurumGuncelleTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    RandevuDurumGuncelleCevapType cevap = default(RandevuDurumGuncelleCevapType);
                    cevap = (RandevuDurumGuncelleCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion RandevuDurumGuncelleSync_Body

            }

            public static RandevuEklemeCevapType RandevuEklemeSync(Guid siteID, RandevuEklemeTalepType RandevuEklemeTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (RandevuEklemeCevapType) TTMessageFactory.SyncCall(siteID, new Guid("54ca3100-614b-4f0f-aae3-f8277ab5cb19"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","RandevuEklemeSync_ServerSide", RandevuEklemeTalep);
            }


            private static RandevuEklemeCevapType RandevuEklemeSync_ServerSide(RandevuEklemeTalepType RandevuEklemeTalep)
            {

#region RandevuEklemeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "RandevuEkleme";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("RandevuEklemeTalep", (object)RandevuEklemeTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    RandevuEklemeCevapType cevap = default(RandevuEklemeCevapType);
                    cevap = (RandevuEklemeCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion RandevuEklemeSync_Body

            }

            public static RandevuIptalCevapType RandevuIptalSync(Guid siteID, RandevuIptalTalepType RandevuIptalTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (RandevuIptalCevapType) TTMessageFactory.SyncCall(siteID, new Guid("e8bdc085-36be-4952-ae64-d18be011136a"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","RandevuIptalSync_ServerSide", RandevuIptalTalep);
            }


            private static RandevuIptalCevapType RandevuIptalSync_ServerSide(RandevuIptalTalepType RandevuIptalTalep)
            {

#region RandevuIptalSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "RandevuIptal";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("RandevuIptalTalep", (object)RandevuIptalTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    RandevuIptalCevapType cevap = default(RandevuIptalCevapType);
                    cevap = (RandevuIptalCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion RandevuIptalSync_Body

            }

            public static RandevuKlinikSorgulamaObjCevapType RandevuKlinikSorgulamaObjSync(Guid siteID, RandevuKlinikSorgulamaTalepType RandevuKlinikSorgulamaObjTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (RandevuKlinikSorgulamaObjCevapType) TTMessageFactory.SyncCall(siteID, new Guid("0ca560bd-75fc-4252-9ee0-b86643be0f3f"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","RandevuKlinikSorgulamaObjSync_ServerSide", RandevuKlinikSorgulamaObjTalep);
            }


            private static RandevuKlinikSorgulamaObjCevapType RandevuKlinikSorgulamaObjSync_ServerSide(RandevuKlinikSorgulamaTalepType RandevuKlinikSorgulamaObjTalep)
            {

#region RandevuKlinikSorgulamaObjSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "RandevuKlinikSorgulamaObj";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("RandevuKlinikSorgulamaObjTalep", (object)RandevuKlinikSorgulamaObjTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    RandevuKlinikSorgulamaObjCevapType cevap = default(RandevuKlinikSorgulamaObjCevapType);
                    cevap = (RandevuKlinikSorgulamaObjCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion RandevuKlinikSorgulamaObjSync_Body

            }

            public static YesilListeVatandasEklemeCevapType YesilListeVatandasEklemeSync(Guid siteID, YesilListeVatandasEklemeTalepType YesilListeVatandasEklemeTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (YesilListeVatandasEklemeCevapType) TTMessageFactory.SyncCall(siteID, new Guid("a9dc9d8f-78d1-4c48-b994-7cba10982620"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","YesilListeVatandasEklemeSync_ServerSide", YesilListeVatandasEklemeTalep);
            }


            private static YesilListeVatandasEklemeCevapType YesilListeVatandasEklemeSync_ServerSide(YesilListeVatandasEklemeTalepType YesilListeVatandasEklemeTalep)
            {

#region YesilListeVatandasEklemeSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "YesilListeVatandasEkleme";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("YesilListeVatandasEklemeTalep", (object)YesilListeVatandasEklemeTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    YesilListeVatandasEklemeCevapType cevap = default(YesilListeVatandasEklemeCevapType);
                    cevap = (YesilListeVatandasEklemeCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion YesilListeVatandasEklemeSync_Body

            }

            public static YesilListeVatandasOnaylamaCevapType YesilListeVatandasOnaylamaSync(Guid siteID, YesilListeVatandasOnaylamaTalepType YesilListeVatandasOnaylamaTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (YesilListeVatandasOnaylamaCevapType) TTMessageFactory.SyncCall(siteID, new Guid("8aff59e9-cf18-4dd6-8e4f-e60fa19d749b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","YesilListeVatandasOnaylamaSync_ServerSide", YesilListeVatandasOnaylamaTalep);
            }


            private static YesilListeVatandasOnaylamaCevapType YesilListeVatandasOnaylamaSync_ServerSide(YesilListeVatandasOnaylamaTalepType YesilListeVatandasOnaylamaTalep)
            {

#region YesilListeVatandasOnaylamaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "YesilListeVatandasOnaylama";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("YesilListeVatandasOnaylamaTalep", (object)YesilListeVatandasOnaylamaTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    YesilListeVatandasOnaylamaCevapType cevap = default(YesilListeVatandasOnaylamaCevapType);
                    cevap = (YesilListeVatandasOnaylamaCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion YesilListeVatandasOnaylamaSync_Body

            }

            public static YesilListeVatandasSorgulamaCevapType YesilListeVatandasSorgulamaSync(Guid siteID, YesilListeVatandasSorgulamaTalepType YesilListeVatandasSorgulamaTalep)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (YesilListeVatandasSorgulamaCevapType) TTMessageFactory.SyncCall(siteID, new Guid("9a683c28-48da-409b-a977-075b72e57d8b"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.MHRSServis+WebMethods, TTObjectClasses","YesilListeVatandasSorgulamaSync_ServerSide", YesilListeVatandasSorgulamaTalep);
            }


            private static YesilListeVatandasSorgulamaCevapType YesilListeVatandasSorgulamaSync_ServerSide(YesilListeVatandasSorgulamaTalepType YesilListeVatandasSorgulamaTalep)
            {

#region YesilListeVatandasSorgulamaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.MHRSServis";
                    header.ServiceId = "85711850-0a33-4bf5-9c0c-c5d8647a75f9";
                    header.MethodName = "YesilListeVatandasSorgulama";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("YesilListeVatandasSorgulamaTalep", (object)YesilListeVatandasSorgulamaTalep),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD","");

                    YesilListeVatandasSorgulamaCevapType cevap = default(YesilListeVatandasSorgulamaCevapType);
                    cevap = (YesilListeVatandasSorgulamaCevapType)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion YesilListeVatandasSorgulamaSync_Body

            }

        }
                    
        protected MHRSServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MHRSServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MHRSServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MHRSServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MHRSServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHRSSERVIS", dataRow) { }
        protected MHRSServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHRSSERVIS", dataRow, isImported) { }
        public MHRSServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MHRSServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MHRSServis() : base() { }

    }
}