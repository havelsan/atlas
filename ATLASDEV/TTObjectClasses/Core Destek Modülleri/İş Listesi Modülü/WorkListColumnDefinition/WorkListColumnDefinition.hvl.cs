
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WorkListColumnDefinition")] 

    public  partial class WorkListColumnDefinition : TerminologyManagerDef
    {
        public class WorkListColumnDefinitionList : TTObjectCollection<WorkListColumnDefinition> { }
                    
        public class ChildWorkListColumnDefinitionCollection : TTObject.TTChildObjectCollection<WorkListColumnDefinition>
        {
            public ChildWorkListColumnDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWorkListColumnDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Teklik
    /// </summary>
        public bool? IsUnique
        {
            get { return (bool?)this["ISUNIQUE"]; }
            set { this["ISUNIQUE"] = value; }
        }

    /// <summary>
    /// Tip Adı
    /// </summary>
        public string TypeName
        {
            get { return (string)this["TYPENAME"]; }
            set { this["TYPENAME"] = value; }
        }

    /// <summary>
    /// Görünür
    /// </summary>
        public bool? IsVisible
        {
            get { return (bool?)this["ISVISIBLE"]; }
            set { this["ISVISIBLE"] = value; }
        }

    /// <summary>
    /// Üye Adı
    /// </summary>
        public string MemberName
        {
            get { return (string)this["MEMBERNAME"]; }
            set { this["MEMBERNAME"] = value; }
        }

    /// <summary>
    /// Başlık
    /// </summary>
        public string Caption
        {
            get { return (string)this["CAPTION"]; }
            set { this["CAPTION"] = value; }
        }

    /// <summary>
    /// Sırası
    /// </summary>
        public int? ColumnOrder
        {
            get { return (int?)this["COLUMNORDER"]; }
            set { this["COLUMNORDER"] = value; }
        }

    /// <summary>
    /// Enum
    /// </summary>
        public bool? IsEnum
        {
            get { return (bool?)this["ISENUM"]; }
            set { this["ISENUM"] = value; }
        }

    /// <summary>
    /// Tarih Formatı
    /// </summary>
        public string DateFormat
        {
            get { return (string)this["DATEFORMAT"]; }
            set { this["DATEFORMAT"] = value; }
        }

    /// <summary>
    /// Genişlik
    /// </summary>
        public int? ColumnWidth
        {
            get { return (int?)this["COLUMNWIDTH"]; }
            set { this["COLUMNWIDTH"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string ColumnName
        {
            get { return (string)this["COLUMNNAME"]; }
            set { this["COLUMNNAME"] = value; }
        }

    /// <summary>
    /// Object
    /// </summary>
        public bool? IsObject
        {
            get { return (bool?)this["ISOBJECT"]; }
            set { this["ISOBJECT"] = value; }
        }

        public WorkListDefinition ColumnDefinition
        {
            get { return (WorkListDefinition)((ITTObject)this).GetParent("COLUMNDEFINITION"); }
            set { this["COLUMNDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateWorklistColumnConditionsCollection()
        {
            _WorklistColumnConditions = new WorklistColumnCondition.ChildWorklistColumnConditionCollection(this, new Guid("b48cd805-0b84-4c02-83f0-db43ae2d0c48"));
            ((ITTChildObjectCollection)_WorklistColumnConditions).GetChildren();
        }

        protected WorklistColumnCondition.ChildWorklistColumnConditionCollection _WorklistColumnConditions = null;
        public WorklistColumnCondition.ChildWorklistColumnConditionCollection WorklistColumnConditions
        {
            get
            {
                if (_WorklistColumnConditions == null)
                    CreateWorklistColumnConditionsCollection();
                return _WorklistColumnConditions;
            }
        }

        protected WorkListColumnDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WorkListColumnDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WorkListColumnDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WorkListColumnDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WorkListColumnDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WORKLISTCOLUMNDEFINITION", dataRow) { }
        protected WorkListColumnDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WORKLISTCOLUMNDEFINITION", dataRow, isImported) { }
        public WorkListColumnDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WorkListColumnDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WorkListColumnDefinition() : base() { }

    }
}