
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralPreparationType")] 

    public  partial class MagistralPreparationType : TerminologyManagerDef
    {
        public class MagistralPreparationTypeList : TTObjectCollection<MagistralPreparationType> { }
                    
        public class ChildMagistralPreparationTypeCollection : TTObject.TTChildObjectCollection<MagistralPreparationType>
        {
            public ChildMagistralPreparationTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralPreparationTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<MagistralPreparationType> GetMagistralPrepTypebyLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALPREPARATIONTYPE"].QueryDefs["GetMagistralPrepTypebyLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MagistralPreparationType>(queryDef, paramList);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// SPTS Preparation Type ID
    /// </summary>
        public long? SPTSPreparationTypeID
        {
            get { return (long?)this["SPTSPREPARATIONTYPEID"]; }
            set { this["SPTSPREPARATIONTYPEID"] = value; }
        }

    /// <summary>
    /// Fiyat
    /// </summary>
        public double? Price
        {
            get { return (double?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

    /// <summary>
    /// İlave Fiyat
    /// </summary>
        public double? AdditionalPrice
        {
            get { return (double?)this["ADDITIONALPRICE"]; }
            set { this["ADDITIONALPRICE"] = value; }
        }

    /// <summary>
    /// İlave Miktar
    /// </summary>
        public double? AdditionalAmount
        {
            get { return (double?)this["ADDITIONALAMOUNT"]; }
            set { this["ADDITIONALAMOUNT"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Genel Gider Payı
    /// </summary>
        public MagistralShareOfOverhead MagistralShareOfOverhead
        {
            get { return (MagistralShareOfOverhead)((ITTObject)this).GetParent("MAGISTRALSHAREOFOVERHEAD"); }
            set { this["MAGISTRALSHAREOFOVERHEAD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MagistralPreparationType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralPreparationType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralPreparationType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralPreparationType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralPreparationType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALPREPARATIONTYPE", dataRow) { }
        protected MagistralPreparationType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALPREPARATIONTYPE", dataRow, isImported) { }
        public MagistralPreparationType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralPreparationType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralPreparationType() : base() { }

    }
}