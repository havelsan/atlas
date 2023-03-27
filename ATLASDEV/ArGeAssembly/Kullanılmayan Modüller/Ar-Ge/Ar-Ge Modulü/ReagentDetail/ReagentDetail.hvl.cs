
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReagentDetail")] 

    public  partial class ReagentDetail : TTObject
    {
        public class ReagentDetailList : TTObjectCollection<ReagentDetail> { }
                    
        public class ChildReagentDetailCollection : TTObject.TTChildObjectCollection<ReagentDetail>
        {
            public ChildReagentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReagentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? ReagentAmmount
        {
            get { return (int?)this["REAGENTAMMOUNT"]; }
            set { this["REAGENTAMMOUNT"] = value; }
        }

        public SexEnum? ReagentSex
        {
            get { return (SexEnum?)(int?)this["REAGENTSEX"]; }
            set { this["REAGENTSEX"] = value; }
        }

        public double? ReagentWeight
        {
            get { return (double?)this["REAGENTWEIGHT"]; }
            set { this["REAGENTWEIGHT"] = value; }
        }

        public Currency? ReagentPrice
        {
            get { return (Currency?)this["REAGENTPRICE"]; }
            set { this["REAGENTPRICE"] = value; }
        }

        public ReagentSpeciesDef ReagentSpecies
        {
            get { return (ReagentSpeciesDef)((ITTObject)this).GetParent("REAGENTSPECIES"); }
            set { this["REAGENTSPECIES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ArgeProject ArgeProjectCost
        {
            get { return (ArgeProject)((ITTObject)this).GetParent("ARGEPROJECTCOST"); }
            set { this["ARGEPROJECTCOST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ExchangeTypeDef ExchangeType
        {
            get { return (ExchangeTypeDef)((ITTObject)this).GetParent("EXCHANGETYPE"); }
            set { this["EXCHANGETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ReagentTypeDef ReagentType
        {
            get { return (ReagentTypeDef)((ITTObject)this).GetParent("REAGENTTYPE"); }
            set { this["REAGENTTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ReagentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReagentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReagentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReagentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReagentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REAGENTDETAIL", dataRow) { }
        protected ReagentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REAGENTDETAIL", dataRow, isImported) { }
        public ReagentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReagentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReagentDetail() : base() { }

    }
}