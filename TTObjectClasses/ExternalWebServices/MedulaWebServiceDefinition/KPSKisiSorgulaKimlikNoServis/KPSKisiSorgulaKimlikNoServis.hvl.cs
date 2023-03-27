
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KPSKisiSorgulaKimlikNoServis")] 

    public  partial class KPSKisiSorgulaKimlikNoServis : TTObject
    {
        public class KPSKisiSorgulaKimlikNoServisList : TTObjectCollection<KPSKisiSorgulaKimlikNoServis> { }
                    
        public class ChildKPSKisiSorgulaKimlikNoServisCollection : TTObject.TTChildObjectCollection<KPSKisiSorgulaKimlikNoServis>
        {
            public ChildKPSKisiSorgulaKimlikNoServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKPSKisiSorgulaKimlikNoServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            /// <summary>
            /// Mernis Kimlik No ile kişi bilgisi sorgulama
            /// </summary>
            public static KisiBilgisiSonucu ListeleCokluSync(Guid siteID, KisiSorgulaTCKimlikNoSorguKriteri kriter)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KisiBilgisiSonucu) TTMessageFactory.SyncCall(siteID, new Guid("4b1cad30-86b5-4bc8-a325-d3947adb50d3"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSKisiSorgulaKimlikNoServis+WebMethods, TTObjectClasses","ListeleCokluSync_ServerSide", kriter);
            }


            private static KisiBilgisiSonucu ListeleCokluSync_ServerSide(KisiSorgulaTCKimlikNoSorguKriteri kriter)
            {

#region ListeleCokluSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSKisiSorgulaKimlikNoServis";
                    header.ServiceId = "66b0a449-9d85-4ee5-9b48-c3fe95aca8c8";
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

                    KisiBilgisiSonucu cevap = default(KisiBilgisiSonucu);
                    cevap = (KisiBilgisiSonucu)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion ListeleCokluSync_Body

            }

        }
                    
        protected KPSKisiSorgulaKimlikNoServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KPSKisiSorgulaKimlikNoServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KPSKisiSorgulaKimlikNoServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KPSKisiSorgulaKimlikNoServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KPSKisiSorgulaKimlikNoServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KPSKISISORGULAKIMLIKNOSERVIS", dataRow) { }
        protected KPSKisiSorgulaKimlikNoServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KPSKISISORGULAKIMLIKNOSERVIS", dataRow, isImported) { }
        public KPSKisiSorgulaKimlikNoServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KPSKisiSorgulaKimlikNoServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KPSKisiSorgulaKimlikNoServis() : base() { }

    }
}