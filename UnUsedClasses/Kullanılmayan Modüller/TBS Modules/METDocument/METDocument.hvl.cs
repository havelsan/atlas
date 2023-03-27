
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="METDocument")] 

    /// <summary>
    /// Evrak
    /// </summary>
    public  partial class METDocument : TTObject
    {
        public class METDocumentList : TTObjectCollection<METDocument> { }
                    
        public class ChildMETDocumentCollection : TTObject.TTChildObjectCollection<METDocument>
        {
            public ChildMETDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMETDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tür
    /// </summary>
        public int? Type
        {
            get { return (int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Konu
    /// </summary>
        public string Subject
        {
            get { return (string)this["SUBJECT"]; }
            set { this["SUBJECT"] = value; }
        }

    /// <summary>
    /// Kayıt Tarihi
    /// </summary>
        public DateTime? DateSaved
        {
            get { return (DateTime?)this["DATESAVED"]; }
            set { this["DATESAVED"] = value; }
        }

    /// <summary>
    /// Miad Tarihi
    /// </summary>
        public DateTime? DueDate
        {
            get { return (DateTime?)this["DUEDATE"]; }
            set { this["DUEDATE"] = value; }
        }

    /// <summary>
    /// Sayı
    /// </summary>
        public string Count
        {
            get { return (string)this["COUNT"]; }
            set { this["COUNT"] = value; }
        }

    /// <summary>
    /// Gizlilik Derecesi
    /// </summary>
        public int? ClassificationDegree
        {
            get { return (int?)this["CLASSIFICATIONDEGREE"]; }
            set { this["CLASSIFICATIONDEGREE"] = value; }
        }

    /// <summary>
    /// Evrak Tarihi
    /// </summary>
        public DateTime? DocumentDate
        {
            get { return (DateTime?)this["DOCUMENTDATE"]; }
            set { this["DOCUMENTDATE"] = value; }
        }

    /// <summary>
    /// Gönderen
    /// </summary>
        public METTarget Sender
        {
            get { return (METTarget)((ITTObject)this).GetParent("SENDER"); }
            set { this["SENDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ilgi
    /// </summary>
        public METDocument RelatedDocument
        {
            get { return (METDocument)((ITTObject)this).GetParent("RELATEDDOCUMENT"); }
            set { this["RELATEDDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Dağıtım Planı
    /// </summary>
        public METDistributionPlan Plan
        {
            get { return (METDistributionPlan)((ITTObject)this).GetParent("PLAN"); }
            set { this["PLAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected METDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected METDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected METDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected METDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected METDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "METDOCUMENT", dataRow) { }
        protected METDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "METDOCUMENT", dataRow, isImported) { }
        public METDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public METDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public METDocument() : base() { }

    }
}