
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingPainScale")] 

    /// <summary>
    /// Ağrı Değerlendirme
    /// </summary>
    public  partial class NursingPainScale : BaseNursingDataEntry
    {
        public class NursingPainScaleList : TTObjectCollection<NursingPainScale> { }
                    
        public class ChildNursingPainScaleCollection : TTObject.TTChildObjectCollection<NursingPainScale>
        {
            public ChildNursingPainScaleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingPainScaleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPainScale_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? Uygulama_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UYGULAMA_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGPAINSCALE"].AllPropertyDefs["APPLICATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Agriyan_taraf
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AGRIYAN_TARAF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGPAINSCALE"].AllPropertyDefs["ACHINGSIDE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Agri_detay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AGRI_DETAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGPAINSCALE"].AllPropertyDefs["PAINDETAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Agri_yeri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AGRI_YERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAINPLACEDEFITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Agri_zaman
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AGRI_ZAMAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGPAINSCALE"].AllPropertyDefs["PAINTIME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Agri_suresi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AGRI_SURESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGPAINSCALE"].AllPropertyDefs["DURATIONOFPAIN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Agri_nitelik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AGRI_NITELIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAINQUALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Nitelik_aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NITELIK_ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGPAINSCALE"].AllPropertyDefs["PAINQUALITYDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Agri_siklik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AGRI_SIKLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAINFREQUENCYDEFINITON"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PainFaceScaleEnum? Agri_siddeti
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AGRI_SIDDETI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGPAINSCALE"].AllPropertyDefs["PAINFACESCALE"].DataType;
                    return (PainFaceScaleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public PostNursingInitiativesEnum? Girisim_sonrasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIRISIM_SONRASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGPAINSCALE"].AllPropertyDefs["POSTNURSINGINITIATIVE"].DataType;
                    return (PostNursingInitiativesEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPainScale_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPainScale_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPainScale_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllPainScalesByNA_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ApplicationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPLICATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGPAINSCALE"].AllPropertyDefs["APPLICATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetAllPainScalesByNA_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllPainScalesByNA_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllPainScalesByNA_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

        public static BindingList<NursingPainScale.GetPainScale_Class> GetPainScale(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGPAINSCALE"].QueryDefs["GetPainScale"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<NursingPainScale.GetPainScale_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingPainScale.GetPainScale_Class> GetPainScale(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGPAINSCALE"].QueryDefs["GetPainScale"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<NursingPainScale.GetPainScale_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<NursingPainScale.GetAllPainScalesByNA_Class> GetAllPainScalesByNA(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGPAINSCALE"].QueryDefs["GetAllPainScalesByNA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<NursingPainScale.GetAllPainScalesByNA_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingPainScale.GetAllPainScalesByNA_Class> GetAllPainScalesByNA(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGPAINSCALE"].QueryDefs["GetAllPainScalesByNA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<NursingPainScale.GetAllPainScalesByNA_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hemşirelik Girişimleri Uygulandı Mı
    /// </summary>
        public DateTime? NursingAppDoneDate
        {
            get { return (DateTime?)this["NURSINGAPPDONEDATE"]; }
            set { this["NURSINGAPPDONEDATE"] = value; }
        }

    /// <summary>
    /// Hemşirelik Girişimi Sonrası
    /// </summary>
        public PostNursingInitiativesEnum? PostNursingInitiative
        {
            get { return (PostNursingInitiativesEnum?)(int?)this["POSTNURSINGINITIATIVE"]; }
            set { this["POSTNURSINGINITIATIVE"] = value; }
        }

        public string PainDetail
        {
            get { return (string)this["PAINDETAIL"]; }
            set { this["PAINDETAIL"] = value; }
        }

        public string PainTime
        {
            get { return (string)this["PAINTIME"]; }
            set { this["PAINTIME"] = value; }
        }

        public string DurationofPain
        {
            get { return (string)this["DURATIONOFPAIN"]; }
            set { this["DURATIONOFPAIN"] = value; }
        }

        public string AchingSide
        {
            get { return (string)this["ACHINGSIDE"]; }
            set { this["ACHINGSIDE"] = value; }
        }

        public string PainQualityDescription
        {
            get { return (string)this["PAINQUALITYDESCRIPTION"]; }
            set { this["PAINQUALITYDESCRIPTION"] = value; }
        }

        public PainFaceScaleEnum? PainFaceScale
        {
            get { return (PainFaceScaleEnum?)(int?)this["PAINFACESCALE"]; }
            set { this["PAINFACESCALE"] = value; }
        }

    /// <summary>
    /// Ağrının Yeri
    /// </summary>
        public PainPlaceDefition PainPlaces
        {
            get { return (PainPlaceDefition)((ITTObject)this).GetParent("PAINPLACES"); }
            set { this["PAINPLACES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ağrının Sıklığı
    /// </summary>
        public PainFrequencyDefiniton PainFrequency
        {
            get { return (PainFrequencyDefiniton)((ITTObject)this).GetParent("PAINFREQUENCY"); }
            set { this["PAINFREQUENCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ağrının Niteliği
    /// </summary>
        public PainQualityDefinition PainQuality
        {
            get { return (PainQualityDefinition)((ITTObject)this).GetParent("PAINQUALITY"); }
            set { this["PAINQUALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateNursingInitiativesCollection()
        {
            _NursingInitiatives = new NursingInitiative.ChildNursingInitiativeCollection(this, new Guid("bcb5bcdf-49a0-43d4-9c6a-1451a3be5c31"));
            ((ITTChildObjectCollection)_NursingInitiatives).GetChildren();
        }

        protected NursingInitiative.ChildNursingInitiativeCollection _NursingInitiatives = null;
        public NursingInitiative.ChildNursingInitiativeCollection NursingInitiatives
        {
            get
            {
                if (_NursingInitiatives == null)
                    CreateNursingInitiativesCollection();
                return _NursingInitiatives;
            }
        }

        virtual protected void CreatePainScaleIncreaseGridsCollection()
        {
            _PainScaleIncreaseGrids = new PainScaleIncreaseGrid.ChildPainScaleIncreaseGridCollection(this, new Guid("94570c6c-1d09-43fc-b753-053fc97000aa"));
            ((ITTChildObjectCollection)_PainScaleIncreaseGrids).GetChildren();
        }

        protected PainScaleIncreaseGrid.ChildPainScaleIncreaseGridCollection _PainScaleIncreaseGrids = null;
        public PainScaleIncreaseGrid.ChildPainScaleIncreaseGridCollection PainScaleIncreaseGrids
        {
            get
            {
                if (_PainScaleIncreaseGrids == null)
                    CreatePainScaleIncreaseGridsCollection();
                return _PainScaleIncreaseGrids;
            }
        }

        virtual protected void CreatePainScaleDecreaseGridCollection()
        {
            _PainScaleDecreaseGrid = new PainScaleDecreaseGrid.ChildPainScaleDecreaseGridCollection(this, new Guid("c9740cdc-4758-4527-a0b1-a3bf150a98f8"));
            ((ITTChildObjectCollection)_PainScaleDecreaseGrid).GetChildren();
        }

        protected PainScaleDecreaseGrid.ChildPainScaleDecreaseGridCollection _PainScaleDecreaseGrid = null;
        public PainScaleDecreaseGrid.ChildPainScaleDecreaseGridCollection PainScaleDecreaseGrid
        {
            get
            {
                if (_PainScaleDecreaseGrid == null)
                    CreatePainScaleDecreaseGridCollection();
                return _PainScaleDecreaseGrid;
            }
        }

        protected NursingPainScale(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingPainScale(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingPainScale(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingPainScale(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingPainScale(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGPAINSCALE", dataRow) { }
        protected NursingPainScale(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGPAINSCALE", dataRow, isImported) { }
        public NursingPainScale(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingPainScale(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingPainScale() : base() { }

    }
}