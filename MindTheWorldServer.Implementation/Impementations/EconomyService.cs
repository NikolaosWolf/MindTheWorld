﻿using Microsoft.AspNetCore.Http;
using MindTheWorldServer.Domain;
using MindTheWorldServer.Extras.Helpers;
using MindTheWorldServer.Services.Definitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindTheWorldServer.Services.Implementations
{
    public class EconomyService : IEconomyService
    {
        private readonly ICsvTransformer _csvTransformer;
        private readonly ITransformService _transformService;
        private readonly MindTheWorldContext _mindTheWorldContext;

        public EconomyService(ICsvTransformer csvTransformer,
                              ITransformService transformService,
                              MindTheWorldContext mindTheWorldContext)
        {
            _csvTransformer = csvTransformer;
            _transformService = transformService;
            _mindTheWorldContext = mindTheWorldContext;
        }

        public async Task<IEnumerable<GrossDomesticProduct>> ImportGrossDomesticProducts(IFormFile inputFile)
        {
            var dataTable = await _csvTransformer.Transform(inputFile);

            _mindTheWorldContext
                .GrossDomesticProducts
                .AddRange(await _transformService.ToEntities<GrossDomesticProduct, decimal?>(dataTable));

            await _mindTheWorldContext.SaveChangesAsync();

            return null;
        }
    }
}
