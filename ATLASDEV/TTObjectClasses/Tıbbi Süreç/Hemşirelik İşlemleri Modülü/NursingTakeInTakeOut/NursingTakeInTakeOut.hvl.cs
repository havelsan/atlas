
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingTakeInTakeOut")] 

    public  partial class NursingTakeInTakeOut : TTObject
    {
        public class NursingTakeInTakeOutList : TTObjectCollection<NursingTakeInTakeOut> { }
                    
        public class ChildNursingTakeInTakeOutCollection : TTObject.TTChildObjectCollection<NursingTakeInTakeOut>
        {
            public ChildNursingTakeInTakeOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingTakeInTakeOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByNursingApplication_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGTAKEINTAKEOUT"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? Bleeding
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BLEEDING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGTAKEINTAKEOUT"].AllPropertyDefs["BLEEDING"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Dren
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DREN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGTAKEINTAKEOUT"].AllPropertyDefs["DREN"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Gaita
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GAITA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGTAKEINTAKEOUT"].AllPropertyDefs["GAITA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? IVInf
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IVINF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGTAKEINTAKEOUT"].AllPropertyDefs["IVINF"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Oral
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGTAKEINTAKEOUT"].AllPropertyDefs["ORAL"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Uretic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["URETIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGTAKEINTAKEOUT"].AllPropertyDefs["URETIC"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Vomiting
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VOMITING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGTAKEINTAKEOUT"].AllPropertyDefs["VOMITING"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public HourIntervalEnum? HourInterval
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOURINTERVAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGTAKEINTAKEOUT"].AllPropertyDefs["HOURINTERVAL"].DataType;
                    return (HourIntervalEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAKEINTAKEOUTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetByNursingApplication_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByNursingApplication_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByNursingApplication_Class() : base() { }
        }

        public static BindingList<NursingTakeInTakeOut.GetByNursingApplication_Class> GetByNursingApplication(string NURSINGAPPLICATION, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGTAKEINTAKEOUT"].QueryDefs["GetByNursingApplication"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<NursingTakeInTakeOut.GetByNursingApplication_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingTakeInTakeOut.GetByNursingApplication_Class> GetByNursingApplication(TTObjectContext objectContext, string NURSINGAPPLICATION, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGTAKEINTAKEOUT"].QueryDefs["GetByNursingApplication"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<NursingTakeInTakeOut.GetByNursingApplication_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Explanation
        {
            get { return (string)this["EXPLANATION"]; }
            set { this["EXPLANATION"] = value; }
        }

    /// <summary>
    /// Saat
    /// </summary>
        public HourIntervalEnum? HourInterval
        {
            get { return (HourIntervalEnum?)(int?)this["HOURINTERVAL"]; }
            set { this["HOURINTERVAL"] = value; }
        }

    /// <summary>
    /// Oral
    /// </summary>
        public int? Oral
        {
            get { return (int?)this["ORAL"]; }
            set { this["ORAL"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// İdrar
    /// </summary>
        public int? Uretic
        {
            get { return (int?)this["URETIC"]; }
            set { this["URETIC"] = value; }
        }

    /// <summary>
    /// Kusma
    /// </summary>
        public int? Vomiting
        {
            get { return (int?)this["VOMITING"]; }
            set { this["VOMITING"] = value; }
        }

    /// <summary>
    /// Gaita
    /// </summary>
        public int? Gaita
        {
            get { return (int?)this["GAITA"]; }
            set { this["GAITA"] = value; }
        }

    /// <summary>
    /// IVInf
    /// </summary>
        public int? IVInf
        {
            get { return (int?)this["IVINF"]; }
            set { this["IVINF"] = value; }
        }

    /// <summary>
    /// Kanama
    /// </summary>
        public int? Bleeding
        {
            get { return (int?)this["BLEEDING"]; }
            set { this["BLEEDING"] = value; }
        }

    /// <summary>
    /// Dren
    /// </summary>
        public int? Dren
        {
            get { return (int?)this["DREN"]; }
            set { this["DREN"] = value; }
        }

    /// <summary>
    /// Aldığı Çıkardığı
    /// </summary>
        public TakeInTakeOutDefinition TakeInTakeOut
        {
            get { return (TakeInTakeOutDefinition)((ITTObject)this).GetParent("TAKEINTAKEOUT"); }
            set { this["TAKEINTAKEOUT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Aldığı Çıkardığı
    /// </summary>
        public NursingApplication NursingApplication
        {
            get { return (NursingApplication)((ITTObject)this).GetParent("NURSINGAPPLICATION"); }
            set { this["NURSINGAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingTakeInTakeOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingTakeInTakeOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingTakeInTakeOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingTakeInTakeOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingTakeInTakeOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGTAKEINTAKEOUT", dataRow) { }
        protected NursingTakeInTakeOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGTAKEINTAKEOUT", dataRow, isImported) { }
        public NursingTakeInTakeOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingTakeInTakeOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingTakeInTakeOut() : base() { }

    }
}