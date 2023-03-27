
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaProvisionInfoList")] 

    /// <summary>
    /// Medula Takip Bilgileri Listesi
    /// </summary>
    public  partial class MedulaProvisionInfoList : TTObject
    {
        public class MedulaProvisionInfoListList : TTObjectCollection<MedulaProvisionInfoList> { }
                    
        public class ChildMedulaProvisionInfoListCollection : TTObject.TTChildObjectCollection<MedulaProvisionInfoList>
        {
            public ChildMedulaProvisionInfoListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaProvisionInfoListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Sonuç Kodu
    /// </summary>
        public string ResultCode
        {
            get { return (string)this["RESULTCODE"]; }
            set { this["RESULTCODE"] = value; }
        }

    /// <summary>
    /// Sonuç Mesajı
    /// </summary>
        public string ResultMessage
        {
            get { return (string)this["RESULTMESSAGE"]; }
            set { this["RESULTMESSAGE"] = value; }
        }

    /// <summary>
    /// Medula Fatura Dönemi
    /// </summary>
        public MedulaInvoiceTermDefinition MedulaInvoiceTerm
        {
            get { return (MedulaInvoiceTermDefinition)((ITTObject)this).GetParent("MEDULAINVOICETERM"); }
            set { this["MEDULAINVOICETERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMedulaProvisionInfoListDetailsCollection()
        {
            _MedulaProvisionInfoListDetails = new MedulaProvisionInfoListDetail.ChildMedulaProvisionInfoListDetailCollection(this, new Guid("8ed4fdfd-d936-45b2-ac48-920a42e4ad47"));
            ((ITTChildObjectCollection)_MedulaProvisionInfoListDetails).GetChildren();
        }

        protected MedulaProvisionInfoListDetail.ChildMedulaProvisionInfoListDetailCollection _MedulaProvisionInfoListDetails = null;
    /// <summary>
    /// Child collection for Medula Takip Bilgileri Listesi
    /// </summary>
        public MedulaProvisionInfoListDetail.ChildMedulaProvisionInfoListDetailCollection MedulaProvisionInfoListDetails
        {
            get
            {
                if (_MedulaProvisionInfoListDetails == null)
                    CreateMedulaProvisionInfoListDetailsCollection();
                return _MedulaProvisionInfoListDetails;
            }
        }

        protected MedulaProvisionInfoList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaProvisionInfoList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaProvisionInfoList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaProvisionInfoList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaProvisionInfoList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAPROVISIONINFOLIST", dataRow) { }
        protected MedulaProvisionInfoList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAPROVISIONINFOLIST", dataRow, isImported) { }
        public MedulaProvisionInfoList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaProvisionInfoList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaProvisionInfoList() : base() { }

    }
}