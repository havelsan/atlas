
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtocolExceptionProcedureDefinition")] 

    /// <summary>
    /// Kurum Anlaşma Hizmet İstisnaları
    /// </summary>
    public  partial class ProtocolExceptionProcedureDefinition : TerminologyManagerDef
    {
        public class ProtocolExceptionProcedureDefinitionList : TTObjectCollection<ProtocolExceptionProcedureDefinition> { }
                    
        public class ChildProtocolExceptionProcedureDefinitionCollection : TTObject.TTChildObjectCollection<ProtocolExceptionProcedureDefinition>
        {
            public ChildProtocolExceptionProcedureDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtocolExceptionProcedureDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ProtocolExceptionProcedureDefinition> GetByProtocolAndProcedure(TTObjectContext objectContext, string PROTOCOLOBJECTID, string PROCEDUREOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLEXCEPTIONPROCEDUREDEFINITION"].QueryDefs["GetByProtocolAndProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROTOCOLOBJECTID", PROTOCOLOBJECTID);
            paramList.Add("PROCEDUREOBJECTID", PROCEDUREOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<ProtocolExceptionProcedureDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Ayaktan Hasta Payı
    /// </summary>
        public int? OutPatientPatientPercent
        {
            get { return (int?)this["OUTPATIENTPATIENTPERCENT"]; }
            set { this["OUTPATIENTPATIENTPERCENT"] = value; }
        }

    /// <summary>
    /// Yatan Hasta İndirim Oranı
    /// </summary>
        public double? InPatientDiscountPercent
        {
            get { return (double?)this["INPATIENTDISCOUNTPERCENT"]; }
            set { this["INPATIENTDISCOUNTPERCENT"] = value; }
        }

    /// <summary>
    /// Hasta Tutarı
    /// </summary>
        public Currency? PatientPrice
        {
            get { return (Currency?)this["PATIENTPRICE"]; }
            set { this["PATIENTPRICE"] = value; }
        }

    /// <summary>
    /// Ayaktan Hasta Kurum Payı
    /// </summary>
        public int? OutPatientPayerPercent
        {
            get { return (int?)this["OUTPATIENTPAYERPERCENT"]; }
            set { this["OUTPATIENTPAYERPERCENT"] = value; }
        }

    /// <summary>
    /// Ayaktan Hasta İndirim Oranı
    /// </summary>
        public double? OutPatientDiscountPercent
        {
            get { return (double?)this["OUTPATIENTDISCOUNTPERCENT"]; }
            set { this["OUTPATIENTDISCOUNTPERCENT"] = value; }
        }

    /// <summary>
    /// Yatan Hasta Payı
    /// </summary>
        public int? InPatientPatientPercent
        {
            get { return (int?)this["INPATIENTPATIENTPERCENT"]; }
            set { this["INPATIENTPATIENTPERCENT"] = value; }
        }

    /// <summary>
    /// Yatan Hasta Kurum Payı
    /// </summary>
        public int? InPatientPayerPercent
        {
            get { return (int?)this["INPATIENTPAYERPERCENT"]; }
            set { this["INPATIENTPAYERPERCENT"] = value; }
        }

    /// <summary>
    /// Kurum Tutarı
    /// </summary>
        public Currency? PayerPrice
        {
            get { return (Currency?)this["PAYERPRICE"]; }
            set { this["PAYERPRICE"] = value; }
        }

    /// <summary>
    /// Başlangıç Yaşı
    /// </summary>
        public int? StartAge
        {
            get { return (int?)this["STARTAGE"]; }
            set { this["STARTAGE"] = value; }
        }

    /// <summary>
    /// Bitiş Yaşı
    /// </summary>
        public int? EndAge
        {
            get { return (int?)this["ENDAGE"]; }
            set { this["ENDAGE"] = value; }
        }

    /// <summary>
    /// Fiyat Listesi
    /// </summary>
        public PricingListDefinition PricingList
        {
            get { return (PricingListDefinition)((ITTObject)this).GetParent("PRICINGLIST"); }
            set { this["PRICINGLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet
    /// </summary>
        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Anlaşma Tanımı ile ilişki
    /// </summary>
        public ProtocolDefinition Protocol
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOL"); }
            set { this["PROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fiyat Listesi Çarpanı
    /// </summary>
        public PriceMultiplierDefinition PricingListMultiplier
        {
            get { return (PriceMultiplierDefinition)((ITTObject)this).GetParent("PRICINGLISTMULTIPLIER"); }
            set { this["PRICINGLISTMULTIPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Alternatif Fiyat Listesi
    /// </summary>
        public PricingListDefinition SecondPricingList
        {
            get { return (PricingListDefinition)((ITTObject)this).GetParent("SECONDPRICINGLIST"); }
            set { this["SECONDPRICINGLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Alternatif Fiyat Listesi Çarpanı
    /// </summary>
        public PriceMultiplierDefinition SecondPricingListMultiplier
        {
            get { return (PriceMultiplierDefinition)((ITTObject)this).GetParent("SECONDPRICINGLISTMULTIPLIER"); }
            set { this["SECONDPRICINGLISTMULTIPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProtocolExceptionProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtocolExceptionProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtocolExceptionProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtocolExceptionProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtocolExceptionProcedureDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTOCOLEXCEPTIONPROCEDUREDEFINITION", dataRow) { }
        protected ProtocolExceptionProcedureDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTOCOLEXCEPTIONPROCEDUREDEFINITION", dataRow, isImported) { }
        protected ProtocolExceptionProcedureDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtocolExceptionProcedureDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtocolExceptionProcedureDefinition() : base() { }

    }
}