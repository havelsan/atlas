
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaintenanceOrderCost")] 

    /// <summary>
    /// Sipariş Maliyet Sekmesi
    /// </summary>
    public  partial class MaintenanceOrderCost : TTObject
    {
        public class MaintenanceOrderCostList : TTObjectCollection<MaintenanceOrderCost> { }
                    
        public class ChildMaintenanceOrderCostCollection : TTObject.TTChildObjectCollection<MaintenanceOrderCost>
        {
            public ChildMaintenanceOrderCostCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintenanceOrderCostCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Amortisman Gideri
    /// </summary>
        public Currency? DepreciationExpense
        {
            get { return (Currency?)this["DEPRECIATIONEXPENSE"]; }
            set { this["DEPRECIATIONEXPENSE"] = value; }
        }

    /// <summary>
    /// Ortalama Direk İşcilik Gideri
    /// </summary>
        public Currency? AvarageDirectLaborCost
        {
            get { return (Currency?)this["AVARAGEDIRECTLABORCOST"]; }
            set { this["AVARAGEDIRECTLABORCOST"] = value; }
        }

    /// <summary>
    /// Genel Üretim Giderleri
    /// </summary>
        public Currency? GeneralProcessingCost
        {
            get { return (Currency?)this["GENERALPROCESSINGCOST"]; }
            set { this["GENERALPROCESSINGCOST"] = value; }
        }

    /// <summary>
    /// Ortalama Amortisman Gideri
    /// </summary>
        public Currency? AverageDepreciationExpense
        {
            get { return (Currency?)this["AVERAGEDEPRECIATIONEXPENSE"]; }
            set { this["AVERAGEDEPRECIATIONEXPENSE"] = value; }
        }

    /// <summary>
    /// Net İşcilik Gideri
    /// </summary>
        public Currency? SharpLaborCost
        {
            get { return (Currency?)this["SHARPLABORCOST"]; }
            set { this["SHARPLABORCOST"] = value; }
        }

    /// <summary>
    /// Ortalama Genel Üretim Giderleri
    /// </summary>
        public Currency? AverageGeneralProcessingCost
        {
            get { return (Currency?)this["AVERAGEGENERALPROCESSINGCOST"]; }
            set { this["AVERAGEGENERALPROCESSINGCOST"] = value; }
        }

    /// <summary>
    /// Direk Malzeme Gideri
    /// </summary>
        public Currency? DirectMaterialExpense
        {
            get { return (Currency?)this["DIRECTMATERIALEXPENSE"]; }
            set { this["DIRECTMATERIALEXPENSE"] = value; }
        }

    /// <summary>
    /// İşcilik Gideri
    /// </summary>
        public Currency? LaborCost
        {
            get { return (Currency?)this["LABORCOST"]; }
            set { this["LABORCOST"] = value; }
        }

        public MaintenanceOrder MaintenanceOrder
        {
            get { return (MaintenanceOrder)((ITTObject)this).GetParent("MAINTENANCEORDER"); }
            set { this["MAINTENANCEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaintenanceOrderCost(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaintenanceOrderCost(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaintenanceOrderCost(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaintenanceOrderCost(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaintenanceOrderCost(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTENANCEORDERCOST", dataRow) { }
        protected MaintenanceOrderCost(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTENANCEORDERCOST", dataRow, isImported) { }
        public MaintenanceOrderCost(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaintenanceOrderCost(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaintenanceOrderCost() : base() { }

    }
}