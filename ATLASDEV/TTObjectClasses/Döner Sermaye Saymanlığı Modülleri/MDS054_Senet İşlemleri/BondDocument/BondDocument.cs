
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
    public  partial class BondDocument : AccountDocument
    {
        protected override void PreInsert()
        {
            Guid bondNoSequence = new Guid("7b2fab50-49de-4499-866b-2d674cf39d73");
            DocumentNo = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[bondNoSequence], null, null).ToString();
        }
    }
}