
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CPT4Definition")] 

    /// <summary>
    /// CPT4 Tanımları
    /// </summary>
    public  partial class CPT4Definition : TerminologyManagerDef, ITTListTreeObject
    {
        public class CPT4DefinitionList : TTObjectCollection<CPT4Definition> { }
                    
        public class ChildCPT4DefinitionCollection : TTObject.TTChildObjectCollection<CPT4Definition>
        {
            public ChildCPT4DefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCPT4DefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCPT4Definitions_Class : TTReportNqlObject 
        {
            public string CPTCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CPTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CPT4DEFINITION"].AllPropertyDefs["CPTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OriginalName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORIGINALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CPT4DEFINITION"].AllPropertyDefs["ORIGINALNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CPT4DEFINITION"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TurkishName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TURKISHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CPT4DEFINITION"].AllPropertyDefs["TURKISHNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EnglishName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENGLISHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CPT4DEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetCPT4Definitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCPT4Definitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCPT4Definitions_Class() : base() { }
        }

        public static BindingList<CPT4Definition.GetCPT4Definitions_Class> GetCPT4Definitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CPT4DEFINITION"].QueryDefs["GetCPT4Definitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CPT4Definition.GetCPT4Definitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CPT4Definition.GetCPT4Definitions_Class> GetCPT4Definitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CPT4DEFINITION"].QueryDefs["GetCPT4Definitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CPT4Definition.GetCPT4Definitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CPT4Definition> GetCPT4DefinitionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CPT4DEFINITION"].QueryDefs["GetCPT4DefinitionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<CPT4Definition>(queryDef, paramList);
        }

    /// <summary>
    /// IsLeaf
    /// </summary>
        public bool? IsLeaf
        {
            get { return (bool?)this["ISLEAF"]; }
            set { this["ISLEAF"] = value; }
        }

        public string OriginalName_Shadow
        {
            get { return (string)this["ORIGINALNAME_SHADOW"]; }
        }

    /// <summary>
    /// CPT4 Kodu
    /// </summary>
        public string CPTCode
        {
            get { return (string)this["CPTCODE"]; }
            set { this["CPTCODE"] = value; }
        }

    /// <summary>
    /// Orjinal Adı
    /// </summary>
        public string OriginalName
        {
            get { return (string)this["ORIGINALNAME"]; }
            set { this["ORIGINALNAME"] = value; }
        }

    /// <summary>
    /// Kısa Adı
    /// </summary>
        public string Qref
        {
            get { return (string)this["QREF"]; }
            set { this["QREF"] = value; }
        }

    /// <summary>
    /// Türkçe Adı
    /// </summary>
        public string TurkishName
        {
            get { return (string)this["TURKISHNAME"]; }
            set { this["TURKISHNAME"] = value; }
        }

    /// <summary>
    /// HuyAnkMevDB den alındı
    /// </summary>
        public long? MprocedureID
        {
            get { return (long?)this["MPROCEDUREID"]; }
            set { this["MPROCEDUREID"] = value; }
        }

    /// <summary>
    /// İngilizce Adı
    /// </summary>
        public string EnglishName
        {
            get { return (string)this["ENGLISHNAME"]; }
            set { this["ENGLISHNAME"] = value; }
        }

        public ProcedureTypeDefinition ProcedureType
        {
            get { return (ProcedureTypeDefinition)((ITTObject)this).GetParent("PROCEDURETYPE"); }
            set { this["PROCEDURETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSUTDefinitionsCollection()
        {
            _SUTDefinitions = new MatchingCPT4AndSUTDefinitions.ChildMatchingCPT4AndSUTDefinitionsCollection(this, new Guid("10977417-6286-491a-85cc-e342efb3e328"));
            ((ITTChildObjectCollection)_SUTDefinitions).GetChildren();
        }

        protected MatchingCPT4AndSUTDefinitions.ChildMatchingCPT4AndSUTDefinitionsCollection _SUTDefinitions = null;
    /// <summary>
    /// Child collection for CPT4 Hizmeti
    /// </summary>
        public MatchingCPT4AndSUTDefinitions.ChildMatchingCPT4AndSUTDefinitionsCollection SUTDefinitions
        {
            get
            {
                if (_SUTDefinitions == null)
                    CreateSUTDefinitionsCollection();
                return _SUTDefinitions;
            }
        }

        protected CPT4Definition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CPT4Definition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CPT4Definition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CPT4Definition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CPT4Definition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CPT4DEFINITION", dataRow) { }
        protected CPT4Definition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CPT4DEFINITION", dataRow, isImported) { }
        public CPT4Definition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CPT4Definition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CPT4Definition() : base() { }

    }
}