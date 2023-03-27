
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseQuarantineValuableMaterial")] 

    /// <summary>
    /// Değerli Eşyalar
    /// </summary>
    public  partial class BaseQuarantineValuableMaterial : TTObject
    {
        public class BaseQuarantineValuableMaterialList : TTObjectCollection<BaseQuarantineValuableMaterial> { }
                    
        public class ChildBaseQuarantineValuableMaterialCollection : TTObject.TTChildObjectCollection<BaseQuarantineValuableMaterial>
        {
            public ChildBaseQuarantineValuableMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseQuarantineValuableMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
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
    /// Teslim Alan
    /// </summary>
        public string PersonWhoTakeMaterials
        {
            get { return (string)this["PERSONWHOTAKEMATERIALS"]; }
            set { this["PERSONWHOTAKEMATERIALS"] = value; }
        }

    /// <summary>
    /// Karantina işlem Türü
    /// </summary>
        public QuarantineProcessTypeEnum? QuarantineProcessType
        {
            get { return (QuarantineProcessTypeEnum?)(int?)this["QUARANTINEPROCESSTYPE"]; }
            set { this["QUARANTINEPROCESSTYPE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Teslim Eden
    /// </summary>
        public string PersonWhoGiveMaterials
        {
            get { return (string)this["PERSONWHOGIVEMATERIALS"]; }
            set { this["PERSONWHOGIVEMATERIALS"] = value; }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseQuarantineValuableMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseQuarantineValuableMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseQuarantineValuableMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseQuarantineValuableMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseQuarantineValuableMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEQUARANTINEVALUABLEMATERIAL", dataRow) { }
        protected BaseQuarantineValuableMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEQUARANTINEVALUABLEMATERIAL", dataRow, isImported) { }
        public BaseQuarantineValuableMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseQuarantineValuableMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseQuarantineValuableMaterial() : base() { }

    }
}