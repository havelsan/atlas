
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalResarchTermDef")] 

    public  partial class MedicalResarchTermDef : TerminologyManagerDef
    {
        public class MedicalResarchTermDefList : TTObjectCollection<MedicalResarchTermDef> { }
                    
        public class ChildMedicalResarchTermDefCollection : TTObject.TTChildObjectCollection<MedicalResarchTermDef>
        {
            public ChildMedicalResarchTermDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalResarchTermDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedicalResarchTermDefList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string TermName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TERMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCHTERMDEF"].AllPropertyDefs["TERMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCHTERMDEF"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCHTERMDEF"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string TermCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TERMCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCHTERMDEF"].AllPropertyDefs["TERMCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMedicalResarchTermDefList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalResarchTermDefList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalResarchTermDefList_Class() : base() { }
        }

        public static BindingList<MedicalResarchTermDef.GetMedicalResarchTermDefList_Class> GetMedicalResarchTermDefList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCHTERMDEF"].QueryDefs["GetMedicalResarchTermDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalResarchTermDef.GetMedicalResarchTermDefList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalResarchTermDef.GetMedicalResarchTermDefList_Class> GetMedicalResarchTermDefList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCHTERMDEF"].QueryDefs["GetMedicalResarchTermDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalResarchTermDef.GetMedicalResarchTermDefList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string TermName
        {
            get { return (string)this["TERMNAME"]; }
            set { this["TERMNAME"] = value; }
        }

        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        public string TermCode
        {
            get { return (string)this["TERMCODE"]; }
            set { this["TERMCODE"] = value; }
        }

        public BigCurrency? TermBudgetPrice
        {
            get { return (BigCurrency?)this["TERMBUDGETPRICE"]; }
            set { this["TERMBUDGETPRICE"] = value; }
        }

        public string Desciption
        {
            get { return (string)this["DESCIPTION"]; }
            set { this["DESCIPTION"] = value; }
        }

        protected MedicalResarchTermDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalResarchTermDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalResarchTermDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalResarchTermDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalResarchTermDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALRESARCHTERMDEF", dataRow) { }
        protected MedicalResarchTermDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALRESARCHTERMDEF", dataRow, isImported) { }
        public MedicalResarchTermDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalResarchTermDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalResarchTermDef() : base() { }

    }
}