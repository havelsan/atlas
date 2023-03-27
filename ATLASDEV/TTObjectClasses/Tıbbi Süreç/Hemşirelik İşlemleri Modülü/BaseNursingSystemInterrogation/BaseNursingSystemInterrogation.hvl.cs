
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseNursingSystemInterrogation")] 

    /// <summary>
    /// Hasta Sistem Sorgulama
    /// </summary>
    public  partial class BaseNursingSystemInterrogation : BaseNursingDataEntry
    {
        public class BaseNursingSystemInterrogationList : TTObjectCollection<BaseNursingSystemInterrogation> { }
                    
        public class ChildBaseNursingSystemInterrogationCollection : TTObject.TTChildObjectCollection<BaseNursingSystemInterrogation>
        {
            public ChildBaseNursingSystemInterrogationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseNursingSystemInterrogationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

        virtual protected void CreateNursingSystemInterrogationsCollection()
        {
            _NursingSystemInterrogations = new NursingSystemInterrogation.ChildNursingSystemInterrogationCollection(this, new Guid("5ac988f3-b488-4dc3-a901-da4ce49a2d63"));
            ((ITTChildObjectCollection)_NursingSystemInterrogations).GetChildren();
        }

        protected NursingSystemInterrogation.ChildNursingSystemInterrogationCollection _NursingSystemInterrogations = null;
        public NursingSystemInterrogation.ChildNursingSystemInterrogationCollection NursingSystemInterrogations
        {
            get
            {
                if (_NursingSystemInterrogations == null)
                    CreateNursingSystemInterrogationsCollection();
                return _NursingSystemInterrogations;
            }
        }

        protected BaseNursingSystemInterrogation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseNursingSystemInterrogation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseNursingSystemInterrogation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseNursingSystemInterrogation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseNursingSystemInterrogation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASENURSINGSYSTEMINTERROGATION", dataRow) { }
        protected BaseNursingSystemInterrogation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASENURSINGSYSTEMINTERROGATION", dataRow, isImported) { }
        public BaseNursingSystemInterrogation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseNursingSystemInterrogation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseNursingSystemInterrogation() : base() { }

    }
}