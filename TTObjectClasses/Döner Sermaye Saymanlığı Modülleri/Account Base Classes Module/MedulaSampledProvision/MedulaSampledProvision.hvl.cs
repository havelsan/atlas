
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaSampledProvision")] 

    /// <summary>
    /// Medula Örneklenmiş Takipler
    /// </summary>
    public  partial class MedulaSampledProvision : TTObject
    {
        public class MedulaSampledProvisionList : TTObjectCollection<MedulaSampledProvision> { }
                    
        public class ChildMedulaSampledProvisionCollection : TTObject.TTChildObjectCollection<MedulaSampledProvision>
        {
            public ChildMedulaSampledProvisionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaSampledProvisionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Medula Fatura Dönemi
    /// </summary>
        public MedulaInvoiceTermDefinition MedulaInvoiceTerm
        {
            get { return (MedulaInvoiceTermDefinition)((ITTObject)this).GetParent("MEDULAINVOICETERM"); }
            set { this["MEDULAINVOICETERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMedulaSampledProvisionDetailsCollection()
        {
            _MedulaSampledProvisionDetails = new MedulaSampledProvisionDetail.ChildMedulaSampledProvisionDetailCollection(this, new Guid("39a5af15-26b3-4a37-b2b4-6810656f1c4a"));
            ((ITTChildObjectCollection)_MedulaSampledProvisionDetails).GetChildren();
        }

        protected MedulaSampledProvisionDetail.ChildMedulaSampledProvisionDetailCollection _MedulaSampledProvisionDetails = null;
    /// <summary>
    /// Child collection for Medula Örneklenmiş Takip
    /// </summary>
        public MedulaSampledProvisionDetail.ChildMedulaSampledProvisionDetailCollection MedulaSampledProvisionDetails
        {
            get
            {
                if (_MedulaSampledProvisionDetails == null)
                    CreateMedulaSampledProvisionDetailsCollection();
                return _MedulaSampledProvisionDetails;
            }
        }

        protected MedulaSampledProvision(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaSampledProvision(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaSampledProvision(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaSampledProvision(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaSampledProvision(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULASAMPLEDPROVISION", dataRow) { }
        protected MedulaSampledProvision(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULASAMPLEDPROVISION", dataRow, isImported) { }
        public MedulaSampledProvision(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaSampledProvision(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaSampledProvision() : base() { }

    }
}