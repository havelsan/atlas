
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
    /// Bakım-Onarımı Mümkün Malzeme Etiketi
    /// </summary>
    public partial class BakimOnarimMalzemeEtiketi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public BakimOnarimMalzemeEtiketi MyParentReport
            {
                get { return (BakimOnarimMalzemeEtiketi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1223111 { get {return Body().NewField1223111;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField CLASS { get {return Body().CLASS;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField REPORTNAME { get {return Body().REPORTNAME;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportField SERIALNO { get {return Body().SERIALNO;} }
            public TTReportField MILITARYUNIT { get {return Body().MILITARYUNIT;} }
            public TTReportField NewField1223112 { get {return Body().NewField1223112;} }
            public TTReportField FIRSTCHECKDATE { get {return Body().FIRSTCHECKDATE;} }
            public TTReportField NewField111322 { get {return Body().NewField111322;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportField NewField1132 { get {return Body().NewField1132;} }
            public TTReportField NewField12311 { get {return Body().NewField12311;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField NewField111323 { get {return Body().NewField111323;} }
            public TTReportField DATE { get {return Body().DATE;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class>("GetReferToUpperLevelByObjectIDQuery", ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public BakimOnarimMalzemeEtiketi MyParentReport
                {
                    get { return (BakimOnarimMalzemeEtiketi)ParentReport; }
                }
                
                public TTReportField NewField1223111;
                public TTReportField NewField131;
                public TTReportField NewField1131;
                public TTReportField DESCRIPTION;
                public TTReportField NewField13;
                public TTReportField CLASS;
                public TTReportField NewField12;
                public TTReportField NewField11;
                public TTReportField NewField1;
                public TTReportField REPORTNAME;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField NATOSTOCKNO;
                public TTReportField MATERIALNAME;
                public TTReportShape NewLine2;
                public TTReportField SERIALNO;
                public TTReportField MILITARYUNIT;
                public TTReportField NewField1223112;
                public TTReportField FIRSTCHECKDATE;
                public TTReportField NewField111322;
                public TTReportShape NewLine12;
                public TTReportField NewField1132;
                public TTReportField NewField12311;
                public TTReportField AMOUNT;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField NewField111323;
                public TTReportField DATE;
                public TTReportShape NewLine121; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 105;
                    RepeatCount = 0;
                    
                    NewField1223111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 55, 130, 83, false);
                    NewField1223111.Name = "NewField1223111";
                    NewField1223111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1223111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1223111.TextFont.Name = "Arial";
                    NewField1223111.TextFont.Size = 8;
                    NewField1223111.TextFont.CharSet = 162;
                    NewField1223111.Value = @"İlgili Onaylar";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 31, 130, 39, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 8;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @" Seri Nu.";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 39, 65, 47, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 8;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @" Birlik Adı";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 31, 65, 39, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Name = "Arial";
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 19, 25, 23, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 8;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @" İsmi";

                    CLASS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 13, 129, 17, false);
                    CLASS.Name = "CLASS";
                    CLASS.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLASS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CLASS.WordBreak = EvetHayirEnum.ehEvet;
                    CLASS.TextFont.Name = "Arial";
                    CLASS.TextFont.Size = 8;
                    CLASS.TextFont.CharSet = 162;
                    CLASS.Value = @"{#STOCKCARDCLASS#}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 9, 106, 13, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Sınıfı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 9, 75, 13, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Parça Nu.";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 9, 25, 13, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @" NATO Stok Nu.";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 2, 130, 8, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME.DrawWidth = 2;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 11;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"BAKIM-ONARIMI MÜMKÜN MALZEME ETİKETİ";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 9, 130, 9, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 83, 130, 83, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 13, 42, 17, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.TextFont.Name = "Arial";
                    NATOSTOCKNO.TextFont.Size = 8;
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 23, 77, 31, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.Size = 8;
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#FANAME#}";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 31, 130, 31, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 35, 128, 39, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SERIALNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERIALNO.TextFont.Name = "Arial";
                    SERIALNO.TextFont.Size = 8;
                    SERIALNO.TextFont.CharSet = 162;
                    SERIALNO.Value = @"{#SERIALNUMBER#}";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 43, 64, 47, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.TextFont.Name = "Arial";
                    MILITARYUNIT.TextFont.Size = 8;
                    MILITARYUNIT.TextFont.CharSet = 162;
                    MILITARYUNIT.Value = @"{#SENDERMILITARYUNIT#}";

                    NewField1223112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 56, 35, 64, false);
                    NewField1223112.Name = "NewField1223112";
                    NewField1223112.TextFont.Name = "Arial";
                    NewField1223112.TextFont.Size = 8;
                    NewField1223112.TextFont.CharSet = 162;
                    NewField1223112.Value = @" İlk Muayene Tarihi";

                    FIRSTCHECKDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 60, 34, 64, false);
                    FIRSTCHECKDATE.Name = "FIRSTCHECKDATE";
                    FIRSTCHECKDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRSTCHECKDATE.TextFormat = @"dd/MM/yyyy";
                    FIRSTCHECKDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRSTCHECKDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRSTCHECKDATE.TextFont.Name = "Arial";
                    FIRSTCHECKDATE.TextFont.Size = 8;
                    FIRSTCHECKDATE.TextFont.CharSet = 162;
                    FIRSTCHECKDATE.Value = @"{#CHECKDATE#}";

                    NewField111322 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 47, 35, 55, false);
                    NewField111322.Name = "NewField111322";
                    NewField111322.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111322.TextFont.Name = "Arial";
                    NewField111322.TextFont.Size = 8;
                    NewField111322.TextFont.CharSet = 162;
                    NewField111322.Value = @" Sıra Nu.";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 9, 0, 83, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.DrawWidth = 2;

                    NewField1132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 39, 95, 47, false);
                    NewField1132.Name = "NewField1132";
                    NewField1132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1132.TextFont.Name = "Arial";
                    NewField1132.TextFont.Size = 8;
                    NewField1132.TextFont.CharSet = 162;
                    NewField1132.Value = @" Miktar";

                    NewField12311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 39, 130, 47, false);
                    NewField12311.Name = "NewField12311";
                    NewField12311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12311.TextFont.Name = "Arial";
                    NewField12311.TextFont.Size = 8;
                    NewField12311.TextFont.CharSet = 162;
                    NewField12311.Value = @" Birimi";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 43, 94, 47, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 43, 129, 47, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.WordBreak = EvetHayirEnum.ehEvet;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE.TextFont.Size = 8;
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    NewField111323 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 47, 95, 55, false);
                    NewField111323.Name = "NewField111323";
                    NewField111323.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111323.TextFont.Name = "Arial";
                    NewField111323.TextFont.Size = 8;
                    NewField111323.TextFont.CharSet = 162;
                    NewField111323.Value = @" Sipariş Nu.";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 47, 130, 55, false);
                    DATE.Name = "DATE";
                    DATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.MultiLine = EvetHayirEnum.ehEvet;
                    DATE.TextFont.Name = "Arial";
                    DATE.TextFont.Size = 8;
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @" Tarih
     {@printdate@}";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 130, 9, 130, 83, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class dataset_GetReferToUpperLevelByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class>(0);
                    NewField1223111.CalcValue = NewField1223111.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    DESCRIPTION.CalcValue = @"";
                    NewField13.CalcValue = NewField13.Value;
                    CLASS.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Stockcardclass) : "");
                    NewField12.CalcValue = NewField12.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField1.CalcValue = NewField1.Value;
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    NATOSTOCKNO.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.NATOStockNO) : "");
                    MATERIALNAME.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Faname) : "");
                    SERIALNO.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.SerialNumber) : "");
                    MILITARYUNIT.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Sendermilitaryunit) : "");
                    NewField1223112.CalcValue = NewField1223112.Value;
                    FIRSTCHECKDATE.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.CheckDate) : "");
                    NewField111322.CalcValue = NewField111322.Value;
                    NewField1132.CalcValue = NewField1132.Value;
                    NewField12311.CalcValue = NewField12311.Value;
                    AMOUNT.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Amount) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.DistributionType) : "");
                    NewField111323.CalcValue = NewField111323.Value;
                    DATE.CalcValue = @" Tarih
     " + DateTime.Now.ToShortDateString();
                    return new TTReportObject[] { NewField1223111,NewField131,NewField1131,DESCRIPTION,NewField13,CLASS,NewField12,NewField11,NewField1,REPORTNAME,NATOSTOCKNO,MATERIALNAME,SERIALNO,MILITARYUNIT,NewField1223112,FIRSTCHECKDATE,NewField111322,NewField1132,NewField12311,AMOUNT,DISTRIBUTIONTYPE,NewField111323,DATE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public BakimOnarimMalzemeEtiketi()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "BAKIMONARIMMALZEMEETIKETI";
            Caption = "Bakım-Onarımı Mümkün Malzeme Etiketi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            PaperSize = 256;
            UserMarginLeft = 10;
            UserMarginTop = 10;
            p_PageWidth = 148;
            p_PageHeight = 105;
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
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