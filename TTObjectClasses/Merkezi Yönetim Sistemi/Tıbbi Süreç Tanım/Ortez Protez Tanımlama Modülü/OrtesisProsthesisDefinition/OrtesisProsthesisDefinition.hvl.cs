
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrtesisProsthesisDefinition")] 

    /// <summary>
    /// Ortez Protez Tanımlama
    /// </summary>
    public  partial class OrtesisProsthesisDefinition : ProcedureDefinition
    {
        public class OrtesisProsthesisDefinitionList : TTObjectCollection<OrtesisProsthesisDefinition> { }
                    
        public class ChildOrtesisProsthesisDefinitionCollection : TTObject.TTChildObjectCollection<OrtesisProsthesisDefinition>
        {
            public ChildOrtesisProsthesisDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrtesisProsthesisDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOrtesisProsthesisDefinitions_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTESISPROSTHESISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTESISPROSTHESISDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTESISPROSTHESISDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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

            public string Warranty
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARRANTY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTESISPROSTHESISDEFINITION"].AllPropertyDefs["WARRANTY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOrtesisProsthesisDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrtesisProsthesisDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrtesisProsthesisDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOrtesisProsthesisDefinitionByID_Class : TTReportNqlObject 
        {
            public string Kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTESISPROSTHESISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTESISPROSTHESISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Defid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEFID"]);
                }
            }

            public GetOrtesisProsthesisDefinitionByID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrtesisProsthesisDefinitionByID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrtesisProsthesisDefinitionByID_Class() : base() { }
        }

        public static BindingList<OrtesisProsthesisDefinition.GetOrtesisProsthesisDefinitions_Class> GetOrtesisProsthesisDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTESISPROSTHESISDEFINITION"].QueryDefs["GetOrtesisProsthesisDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OrtesisProsthesisDefinition.GetOrtesisProsthesisDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OrtesisProsthesisDefinition.GetOrtesisProsthesisDefinitions_Class> GetOrtesisProsthesisDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTESISPROSTHESISDEFINITION"].QueryDefs["GetOrtesisProsthesisDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OrtesisProsthesisDefinition.GetOrtesisProsthesisDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// OrtesisProsthesisDefinition ı objectID ile get eder
    /// </summary>
        public static BindingList<OrtesisProsthesisDefinition.GetOrtesisProsthesisDefinitionByID_Class> GetOrtesisProsthesisDefinitionByID(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTESISPROSTHESISDEFINITION"].QueryDefs["GetOrtesisProsthesisDefinitionByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<OrtesisProsthesisDefinition.GetOrtesisProsthesisDefinitionByID_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// OrtesisProsthesisDefinition ı objectID ile get eder
    /// </summary>
        public static BindingList<OrtesisProsthesisDefinition.GetOrtesisProsthesisDefinitionByID_Class> GetOrtesisProsthesisDefinitionByID(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTESISPROSTHESISDEFINITION"].QueryDefs["GetOrtesisProsthesisDefinitionByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<OrtesisProsthesisDefinition.GetOrtesisProsthesisDefinitionByID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OrtesisProsthesisDefinition> GetOrtesisProsthesisDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTESISPROSTHESISDEFINITION"].QueryDefs["GetOrtesisProsthesisDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<OrtesisProsthesisDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Sağlık Kurulu Tipi
    /// </summary>
        public OrthesisProsthesisHCType? HealthCommitteeType
        {
            get { return (OrthesisProsthesisHCType?)(int?)this["HEALTHCOMMITTEETYPE"]; }
            set { this["HEALTHCOMMITTEETYPE"] = value; }
        }

    /// <summary>
    /// Yön Seçimine Zorla
    /// </summary>
        public bool? SideSelect
        {
            get { return (bool?)this["SIDESELECT"]; }
            set { this["SIDESELECT"] = value; }
        }

    /// <summary>
    /// Garanti Süresi
    /// </summary>
        public string Warranty
        {
            get { return (string)this["WARRANTY"]; }
            set { this["WARRANTY"] = value; }
        }

        public int? DefaultAmount
        {
            get { return (int?)this["DEFAULTAMOUNT"]; }
            set { this["DEFAULTAMOUNT"] = value; }
        }

        virtual protected void CreateMaterialsCollection()
        {
            _Materials = new OrtesisProsthesisMaterialGrid.ChildOrtesisProsthesisMaterialGridCollection(this, new Guid("a8942390-89ff-43b3-b42e-42aac8340f40"));
            ((ITTChildObjectCollection)_Materials).GetChildren();
        }

        protected OrtesisProsthesisMaterialGrid.ChildOrtesisProsthesisMaterialGridCollection _Materials = null;
        public OrtesisProsthesisMaterialGrid.ChildOrtesisProsthesisMaterialGridCollection Materials
        {
            get
            {
                if (_Materials == null)
                    CreateMaterialsCollection();
                return _Materials;
            }
        }

        protected OrtesisProsthesisDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrtesisProsthesisDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrtesisProsthesisDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrtesisProsthesisDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrtesisProsthesisDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORTESISPROSTHESISDEFINITION", dataRow) { }
        protected OrtesisProsthesisDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORTESISPROSTHESISDEFINITION", dataRow, isImported) { }
        public OrtesisProsthesisDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrtesisProsthesisDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrtesisProsthesisDefinition() : base() { }

    }
}