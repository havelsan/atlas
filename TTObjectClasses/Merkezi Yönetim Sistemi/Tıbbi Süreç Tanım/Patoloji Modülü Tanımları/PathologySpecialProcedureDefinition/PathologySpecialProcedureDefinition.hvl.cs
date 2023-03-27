
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologySpecialProcedureDefinition")] 

    /// <summary>
    /// Patoloji Modülü Tanımları
    /// </summary>
    public  partial class PathologySpecialProcedureDefinition : ProcedureDefinition
    {
        public class PathologySpecialProcedureDefinitionList : TTObjectCollection<PathologySpecialProcedureDefinition> { }
                    
        public class ChildPathologySpecialProcedureDefinitionCollection : TTObject.TTChildObjectCollection<PathologySpecialProcedureDefinition>
        {
            public ChildPathologySpecialProcedureDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologySpecialProcedureDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PathologySpecialProcedureDefFormNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYSPECIALPROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYSPECIALPROCEDUREDEFINITION"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PathologySpecialProcedureDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologySpecialProcedureDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologySpecialProcedureDefFormNQL_Class() : base() { }
        }

        public static BindingList<PathologySpecialProcedureDefinition.PathologySpecialProcedureDefFormNQL_Class> PathologySpecialProcedureDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYSPECIALPROCEDUREDEFINITION"].QueryDefs["PathologySpecialProcedureDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologySpecialProcedureDefinition.PathologySpecialProcedureDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologySpecialProcedureDefinition.PathologySpecialProcedureDefFormNQL_Class> PathologySpecialProcedureDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYSPECIALPROCEDUREDEFINITION"].QueryDefs["PathologySpecialProcedureDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologySpecialProcedureDefinition.PathologySpecialProcedureDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Patoloji Özel İşlem Tipi Tanım İlişkisi
    /// </summary>
        public PathologySpecialProcedureTypeDefinition SpecialProcedureTypeTree
        {
            get { return (PathologySpecialProcedureTypeDefinition)((ITTObject)this).GetParent("SPECIALPROCEDURETYPETREE"); }
            set { this["SPECIALPROCEDURETYPETREE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTypesCollection()
        {
            _Types = new PathologyGridSpecialProcedureDefinition.ChildPathologyGridSpecialProcedureDefinitionCollection(this, new Guid("aa38b225-c72d-4572-a20d-3d832be831f0"));
            ((ITTChildObjectCollection)_Types).GetChildren();
        }

        protected PathologyGridSpecialProcedureDefinition.ChildPathologyGridSpecialProcedureDefinitionCollection _Types = null;
    /// <summary>
    /// Child collection for Patoloji Özel İşlem Tanım İlişkisi
    /// </summary>
        public PathologyGridSpecialProcedureDefinition.ChildPathologyGridSpecialProcedureDefinitionCollection Types
        {
            get
            {
                if (_Types == null)
                    CreateTypesCollection();
                return _Types;
            }
        }

        virtual protected void CreateSpecialProcedureCollection()
        {
            _SpecialProcedure = new PathologySpecialProcedure.ChildPathologySpecialProcedureCollection(this, new Guid("32920287-becb-433e-8fc7-9d10a010ca08"));
            ((ITTChildObjectCollection)_SpecialProcedure).GetChildren();
        }

        protected PathologySpecialProcedure.ChildPathologySpecialProcedureCollection _SpecialProcedure = null;
    /// <summary>
    /// Child collection for Patoloji Özel Hizmet Tanımı İlişkisi
    /// </summary>
        public PathologySpecialProcedure.ChildPathologySpecialProcedureCollection SpecialProcedure
        {
            get
            {
                if (_SpecialProcedure == null)
                    CreateSpecialProcedureCollection();
                return _SpecialProcedure;
            }
        }

        protected PathologySpecialProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologySpecialProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologySpecialProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologySpecialProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologySpecialProcedureDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYSPECIALPROCEDUREDEFINITION", dataRow) { }
        protected PathologySpecialProcedureDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYSPECIALPROCEDUREDEFINITION", dataRow, isImported) { }
        public PathologySpecialProcedureDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologySpecialProcedureDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologySpecialProcedureDefinition() : base() { }

    }
}