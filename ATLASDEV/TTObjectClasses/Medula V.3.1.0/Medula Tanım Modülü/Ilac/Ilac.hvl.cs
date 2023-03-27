
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Ilac")] 

    /// <summary>
    /// İlaç
    /// </summary>
    public  partial class Ilac : BaseMedulaDefinition
    {
        public class IlacList : TTObjectCollection<Ilac> { }
                    
        public class ChildIlacCollection : TTObject.TTChildObjectCollection<Ilac>
        {
            public ChildIlacCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIlacCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetIlacDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string barkod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARKOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ILAC"].AllPropertyDefs["BARKOD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ilacAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ILACADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ILAC"].AllPropertyDefs["ILACADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? kullanimBirimi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KULLANIMBIRIMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ILAC"].AllPropertyDefs["KULLANIMBIRIMI"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetIlacDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIlacDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIlacDefinitionQuery_Class() : base() { }
        }

        public static BindingList<Ilac.GetIlacDefinitionQuery_Class> GetIlacDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILAC"].QueryDefs["GetIlacDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Ilac.GetIlacDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Ilac.GetIlacDefinitionQuery_Class> GetIlacDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILAC"].QueryDefs["GetIlacDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Ilac.GetIlacDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Ilac> GetIlacByBarkod(TTObjectContext objectContext, string BARKOD)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILAC"].QueryDefs["GetIlacByBarkod"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BARKOD", BARKOD);

            return ((ITTQuery)objectContext).QueryObjects<Ilac>(queryDef, paramList);
        }

        public string barkod_Shadow
        {
            get { return (string)this["BARKOD_SHADOW"]; }
        }

        public string ilacAdi_Shadow
        {
            get { return (string)this["ILACADI_SHADOW"]; }
        }

    /// <summary>
    /// İlaç Kullanım Birimi
    /// </summary>
        public double? kullanimBirimi
        {
            get { return (double?)this["KULLANIMBIRIMI"]; }
            set { this["KULLANIMBIRIMI"] = value; }
        }

    /// <summary>
    /// İlaç Barkodu
    /// </summary>
        public string barkod
        {
            get { return (string)this["BARKOD"]; }
            set { this["BARKOD"] = value; }
        }

    /// <summary>
    /// İlaç Adı
    /// </summary>
        public string ilacAdi
        {
            get { return (string)this["ILACADI"]; }
            set { this["ILACADI"] = value; }
        }

        public string GLN
        {
            get { return (string)this["GLN"]; }
            set { this["GLN"] = value; }
        }

        virtual protected void CreateilacFiyatlariCollection()
        {
            _ilacFiyatlari = new Fiyat.ChildFiyatCollection(this, new Guid("e9ba84e0-68ba-41dc-923d-cb638f1fe9db"));
            ((ITTChildObjectCollection)_ilacFiyatlari).GetChildren();
        }

        protected Fiyat.ChildFiyatCollection _ilacFiyatlari = null;
    /// <summary>
    /// Child collection for İlaç-İlaç fiyat bilgisi
    /// </summary>
        public Fiyat.ChildFiyatCollection ilacFiyatlari
        {
            get
            {
                if (_ilacFiyatlari == null)
                    CreateilacFiyatlariCollection();
                return _ilacFiyatlari;
            }
        }

        protected Ilac(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Ilac(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Ilac(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Ilac(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Ilac(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ILAC", dataRow) { }
        protected Ilac(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ILAC", dataRow, isImported) { }
        public Ilac(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Ilac(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Ilac() : base() { }

    }
}