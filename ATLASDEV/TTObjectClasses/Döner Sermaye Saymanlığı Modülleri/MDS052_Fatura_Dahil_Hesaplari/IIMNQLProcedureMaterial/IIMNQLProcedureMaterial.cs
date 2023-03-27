
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
    public partial class IIMNQLProcedureMaterial : TTObject
    {

        public void Control()
        {
            if (InvoiceInclusionNQL != null && ProcedureDefinition != null)
                throw new TTException(TTUtils.CultureService.GetText("M25742", "Grup ve Hizmet bilgilerinden sadece birisi dolu olabilir."));
        }

        protected override void PreInsert()
        {
            base.PreInsert();
            Control();
        }

        protected override void PreUpdate()
        {
            base.PreUpdate();
            Control();
        }

    }
}