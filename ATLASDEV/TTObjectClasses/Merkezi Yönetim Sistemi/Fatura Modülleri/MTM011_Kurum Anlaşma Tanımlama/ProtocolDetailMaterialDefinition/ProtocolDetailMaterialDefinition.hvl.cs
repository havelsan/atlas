
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtocolDetailMaterialDefinition")] 

    /// <summary>
    /// Kurum Anlaşma Malzeme Grup Detayları
    /// </summary>
    public  partial class ProtocolDetailMaterialDefinition : TerminologyManagerDef
    {
        public class ProtocolDetailMaterialDefinitionList : TTObjectCollection<ProtocolDetailMaterialDefinition> { }
                    
        public class ChildProtocolDetailMaterialDefinitionCollection : TTObject.TTChildObjectCollection<ProtocolDetailMaterialDefinition>
        {
            public ChildProtocolDetailMaterialDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtocolDetailMaterialDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ProtocolDetailMaterialDefinition> GetByProtocolAndMaterialTree(TTObjectContext objectContext, string PARAMPROTOCOL, string PARAMMATERIALTREE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDETAILMATERIALDEFINITION"].QueryDefs["GetByProtocolAndMaterialTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPROTOCOL", PARAMPROTOCOL);
            paramList.Add("PARAMMATERIALTREE", PARAMMATERIALTREE);

            return ((ITTQuery)objectContext).QueryObjects<ProtocolDetailMaterialDefinition>(queryDef, paramList);
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
    /// Ayaktan Hasta Payı
    /// </summary>
        public int? OutPatientPatientPercent
        {
            get { return (int?)this["OUTPATIENTPATIENTPERCENT"]; }
            set { this["OUTPATIENTPATIENTPERCENT"] = value; }
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
    /// Yatan Hasta İndirim Oranı
    /// </summary>
        public double? InPatientDiscountPercent
        {
            get { return (double?)this["INPATIENTDISCOUNTPERCENT"]; }
            set { this["INPATIENTDISCOUNTPERCENT"] = value; }
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
    /// Anlaşma Tanımı ile ilişki
    /// </summary>
        public ProtocolDefinition Protocol
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOL"); }
            set { this["PROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Malzeme Grubu ilişkisi
    /// </summary>
        public MaterialTreeDefinition MaterialTree
        {
            get { return (MaterialTreeDefinition)((ITTObject)this).GetParent("MATERIALTREE"); }
            set { this["MATERIALTREE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fiyat Listesi
    /// </summary>
        public PricingListDefinition PricingList
        {
            get { return (PricingListDefinition)((ITTObject)this).GetParent("PRICINGLIST"); }
            set { this["PRICINGLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProtocolDetailMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtocolDetailMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtocolDetailMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtocolDetailMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtocolDetailMaterialDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTOCOLDETAILMATERIALDEFINITION", dataRow) { }
        protected ProtocolDetailMaterialDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTOCOLDETAILMATERIALDEFINITION", dataRow, isImported) { }
        protected ProtocolDetailMaterialDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtocolDetailMaterialDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtocolDetailMaterialDefinition() : base() { }

    }
}