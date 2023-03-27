
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
    /// Paketi Hizmet İstem Template Tanımlama
    /// </summary>
    public partial class PackageTemplateDefinition : TTDefinitionSet
    {

        public List<ProcedureRequestFormDetailDefinition> GetMyProcedureRequests()
        {
            List<ProcedureRequestFormDetailDefinition> myProcedureReqFormDetails = new List<ProcedureRequestFormDetailDefinition>();

            //foreach (ProcedureRequestFormDetailDefinition formDetail in this.ProcedureRequestFormDetailDefinitions)
            //{
            //    myProcedureReqFormDetails.Add(formDetail);
            //}
            return myProcedureReqFormDetails;
        }


        public List<PackageTemplateICDDetailDefinition> GetMyICDs()
        {
            List<PackageTemplateICDDetailDefinition> myICDList = new List<PackageTemplateICDDetailDefinition>();

            foreach (PackageTemplateICDDetailDefinition myICD in PackageTemplateICDs)
            {
                myICDList.Add(myICD);
            }
            return myICDList;
        }
    }
}