
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
        private readonly IReliabilityTestingConfigurationRepository _reliabilitytestingConfigurationRepository;
        private readonly IReliabilityTestingSheetRepository _reliabilitytestingsheetRepository;
        private readonly IDeformationTestingConfigurationRepository _deformationTestingConfigurationRepository;
        private readonly IDeformationTestingSheetRepository _deformationTestingSheetRepository;

        public DatabaseService(IunitOfWork unitOfWork, IReliabilityTestingConfigurationRepository testingConfigurationRepository, IReliabilityTestingSheetRepository testingsheetRepository, IDeformationTestingConfigurationRepository deformationTestingConfigurationRepository, IDeformationTestingSheetRepository deformationTestingSheetRepository)
        {
            _unitOfWork = unitOfWork;
            _reliabilitytestingConfigurationRepository = testingConfigurationRepository;
            _reliabilitytestingsheetRepository = testingsheetRepository;
            _deformationTestingConfigurationRepository = deformationTestingConfigurationRepository;
            _deformationTestingSheetRepository = deformationTestingSheetRepository;
        }




        #region ReliabilityTestingConfiguration
        public async Task<ServiceResponse> InsertReliabilityTestingConfigurations(ReliabilityTestingConfigurations testingConfigurations)
        {
            try
            {
                _reliabilitytestingConfigurationRepository.Insert(testingConfigurations);
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
        public async Task<ServiceResponse> ClearReliabilityConfiguration()
        {
            try
            {
                _reliabilitytestingConfigurationRepository.Clear();
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
        public async Task<IList<ReliabilityTestingConfigurations>> LoadAllReliabilityConfiguration()
        {
            return await _reliabilitytestingConfigurationRepository.LoadConfigurations();
        }

        #endregion

        #region RiliabilityTestingSheet

        public async Task<ServiceResponse> InsertReliability(TestSheet entry)
        {
            try
            {
                _reliabilitytestingsheetRepository.InsertReliability(entry);
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

        public async Task<IEnumerable<TestSheet>> LoadReliability()
        {
            return await _reliabilitytestingsheetRepository.LoadReliability();
        }
        public async Task<ServiceResponse> ClearReliability()
        {
            try
            {
                _reliabilitytestingsheetRepository.ClearReliability();
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
        #endregion

        #region DeformationTestingConfiguration
        public async Task<ServiceResponse> InsertDeformationTestingConfigurations(DeformationTestingConfigurations deformationtestingConfigurations)
        {
            try
            {
                _deformationTestingConfigurationRepository.Insert(deformationtestingConfigurations);
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
        public async Task<ServiceResponse> ClearDeformationConfiguration()
        {
            try
            {
                _deformationTestingConfigurationRepository.Clear();
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
        public async Task<IList<DeformationTestingConfigurations>> LoadAllDeformationConfiguration()
        {
            return await _deformationTestingConfigurationRepository.LoadConfigurations();
        }

        #endregion
        #region DeformationTestingSheet

        public async Task<ServiceResponse> InsertDeformation(DeformationTestSheet entry)
        {
            try
            {
                _deformationTestingSheetRepository.InsertDeformation(entry);
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

        
        public async Task<IEnumerable<DeformationTestSheet>> LoadDeformation()
        {
            return await _deformationTestingSheetRepository.LoadDeformation();
        }
        
        public async Task<ServiceResponse> ClearDeformation()
        {
            try
            {
                _deformationTestingSheetRepository.ClearDeformation();
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
    }
    #endregion
}

