
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DisTaahhutSil")] 

    public  partial class DisTaahhutSil : BaseMedulaAction
    {
        public class DisTaahhutSilList : TTObjectCollection<DisTaahhutSil> { }
                    
        public class ChildDisTaahhutSilCollection : TTObject.TTChildObjectCollection<DisTaahhutSil>
        {
            public ChildDisTaahhutSilCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDisTaahhutSilCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDisTaahhutSilWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDisTaahhutSilWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDisTaahhutSilWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDisTaahhutSilWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid CompletedSuccessfully { get { return new Guid("8ba8f750-d3ae-47cc-b97d-6dc23fb2dd1f"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("22f5b42b-a6dd-41dc-b667-be8b498f603e"); } }
            public static Guid New { get { return new Guid("945ab691-02d2-4e3d-8ecb-70c5e49b983c"); } }
            public static Guid SentMedula { get { return new Guid("c34f9d95-cb19-452e-aecd-1dcc0b318f9a"); } }
            public static Guid SentServer { get { return new Guid("08272bc3-c012-4e2e-a328-5a278d79f860"); } }
            public static Guid Cancelled { get { return new Guid("c920e0a9-e51a-402b-a4bf-b41a9275ebe2"); } }
        }

        public static BindingList<DisTaahhutSil.GetDisTaahhutSilWillBeSentToMedulaRQ_Class> GetDisTaahhutSilWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTAAHHUTSIL"].QueryDefs["GetDisTaahhutSilWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<DisTaahhutSil.GetDisTaahhutSilWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DisTaahhutSil.GetDisTaahhutSilWillBeSentToMedulaRQ_Class> GetDisTaahhutSilWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTAAHHUTSIL"].QueryDefs["GetDisTaahhutSilWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<DisTaahhutSil.GetDisTaahhutSilWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public TaahhutOkuDVO taahhutOkuDVO
        {
            get { return (TaahhutOkuDVO)((ITTObject)this).GetParent("TAAHHUTOKUDVO"); }
            set { this["TAAHHUTOKUDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DisTaahhutSil(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DisTaahhutSil(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DisTaahhutSil(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DisTaahhutSil(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DisTaahhutSil(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISTAAHHUTSIL", dataRow) { }
        protected DisTaahhutSil(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISTAAHHUTSIL", dataRow, isImported) { }
        public DisTaahhutSil(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DisTaahhutSil(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DisTaahhutSil() : base() { }

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