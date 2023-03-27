
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KPSV2")] 

    public  partial class KPSV2 : TTObject
    {
        public class KPSV2List : TTObjectCollection<KPSV2> { }
                    
        public class ChildKPSV2Collection : TTObject.TTChildObjectCollection<KPSV2>
        {
            public ChildKPSV2Collection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKPSV2Collection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            public static KpsServisSonucuAileBilgisi AileBireyleriSorgulaSync(Guid siteID, AileBireyleriSorgulaKriter kriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KpsServisSonucuAileBilgisi) TTMessageFactory.SyncCall(siteID, new Guid("5094017a-1123-4a0e-9b54-14140d80162c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSV2+WebMethods, TTObjectClasses","AileBireyleriSorgulaSync_ServerSide", kriter);
            }


            private static KpsServisSonucuAileBilgisi AileBireyleriSorgulaSync_ServerSide(AileBireyleriSorgulaKriter kriter)
            {

#region AileBireyleriSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSV2";
                    header.ServiceId = "2f15c1c6-dc24-4c65-92a6-dd5812afeffe";
                    header.MethodName = "AileBireyleriSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["KPSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["KPSPASSWORD"];
                    credential.ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSAPPLICATIONCODE","");
                    credential.OrganizationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSORGANIZATIONCODE","");

                    KpsServisSonucuAileBilgisi cevap = default(KpsServisSonucuAileBilgisi);
                    cevap = (KpsServisSonucuAileBilgisi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion AileBireyleriSorgulaSync_Body

            }

            public static KpsServisSonucuBilesikKisiBilgisi BilesikKisiSorgulaSync(Guid siteID, long kimlikNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KpsServisSonucuBilesikKisiBilgisi) TTMessageFactory.SyncCall(siteID, new Guid("ce60b69a-4a55-4bce-af97-f5b120f40529"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSV2+WebMethods, TTObjectClasses","BilesikKisiSorgulaSync_ServerSide", kimlikNo);
            }


            private static KpsServisSonucuBilesikKisiBilgisi BilesikKisiSorgulaSync_ServerSide(long kimlikNo)
            {

#region BilesikKisiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSV2";
                    header.ServiceId = "2f15c1c6-dc24-4c65-92a6-dd5812afeffe";
                    header.MethodName = "BilesikKisiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kimlikNo", (object)kimlikNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["KPSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["KPSPASSWORD"];
                    credential.ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSAPPLICATIONCODE","");
                    credential.OrganizationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSORGANIZATIONCODE","");

                    KpsServisSonucuBilesikKisiBilgisi cevap = default(KpsServisSonucuBilesikKisiBilgisi);
                    cevap = (KpsServisSonucuBilesikKisiBilgisi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion BilesikKisiSorgulaSync_Body

            }

            public static KpsServisSonucuBilesikKisiBilgisi BilesikKisiveAdresSorgulaSync(Guid siteID, long kimlikNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KpsServisSonucuBilesikKisiBilgisi) TTMessageFactory.SyncCall(siteID, new Guid("ea31ed5e-87bc-41b4-a4c6-89e7cf8b5fc0"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSV2+WebMethods, TTObjectClasses","BilesikKisiveAdresSorgulaSync_ServerSide", kimlikNo);
            }


            private static KpsServisSonucuBilesikKisiBilgisi BilesikKisiveAdresSorgulaSync_ServerSide(long kimlikNo)
            {

#region BilesikKisiveAdresSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSV2";
                    header.ServiceId = "2f15c1c6-dc24-4c65-92a6-dd5812afeffe";
                    header.MethodName = "BilesikKisiveAdresSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kimlikNo", (object)kimlikNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["KPSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["KPSPASSWORD"];
                    credential.ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSAPPLICATIONCODE","");
                    credential.OrganizationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSORGANIZATIONCODE","");

                    KpsServisSonucuBilesikKisiBilgisi cevap = default(KpsServisSonucuBilesikKisiBilgisi);
                    cevap = (KpsServisSonucuBilesikKisiBilgisi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion BilesikKisiveAdresSorgulaSync_Body

            }

            public static KpsServisSonucuKisiAdresBilgisi KimlikNoIleAdresBilgisiSorgulaSync(Guid siteID, long kimlikNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KpsServisSonucuKisiAdresBilgisi) TTMessageFactory.SyncCall(siteID, new Guid("00abf9e9-af57-4b1f-bf09-2f3268f6d452"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSV2+WebMethods, TTObjectClasses","KimlikNoIleAdresBilgisiSorgulaSync_ServerSide", kimlikNo);
            }


            private static KpsServisSonucuKisiAdresBilgisi KimlikNoIleAdresBilgisiSorgulaSync_ServerSide(long kimlikNo)
            {

#region KimlikNoIleAdresBilgisiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSV2";
                    header.ServiceId = "2f15c1c6-dc24-4c65-92a6-dd5812afeffe";
                    header.MethodName = "KimlikNoIleAdresBilgisiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kimlikNo", (object)kimlikNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["KPSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["KPSPASSWORD"];
                    credential.ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSAPPLICATIONCODE","");
                    credential.OrganizationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSORGANIZATIONCODE","");

                    KpsServisSonucuKisiAdresBilgisi cevap = default(KpsServisSonucuKisiAdresBilgisi);
                    cevap = (KpsServisSonucuKisiAdresBilgisi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KimlikNoIleAdresBilgisiSorgulaSync_Body

            }

            public static KpsServisSonucuGenelNufusKayitOrnegi KimlikNoIleNufusKayitOrnegiSorgulaSync(Guid siteID, long kimlikNo)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KpsServisSonucuGenelNufusKayitOrnegi) TTMessageFactory.SyncCall(siteID, new Guid("a0dd231a-5962-40f9-a60b-499ee11cc39c"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSV2+WebMethods, TTObjectClasses","KimlikNoIleNufusKayitOrnegiSorgulaSync_ServerSide", kimlikNo);
            }


            private static KpsServisSonucuGenelNufusKayitOrnegi KimlikNoIleNufusKayitOrnegiSorgulaSync_ServerSide(long kimlikNo)
            {

#region KimlikNoIleNufusKayitOrnegiSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSV2";
                    header.ServiceId = "2f15c1c6-dc24-4c65-92a6-dd5812afeffe";
                    header.MethodName = "KimlikNoIleNufusKayitOrnegiSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kimlikNo", (object)kimlikNo),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["KPSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["KPSPASSWORD"];
                    credential.ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSAPPLICATIONCODE","");
                    credential.OrganizationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSORGANIZATIONCODE","");

                    KpsServisSonucuGenelNufusKayitOrnegi cevap = default(KpsServisSonucuGenelNufusKayitOrnegi);
                    cevap = (KpsServisSonucuGenelNufusKayitOrnegi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion KimlikNoIleNufusKayitOrnegiSorgulaSync_Body

            }

            public static KpsServisSonucuKisiTemelBilgisi TcKimlikNoSorgulaSync(Guid siteID, KisiSorgulaKisiBilgileriCO kriter)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KpsServisSonucuKisiTemelBilgisi) TTMessageFactory.SyncCall(siteID, new Guid("b4cbeaee-b326-4bae-b103-128e6a3754f1"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSV2+WebMethods, TTObjectClasses","TcKimlikNoSorgulaSync_ServerSide", kriter);
            }


            private static KpsServisSonucuKisiTemelBilgisi TcKimlikNoSorgulaSync_ServerSide(KisiSorgulaKisiBilgileriCO kriter)
            {

#region TcKimlikNoSorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSV2";
                    header.ServiceId = "2f15c1c6-dc24-4c65-92a6-dd5812afeffe";
                    header.MethodName = "TcKimlikNoSorgula";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["KPSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["KPSPASSWORD"];
                    credential.ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSAPPLICATIONCODE","");
                    credential.OrganizationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSORGANIZATIONCODE","");

                    KpsServisSonucuKisiTemelBilgisi cevap = default(KpsServisSonucuKisiTemelBilgisi);
                    cevap = (KpsServisSonucuKisiTemelBilgisi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion TcKimlikNoSorgulaSync_Body

            }

            public static KpsServisSonucuYetkiListesi YetkiListesiSync(Guid siteID)
            {
            
                Guid? resourceObjectID = null;
                Guid? procedureObjectID = null;
return (KpsServisSonucuYetkiListesi) TTMessageFactory.SyncCall(siteID, new Guid("735142dc-fb39-4455-ad1f-fb7fa92b0e07"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSV2+WebMethods, TTObjectClasses","YetkiListesiSync_ServerSide");
            }


            private static KpsServisSonucuYetkiListesi YetkiListesiSync_ServerSide()
            {

#region YetkiListesiSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSV2";
                    header.ServiceId = "2f15c1c6-dc24-4c65-92a6-dd5812afeffe";
                    header.MethodName = "YetkiListesi";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {

                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["KPSUSERNAME"];
                    credential.Password = (string)TTStorageManager.Security.TTUser.CurrentUser.UserObject["KPSPASSWORD"];
                    credential.ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSAPPLICATIONCODE","");
                    credential.OrganizationCode = TTObjectClasses.SystemParameter.GetParameterValue("KPSORGANIZATIONCODE","");

                    KpsServisSonucuYetkiListesi cevap = default(KpsServisSonucuYetkiListesi);
                    cevap = (KpsServisSonucuYetkiListesi)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion YetkiListesiSync_Body

            }

        }
                    
        protected KPSV2(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KPSV2(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KPSV2(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KPSV2(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KPSV2(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KPSV2", dataRow) { }
        protected KPSV2(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KPSV2", dataRow, isImported) { }
        public KPSV2(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KPSV2(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KPSV2() : base() { }

    }
}