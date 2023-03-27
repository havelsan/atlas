
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeriyeDonukYatisKabul")] 

    /// <summary>
    /// Geriye Dönük Yatış Kabul
    /// </summary>
    public  partial class GeriyeDonukYatisKabul : BaseHastaKabul
    {
        public class GeriyeDonukYatisKabulList : TTObjectCollection<GeriyeDonukYatisKabul> { }
                    
        public class ChildGeriyeDonukYatisKabulCollection : TTObject.TTChildObjectCollection<GeriyeDonukYatisKabul>
        {
            public ChildGeriyeDonukYatisKabulCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeriyeDonukYatisKabulCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetGeriyeDonukYatisKabulWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetGeriyeDonukYatisKabulWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetGeriyeDonukYatisKabulWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetGeriyeDonukYatisKabulWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("f80268d9-47ef-4970-8d9a-6c3dd9b6ebfb"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("6bb3764f-0341-4c14-b031-9e7f7d2164da"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("d0e756ec-03c6-420a-9db6-d76f0a856b20"); } }
            public static Guid New { get { return new Guid("1bb5434b-f74a-41a0-9966-801a675fab82"); } }
            public static Guid SentMedula { get { return new Guid("c11c6e07-2b33-4da4-bab1-9193d89cebe0"); } }
            public static Guid SentServer { get { return new Guid("4759f134-e16d-4cc5-8f82-5fec2a0a3dab"); } }
        }

        public static BindingList<GeriyeDonukYatisKabul.GetGeriyeDonukYatisKabulWillBeSentToMedulaRQ_Class> GetGeriyeDonukYatisKabulWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GERIYEDONUKYATISKABUL"].QueryDefs["GetGeriyeDonukYatisKabulWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<GeriyeDonukYatisKabul.GetGeriyeDonukYatisKabulWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<GeriyeDonukYatisKabul.GetGeriyeDonukYatisKabulWillBeSentToMedulaRQ_Class> GetGeriyeDonukYatisKabulWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GERIYEDONUKYATISKABUL"].QueryDefs["GetGeriyeDonukYatisKabulWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<GeriyeDonukYatisKabul.GetGeriyeDonukYatisKabulWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<GeriyeDonukYatisKabul> GetGeriyeDonukYatisKabulWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GERIYEDONUKYATISKABUL"].QueryDefs["GetGeriyeDonukYatisKabulWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<GeriyeDonukYatisKabul>(queryDef, paramList);
        }

        protected GeriyeDonukYatisKabul(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeriyeDonukYatisKabul(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeriyeDonukYatisKabul(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeriyeDonukYatisKabul(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeriyeDonukYatisKabul(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GERIYEDONUKYATISKABUL", dataRow) { }
        protected GeriyeDonukYatisKabul(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GERIYEDONUKYATISKABUL", dataRow, isImported) { }
        public GeriyeDonukYatisKabul(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeriyeDonukYatisKabul(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeriyeDonukYatisKabul() : base() { }

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