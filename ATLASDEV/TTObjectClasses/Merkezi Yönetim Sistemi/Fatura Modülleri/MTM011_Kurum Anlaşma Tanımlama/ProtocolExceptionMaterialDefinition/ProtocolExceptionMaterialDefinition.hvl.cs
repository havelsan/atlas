
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtocolExceptionMaterialDefinition")] 

    /// <summary>
    /// Kurum Anlaşma Malzeme İstisnaları
    /// </summary>
    public  partial class ProtocolExceptionMaterialDefinition : TerminologyManagerDef
    {
        public class ProtocolExceptionMaterialDefinitionList : TTObjectCollection<ProtocolExceptionMaterialDefinition> { }
                    
        public class ChildProtocolExceptionMaterialDefinitionCollection : TTObject.TTChildObjectCollection<ProtocolExceptionMaterialDefinition>
        {
            public ChildProtocolExceptionMaterialDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtocolExceptionMaterialDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ProtocolExceptionMaterialDefinition> GetByProtocolAndMaterial(TTObjectContext objectContext, string PROTOCOLOBJECTID, string MATERIALOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLEXCEPTIONMATERIALDEFINITION"].QueryDefs["GetByProtocolAndMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROTOCOLOBJECTID", PROTOCOLOBJECTID);
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<ProtocolExceptionMaterialDefinition>(queryDef, paramList);
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
    /// Ayaktan Hasta İndirim Oranı
    /// </summary>
        public double? OutPatientDiscountPercent
        {
            get { return (double?)this["OUTPATIENTDISCOUNTPERCENT"]; }
            set { this["OUTPATIENTDISCOUNTPERCENT"] = value; }
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
    /// Ayaktan Hasta Kurum Payı
    /// </summary>
        public int? OutPatientPayerPercent
        {
            get { return (int?)this["OUTPATIENTPAYERPERCENT"]; }
            set { this["OUTPATIENTPAYERPERCENT"] = value; }
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
    /// Yatan Hasta İndirim Oranı
    /// </summary>
        public double? InPatientDiscountPercent
        {
            get { return (double?)this["INPATIENTDISCOUNTPERCENT"]; }
            set { this["INPATIENTDISCOUNTPERCENT"] = value; }
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
    /// Anlaşma Tanımı ile ilişki
    /// </summary>
        public ProtocolDefinition Protocol
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOL"); }
            set { this["PROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fiyat
    /// </summary>
        public PricingListDefinition PricingList
        {
            get { return (PricingListDefinition)((ITTObject)this).GetParent("PRICINGLIST"); }
            set { this["PRICINGLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Malzeme
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProtocolExceptionMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtocolExceptionMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtocolExceptionMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtocolExceptionMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtocolExceptionMaterialDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTOCOLEXCEPTIONMATERIALDEFINITION", dataRow) { }
        protected ProtocolExceptionMaterialDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTOCOLEXCEPTIONMATERIALDEFINITION", dataRow, isImported) { }
        public ProtocolExceptionMaterialDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtocolExceptionMaterialDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtocolExceptionMaterialDefinition() : base() { }

    }
}