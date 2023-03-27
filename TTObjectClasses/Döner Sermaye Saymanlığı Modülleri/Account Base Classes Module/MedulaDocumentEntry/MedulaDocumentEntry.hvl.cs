
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaDocumentEntry")] 

    /// <summary>
    /// Medula Döküman Kayıt
    /// </summary>
    public  partial class MedulaDocumentEntry : TTObject
    {
        public class MedulaDocumentEntryList : TTObjectCollection<MedulaDocumentEntry> { }
                    
        public class ChildMedulaDocumentEntryCollection : TTObject.TTChildObjectCollection<MedulaDocumentEntry>
        {
            public ChildMedulaDocumentEntryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaDocumentEntryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("381783af-3531-467c-b7de-d3e862df9e1d"); } }
    /// <summary>
    /// Kaydedildi
    /// </summary>
            public static Guid Saved { get { return new Guid("acb2cfb2-d438-47a7-91e7-a8dc801071ae"); } }
        }

    /// <summary>
    /// Medula Kayıt Referans Numarası
    /// </summary>
        public long? ReferenceNo
        {
            get { return (long?)this["REFERENCENO"]; }
            set { this["REFERENCENO"] = value; }
        }

    /// <summary>
    /// Medula Takip No
    /// </summary>
        public string TakipNo
        {
            get { return (string)this["TAKIPNO"]; }
            set { this["TAKIPNO"] = value; }
        }

    /// <summary>
    /// Dönem Evrak No
    /// </summary>
        public int? EvrakId
        {
            get { return (int?)this["EVRAKID"]; }
            set { this["EVRAKID"] = value; }
        }

        public UploadedDocument UploadedDocument
        {
            get { return (UploadedDocument)((ITTObject)this).GetParent("UPLOADEDDOCUMENT"); }
            set { this["UPLOADEDDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisodeProtocol SubEpisodeProtocol
        {
            get { return (SubEpisodeProtocol)((ITTObject)this).GetParent("SUBEPISODEPROTOCOL"); }
            set { this["SUBEPISODEPROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaDocumentEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaDocumentEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaDocumentEntry(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaDocumentEntry(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaDocumentEntry(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULADOCUMENTENTRY", dataRow) { }
        protected MedulaDocumentEntry(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULADOCUMENTENTRY", dataRow, isImported) { }
        public MedulaDocumentEntry(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaDocumentEntry(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaDocumentEntry() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}