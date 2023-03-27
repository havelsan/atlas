
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
    public  partial class PandemicProcedure : SubActionProcedure
    {
        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            return EpisodeAction?.ProcedureSpeciality?.Code;
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            return MasterSubActionProcedure?.GetDVODrTescilNo(branchCode);
        }
    }
}