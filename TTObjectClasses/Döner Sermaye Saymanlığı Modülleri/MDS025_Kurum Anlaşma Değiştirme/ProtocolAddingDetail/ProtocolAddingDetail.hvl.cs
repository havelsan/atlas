
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtocolAddingDetail")] 

    /// <summary>
    /// Epizottaki mevcut anlaşmaları tutar
    /// </summary>
    public  partial class ProtocolAddingDetail : TTObject
    {
        public class ProtocolAddingDetailList : TTObjectCollection<ProtocolAddingDetail> { }
                    
        public class ChildProtocolAddingDetailCollection : TTObject.TTChildObjectCollection<ProtocolAddingDetail>
        {
            public ChildProtocolAddingDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtocolAddingDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Anlaşmanın Durumu
    /// </summary>
        public string PROTOCOLSTATUS
        {
            get { return (string)this["PROTOCOLSTATUS"]; }
            set { this["PROTOCOLSTATUS"] = value; }
        }

    /// <summary>
    /// F. Durumu
    /// </summary>
        public MedulaSubEpisodeStatusEnum? INVOICESTATUS
        {
            get { return (MedulaSubEpisodeStatusEnum?)(int?)this["INVOICESTATUS"]; }
            set { this["INVOICESTATUS"] = value; }
        }

    /// <summary>
    /// Epizottaki anlaşmaların ID si
    /// </summary>
        public Guid? SEPOBJECTID
        {
            get { return (Guid?)this["SEPOBJECTID"]; }
            set { this["SEPOBJECTID"] = value; }
        }

        public string SUBEPISODENAME
        {
            get { return (string)this["SUBEPISODENAME"]; }
            set { this["SUBEPISODENAME"] = value; }
        }

    /// <summary>
    /// Alt vaka objectid si
    /// </summary>
        public Guid? SUBEPISODEOBJECTID
        {
            get { return (Guid?)this["SUBEPISODEOBJECTID"]; }
            set { this["SUBEPISODEOBJECTID"] = value; }
        }

    /// <summary>
    /// Anlaşma adı
    /// </summary>
        public string PROTOCOLNAME
        {
            get { return (string)this["PROTOCOLNAME"]; }
            set { this["PROTOCOLNAME"] = value; }
        }

    /// <summary>
    /// Anlaşmanın kurumu
    /// </summary>
        public string PAYERNAME
        {
            get { return (string)this["PAYERNAME"]; }
            set { this["PAYERNAME"] = value; }
        }

    /// <summary>
    /// Açılış Tarihi
    /// </summary>
        public DateTime? CREATIONDATE
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

    /// <summary>
    /// Hasta Kurum Bilgisi Değiştirme ile ilişki
    /// </summary>
        public ProtocolAdding ProtocolAdding
        {
            get { return (ProtocolAdding)((ITTObject)this).GetParent("PROTOCOLADDING"); }
            set { this["PROTOCOLADDING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProtocolAddingDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtocolAddingDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtocolAddingDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtocolAddingDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtocolAddingDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTOCOLADDINGDETAIL", dataRow) { }
        protected ProtocolAddingDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTOCOLADDINGDETAIL", dataRow, isImported) { }
        public ProtocolAddingDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtocolAddingDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtocolAddingDetail() : base() { }

    }
}