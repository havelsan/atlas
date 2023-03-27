
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralPreparationDetail")] 

    /// <summary>
    /// Üretilen Majistral Sekmesi
    /// </summary>
    public  partial class MagistralPreparationDetail : TTObject
    {
        public class MagistralPreparationDetailList : TTObjectCollection<MagistralPreparationDetail> { }
                    
        public class ChildMagistralPreparationDetailCollection : TTObject.TTChildObjectCollection<MagistralPreparationDetail>
        {
            public ChildMagistralPreparationDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralPreparationDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Son Kullanma Tarihi
    /// </summary>
        public DateTime? ExpirationDate
        {
            get { return (DateTime?)this["EXPIRATIONDATE"]; }
            set { this["EXPIRATIONDATE"] = value; }
        }

        public MagistralPreparationDefinition MagistralPreparationDef
        {
            get { return (MagistralPreparationDefinition)((ITTObject)this).GetParent("MAGISTRALPREPARATIONDEF"); }
            set { this["MAGISTRALPREPARATIONDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MagistralPreparationAction MagistralPreparationAction
        {
            get { return (MagistralPreparationAction)((ITTObject)this).GetParent("MAGISTRALPREPARATIONACTION"); }
            set { this["MAGISTRALPREPARATIONACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MagistralPreparationDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralPreparationDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralPreparationDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralPreparationDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralPreparationDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALPREPARATIONDETAIL", dataRow) { }
        protected MagistralPreparationDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALPREPARATIONDETAIL", dataRow, isImported) { }
        public MagistralPreparationDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralPreparationDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralPreparationDetail() : base() { }

    }
}