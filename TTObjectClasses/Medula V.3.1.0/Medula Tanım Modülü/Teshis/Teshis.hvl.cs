
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Teshis")] 

    public  partial class Teshis : BaseMedulaDefinition
    {
        public class TeshisList : TTObjectCollection<Teshis> { }
                    
        public class ChildTeshisCollection : TTObject.TTChildObjectCollection<Teshis>
        {
            public ChildTeshisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTeshisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTeshisDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? teshisKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESHISKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TESHIS"].AllPropertyDefs["TESHISKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string teshisAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESHISADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TESHIS"].AllPropertyDefs["TESHISADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTeshisDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTeshisDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTeshisDefinitionQuery_Class() : base() { }
        }

        public static BindingList<Teshis.GetTeshisDefinitionQuery_Class> GetTeshisDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TESHIS"].QueryDefs["GetTeshisDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Teshis.GetTeshisDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Teshis.GetTeshisDefinitionQuery_Class> GetTeshisDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TESHIS"].QueryDefs["GetTeshisDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Teshis.GetTeshisDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Teshis> GetTesihisByCode(TTObjectContext objectContext, string CODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TESHIS"].QueryDefs["GetTesihisByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<Teshis>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Teşhis Adı
    /// </summary>
        public string teshisAdi
        {
            get { return (string)this["TESHISADI"]; }
            set { this["TESHISADI"] = value; }
        }

        public string teshisAdi_Shadow
        {
            get { return (string)this["TESHISADI_SHADOW"]; }
        }

    /// <summary>
    /// Teşhis Kodu
    /// </summary>
        public int? teshisKodu
        {
            get { return (int?)this["TESHISKODU"]; }
            set { this["TESHISKODU"] = value; }
        }

        virtual protected void CreateDiagnosisDefTeshisCollection()
        {
            _DiagnosisDefTeshis = new DiagnosisDefTeshis.ChildDiagnosisDefTeshisCollection(this, new Guid("6ae79a2c-d533-49cf-b992-7fcd2f1e80b7"));
            ((ITTChildObjectCollection)_DiagnosisDefTeshis).GetChildren();
        }

        protected DiagnosisDefTeshis.ChildDiagnosisDefTeshisCollection _DiagnosisDefTeshis = null;
        public DiagnosisDefTeshis.ChildDiagnosisDefTeshisCollection DiagnosisDefTeshis
        {
            get
            {
                if (_DiagnosisDefTeshis == null)
                    CreateDiagnosisDefTeshisCollection();
                return _DiagnosisDefTeshis;
            }
        }

        protected Teshis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Teshis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Teshis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Teshis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Teshis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TESHIS", dataRow) { }
        protected Teshis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TESHIS", dataRow, isImported) { }
        public Teshis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Teshis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Teshis() : base() { }

    }
}