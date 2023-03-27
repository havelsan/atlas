
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="XXXXXXEHIP")] 

    /// <summary>
    /// EHİP WEB SERVİS Entegrasyon Nesnesi
    /// </summary>
    public  partial class XXXXXXEHIP : TTObject
    {
        public class XXXXXXEHIPList : TTObjectCollection<XXXXXXEHIP> { }
                    
        public class ChildXXXXXXEHIPCollection : TTObject.TTChildObjectCollection<XXXXXXEHIP>
        {
            public ChildXXXXXXEHIPCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildXXXXXXEHIPCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static IslemSonuc GetEhipWsEntegreKeyByBolumIdSync(Guid siteID, string bolumId, string ehipWsUsername, string ehipWsPassword)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (IslemSonuc) TTMessageFactory.SyncCall(siteID, new Guid("01d00cfe-7c9c-4383-a29a-a884fb68eba1"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXEHIP+WebMethods, TTObjectClasses","GetEhipWsEntegreKeyByBolumIdSync_ServerSide", bolumId, ehipWsUsername, ehipWsPassword);
            }


            private static IslemSonuc GetEhipWsEntegreKeyByBolumIdSync_ServerSide(string bolumId, string ehipWsUsername, string ehipWsPassword)
            {

#region GetEhipWsEntegreKeyByBolumIdSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXEHIP";
                    header.ServiceId = "31ac4645-14fa-4976-99cf-b79dbcf23685";
                    header.MethodName = "GetEhipWsEntegreKeyByBolumId";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("bolumId", (object)bolumId),
                        Tuple.Create("ehipWsUsername", (object)ehipWsUsername),
                        Tuple.Create("ehipWsPassword", (object)ehipWsPassword),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    IslemSonuc cevap = default(IslemSonuc);
                    cevap = (IslemSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion GetEhipWsEntegreKeyByBolumIdSync_Body

            }

            public static KisiIhaleKomisyonInfo[] GetKisiIhaleKomisyonListesiSync(Guid siteID, string Guid)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KisiIhaleKomisyonInfo[]) TTMessageFactory.SyncCall(siteID, new Guid("74c4ada0-407b-4ae2-9c71-1a7396aa268d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXEHIP+WebMethods, TTObjectClasses","GetKisiIhaleKomisyonListesiSync_ServerSide", Guid);
            }


            private static KisiIhaleKomisyonInfo[] GetKisiIhaleKomisyonListesiSync_ServerSide(string Guid)
            {

#region GetKisiIhaleKomisyonListesiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXEHIP";
                    header.ServiceId = "31ac4645-14fa-4976-99cf-b79dbcf23685";
                    header.MethodName = "GetKisiIhaleKomisyonListesi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("Guid", (object)Guid),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    KisiIhaleKomisyonInfo[] cevap = default(KisiIhaleKomisyonInfo[]);
                    cevap = (KisiIhaleKomisyonInfo[])Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion GetKisiIhaleKomisyonListesiSync_Body

            }

            public static IslemSonuc HbysStokKayitlariGonderimSync(Guid siteID, StokGonderimObje obje)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (IslemSonuc) TTMessageFactory.SyncCall(siteID, new Guid("59ecd1a6-15f4-4273-9428-1439b9264a67"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.XXXXXXEHIP+WebMethods, TTObjectClasses","HbysStokKayitlariGonderimSync_ServerSide", obje);
            }


            private static IslemSonuc HbysStokKayitlariGonderimSync_ServerSide(StokGonderimObje obje)
            {

#region HbysStokKayitlariGonderimSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.XXXXXXEHIP";
                    header.ServiceId = "31ac4645-14fa-4976-99cf-b79dbcf23685";
                    header.MethodName = "HbysStokKayitlariGonderim";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("obje", (object)obje),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI","");

                    IslemSonuc cevap = default(IslemSonuc);
                    cevap = (IslemSonuc)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion HbysStokKayitlariGonderimSync_Body

            }

        }
                    
        protected XXXXXXEHIP(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected XXXXXXEHIP(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected XXXXXXEHIP(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected XXXXXXEHIP(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected XXXXXXEHIP(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "XXXXXXEHIP", dataRow) { }
        protected XXXXXXEHIP(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "XXXXXXEHIP", dataRow, isImported) { }
        public XXXXXXEHIP(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public XXXXXXEHIP(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public XXXXXXEHIP() : base() { }

    }
}