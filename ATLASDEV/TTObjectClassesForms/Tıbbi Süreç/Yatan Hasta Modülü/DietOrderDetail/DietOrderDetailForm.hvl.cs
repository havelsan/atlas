
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
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Hasta Diyet Detayları
    /// </summary>
    public partial class DietOrderDetailForm : SubactionProcedureFlowableForm
    {
    /// <summary>
    /// Yatan Hasta Diyet
    /// </summary>
        protected TTObjectClasses.DietOrderDetail _DietOrderDetail
        {
            get { return (TTObjectClasses.DietOrderDetail)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTCheckBox BreakfastMealTypes;
        protected ITTCheckBox Snack3MealTypes;
        protected ITTCheckBox DinnerMealTypes;
        protected ITTCheckBox Snack2MealTypes;
        protected ITTCheckBox LunchMealTypes;
        protected ITTCheckBox Snack1MealTypes;
        protected ITTCheckBox NightBreakfastMealTypes;
        protected ITTLabel labelWeightEpisode;
        protected ITTTextBox WeightEpisode;
        protected ITTTextBox HeigthEpisode;
        protected ITTLabel labelHeigthEpisode;
        protected ITTLabel labelWorkListDate;
        protected ITTDateTimePicker WorkListDate;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelProcedure;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("c45bf862-d60c-4fa2-8fd8-3191fc984391"));
            BreakfastMealTypes = (ITTCheckBox)AddControl(new Guid("23f73d6f-dc1f-48d7-aeb9-416957dc00eb"));
            Snack3MealTypes = (ITTCheckBox)AddControl(new Guid("5e229124-12c5-4640-9cc5-e9c65fb65ff3"));
            DinnerMealTypes = (ITTCheckBox)AddControl(new Guid("15067e2e-7b8f-4648-b9cc-e6bf486ccdd5"));
            Snack2MealTypes = (ITTCheckBox)AddControl(new Guid("6075527f-28e2-43fc-9d28-387a1ac22c4f"));
            LunchMealTypes = (ITTCheckBox)AddControl(new Guid("eb258b88-e2c4-49a5-8345-01bc4a41a8f7"));
            Snack1MealTypes = (ITTCheckBox)AddControl(new Guid("aa9d667e-b9a9-4a20-8b5f-6b12089daa5f"));
            NightBreakfastMealTypes = (ITTCheckBox)AddControl(new Guid("82e1b7b2-2c76-47d2-943a-178b095628c8"));
            labelWeightEpisode = (ITTLabel)AddControl(new Guid("8b913384-fb5c-4ca4-8344-89878e350eaf"));
            WeightEpisode = (ITTTextBox)AddControl(new Guid("4843cc2b-5f40-42ff-9a02-b54ac953b853"));
            HeigthEpisode = (ITTTextBox)AddControl(new Guid("31397fa2-12bc-43cc-a2b1-ca0a8125d1b4"));
            labelHeigthEpisode = (ITTLabel)AddControl(new Guid("63f7f398-44e2-48ed-990a-141f55b0e2f5"));
            labelWorkListDate = (ITTLabel)AddControl(new Guid("af36d2b3-fbcf-485f-9a24-390397a67501"));
            WorkListDate = (ITTDateTimePicker)AddControl(new Guid("e0e5c3ef-50eb-4445-a6e4-a6d786b240f5"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("d1507f61-19a5-45e8-8a05-3e95ac2c165e"));
            labelProcedure = (ITTLabel)AddControl(new Guid("083fb435-f60b-44d5-ac96-5fdf98b399bc"));
            base.InitializeControls();
        }

        public DietOrderDetailForm() : base("DIETORDERDETAIL", "DietOrderDetailForm")
        {
        }

        protected DietOrderDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}