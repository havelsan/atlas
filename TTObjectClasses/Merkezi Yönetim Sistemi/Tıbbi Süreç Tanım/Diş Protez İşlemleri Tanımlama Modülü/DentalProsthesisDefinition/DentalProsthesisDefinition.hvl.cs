
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalProsthesisDefinition")] 

    /// <summary>
    /// Diş Protez İşlemleri Tanımlama
    /// </summary>
    public  partial class DentalProsthesisDefinition : ProcedureDefinition
    {
        public class DentalProsthesisDefinitionList : TTObjectCollection<DentalProsthesisDefinition> { }
                    
        public class ChildDentalProsthesisDefinitionCollection : TTObject.TTChildObjectCollection<DentalProsthesisDefinition>
        {
            public ChildDentalProsthesisDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalProsthesisDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDentalProsthesisDefinition_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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

            public GetDentalProsthesisDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDentalProsthesisDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDentalProsthesisDefinition_Class() : base() { }
        }

        public static BindingList<DentalProsthesisDefinition> GetDentalProsthesisDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISDEFINITION"].QueryDefs["GetDentalProsthesisDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DentalProsthesisDefinition>(queryDef, paramList);
        }

        public static BindingList<DentalProsthesisDefinition.GetDentalProsthesisDefinition_Class> GetDentalProsthesisDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISDEFINITION"].QueryDefs["GetDentalProsthesisDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalProsthesisDefinition.GetDentalProsthesisDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DentalProsthesisDefinition.GetDentalProsthesisDefinition_Class> GetDentalProsthesisDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROSTHESISDEFINITION"].QueryDefs["GetDentalProsthesisDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalProsthesisDefinition.GetDentalProsthesisDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateDepartmentsCollection()
        {
            _Departments = new DentalProsthesisDepartmentGrid.ChildDentalProsthesisDepartmentGridCollection(this, new Guid("1e801ebe-a7cd-44f6-a9cd-95e7d22b84ae"));
            ((ITTChildObjectCollection)_Departments).GetChildren();
        }

        protected DentalProsthesisDepartmentGrid.ChildDentalProsthesisDepartmentGridCollection _Departments = null;
    /// <summary>
    /// Child collection for Diş Protez Birimleri
    /// </summary>
        public DentalProsthesisDepartmentGrid.ChildDentalProsthesisDepartmentGridCollection Departments
        {
            get
            {
                if (_Departments == null)
                    CreateDepartmentsCollection();
                return _Departments;
            }
        }

        protected DentalProsthesisDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalProsthesisDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalProsthesisDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalProsthesisDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalProsthesisDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALPROSTHESISDEFINITION", dataRow) { }
        protected DentalProsthesisDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALPROSTHESISDEFINITION", dataRow, isImported) { }
        public DentalProsthesisDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalProsthesisDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalProsthesisDefinition() : base() { }

    }
}