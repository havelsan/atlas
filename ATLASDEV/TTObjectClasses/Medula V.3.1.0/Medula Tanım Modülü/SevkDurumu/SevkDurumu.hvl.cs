
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SevkDurumu")] 

    /// <summary>
    /// Sevk Durumu
    /// </summary>
    public  partial class SevkDurumu : BaseMedulaDefinition
    {
        public class SevkDurumuList : TTObjectCollection<SevkDurumu> { }
                    
        public class ChildSevkDurumuCollection : TTObject.TTChildObjectCollection<SevkDurumu>
        {
            public ChildSevkDurumuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSevkDurumuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSevkDurumuDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string sevkDurumuKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKDURUMUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEVKDURUMU"].AllPropertyDefs["SEVKDURUMUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string sevkDurumuAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKDURUMUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEVKDURUMU"].AllPropertyDefs["SEVKDURUMUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSevkDurumuDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSevkDurumuDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSevkDurumuDefinitionQuery_Class() : base() { }
        }

        public static BindingList<SevkDurumu.GetSevkDurumuDefinitionQuery_Class> GetSevkDurumuDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEVKDURUMU"].QueryDefs["GetSevkDurumuDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SevkDurumu.GetSevkDurumuDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SevkDurumu.GetSevkDurumuDefinitionQuery_Class> GetSevkDurumuDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEVKDURUMU"].QueryDefs["GetSevkDurumuDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SevkDurumu.GetSevkDurumuDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Sevk Durumu Adı
    /// </summary>
        public string sevkDurumuAdi
        {
            get { return (string)this["SEVKDURUMUADI"]; }
            set { this["SEVKDURUMUADI"] = value; }
        }

    /// <summary>
    /// Sevk Durumu Kodu
    /// </summary>
        public string sevkDurumuKodu
        {
            get { return (string)this["SEVKDURUMUKODU"]; }
            set { this["SEVKDURUMUKODU"] = value; }
        }

        public string sevkDurumuAdi_Shadow
        {
            get { return (string)this["SEVKDURUMUADI_SHADOW"]; }
        }

        protected SevkDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SevkDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SevkDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SevkDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SevkDurumu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SEVKDURUMU", dataRow) { }
        protected SevkDurumu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SEVKDURUMU", dataRow, isImported) { }
        public SevkDurumu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SevkDurumu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SevkDurumu() : base() { }

    }
}