
using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.Communication;
using ProductVertificationDesktopApp.Domain.Models.Resource;
using ProductVertificationDesktopApp.Persistence.Repositories.Interfaces;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Service
{
    public class DatabaseService: IDatabaseService
    {
        private readonly IunitOfWork _unitOfWork;
        private readonly ITestingConfigurationRepository _testingConfigurationRepository;
        private readonly ITestingSheetRepository _testingsheetRepository;

        public DatabaseService(IunitOfWork unitOfWork, ITestingConfigurationRepository testingConfigurationRepository, ITestingSheetRepository testingMachineRepository)
        {
            _unitOfWork = unitOfWork;
            _testingConfigurationRepository = testingConfigurationRepository;
            _testingsheetRepository = testingMachineRepository;
        }


        #region TestingConfiguration
        public async Task<ServiceResponse> UpdateConfigurationEntry(TestingConfigurations entry)
        {
            try
            {
                await _testingConfigurationRepository.Update(entry);
                await _unitOfWork.SaveChangeAsync();
                return ServiceResponse.Successful();
            }
            catch
            {
                _unitOfWork.DetachChange();
                var error = new Error
                {
                    ErrorCode = "Database.Update",
                    Message = "Lỗi database local."
                };
                return ServiceResponse.Failed(error);
            }
        }
        public async Task<ServiceResponse> InsertTestingConfigurations(TestingConfigurations testingConfigurations)
        {
            try
            {
                _testingConfigurationRepository.Insert(testingConfigurations);
                await _unitOfWork.SaveChangeAsync();

                return ServiceResponse.Successful();
            }
            catch
            {
                _unitOfWork.DetachChange();
                Error error = new Error
                {
                    ErrorCode = "Database.Insert",
                    Message = "Lỗi khác."
                };
                return ServiceResponse.Failed(error);
            }
        }
        public async Task<ServiceResponse> ClearConfiguration()
        {
            try
            {
                _testingConfigurationRepository.Clear();
                await _unitOfWork.SaveChangeAsync();
                return ServiceResponse.Successful();
            }
            catch
            {
                _unitOfWork.DetachChange();
                var error = new Error
                {
                    ErrorCode = "Database.Clear",
                    Message = "Lỗi database."
                };
                return ServiceResponse.Failed(error);
            }
        }
        public async Task<IEnumerable<TestingConfigurations>> LoadAllConfiguration()
        {
            return await _testingConfigurationRepository.Load();
        }
        public async Task<ServiceResourceResponse<TestingConfigurations>> FindTestId(string machineId)
        {
            try
            {
                var resultFindByMachineId = await _testingConfigurationRepository.FindTestId(machineId);
                return new ServiceResourceResponse<TestingConfigurations>(resultFindByMachineId);
            }
            catch
            {
                _unitOfWork.DetachChange();
                var error = new Error
                {
                    ErrorCode = "Database.FindConfigByMachineId",
                    Message = "Lỗi database."
                };
                return new ServiceResourceResponse<TestingConfigurations>(error);
            }
        }
        #endregion

        #region TestingMachine
        
        public async Task<ServiceResponse> InsertReliability(TestSheet entry)
        {
            try
            {
                _testingsheetRepository.InsertReliability(entry);
                await _unitOfWork.SaveChangeAsync();

                return ServiceResponse.Successful();
            }
            catch
            {
                _unitOfWork.DetachChange();
                Error error = new Error
                {
                    ErrorCode = "Database.Insert",
                    Message = "Lỗi khác."
                };
                return ServiceResponse.Failed(error);
            }
        }

      /*  public async Task<ServiceResponse> InsertDeformation(TestSheet entry)
        {
            try
            {
                _testingsheetRepository.InsertDeformation(entry);
                await _unitOfWork.SaveChangeAsync();

                return ServiceResponse.Successful();
            }
            catch
            {
                _unitOfWork.DetachChange();
                Error error = new Error
                {
                    ErrorCode = "Database.Insert",
                    Message = "Lỗi khác."
                };
                return ServiceResponse.Failed(error);
            }
        }*/
        public async Task<IEnumerable<TestSheet>> LoadReliability()
        {
            return await _testingsheetRepository.LoadReliability();
        }
       /* public async Task<IEnumerable<TestSheet>> LoadDeformation()
        {
            return await _testingsheetRepository.LoadDeformation();
        }*/
        public async Task<ServiceResponse> ClearReliability()
        {
            try
            {
                _testingsheetRepository.ClearReliability();
                await _unitOfWork.SaveChangeAsync();
                return ServiceResponse.Successful();
            }
            catch
            {
                _unitOfWork.DetachChange();
                var error = new Error
                {
                    ErrorCode = "Database.Clear",
                    Message = "Lỗi database."
                };
                return ServiceResponse.Failed(error);
            }
        }
       /* public async Task<ServiceResponse> ClearDeformation()
        {
            try
            {
                _testingsheetRepository.ClearDeformation();
                await _unitOfWork.SaveChangeAsync();
                return ServiceResponse.Successful();
            }
            catch
            {
                _unitOfWork.DetachChange();
                var error = new Error
                {
                    ErrorCode = "Database.Clear",
                    Message = "Lỗi database."
                };
                return ServiceResponse.Failed(error);
            }
        }*/
        #endregion
    }
}
