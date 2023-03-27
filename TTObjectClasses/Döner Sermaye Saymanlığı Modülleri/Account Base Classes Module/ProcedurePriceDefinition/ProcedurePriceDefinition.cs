
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
    /// Hizmet Fiyat Eşleştirme Tanımı
    /// </summary>
    public  partial class ProcedurePriceDefinition : TerminologyManagerDef
    {
        public partial class ProcedurePriceListNQL_Class : TTReportNqlObject 
        {
        }

        public partial class ProcedurePriceListByProcedure_Class : TTReportNqlObject 
        {
        }

        public partial class ProcedurePriceListByProcedureAndPriceList_Class : TTReportNqlObject 
        {
        }

        protected override void PostInsert()
        {
#region PostInsert
            
            base.PostInsert();
            // Eşleştirilen fiyat tarih olarak geçerli ise aynı fiyat listesinden eşleşmiş olduğu aktif fiyat var mı diye kontrol edilir
            // bu kontrol sadece merkezde yapılır
            ResHospital hospital = Common.GetCurrentHospital(ObjectContext);
            if(hospital.Site.ObjectID == Sites.SiteMerkezSagKom)
            {
                if((DateTime)PricingDetail.DateStart <= Common.RecTime() && Common.RecTime() <= (DateTime)PricingDetail.DateEnd)
                {
                    IList<ProcedurePriceListByProcedureAndPriceList_Class> list = ProcedurePriceListByProcedureAndPriceList(ProcedureObject.ObjectID.ToString(), PricingDetail.PricingList.ObjectID.ToString());
                    foreach (ProcedurePriceDefinition.ProcedurePriceListByProcedureAndPriceList_Class procedurePrice in list)
                    {
                        if(procedurePrice.ObjectID.ToString() != ObjectID.ToString())
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25307", "Bu hizmetin aynı fiyat listesinden aktif tarihli bir fiyat eşleştirmesi bulunmaktadır! Sistem ikinci bir aktif tarihli eşleştirmeye izin vermemektedir."));
                    }
                }
            }

#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            base.PostUpdate();
            // Eşleştirilen fiyat tarih olarak geçerli ise aynı fiyat listesinden eşleşmiş olduğu aktif fiyat var mı diye kontrol edilir
            // bu kontrol sadece merkezde yapılır
            ResHospital hospital = Common.GetCurrentHospital(ObjectContext);
            if(hospital.Site.ObjectID == Sites.SiteMerkezSagKom)
            {
                if((DateTime)PricingDetail.DateStart <= Common.RecTime() && Common.RecTime() <= (DateTime)PricingDetail.DateEnd)
                {
                    IList<ProcedurePriceListByProcedureAndPriceList_Class> list = ProcedurePriceListByProcedureAndPriceList(ProcedureObject.ObjectID.ToString(), PricingDetail.PricingList.ObjectID.ToString());
                    foreach (ProcedurePriceDefinition.ProcedurePriceListByProcedureAndPriceList_Class procedurePrice in list)
                    {
                        if(procedurePrice.ObjectID.ToString() != ObjectID.ToString())
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25307", "Bu hizmetin aynı fiyat listesinden aktif tarihli bir fiyat eşleştirmesi bulunmaktadır! Sistem ikinci bir aktif tarihli eşleştirmeye izin vermemektedir."));
                    }
                }
            }

#endregion PostUpdate
        }

#region Methods
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.ProcedurePriceInfo;
        }
        
#endregion Methods

    }
}