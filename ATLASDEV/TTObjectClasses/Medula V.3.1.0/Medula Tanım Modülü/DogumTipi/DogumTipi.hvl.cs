
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DogumTipi")] 

    public  partial class DogumTipi : BaseMedulaDefinition
    {
        public class DogumTipiList : TTObjectCollection<DogumTipi> { }
                    
        public class ChildDogumTipiCollection : TTObject.TTChildObjectCollection<DogumTipi>
        {
            public ChildDogumTipiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDogumTipiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDogumTipiDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string dogumTipiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUMTIPIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOGUMTIPI"].AllPropertyDefs["DOGUMTIPIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string dogumTipiAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUMTIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOGUMTIPI"].AllPropertyDefs["DOGUMTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDogumTipiDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDogumTipiDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDogumTipiDefinitionQuery_Class() : base() { }
        }

        public static BindingList<DogumTipi.GetDogumTipiDefinitionQuery_Class> GetDogumTipiDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOGUMTIPI"].QueryDefs["GetDogumTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DogumTipi.GetDogumTipiDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DogumTipi.GetDogumTipiDefinitionQuery_Class> GetDogumTipiDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOGUMTIPI"].QueryDefs["GetDogumTipiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DogumTipi.GetDogumTipiDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string dogumTipiAdi
        {
            get { return (string)this["DOGUMTIPIADI"]; }
            set { this["DOGUMTIPIADI"] = value; }
        }

        public string dogumTipiAdi_Shadow
        {
            get { return (string)this["DOGUMTIPIADI_SHADOW"]; }
        }

        public string dogumTipiKodu
        {
            get { return (string)this["DOGUMTIPIKODU"]; }
            set { this["DOGUMTIPIKODU"] = value; }
        }

        protected DogumTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DogumTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DogumTipi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DogumTipi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DogumTipi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOGUMTIPI", dataRow) { }
        protected DogumTipi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOGUMTIPI", dataRow, isImported) { }
        public DogumTipi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DogumTipi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DogumTipi() : base() { }

    }
}