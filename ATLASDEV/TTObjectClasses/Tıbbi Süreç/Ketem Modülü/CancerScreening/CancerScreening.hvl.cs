
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CancerScreening")] 

    /// <summary>
    /// Toplum Tabanlı Kanser Tarama - NBZ247
    /// </summary>
    public  partial class CancerScreening : Ketem
    {
        public class CancerScreeningList : TTObjectCollection<CancerScreening> { }
                    
        public class ChildCancerScreeningCollection : TTObject.TTChildObjectCollection<CancerScreening>
        {
            public ChildCancerScreeningCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCancerScreeningCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCancerScreeningBySubepisodeID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public DateTime? TaramaTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARAMATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CANCERSCREENING"].AllPropertyDefs["TARAMATARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? TaramaSonuclanmaTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARAMASONUCLANMATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CANCERSCREENING"].AllPropertyDefs["TARAMASONUCLANMATARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetCancerScreeningBySubepisodeID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCancerScreeningBySubepisodeID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCancerScreeningBySubepisodeID_Class() : base() { }
        }

        public static BindingList<CancerScreening.GetCancerScreeningBySubepisodeID_Class> GetCancerScreeningBySubepisodeID(Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CANCERSCREENING"].QueryDefs["GetCancerScreeningBySubepisodeID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<CancerScreening.GetCancerScreeningBySubepisodeID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CancerScreening.GetCancerScreeningBySubepisodeID_Class> GetCancerScreeningBySubepisodeID(TTObjectContext objectContext, Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CANCERSCREENING"].QueryDefs["GetCancerScreeningBySubepisodeID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<CancerScreening.GetCancerScreeningBySubepisodeID_Class>(objectContext, queryDef, paramList, pi);
        }

        public DateTime? TaramaTarihi
        {
            get { return (DateTime?)this["TARAMATARIHI"]; }
            set { this["TARAMATARIHI"] = value; }
        }

        public DateTime? TaramaSonuclanmaTarihi
        {
            get { return (DateTime?)this["TARAMASONUCLANMATARIHI"]; }
            set { this["TARAMASONUCLANMATARIHI"] = value; }
        }

        public SKRSGaitadaGizliKanTesti SKRSGaitadaGizliKanTesti
        {
            get { return (SKRSGaitadaGizliKanTesti)((ITTObject)this).GetParent("SKRSGAITADAGIZLIKANTESTI"); }
            set { this["SKRSGAITADAGIZLIKANTESTI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKolonGoruntulemeYontemi SKRSKolonGoruntulemeYontemi
        {
            get { return (SKRSKolonGoruntulemeYontemi)((ITTObject)this).GetParent("SKRSKOLONGORUNTULEMEYONTEMI"); }
            set { this["SKRSKOLONGORUNTULEMEYONTEMI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKolonoskopi SKRSKolonoskopi
        {
            get { return (SKRSKolonoskopi)((ITTObject)this).GetParent("SKRSKOLONOSKOPI"); }
            set { this["SKRSKOLONOSKOPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSHPVTaramaTesti SKRSHPVTaramaTesti
        {
            get { return (SKRSHPVTaramaTesti)((ITTObject)this).GetParent("SKRSHPVTARAMATESTI"); }
            set { this["SKRSHPVTARAMATESTI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKendiKendineMemeMuayenesi SKRSKendiKendineMemeMuayenesi
        {
            get { return (SKRSKendiKendineMemeMuayenesi)((ITTObject)this).GetParent("SKRSKENDIKENDINEMEMEMUAYENESI"); }
            set { this["SKRSKENDIKENDINEMEMEMUAYENESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKlinikMemeMuayenesi SKRSKlinikMemeMuayenesi
        {
            get { return (SKRSKlinikMemeMuayenesi)((ITTObject)this).GetParent("SKRSKLINIKMEMEMUAYENESI"); }
            set { this["SKRSKLINIKMEMEMUAYENESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKolonoskopininSuresi SKRSKolonoskopininSuresi
        {
            get { return (SKRSKolonoskopininSuresi)((ITTObject)this).GetParent("SKRSKOLONOSKOPININSURESI"); }
            set { this["SKRSKOLONOSKOPININSURESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKolposkopi SKRSKolposkopi
        {
            get { return (SKRSKolposkopi)((ITTObject)this).GetParent("SKRSKOLPOSKOPI"); }
            set { this["SKRSKOLPOSKOPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSMamografi SKRSMamografi
        {
            get { return (SKRSMamografi)((ITTObject)this).GetParent("SKRSMAMOGRAFI"); }
            set { this["SKRSMAMOGRAFI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSMamografiSonucu SKRSMamografiSonucu
        {
            get { return (SKRSMamografiSonucu)((ITTObject)this).GetParent("SKRSMAMOGRAFISONUCU"); }
            set { this["SKRSMAMOGRAFISONUCU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSPapSmearTesti SKRSPapSmearTesti
        {
            get { return (SKRSPapSmearTesti)((ITTObject)this).GetParent("SKRSPAPSMEARTESTI"); }
            set { this["SKRSPAPSMEARTESTI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSSigmoidoskopi SKRSSigmoidoskopi
        {
            get { return (SKRSSigmoidoskopi)((ITTObject)this).GetParent("SKRSSIGMOIDOSKOPI"); }
            set { this["SKRSSIGMOIDOSKOPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSTARAMATIPI SKRSTARAMATIPI
        {
            get { return (SKRSTARAMATIPI)((ITTObject)this).GetParent("SKRSTARAMATIPI"); }
            set { this["SKRSTARAMATIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateColonoscopyQualityCriteriaCollection()
        {
            _ColonoscopyQualityCriteria = new ColonoscopyQualityCriteria.ChildColonoscopyQualityCriteriaCollection(this, new Guid("75b79d0f-a87e-4d11-b2f5-6596ec9c4cab"));
            ((ITTChildObjectCollection)_ColonoscopyQualityCriteria).GetChildren();
        }

        protected ColonoscopyQualityCriteria.ChildColonoscopyQualityCriteriaCollection _ColonoscopyQualityCriteria = null;
        public ColonoscopyQualityCriteria.ChildColonoscopyQualityCriteriaCollection ColonoscopyQualityCriteria
        {
            get
            {
                if (_ColonoscopyQualityCriteria == null)
                    CreateColonoscopyQualityCriteriaCollection();
                return _ColonoscopyQualityCriteria;
            }
        }

        virtual protected void CreateColorectalBiopsyResultsCollection()
        {
            _ColorectalBiopsyResults = new ColorectalBiopsyResults.ChildColorectalBiopsyResultsCollection(this, new Guid("6c6ef8d4-2bdb-4313-b568-874888b8d184"));
            ((ITTChildObjectCollection)_ColorectalBiopsyResults).GetChildren();
        }

        protected ColorectalBiopsyResults.ChildColorectalBiopsyResultsCollection _ColorectalBiopsyResults = null;
        public ColorectalBiopsyResults.ChildColorectalBiopsyResultsCollection ColorectalBiopsyResults
        {
            get
            {
                if (_ColorectalBiopsyResults == null)
                    CreateColorectalBiopsyResultsCollection();
                return _ColorectalBiopsyResults;
            }
        }

        virtual protected void CreateBreastBiopsyCollection()
        {
            _BreastBiopsy = new BreastBiopsy.ChildBreastBiopsyCollection(this, new Guid("63437999-8057-422b-93d5-7316d8fb05ce"));
            ((ITTChildObjectCollection)_BreastBiopsy).GetChildren();
        }

        protected BreastBiopsy.ChildBreastBiopsyCollection _BreastBiopsy = null;
        public BreastBiopsy.ChildBreastBiopsyCollection BreastBiopsy
        {
            get
            {
                if (_BreastBiopsy == null)
                    CreateBreastBiopsyCollection();
                return _BreastBiopsy;
            }
        }

        virtual protected void CreateCervicalBiopsyResultsCollection()
        {
            _CervicalBiopsyResults = new CervicalBiopsyResults.ChildCervicalBiopsyResultsCollection(this, new Guid("1aae142f-af54-4018-ac80-c48e034a099e"));
            ((ITTChildObjectCollection)_CervicalBiopsyResults).GetChildren();
        }

        protected CervicalBiopsyResults.ChildCervicalBiopsyResultsCollection _CervicalBiopsyResults = null;
        public CervicalBiopsyResults.ChildCervicalBiopsyResultsCollection CervicalBiopsyResults
        {
            get
            {
                if (_CervicalBiopsyResults == null)
                    CreateCervicalBiopsyResultsCollection();
                return _CervicalBiopsyResults;
            }
        }

        virtual protected void CreateCervicalCytologyResultsCollection()
        {
            _CervicalCytologyResults = new CervicalCytologyResults.ChildCervicalCytologyResultsCollection(this, new Guid("53a8b276-3ce4-4048-a0de-7e58b77cf578"));
            ((ITTChildObjectCollection)_CervicalCytologyResults).GetChildren();
        }

        protected CervicalCytologyResults.ChildCervicalCytologyResultsCollection _CervicalCytologyResults = null;
        public CervicalCytologyResults.ChildCervicalCytologyResultsCollection CervicalCytologyResults
        {
            get
            {
                if (_CervicalCytologyResults == null)
                    CreateCervicalCytologyResultsCollection();
                return _CervicalCytologyResults;
            }
        }

        virtual protected void CreateHPVTypeInfoCollection()
        {
            _HPVTypeInfo = new HPVTypeInfo.ChildHPVTypeInfoCollection(this, new Guid("4e547d48-b2d1-4719-bba3-f1906f952792"));
            ((ITTChildObjectCollection)_HPVTypeInfo).GetChildren();
        }

        protected HPVTypeInfo.ChildHPVTypeInfoCollection _HPVTypeInfo = null;
        public HPVTypeInfo.ChildHPVTypeInfoCollection HPVTypeInfo
        {
            get
            {
                if (_HPVTypeInfo == null)
                    CreateHPVTypeInfoCollection();
                return _HPVTypeInfo;
            }
        }

        protected CancerScreening(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CancerScreening(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CancerScreening(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CancerScreening(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CancerScreening(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CANCERSCREENING", dataRow) { }
        protected CancerScreening(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CANCERSCREENING", dataRow, isImported) { }
        public CancerScreening(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CancerScreening(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CancerScreening() : base() { }

    }
}