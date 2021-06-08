using OfficeOpenXml;
using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.Communication;
using ProductVertificationDesktopApp.Domain.Models;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductVertificationDesktopApp.Service
{
    public class Excel: IExcel
    {
        private  ExcelPackage package;
        private ExcelWorksheet worksheet;
        private async Task<ServiceResponse> ReadExcelFile(string path)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            try
            {
                // mở file excel
                package = new ExcelPackage(new FileInfo("ImportData.xlsx"));

                // lấy ra sheet đầu tiên để thao tác
                worksheet = package.Workbook.Worksheets[0];
                return ServiceResponse.Successful();
            }
            catch (Exception EE)
            {
                Error error = new Error
                {
                    ErrorCode = "ReadExcel",
                    Message = "Lỗi Đọc"
                };
                return  ServiceResponse.Failed(error);
            }

        }

        private async Task<ServiceResponse> EditExcelFile(List<TestingMachine> testingMachine)
        {
            try
            {
                for(int i=0; i<=20;i++)
                {
                    worksheet.Cells[15+i, 2].Value = testingMachine[i].TimeSmoothClosingLid;
                    worksheet.Cells[15 + i, 3].Value = testingMachine[i].StatusLidNotFall;
                    worksheet.Cells[15 + i, 4].Value = testingMachine[i].StatusLidNotLeak;
                    worksheet.Cells[15 + i, 5].Value = testingMachine[i].StatusLidResult;
                    worksheet.Cells[15 + i, 6].Value = testingMachine[i].TimeSmoothClosingPlinth;
                    worksheet.Cells[15 + i, 7].Value = testingMachine[i].StatusPlinthNotFall;
                    worksheet.Cells[15 + i, 8].Value = testingMachine[i].StatusPlinthNotLeak;
                    worksheet.Cells[15 + i, 9].Value = testingMachine[i].StatusPlinthResult;
                    worksheet.Cells[15 + i, 10].Value = testingMachine[i].TotalMistake;
                    worksheet.Cells[15 + i, 11].Value = testingMachine[i].Note;
                    worksheet.Cells[15 + i, 12].Value = testingMachine[i].TimeSmoothClosingLid;
                }
                return ServiceResponse.Successful();
            }
            catch (Exception EE)
            {
                Error error = new Error
                {
                    ErrorCode = "EditExcel",
                    Message = "Lỗi Edit"
                };
                return ServiceResponse.Failed(error);
            }
        }
        private async Task<ServiceResponse> ExportExcelFile()
        {
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }

            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
            }
            try
            {
                using (package)
                {
                    //Lưu file lại
                    Byte[] bin = package.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                return ServiceResponse.Successful();
            }
            catch (Exception EE)
            {
                Error error = new Error
                {
                    ErrorCode = "ExportExcel",
                    Message = "Lỗi Export"
                };
                return ServiceResponse.Failed(error);
            }
        }

        public async Task Exportdata(string path, List<TestingMachine> testingMachine)
        {
            var step1 = await ReadExcelFile(path);
            var step2 = await EditExcelFile(testingMachine);
            var step3 = await ExportExcelFile();
        }

    }
}
