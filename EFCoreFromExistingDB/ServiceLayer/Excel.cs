using System;
using System.Collections.Generic;
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
    public class Excel
    {
        private readonly ExcelFile _workbook;
        private readonly IService _service;
        public Excel(IDataAccess database, IMapper mapper)
        {
            _service = new Service(database, mapper);
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            _workbook = new ExcelFile();
        }
        public byte[] Create()
        {
            var options = SaveOptions.XlsxDefault;
            CreateSkillsWorksheet();

            return GetBytes(_workbook, options);
        }

        private void CreateSkillsWorksheet()
        {
            var worksheet = _workbook.Worksheets.Add("SkillsSheet");

            var style = worksheet.Rows[0].Style;
            style.Font.Weight = ExcelFont.BoldWeight;
            style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
            worksheet.Columns[0].Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;

            worksheet.Columns[0].SetWidth(50, LengthUnit.Pixel);
            worksheet.Columns[1].SetWidth(150, LengthUnit.Pixel);
            worksheet.Columns[2].SetWidth(150, LengthUnit.Pixel);
            worksheet.Columns[3].SetWidth(150, LengthUnit.Pixel);
            worksheet.Columns[4].SetWidth(150, LengthUnit.Pixel);
            worksheet.Columns[5].SetWidth(150, LengthUnit.Pixel);
            worksheet.Columns[6].SetWidth(150, LengthUnit.Pixel);

            worksheet.Cells["A1"].Value = "Name";
            worksheet.Cells["B1"].Value = "Description";
            var skills = _service.GetSkills().ToList();
            for (var r = 1; r <= skills.Count; r++)
            {
                var item = skills[r - 1];
                worksheet.Cells[r, 0].Value = item.Name;
                worksheet.Cells[r, 1].Value = item.Description;
            }
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
