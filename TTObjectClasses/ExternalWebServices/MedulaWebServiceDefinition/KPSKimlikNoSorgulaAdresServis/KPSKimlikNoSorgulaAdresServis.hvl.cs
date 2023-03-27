
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KPSKimlikNoSorgulaAdresServis")] 

    /// <summary>
    /// Medula Adres Bilgileri WebService Classı
    /// </summary>
    public  partial class KPSKimlikNoSorgulaAdresServis : TTObject
    {
        public class KPSKimlikNoSorgulaAdresServisList : TTObjectCollection<KPSKimlikNoSorgulaAdresServis> { }
                    
        public class ChildKPSKimlikNoSorgulaAdresServisCollection : TTObject.TTChildObjectCollection<KPSKimlikNoSorgulaAdresServis>
        {
            public ChildKPSKimlikNoSorgulaAdresServisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKPSKimlikNoSorgulaAdresServisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static partial class WebMethods
        {
                    
            /// <summary>
            /// Mernisten Adres Bilgilerini Getiren Web Method
            /// </summary>
            public static KimlikNoileKisiAdresBilgileriSonucu SorgulaSync(Guid siteID, KimlikNoileAdresSorguKriteri kriter)
            {
            
                TTObjectClasses.Resource res = TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource;
                Guid? resourceObjectID = null;
                if (res != null)
                    resourceObjectID = res.ObjectID;
                Guid? procedureObjectID = null;
return (KimlikNoileKisiAdresBilgileriSonucu) TTMessageFactory.SyncCall(siteID, new Guid("88d77acb-614e-4a9e-9c33-1e76813b7ddd"), resourceObjectID, procedureObjectID, "TTObjectClasses","TTObjectClasses.KPSKimlikNoSorgulaAdresServis+WebMethods, TTObjectClasses","SorgulaSync_ServerSide", kriter);
            }


            private static KimlikNoileKisiAdresBilgileriSonucu SorgulaSync_ServerSide(KimlikNoileAdresSorguKriteri kriter)
            {

#region SorgulaSync_Body
                    TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                    header.Namespace = "TTObjectClasses.KPSKimlikNoSorgulaAdresServis";
                    header.ServiceId = "eb2f9c7b-2457-4a86-9a34-5510f12fcf3d";
                    header.MethodName = "Sorgula";
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

                    KimlikNoileKisiAdresBilgileriSonucu cevap = default(KimlikNoileKisiAdresBilgileriSonucu);
                    cevap = (KimlikNoileKisiAdresBilgileriSonucu)Common.CallWebMethodWithHeader(header, credential, callParameters);
                    return cevap;

#endregion SorgulaSync_Body

            }

        }
                    
        protected KPSKimlikNoSorgulaAdresServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KPSKimlikNoSorgulaAdresServis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KPSKimlikNoSorgulaAdresServis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KPSKimlikNoSorgulaAdresServis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KPSKimlikNoSorgulaAdresServis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KPSKIMLIKNOSORGULAADRESSERVIS", dataRow) { }
        protected KPSKimlikNoSorgulaAdresServis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KPSKIMLIKNOSORGULAADRESSERVIS", dataRow, isImported) { }
        public KPSKimlikNoSorgulaAdresServis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KPSKimlikNoSorgulaAdresServis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KPSKimlikNoSorgulaAdresServis() : base() { }

    }
}