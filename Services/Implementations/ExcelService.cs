using ClosedXML.Excel;
using Domain.Entities;
using Services.Helpers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ExcelService: IExcelService
    {
        public ExcelService()
        {

        }

        public async Task<byte[]> GenerateExcelFile()
        {
            List<MyEntity> entities = GenerateEntitiesList();

            DataSet ds = new DataSet();

            DataTable dataTable = Helper.GenerateDataTable(entities);

            ds.Tables.Add(dataTable);

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(ds);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;

                using (MemoryStream myMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(myMemoryStream);

                    return myMemoryStream.ToArray();
                }
            }
        }

        private List<MyEntity> GenerateEntitiesList()
        {
            List<MyEntity> list = new List<MyEntity>();

            list.Add(new MyEntity()
            {
                Id = 0,
                Name = "Injir",
                Age = 20
            });

            list.Add(new MyEntity()
            {
                Id = 1,
                Name = "Shawerma",
                Age = 24
            });

            return list;
        }
    }
}
