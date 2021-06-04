using ProductVertificationDesktopApp.IView;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Presenters.SupervisorPresenters.SupervisorParamPresenter
{
    class SupervisorDeformationParamPresenter
    {
        IViewParametersSetAndSup _viewParametersSetAndSup;
        Is71200ModellingMachine _is71200ModellingMachine;

        public SupervisorDeformationParamPresenter(IViewParametersSetAndSup viewParametersSetAndSup, Is71200ModellingMachine is71200ModellingMachine)
        {
            _viewParametersSetAndSup = viewParametersSetAndSup;
            _is71200ModellingMachine = is71200ModellingMachine;
            _is71200ModellingMachine.UpdateData.Add(UpdateView);
        }
        private void UpdateView (bool status)
        {
            _viewParametersSetAndSup.CompressionForceSettingsystem1 = _is71200ModellingMachine.CompressionForceSettingsystem1_SP;
            _viewParametersSetAndSup.CompressionForceSettingsystem2 = _is71200ModellingMachine.CompressionForceSettingsystem1_SP;
            _viewParametersSetAndSup.CompressionForceSettingsystem3 = _is71200ModellingMachine.CompressionForceSettingsystem2_SP;
            _viewParametersSetAndSup.TimeOccupying1 = _is71200ModellingMachine.TimeOccupying1;
            _viewParametersSetAndSup.TimeOccupying2 = _is71200ModellingMachine.TimeOccupying1;
            _viewParametersSetAndSup.TimeOccuping3 = _is71200ModellingMachine.TimeOccupying2;
            _viewParametersSetAndSup.NumberClick1 = _is71200ModellingMachine.NumberClick1_SP;
            _viewParametersSetAndSup.NumberClick2 = _is71200ModellingMachine.NumberClick1_SP;
            _viewParametersSetAndSup.NumberClick3 = _is71200ModellingMachine.NumberClick2_SP;

        }
    }
}
