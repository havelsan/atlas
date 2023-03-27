
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TibbiMalzemeYardimciIslemler")] 

    public  partial class TibbiMalzemeYardimciIslemler : TTObject
    {
        public class TibbiMalzemeYardimciIslemlerList : TTObjectCollection<TibbiMalzemeYardimciIslemler> { }
                    
        public class ChildTibbiMalzemeYardimciIslemlerCollection : TTObject.TTChildObjectCollection<TibbiMalzemeYardimciIslemler>
        {
            public ChildTibbiMalzemeYardimciIslemlerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTibbiMalzemeYardimciIslemlerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static TTMessage abrTestiKaydetASync(Guid siteID, IWebMethodCallback callerObject, odyometriTestGirisIstekDVO abrTestGirisIstekDVO)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeYardimciIslemler+WebMethods, TTObjectClasses","abrTestiKaydetASync_ServerSide", new Guid("bfebcf40-dadb-46e1-afc2-47198c3c3047"), callerObject, abrTestGirisIstekDVO);
            }

            private static odyometriTestiCevapDVO abrTestiKaydetASync_ServerSide(IWebMethodCallback callerObject, odyometriTestGirisIstekDVO abrTestGirisIstekDVO)
            {

#region abrTestiKaydetASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeYardimciIslemler";
                    header.ServiceId = "8dad1305-38ac-4ada-a294-379d14dbaf04";
                    header.MethodName = "abrTestiKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("abrTestGirisIstekDVO", (object)abrTestGirisIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    odyometriTestiCevapDVO cevap = default(odyometriTestiCevapDVO);
                    
                    try
                    {
                        cevap = (odyometriTestiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { abrTestGirisIstekDVO }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { abrTestGirisIstekDVO }, null);

                    return cevap;
                

#endregion abrTestiKaydetASync_Body

            }

            public static odyometriTestiCevapDVO abrTestiKaydetSync(Guid siteID, odyometriTestGirisIstekDVO abrTestGirisIstekDVO)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (odyometriTestiCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("d1af1896-70a2-4906-920e-dc0e6c467de8"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeYardimciIslemler+WebMethods, TTObjectClasses","abrTestiKaydetSync_ServerSide", abrTestGirisIstekDVO);
            }


            private static odyometriTestiCevapDVO abrTestiKaydetSync_ServerSide(odyometriTestGirisIstekDVO abrTestGirisIstekDVO)
            {

#region abrTestiKaydetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeYardimciIslemler";
                    header.ServiceId = "8dad1305-38ac-4ada-a294-379d14dbaf04";
                    header.MethodName = "abrTestiKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("abrTestGirisIstekDVO", (object)abrTestGirisIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    odyometriTestiCevapDVO cevap = default(odyometriTestiCevapDVO);
                    cevap = (odyometriTestiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion abrTestiKaydetSync_Body

            }

            public static TTMessage davranimOdyometrisiTestKaydetASync(Guid siteID, IWebMethodCallback callerObject, odyometriTestGirisIstekDVO davranimOdyometrisiTestGirisIstekDVO)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeYardimciIslemler+WebMethods, TTObjectClasses","davranimOdyometrisiTestKaydetASync_ServerSide", new Guid("6029e19e-8eb2-46e8-b2e9-1e42db787f30"), callerObject, davranimOdyometrisiTestGirisIstekDVO);
            }

            private static odyometriTestiCevapDVO davranimOdyometrisiTestKaydetASync_ServerSide(IWebMethodCallback callerObject, odyometriTestGirisIstekDVO davranimOdyometrisiTestGirisIstekDVO)
            {

#region davranimOdyometrisiTestKaydetASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeYardimciIslemler";
                    header.ServiceId = "8dad1305-38ac-4ada-a294-379d14dbaf04";
                    header.MethodName = "davranimOdyometrisiTestKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("davranimOdyometrisiTestGirisIstekDVO", (object)davranimOdyometrisiTestGirisIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    odyometriTestiCevapDVO cevap = default(odyometriTestiCevapDVO);
                    
                    try
                    {
                        cevap = (odyometriTestiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { davranimOdyometrisiTestGirisIstekDVO }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { davranimOdyometrisiTestGirisIstekDVO }, null);

                    return cevap;
                

#endregion davranimOdyometrisiTestKaydetASync_Body

            }

            public static odyometriTestiCevapDVO davranimOdyometrisiTestKaydetSync(Guid siteID, odyometriTestGirisIstekDVO davranimOdyometrisiTestGirisIstekDVO)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (odyometriTestiCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("2a9ad302-5d39-4e7b-835a-1d69b923fc14"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeYardimciIslemler+WebMethods, TTObjectClasses","davranimOdyometrisiTestKaydetSync_ServerSide", davranimOdyometrisiTestGirisIstekDVO);
            }


            private static odyometriTestiCevapDVO davranimOdyometrisiTestKaydetSync_ServerSide(odyometriTestGirisIstekDVO davranimOdyometrisiTestGirisIstekDVO)
            {

#region davranimOdyometrisiTestKaydetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeYardimciIslemler";
                    header.ServiceId = "8dad1305-38ac-4ada-a294-379d14dbaf04";
                    header.MethodName = "davranimOdyometrisiTestKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("davranimOdyometrisiTestGirisIstekDVO", (object)davranimOdyometrisiTestGirisIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    odyometriTestiCevapDVO cevap = default(odyometriTestiCevapDVO);
                    cevap = (odyometriTestiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion davranimOdyometrisiTestKaydetSync_Body

            }

            public static TTMessage safSesOdyometrisiTestKaydetASync(Guid siteID, IWebMethodCallback callerObject, odyometriTestGirisIstekDVO safSesOdyometriTestGirisIstekDVO)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeYardimciIslemler+WebMethods, TTObjectClasses","safSesOdyometrisiTestKaydetASync_ServerSide", new Guid("85e86013-1af0-442a-9016-ec77636837af"), callerObject, safSesOdyometriTestGirisIstekDVO);
            }

            private static odyometriTestiCevapDVO safSesOdyometrisiTestKaydetASync_ServerSide(IWebMethodCallback callerObject, odyometriTestGirisIstekDVO safSesOdyometriTestGirisIstekDVO)
            {

#region safSesOdyometrisiTestKaydetASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeYardimciIslemler";
                    header.ServiceId = "8dad1305-38ac-4ada-a294-379d14dbaf04";
                    header.MethodName = "safSesOdyometrisiTestKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("safSesOdyometriTestGirisIstekDVO", (object)safSesOdyometriTestGirisIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    odyometriTestiCevapDVO cevap = default(odyometriTestiCevapDVO);
                    
                    try
                    {
                        cevap = (odyometriTestiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] { safSesOdyometriTestGirisIstekDVO }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] { safSesOdyometriTestGirisIstekDVO }, null);

                    return cevap;
                

#endregion safSesOdyometrisiTestKaydetASync_Body

            }

            public static odyometriTestiCevapDVO safSesOdyometrisiTestKaydetSync(Guid siteID, odyometriTestGirisIstekDVO safSesOdyometriTestGirisIstekDVO)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (odyometriTestiCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("921e9e25-9e5f-41d9-8fff-23f9928d0d32"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeYardimciIslemler+WebMethods, TTObjectClasses","safSesOdyometrisiTestKaydetSync_ServerSide", safSesOdyometriTestGirisIstekDVO);
            }


            private static odyometriTestiCevapDVO safSesOdyometrisiTestKaydetSync_ServerSide(odyometriTestGirisIstekDVO safSesOdyometriTestGirisIstekDVO)
            {

#region safSesOdyometrisiTestKaydetSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeYardimciIslemler";
                    header.ServiceId = "8dad1305-38ac-4ada-a294-379d14dbaf04";
                    header.MethodName = "safSesOdyometrisiTestKaydet";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("safSesOdyometriTestGirisIstekDVO", (object)safSesOdyometriTestGirisIstekDVO),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    odyometriTestiCevapDVO cevap = default(odyometriTestiCevapDVO);
                    cevap = (odyometriTestiCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion safSesOdyometrisiTestKaydetSync_Body

            }

            public static TTMessage sutMalzemeSorgulaASync(Guid siteID, IWebMethodCallback callerObject)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return TTMessageFactory.ASyncCall(siteID, resourceObjectID, procedureObjectID, TTMessagePriorityEnum.MediumPriority ,"TTObjectClasses","TTObjectClasses.TibbiMalzemeYardimciIslemler+WebMethods, TTObjectClasses","sutMalzemeSorgulaASync_ServerSide", new Guid("06cde47d-f460-49a3-b7f9-22bcad76498b"), callerObject);
            }

            private static butKodlariCevapDVO sutMalzemeSorgulaASync_ServerSide(IWebMethodCallback callerObject)
            {

#region sutMalzemeSorgulaASync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeYardimciIslemler";
                    header.ServiceId = "8dad1305-38ac-4ada-a294-379d14dbaf04";
                    header.MethodName = "sutMalzemeSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");


                    butKodlariCevapDVO cevap = default(butKodlariCevapDVO);
                    
                    try
                    {
                        cevap = (butKodlariCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    }
                    catch (Exception ex)
                    {
                        bool thr = true;
                        if (callerObject != null)
                            thr = callerObject.WebMethodCallback(cevap, new object[] {  }, ex);

                        if (thr)
                            throw;

                        return null;
                    }

                    if (callerObject != null)
                        callerObject.WebMethodCallback(cevap, new object[] {  }, null);

                    return cevap;
                

#endregion sutMalzemeSorgulaASync_Body

            }

            public static butKodlariCevapDVO sutMalzemeSorgulaSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (butKodlariCevapDVO) TTMessageFactory.SyncCall(siteID, new Guid("6477680d-e151-4f49-a7e0-e466aa259483"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.TibbiMalzemeYardimciIslemler+WebMethods, TTObjectClasses","sutMalzemeSorgulaSync_ServerSide");
            }


            private static butKodlariCevapDVO sutMalzemeSorgulaSync_ServerSide()
            {

#region sutMalzemeSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.TibbiMalzemeYardimciIslemler";
                    header.ServiceId = "8dad1305-38ac-4ada-a294-379d14dbaf04";
                    header.MethodName = "sutMalzemeSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD","");

                    butKodlariCevapDVO cevap = default(butKodlariCevapDVO);
                    cevap = (butKodlariCevapDVO)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion sutMalzemeSorgulaSync_Body

            }

        }
                    
        protected TibbiMalzemeYardimciIslemler(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TibbiMalzemeYardimciIslemler(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TibbiMalzemeYardimciIslemler(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TibbiMalzemeYardimciIslemler(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TibbiMalzemeYardimciIslemler(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TIBBIMALZEMEYARDIMCIISLEMLER", dataRow) { }
        protected TibbiMalzemeYardimciIslemler(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TIBBIMALZEMEYARDIMCIISLEMLER", dataRow, isImported) { }
        public TibbiMalzemeYardimciIslemler(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TibbiMalzemeYardimciIslemler(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TibbiMalzemeYardimciIslemler() : base() { }

    }
}