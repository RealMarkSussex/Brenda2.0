using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using EFCoreFromExistingDB.Interfaces;
using GemBox.Spreadsheet;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;

namespace ServiceLayer
{
    public class SkillExcel
    {
        private readonly ExcelFile _workbook;
        private readonly IService _service;
        private readonly IReadOnlyList<ServiceSkill> _skills;
        public SkillExcel(IService service)
        {
            _service = service;
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            _workbook = new ExcelFile();
            _skills = _service.GetSkills().ToList();
        }
        public byte[] Create()
        {
            var options = SaveOptions.XlsxDefault;
            var skills = _service.GetSkills().ToList();
            CreateSkillsWorksheet();
            CreateSkillLevelWorksheet();

            return GetBytes(_workbook, options);
        }

        private void CreateSkillsWorksheet()
        {
            var worksheet = _workbook.Worksheets.Add("SkillsSheet");

            worksheet.Cells.GetSubrange("A1:C1").Style = GetStyle(Color.Chocolate);

            worksheet.Columns[0].SetWidth(50, LengthUnit.Pixel);
            worksheet.Columns[1].SetWidth(150, LengthUnit.Pixel);
            worksheet.Columns[2].SetWidth(150, LengthUnit.Pixel);

            worksheet.Cells["A1"].Value = "Id";
            worksheet.Cells["B1"].Value = "Name";
            worksheet.Cells["C1"].Value = "Description";
            for (var r = 1; r <= _skills.Count; r++)
            {
                var skill = _skills[r - 1];
                worksheet.Cells[r, 0].Value = skill.SkillId;
                worksheet.Cells[r, 1].Value = skill.Name;
                worksheet.Cells[r, 2].Value = skill.Description;
            }
        }

        private void CreateSkillLevelWorksheet()
        {
            var worksheet = _workbook.Worksheets.Add("SkillLevelSheet");

            worksheet.Columns[0].SetWidth(150, LengthUnit.Pixel);
            worksheet.Columns[1].SetWidth(150, LengthUnit.Pixel);

            var count = 0;
            var chocolateStyle = GetStyle(Color.Chocolate);
            var aquaStyle = GetStyle(Color.Aqua);
            foreach (var skill in _skills)
            {
                //Cells[3, 0] is A3
                worksheet.Cells[count, 0].Style = aquaStyle;
                worksheet.Cells[count, 0].Value = skill.Name;
                count++;

                worksheet.Cells[count, 0].Value = "Level Number";
                worksheet.Cells[count, 1].Value = "Description";
                worksheet.Cells[count, 0].Style = chocolateStyle;
                worksheet.Cells[count, 1].Style = chocolateStyle;
                count++;

                var levelNumber = 1; //each level is ordered in skillLevel collection
                foreach (var skillLevel in skill.SkillLevel)
                {
                    worksheet.Cells[count, 0].Style.Borders.SetBorders(MultipleBorders.Outside, Color.Black, LineStyle.Thin);
                    worksheet.Cells[count, 1].Style.Borders.SetBorders(MultipleBorders.Outside, Color.Black, LineStyle.Thin);
                    worksheet.Cells[count, 0].Value = levelNumber;
                    worksheet.Cells[count, 1].Value = skillLevel.Description;
                    count++;
                    levelNumber++;
                }
            }
        }

        private static CellStyle GetStyle(Color color)
        {
            var style = new CellStyle();
            style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
            style.VerticalAlignment = VerticalAlignmentStyle.Center;
            style.FillPattern.SetSolid(color);
            style.Font.Weight = ExcelFont.BoldWeight;
            style.Font.Color = Color.White;
            style.WrapText = true;
            style.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Thin);
            return style;
        }

        private static byte[] GetBytes(ExcelFile file, SaveOptions options)
        {
            using (var stream = new MemoryStream())
            {
                file.Save(stream, options);
                return stream.ToArray();
            }
        }
    }
}
