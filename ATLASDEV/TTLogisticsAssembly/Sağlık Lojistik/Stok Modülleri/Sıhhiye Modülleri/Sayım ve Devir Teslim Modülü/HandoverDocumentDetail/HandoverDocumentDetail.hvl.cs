
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HandoverDocumentDetail")] 

    public  partial class HandoverDocumentDetail : TTObject
    {
        public class HandoverDocumentDetailList : TTObjectCollection<HandoverDocumentDetail> { }
                    
        public class ChildHandoverDocumentDetailCollection : TTObject.TTChildObjectCollection<HandoverDocumentDetail>
        {
            public ChildHandoverDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHandoverDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Noksan Miktar
    /// </summary>
        public Currency? Absent
        {
            get { return (Currency?)this["ABSENT"]; }
            set { this["ABSENT"] = value; }
        }

    /// <summary>
    /// Sayımda Bulunan Miktar
    /// </summary>
        public Currency? CensusInheld
        {
            get { return (Currency?)this["CENSUSINHELD"]; }
            set { this["CENSUSINHELD"] = value; }
        }

    /// <summary>
    /// Kayıtlardaki Miktar
    /// </summary>
        public Currency? Inheld
        {
            get { return (Currency?)this["INHELD"]; }
            set { this["INHELD"] = value; }
        }

    /// <summary>
    /// Fazla Miktar
    /// </summary>
        public Currency? Remnant
        {
            get { return (Currency?)this["REMNANT"]; }
            set { this["REMNANT"] = value; }
        }

        public HandoverDocument HandoverDocument
        {
            get { return (HandoverDocument)((ITTObject)this).GetParent("HANDOVERDOCUMENT"); }
            set { this["HANDOVERDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HandoverDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HandoverDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HandoverDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HandoverDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HandoverDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HANDOVERDOCUMENTDETAIL", dataRow) { }
        protected HandoverDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HANDOVERDOCUMENTDETAIL", dataRow, isImported) { }
        public HandoverDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HandoverDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HandoverDocumentDetail() : base() { }

    }
}