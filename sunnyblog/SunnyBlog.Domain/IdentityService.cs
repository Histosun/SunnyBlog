using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunnyBlog.Domain
{
    public class IdentityService
    {
        private readonly IIdRepository userRepository;
        public IdentityService(IIdRepository userRepository)
        {
            this.userRepository = userRepository;
        }
    }
}
