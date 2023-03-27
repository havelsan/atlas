
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SpecificationDefinition")] 

    /// <summary>
    /// Şartname Tanımı
    /// </summary>
    public  partial class SpecificationDefinition : TerminologyManagerDef
    {
        public class SpecificationDefinitionList : TTObjectCollection<SpecificationDefinition> { }
                    
        public class ChildSpecificationDefinitionCollection : TTObject.TTChildObjectCollection<SpecificationDefinition>
        {
            public ChildSpecificationDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSpecificationDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class SDDefinitionFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public SpecificationCategoryEnum? Category
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CATEGORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIFICATIONDEFINITION"].AllPropertyDefs["CATEGORY"].DataType;
                    return (SpecificationCategoryEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIFICATIONDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIFICATIONDEFINITION"].AllPropertyDefs["DATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIFICATIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string No
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIFICATIONDEFINITION"].AllPropertyDefs["NO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SDDefinitionFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SDDefinitionFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SDDefinitionFormNQL_Class() : base() { }
        }

        public static BindingList<SpecificationDefinition.SDDefinitionFormNQL_Class> SDDefinitionFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIFICATIONDEFINITION"].QueryDefs["SDDefinitionFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SpecificationDefinition.SDDefinitionFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SpecificationDefinition.SDDefinitionFormNQL_Class> SDDefinitionFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIFICATIONDEFINITION"].QueryDefs["SDDefinitionFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SpecificationDefinition.SDDefinitionFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SpecificationDefinition> GetSpecificationDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIFICATIONDEFINITION"].QueryDefs["GetSpecificationDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<SpecificationDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// No
    /// </summary>
        public string No
        {
            get { return (string)this["NO"]; }
            set { this["NO"] = value; }
        }

    /// <summary>
    /// Kategori
    /// </summary>
        public SpecificationCategoryEnum? Category
        {
            get { return (SpecificationCategoryEnum?)(int?)this["CATEGORY"]; }
            set { this["CATEGORY"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

        public string No_Shadow
        {
            get { return (string)this["NO_SHADOW"]; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        virtual protected void CreateSpecificationClausesCollection()
        {
            _SpecificationClauses = new SpecificationClause.ChildSpecificationClauseCollection(this, new Guid("36e913af-b8c5-42cd-a416-672958693986"));
            ((ITTChildObjectCollection)_SpecificationClauses).GetChildren();
        }

        protected SpecificationClause.ChildSpecificationClauseCollection _SpecificationClauses = null;
        public SpecificationClause.ChildSpecificationClauseCollection SpecificationClauses
        {
            get
            {
                if (_SpecificationClauses == null)
                    CreateSpecificationClausesCollection();
                return _SpecificationClauses;
            }
        }

        protected SpecificationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SpecificationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SpecificationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SpecificationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SpecificationDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SPECIFICATIONDEFINITION", dataRow) { }
        protected SpecificationDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SPECIFICATIONDEFINITION", dataRow, isImported) { }
        public SpecificationDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SpecificationDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SpecificationDefinition() : base() { }

    }
}