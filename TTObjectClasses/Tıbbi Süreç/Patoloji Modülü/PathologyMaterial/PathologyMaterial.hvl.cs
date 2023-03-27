
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyMaterial")] 

    public  partial class PathologyMaterial : TTObject
    {
        public class PathologyMaterialList : TTObjectCollection<PathologyMaterial> { }
                    
        public class ChildPathologyMaterialCollection : TTObject.TTChildObjectCollection<PathologyMaterial>
        {
            public ChildPathologyMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPathologyMaterialsByRequestNQL_Class : TTReportNqlObject 
        {
            public DateTime? Sampletakendate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLETAKENDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["DATEOFSAMPLETAKEN"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Materialno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["MATERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialozellik
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOZELLIK"]);
                }
            }

            public Guid? Alinmasekli
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ALINMASEKLI"]);
                }
            }

            public Guid? Materialyer
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALYER"]);
                }
            }

            public string Klinikbulgu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKBULGU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["CLINICALFINDINGS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPathologyMaterialsByRequestNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyMaterialsByRequestNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyMaterialsByRequestNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyMaterialsByRequestID_Class : TTReportNqlObject 
        {
            public DateTime? Sampletakendate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SAMPLETAKENDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["DATEOFSAMPLETAKEN"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Materialno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["MATERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialozellik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALOZELLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNUMUNEALINDIGIDOKUNUNTEMELOZELLIGI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Alinmasekli
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALINMASEKLI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNUMUNEALINMASEKLI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialyerlesimyeri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALYERLESIMYERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].AllPropertyDefs["KODTANIMI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Klinikbulgu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKBULGU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["CLINICALFINDINGS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public GetPathologyMaterialsByRequestID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyMaterialsByRequestID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyMaterialsByRequestID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyMaterialsByPathology_Class : TTReportNqlObject 
        {
            public Guid? Materialobjid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJID"]);
                }
            }

            public string Materyalnumarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERYALNUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["MATERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Numunealinmatarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMUNEALINMATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["DATEOFSAMPLETAKEN"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string TOPOGRAFIKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOPOGRAFIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].AllPropertyDefs["TOPOGRAFIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KODTANIMI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODTANIMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].AllPropertyDefs["KODTANIMI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Alindigidokununtemelozelligi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALINDIGIDOKUNUNTEMELOZELLIGI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNUMUNEALINDIGIDOKUNUNTEMELOZELLIGI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Numunealinmasekli
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMUNEALINMASEKLI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNUMUNEALINMASEKLI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Preparatdurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREPARATDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPATOLOJIPREPARATIDURUMU"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Morfolojikodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MORFOLOJIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOMORFOLOJIKODU"].AllPropertyDefs["MORFOLOJIKODACIKLAMA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Klinikbulgular
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKBULGULAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["CLINICALFINDINGS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Makroskopi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAKROSKOPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["MACROSCOPY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Mikroskopi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MIKROSKOPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["MICROSCOPY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Notyorum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTYORUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["NOTE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Tani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["PATHOLOGICDIAGNOSIS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? Bening
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BENING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["BENIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Malign
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALIGN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["MALIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Suphelimalign
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPHELIMALIGN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["SUSPICIOUSMALIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Frozen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROZEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["FROZEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetPathologyMaterialsByPathology_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyMaterialsByPathology_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyMaterialsByPathology_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("36ecf220-6d61-4a16-8cb9-7f877f1d0253"); } }
            public static Guid Accept { get { return new Guid("018809dd-ec3b-46c9-a8e5-2216fc199e2d"); } }
    /// <summary>
    /// Numune Red
    /// </summary>
            public static Guid Reject { get { return new Guid("60d312df-69c3-4d92-85a4-0debdc190237"); } }
        }

        public static BindingList<PathologyMaterial.GetPathologyMaterialsByRequestNQL_Class> GetPathologyMaterialsByRequestNQL(string PATHOLOGYREQOBECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].QueryDefs["GetPathologyMaterialsByRequestNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATHOLOGYREQOBECTID", PATHOLOGYREQOBECTID);

            return TTReportNqlObject.QueryObjects<PathologyMaterial.GetPathologyMaterialsByRequestNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyMaterial.GetPathologyMaterialsByRequestNQL_Class> GetPathologyMaterialsByRequestNQL(TTObjectContext objectContext, string PATHOLOGYREQOBECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].QueryDefs["GetPathologyMaterialsByRequestNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATHOLOGYREQOBECTID", PATHOLOGYREQOBECTID);

            return TTReportNqlObject.QueryObjects<PathologyMaterial.GetPathologyMaterialsByRequestNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PathologyMaterial.GetPathologyMaterialsByRequestID_Class> GetPathologyMaterialsByRequestID(Guid PATHOLOGYREQUESTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].QueryDefs["GetPathologyMaterialsByRequestID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATHOLOGYREQUESTID", PATHOLOGYREQUESTID);

            return TTReportNqlObject.QueryObjects<PathologyMaterial.GetPathologyMaterialsByRequestID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyMaterial.GetPathologyMaterialsByRequestID_Class> GetPathologyMaterialsByRequestID(TTObjectContext objectContext, Guid PATHOLOGYREQUESTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].QueryDefs["GetPathologyMaterialsByRequestID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATHOLOGYREQUESTID", PATHOLOGYREQUESTID);

            return TTReportNqlObject.QueryObjects<PathologyMaterial.GetPathologyMaterialsByRequestID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PathologyMaterial.GetPathologyMaterialsByPathology_Class> GetPathologyMaterialsByPathology(Guid PATHOLOGYOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].QueryDefs["GetPathologyMaterialsByPathology"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATHOLOGYOBJECTID", PATHOLOGYOBJECTID);

            return TTReportNqlObject.QueryObjects<PathologyMaterial.GetPathologyMaterialsByPathology_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyMaterial.GetPathologyMaterialsByPathology_Class> GetPathologyMaterialsByPathology(TTObjectContext objectContext, Guid PATHOLOGYOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].QueryDefs["GetPathologyMaterialsByPathology"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATHOLOGYOBJECTID", PATHOLOGYOBJECTID);

            return TTReportNqlObject.QueryObjects<PathologyMaterial.GetPathologyMaterialsByPathology_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Klinik Bulgular
    /// </summary>
        public string ClinicalFindings
        {
            get { return (string)this["CLINICALFINDINGS"]; }
            set { this["CLINICALFINDINGS"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Numune Alınma Tarihi
    /// </summary>
        public DateTime? DateOfSampleTaken
        {
            get { return (DateTime?)this["DATEOFSAMPLETAKEN"]; }
            set { this["DATEOFSAMPLETAKEN"] = value; }
        }

    /// <summary>
    /// Makroskopi
    /// </summary>
        public object Macroscopy
        {
            get { return (object)this["MACROSCOPY"]; }
            set { this["MACROSCOPY"] = value; }
        }

    /// <summary>
    /// Mikroskopi
    /// </summary>
        public object Microscopy
        {
            get { return (object)this["MICROSCOPY"]; }
            set { this["MICROSCOPY"] = value; }
        }

    /// <summary>
    /// Not/Yorum
    /// </summary>
        public object Note
        {
            get { return (object)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Tanı
    /// </summary>
        public object PathologicDiagnosis
        {
            get { return (object)this["PATHOLOGICDIAGNOSIS"]; }
            set { this["PATHOLOGICDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Frozen
    /// </summary>
        public bool? Frozen
        {
            get { return (bool?)this["FROZEN"]; }
            set { this["FROZEN"] = value; }
        }

    /// <summary>
    /// Malign
    /// </summary>
        public bool? Malign
        {
            get { return (bool?)this["MALIGN"]; }
            set { this["MALIGN"] = value; }
        }

    /// <summary>
    /// Materyal Numarası
    /// </summary>
        public string MaterialNumber
        {
            get { return (string)this["MATERIALNUMBER"]; }
            set { this["MATERIALNUMBER"] = value; }
        }

    /// <summary>
    /// No
    /// </summary>
        public int? No
        {
            get { return (int?)this["NO"]; }
            set { this["NO"] = value; }
        }

    /// <summary>
    /// Şüpheli Malign
    /// </summary>
        public bool? SuspiciousMalign
        {
            get { return (bool?)this["SUSPICIOUSMALIGN"]; }
            set { this["SUSPICIOUSMALIGN"] = value; }
        }

    /// <summary>
    /// Benign
    /// </summary>
        public bool? Benign
        {
            get { return (bool?)this["BENIGN"]; }
            set { this["BENIGN"] = value; }
        }

        public SKRSNumuneAlindigiDokununTemelOzelligi AlindigiDokununTemelOzelligi
        {
            get { return (SKRSNumuneAlindigiDokununTemelOzelligi)((ITTObject)this).GetParent("ALINDIGIDOKUNUNTEMELOZELLIGI"); }
            set { this["ALINDIGIDOKUNUNTEMELOZELLIGI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSICDOMORFOLOJIKODU MorfolojiKodu
        {
            get { return (SKRSICDOMORFOLOJIKODU)((ITTObject)this).GetParent("MORFOLOJIKODU"); }
            set { this["MORFOLOJIKODU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSNumuneAlinmaSekli NumuneAlinmaSekli
        {
            get { return (SKRSNumuneAlinmaSekli)((ITTObject)this).GetParent("NUMUNEALINMASEKLI"); }
            set { this["NUMUNEALINMASEKLI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSPatolojiPreparatiDurumu PatolojiPreparatiDurumu
        {
            get { return (SKRSPatolojiPreparatiDurumu)((ITTObject)this).GetParent("PATOLOJIPREPARATIDURUMU"); }
            set { this["PATOLOJIPREPARATIDURUMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSICDOYERLESIMYERI YerlesimYeri
        {
            get { return (SKRSICDOYERLESIMYERI)((ITTObject)this).GetParent("YERLESIMYERI"); }
            set { this["YERLESIMYERI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PathologyRequest PathologyRequest
        {
            get { return (PathologyRequest)((ITTObject)this).GetParent("PATHOLOGYREQUEST"); }
            set { this["PATHOLOGYREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Pathology Pathology
        {
            get { return (Pathology)((ITTObject)this).GetParent("PATHOLOGY"); }
            set { this["PATHOLOGY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Patoloji Materyal Red Nedeni İlişkisi
    /// </summary>
        public ReasonForPathologyRejection ReasonForPathologyRejection
        {
            get { return (ReasonForPathologyRejection)((ITTObject)this).GetParent("REASONFORPATHOLOGYREJECTION"); }
            set { this["REASONFORPATHOLOGYREJECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PathologyJarTypeDef KavanozTipi
        {
            get { return (PathologyJarTypeDef)((ITTObject)this).GetParent("KAVANOZTIPI"); }
            set { this["KAVANOZTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePathologyTestProcedureCollection()
        {
            _PathologyTestProcedure = new PathologyTestProcedure.ChildPathologyTestProcedureCollection(this, new Guid("fbe263c5-2046-41f0-aa02-df5520b1ad14"));
            ((ITTChildObjectCollection)_PathologyTestProcedure).GetChildren();
        }

        protected PathologyTestProcedure.ChildPathologyTestProcedureCollection _PathologyTestProcedure = null;
        public PathologyTestProcedure.ChildPathologyTestProcedureCollection PathologyTestProcedure
        {
            get
            {
                if (_PathologyTestProcedure == null)
                    CreatePathologyTestProcedureCollection();
                return _PathologyTestProcedure;
            }
        }

        protected PathologyMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYMATERIAL", dataRow) { }
        protected PathologyMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYMATERIAL", dataRow, isImported) { }
        public PathologyMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyMaterial() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}