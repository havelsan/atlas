
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KPSYbKisiSorgulaYbKimlikNoServis")] 

    public  partial class KPSYbKisiSorgulaYbKimlikNoServis : TTObject
    {
        public class KPSYbKisiSorgulaYbKimlikNoServisList : TTObjectCollection<KPSYbKisiSorgulaYbKimlikNoServis> { }
                    
        public class ChildKPSYbKisiSorgulaYbKimlikNoServisCollection : TTObject.TTChildObjectCollection<KPSYbKisiSorgulaYbKimlikNoServis>
        {
            public ChildKPSYbKisiSorgulaYbKimlikNoServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKPSYbKisiSorgulaYbKimlikNoServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            /// <summary>
            /// Mernis Yabancı Kimlik No ile Kişi Sorgulama
            /// </summary>
            public static YbKimlikNoIleYbKisiBilgisiSonucu ListeleCokluSync(Guid siteID, YbKisiSorgulaYbKimlikNoSorguKriteri kriter)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (YbKimlikNoIleYbKisiBilgisiSonucu) TTMessageFactory.SyncCall(siteID, new Guid("91d91fa0-8572-4544-a4eb-5e6dbe9595cb"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSYbKisiSorgulaYbKimlikNoServis+WebMethods, TTObjectClasses","ListeleCokluSync_ServerSide", kriter);
            }


            private static YbKimlikNoIleYbKisiBilgisiSonucu ListeleCokluSync_ServerSide(YbKisiSorgulaYbKimlikNoSorguKriteri kriter)
            {

#region ListeleCokluSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSYbKisiSorgulaYbKimlikNoServis";
                    header.ServiceId = "2304cba6-4158-4c3f-beca-08faea57a40c";
                    header.MethodName = "ListeleCoklu";
                    header.CallTimeout = 30;
                    header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                    header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID","");
                    header.ServiceType = ServiceType.SOAP;
                    IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("kriter", (object)kriter),
                    };

                    TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();
                    credential.UserName = TTObjectClasses.SystemParameter.GetParameterValue("MERNISUSERNAME","");
                    credential.Password = TTObjectClasses.SystemParameter.GetParameterValue("MERNISPASSWORD","");

                    YbKimlikNoIleYbKisiBilgisiSonucu cevap = default(YbKimlikNoIleYbKisiBilgisiSonucu);
                    cevap = (YbKimlikNoIleYbKisiBilgisiSonucu)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ListeleCokluSync_Body

            }

        }
                    
        protected KPSYbKisiSorgulaYbKimlikNoServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KPSYbKisiSorgulaYbKimlikNoServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KPSYbKisiSorgulaYbKimlikNoServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KPSYbKisiSorgulaYbKimlikNoServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KPSYbKisiSorgulaYbKimlikNoServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KPSYBKISISORGULAYBKIMLIKNOSERVIS", dataRow) { }
        protected KPSYbKisiSorgulaYbKimlikNoServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KPSYBKISISORGULAYBKIMLIKNOSERVIS", dataRow, isImported) { }
        public KPSYbKisiSorgulaYbKimlikNoServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KPSYbKisiSorgulaYbKimlikNoServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KPSYbKisiSorgulaYbKimlikNoServis() : base() { }

    }
}