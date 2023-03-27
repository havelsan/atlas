
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TaahhutIslemleri")] 

    public  abstract  partial class TaahhutIslemleri : TTObject
    {
        public class TaahhutIslemleriList : TTObjectCollection<TaahhutIslemleri> { }
                    
        public class ChildTaahhutIslemleriCollection : TTObject.TTChildObjectCollection<TaahhutIslemleri>
        {
            public ChildTaahhutIslemleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTaahhutIslemleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static taahhutCevapDVO disTaahhutKayit(Guid siteID, taahhutKayitDVO taahhutKayit)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (taahhutCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("0bca5e60-9989-407b-a6d9-af4a5966dce8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TaahhutIslemleri+WebMethods, TTObjectClasses","disTaahhutKayit_ServerSide", taahhutKayit);
            }


            private static taahhutCevapDVO disTaahhutKayit_ServerSide(taahhutKayitDVO taahhutKayit)
            {

#region disTaahhutKayit_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TaahhutIslemleri";
                    header.ServiceId = "4675b70f-109a-47f4-a946-564e5acdb807";
                    header.MethodName = "disTaahhutKayit";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("taahhutKayit", (object)taahhutKayit),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    taahhutCevapDVO cevap = default(taahhutCevapDVO);
                    cevap = (taahhutCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion disTaahhutKayit_Body

            }

            public static taahhutCevapDVO okuDisTaahhut(Guid siteID, taahhutOkuDVO taahhutOku)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (taahhutCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("272970b6-1f6a-48a2-8d7d-12726daa2a78"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TaahhutIslemleri+WebMethods, TTObjectClasses","okuDisTaahhut_ServerSide", taahhutOku);
            }


            private static taahhutCevapDVO okuDisTaahhut_ServerSide(taahhutOkuDVO taahhutOku)
            {

#region okuDisTaahhut_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TaahhutIslemleri";
                    header.ServiceId = "4675b70f-109a-47f4-a946-564e5acdb807";
                    header.MethodName = "okuDisTaahhut";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("taahhutOku", (object)taahhutOku),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    taahhutCevapDVO cevap = default(taahhutCevapDVO);
                    cevap = (taahhutCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion okuDisTaahhut_Body

            }

            public static taahhutKisiCevapDVO okuKisiDisTaahhut(Guid siteID, taahhutKisiOkuDVO taahhutOku)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (taahhutKisiCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("7a4f4ea2-e8e7-4d9b-b420-a68855ffd491"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TaahhutIslemleri+WebMethods, TTObjectClasses","okuKisiDisTaahhut_ServerSide", taahhutOku);
            }


            private static taahhutKisiCevapDVO okuKisiDisTaahhut_ServerSide(taahhutKisiOkuDVO taahhutOku)
            {

#region okuKisiDisTaahhut_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TaahhutIslemleri";
                    header.ServiceId = "4675b70f-109a-47f4-a946-564e5acdb807";
                    header.MethodName = "okuKisiDisTaahhut";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("taahhutOku", (object)taahhutOku),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    taahhutKisiCevapDVO cevap = default(taahhutKisiCevapDVO);
                    cevap = (taahhutKisiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion okuKisiDisTaahhut_Body

            }

            public static taahhutCevapDVO silDisTaahhut(Guid siteID, taahhutOkuDVO taahhutOku)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (taahhutCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("c6912334-09eb-47a1-879f-89baca7e8935"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TaahhutIslemleri+WebMethods, TTObjectClasses","silDisTaahhut_ServerSide", taahhutOku);
            }


            private static taahhutCevapDVO silDisTaahhut_ServerSide(taahhutOkuDVO taahhutOku)
            {

#region silDisTaahhut_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TaahhutIslemleri";
                    header.ServiceId = "4675b70f-109a-47f4-a946-564e5acdb807";
                    header.MethodName = "silDisTaahhut";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("taahhutOku", (object)taahhutOku),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    taahhutCevapDVO cevap = default(taahhutCevapDVO);
                    cevap = (taahhutCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion silDisTaahhut_Body

            }

        }
                    
        protected TaahhutIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TaahhutIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TaahhutIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TaahhutIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TaahhutIslemleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAAHHUTISLEMLERI", dataRow) { }
        protected TaahhutIslemleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAAHHUTISLEMLERI", dataRow, isImported) { }
        public TaahhutIslemleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TaahhutIslemleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TaahhutIslemleri() : base() { }

    }
}