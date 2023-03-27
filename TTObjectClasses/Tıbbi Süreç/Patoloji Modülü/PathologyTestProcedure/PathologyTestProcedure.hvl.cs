
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyTestProcedure")] 

    public  partial class PathologyTestProcedure : SubActionProcedure
    {
        public class PathologyTestProcedureList : TTObjectCollection<PathologyTestProcedure> { }
                    
        public class ChildPathologyTestProcedureCollection : TTObject.TTChildObjectCollection<PathologyTestProcedure>
        {
            public ChildPathologyTestProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyTestProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPathologyProceduresByMaterialObjectID_Class : TTReportNqlObject 
        {
            public Guid? Subactionprocedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBACTIONPROCEDUREOBJECTID"]);
                }
            }

            public string Procedurecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Requestby
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTBY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Requestdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Procedureobjectdef
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTDEF"]);
                }
            }

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string Proceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPathologyProceduresByMaterialObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyProceduresByMaterialObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyProceduresByMaterialObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_PATOLOJI_Class : TTReportNqlObject 
        {
            public Guid? Patoloji_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATOLOJI_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Hasta_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public Object Patoloji_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATOLOJI_TURU"]);
                }
            }

            public string Patoloji_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATOLOJI_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Tetkik_ornek_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TETKIK_ORNEK_KODU"]);
                }
            }

            public Guid? Hizmet_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HIZMET_KODU"]);
                }
            }

            public string Materyal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERYAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Organ
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORGAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].AllPropertyDefs["KODTANIMI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Bulgular
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BULGULAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["CLINICALFINDINGS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patolojik_tani_morfoloji_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATOLOJIK_TANI_MORFOLOJI_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOMORFOLOJIKODU"].AllPropertyDefs["MORFOLOJIKOD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Patolojik_tani_yerlesim_yeri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATOLOJIK_TANI_YERLESIM_YERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].AllPropertyDefs["SKRSKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public object Makroskopi_sonucu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAKROSKOPI_SONUCU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["MACROSCOPY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Mikroskopi_sonucu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MIKROSKOPI_SONUCU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["MICROSCOPY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Guid? Hekim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEKIM_KODU"]);
                }
            }

            public DateTime? Parca_kabul_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARCA_KABUL_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Rapor_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPOR_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Patoloji_aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATOLOJI_ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Histopatolojik_tani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HISTOPATOLOJIK_TANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["PATHOLOGICDIAGNOSIS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Sitopatolojik_tani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SITOPATOLOJIK_TANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["PATHOLOGICDIAGNOSIS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Object Histokimyasal_boyama
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HISTOKIMYASAL_BOYAMA"]);
                }
            }

            public Object Immunhistokimya_boyama
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["IMMUNHISTOKIMYA_BOYAMA"]);
                }
            }

            public Object Frozen_tani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FROZEN_TANI"]);
                }
            }

            public Object Boyama_yontemi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BOYAMA_YONTEMI"]);
                }
            }

            public Guid? Hekim1_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEKIM1_KODU"]);
                }
            }

            public Guid? Hekim2_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEKIM2_KODU"]);
                }
            }

            public Object Hekim3_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HEKIM3_KODU"]);
                }
            }

            public Object Yorum
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YORUM"]);
                }
            }

            public Guid? Ekleyen_kullanici_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_PATOLOJI_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_PATOLOJI_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_PATOLOJI_Class() : base() { }
        }

        [Serializable] 

        public partial class PathologyTestProcedureByObjectIDQuery_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PricingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsResultSeen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTSEEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["ISRESULTSEEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? FromClinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMCLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["FROMCLINIC"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public PathologyTestProcedureByObjectIDQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyTestProcedureByObjectIDQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyTestProcedureByObjectIDQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyProceduresByPathologyMaterial_Class : TTReportNqlObject 
        {
            public Guid? Subactionprocedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBACTIONPROCEDUREOBJECTID"]);
                }
            }

            public string Tetkikkodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIKKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Tetkikadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Tetkikadeti
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIKADETI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Tetkikisteyendoktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIKISTEYENDOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tetkiktamamlanmatarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIKTAMAMLANMATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tetkikistemtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIKISTEMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Procedureobjectdef
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTDEF"]);
                }
            }

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public GetPathologyProceduresByPathologyMaterial_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyProceduresByPathologyMaterial_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyProceduresByPathologyMaterial_Class() : base() { }
        }

        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public static BindingList<PathologyTestProcedure.GetPathologyProceduresByMaterialObjectID_Class> GetPathologyProceduresByMaterialObjectID(Guid MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].QueryDefs["GetPathologyProceduresByMaterialObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<PathologyTestProcedure.GetPathologyProceduresByMaterialObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyTestProcedure.GetPathologyProceduresByMaterialObjectID_Class> GetPathologyProceduresByMaterialObjectID(TTObjectContext objectContext, Guid MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].QueryDefs["GetPathologyProceduresByMaterialObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<PathologyTestProcedure.GetPathologyProceduresByMaterialObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PathologyTestProcedure.VEM_PATOLOJI_Class> VEM_PATOLOJI(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].QueryDefs["VEM_PATOLOJI"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyTestProcedure.VEM_PATOLOJI_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyTestProcedure.VEM_PATOLOJI_Class> VEM_PATOLOJI(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].QueryDefs["VEM_PATOLOJI"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyTestProcedure.VEM_PATOLOJI_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PathologyTestProcedure.PathologyTestProcedureByObjectIDQuery_Class> PathologyTestProcedureByObjectIDQuery(string PARAMTESTOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].QueryDefs["PathologyTestProcedureByObjectIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTESTOBJID", PARAMTESTOBJID);

            return TTReportNqlObject.QueryObjects<PathologyTestProcedure.PathologyTestProcedureByObjectIDQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyTestProcedure.PathologyTestProcedureByObjectIDQuery_Class> PathologyTestProcedureByObjectIDQuery(TTObjectContext objectContext, string PARAMTESTOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].QueryDefs["PathologyTestProcedureByObjectIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTESTOBJID", PARAMTESTOBJID);

            return TTReportNqlObject.QueryObjects<PathologyTestProcedure.PathologyTestProcedureByObjectIDQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PathologyTestProcedure.GetPathologyProceduresByPathologyMaterial_Class> GetPathologyProceduresByPathologyMaterial(Guid PATHOLOGYMATERIALOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].QueryDefs["GetPathologyProceduresByPathologyMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATHOLOGYMATERIALOBJID", PATHOLOGYMATERIALOBJID);

            return TTReportNqlObject.QueryObjects<PathologyTestProcedure.GetPathologyProceduresByPathologyMaterial_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyTestProcedure.GetPathologyProceduresByPathologyMaterial_Class> GetPathologyProceduresByPathologyMaterial(TTObjectContext objectContext, Guid PATHOLOGYMATERIALOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYTESTPROCEDURE"].QueryDefs["GetPathologyProceduresByPathologyMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATHOLOGYMATERIALOBJID", PATHOLOGYMATERIALOBJID);

            return TTReportNqlObject.QueryObjects<PathologyTestProcedure.GetPathologyProceduresByPathologyMaterial_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sonuç görüntülendi ise True olacak.
    /// </summary>
        public bool? IsResultSeen
        {
            get { return (bool?)this["ISRESULTSEEN"]; }
            set { this["ISRESULTSEEN"] = value; }
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
    /// Klinikten eklenen işlemler
    /// </summary>
        public bool? FromClinic
        {
            get { return (bool?)this["FROMCLINIC"]; }
            set { this["FROMCLINIC"] = value; }
        }

        public PathologyMaterial PathologyMaterial
        {
            get { return (PathologyMaterial)((ITTObject)this).GetParent("PATHOLOGYMATERIAL"); }
            set { this["PATHOLOGYMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PathologyRequest PathologyRequest
        {
            get { return (PathologyRequest)((ITTObject)this).GetParent("PATHOLOGYREQUEST"); }
            set { this["PATHOLOGYREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Patoloji Test Kategori Tanım İlişkisi
    /// </summary>
        public PathologyTestCategoryDefinition TestCategory
        {
            get { return (PathologyTestCategoryDefinition)((ITTObject)this).GetParent("TESTCATEGORY"); }
            set { this["TESTCATEGORY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Pathology Pathology
        {
            get 
            {   
                if (EpisodeAction is Pathology)
                    return (Pathology)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected PathologyTestProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyTestProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyTestProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyTestProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyTestProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYTESTPROCEDURE", dataRow) { }
        protected PathologyTestProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYTESTPROCEDURE", dataRow, isImported) { }
        public PathologyTestProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyTestProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyTestProcedure() : base() { }

    }
}