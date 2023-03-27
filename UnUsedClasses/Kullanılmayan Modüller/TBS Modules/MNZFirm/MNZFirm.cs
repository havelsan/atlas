
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
    /// DE_Firma Tanımı
    /// </summary>
    public  partial class MNZFirm : MNZActor
    {
        protected override void PreInsert()
        {
#region PreInsert
            controlFirmProperties();
#endregion PreInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            controlFirmProperties();
#endregion PreUpdate
        }

#region Methods
        public void controlFirmProperties()
        {
            string errorString = "";
            
            if(StartDate.HasValue && !EndDate.HasValue)
                errorString = "İzin bitiş günü belirtilmeli.\n";
            else if(EndDate.HasValue && !StartDate.HasValue)
                errorString += "İzin başlangıç günü belirtilmeli\n";
            else if(StartDate.HasValue && EndDate.HasValue && EndDate < StartDate)
                errorString += "İzin bitiş günü izin başlangıç gününden önce olmamalı\n";
            if(errorString != "")
                throw new TTException("errorString");
        }
        
#endregion Methods

    }
}