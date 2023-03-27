
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MorgueGivenMaterial")] 

    /// <summary>
    /// Morg Verilen Eşyalar 
    /// </summary>
    public  partial class MorgueGivenMaterial : TTObject
    {
        public class MorgueGivenMaterialList : TTObjectCollection<MorgueGivenMaterial> { }
                    
        public class ChildMorgueGivenMaterialCollection : TTObject.TTChildObjectCollection<MorgueGivenMaterial>
        {
            public ChildMorgueGivenMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMorgueGivenMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Eşya Miktarı
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Tarih/Saat
    /// </summary>
        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
        }

    /// <summary>
    /// Teslim Edilen Eşya Açıklaması
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Verilen Eşyalar
    /// </summary>
        public Morgue Morgue
        {
            get { return (Morgue)((ITTObject)this).GetParent("MORGUE"); }
            set { this["MORGUE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Verilen Eşya Türü
    /// </summary>
        public QuarantineMaterialDefinition MaterialType
        {
            get { return (QuarantineMaterialDefinition)((ITTObject)this).GetParent("MATERIALTYPE"); }
            set { this["MATERIALTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MorgueGivenMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MorgueGivenMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MorgueGivenMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MorgueGivenMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MorgueGivenMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MORGUEGIVENMATERIAL", dataRow) { }
        protected MorgueGivenMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MORGUEGIVENMATERIAL", dataRow, isImported) { }
        public MorgueGivenMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MorgueGivenMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MorgueGivenMaterial() : base() { }

    }
}