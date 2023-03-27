
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HospitalEmblemDefinition")] 

    /// <summary>
    /// XXXXXX Logo Tanımlama
    /// </summary>
    public  partial class HospitalEmblemDefinition : TerminologyManagerDef
    {
        public class HospitalEmblemDefinitionList : TTObjectCollection<HospitalEmblemDefinition> { }
                    
        public class ChildHospitalEmblemDefinitionCollection : TTObject.TTChildObjectCollection<HospitalEmblemDefinition>
        {
            public ChildHospitalEmblemDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHospitalEmblemDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHospitalEmblemDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HOSPITALEMBLEMDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Emblem
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMBLEM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HOSPITALEMBLEMDEFINITION"].AllPropertyDefs["EMBLEM"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetHospitalEmblemDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHospitalEmblemDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHospitalEmblemDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHospitalEmblemByName_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HOSPITALEMBLEMDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Emblem
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMBLEM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HOSPITALEMBLEMDEFINITION"].AllPropertyDefs["EMBLEM"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetHospitalEmblemByName_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHospitalEmblemByName_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHospitalEmblemByName_Class() : base() { }
        }

        public static BindingList<HospitalEmblemDefinition.GetHospitalEmblemDefinition_Class> GetHospitalEmblemDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HOSPITALEMBLEMDEFINITION"].QueryDefs["GetHospitalEmblemDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HospitalEmblemDefinition.GetHospitalEmblemDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HospitalEmblemDefinition.GetHospitalEmblemDefinition_Class> GetHospitalEmblemDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HOSPITALEMBLEMDEFINITION"].QueryDefs["GetHospitalEmblemDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HospitalEmblemDefinition.GetHospitalEmblemDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HospitalEmblemDefinition.GetHospitalEmblemByName_Class> GetHospitalEmblemByName(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HOSPITALEMBLEMDEFINITION"].QueryDefs["GetHospitalEmblemByName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HospitalEmblemDefinition.GetHospitalEmblemByName_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HospitalEmblemDefinition.GetHospitalEmblemByName_Class> GetHospitalEmblemByName(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HOSPITALEMBLEMDEFINITION"].QueryDefs["GetHospitalEmblemByName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HospitalEmblemDefinition.GetHospitalEmblemByName_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Amblem
    /// </summary>
        public object Emblem
        {
            get { return (object)this["EMBLEM"]; }
            set { this["EMBLEM"] = value; }
        }

    /// <summary>
    /// Resim Tanım Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected HospitalEmblemDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HospitalEmblemDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HospitalEmblemDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HospitalEmblemDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HospitalEmblemDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HOSPITALEMBLEMDEFINITION", dataRow) { }
        protected HospitalEmblemDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HOSPITALEMBLEMDEFINITION", dataRow, isImported) { }
        public HospitalEmblemDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HospitalEmblemDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HospitalEmblemDefinition() : base() { }

    }
}