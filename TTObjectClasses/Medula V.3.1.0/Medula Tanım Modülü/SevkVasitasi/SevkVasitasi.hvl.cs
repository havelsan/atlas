
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SevkVasitasi")] 

    /// <summary>
    /// Sevk Vasıtası
    /// </summary>
    public  partial class SevkVasitasi : BaseMedulaDefinition
    {
        public class SevkVasitasiList : TTObjectCollection<SevkVasitasi> { }
                    
        public class ChildSevkVasitasiCollection : TTObject.TTChildObjectCollection<SevkVasitasi>
        {
            public ChildSevkVasitasiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSevkVasitasiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSevkVasitasiDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string sevkVasitasiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKVASITASIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEVKVASITASI"].AllPropertyDefs["SEVKVASITASIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string sevkVasitasiAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKVASITASIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEVKVASITASI"].AllPropertyDefs["SEVKVASITASIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSevkVasitasiDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSevkVasitasiDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSevkVasitasiDefinitionQuery_Class() : base() { }
        }

        public static BindingList<SevkVasitasi.GetSevkVasitasiDefinitionQuery_Class> GetSevkVasitasiDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEVKVASITASI"].QueryDefs["GetSevkVasitasiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SevkVasitasi.GetSevkVasitasiDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SevkVasitasi.GetSevkVasitasiDefinitionQuery_Class> GetSevkVasitasiDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEVKVASITASI"].QueryDefs["GetSevkVasitasiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SevkVasitasi.GetSevkVasitasiDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Sevk Vasıtası Adı
    /// </summary>
        public string sevkVasitasiAdi
        {
            get { return (string)this["SEVKVASITASIADI"]; }
            set { this["SEVKVASITASIADI"] = value; }
        }

        public string sevkVasitasiAdi_Shadow
        {
            get { return (string)this["SEVKVASITASIADI_SHADOW"]; }
            set { this["SEVKVASITASIADI_SHADOW"] = value; }
        }

    /// <summary>
    /// Sevk Vasıtası Kodu
    /// </summary>
        public string sevkVasitasiKodu
        {
            get { return (string)this["SEVKVASITASIKODU"]; }
            set { this["SEVKVASITASIKODU"] = value; }
        }

        protected SevkVasitasi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SevkVasitasi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SevkVasitasi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SevkVasitasi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SevkVasitasi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SEVKVASITASI", dataRow) { }
        protected SevkVasitasi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SEVKVASITASI", dataRow, isImported) { }
        public SevkVasitasi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SevkVasitasi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SevkVasitasi() : base() { }

    }
}