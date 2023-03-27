
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IliskiliTakipHastaKabul")] 

    /// <summary>
    /// İlişkili Takip Hasta Kabul
    /// </summary>
    public  partial class IliskiliTakipHastaKabul : BaseHastaKabul
    {
        public class IliskiliTakipHastaKabulList : TTObjectCollection<IliskiliTakipHastaKabul> { }
                    
        public class ChildIliskiliTakipHastaKabulCollection : TTObject.TTChildObjectCollection<IliskiliTakipHastaKabul>
        {
            public ChildIliskiliTakipHastaKabulCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIliskiliTakipHastaKabulCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetIliskiliTakipHKWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetIliskiliTakipHKWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIliskiliTakipHKWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIliskiliTakipHKWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("c02a4a7e-40c4-44b0-b70e-07339608acf9"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("9f32bdd5-3ce0-4536-aace-4ba41fddd98a"); } }
            public static Guid New { get { return new Guid("a3ed6109-31e1-4596-9783-cb1c396d1073"); } }
            public static Guid SentMedula { get { return new Guid("66b74335-66ee-4f50-9c56-55e35955ecf1"); } }
            public static Guid SentServer { get { return new Guid("5ac14568-a13f-4eac-891f-b45697fe7390"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("7e3f508f-e3a5-44aa-9370-7ff7b3ce4b98"); } }
        }

        public static BindingList<IliskiliTakipHastaKabul.GetIliskiliTakipHKWillBeSentToMedulaRQ_Class> GetIliskiliTakipHKWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILISKILITAKIPHASTAKABUL"].QueryDefs["GetIliskiliTakipHKWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<IliskiliTakipHastaKabul.GetIliskiliTakipHKWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<IliskiliTakipHastaKabul.GetIliskiliTakipHKWillBeSentToMedulaRQ_Class> GetIliskiliTakipHKWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILISKILITAKIPHASTAKABUL"].QueryDefs["GetIliskiliTakipHKWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<IliskiliTakipHastaKabul.GetIliskiliTakipHKWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<IliskiliTakipHastaKabul> GetIliskiliTakipHastaKabulWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILISKILITAKIPHASTAKABUL"].QueryDefs["GetIliskiliTakipHastaKabulWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<IliskiliTakipHastaKabul>(queryDef, paramList);
        }

        protected IliskiliTakipHastaKabul(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IliskiliTakipHastaKabul(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IliskiliTakipHastaKabul(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IliskiliTakipHastaKabul(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IliskiliTakipHastaKabul(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ILISKILITAKIPHASTAKABUL", dataRow) { }
        protected IliskiliTakipHastaKabul(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ILISKILITAKIPHASTAKABUL", dataRow, isImported) { }
        public IliskiliTakipHastaKabul(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IliskiliTakipHastaKabul(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IliskiliTakipHastaKabul() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}