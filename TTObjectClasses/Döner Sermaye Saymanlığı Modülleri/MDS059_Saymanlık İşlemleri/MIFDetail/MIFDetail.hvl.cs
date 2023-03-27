
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MIFDetail")] 

    public  partial class MIFDetail : TTObject
    {
        public class MIFDetailList : TTObjectCollection<MIFDetail> { }
                    
        public class ChildMIFDetailCollection : TTObject.TTChildObjectCollection<MIFDetail>
        {
            public ChildMIFDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMIFDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hesap Kodu
    /// </summary>
        public string AccountCode
        {
            get { return (string)this["ACCOUNTCODE"]; }
            set { this["ACCOUNTCODE"] = value; }
        }

    /// <summary>
    /// Hesap / Ayrıntı Adı
    /// </summary>
        public string AccountName
        {
            get { return (string)this["ACCOUNTNAME"]; }
            set { this["ACCOUNTNAME"] = value; }
        }

    /// <summary>
    /// Borç Tutarı
    /// </summary>
        public Currency? Debt
        {
            get { return (Currency?)this["DEBT"]; }
            set { this["DEBT"] = value; }
        }

    /// <summary>
    /// Alacak Tutarı
    /// </summary>
        public Currency? Credit
        {
            get { return (Currency?)this["CREDIT"]; }
            set { this["CREDIT"] = value; }
        }

        public MIF MIF
        {
            get { return (MIF)((ITTObject)this).GetParent("MIF"); }
            set { this["MIF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MIFDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MIFDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MIFDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MIFDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MIFDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MIFDETAIL", dataRow) { }
        protected MIFDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MIFDETAIL", dataRow, isImported) { }
        public MIFDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MIFDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MIFDetail() : base() { }

    }
}