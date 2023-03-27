
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologySpecialProcedureTypeDefinition")] 

    /// <summary>
    /// Patoloji Özel İşlem Tür Tanımı
    /// </summary>
    public  partial class PathologySpecialProcedureTypeDefinition : TerminologyManagerDef
    {
        public class PathologySpecialProcedureTypeDefinitionList : TTObjectCollection<PathologySpecialProcedureTypeDefinition> { }
                    
        public class ChildPathologySpecialProcedureTypeDefinitionCollection : TTObject.TTChildObjectCollection<PathologySpecialProcedureTypeDefinition>
        {
            public ChildPathologySpecialProcedureTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologySpecialProcedureTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PathologySpecialProcedureTypeDefFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYSPECIALPROCEDURETYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PathologySpecialProcedureTypeDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologySpecialProcedureTypeDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologySpecialProcedureTypeDefFormNQL_Class() : base() { }
        }

        public static BindingList<PathologySpecialProcedureTypeDefinition.PathologySpecialProcedureTypeDefFormNQL_Class> PathologySpecialProcedureTypeDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYSPECIALPROCEDURETYPEDEFINITION"].QueryDefs["PathologySpecialProcedureTypeDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologySpecialProcedureTypeDefinition.PathologySpecialProcedureTypeDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologySpecialProcedureTypeDefinition.PathologySpecialProcedureTypeDefFormNQL_Class> PathologySpecialProcedureTypeDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYSPECIALPROCEDURETYPEDEFINITION"].QueryDefs["PathologySpecialProcedureTypeDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologySpecialProcedureTypeDefinition.PathologySpecialProcedureTypeDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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
    /// Patoloji Özel İşlem Tipi Tanım İlişkisi
    /// </summary>
        public PathologySpecialProcedureTypeDefinition ParentSpecialTypeTree
        {
            get { return (PathologySpecialProcedureTypeDefinition)((ITTObject)this).GetParent("PARENTSPECIALTYPETREE"); }
            set { this["PARENTSPECIALTYPETREE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePathologySpecialProcedureDefinitionsCollection()
        {
            _PathologySpecialProcedureDefinitions = new PathologySpecialProcedureDefinition.ChildPathologySpecialProcedureDefinitionCollection(this, new Guid("1145fac2-3c74-442a-b0d5-65fc7a013972"));
            ((ITTChildObjectCollection)_PathologySpecialProcedureDefinitions).GetChildren();
        }

        protected PathologySpecialProcedureDefinition.ChildPathologySpecialProcedureDefinitionCollection _PathologySpecialProcedureDefinitions = null;
    /// <summary>
    /// Child collection for Patoloji Özel İşlem Tipi Tanım İlişkisi
    /// </summary>
        public PathologySpecialProcedureDefinition.ChildPathologySpecialProcedureDefinitionCollection PathologySpecialProcedureDefinitions
        {
            get
            {
                if (_PathologySpecialProcedureDefinitions == null)
                    CreatePathologySpecialProcedureDefinitionsCollection();
                return _PathologySpecialProcedureDefinitions;
            }
        }

        protected PathologySpecialProcedureTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologySpecialProcedureTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologySpecialProcedureTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologySpecialProcedureTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologySpecialProcedureTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYSPECIALPROCEDURETYPEDEFINITION", dataRow) { }
        protected PathologySpecialProcedureTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYSPECIALPROCEDURETYPEDEFINITION", dataRow, isImported) { }
        public PathologySpecialProcedureTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologySpecialProcedureTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologySpecialProcedureTypeDefinition() : base() { }

    }
}