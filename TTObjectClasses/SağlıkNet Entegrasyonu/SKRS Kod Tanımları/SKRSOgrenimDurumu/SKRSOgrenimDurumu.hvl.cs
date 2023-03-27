
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSOgrenimDurumu")] 

    /// <summary>
    /// 3cdc2ba0-03de-46f4-8ace-684c94712349
    /// </summary>
    public  partial class SKRSOgrenimDurumu : BaseSKRSCommonDef
    {
        public class SKRSOgrenimDurumuList : TTObjectCollection<SKRSOgrenimDurumu> { }
                    
        public class ChildSKRSOgrenimDurumuCollection : TTObject.TTChildObjectCollection<SKRSOgrenimDurumu>
        {
            public ChildSKRSOgrenimDurumuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSOgrenimDurumuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSOgrenimDurumu_Class : TTReportNqlObject 
        {
            public string ADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOGRENIMDURUMU"].AllPropertyDefs["ADI"].DataType;
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

            public GetSKRSOgrenimDurumu_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSOgrenimDurumu_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSOgrenimDurumu_Class() : base() { }
        }

        public static BindingList<SKRSOgrenimDurumu.GetSKRSOgrenimDurumu_Class> GetSKRSOgrenimDurumu(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSOGRENIMDURUMU"].QueryDefs["GetSKRSOgrenimDurumu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSOgrenimDurumu.GetSKRSOgrenimDurumu_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSOgrenimDurumu.GetSKRSOgrenimDurumu_Class> GetSKRSOgrenimDurumu(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSOGRENIMDURUMU"].QueryDefs["GetSKRSOgrenimDurumu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSOgrenimDurumu.GetSKRSOgrenimDurumu_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSOgrenimDurumu> GetBySKRSKodu(TTObjectContext objectContext, int SKRSKod)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSOGRENIMDURUMU"].QueryDefs["GetBySKRSKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SKRSKOD", SKRSKod);

            return ((ITTQuery)objectContext).QueryObjects<SKRSOgrenimDurumu>(queryDef, paramList);
        }

        protected SKRSOgrenimDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSOgrenimDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSOgrenimDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSOgrenimDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSOgrenimDurumu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSOGRENIMDURUMU", dataRow) { }
        protected SKRSOgrenimDurumu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSOGRENIMDURUMU", dataRow, isImported) { }
        public SKRSOgrenimDurumu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSOgrenimDurumu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSOgrenimDurumu() : base() { }

    }
}