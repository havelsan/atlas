
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SUTDefinition")] 

    /// <summary>
    /// SUT Tanımlama
    /// </summary>
    public  partial class SUTDefinition : TerminologyManagerDef
    {
        public class SUTDefinitionList : TTObjectCollection<SUTDefinition> { }
                    
        public class ChildSUTDefinitionCollection : TTObject.TTChildObjectCollection<SUTDefinition>
        {
            public ChildSUTDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSUTDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<SUTDefinition> GetSUTDefinitionByCodeAndExternalID(TTObjectContext objectContext, string CODE, long EXTERNALID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUTDEFINITION"].QueryDefs["GetSUTDefinitionByCodeAndExternalID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);
            paramList.Add("EXTERNALID", EXTERNALID);

            return ((ITTQuery)objectContext).QueryObjects<SUTDefinition>(queryDef, paramList);
        }

        public static BindingList<SUTDefinition> GetSUTDefinitions(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUTDEFINITION"].QueryDefs["GetSUTDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<SUTDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<SUTDefinition> GetSUTDefinitionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUTDEFINITION"].QueryDefs["GetSUTDefinitionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<SUTDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// ID
    /// </summary>
        public long? ID
        {
            get { return (long?)this["ID"]; }
            set { this["ID"] = value; }
        }

    /// <summary>
    /// Üst No
    /// </summary>
        public long? ParentID
        {
            get { return (long?)this["PARENTID"]; }
            set { this["PARENTID"] = value; }
        }

    /// <summary>
    /// Harici Üst ID
    /// </summary>
        public long? ExternalParentID
        {
            get { return (long?)this["EXTERNALPARENTID"]; }
            set { this["EXTERNALPARENTID"] = value; }
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
    /// Türü
    /// </summary>
        public SUTTypeEnum? Type
        {
            get { return (SUTTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Yılı
    /// </summary>
        public int? Year
        {
            get { return (int?)this["YEAR"]; }
            set { this["YEAR"] = value; }
        }

    /// <summary>
    /// Harici ID
    /// </summary>
        public long? ExternalID
        {
            get { return (long?)this["EXTERNALID"]; }
            set { this["EXTERNALID"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Üst Grup
    /// </summary>
        public SUTDefinition ParentGroup
        {
            get { return (SUTDefinition)((ITTObject)this).GetParent("PARENTGROUP"); }
            set { this["PARENTGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSUTDefinitionsCollection()
        {
            _SUTDefinitions = new SUTDefinition.ChildSUTDefinitionCollection(this, new Guid("9b62bc3a-7714-4f66-b343-a012894a2403"));
            ((ITTChildObjectCollection)_SUTDefinitions).GetChildren();
        }

        protected SUTDefinition.ChildSUTDefinitionCollection _SUTDefinitions = null;
    /// <summary>
    /// Child collection for Üst Grup
    /// </summary>
        public SUTDefinition.ChildSUTDefinitionCollection SUTDefinitions
        {
            get
            {
                if (_SUTDefinitions == null)
                    CreateSUTDefinitionsCollection();
                return _SUTDefinitions;
            }
        }

        virtual protected void CreateCPT4DefinitionsCollection()
        {
            _CPT4Definitions = new MatchingCPT4AndSUTDefinitions.ChildMatchingCPT4AndSUTDefinitionsCollection(this, new Guid("6a71e56a-e0ea-4712-bd6d-fdf851c77b7a"));
            ((ITTChildObjectCollection)_CPT4Definitions).GetChildren();
        }

        protected MatchingCPT4AndSUTDefinitions.ChildMatchingCPT4AndSUTDefinitionsCollection _CPT4Definitions = null;
    /// <summary>
    /// Child collection for SUT Hizmeti
    /// </summary>
        public MatchingCPT4AndSUTDefinitions.ChildMatchingCPT4AndSUTDefinitionsCollection CPT4Definitions
        {
            get
            {
                if (_CPT4Definitions == null)
                    CreateCPT4DefinitionsCollection();
                return _CPT4Definitions;
            }
        }

        protected SUTDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SUTDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SUTDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SUTDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SUTDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUTDEFINITION", dataRow) { }
        protected SUTDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUTDEFINITION", dataRow, isImported) { }
        public SUTDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SUTDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SUTDefinition() : base() { }

    }
}