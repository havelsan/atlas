
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SkinPrickTestDetail")] 

    /// <summary>
    /// Deri Prick Test Detayları
    /// </summary>
    public  partial class SkinPrickTestDetail : TTObject
    {
        public class SkinPrickTestDetailList : TTObjectCollection<SkinPrickTestDetail> { }
                    
        public class ChildSkinPrickTestDetailCollection : TTObject.TTChildObjectCollection<SkinPrickTestDetail>
        {
            public ChildSkinPrickTestDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSkinPrickTestDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Negatif
    /// </summary>
        public bool? Negative
        {
            get { return (bool?)this["NEGATIVE"]; }
            set { this["NEGATIVE"] = value; }
        }

    /// <summary>
    /// Pozitif
    /// </summary>
        public bool? Positive
        {
            get { return (bool?)this["POSITIVE"]; }
            set { this["POSITIVE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public SkinPrickTestResult SkinPrickTestResult
        {
            get { return (SkinPrickTestResult)((ITTObject)this).GetParent("SKINPRICKTESTRESULT"); }
            set { this["SKINPRICKTESTRESULT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseAdditionalApplication BaseAdditionalApplication
        {
            get { return (BaseAdditionalApplication)((ITTObject)this).GetParent("BASEADDITIONALAPPLICATION"); }
            set { this["BASEADDITIONALAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SkinPrickTestDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SkinPrickTestDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SkinPrickTestDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SkinPrickTestDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SkinPrickTestDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKINPRICKTESTDETAIL", dataRow) { }
        protected SkinPrickTestDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKINPRICKTESTDETAIL", dataRow, isImported) { }
        public SkinPrickTestDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SkinPrickTestDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SkinPrickTestDetail() : base() { }

    }
}