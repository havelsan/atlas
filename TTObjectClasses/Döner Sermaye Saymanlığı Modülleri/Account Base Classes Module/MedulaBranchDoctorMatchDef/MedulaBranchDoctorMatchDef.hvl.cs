
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaBranchDoctorMatchDef")] 

    /// <summary>
    /// Medula Branş Doktor Eşleştirme Tanımı
    /// </summary>
    public  partial class MedulaBranchDoctorMatchDef : TerminologyManagerDef
    {
        public class MedulaBranchDoctorMatchDefList : TTObjectCollection<MedulaBranchDoctorMatchDef> { }
                    
        public class ChildMedulaBranchDoctorMatchDefCollection : TTObject.TTChildObjectCollection<MedulaBranchDoctorMatchDef>
        {
            public ChildMedulaBranchDoctorMatchDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaBranchDoctorMatchDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedulaBranchDoctorMatchDefs_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Branchcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRANCHCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Branchname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRANCHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DiplomaRegisterNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPLOMAREGISTERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMAREGISTERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMedulaBranchDoctorMatchDefs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaBranchDoctorMatchDefs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaBranchDoctorMatchDefs_Class() : base() { }
        }

        public static BindingList<MedulaBranchDoctorMatchDef.GetMedulaBranchDoctorMatchDefs_Class> GetMedulaBranchDoctorMatchDefs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULABRANCHDOCTORMATCHDEF"].QueryDefs["GetMedulaBranchDoctorMatchDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaBranchDoctorMatchDef.GetMedulaBranchDoctorMatchDefs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaBranchDoctorMatchDef.GetMedulaBranchDoctorMatchDefs_Class> GetMedulaBranchDoctorMatchDefs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULABRANCHDOCTORMATCHDEF"].QueryDefs["GetMedulaBranchDoctorMatchDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaBranchDoctorMatchDef.GetMedulaBranchDoctorMatchDefs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaBranchDoctorMatchDef> GetByBrachCode(TTObjectContext objectContext, string BRANCHCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULABRANCHDOCTORMATCHDEF"].QueryDefs["GetByBrachCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BRANCHCODE", BRANCHCODE);

            return ((ITTQuery)objectContext).QueryObjects<MedulaBranchDoctorMatchDef>(queryDef, paramList);
        }

        public SpecialityDefinition Branch
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("BRANCH"); }
            set { this["BRANCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaBranchDoctorMatchDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaBranchDoctorMatchDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaBranchDoctorMatchDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaBranchDoctorMatchDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaBranchDoctorMatchDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULABRANCHDOCTORMATCHDEF", dataRow) { }
        protected MedulaBranchDoctorMatchDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULABRANCHDOCTORMATCHDEF", dataRow, isImported) { }
        protected MedulaBranchDoctorMatchDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaBranchDoctorMatchDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaBranchDoctorMatchDef() : base() { }

    }
}