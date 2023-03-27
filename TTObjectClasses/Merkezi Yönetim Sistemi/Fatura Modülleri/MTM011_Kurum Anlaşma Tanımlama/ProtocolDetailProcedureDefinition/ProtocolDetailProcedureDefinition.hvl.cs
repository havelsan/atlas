
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtocolDetailProcedureDefinition")] 

    /// <summary>
    /// Kurum Anlaşma Hizmet Grup Detayları
    /// </summary>
    public  partial class ProtocolDetailProcedureDefinition : TerminologyManagerDef
    {
        public class ProtocolDetailProcedureDefinitionList : TTObjectCollection<ProtocolDetailProcedureDefinition> { }
                    
        public class ChildProtocolDetailProcedureDefinitionCollection : TTObject.TTChildObjectCollection<ProtocolDetailProcedureDefinition>
        {
            public ChildProtocolDetailProcedureDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtocolDetailProcedureDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ProtocolDetailProcedureDefinition> GetByProtocolAndProcedureTree(TTObjectContext objectContext, string PARAMPROTOCOL, string PARAMPROCEDURETREE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDETAILPROCEDUREDEFINITION"].QueryDefs["GetByProtocolAndProcedureTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPROTOCOL", PARAMPROTOCOL);
            paramList.Add("PARAMPROCEDURETREE", PARAMPROCEDURETREE);

            return ((ITTQuery)objectContext).QueryObjects<ProtocolDetailProcedureDefinition>(queryDef, paramList);
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
    /// Yatan Hasta Payı
    /// </summary>
        public int? InPatientPatientPercent
        {
            get { return (int?)this["INPATIENTPATIENTPERCENT"]; }
            set { this["INPATIENTPATIENTPERCENT"] = value; }
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
    /// Ayaktan Hasta Payı
    /// </summary>
        public int? OutPatientPatientPercent
        {
            get { return (int?)this["OUTPATIENTPATIENTPERCENT"]; }
            set { this["OUTPATIENTPATIENTPERCENT"] = value; }
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
    /// Ayaktan Hasta İndirim Oranı
    /// </summary>
        public double? OutPatientDiscountPercent
        {
            get { return (double?)this["OUTPATIENTDISCOUNTPERCENT"]; }
            set { this["OUTPATIENTDISCOUNTPERCENT"] = value; }
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
    /// Fiyat Listesi
    /// </summary>
        public PricingListDefinition PricingList
        {
            get { return (PricingListDefinition)((ITTObject)this).GetParent("PRICINGLIST"); }
            set { this["PRICINGLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
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
    /// Hizmet Grubu İlişkisi
    /// </summary>
        public ProcedureTreeDefinition ProcedureTree
        {
            get { return (ProcedureTreeDefinition)((ITTObject)this).GetParent("PROCEDURETREE"); }
            set { this["PROCEDURETREE"] = (value==null ? null : (Guid?)value.ObjectID); }
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
    /// Fiyat Listesi Çarpanı
    /// </summary>
        public PriceMultiplierDefinition PricingListMultiplier
        {
            get { return (PriceMultiplierDefinition)((ITTObject)this).GetParent("PRICINGLISTMULTIPLIER"); }
            set { this["PRICINGLISTMULTIPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Alternatif Fiyat Listesi Çarpanı
    /// </summary>
        public PriceMultiplierDefinition SecondPricingListMultiplier
        {
            get { return (PriceMultiplierDefinition)((ITTObject)this).GetParent("SECONDPRICINGLISTMULTIPLIER"); }
            set { this["SECONDPRICINGLISTMULTIPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProtocolDetailProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtocolDetailProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtocolDetailProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtocolDetailProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtocolDetailProcedureDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTOCOLDETAILPROCEDUREDEFINITION", dataRow) { }
        protected ProtocolDetailProcedureDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTOCOLDETAILPROCEDUREDEFINITION", dataRow, isImported) { }
        protected ProtocolDetailProcedureDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtocolDetailProcedureDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtocolDetailProcedureDefinition() : base() { }

    }
}