
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// Bakım Onarım Sonu. Raporu
    /// </summary>
    public partial class BakimOnarımSonucRaporu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public BakimOnarımSonucRaporu MyParentReport
            {
                get { return (BakimOnarımSonucRaporu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField111151112 { get {return Body().NewField111151112;} }
            public TTReportField NewField11115111 { get {return Body().NewField11115111;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField SECTION { get {return Body().SECTION;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField REQUESTNO { get {return Body().REQUESTNO;} }
            public TTReportField NewField11511 { get {return Body().NewField11511;} }
            public TTReportField NewField111511 { get {return Body().NewField111511;} }
            public TTReportField NewField1115111 { get {return Body().NewField1115111;} }
            public TTReportField NewField111151111 { get {return Body().NewField111151111;} }
            public TTReportField SENDERSECTION { get {return Body().SENDERSECTION;} }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField MARK { get {return Body().MARK;} }
            public TTReportField SERIALNO { get {return Body().SERIALNO;} }
            public TTReportField NewField111512 { get {return Body().NewField111512;} }
            public TTReportField NewField1215111 { get {return Body().NewField1215111;} }
            public TTReportField NewField11115121 { get {return Body().NewField11115121;} }
            public TTReportField NewField1211151111 { get {return Body().NewField1211151111;} }
            public TTReportField STATEDATE { get {return Body().STATEDATE;} }
            public TTReportField NewField11111511121 { get {return Body().NewField11111511121;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField NewField1112 { get {return Body().NewField1112;} }
            public TTReportField REPAIRNOTES { get {return Body().REPAIRNOTES;} }
            public TTReportField USEDMATERIALS { get {return Body().USEDMATERIALS;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField RESPONSIBLEUSER { get {return Body().RESPONSIBLEUSER;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public BakimOnarımSonucRaporu MyParentReport
                {
                    get { return (BakimOnarımSonucRaporu)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField111151112;
                public TTReportField NewField11115111;
                public TTReportField NewField12;
                public TTReportField MATERIALNAME;
                public TTReportField SECTION;
                public TTReportField NATOSTOCKNO;
                public TTReportField REQUESTNO;
                public TTReportField NewField11511;
                public TTReportField NewField111511;
                public TTReportField NewField1115111;
                public TTReportField NewField111151111;
                public TTReportField SENDERSECTION;
                public TTReportField REQUESTDATE;
                public TTReportField MARK;
                public TTReportField SERIALNO;
                public TTReportField NewField111512;
                public TTReportField NewField1215111;
                public TTReportField NewField11115121;
                public TTReportField NewField1211151111;
                public TTReportField STATEDATE;
                public TTReportField NewField11111511121;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField1112;
                public TTReportField REPAIRNOTES;
                public TTReportField USEDMATERIALS;
                public TTReportField NewField2;
                public TTReportField RESPONSIBLEUSER; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 272;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 108, 202, 167, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1.TextFont.Size = 10;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"YAPILAN İŞLEM :";

                    NewField111151112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 72, 202, 83, false);
                    NewField111151112.Name = "NewField111151112";
                    NewField111151112.TextFont.Size = 10;
                    NewField111151112.TextFont.Bold = true;
                    NewField111151112.Value = @"İŞİN BAŞLANGIÇ TARİHİ :";

                    NewField11115111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 61, 202, 72, false);
                    NewField11115111.Name = "NewField11115111";
                    NewField11115111.TextFont.Size = 10;
                    NewField11115111.TextFont.Bold = true;
                    NewField11115111.Value = @"İŞİ YAPACAK KISIM :";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 17, 202, 24, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Size = 12;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"İŞ SEVK FORMU";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 28, 126, 39, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Size = 10;
                    MATERIALNAME.Value = @"";

                    SECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 64, 192, 69, false);
                    SECTION.Name = "SECTION";
                    SECTION.DrawStyle = DrawStyleConstants.vbInvisible;
                    SECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECTION.TextFont.Size = 10;
                    SECTION.Value = @"";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 39, 202, 50, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.TextFont.Size = 10;
                    NATOSTOCKNO.Value = @"";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 50, 202, 61, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.TextFont.Size = 10;
                    REQUESTNO.Value = @"";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 28, 61, 39, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.TextFont.Size = 10;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.Value = @"ADI";

                    NewField111511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 39, 61, 50, false);
                    NewField111511.Name = "NewField111511";
                    NewField111511.TextFont.Size = 10;
                    NewField111511.TextFont.Bold = true;
                    NewField111511.Value = @"MARKASI - MODELİ";

                    NewField1115111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 50, 61, 61, false);
                    NewField1115111.Name = "NewField1115111";
                    NewField1115111.TextFont.Size = 10;
                    NewField1115111.TextFont.Bold = true;
                    NewField1115111.Value = @"SERİ NO";

                    NewField111151111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 28, 22, 61, false);
                    NewField111151111.Name = "NewField111151111";
                    NewField111151111.FontAngle = 900;
                    NewField111151111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111151111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111151111.TextFont.Size = 10;
                    NewField111151111.TextFont.Bold = true;
                    NewField111151111.Value = @"CİHAZIN";

                    SENDERSECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 28, 202, 39, false);
                    SENDERSECTION.Name = "SENDERSECTION";
                    SENDERSECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERSECTION.MultiLine = EvetHayirEnum.ehEvet;
                    SENDERSECTION.WordBreak = EvetHayirEnum.ehEvet;
                    SENDERSECTION.Value = @"";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 75, 200, 80, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.DrawStyle = DrawStyleConstants.vbInvisible;
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"dd/MM/yyyy";
                    REQUESTDATE.TextFont.Size = 10;
                    REQUESTDATE.Value = @"";

                    MARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 39, 126, 50, false);
                    MARK.Name = "MARK";
                    MARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK.MultiLine = EvetHayirEnum.ehEvet;
                    MARK.WordBreak = EvetHayirEnum.ehEvet;
                    MARK.TextFont.Size = 10;
                    MARK.Value = @"";

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 50, 126, 61, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.MultiLine = EvetHayirEnum.ehEvet;
                    SERIALNO.WordBreak = EvetHayirEnum.ehEvet;
                    SERIALNO.TextFont.Size = 10;
                    SERIALNO.Value = @"";

                    NewField111512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 28, 165, 39, false);
                    NewField111512.Name = "NewField111512";
                    NewField111512.TextFont.Size = 10;
                    NewField111512.TextFont.Bold = true;
                    NewField111512.Value = @"KLİNİĞİ";

                    NewField1215111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 39, 165, 50, false);
                    NewField1215111.Name = "NewField1215111";
                    NewField1215111.TextFont.Size = 10;
                    NewField1215111.TextFont.Bold = true;
                    NewField1215111.Value = @"STOK NO";

                    NewField11115121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 50, 165, 61, false);
                    NewField11115121.Name = "NewField11115121";
                    NewField11115121.TextFont.Size = 10;
                    NewField11115121.TextFont.Bold = true;
                    NewField11115121.Value = @"İSTEK VE İŞ NO";

                    NewField1211151111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 83, 202, 94, false);
                    NewField1211151111.Name = "NewField1211151111";
                    NewField1211151111.TextFont.Size = 10;
                    NewField1211151111.TextFont.Bold = true;
                    NewField1211151111.Value = @"İŞİN BİTİŞ TARİHİ :";

                    STATEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 86, 188, 91, false);
                    STATEDATE.Name = "STATEDATE";
                    STATEDATE.DrawStyle = DrawStyleConstants.vbInvisible;
                    STATEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATEDATE.TextFormat = @"dd/MM/yyyy";
                    STATEDATE.TextFont.Size = 10;
                    STATEDATE.Value = @"";

                    NewField11111511121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 97, 202, 108, false);
                    NewField11111511121.Name = "NewField11111511121";
                    NewField11111511121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111511121.TextFont.Size = 10;
                    NewField11111511121.TextFont.Bold = true;
                    NewField11111511121.Value = @"BAKIM - ONARIM - KALİBRASYON SONUÇ RAPORU";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 167, 202, 221, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField11.TextFont.Size = 10;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"KULLANILAN MALZEME :";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 221, 75, 264, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField111.TextFont.Size = 10;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"TESLİM EDİLEN KLİNK PER.";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 221, 138, 264, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1111.TextFont.Size = 10;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"BAKIM VE ONARIMI YAPAN TEK.";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 221, 202, 264, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1112.TextFont.Size = 10;
                    NewField1112.TextFont.Bold = true;
                    NewField1112.Value = @"ATÖLYE KISIM AMİRİ";

                    REPAIRNOTES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 113, 199, 165, false);
                    REPAIRNOTES.Name = "REPAIRNOTES";
                    REPAIRNOTES.DrawStyle = DrawStyleConstants.vbInvisible;
                    REPAIRNOTES.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPAIRNOTES.VertAlign = VerticalAlignmentEnum.vaTop;
                    REPAIRNOTES.MultiLine = EvetHayirEnum.ehEvet;
                    REPAIRNOTES.WordBreak = EvetHayirEnum.ehEvet;
                    REPAIRNOTES.TextFont.Size = 10;
                    REPAIRNOTES.Value = @"";

                    USEDMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 172, 199, 218, false);
                    USEDMATERIALS.Name = "USEDMATERIALS";
                    USEDMATERIALS.DrawStyle = DrawStyleConstants.vbInvisible;
                    USEDMATERIALS.FieldType = ReportFieldTypeEnum.ftVariable;
                    USEDMATERIALS.VertAlign = VerticalAlignmentEnum.vaTop;
                    USEDMATERIALS.MultiLine = EvetHayirEnum.ehEvet;
                    USEDMATERIALS.WordBreak = EvetHayirEnum.ehEvet;
                    USEDMATERIALS.TextFont.Size = 10;
                    USEDMATERIALS.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 34, 21, 57, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField2.FontAngle = 900;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"CİHAZIN";

                    RESPONSIBLEUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 241, 135, 262, false);
                    RESPONSIBLEUSER.Name = "RESPONSIBLEUSER";
                    RESPONSIBLEUSER.DrawStyle = DrawStyleConstants.vbInvisible;
                    RESPONSIBLEUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RESPONSIBLEUSER.MultiLine = EvetHayirEnum.ehEvet;
                    RESPONSIBLEUSER.WordBreak = EvetHayirEnum.ehEvet;
                    RESPONSIBLEUSER.TextFont.Size = 10;
                    RESPONSIBLEUSER.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField111151112.CalcValue = NewField111151112.Value;
                    NewField11115111.CalcValue = NewField11115111.Value;
                    NewField12.CalcValue = NewField12.Value;
                    MATERIALNAME.CalcValue = @"";
                    SECTION.CalcValue = @"";
                    NATOSTOCKNO.CalcValue = @"";
                    REQUESTNO.CalcValue = @"";
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField111511.CalcValue = NewField111511.Value;
                    NewField1115111.CalcValue = NewField1115111.Value;
                    NewField111151111.CalcValue = NewField111151111.Value;
                    SENDERSECTION.CalcValue = @"";
                    REQUESTDATE.CalcValue = @"";
                    MARK.CalcValue = @"";
                    SERIALNO.CalcValue = @"";
                    NewField111512.CalcValue = NewField111512.Value;
                    NewField1215111.CalcValue = NewField1215111.Value;
                    NewField11115121.CalcValue = NewField11115121.Value;
                    NewField1211151111.CalcValue = NewField1211151111.Value;
                    STATEDATE.CalcValue = @"";
                    NewField11111511121.CalcValue = NewField11111511121.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    REPAIRNOTES.CalcValue = @"";
                    USEDMATERIALS.CalcValue = @"";
                    NewField2.CalcValue = NewField2.Value;
                    RESPONSIBLEUSER.CalcValue = @"";
                    return new TTReportObject[] { NewField1,NewField111151112,NewField11115111,NewField12,MATERIALNAME,SECTION,NATOSTOCKNO,REQUESTNO,NewField11511,NewField111511,NewField1115111,NewField111151111,SENDERSECTION,REQUESTDATE,MARK,SERIALNO,NewField111512,NewField1215111,NewField11115121,NewField1211151111,STATEDATE,NewField11111511121,NewField11,NewField111,NewField1111,NewField1112,REPAIRNOTES,USEDMATERIALS,NewField2,RESPONSIBLEUSER};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    CMRAction cmrAction = (CMRAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(CMRAction));
            string signDesc = string.Empty;
            string usedMaterials = string.Empty;

            if (cmrAction is MaterialRepair)
            {
                MaterialRepair mRepair = (MaterialRepair)cmrAction;
                MATERIALNAME.CalcValue = mRepair.FixedAssetDefinition.Name;
                NATOSTOCKNO.CalcValue = mRepair.FixedAssetDefinition.NATOStockNO;
                SECTION.CalcValue = mRepair.Section.Name;
                SENDERSECTION.CalcValue = mRepair.SenderSection.Name;
                REQUESTNO.CalcValue = mRepair.RequestNo.ToString();
                REQUESTDATE.CalcValue = ((DateTime)mRepair.StartDate).ToShortDateString();
                REPAIRNOTES.CalcValue = mRepair.RepairNotes;
                if(mRepair.EndDate != null)
                {
                    STATEDATE.CalcValue = ((DateTime)mRepair.EndDate).ToShortDateString();
                }
                foreach (UsedConsumedMaterail material in mRepair.UsedConsumedMaterails)
                {
                    usedMaterials = usedMaterials + material.Material.Name  +" - "+ material.Amount.ToString() + "\r\n";
                }
                USEDMATERIALS.CalcValue = usedMaterials;
                signDesc += mRepair.ResponsibleUser.Name + "\r\n";
                if (mRepair.ResponsibleUser.MilitaryClass != null)
                    signDesc += mRepair.ResponsibleUser.MilitaryClass.ShortName;
                if (mRepair.ResponsibleUser.Rank != null)
                    signDesc += mRepair.ResponsibleUser.Rank.ShortName + "\r\n";
                signDesc += "(" + mRepair.ResponsibleUser.EmploymentRecordID + ")";
                RESPONSIBLEUSER.CalcValue = signDesc ;
                
            }
            else
            {
                Repair repair = (Repair)cmrAction;
                MATERIALNAME.CalcValue = repair.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;
                NATOSTOCKNO.CalcValue = repair.FixedAssetMaterialDefinition.FixedAssetDefinition.NATOStockNO;
                SECTION .CalcValue = repair.Section.Name;
                SENDERSECTION.CalcValue = repair.SenderSection.Name ;
                REQUESTNO.CalcValue = repair.RequestNo.ToString();
                REQUESTDATE.CalcValue = ((DateTime)repair.StartDate).ToShortDateString ();
                REPAIRNOTES.CalcValue = repair.RepairNotes;
                MARK.CalcValue = repair.FixedAssetMaterialDefinition.Mark + " - " +repair.FixedAssetMaterialDefinition.Model;
                SERIALNO.CalcValue = repair.FixedAssetMaterialDefinition.SerialNumber;
                if(repair.EndDate != null)
                {
                    STATEDATE.CalcValue = ((DateTime)repair.EndDate).ToShortDateString();
                }
                foreach(UsedConsumedMaterail material in repair.UsedConsumedMaterails)
                {
                    usedMaterials = usedMaterials + material.Material.Name + " - " + material.Amount.ToString() + "\r\n";
                }
                USEDMATERIALS.CalcValue = usedMaterials;
                signDesc += repair.ResponsibleUser.Name + "\r\n";
                if(repair.ResponsibleUser.MilitaryClass != null)
                    signDesc += repair.ResponsibleUser.MilitaryClass.ShortName;
                if(repair.ResponsibleUser.Rank != null)
                    signDesc += repair.ResponsibleUser.Rank.ShortName + "\r\n";
                signDesc += "(" + repair.ResponsibleUser.EmploymentRecordID + ")";
                RESPONSIBLEUSER.CalcValue = signDesc  ;
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public BakimOnarımSonucRaporu()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "Onarım", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "BAKIMONARıMSONUCRAPORU";
            Caption = "Bakım Onarım Sonu. Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaMiddle;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial";
            fd.TextFont.Size = 9;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}