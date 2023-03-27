
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturalanmaDurumu")] 

    /// <summary>
    /// Faturalanma Durumu
    /// </summary>
    public  partial class FaturalanmaDurumu : BaseMedulaDefinition
    {
        public class FaturalanmaDurumuList : TTObjectCollection<FaturalanmaDurumu> { }
                    
        public class ChildFaturalanmaDurumuCollection : TTObject.TTChildObjectCollection<FaturalanmaDurumu>
        {
            public ChildFaturalanmaDurumuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturalanmaDurumuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFaturalanmaDurumuDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string faturalanmaDurumuKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATURALANMADURUMUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FATURALANMADURUMU"].AllPropertyDefs["FATURALANMADURUMUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string faturalanmaDurumuAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATURALANMADURUMUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FATURALANMADURUMU"].AllPropertyDefs["FATURALANMADURUMUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFaturalanmaDurumuDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFaturalanmaDurumuDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFaturalanmaDurumuDefinitionQuery_Class() : base() { }
        }

        public static BindingList<FaturalanmaDurumu.GetFaturalanmaDurumuDefinitionQuery_Class> GetFaturalanmaDurumuDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FATURALANMADURUMU"].QueryDefs["GetFaturalanmaDurumuDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FaturalanmaDurumu.GetFaturalanmaDurumuDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FaturalanmaDurumu.GetFaturalanmaDurumuDefinitionQuery_Class> GetFaturalanmaDurumuDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FATURALANMADURUMU"].QueryDefs["GetFaturalanmaDurumuDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FaturalanmaDurumu.GetFaturalanmaDurumuDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Faturalanma Durumu Adı
    /// </summary>
        public string faturalanmaDurumuAdi
        {
            get { return (string)this["FATURALANMADURUMUADI"]; }
            set { this["FATURALANMADURUMUADI"] = value; }
        }

    /// <summary>
    /// Faturalanma Durumu Kodu
    /// </summary>
        public string faturalanmaDurumuKodu
        {
            get { return (string)this["FATURALANMADURUMUKODU"]; }
            set { this["FATURALANMADURUMUKODU"] = value; }
        }

        public string faturalanmaDurumuAdi_Shado
        {
            get { return (string)this["FATURALANMADURUMUADI_SHADO"]; }
        }

        protected FaturalanmaDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturalanmaDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturalanmaDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturalanmaDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturalanmaDurumu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURALANMADURUMU", dataRow) { }
        protected FaturalanmaDurumu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURALANMADURUMU", dataRow, isImported) { }
        public FaturalanmaDurumu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturalanmaDurumu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturalanmaDurumu() : base() { }

    }
}