
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HizmetKaydiIptal")] 

    /// <summary>
    /// Hizmet Kaydı İptal
    /// </summary>
    public  partial class HizmetKaydiIptal : BaseMedulaAction
    {
        public class HizmetKaydiIptalList : TTObjectCollection<HizmetKaydiIptal> { }
                    
        public class ChildHizmetKaydiIptalCollection : TTObject.TTChildObjectCollection<HizmetKaydiIptal>
        {
            public ChildHizmetKaydiIptalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHizmetKaydiIptalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHizmetKaydiIptalWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetHizmetKaydiIptalWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHizmetKaydiIptalWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHizmetKaydiIptalWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("ea9ef782-b880-4dea-a930-a3545671c78b"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("522da4b2-2d27-424b-84e4-76f002ecd424"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("d05ee4e1-3afc-45b7-a606-ef8a1eac83ee"); } }
            public static Guid New { get { return new Guid("69b75102-8247-42f7-9582-eac292670995"); } }
            public static Guid SentMedula { get { return new Guid("cefc2a7c-dd8a-4a58-a85e-f35ab17962e7"); } }
            public static Guid SentServer { get { return new Guid("f6080559-76cf-4005-96b6-d54db37b00e0"); } }
        }

        public static BindingList<HizmetKaydiIptal> GetHizmetKaydiIptalWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HIZMETKAYDIIPTAL"].QueryDefs["GetHizmetKaydiIptalWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HizmetKaydiIptal>(queryDef, paramList);
        }

        public static BindingList<HizmetKaydiIptal.GetHizmetKaydiIptalWillBeSentToMedulaRQ_Class> GetHizmetKaydiIptalWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HIZMETKAYDIIPTAL"].QueryDefs["GetHizmetKaydiIptalWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HizmetKaydiIptal.GetHizmetKaydiIptalWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HizmetKaydiIptal.GetHizmetKaydiIptalWillBeSentToMedulaRQ_Class> GetHizmetKaydiIptalWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HIZMETKAYDIIPTAL"].QueryDefs["GetHizmetKaydiIptalWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HizmetKaydiIptal.GetHizmetKaydiIptalWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hizmet İptal Giriş
    /// </summary>
        public HizmetIptalGirisDVO hizmetIptalGirisDVO
        {
            get { return (HizmetIptalGirisDVO)((ITTObject)this).GetParent("HIZMETIPTALGIRISDVO"); }
            set { this["HIZMETIPTALGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HizmetKaydiIptal(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HizmetKaydiIptal(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HizmetKaydiIptal(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HizmetKaydiIptal(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HizmetKaydiIptal(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HIZMETKAYDIIPTAL", dataRow) { }
        protected HizmetKaydiIptal(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HIZMETKAYDIIPTAL", dataRow, isImported) { }
        public HizmetKaydiIptal(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HizmetKaydiIptal(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HizmetKaydiIptal() : base() { }

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