
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NabizHBYSServis")] 

    public  partial class NabizHBYSServis : TTObject
    {
        public class NabizHBYSServisList : TTObjectCollection<NabizHBYSServis> { }
                    
        public class ChildNabizHBYSServisCollection : TTObject.TTChildObjectCollection<NabizHBYSServis>
        {
            public ChildNabizHBYSServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNabizHBYSServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static DoktorErisimCevap DoktorAcilEHRErisimiSync(Guid siteID, DoktorErisimTalep input)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (DoktorErisimCevap) TTMessageFactory.SyncCall(siteID, new Guid("c1c788ea-d307-4215-8fe5-fd50e62d6386"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.NabizHBYSServis+WebMethods, TTObjectClasses","DoktorAcilEHRErisimiSync_ServerSide", input);
            }


            private static DoktorErisimCevap DoktorAcilEHRErisimiSync_ServerSide(DoktorErisimTalep input)
            {

#region DoktorAcilEHRErisimiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.NabizHBYSServis";
                    header.ServiceId = "0498b693-0649-4024-9d84-719e043cecfe";
                    header.MethodName = "DoktorAcilEHRErisimi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("input", (object)input),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    DoktorErisimCevap cevap = default(DoktorErisimCevap);
                    cevap = (DoktorErisimCevap)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion DoktorAcilEHRErisimiSync_Body

            }

            public static DoktorErisimCevap DoktorEHRErisimiSync(Guid siteID, DoktorErisimTalep input)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (DoktorErisimCevap) TTMessageFactory.SyncCall(siteID, new Guid("54064560-2460-425d-bc4b-2db6194270d9"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.NabizHBYSServis+WebMethods, TTObjectClasses","DoktorEHRErisimiSync_ServerSide", input);
            }


            private static DoktorErisimCevap DoktorEHRErisimiSync_ServerSide(DoktorErisimTalep input)
            {

#region DoktorEHRErisimiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.NabizHBYSServis";
                    header.ServiceId = "0498b693-0649-4024-9d84-719e043cecfe";
                    header.MethodName = "DoktorEHRErisimi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("input", (object)input),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    DoktorErisimCevap cevap = default(DoktorErisimCevap);
                    cevap = (DoktorErisimCevap)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion DoktorEHRErisimiSync_Body

            }

            public static HastaMesajGonderCevap HastaMesajGonderSync(Guid siteID, HastaMesajGonderTalep input)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (HastaMesajGonderCevap) TTMessageFactory.SyncCall(siteID, new Guid("f637e2f1-3e42-4343-8a2c-17dba2ef7c26"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.NabizHBYSServis+WebMethods, TTObjectClasses","HastaMesajGonderSync_ServerSide", input);
            }


            private static HastaMesajGonderCevap HastaMesajGonderSync_ServerSide(HastaMesajGonderTalep input)
            {

#region HastaMesajGonderSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.NabizHBYSServis";
                    header.ServiceId = "0498b693-0649-4024-9d84-719e043cecfe";
                    header.MethodName = "HastaMesajGonder";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("input", (object)input),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    HastaMesajGonderCevap cevap = default(HastaMesajGonderCevap);
                    cevap = (HastaMesajGonderCevap)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion HastaMesajGonderSync_Body

            }

            public static HastaVitalBulguGonderCevap HastaVitalBulguGonderSync(Guid siteID, HastaVitalBulguGonderTalep input)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (HastaVitalBulguGonderCevap) TTMessageFactory.SyncCall(siteID, new Guid("2b8bb961-4e3a-4d60-bc99-e2493326a45c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.NabizHBYSServis+WebMethods, TTObjectClasses","HastaVitalBulguGonderSync_ServerSide", input);
            }


            private static HastaVitalBulguGonderCevap HastaVitalBulguGonderSync_ServerSide(HastaVitalBulguGonderTalep input)
            {

#region HastaVitalBulguGonderSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.NabizHBYSServis";
                    header.ServiceId = "0498b693-0649-4024-9d84-719e043cecfe";
                    header.MethodName = "HastaVitalBulguGonder";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("input", (object)input),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    HastaVitalBulguGonderCevap cevap = default(HastaVitalBulguGonderCevap);
                    cevap = (HastaVitalBulguGonderCevap)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion HastaVitalBulguGonderSync_Body

            }

            public static HBYSHataliIslemSorgulaCevap HBYSHataliIslemSorgulaSync(Guid siteID, HBYSHataliIslemSorgulaTalep input)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (HBYSHataliIslemSorgulaCevap) TTMessageFactory.SyncCall(siteID, new Guid("38308186-8a6d-4de0-9573-6b4c23b3a508"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.NabizHBYSServis+WebMethods, TTObjectClasses","HBYSHataliIslemSorgulaSync_ServerSide", input);
            }


            private static HBYSHataliIslemSorgulaCevap HBYSHataliIslemSorgulaSync_ServerSide(HBYSHataliIslemSorgulaTalep input)
            {

#region HBYSHataliIslemSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.NabizHBYSServis";
                    header.ServiceId = "0498b693-0649-4024-9d84-719e043cecfe";
                    header.MethodName = "HBYSHataliIslemSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("input", (object)input),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI","");

                    HBYSHataliIslemSorgulaCevap cevap = default(HBYSHataliIslemSorgulaCevap);
                    cevap = (HBYSHataliIslemSorgulaCevap)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion HBYSHataliIslemSorgulaSync_Body

            }

        }
                    
        protected NabizHBYSServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NabizHBYSServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NabizHBYSServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NabizHBYSServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NabizHBYSServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NABIZHBYSSERVIS", dataRow) { }
        protected NabizHBYSServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NABIZHBYSSERVIS", dataRow, isImported) { }
        public NabizHBYSServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NabizHBYSServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NabizHBYSServis() : base() { }

    }
}