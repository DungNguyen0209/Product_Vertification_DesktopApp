using ProductVertificationDesktopApp.Domain.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.Communication
{
    public class ServiceResourceResponse<TResource> : ServiceResponse
    {
        public TResource Resource { get; private set; }
        public List<TResource> ResourceList { get; private set; }
        public ServiceResourceResponse(TResource resource)
        {
            Success = true;
            Error = null;
            Resource = resource;
        }

        public ServiceResourceResponse(List<TResource> resourcelist)
        {
            Success = true;
            Error = null;
            ResourceList = resourcelist;
        }
        public ServiceResourceResponse(Error error)
        {
            Success = false;
            Error = error;
            Resource = default;
        }
    }
}
