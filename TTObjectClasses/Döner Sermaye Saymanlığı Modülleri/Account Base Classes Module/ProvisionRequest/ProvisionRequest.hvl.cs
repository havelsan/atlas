
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProvisionRequest")] 

    /// <summary>
    /// Provizyon Request
    /// </summary>
    public  partial class ProvisionRequest : TTObject
    {
        public class ProvisionRequestList : TTObjectCollection<ProvisionRequest> { }
                    
        public class ChildProvisionRequestCollection : TTObject.TTChildObjectCollection<ProvisionRequest>
        {
            public ChildProvisionRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProvisionRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// DonorTCKimlikNo
    /// </summary>
        public long? DonorTCKimlikNo
        {
            get { return (long?)this["DONORTCKIMLIKNO"]; }
            set { this["DONORTCKIMLIKNO"] = value; }
        }

    /// <summary>
    /// Medula Takip No
    /// </summary>
        public string MedulaTakipNo
        {
            get { return (string)this["MEDULATAKIPNO"]; }
            set { this["MEDULATAKIPNO"] = value; }
        }

    /// <summary>
    /// YesilKartSevkEdenTesisKodu
    /// </summary>
        public string YesilKartSevkEdenTesisKodu
        {
            get { return (string)this["YESILKARTSEVKEDENTESISKODU"]; }
            set { this["YESILKARTSEVKEDENTESISKODU"] = value; }
        }

    /// <summary>
    /// PlakaNo
    /// </summary>
        public string PlakaNo
        {
            get { return (string)this["PLAKANO"]; }
            set { this["PLAKANO"] = value; }
        }

    /// <summary>
    /// ProvizyonTarihi
    /// </summary>
        public DateTime? ProvizyonTarihi
        {
            get { return (DateTime?)this["PROVIZYONTARIHI"]; }
            set { this["PROVIZYONTARIHI"] = value; }
        }

    /// <summary>
    /// Bağlı Takip No
    /// </summary>
        public string BagliTakipNo
        {
            get { return (string)this["BAGLITAKIPNO"]; }
            set { this["BAGLITAKIPNO"] = value; }
        }

        public SpecialityDefinition Brans
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("BRANS"); }
            set { this["BRANS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DevredilenKurum DevredilenKurum
        {
            get { return (DevredilenKurum)((ITTObject)this).GetParent("DEVREDILENKURUM"); }
            set { this["DEVREDILENKURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProvizyonTipi ProvizyonTipi
        {
            get { return (ProvizyonTipi)((ITTObject)this).GetParent("PROVIZYONTIPI"); }
            set { this["PROVIZYONTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SigortaliTuru SigortaliTuru
        {
            get { return (SigortaliTuru)((ITTObject)this).GetParent("SIGORTALITURU"); }
            set { this["SIGORTALITURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TakipTipi TakipTipi
        {
            get { return (TakipTipi)((ITTObject)this).GetParent("TAKIPTIPI"); }
            set { this["TAKIPTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TedaviTipi TedaviTipi
        {
            get { return (TedaviTipi)((ITTObject)this).GetParent("TEDAVITIPI"); }
            set { this["TEDAVITIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TedaviTuru TedaviTuru
        {
            get { return (TedaviTuru)((ITTObject)this).GetParent("TEDAVITURU"); }
            set { this["TEDAVITURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProvisionRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProvisionRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProvisionRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProvisionRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProvisionRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROVISIONREQUEST", dataRow) { }
        protected ProvisionRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROVISIONREQUEST", dataRow, isImported) { }
        public ProvisionRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProvisionRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProvisionRequest() : base() { }

    }
}