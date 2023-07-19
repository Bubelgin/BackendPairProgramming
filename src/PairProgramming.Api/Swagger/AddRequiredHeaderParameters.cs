using System.Collections.Generic;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using PairProgramming.Common.Constants;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PairProgramming.Api.Swagger
{
    public class AddRequiredHeaderParameters : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = HeaderConstants.ApplicationKey,
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema { Type = "string", Default = new OpenApiString("") },
                Required = true,
            });
        }
    }
}
