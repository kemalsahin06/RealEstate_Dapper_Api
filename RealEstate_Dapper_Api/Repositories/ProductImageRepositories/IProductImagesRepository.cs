﻿using RealEstate_Dapper_Api.Dtos.ProductImageDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductImageRepositories
{
    public interface IProductImagesRepository
    {
        Task<List<GetProductImageByProductIdDto>> GetProductImageByProductId(int id);
    }
}
