
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
    /// Medula Fatura Dönem Tanım Ekranı
    /// </summary>
    public  partial class MedulaInvoiceTermDefinition : TerminologyManagerDef
    {
        public partial class GetMedulaInvoiceTermDefinitions_Class : TTReportNqlObject 
        {
        }

        public partial class GetMedulaInvoiceTermDefs_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            
            if(StartDate != null)
                StartDate = Convert.ToDateTime(((DateTime)StartDate).ToShortDateString() + " " + "00:00:00");
            
            if(EndDate != null)
                EndDate = Convert.ToDateTime(((DateTime)EndDate).ToShortDateString() + " " + "23:59:59");

#endregion PreInsert
        }

        protected override void PostInsert()
        {
#region PostInsert
            
            base.PostInsert();
            
            // Medula Fatura Dönemi eklendiği zaman, o dönem için Medula Fatura Türü tanımı kadar
            // Medula Fatura Dönemi Detayı oluşturulur. 
            /*
            IList MITypeList = MedulaInvoiceTypeDefinition.GetMedulaInvoiceTypes(this.ObjectContext, "");
            foreach(MedulaInvoiceTypeDefinition MIType in MITypeList)
            {
                MedulaInvoiceTermDetailDefinition MITermDetail = new MedulaInvoiceTermDetailDefinition(this.ObjectContext);
                MITermDetail.MedulaInvoiceTerm = this;
                MITermDetail.MedulaInvoiceType = MIType;
            }
            */

#endregion PostInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();
            
            if(StartDate != null)
                StartDate = Convert.ToDateTime(((DateTime)StartDate).ToShortDateString() + " " + "00:00:00");
            
            if(EndDate != null)
                EndDate = Convert.ToDateTime(((DateTime)EndDate).ToShortDateString() + " " + "23:59:59");

#endregion PreUpdate
        }

#region Methods
        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = base.GetMyLocalPropertyNamesList();
            if(localPropertyNamesList==null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("DocumentNo");
            return localPropertyNamesList;
        }
        
#endregion Methods

    }
}