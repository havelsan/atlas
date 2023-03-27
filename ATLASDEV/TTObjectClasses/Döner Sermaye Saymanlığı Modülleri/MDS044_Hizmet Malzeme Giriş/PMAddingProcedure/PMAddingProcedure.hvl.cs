
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PMAddingProcedure")] 

    public  partial class PMAddingProcedure : SubActionProcedure
    {
        public class PMAddingProcedureList : TTObjectCollection<PMAddingProcedure> { }
                    
        public class ChildPMAddingProcedureCollection : TTObject.TTChildObjectCollection<PMAddingProcedure>
        {
            public ChildPMAddingProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPMAddingProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public static BindingList<PMAddingProcedure> GetPMProcedureByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PMADDINGPROCEDURE"].QueryDefs["GetPMProcedureByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<PMAddingProcedure>(queryDef, paramList);
        }

        public static BindingList<PMAddingProcedure> GetPMProcedureBySubEpisode(TTObjectContext objectContext, Guid EPISODE, Guid SUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PMADDINGPROCEDURE"].QueryDefs["GetPMProcedureBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<PMAddingProcedure>(queryDef, paramList);
        }

    /// <summary>
    /// Kurum Fiyatı
    /// </summary>
        public Currency? PayerPrice
        {
            get { return (Currency?)this["PAYERPRICE"]; }
            set { this["PAYERPRICE"] = value; }
        }

    /// <summary>
    /// Hasta Fiyatı
    /// </summary>
        public Currency? PatientPrice
        {
            get { return (Currency?)this["PATIENTPRICE"]; }
            set { this["PATIENTPRICE"] = value; }
        }

        protected PMAddingProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PMAddingProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PMAddingProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PMAddingProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PMAddingProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PMADDINGPROCEDURE", dataRow) { }
        protected PMAddingProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PMADDINGPROCEDURE", dataRow, isImported) { }
        public PMAddingProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PMAddingProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PMAddingProcedure() : base() { }

    }
}