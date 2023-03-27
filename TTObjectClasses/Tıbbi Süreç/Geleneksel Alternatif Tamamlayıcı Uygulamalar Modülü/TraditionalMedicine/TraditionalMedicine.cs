
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
    /// <summary>
    /// Traditional and complementary medicine object
    /// </summary>
    public partial class TraditionalMedicine : SpecialityBasedObject
    {
        public TraditionalMedicine(PhysicianApplication physicianApplication) : this(physicianApplication.ObjectContext)
        {
        }

        protected override void PostUpdate()
        {
            base.PostUpdate();
            new SendToENabiz(ObjectContext, PhysicianApplication.SubEpisode, ObjectID, ObjectDef.Name, "227", Common.RecTime());
        }


    }
}