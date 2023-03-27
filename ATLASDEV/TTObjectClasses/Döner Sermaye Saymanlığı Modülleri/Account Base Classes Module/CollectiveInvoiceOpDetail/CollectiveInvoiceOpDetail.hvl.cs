
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CollectiveInvoiceOpDetail")] 

    /// <summary>
    /// Fatura ekranındaki toplu işlemlerin detay objesi
    /// </summary>
    public  partial class CollectiveInvoiceOpDetail : TTObject
    {
        public class CollectiveInvoiceOpDetailList : TTObjectCollection<CollectiveInvoiceOpDetail> { }
                    
        public class ChildCollectiveInvoiceOpDetailCollection : TTObject.TTChildObjectCollection<CollectiveInvoiceOpDetail>
        {
            public ChildCollectiveInvoiceOpDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCollectiveInvoiceOpDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("8f5dddcb-31dc-4115-a088-530a147357ea"); } }
    /// <summary>
    /// Başarılı
    /// </summary>
            public static Guid Succes { get { return new Guid("274a02d7-2000-4f2c-be20-7176ea02a801"); } }
    /// <summary>
    /// Hatalı
    /// </summary>
            public static Guid Error { get { return new Guid("19b7ac31-e18f-4b34-a092-4934fce40dba"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancel { get { return new Guid("836da46d-29e2-4131-84c6-987a96c92f2e"); } }
        }

    /// <summary>
    /// Çalışacak Obje
    /// </summary>
        public Guid? ExecObjectID
        {
            get { return (Guid?)this["EXECOBJECTID"]; }
            set { this["EXECOBJECTID"] = value; }
        }

    /// <summary>
    /// Çalışacak Obje Tipi
    /// </summary>
        public string ExecObjectType
        {
            get { return (string)this["EXECOBJECTTYPE"]; }
            set { this["EXECOBJECTTYPE"] = value; }
        }

    /// <summary>
    /// Çalışma Zamanı
    /// </summary>
        public DateTime? ExecDate
        {
            get { return (DateTime?)this["EXECDATE"]; }
            set { this["EXECDATE"] = value; }
        }

    /// <summary>
    /// Hata Kodu
    /// </summary>
        public string ErrorCode
        {
            get { return (string)this["ERRORCODE"]; }
            set { this["ERRORCODE"] = value; }
        }

    /// <summary>
    /// Hata Mesajı
    /// </summary>
        public string ErrorMessage
        {
            get { return (string)this["ERRORMESSAGE"]; }
            set { this["ERRORMESSAGE"] = value; }
        }

        public string MedulaTakipNo
        {
            get { return (string)this["MEDULATAKIPNO"]; }
            set { this["MEDULATAKIPNO"] = value; }
        }

        public string ProtocolNo
        {
            get { return (string)this["PROTOCOLNO"]; }
            set { this["PROTOCOLNO"] = value; }
        }

    /// <summary>
    /// CollectiveInvoiceOp
    /// </summary>
        public CollectiveInvoiceOp CollectiveInvoiceOp
        {
            get { return (CollectiveInvoiceOp)((ITTObject)this).GetParent("COLLECTIVEINVOICEOP"); }
            set { this["COLLECTIVEINVOICEOP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CollectiveInvoiceOpDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CollectiveInvoiceOpDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CollectiveInvoiceOpDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CollectiveInvoiceOpDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CollectiveInvoiceOpDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COLLECTIVEINVOICEOPDETAIL", dataRow) { }
        protected CollectiveInvoiceOpDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COLLECTIVEINVOICEOPDETAIL", dataRow, isImported) { }
        public CollectiveInvoiceOpDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CollectiveInvoiceOpDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CollectiveInvoiceOpDetail() : base() { }

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