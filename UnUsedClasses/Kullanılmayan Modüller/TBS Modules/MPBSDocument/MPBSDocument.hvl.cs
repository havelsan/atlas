
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSDocument")] 

    /// <summary>
    /// Evrak
    /// </summary>
    public  partial class MPBSDocument : TTObject
    {
        public class MPBSDocumentList : TTObjectCollection<MPBSDocument> { }
                    
        public class ChildMPBSDocumentCollection : TTObject.TTChildObjectCollection<MPBSDocument>
        {
            public ChildMPBSDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Evrak Ek Sayısı
    /// </summary>
        public int? AdditionalNumber
        {
            get { return (int?)this["ADDITIONALNUMBER"]; }
            set { this["ADDITIONALNUMBER"] = value; }
        }

    /// <summary>
    /// Evrak Kayıt Tarihi
    /// </summary>
        public DateTime? RegisterDate
        {
            get { return (DateTime?)this["REGISTERDATE"]; }
            set { this["REGISTERDATE"] = value; }
        }

    /// <summary>
    /// İlgili Makam
    /// </summary>
        public string ConcernedPosition
        {
            get { return (string)this["CONCERNEDPOSITION"]; }
            set { this["CONCERNEDPOSITION"] = value; }
        }

    /// <summary>
    /// Gizlilik Derecesi
    /// </summary>
        public string SecurityLevel
        {
            get { return (string)this["SECURITYLEVEL"]; }
            set { this["SECURITYLEVEL"] = value; }
        }

    /// <summary>
    /// Miat Tarihi
    /// </summary>
        public DateTime? WearLifeDate
        {
            get { return (DateTime?)this["WEARLIFEDATE"]; }
            set { this["WEARLIFEDATE"] = value; }
        }

    /// <summary>
    /// Evrak Belirteci
    /// </summary>
        public string Identifier
        {
            get { return (string)this["IDENTIFIER"]; }
            set { this["IDENTIFIER"] = value; }
        }

    /// <summary>
    /// Arz Türü
    /// </summary>
        public string PresentationType
        {
            get { return (string)this["PRESENTATIONTYPE"]; }
            set { this["PRESENTATIONTYPE"] = value; }
        }

    /// <summary>
    /// Evrak Dağıtım Tarihi
    /// </summary>
        public DateTime? DistributionDate
        {
            get { return (DateTime?)this["DISTRIBUTIONDATE"]; }
            set { this["DISTRIBUTIONDATE"] = value; }
        }

    /// <summary>
    /// Evrak No
    /// </summary>
        public int? DocumentNo
        {
            get { return (int?)this["DOCUMENTNO"]; }
            set { this["DOCUMENTNO"] = value; }
        }

    /// <summary>
    /// Evrak İç-Dış
    /// </summary>
        public MPBSDocumentIntenalExternalEnum? InternalExternal
        {
            get { return (MPBSDocumentIntenalExternalEnum?)(int?)this["INTERNALEXTERNAL"]; }
            set { this["INTERNALEXTERNAL"] = value; }
        }

    /// <summary>
    /// Evrak Tarihi
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// Evrakın Bulunduğu Dolap
    /// </summary>
        public string WhichCupboardIn
        {
            get { return (string)this["WHICHCUPBOARDIN"]; }
            set { this["WHICHCUPBOARDIN"] = value; }
        }

    /// <summary>
    /// Günlük Evrak No
    /// </summary>
        public int? DailyDocumentNo
        {
            get { return (int?)this["DAILYDOCUMENTNO"]; }
            set { this["DAILYDOCUMENTNO"] = value; }
        }

    /// <summary>
    /// Evrak Konusu
    /// </summary>
        public string Subject
        {
            get { return (string)this["SUBJECT"]; }
            set { this["SUBJECT"] = value; }
        }

    /// <summary>
    /// Evrakın Bulunduğu Dosya
    /// </summary>
        public string WhichFileIn
        {
            get { return (string)this["WHICHFILEIN"]; }
            set { this["WHICHFILEIN"] = value; }
        }

        protected MPBSDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSDOCUMENT", dataRow) { }
        protected MPBSDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSDOCUMENT", dataRow, isImported) { }
        public MPBSDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSDocument() : base() { }

    }
}