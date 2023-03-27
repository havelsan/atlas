
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralPreparationSubType")] 

    public  partial class MagistralPreparationSubType : TerminologyManagerDef
    {
        public class MagistralPreparationSubTypeList : TTObjectCollection<MagistralPreparationSubType> { }
                    
        public class ChildMagistralPreparationSubTypeCollection : TTObject.TTChildObjectCollection<MagistralPreparationSubType>
        {
            public ChildMagistralPreparationSubTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralPreparationSubTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<MagistralPreparationSubType> GetMagistralPrepSubTypebyLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALPREPARATIONSUBTYPE"].QueryDefs["GetMagistralPrepSubTypebyLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MagistralPreparationSubType>(queryDef, paramList);
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
    /// SPTS Preparation SubType ID
    /// </summary>
        public long? SPTSPreparationSubTypeID
        {
            get { return (long?)this["SPTSPREPARATIONSUBTYPEID"]; }
            set { this["SPTSPREPARATIONSUBTYPEID"] = value; }
        }

    /// <summary>
    /// Fiyat
    /// </summary>
        public double? Price
        {
            get { return (double?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Genel Gider Payı
    /// </summary>
        public MagistralShareOfOverhead MagistralShareOfOverhead
        {
            get { return (MagistralShareOfOverhead)((ITTObject)this).GetParent("MAGISTRALSHAREOFOVERHEAD"); }
            set { this["MAGISTRALSHAREOFOVERHEAD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Preparat Türü
    /// </summary>
        public MagistralPreparationType MagistralPreparationType
        {
            get { return (MagistralPreparationType)((ITTObject)this).GetParent("MAGISTRALPREPARATIONTYPE"); }
            set { this["MAGISTRALPREPARATIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MagistralPreparationSubType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralPreparationSubType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralPreparationSubType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralPreparationSubType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralPreparationSubType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALPREPARATIONSUBTYPE", dataRow) { }
        protected MagistralPreparationSubType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALPREPARATIONSUBTYPE", dataRow, isImported) { }
        public MagistralPreparationSubType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralPreparationSubType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralPreparationSubType() : base() { }

    }
}