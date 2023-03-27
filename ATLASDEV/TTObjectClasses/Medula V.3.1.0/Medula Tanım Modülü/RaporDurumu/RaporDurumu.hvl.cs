
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporDurumu")] 

    public  partial class RaporDurumu : BaseMedulaDefinition
    {
        public class RaporDurumuList : TTObjectCollection<RaporDurumu> { }
                    
        public class ChildRaporDurumuCollection : TTObject.TTChildObjectCollection<RaporDurumu>
        {
            public ChildRaporDurumuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporDurumuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRaporDurumuQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string raporDurumuKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORDURUMUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RAPORDURUMU"].AllPropertyDefs["RAPORDURUMUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string raporDurumuAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORDURUMUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RAPORDURUMU"].AllPropertyDefs["RAPORDURUMUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRaporDurumuQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRaporDurumuQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRaporDurumuQuery_Class() : base() { }
        }

        public static BindingList<RaporDurumu.GetRaporDurumuQuery_Class> GetRaporDurumuQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORDURUMU"].QueryDefs["GetRaporDurumuQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RaporDurumu.GetRaporDurumuQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RaporDurumu.GetRaporDurumuQuery_Class> GetRaporDurumuQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORDURUMU"].QueryDefs["GetRaporDurumuQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RaporDurumu.GetRaporDurumuQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string raporDurumuAdi
        {
            get { return (string)this["RAPORDURUMUADI"]; }
            set { this["RAPORDURUMUADI"] = value; }
        }

        public string raporDurumuAdi_Shadow
        {
            get { return (string)this["RAPORDURUMUADI_SHADOW"]; }
            set { this["RAPORDURUMUADI_SHADOW"] = value; }
        }

        public string raporDurumuKodu
        {
            get { return (string)this["RAPORDURUMUKODU"]; }
            set { this["RAPORDURUMUKODU"] = value; }
        }

        protected RaporDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporDurumu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORDURUMU", dataRow) { }
        protected RaporDurumu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORDURUMU", dataRow, isImported) { }
        public RaporDurumu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporDurumu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporDurumu() : base() { }

    }
}