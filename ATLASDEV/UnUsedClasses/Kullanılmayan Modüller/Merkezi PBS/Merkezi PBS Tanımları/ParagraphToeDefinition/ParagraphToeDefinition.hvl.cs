
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ParagraphToeDefinition")] 

    public  partial class ParagraphToeDefinition : TerminologyManagerDef, ITMK
    {
        public class ParagraphToeDefinitionList : TTObjectCollection<ParagraphToeDefinition> { }
                    
        public class ChildParagraphToeDefinitionCollection : TTObject.TTChildObjectCollection<ParagraphToeDefinition>
        {
            public ChildParagraphToeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildParagraphToeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetParagraphToeDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string PARAGRAPHTOECODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARAGRAPHTOECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARAGRAPHTOEDEFINITION"].AllPropertyDefs["PARAGRAPHTOECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MAINTOECODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTOECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTOEDEFINITION"].AllPropertyDefs["MAINTOECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unitenclosurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITENCLOSURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITENCLOSUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEPARTMENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Officename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OFFICEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sectionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECTIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SECTIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetParagraphToeDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetParagraphToeDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetParagraphToeDefinitionList_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetParagraphToeDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string PARAGRAPHTOECODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARAGRAPHTOECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARAGRAPHTOEDEFINITION"].AllPropertyDefs["PARAGRAPHTOECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? MainToeId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MAINTOEID"]);
                }
            }

            public Guid? OfficeId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OFFICEID"]);
                }
            }

            public Guid? SectionId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SECTIONID"]);
                }
            }

            public OLAP_GetParagraphToeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetParagraphToeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetParagraphToeDefinition_Class() : base() { }
        }

        public static BindingList<ParagraphToeDefinition.GetParagraphToeDefinitionList_Class> GetParagraphToeDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PARAGRAPHTOEDEFINITION"].QueryDefs["GetParagraphToeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ParagraphToeDefinition.GetParagraphToeDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ParagraphToeDefinition.GetParagraphToeDefinitionList_Class> GetParagraphToeDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PARAGRAPHTOEDEFINITION"].QueryDefs["GetParagraphToeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ParagraphToeDefinition.GetParagraphToeDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ParagraphToeDefinition.OLAP_GetParagraphToeDefinition_Class> OLAP_GetParagraphToeDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PARAGRAPHTOEDEFINITION"].QueryDefs["OLAP_GetParagraphToeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ParagraphToeDefinition.OLAP_GetParagraphToeDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ParagraphToeDefinition.OLAP_GetParagraphToeDefinition_Class> OLAP_GetParagraphToeDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PARAGRAPHTOEDEFINITION"].QueryDefs["OLAP_GetParagraphToeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ParagraphToeDefinition.OLAP_GetParagraphToeDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public string PARAGRAPHTOECODE
        {
            get { return (string)this["PARAGRAPHTOECODE"]; }
            set { this["PARAGRAPHTOECODE"] = value; }
        }

    /// <summary>
    /// OfficeDefinition
    /// </summary>
        public OfficeDefinition OfficeId
        {
            get { return (OfficeDefinition)((ITTObject)this).GetParent("OFFICEID"); }
            set { this["OFFICEID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// MainToeDefinition
    /// </summary>
        public MainToeDefinition MainToeId
        {
            get { return (MainToeDefinition)((ITTObject)this).GetParent("MAINTOEID"); }
            set { this["MAINTOEID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SectionDefinition
    /// </summary>
        public SectionDefinition SectionId
        {
            get { return (SectionDefinition)((ITTObject)this).GetParent("SECTIONID"); }
            set { this["SECTIONID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ParagraphToeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ParagraphToeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ParagraphToeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ParagraphToeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ParagraphToeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PARAGRAPHTOEDEFINITION", dataRow) { }
        protected ParagraphToeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PARAGRAPHTOEDEFINITION", dataRow, isImported) { }
        public ParagraphToeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ParagraphToeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ParagraphToeDefinition() : base() { }

    }
}