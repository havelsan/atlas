
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugMatch")] 

    public  partial class DrugMatch : TTObject
    {
        public class DrugMatchList : TTObjectCollection<DrugMatch> { }
                    
        public class ChildDrugMatchCollection : TTObject.TTChildObjectCollection<DrugMatch>
        {
            public ChildDrugMatchCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugMatchCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Guid? WrongDrugID
        {
            get { return (Guid?)this["WRONGDRUGID"]; }
            set { this["WRONGDRUGID"] = value; }
        }

        public Guid? MatchDrugID
        {
            get { return (Guid?)this["MATCHDRUGID"]; }
            set { this["MATCHDRUGID"] = value; }
        }

        public bool? Convert
        {
            get { return (bool?)this["CONVERT"]; }
            set { this["CONVERT"] = value; }
        }

        protected DrugMatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugMatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugMatch(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugMatch(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugMatch(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGMATCH", dataRow) { }
        protected DrugMatch(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGMATCH", dataRow, isImported) { }
        public DrugMatch(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugMatch(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugMatch() : base() { }

    }
}