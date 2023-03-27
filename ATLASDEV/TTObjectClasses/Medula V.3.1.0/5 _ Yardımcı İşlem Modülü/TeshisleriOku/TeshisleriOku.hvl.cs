
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TeshisleriOku")] 

    public  partial class TeshisleriOku : BaseMedulaDefinitionAction
    {
        public class TeshisleriOkuList : TTObjectCollection<TeshisleriOku> { }
                    
        public class ChildTeshisleriOkuCollection : TTObject.TTChildObjectCollection<TeshisleriOku>
        {
            public ChildTeshisleriOkuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTeshisleriOkuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTeshisleriOkuWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetTeshisleriOkuWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTeshisleriOkuWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTeshisleriOkuWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("e02265e4-3bc1-4d5f-9660-47be21967a7b"); } }
            public static Guid Completed { get { return new Guid("b9754f30-7c44-483d-9abb-4d93975df15f"); } }
            public static Guid New { get { return new Guid("841a9792-a146-449e-a433-fa4e788e2fdf"); } }
            public static Guid SentMedula { get { return new Guid("c3623af4-cd9d-465f-8feb-bbc6da3694f4"); } }
            public static Guid SentServer { get { return new Guid("f5d88905-460b-4db6-bea1-ea7b8010c629"); } }
            public static Guid Successfully { get { return new Guid("3f8fc646-aa40-47c0-a403-fbfd57da01c0"); } }
            public static Guid Unsuccessfully { get { return new Guid("b2230538-5529-448f-be67-c6c575f3ab13"); } }
        }

        public static BindingList<TeshisleriOku> GetTeshisleriOkuWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TESHISLERIOKU"].QueryDefs["GetTeshisleriOkuWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<TeshisleriOku>(queryDef, paramList);
        }

        public static BindingList<TeshisleriOku.GetTeshisleriOkuWillBeSentToMedulaRQ_Class> GetTeshisleriOkuWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TESHISLERIOKU"].QueryDefs["GetTeshisleriOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<TeshisleriOku.GetTeshisleriOkuWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TeshisleriOku.GetTeshisleriOkuWillBeSentToMedulaRQ_Class> GetTeshisleriOkuWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TESHISLERIOKU"].QueryDefs["GetTeshisleriOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<TeshisleriOku.GetTeshisleriOkuWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public TeshisOkuGirisDVO teshisOkuGirisDVO
        {
            get { return (TeshisOkuGirisDVO)((ITTObject)this).GetParent("TESHISOKUGIRISDVO"); }
            set { this["TESHISOKUGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TeshisleriOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TeshisleriOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TeshisleriOku(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TeshisleriOku(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TeshisleriOku(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TESHISLERIOKU", dataRow) { }
        protected TeshisleriOku(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TESHISLERIOKU", dataRow, isImported) { }
        public TeshisleriOku(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TeshisleriOku(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TeshisleriOku() : base() { }

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