
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
    /// Kullanıcı Seviyesi Bakım Formu
    /// </summary>
    public partial class UserMaintenanceReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public UserMaintenanceReport MyParentReport
            {
                get { return (UserMaintenanceReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField121211 { get {return Header().NewField121211;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11212 { get {return Header().NewField11212;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NATOSTOCKNO { get {return Header().NATOSTOCKNO;} }
            public TTReportField RESPONSIBLEPERSON { get {return Header().RESPONSIBLEPERSON;} }
            public TTReportField MARKMODEL { get {return Header().MARKMODEL;} }
            public TTReportField MATERIALNAME { get {return Header().MATERIALNAME;} }
            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField143 { get {return Header().NewField143;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField REPORTNAME1 { get {return Header().REPORTNAME1;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportShape NewLine13 { get {return Footer().NewLine13;} }
            public TTReportField Aciklama { get {return Footer().Aciklama;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField NewField161 { get {return Footer().NewField161;} }
            public TTReportField REPORTNAME11 { get {return Footer().REPORTNAME11;} }
            public TTReportField NewField1161 { get {return Footer().NewField1161;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<CMRActionRequest.GetUserMaintenanceReportQuery_Class>("GetUserMaintenanceReportQuery", CMRActionRequest.GetUserMaintenanceReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public UserMaintenanceReport MyParentReport
                {
                    get { return (UserMaintenanceReport)ParentReport; }
                }
                
                public TTReportField NewField121211;
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportField NewField11212;
                public TTReportField NewField121;
                public TTReportField NATOSTOCKNO;
                public TTReportField RESPONSIBLEPERSON;
                public TTReportField MARKMODEL;
                public TTReportField MATERIALNAME;
                public TTReportField REPORTNAME;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField141;
                public TTReportField NewField142;
                public TTReportField NewField143;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine121;
                public TTReportShape NewLine111;
                public TTReportField REPORTNAME1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 59;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField121211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 49, 124, 59, false);
                    NewField121211.Name = "NewField121211";
                    NewField121211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121211.TextFont.Name = "Arial";
                    NewField121211.TextFont.Bold = true;
                    NewField121211.TextFont.CharSet = 162;
                    NewField121211.Value = @"Yapılacak İşlemler";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 49, 139, 59, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Günlük
Bakım";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 49, 154, 59, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Haftalık
Bakım";

                    NewField11212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 49, 200, 59, false);
                    NewField11212.Name = "NewField11212";
                    NewField11212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11212.TextFont.Name = "Arial";
                    NewField11212.TextFont.Bold = true;
                    NewField11212.TextFont.CharSet = 162;
                    NewField11212.Value = @"Açıklamalar";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 49, 31, 59, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Sıra
Nu.";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 37, 200, 42, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.TextFont.Name = "Arial";
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    RESPONSIBLEPERSON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 42, 200, 47, false);
                    RESPONSIBLEPERSON.Name = "RESPONSIBLEPERSON";
                    RESPONSIBLEPERSON.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEPERSON.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESPONSIBLEPERSON.TextFont.Name = "Arial";
                    RESPONSIBLEPERSON.TextFont.CharSet = 162;
                    RESPONSIBLEPERSON.Value = @"";

                    MARKMODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 32, 200, 37, false);
                    MARKMODEL.Name = "MARKMODEL";
                    MARKMODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKMODEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKMODEL.TextFont.Name = "Arial";
                    MARKMODEL.TextFont.CharSet = 162;
                    MARKMODEL.Value = @"{#MARK#} / {#MODEL#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 27, 200, 32, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 15, 200, 20, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 11;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"KULLANICI SEVİYESİ BAKIM FORMU";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 27, 52, 32, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @" Cihazın Adı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 32, 52, 37, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @" Marka ve Modeli";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 37, 52, 42, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @" Stok Nu.";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 42, 52, 47, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @" Sorumlu Personel";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 42, 54, 47, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @":";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 37, 54, 42, false);
                    NewField141.Name = "NewField141";
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @":";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 32, 54, 37, false);
                    NewField142.Name = "NewField142";
                    NewField142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField142.TextFont.Name = "Arial";
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @":";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 27, 54, 32, false);
                    NewField143.Name = "NewField143";
                    NewField143.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField143.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField143.TextFont.Name = "Arial";
                    NewField143.TextFont.Bold = true;
                    NewField143.TextFont.CharSet = 162;
                    NewField143.Value = @":";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 25, 200, 25, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 49, 200, 49, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 25, 20, 59, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.DrawWidth = 2;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 25, 200, 59, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.DrawWidth = 2;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 59, 200, 59, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    REPORTNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 6, 137, 11, false);
                    REPORTNAME1.Name = "REPORTNAME1";
                    REPORTNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1.TextFont.Name = "Arial";
                    REPORTNAME1.TextFont.Size = 11;
                    REPORTNAME1.TextFont.Bold = true;
                    REPORTNAME1.TextFont.CharSet = 162;
                    REPORTNAME1.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetUserMaintenanceReportQuery_Class dataset_GetUserMaintenanceReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.GetUserMaintenanceReportQuery_Class>(0);
                    NewField121211.CalcValue = NewField121211.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11212.CalcValue = NewField11212.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NATOSTOCKNO.CalcValue = (dataset_GetUserMaintenanceReportQuery != null ? Globals.ToStringCore(dataset_GetUserMaintenanceReportQuery.NATOStockNO) : "");
                    RESPONSIBLEPERSON.CalcValue = @"";
                    MARKMODEL.CalcValue = (dataset_GetUserMaintenanceReportQuery != null ? Globals.ToStringCore(dataset_GetUserMaintenanceReportQuery.Mark) : "") + @" / " + (dataset_GetUserMaintenanceReportQuery != null ? Globals.ToStringCore(dataset_GetUserMaintenanceReportQuery.Model) : "");
                    MATERIALNAME.CalcValue = (dataset_GetUserMaintenanceReportQuery != null ? Globals.ToStringCore(dataset_GetUserMaintenanceReportQuery.Materialname) : "");
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField143.CalcValue = NewField143.Value;
                    REPORTNAME1.CalcValue = REPORTNAME1.Value;
                    return new TTReportObject[] { NewField121211,NewField1121,NewField11211,NewField11212,NewField121,NATOSTOCKNO,RESPONSIBLEPERSON,MARKMODEL,MATERIALNAME,REPORTNAME,NewField1,NewField11,NewField12,NewField13,NewField14,NewField141,NewField142,NewField143,REPORTNAME1};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    CMRActionRequest cmrRequest = (CMRActionRequest)MyParentReport.ReportObjectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.TTOBJECTID.ToString()), typeof(CMRActionRequest));
            if(cmrRequest.DeviceUser != null)
                RESPONSIBLEPERSON.CalcValue = cmrRequest.DeviceUser.Name;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public UserMaintenanceReport MyParentReport
                {
                    get { return (UserMaintenanceReport)ParentReport; }
                }
                
                public TTReportField NewField15;
                public TTReportShape NewLine13;
                public TTReportField Aciklama;
                public TTReportField NewField2;
                public TTReportField NewField16;
                public TTReportField NewField161;
                public TTReportField REPORTNAME11;
                public TTReportField NewField1161; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 72;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 21, 121, 26, false);
                    NewField15.Name = "NewField15";
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.Underline = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"O N A Y";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 0, 200, 0, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.DrawWidth = 2;

                    Aciklama = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 6, 200, 11, false);
                    Aciklama.Name = "Aciklama";
                    Aciklama.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Aciklama.TextFont.Name = "Arial";
                    Aciklama.TextFont.Size = 11;
                    Aciklama.TextFont.Bold = true;
                    Aciklama.TextFont.CharSet = 162;
                    Aciklama.Value = @"NOT: İşlemlerin yapılması için, Cihazın Bakım Talimatından yararlanılır.";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 28, 137, 33, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.Value = @"....................................................";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 35, 137, 40, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.Value = @"....................................................";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 40, 137, 47, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.TextFont.Size = 12;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"XXXXXX.Shh.İkm.Bkm.Mrk.K.lığı";

                    REPORTNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 58, 137, 65, false);
                    REPORTNAME11.Name = "REPORTNAME11";
                    REPORTNAME11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME11.TextFont.Name = "Arial";
                    REPORTNAME11.TextFont.Size = 11;
                    REPORTNAME11.TextFont.Bold = true;
                    REPORTNAME11.TextFont.CharSet = 162;
                    REPORTNAME11.Value = @"HİZMETE ÖZEL";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 52, 137, 58, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1161.TextFont.Name = "Arial";
                    NewField1161.TextFont.Size = 12;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"3-8";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetUserMaintenanceReportQuery_Class dataset_GetUserMaintenanceReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.GetUserMaintenanceReportQuery_Class>(0);
                    NewField15.CalcValue = NewField15.Value;
                    Aciklama.CalcValue = Aciklama.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField161.CalcValue = NewField161.Value;
                    REPORTNAME11.CalcValue = REPORTNAME11.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    return new TTReportObject[] { NewField15,Aciklama,NewField2,NewField16,NewField161,REPORTNAME11,NewField1161};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public UserMaintenanceReport MyParentReport
            {
                get { return (UserMaintenanceReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField DAILYMAINTENANCE { get {return Body().DAILYMAINTENANCE;} }
            public TTReportField WEEKLYMAINTENANCE { get {return Body().WEEKLYMAINTENANCE;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField PARAMETER { get {return Body().PARAMETER;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                CMRActionRequest.GetUserMaintenanceReportQuery_Class dataSet_GetUserMaintenanceReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.GetUserMaintenanceReportQuery_Class>(0);    
                return new object[] {(dataSet_GetUserMaintenanceReportQuery==null ? null : dataSet_GetUserMaintenanceReportQuery.ObjectID)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public UserMaintenanceReport MyParentReport
                {
                    get { return (UserMaintenanceReport)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField DAILYMAINTENANCE;
                public TTReportField WEEKLYMAINTENANCE;
                public TTReportField DESCRIPTION;
                public TTReportField PARAMETER;
                public TTReportShape NewLine121;
                public TTReportShape NewLine1121; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    RepeatCount = 0;
                    
                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 31, 10, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    DAILYMAINTENANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 0, 139, 10, false);
                    DAILYMAINTENANCE.Name = "DAILYMAINTENANCE";
                    DAILYMAINTENANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    DAILYMAINTENANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAILYMAINTENANCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DAILYMAINTENANCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DAILYMAINTENANCE.TextFont.Name = "Arial";
                    DAILYMAINTENANCE.TextFont.CharSet = 162;
                    DAILYMAINTENANCE.Value = @"";

                    WEEKLYMAINTENANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 0, 154, 10, false);
                    WEEKLYMAINTENANCE.Name = "WEEKLYMAINTENANCE";
                    WEEKLYMAINTENANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    WEEKLYMAINTENANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEEKLYMAINTENANCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEEKLYMAINTENANCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEEKLYMAINTENANCE.TextFont.Name = "Arial";
                    WEEKLYMAINTENANCE.TextFont.CharSet = 162;
                    WEEKLYMAINTENANCE.Value = @"";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 0, 200, 10, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Name = "Arial";
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @" {#PARTA.DESCRIPTION#}";

                    PARAMETER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 0, 124, 10, false);
                    PARAMETER.Name = "PARAMETER";
                    PARAMETER.DrawStyle = DrawStyleConstants.vbSolid;
                    PARAMETER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAMETER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETER.MultiLine = EvetHayirEnum.ehEvet;
                    PARAMETER.WordBreak = EvetHayirEnum.ehEvet;
                    PARAMETER.TextFont.Name = "Arial";
                    PARAMETER.TextFont.CharSet = 162;
                    PARAMETER.Value = @" {#PARTA.PARAMETER#}";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 0, 20, 10, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.DrawWidth = 2;
                    NewLine121.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 0, 200, 10, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1121.DrawWidth = 2;
                    NewLine1121.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetUserMaintenanceReportQuery_Class dataset_GetUserMaintenanceReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<CMRActionRequest.GetUserMaintenanceReportQuery_Class>(0);
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    DAILYMAINTENANCE.CalcValue = @"";
                    WEEKLYMAINTENANCE.CalcValue = @"";
                    DESCRIPTION.CalcValue = @" " + (dataset_GetUserMaintenanceReportQuery != null ? Globals.ToStringCore(dataset_GetUserMaintenanceReportQuery.Description) : "");
                    PARAMETER.CalcValue = @" " + (dataset_GetUserMaintenanceReportQuery != null ? Globals.ToStringCore(dataset_GetUserMaintenanceReportQuery.Parameter) : "");
                    return new TTReportObject[] { COUNT,DAILYMAINTENANCE,WEEKLYMAINTENANCE,DESCRIPTION,PARAMETER};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public UserMaintenanceReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "USERMAINTENANCEREPORT";
            Caption = "Kullanıcı Seviyesi Bakım Formu";
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