
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryGridReferenceValueDefinition")] 

    /// <summary>
    /// Laboratuvar Reference Değer Tanımı
    /// </summary>
    public  partial class LaboratoryGridReferenceValueDefinition : TTDefinitionSet
    {
        public class LaboratoryGridReferenceValueDefinitionList : TTObjectCollection<LaboratoryGridReferenceValueDefinition> { }
                    
        public class ChildLaboratoryGridReferenceValueDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryGridReferenceValueDefinition>
        {
            public ChildLaboratoryGridReferenceValueDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryGridReferenceValueDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kritik Alt Değer
    /// </summary>
        public string CriticalMinValue
        {
            get { return (string)this["CRITICALMINVALUE"]; }
            set { this["CRITICALMINVALUE"] = value; }
        }

    /// <summary>
    /// Üst Sınır Türü
    /// </summary>
        public LaboratoryRangeTypeEnum? MaxRangeType
        {
            get { return (LaboratoryRangeTypeEnum?)(int?)this["MAXRANGETYPE"]; }
            set { this["MAXRANGETYPE"] = value; }
        }

    /// <summary>
    /// Cinsiyet
    /// </summary>
        public SexEnum? Sex
        {
            get { return (SexEnum?)(int?)this["SEX"]; }
            set { this["SEX"] = value; }
        }

    /// <summary>
    /// Alt Sınır Türü
    /// </summary>
        public LaboratoryRangeTypeEnum? MinRangeType
        {
            get { return (LaboratoryRangeTypeEnum?)(int?)this["MINRANGETYPE"]; }
            set { this["MINRANGETYPE"] = value; }
        }

    /// <summary>
    /// Değeri
    /// </summary>
        public string MinRangeValue
        {
            get { return (string)this["MINRANGEVALUE"]; }
            set { this["MINRANGEVALUE"] = value; }
        }

    /// <summary>
    /// Alt Değer
    /// </summary>
        public string MinValue
        {
            get { return (string)this["MINVALUE"]; }
            set { this["MINVALUE"] = value; }
        }

    /// <summary>
    /// Kritik Üst Değer
    /// </summary>
        public string CriticalMaxValue
        {
            get { return (string)this["CRITICALMAXVALUE"]; }
            set { this["CRITICALMAXVALUE"] = value; }
        }

    /// <summary>
    /// Üst Değer
    /// </summary>
        public string MaxValue
        {
            get { return (string)this["MAXVALUE"]; }
            set { this["MAXVALUE"] = value; }
        }

    /// <summary>
    /// Değeri
    /// </summary>
        public string MaxRangeValue
        {
            get { return (string)this["MAXRANGEVALUE"]; }
            set { this["MAXRANGEVALUE"] = value; }
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
    /// Laboratuvar Test Tanımı İlişkisi
    /// </summary>
        public LaboratoryTestDefinition LaboratoryTest
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("LABORATORYTEST"); }
            set { this["LABORATORYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryGridReferenceValueDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryGridReferenceValueDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryGridReferenceValueDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryGridReferenceValueDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryGridReferenceValueDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYGRIDREFERENCEVALUEDEFINITION", dataRow) { }
        protected LaboratoryGridReferenceValueDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYGRIDREFERENCEVALUEDEFINITION", dataRow, isImported) { }
        public LaboratoryGridReferenceValueDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryGridReferenceValueDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryGridReferenceValueDefinition() : base() { }

    }
}