﻿using Microsoft.AspNetCore.Http;
using MindTheWorldServer.Domain;
using MindTheWorldServer.Extras.Helpers;
using MindTheWorldServer.Services.Definitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorldServer.Services.Implementations
{
    public class InfrastructureService : IInfrastructureService
    {
        private readonly ICsvTransformer _csvTransformer;
        private readonly ITransformService _transformService;
        private readonly MindTheWorldContext _mindTheWorldContext;

        public InfrastructureService(ICsvTransformer csvTransformer,
                                     ITransformService transformService,
                                     MindTheWorldContext mindTheWorldContext)
        {
            _csvTransformer = csvTransformer;
            _transformService = transformService;
            _mindTheWorldContext = mindTheWorldContext;
        }

        public async Task<IEnumerable<WaterSourceAccess>> ImportWaterSourceAccesses(IFormFile inputFile)
        {
            var dataTable = await _csvTransformer.Transform(inputFile);

            _mindTheWorldContext
                .WaterSourceAccesses
                .AddRange(await _transformService.ToEntities<WaterSourceAccess, decimal?>(dataTable));

            await _mindTheWorldContext.SaveChangesAsync();

            return null;
        }
    }
}