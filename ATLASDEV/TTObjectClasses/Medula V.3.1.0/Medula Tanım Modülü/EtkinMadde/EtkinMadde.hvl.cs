
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EtkinMadde")] 

    public  partial class EtkinMadde : BaseMedulaDefinition
    {
        public class EtkinMaddeList : TTObjectCollection<EtkinMadde> { }
                    
        public class ChildEtkinMaddeCollection : TTObject.TTChildObjectCollection<EtkinMadde>
        {
            public ChildEtkinMaddeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEtkinMaddeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEtkinMaddeDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string etkinMaddeKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETKINMADDEKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].AllPropertyDefs["ETKINMADDEKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string etkinMaddeAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETKINMADDEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].AllPropertyDefs["ETKINMADDEADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEtkinMaddeDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEtkinMaddeDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEtkinMaddeDefinitionQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEtkinMaddeDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string etkinMaddeKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETKINMADDEKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].AllPropertyDefs["ETKINMADDEKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string etkinMaddeAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETKINMADDEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].AllPropertyDefs["ETKINMADDEADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string etkinMaddeLatinceAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETKINMADDELATINCEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].AllPropertyDefs["ETKINMADDELATINCEADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string form
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].AllPropertyDefs["FORM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string icerikMiktari
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ICERIKMIKTARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].AllPropertyDefs["ICERIKMIKTARI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEtkinMaddeDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEtkinMaddeDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEtkinMaddeDefinitionList_Class() : base() { }
        }

        public static BindingList<EtkinMadde.GetEtkinMaddeDefinitionQuery_Class> GetEtkinMaddeDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].QueryDefs["GetEtkinMaddeDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EtkinMadde.GetEtkinMaddeDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EtkinMadde.GetEtkinMaddeDefinitionQuery_Class> GetEtkinMaddeDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].QueryDefs["GetEtkinMaddeDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EtkinMadde.GetEtkinMaddeDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EtkinMadde.GetEtkinMaddeDefinitionList_Class> GetEtkinMaddeDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].QueryDefs["GetEtkinMaddeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EtkinMadde.GetEtkinMaddeDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EtkinMadde.GetEtkinMaddeDefinitionList_Class> GetEtkinMaddeDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].QueryDefs["GetEtkinMaddeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EtkinMadde.GetEtkinMaddeDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EtkinMadde> GetEtkinMaddeByCode(TTObjectContext objectContext, string CODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].QueryDefs["GetEtkinMaddeByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<EtkinMadde>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<EtkinMadde> GetAllEtkinMaddeDef(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].QueryDefs["GetAllEtkinMaddeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<EtkinMadde>(queryDef, paramList);
        }

    /// <summary>
    /// Etkin Madde Latince Adı
    /// </summary>
        public string etkinMaddeLatinceAdi
        {
            get { return (string)this["ETKINMADDELATINCEADI"]; }
            set { this["ETKINMADDELATINCEADI"] = value; }
        }

        public string adetMiktar
        {
            get { return (string)this["ADETMIKTAR"]; }
            set { this["ADETMIKTAR"] = value; }
        }

        public string etkinMaddeAdi
        {
            get { return (string)this["ETKINMADDEADI"]; }
            set { this["ETKINMADDEADI"] = value; }
        }

        public string etkinMaddeAdi_Shadow
        {
            get { return (string)this["ETKINMADDEADI_SHADOW"]; }
        }

        public string etkinMaddeKodu
        {
            get { return (string)this["ETKINMADDEKODU"]; }
            set { this["ETKINMADDEKODU"] = value; }
        }

        public string form
        {
            get { return (string)this["FORM"]; }
            set { this["FORM"] = value; }
        }

        public string icerikMiktari
        {
            get { return (string)this["ICERIKMIKTARI"]; }
            set { this["ICERIKMIKTARI"] = value; }
        }

        public bool? hastaGvnlikveIzlemFrmGerek
        {
            get { return (bool?)this["HASTAGVNLIKVEIZLEMFRMGEREK"]; }
            set { this["HASTAGVNLIKVEIZLEMFRMGEREK"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? baslangicTarihi
        {
            get { return (DateTime?)this["BASLANGICTARIHI"]; }
            set { this["BASLANGICTARIHI"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? bitisTarihi
        {
            get { return (DateTime?)this["BITISTARIHI"]; }
            set { this["BITISTARIHI"] = value; }
        }

    /// <summary>
    /// Etkin Madde SUT Listesi
    /// </summary>
        public string SUTList
        {
            get { return (string)this["SUTLIST"]; }
            set { this["SUTLIST"] = value; }
        }

        virtual protected void CreateTeshisEtkinMaddeGridCollection()
        {
            _TeshisEtkinMaddeGrid = new TeshisEtkinMaddeGrid.ChildTeshisEtkinMaddeGridCollection(this, new Guid("48b8eb0d-6f66-4472-a73e-12a52208121a"));
            ((ITTChildObjectCollection)_TeshisEtkinMaddeGrid).GetChildren();
        }

        protected TeshisEtkinMaddeGrid.ChildTeshisEtkinMaddeGridCollection _TeshisEtkinMaddeGrid = null;
        public TeshisEtkinMaddeGrid.ChildTeshisEtkinMaddeGridCollection TeshisEtkinMaddeGrid
        {
            get
            {
                if (_TeshisEtkinMaddeGrid == null)
                    CreateTeshisEtkinMaddeGridCollection();
                return _TeshisEtkinMaddeGrid;
            }
        }

        protected EtkinMadde(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EtkinMadde(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EtkinMadde(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EtkinMadde(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EtkinMadde(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ETKINMADDE", dataRow) { }
        protected EtkinMadde(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ETKINMADDE", dataRow, isImported) { }
        public EtkinMadde(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EtkinMadde(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EtkinMadde() : base() { }

    }
}