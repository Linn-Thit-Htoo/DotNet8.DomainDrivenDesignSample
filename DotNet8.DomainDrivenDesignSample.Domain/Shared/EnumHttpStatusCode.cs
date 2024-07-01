using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.DomainDrivenDesignSample.Domain.Shared
{
    public enum EnumHttpStatusCode
    {
        Success = 200,
        Created = 201,
        Accepted = 202,
        NoContent = 204,
        BadRequest = 400,
        UnAuthorized = 401,
        NotFound = 404,
        Conflict = 409,
        InternalServerError = 500
    }
}
