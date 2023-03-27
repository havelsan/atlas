
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
    /// Klinik Doktor İşlemleri
    /// </summary>
    public  partial class ehrInPatientPhysicianApplication : ehrEpisodeAction, IOAInPatientApplication
    {
#region Methods
        // protected override List<OldActionPropertyObject> OldActionPropertyList()
//        {
//            List<OldActionPropertyObject> propertyList;
//            if(base.OldActionPropertyList()==null)
//                propertyList = new List<OldActionPropertyObject>();
//            else
//                propertyList = base.OldActionPropertyList();
//            propertyList.Add(new OldActionPropertyObject("Klinik Doktor İşlemleri Hasta Dosyası",Common.ReturnObjectAsString(this.InPatientFolder)));
//            return propertyList;
//        }
//
//        protected override List<List<List<OldActionPropertyObject>>> OldActionChildRelationList()
//        {
//            List<List<List<OldActionPropertyObject>>> gridList;
//            if(base.OldActionChildRelationList()==null)
//                gridList=new List<List<List<OldActionPropertyObject>>>();
//            else
//                gridList=base.OldActionChildRelationList();
//            
//            gridList.Add(this.OldActionPreDiagnosisList());
//            gridList.Add(this.OldActionSecDiagnosisList());
//            // Hasta Güncesi
//            List<List<OldActionPropertyObject>> gridProgressRowList=new List<List<OldActionPropertyObject>>();
//            foreach(InPatientPhysicianProgresses Progress in this.Progresses)
//            {
//                List<OldActionPropertyObject> gridProgressRowColumnList=new List<OldActionPropertyObject>();
//                gridProgressRowColumnList.Add(new OldActionPropertyObject("İşlem Tarihi",Common.ReturnObjectAsString(Progress.ProgressDate)));
//                gridProgressRowColumnList.Add(new OldActionPropertyObject("Hasta Güncesi",Common.ReturnObjectAsString(Progress.Description)));
//                gridProgressRowList.Add(gridProgressRowColumnList);
//            }
//            gridList.Add(gridProgressRowList);
//            
//            //Beslenme Diyet
//            List<List<OldActionPropertyObject>> gridNutritionDietRowList=new List<List<OldActionPropertyObject>>();
//            foreach(InPatientPhysicianApplicationNutritionDiet NutritionDiet in this.NutritionDiets)
//            {
//                List<OldActionPropertyObject> gridNutritionDietRowColumnList=new List<OldActionPropertyObject>();
//                gridNutritionDietRowColumnList.Add(new OldActionPropertyObject("İşlem Tarihi",Common.ReturnObjectAsString(NutritionDiet.ActionDate)));
//                gridNutritionDietRowColumnList.Add(new OldActionPropertyObject("Diyet İşlemi",Common.ReturnObjectAsString(NutritionDiet.ProcedureObject)));
//                gridNutritionDietRowColumnList.Add(new OldActionPropertyObject("Yeme Yeri",Common.ReturnObjectAsString(NutritionDiet.Place)));
//                gridNutritionDietRowColumnList.Add(new OldActionPropertyObject("Beslenme",Common.ReturnObjectAsString(NutritionDiet.Nutrition)));
//                gridNutritionDietRowList.Add(gridNutritionDietRowColumnList);
//            }
//            gridList.Add(gridNutritionDietRowList);
//            // Hemşire Takip Gözlem Talimatları
//            List<List<OldActionPropertyObject>> gridNursingOrderRowList=new List<List<OldActionPropertyObject>>();
//            foreach(NursingOrder NursingOrder in this.NursingOrders)
//            {
//                List<OldActionPropertyObject> gridNursingOrderRowColumnList=new List<OldActionPropertyObject>();
//                gridNursingOrderRowColumnList.Add(new OldActionPropertyObject("Hemşire Takip Gözlem Talimatları",Common.ReturnObjectAsString(NursingOrder.ProcedureObject.Name)));
//                gridNursingOrderRowColumnList.Add(new OldActionPropertyObject("Başlama Zamanı",Common.ReturnObjectAsString(NursingOrder.PeriodStartTime)));
//                gridNursingOrderRowColumnList.Add(new OldActionPropertyObject("Uygulama Aralığı",Common.ReturnObjectAsString(NursingOrder.Frequency)));
//                gridNursingOrderRowColumnList.Add(new OldActionPropertyObject("Uygulama Miktarı",Common.ReturnObjectAsString(NursingOrder.AmountForPeriod)));
//                gridNursingOrderRowColumnList.Add(new OldActionPropertyObject("Gün",Common.ReturnObjectAsString(NursingOrder.RecurrenceDayAmount)));
//                gridNursingOrderRowList.Add(gridNursingOrderRowColumnList);
//            }
//            gridList.Add(gridNursingOrderRowList);
//            
//            // İlaç Direktifleri
//            List<List<OldActionPropertyObject>> gridDrugOrderRowList=new List<List<OldActionPropertyObject>>();
//            foreach(DrugOrder DrugOrder in this.DrugOrders)
//            {
//                List<OldActionPropertyObject> gridDrugOrderRowColumnList=new List<OldActionPropertyObject>();
//                gridDrugOrderRowColumnList.Add(new OldActionPropertyObject("İlaç",Common.ReturnObjectAsString(DrugOrder.Material.Name)));
//                gridDrugOrderRowColumnList.Add(new OldActionPropertyObject("Planlama Başlangıç Tarihi",Common.ReturnObjectAsString(DrugOrder.PlannedStartTime)));
//                gridDrugOrderRowColumnList.Add(new OldActionPropertyObject("Doz Aralığı",Common.ReturnObjectAsString(DrugOrder.Frequency)));
//                gridDrugOrderRowColumnList.Add(new OldActionPropertyObject("Doz Miktarı",Common.ReturnObjectAsString(DrugOrder.DoseAmount)));
//                gridDrugOrderRowColumnList.Add(new OldActionPropertyObject("Gün",Common.ReturnObjectAsString(DrugOrder.Day)));
//                gridDrugOrderRowList.Add(gridDrugOrderRowColumnList);
//            }
//            gridList.Add(gridDrugOrderRowList);
//
//
//            return gridList;
//        }
        
#endregion Methods

    }
}