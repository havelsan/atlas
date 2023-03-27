
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSTemplateLine")] 

    /// <summary>
    /// Fiş Tanımlama Satırı
    /// </summary>
    public  partial class MhSTemplateLine : TTObject
    {
        public class MhSTemplateLineList : TTObjectCollection<MhSTemplateLine> { }
                    
        public class ChildMhSTemplateLineCollection : TTObject.TTChildObjectCollection<MhSTemplateLine>
        {
            public ChildMhSTemplateLineCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSTemplateLineCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sıra
    /// </summary>
        public int? Order
        {
            get { return (int?)this["ORDER"]; }
            set { this["ORDER"] = value; }
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
    /// Açıklama
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

    /// <summary>
    /// Formül
    /// </summary>
        public string Formula
        {
            get { return (string)this["FORMULA"]; }
            set { this["FORMULA"] = value; }
        }

    /// <summary>
    /// Şablon Satırları
    /// </summary>
        public MhSTemplate Template
        {
            get { return (MhSTemplate)((ITTObject)this).GetParent("TEMPLATE"); }
            set { this["TEMPLATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSTemplateLine(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSTemplateLine(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSTemplateLine(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSTemplateLine(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSTemplateLine(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSTEMPLATELINE", dataRow) { }
        protected MhSTemplateLine(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSTEMPLATELINE", dataRow, isImported) { }
        public MhSTemplateLine(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSTemplateLine(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSTemplateLine() : base() { }

    }
}