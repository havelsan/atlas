
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MKYS_ServisDepo")] 

    public  partial class MKYS_ServisDepo : TerminologyManagerDef
    {
        public class MKYS_ServisDepoList : TTObjectCollection<MKYS_ServisDepo> { }
                    
        public class ChildMKYS_ServisDepoCollection : TTObject.TTChildObjectCollection<MKYS_ServisDepo>
        {
            public ChildMKYS_ServisDepoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMKYS_ServisDepoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMKYS_ServisDepoList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? bagliBirimID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BAGLIBIRIMID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYS_SERVISDEPO"].AllPropertyDefs["BAGLIBIRIMID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string birimAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIMADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYS_SERVISDEPO"].AllPropertyDefs["BIRIMADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? birimKayitNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIMKAYITNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYS_SERVISDEPO"].AllPropertyDefs["BIRIMKAYITNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string birimKisaAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIMKISAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYS_SERVISDEPO"].AllPropertyDefs["BIRIMKISAADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string birimKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYS_SERVISDEPO"].AllPropertyDefs["BIRIMKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string faaliyetDurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAALIYETDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYS_SERVISDEPO"].AllPropertyDefs["FAALIYETDURUMU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string tur
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TUR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MKYS_SERVISDEPO"].AllPropertyDefs["TUR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMKYS_ServisDepoList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMKYS_ServisDepoList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMKYS_ServisDepoList_Class() : base() { }
        }

        public static BindingList<MKYS_ServisDepo.GetMKYS_ServisDepoList_Class> GetMKYS_ServisDepoList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MKYS_SERVISDEPO"].QueryDefs["GetMKYS_ServisDepoList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MKYS_ServisDepo.GetMKYS_ServisDepoList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MKYS_ServisDepo.GetMKYS_ServisDepoList_Class> GetMKYS_ServisDepoList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MKYS_SERVISDEPO"].QueryDefs["GetMKYS_ServisDepoList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MKYS_ServisDepo.GetMKYS_ServisDepoList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? bagliBirimID
        {
            get { return (int?)this["BAGLIBIRIMID"]; }
            set { this["BAGLIBIRIMID"] = value; }
        }

        public string birimAdi
        {
            get { return (string)this["BIRIMADI"]; }
            set { this["BIRIMADI"] = value; }
        }

        public int? birimKayitNo
        {
            get { return (int?)this["BIRIMKAYITNO"]; }
            set { this["BIRIMKAYITNO"] = value; }
        }

        public string birimKisaAdi
        {
            get { return (string)this["BIRIMKISAADI"]; }
            set { this["BIRIMKISAADI"] = value; }
        }

        public string birimKodu
        {
            get { return (string)this["BIRIMKODU"]; }
            set { this["BIRIMKODU"] = value; }
        }

        public string faaliyetDurumu
        {
            get { return (string)this["FAALIYETDURUMU"]; }
            set { this["FAALIYETDURUMU"] = value; }
        }

        public string tur
        {
            get { return (string)this["TUR"]; }
            set { this["TUR"] = value; }
        }

        virtual protected void CreateMKYS_BirimDepoCollection()
        {
            _MKYS_BirimDepo = new SubStoreDefinition.ChildSubStoreDefinitionCollection(this, new Guid("5580c735-7df5-4c55-85fa-28999323b632"));
            ((ITTChildObjectCollection)_MKYS_BirimDepo).GetChildren();
        }

        protected SubStoreDefinition.ChildSubStoreDefinitionCollection _MKYS_BirimDepo = null;
    /// <summary>
    /// Child collection for MKYS_ServisDepo
    /// </summary>
        public SubStoreDefinition.ChildSubStoreDefinitionCollection MKYS_BirimDepo
        {
            get
            {
                if (_MKYS_BirimDepo == null)
                    CreateMKYS_BirimDepoCollection();
                return _MKYS_BirimDepo;
            }
        }

        protected MKYS_ServisDepo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MKYS_ServisDepo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MKYS_ServisDepo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MKYS_ServisDepo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MKYS_ServisDepo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MKYS_SERVISDEPO", dataRow) { }
        protected MKYS_ServisDepo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MKYS_SERVISDEPO", dataRow, isImported) { }
        public MKYS_ServisDepo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MKYS_ServisDepo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MKYS_ServisDepo() : base() { }

    }
}