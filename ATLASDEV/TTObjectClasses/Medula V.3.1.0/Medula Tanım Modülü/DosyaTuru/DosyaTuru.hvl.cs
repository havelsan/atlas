
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DosyaTuru")] 

    public  partial class DosyaTuru : BaseMedulaDefinition
    {
        public class DosyaTuruList : TTObjectCollection<DosyaTuru> { }
                    
        public class ChildDosyaTuruCollection : TTObject.TTChildObjectCollection<DosyaTuru>
        {
            public ChildDosyaTuruCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDosyaTuruCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDosyaTuruDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? dosyaTuruKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSYATURUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOSYATURU"].AllPropertyDefs["DOSYATURUKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string dosyaTuruAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSYATURUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOSYATURU"].AllPropertyDefs["DOSYATURUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDosyaTuruDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDosyaTuruDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDosyaTuruDefinitionQuery_Class() : base() { }
        }

        public static BindingList<DosyaTuru.GetDosyaTuruDefinitionQuery_Class> GetDosyaTuruDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOSYATURU"].QueryDefs["GetDosyaTuruDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DosyaTuru.GetDosyaTuruDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DosyaTuru.GetDosyaTuruDefinitionQuery_Class> GetDosyaTuruDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOSYATURU"].QueryDefs["GetDosyaTuruDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DosyaTuru.GetDosyaTuruDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DosyaTuru> GetDocumentTypes(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOSYATURU"].QueryDefs["GetDocumentTypes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<DosyaTuru>(queryDef, paramList, injectionSQL);
        }

        public string dosyaTuruAdi
        {
            get { return (string)this["DOSYATURUADI"]; }
            set { this["DOSYATURUADI"] = value; }
        }

        public string dosyaTuruAdi_Shadow
        {
            get { return (string)this["DOSYATURUADI_SHADOW"]; }
            set { this["DOSYATURUADI_SHADOW"] = value; }
        }

        public int? dosyaTuruKodu
        {
            get { return (int?)this["DOSYATURUKODU"]; }
            set { this["DOSYATURUKODU"] = value; }
        }

        protected DosyaTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DosyaTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DosyaTuru(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DosyaTuru(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DosyaTuru(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOSYATURU", dataRow) { }
        protected DosyaTuru(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOSYATURU", dataRow, isImported) { }
        public DosyaTuru(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DosyaTuru(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DosyaTuru() : base() { }

    }
}