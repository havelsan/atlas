
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakipDurumu")] 

    /// <summary>
    /// Takip Durumu
    /// </summary>
    public  partial class TakipDurumu : BaseMedulaDefinition
    {
        public class TakipDurumuList : TTObjectCollection<TakipDurumu> { }
                    
        public class ChildTakipDurumuCollection : TTObject.TTChildObjectCollection<TakipDurumu>
        {
            public ChildTakipDurumuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakipDurumuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTakipDurumuDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string takipDurumuKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIPDURUMUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAKIPDURUMU"].AllPropertyDefs["TAKIPDURUMUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string takipDurumuAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIPDURUMUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAKIPDURUMU"].AllPropertyDefs["TAKIPDURUMUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTakipDurumuDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTakipDurumuDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTakipDurumuDefinitionQuery_Class() : base() { }
        }

        public static BindingList<TakipDurumu.GetTakipDurumuDefinitionQuery_Class> GetTakipDurumuDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPDURUMU"].QueryDefs["GetTakipDurumuDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TakipDurumu.GetTakipDurumuDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TakipDurumu.GetTakipDurumuDefinitionQuery_Class> GetTakipDurumuDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPDURUMU"].QueryDefs["GetTakipDurumuDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TakipDurumu.GetTakipDurumuDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Takip Durumu Kodu
    /// </summary>
        public string takipDurumuKodu
        {
            get { return (string)this["TAKIPDURUMUKODU"]; }
            set { this["TAKIPDURUMUKODU"] = value; }
        }

    /// <summary>
    /// Takip Durumu Adı
    /// </summary>
        public string takipDurumuAdi
        {
            get { return (string)this["TAKIPDURUMUADI"]; }
            set { this["TAKIPDURUMUADI"] = value; }
        }

        public string takipDurumuAdi_Shadow
        {
            get { return (string)this["TAKIPDURUMUADI_SHADOW"]; }
        }

        protected TakipDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakipDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakipDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakipDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakipDurumu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKIPDURUMU", dataRow) { }
        protected TakipDurumu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKIPDURUMU", dataRow, isImported) { }
        public TakipDurumu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakipDurumu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakipDurumu() : base() { }

    }
}