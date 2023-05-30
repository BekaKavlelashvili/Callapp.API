using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callapp.Shared.Results
{
    public class Result : Result<object>
    {
        public Result()
        {
            MakeSucceded();
        }

        public Result(object @object) : base(@object)
        {
        }

        public Result(Error error) : base(error)
        {
        }

        public Result(List<string> errors) : base(errors)
        {

        }

        public Result(string errorMessage) : base(errorMessage)
        {
        }

        public void AddError(object somethingWentWrong)
        {
            throw new NotImplementedException();
        }
    }
}
