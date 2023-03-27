
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporIslemleri")] 

    public  partial class RaporIslemleri : TTObject
    {
        public class RaporIslemleriList : TTObjectCollection<RaporIslemleri> { }
                    
        public class ChildRaporIslemleriCollection : TTObject.TTChildObjectCollection<RaporIslemleri>
        {
            public ChildRaporIslemleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporIslemleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static raporCevapDVO ilacRaporDuzeltSync(Guid siteID, ilacRaporDuzeltDVO raporDuzelt)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (raporCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("2e1cddec-d267-4047-93a7-088e4e0c3c85"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.RaporIslemleri+WebMethods, TTObjectClasses","ilacRaporDuzeltSync_ServerSide", raporDuzelt);
            }


            private static raporCevapDVO ilacRaporDuzeltSync_ServerSide(ilacRaporDuzeltDVO raporDuzelt)
            {

#region ilacRaporDuzeltSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.RaporIslemleri";
                    header.ServiceId = "9366e2d1-a197-4e0d-877e-3ba56a42b5ca";
                    header.MethodName = "ilacRaporDuzelt";
                    header.CallTimeout = 45;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("raporDuzelt", (object)raporDuzelt),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    raporCevapDVO cevap = default(raporCevapDVO);
                    cevap = (raporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ilacRaporDuzeltSync_Body

            }

            public static raporCevapDVO raporBilgisiBulRaporTakipNodanSync(Guid siteID, raporOkuRaporTakipNodanDVO raporOku)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (raporCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("975c99e0-c840-4ec3-a932-ef5f86e0434e"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.RaporIslemleri+WebMethods, TTObjectClasses","raporBilgisiBulRaporTakipNodanSync_ServerSide", raporOku);
            }


            private static raporCevapDVO raporBilgisiBulRaporTakipNodanSync_ServerSide(raporOkuRaporTakipNodanDVO raporOku)
            {

#region raporBilgisiBulRaporTakipNodanSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.RaporIslemleri";
                    header.ServiceId = "9366e2d1-a197-4e0d-877e-3ba56a42b5ca";
                    header.MethodName = "raporBilgisiBulRaporTakipNodan";
                    header.CallTimeout = 45;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("raporOku", (object)raporOku),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    raporCevapDVO cevap = default(raporCevapDVO);
                    cevap = (raporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion raporBilgisiBulRaporTakipNodanSync_Body

            }

            public static raporCevapDVO raporBilgisiBulSync(Guid siteID, raporSorguDVO raporBilgisi)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (raporCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("098e9c4d-df28-433d-8f6b-c808168a4d5d"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.RaporIslemleri+WebMethods, TTObjectClasses","raporBilgisiBulSync_ServerSide", raporBilgisi);
            }


            private static raporCevapDVO raporBilgisiBulSync_ServerSide(raporSorguDVO raporBilgisi)
            {

#region raporBilgisiBulSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.RaporIslemleri";
                    header.ServiceId = "9366e2d1-a197-4e0d-877e-3ba56a42b5ca";
                    header.MethodName = "raporBilgisiBul";
                    header.CallTimeout = 45;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("raporBilgisi", (object)raporBilgisi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    raporCevapDVO cevap = default(raporCevapDVO);
                    cevap = (raporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion raporBilgisiBulSync_Body

            }

            public static raporCevapTCKimlikNodanDVO raporBilgisiBulTCKimlikNodanSync(Guid siteID, raporOkuTCKimlikNodanDVO raporOku)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (raporCevapTCKimlikNodanDVO) TTMessageFactory.SyncCall(siteID, new Guid("f9f131f2-085e-4a28-9496-7d302b62d470"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.RaporIslemleri+WebMethods, TTObjectClasses","raporBilgisiBulTCKimlikNodanSync_ServerSide", raporOku);
            }


            private static raporCevapTCKimlikNodanDVO raporBilgisiBulTCKimlikNodanSync_ServerSide(raporOkuTCKimlikNodanDVO raporOku)
            {

#region raporBilgisiBulTCKimlikNodanSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.RaporIslemleri";
                    header.ServiceId = "9366e2d1-a197-4e0d-877e-3ba56a42b5ca";
                    header.MethodName = "raporBilgisiBulTCKimlikNodan";
                    header.CallTimeout = 45;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("raporOku", (object)raporOku),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    raporCevapTCKimlikNodanDVO cevap = default(raporCevapTCKimlikNodanDVO);
                    cevap = (raporCevapTCKimlikNodanDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion raporBilgisiBulTCKimlikNodanSync_Body

            }

            public static raporCevapDVO raporBilgisiKaydetSync(Guid siteID, raporGirisDVO raporGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (raporCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("e4cf9acf-841d-4ee2-84c6-a6c982c1b0c7"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.RaporIslemleri+WebMethods, TTObjectClasses","raporBilgisiKaydetSync_ServerSide", raporGiris);
            }


            private static raporCevapDVO raporBilgisiKaydetSync_ServerSide(raporGirisDVO raporGiris)
            {

#region raporBilgisiKaydetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.RaporIslemleri";
                    header.ServiceId = "9366e2d1-a197-4e0d-877e-3ba56a42b5ca";
                    header.MethodName = "raporBilgisiKaydet";
                    header.CallTimeout = 45;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("raporGiris", (object)raporGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    raporCevapDVO cevap = default(raporCevapDVO);
                    cevap = (raporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion raporBilgisiKaydetSync_Body

            }

            public static raporCevapDVO raporBilgisiSilSync(Guid siteID, raporSorguDVO raporBilgisi)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (raporCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("7f17f243-490b-4fe0-b6ec-368f10921115"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.RaporIslemleri+WebMethods, TTObjectClasses","raporBilgisiSilSync_ServerSide", raporBilgisi);
            }


            private static raporCevapDVO raporBilgisiSilSync_ServerSide(raporSorguDVO raporBilgisi)
            {

#region raporBilgisiSilSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.RaporIslemleri";
                    header.ServiceId = "9366e2d1-a197-4e0d-877e-3ba56a42b5ca";
                    header.MethodName = "raporBilgisiSil";
                    header.CallTimeout = 45;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("raporBilgisi", (object)raporBilgisi),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    raporCevapDVO cevap = default(raporCevapDVO);
                    cevap = (raporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion raporBilgisiSilSync_Body

            }

            public static raporCevapDVO takipNoileRaporBilgisiKaydetSync(Guid siteID, raporGirisDVO raporGiris)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (raporCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("b315c923-786a-4882-81ed-190f03aa5dac"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.RaporIslemleri+WebMethods, TTObjectClasses","takipNoileRaporBilgisiKaydetSync_ServerSide", raporGiris);
            }


            private static raporCevapDVO takipNoileRaporBilgisiKaydetSync_ServerSide(raporGirisDVO raporGiris)
            {

#region takipNoileRaporBilgisiKaydetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.RaporIslemleri";
                    header.ServiceId = "9366e2d1-a197-4e0d-877e-3ba56a42b5ca";
                    header.MethodName = "takipNoileRaporBilgisiKaydet";
                    header.CallTimeout = 45;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("raporGiris", (object)raporGiris),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    raporCevapDVO cevap = default(raporCevapDVO);
                    cevap = (raporCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion takipNoileRaporBilgisiKaydetSync_Body

            }

        }
                    
        protected RaporIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporIslemleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporIslemleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporIslemleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORISLEMLERI", dataRow) { }
        protected RaporIslemleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORISLEMLERI", dataRow, isImported) { }
        public RaporIslemleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporIslemleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporIslemleri() : base() { }

    }
}